using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumBasic;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Other
{
    public class DemoQa : TestBase
    {
        public DemoQa(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void AutomationPractiseForm()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(3000);

            var subject = driver.FindElement(By.CssSelector("#subjectsContainer"));
            subject.Click();

            var actions = new Actions(driver);

            actions.SendKeys("m").Perform();
            Thread.Sleep(1000);
            actions.SendKeys(Keys.Enter).Perform();

            actions.SendKeys("a").Perform();
            Thread.Sleep(1000);
            actions.SendKeys(Keys.ArrowDown + Keys.Enter).Perform();

            string[] expectedValuesText = { "Maths", "Arts" };
            var selectedValues = driver.FindElements(By.CssSelector(".subjects-auto-complete__multi-value__label")).Select(e => e.Text).ToArray();
            var i= 0;
            foreach (var value in selectedValues)
            {
                expectedValuesText[i++].Should().Be(value.ToString());
            }
        }
    }
}
