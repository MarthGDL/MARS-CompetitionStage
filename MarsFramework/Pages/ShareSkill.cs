using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Net;
using System.Collections.Generic;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            Thread.Sleep(3000);
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize WebElements

        //Title textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Description textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Tag textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //CStart Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //End Date dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input")]
        private IWebElement EndDateDropDown { get; set; }

        //List of available days
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private IList<IWebElement> Days { get; set; }

        //StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Skill Trade "Exchange" option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillTradeExchangeOption { get; set; }

        //Skill Exchange textfield
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div[1]/div/div/div/div/input")]
        private IWebElement SkillExchange { get; set; }

        //Skill Trade "Credits" option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement SkillTradeCreditsOption { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //WorkSample
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span")]
        private IWebElement WorkSample { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        #endregion

        #region Page Methods

        internal void EnterText(int DataRow)
        {
            //Check if the user is able to Enter Text in the "Title" field
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ReadData(DataRow, "Title"));

            //Check if the user is able to Enter Text in the "Description" field
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ReadData(DataRow, "Description"));

        }

        internal void EditOptions(int DataRow)
        {
            //Check if the user is able to Click on the "Skill Exchange" option
            SkillTradeExchangeOption.Click();

            //Check if the user is able to create a tag for the "Skill Exchange" field
            SkillExchange.SendKeys(GlobalDefinitions.ReadData(DataRow, "SkillExchange") + Keys.Enter);
        }

        internal void FillDetails(int DataRow)
        {
            //Check if the user is able to Enter Text in the "Title" field
            EnterText(DataRow);

            //Check if the user is able to "Click" on the "Category" dropdown list
            CategoryDropDown.Click();
            CategoryDropDown.SendKeys(Keys.ArrowDown + Keys.Enter);

            //Check if the user is able to "Click" on the "SubCategory" dropdown list
            SubCategoryDropDown.Click();
            SubCategoryDropDown.SendKeys(Keys.ArrowDown + Keys.Enter);

            //Check if the user is able to "Enter" a "Tag"
            Tags.SendKeys(GlobalDefinitions.ReadData(DataRow, "Tag") + Keys.Enter);

            //Check if the user is able to "Click" on a "Service Type" option
            ServiceTypeOptions.Click();

            //Check if the user is able to "Click" on a "Location Type" option
            LocationTypeOption.Click();
        }

        internal void FillSchedrule(int DataRow)
        {
            //Check if the user is able to click on a "Start Date" for the "Available days" field
            StartDateDropDown.Click();
            StartDateDropDown.Clear();
            StartDateDropDown.SendKeys(GlobalDefinitions.ReadData(DataRow, "StartDate"));

            //Check if the user is able to click on a "End Date" for the "Available days" field
            EndDateDropDown.Click();
            EndDateDropDown.Clear();
            EndDateDropDown.SendKeys(GlobalDefinitions.ReadData(DataRow, "EndDate"));

            //Check if the user is able to click on a "Day" checkbox for the "Available days" field
            for (var i=1;i<=5;i++)
            {
                Days[i].Click();
            }

            //Check if the user is able to select a "Start Time" for the "Available days" field
            StartTimeDropDown.SendKeys(GlobalDefinitions.ReadData(DataRow, "StartTime"));

            //Check if the user is able to select a "End Time" for the "Available days" field
            EndTimeDropDown.SendKeys(GlobalDefinitions.ReadData(DataRow, "EndTime"));

            //Check if the user is able to click on "Credits" as the "Skill Trade" option
            SkillTradeCreditsOption.Click();

            //Check if the user is able to enter a number for the "Credits" field
            CreditAmount.Clear();
            CreditAmount.SendKeys(GlobalDefinitions.ReadData(DataRow, "Credit"));

            //Check if the user is able to set an option for the "Active" field
            ActiveOption.Click();

        }

        internal void UploadSample(int DataRow)
        {
            //Click on Upload Sample File
            WorkSample.Click();

            //Uses AutoIt to handle the file explorer
            AutoIt.UploadFile(GlobalDefinitions.ReadData(DataRow, "FilePath"));

        }

        #endregion


        internal void FillShareSkill(int DataRow)
        {
            //Prepares the Excel Sheet
            GlobalDefinitions.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Fills the form
            FillDetails(DataRow);
            FillSchedrule(DataRow);

            //Check if the user is able to load a file in the "Work Sample" field
            UploadSample(DataRow);

            //Check if the user can Click on the "Save" button
            Save.Click();
        }

        internal void EditShareSkill(int DataRow)
        {
            //Prepares the Excel Sheet
            GlobalDefinitions.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Edit the form
            EnterText(DataRow);

            //Edit the Trade option
            EditOptions(DataRow);

            //Check if the user can Click on the "Save" button
            Save.Click();
        }

    }
}
