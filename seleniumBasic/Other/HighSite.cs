using OpenQA.Selenium;
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

            for (var i = 0; i < 1000; i++)
            {
                Scroll100px_js(driver);
                if (driver.FindElements(By.CssSelector("#scroll-button")).Count > 0)
                    break;
            }
        }
        [Fact]
        public void Js_HighSite()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/high-site.php");
            Action_HighSite();

            for (var i = 0; i < 1000; i++)
            {
                Scroll100px();
                if (driver.FindElements(By.CssSelector("#scroll-button")).Count > 0)
                    break;
            }
        }

        private void Scroll100px()
        {
            var actions = new Actions(driver);
            _ = actions.ScrollByAmount(0, -100);
        }
        private void Scroll100px_js(IWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,100)");
        }
    }
}