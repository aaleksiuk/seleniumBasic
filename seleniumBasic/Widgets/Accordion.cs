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

            var section1Text = driver.FindElement(By.CssSelector("#ui-id-2 p")).Text;

            output.WriteLine("Section 1 text: " + section1Text);

            driver.FindElement(By.CssSelector("#ui-id-3")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-4")));

            var section2Text = driver.FindElement(By.CssSelector("#ui-id-4 p")).Text;

            output.WriteLine("Section 2 text: " + section2Text);

            driver.FindElement(By.CssSelector("#ui-id-5")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-6")));

            var section3Text = driver.FindElement(By.CssSelector("#ui-id-6 p")).Text;
            var section3Text_ul = driver.FindElement(By.CssSelector("#ui-id-6 ul")).Text;

            output.WriteLine("Section 3 text: " + section3Text + "\n" + section3Text_ul);

            driver.FindElement(By.CssSelector("#ui-id-7")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#ui-id-8")));

            var section4Text = driver.FindElement(By.CssSelector("#ui-id-8 *:first-child")).Text;
            var section4Text_cd = driver.FindElement(By.CssSelector("#ui-id-8 *:last-child")).Text;

            output.WriteLine("Section 4 text:" + section4Text + "\n" + section4Text_cd);
        }
    }
}