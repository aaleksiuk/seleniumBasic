using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Widgets
{
    public class Progressbar : TestBase
    {
        public Progressbar(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ExpectedLabel()//Pierwsza wersja:Wait until the text in progress bar label will be "Complete!"
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/progressbar.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => d.FindElement(By.XPath("//div[@class='progress-label']")).GetAttribute("value") == "Complete!");
            wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Complete!')][@class='progress-label']")));
            
        }
        [Fact] //Wait until ‘class’ attribute of progress bar will contain text: "ui-progressbar-complete"
        public void ClassContainText()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/progressbar.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'ui-progressbar-complete')]")));
        }
    }
}