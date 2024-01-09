using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit.Abstractions;

namespace SeleniumBasic
{
    public abstract class TestBase : IDisposable
    {
        protected readonly IWebDriver driver;
        protected readonly ITestOutputHelper output;
        public TestBase(ITestOutputHelper output)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            this.output = output;
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}