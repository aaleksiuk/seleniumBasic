using OpenQA.Selenium;
using seleniumBasic.Extensions;
using seleniumBasic.POP.Table;
using System.Collections.Generic;

namespace seleniumBasic.POP
{
    public class LepszyTablePage(IWebDriver driver)
    {
        private IList<IWebElement> Rows => driver.WaitAndFindAll(By.CssSelector("table tbody tr"));

        public List<RowPage> GetRows()
        {
            var rows = new List<RowPage>();
            foreach (var row in Rows)
            {
                rows.Add(new RowPage(row));
            }
            return rows;
        }
    }
}