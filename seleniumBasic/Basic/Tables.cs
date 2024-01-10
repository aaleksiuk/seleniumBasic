using OpenQA.Selenium;
using SeleniumBasic;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Basic
{
    public class Tables : TestBase
    {
        public Tables(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TablePeaksInSwitzerland()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/table.php");

            var definedCountry = "Switzerland";
            var definedHeight = 4000;

            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            foreach (var row in rows)
            {
                var rank = int.Parse(row.FindElement(By.CssSelector("th")).Text);
                var peak = row.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                var state = row.FindElement(By.CssSelector("td:nth-child(4)")).Text;
                var height = int.Parse(row.FindElement(By.CssSelector("td:nth-child(5)")).Text);

                if (state.Contains(definedCountry) && (height > definedHeight))
                {
                    output.WriteLine(rank + " " + peak + " " + height);
                }
            }
        }
    }
}
