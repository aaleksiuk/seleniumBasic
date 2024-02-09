using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic2.Widgets
{
    public class Accordion : TestBase
    {
        public Accordion(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void AccordionPrint()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/accordion.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            driver.FindElement(By.CssSelector("#ui-id-1")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-2")));
            var Section1Text = driver.FindElement(By.XPath("//div[@class='ui-accordion-content ui-corner-bottom ui-helper-reset ui-widget-content ui-accordion-content-active']//p")).Text;
            output.WriteLine("Section 1 text:" + Section1Text);

            driver.FindElement(By.CssSelector("#ui-id-3")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-4")));
            var Section2Text = driver.FindElement(By.XPath("//div[@class='ui-accordion-content ui-corner-bottom ui-helper-reset ui-widget-content ui-accordion-content-active']//p")).Text;
            output.WriteLine("Section 2 text:" + Section2Text);

            driver.FindElement(By.CssSelector("#ui-id-5")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-6")));
            var Section3Text = driver.FindElement(By.XPath("//div[@class='ui-accordion-content ui-corner-bottom ui-helper-reset ui-widget-content ui-accordion-content-active']//p")).Text;
            var Section3Text_ul = driver.FindElement(By.XPath("//div[@class='ui-accordion-content ui-corner-bottom ui-helper-reset ui-widget-content ui-accordion-content-active']//ul")).Text;
            output.WriteLine("Section 3 text:" + Section3Text + Section3Text_ul);

            driver.FindElement(By.CssSelector("#ui-id-7")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-8")));
            var Section4Text = driver.FindElement(By.XPath("//div[@class='ui-accordion-content ui-corner-bottom ui-helper-reset ui-widget-content ui-accordion-content-active']//p[1]")).Text;
            var Section4Text_cd = driver.FindElement(By.XPath("//div[@class='ui-accordion-content ui-corner-bottom ui-helper-reset ui-widget-content ui-accordion-content-active']//p[2]")).Text;
            output.WriteLine("Section 4 text:" + Section4Text + Section4Text_cd);
        }
    }
}