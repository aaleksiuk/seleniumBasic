using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumBasic;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Interactions
{
    public class Selectable : TestBase
    {
        public Selectable(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void SelectableItem()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/selectable.php");

            var actions = new Actions(driver);
            var select1 = driver.FindElement(By.CssSelector("ol > li:nth-child(1)"));
            var select3 = driver.FindElement(By.CssSelector("ol > li:nth-child(3)"));
            var select5 = driver.FindElement(By.CssSelector("ol > li:nth-child(5)"));

            actions.KeyDown(Keys.LeftControl).Click(select1).Click(select3).Click(select5).Perform();

            var expectedMsg = "You've selected: #1 #3 #5.";
            var acutalMsg = driver.FindElement(By.Id("feedback")).Text;
            acutalMsg.Should().Be(expectedMsg);
        }
    }
}
