using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Widgets
{
    public class Menu : TestBase
    {
        public Menu(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void MenuItem()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/menu-item.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElement(By.CssSelector("#ui-id-9")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-13")));
            driver.FindElement(By.CssSelector("#ui-id-13")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-16")));
            driver.FindElement(By.CssSelector("#ui-id-16")).Click();
        }
    }
}
