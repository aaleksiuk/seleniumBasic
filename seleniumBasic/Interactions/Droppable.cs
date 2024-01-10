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
            IWebElement drag = driver.FindElement(By.Id("draggable"));
            IWebElement drop = driver.FindElement(By.Id("droppable"));
            Actions actions = new Actions(driver);
            actions.ClickAndHold(drag).MoveToElement(drop).Release().Perform();
            string expectedMsg = "Dropped!";

            string acutalMsg = driver.FindElement(By.CssSelector("p")).Text;///POPRAWIĆ!!!
            acutalMsg.Should().Be(expectedMsg);
        }
    }
}
