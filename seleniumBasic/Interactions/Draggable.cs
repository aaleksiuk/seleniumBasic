using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using System;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Interactions
{
    public class Draggable : TestBase
    {
        public Draggable(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void DragSquareToUpperRightCornerOfPage()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/draggable.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var windowX = driver.Manage().Window.Size.Width;
            var windowY = driver.Manage().Window.Size.Height;

            var draggableElement = driver.FindElement(By.CssSelector("#draggable"));
            var elementLengh = draggableElement.Size.Width;
            var elementHight = draggableElement.Size.Height;

            var localizationX = draggableElement.Location.X;
            var localizationY = draggableElement.Location.Y;

            new Actions(driver)
    .DragAndDropToOffset(draggableElement, windowX - (localizationX + elementLengh), -localizationY)
    .Perform();
        }
        [Fact]
        public void DragSquareToBottomRightCornerOfPage()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/draggable.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var windowX = driver.Manage().Window.Size.Width;
            var windowY = driver.Manage().Window.Size.Height;

            var draggableElement = driver.FindElement(By.CssSelector("#draggable"));
            var elementLengh = draggableElement.Size.Width;
            var elementHight = draggableElement.Size.Height;

            var localizationX = draggableElement.Location.X;
            var localizationY = draggableElement.Location.Y;
            var offsetY = windowY - localizationY - elementHight - localizationY;

            new Actions(driver)
    .DragAndDropToOffset(draggableElement, windowX - (localizationX + elementLengh), windowY - localizationY - (2 * elementHight))
    .Perform();
        }
        [Fact]
        public void DragSquareToTopCenterOfPage()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/draggable.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var windowX = driver.Manage().Window.Size.Width;
            var windowY = driver.Manage().Window.Size.Height;

            var draggableElement = driver.FindElement(By.CssSelector("#draggable"));
            var elementLengh = draggableElement.Size.Width;
            var elementHight = draggableElement.Size.Height;

            var localizationX = draggableElement.Location.X;
            var localizationY = draggableElement.Location.Y;

            new Actions(driver)
    .DragAndDropToOffset(draggableElement, windowX / 2 - localizationX - elementLengh / 2, -localizationY)
    .Perform();
        }
        [Fact]
        public void DragSquareToBottomLeftCornerOfPage()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/draggable.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var windowX = driver.Manage().Window.Size.Width;
            var windowY = driver.Manage().Window.Size.Height;

            var draggableElement = driver.FindElement(By.CssSelector("#draggable"));
            var elementLengh = draggableElement.Size.Width;
            var elementHight = draggableElement.Size.Height;

            var localizationX = draggableElement.Location.X;
            var localizationY = draggableElement.Location.Y;

            new Actions(driver)
    .DragAndDropToOffset(draggableElement, -localizationX, -localizationY)
    .Perform();
        }
    }
}