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

            string definedCountry = "Switzerland";
            int definedHeight = 4000;

            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.CssSelector("table tbody tr"));
            foreach (IWebElement row in rows)
            {
                int rank = int.Parse(row.FindElement(By.CssSelector("th")).Text);
                string peak = row.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                string state = row.FindElement(By.CssSelector("td:nth-child(4)")).Text;
                int height = int.Parse(row.FindElement(By.CssSelector("td:nth-child(5)")).Text);

                if (state.Contains(definedCountry) && (height > definedHeight))
                {
                    output.WriteLine(rank + " " + peak + " " + height);
                }
            }
        }
    }
}
