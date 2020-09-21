using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarsFramework.Global
{
    class WaitHelper
    {
        public static void WaitClickble(IWebDriver driver, IWebElement element)
        {
            try
            {
                var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 25));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            } catch (Exception e) 
            {
                Assert.Fail();
            }

        }
    }
}
