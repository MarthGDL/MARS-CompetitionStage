using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ExcelPath = "C:\\Users\\limbo\\Documents\\VisualStudio2019\\MVP-MARS\\marsframework-master\\MarsFramework\\ExcelData\\TestData.xlsx";//MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string DockerPath = "http://192.168.99.100:5000/";
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [OneTimeSetUp]
        public void Inititalize()
        {

            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    break;

            }

            //Navigate to the MARS Home page
            GlobalDefinitions.driver.Navigate().GoToUrl(Base.DockerPath);

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);

            #endregion

            //Check if the account has been created and create one if not
            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

        }

        [SetUp]
        public void SetUp()
        {
            //Sends the test to the Start Page
            if (GlobalDefinitions.driver.Url!= Base.DockerPath) 
            {
                GlobalDefinitions.driver.Navigate().GoToUrl("http://192.168.99.100:5000/Account/Profile");
                Thread.Sleep(1000);
            }
        }

            [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
            //AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            //test.Log(LogStatus.Info, "Image example: " + img);
            //end test. (Reports)
            //extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            //extent.Flush();
        }

        [OneTimeTearDown]
        public void EndTesting()
        {
            // Close the driver            
            //GlobalDefinitions.driver.Close();
            //GlobalDefinitions.driver.Quit();
        }
        #endregion

    }
}