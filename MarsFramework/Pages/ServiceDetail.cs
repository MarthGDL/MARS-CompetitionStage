using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MarsFramework.Pages
{
    class ServiceDetail
    {
        public ServiceDetail()
        {
            Thread.Sleep(3000);
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region Initialize WebElements
        //Click on Manage Listings Link
        [FindsBy(How = How.ClassName, Using = "//div[@class='description']")]
        private IWebElement Description { get; set; }

        #endregion

        internal void CheckDetails(int DataRow)
        {
            //Prepares the Excel Sheet
            GlobalDefinitions.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Creates a result variable
            bool CheckResult = true;

            //Compares description with expected description
            if (Description.Text!= GlobalDefinitions.ReadData(DataRow, "Description")) { CheckResult = false; }

            if (CheckResult==true)
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
