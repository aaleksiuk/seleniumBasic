using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumBasic;
using Xunit;
using Xunit.Abstractions;

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
            var drag = driver.FindElement(By.Id("draggable"));
            var drop = driver.FindElement(By.Id("droppable"));
            var actions = new Actions(driver);

            actions.ClickAndHold(drag).MoveToElement(drop).Release().Perform();
            var expectedMsg = "Dropped!";

            var acutalMsg = driver.FindElement(By.CssSelector("#droppable p")).Text;
            acutalMsg.Should().Be(expectedMsg);
        }
    }
}
