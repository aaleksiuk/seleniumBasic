using OpenQA.Selenium;
using SeleniumBasic;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Widgets
{
    public class Tooltip : TestBase
    {
        public Tooltip(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void PrintOutMsgFromTooltip()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/tooltip.php");
            IWebElement age = driver.FindElement(By.CssSelector("#age"));
            string actualTooltip = age.GetAttribute("title");
            output.WriteLine(actualTooltip);
        }
    }
}
