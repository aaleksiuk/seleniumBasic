using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace seleniumBasic.POP.Table
{
    public class RowPage
    {
        public RowPage(IWebElement parent)
        {
            PageFactory.InitElements(this, new DefaultElementLocator(parent));
        }
        [FindsBy(How = How.CssSelector, Using = "th")]
        private IWebElement Rank;

        [FindsBy(How = How.XPath, Using = "./td[1]")]
        private IWebElement Peak;

        [FindsBy(How = How.XPath, Using = "./td[2]")]
        private IWebElement MountainRange;

        [FindsBy(How = How.XPath, Using = "./td[3]")]
        private IWebElement State;

        [FindsBy(How = How.XPath, Using = "./td[4]")]
        private IWebElement Height;

        public string GetRank() => Rank.Text;

        public string GetPeak() => Peak.Text;

        public string GetMountainRange() => MountainRange.Text;

        public string GetState() => State.Text;

        public int GetHeight() => int.Parse(Height.Text);
    }
}