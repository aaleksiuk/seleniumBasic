using OpenQA.Selenium;
using seleniumBasic.Extensions;

namespace seleniumBasic.POP.Table
{
    public class LepszyRowPage(IWebDriver driver)
    {
        private IWebElement Rank => driver.WaitAndFind(By.XPath("th"));
        private IWebElement Peak => driver.WaitAndFind(By.XPath("./td[1]"));
        private IWebElement MountainRange => driver.WaitAndFind(By.XPath("./td[2]"));
        private IWebElement State => driver.WaitAndFind(By.XPath("./td[3]"));
        private IWebElement Height => driver.WaitAndFind(By.XPath("./td[4]"));

        public string GetRank() => Rank.Text;
        public string GetPeak() => Peak.Text;
        public string GetMountainRange() => MountainRange.Text;
        public string GetState() => State.Text;
        public int GetHeight() => int.Parse(Height.Text);
    }
}