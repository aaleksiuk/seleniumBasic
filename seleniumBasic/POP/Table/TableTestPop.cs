using FluentAssertions;
using SeleniumBasic;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.POP.Table
{
    public class TableTestPop : TestBase
    {
        private TablePage tablePage;
        public TableTestPop(ITestOutputHelper output) : base(output)
        {

        }
        [Fact]
        public void TablePeaksInSwitzerland()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/table.php");

            //var rows = new TablePage(driver).GetRows();
            var rows = new LepszyTablePage(driver).GetRows();

            var definedCountry = "Switzerland";
            var definedHeight = 4000;
            rows.Should().NotBeEmpty();
            foreach (var row in rows)
            {
                if (row.GetHeight() > definedHeight && row.GetState().Contains(definedCountry))
                {
                    output.WriteLine(row.GetRank() + " " + row.GetPeak() + " " + row.GetHeight());
                }
            }
        }
    }
}
