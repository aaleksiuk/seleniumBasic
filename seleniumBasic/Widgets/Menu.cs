using SeleniumBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElement(By.CssSelector("#ui-id-9")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-13")));
            driver.FindElement(By.CssSelector("#ui-id-13")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-16")));
            driver.FindElement(By.CssSelector("#ui-id-16")).Click();
        }
    }
}
