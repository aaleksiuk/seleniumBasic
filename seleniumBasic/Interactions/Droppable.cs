using SeleniumBasic;
using Xunit.Abstractions;
using Xunit;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using FluentAssertions;

namespace seleniumBasic.Interactions
{
    public class Droppable : TestBase
    {
        public Droppable(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public void DroppableItem()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/droppable.php");
            IWebElement drag = driver.FindElement(By.Id("draggable")); 
            IWebElement drop = driver.FindElement(By.Id("droppable")); 
            Actions actions = new Actions(driver);
            actions.ClickAndHold(drag).MoveToElement(drop).Release().Perform();
            var expectedMsg = "Dropped!";
            var acutalMsg = driver.FindElement(By.CssSelector("#p")).Text;
            acutalMsg.Should().Be(expectedMsg);
        }
    }
}
