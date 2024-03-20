using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Widgets
{
    public class Selectmenu : TestBase
    {
        public Selectmenu(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void SelectRandomSpeed()
        {
            var r = new Random();
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/selectmenu.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var count = driver.FindElements(By.CssSelector("#speed *")).Count();
            var rInt = r.Next(1, count);

            var speedButton = driver.FindElement(By.CssSelector("#speed-button"));
            speedButton.Click();
            wait.Until(d => d.FindElement(By.CssSelector("#speed-button")).GetAttribute("aria-expanded") == "true");

            var speedId = "#ui-id-" + rInt.ToString();
            driver.FindElement(By.CssSelector(speedId)).Click();
        }

        [Fact]
        public void SelectFileFromText()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/selectmenu.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.Id("files-button")).Click();
            wait.Until(d => d.FindElement(By.CssSelector("#files-button")).GetAttribute("aria-expanded") == "true");

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("files-menu")));

            var text = "ui.jQuery.js";
            var liElement = driver.FindElement(By.XPath($"//li[@class='ui-menu-item']//div[text()='{text}']"));
            liElement.Click();
        }

        [Fact]
        public void SelectNumberByIndex()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/selectmenu.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var numberButton = driver.FindElement(By.CssSelector("#number-button"));
            numberButton.Click();
            wait.Until(d => d.FindElement(By.CssSelector("#number-button")).GetAttribute("aria-expanded") == "true");
            driver.FindElement(By.XPath("//div[@id='ui-id-6']")).Click();
        }
        [Fact]
        public void SelectRandomOptionTitle()
        {
            var r = new Random();
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/selectmenu.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var salutationButton = driver.FindElement(By.CssSelector("#salutation-button"));
            salutationButton.Click();
            wait.Until(d => d.FindElement(By.CssSelector("#salutation-button")).GetAttribute("aria-expanded") == "true");

            var count = driver.FindElements(By.XPath("//div[@class='ui-menu-item-wrapper']")).Count();
            var rInt = r.Next(1, count);
            var salutationId = "#ui-id-" + rInt.ToString();
            driver.FindElement(By.CssSelector(salutationId)).Click();
        }
    }
}
