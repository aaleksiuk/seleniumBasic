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

            Actions actions = new Actions(driver);
            IWebElement select1 = driver.FindElement(By.CssSelector("ol > li:nth-child(1)"));
            IWebElement select3 = driver.FindElement(By.CssSelector("ol > li:nth-child(3)"));
            IWebElement select5 = driver.FindElement(By.CssSelector("ol > li:nth-child(5)"));

            actions.KeyDown(Keys.LeftControl).Click(select1).Click(select3).Click(select5).Perform();

            string expectedMsg = "You've selected: #1 #3 #5.";
            string acutalMsg = driver.FindElement(By.Id("feedback")).Text;
            acutalMsg.Should().Be(expectedMsg);
        }
    }
}
