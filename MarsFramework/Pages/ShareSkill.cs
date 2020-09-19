using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
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

        //Table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Monday Box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement MondayBox { get; set; }

        //Tuesday Box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[4]/div[1]/div/input")]
        private IWebElement TuesdayBox { get; set; }

        //Wednesday Box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[5]/div[1]/div/input")]
        private IWebElement WednesdayBox { get; set; }

        //Thursday Box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input")]
        private IWebElement ThursdayBox { get; set; }

        //Friday Box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[1]/div/input")]
        private IWebElement FridayBox { get; set; }

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
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
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

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        #endregion

        #region Page Methods

        internal void FillDetails()
        {
            //Enter text for the Share Skill details
            Title.SendKeys("TitleText");
            Description.SendKeys("DescriptionText");

            //Selects Categories using the dropdown list
            CategoryDropDown.Click();
            CategoryDropDown.SendKeys(Keys.ArrowDown + Keys.Enter);
            SubCategoryDropDown.Click();
            SubCategoryDropDown.SendKeys(Keys.ArrowDown + Keys.Enter);

            //Creates a Tag by entering text and pressing enter
            Tags.SendKeys("Tag" + Keys.Enter);

            //Sets the Service and Location options
            ServiceTypeOptions.Click();
            LocationTypeOption.Click();
        }

        internal void FillSchedrule()
        {
            //Open the StartDate DropDown list and enter a value
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys("19/12/2020");

            //Open the EndDate DropDown list and enter a value
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys("25/03/2021");

            //Checks the boxes for Monday to Friday
            MondayBox.Click();
            TuesdayBox.Click();
            WednesdayBox.Click();
            ThursdayBox.Click();
            FridayBox.Click();

            //Sets StartTime and EndTime with the Dropdown list
            StartTimeDropDown.Click();
            EndTimeDropDown.Click();

            //Selects a Skill trade option and fills its value
            SkillTradeCreditsOption.Click();
            CreditAmount.SendKeys("5.50");

            //Sets the "Active" option to hidden
            ActiveOption.Click();
        }

        #endregion


        internal void AddShareSkill()
        {
            FillDetails();
            FillSchedrule();
            Save.Click();
        }

        internal void EditShareSkill()
        {

        }

        internal void DeleteShareSkill()
        {

        }

    }
}
