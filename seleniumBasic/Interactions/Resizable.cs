using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Interactions
{
    public class Resizable : TestBase
    {
        public Resizable(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ResizeWindowToTheRight()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/resizable.php");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ui-widget-content ui-resizable']")));

            var resizableElement = driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-e']"));
            new Actions(driver).ClickAndHold(resizableElement).MoveByOffset(100, 0).Perform();
        }
        [Fact]
        public void ResizeWindowToTheBottom()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/resizable.php");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ui-widget-content ui-resizable']")));

            var resizableElement = driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-s']"));
            new Actions(driver).ClickAndHold(resizableElement).MoveByOffset(0, 100).Perform();
        }
        [Fact]
        public void ResizeWindowToTheRightAndBottom()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/resizable.php");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ui-widget-content ui-resizable']")));

            var resizableElement = driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));
            new Actions(driver).ClickAndHold(resizableElement).MoveByOffset(100, 100).Perform();
        }
    }
}