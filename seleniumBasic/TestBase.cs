using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumBasic
{
    public abstract class TestBase : IDisposable
    {
        protected readonly IWebDriver driver;
        public TestBase()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}