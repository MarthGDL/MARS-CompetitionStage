using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            Thread.Sleep(5000);
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region Initialize WebElements
        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //Alert "Yes" Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement YesBtn { get; set; }

        //Alert "No" Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[1]")]
        private IWebElement NoBtn { get; set; }

        //Skill Listing Title
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement SkillTitle { get; set; }

        //Skill Listing Description
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")]
        private IWebElement SkillDescription { get; set; }

        //Last Skill Listing Card
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[last()]")]
        private IWebElement LastSkillListing { get; set; }

        #endregion

        internal void EditListing()
        {
            edit.Click();
        }

        internal void DeleteListing()
        {
            delete.Click();
            YesBtn.Click();
        }

        internal void CheckListing(int DataRow)
        {
            //Creates a bool to determine the check result
            bool CheckResult = true;

            //Prepares the Excel Sheet
            GlobalDefinitions.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Compares the listing data
            if (SkillDescription.Text != GlobalDefinitions.ReadData(DataRow, "Description")) { CheckResult = false; }

            //Asserts the test base on the Check Result
            if (CheckResult==true)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }

        internal void CompareLastEntry()
        {
            //Creates a new Web Element for the last() listed element and compares it with the previous last element
            IWebElement NewLastEntry = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[last()]"));
            if (LastSkillListing!= NewLastEntry) 
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

    }
}
