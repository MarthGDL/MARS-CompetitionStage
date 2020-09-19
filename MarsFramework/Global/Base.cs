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
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
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
            GlobalDefinitions.driver.Navigate().GoToUrl("http://192.168.99.100:5000/");

            SignIn SignInPage = new SignIn();
            SignInPage.LoginSteps();

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);

            #endregion

            /*
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
            */

        }

        [SetUp]
        public void SetUp()
        {
            //Sends the test to the Start Page
            if (GlobalDefinitions.driver.Url!= "http://192.168.99.100:5000/") 
            {
                GlobalDefinitions.driver.Navigate().GoToUrl("http://192.168.99.100:5000/Account/Profile");
                Thread.Sleep(1000);
            }
        }

            [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            //test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
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