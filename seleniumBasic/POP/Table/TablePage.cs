using OpenQA.Selenium;
using seleniumBasic.POP.Table;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace seleniumBasic.POP
{
    public class TablePage
    {
        public TablePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "table tbody tr")]
        private IList<IWebElement> Rows;

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