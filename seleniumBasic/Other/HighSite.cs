﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumBasic;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Other
{
    public class HighSite : TestBase
    {
        public HighSite(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Action_HighSite()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/high-site.php");

            var height = driver.Manage().Window.Size.Height;
            for (var i = 0; i < height; i++)
            {
                Scroll100px();
                if (driver.FindElements(By.CssSelector("#scroll-button")).Count > 0)
                {
                    Printscreen("Action");
                    return;
                }
            }

            Assert.Fail("Scroll-button not found");
        }

        private void Printscreen(string function)
        {
            var screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("Screenshots\\screenshot_" + function + ".png");
        }

        [Fact]
        public void Js_HighSite()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/high-site.php");
            var height = driver.Manage().Window.Size.Height;
            for (var i = 0; i < height; i++)
            {
                Scroll100px_js(driver);
                if (driver.FindElements(By.CssSelector("#scroll-button")).Count > 0)
                {
                    Printscreen("Js");
                    return;
                }
            }

            Assert.Fail("Scroll-button not found");
        }

        private void Scroll100px()
        {
            var actions = new Actions(driver);
            actions.ScrollByAmount(0, 100).Perform();
        }
        private void Scroll100px_js(IWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,100)");
        }
    }
}