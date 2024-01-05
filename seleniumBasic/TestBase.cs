using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumBasic
{
    public abstract class TestBase
    {
        protected readonly IWebDriver driver;
        public TestBase()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/form.php");
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}