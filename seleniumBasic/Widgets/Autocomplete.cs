using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Widgets
{
    public class Autocomplete : TestBase
    {
        public Autocomplete(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Autocomplete_print()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/autocomplete.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(By.CssSelector("#search")).SendKeys("a");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ui-menu-item-wrapper']")));

            var results = driver.FindElements(By.XPath("//div[@class='ui-menu-item-wrapper']")).Select(e => e.Text).ToArray();
            var i = 0;
            foreach (var value in results)
            {
                output.WriteLine(results[i++].ToString());
            }
            
            var r = new Random();
            var count = results.Count();
            var rInt = r.Next(1, count);
            var presentedVal = results[rInt].ToString();
            driver.FindElements(By.XPath("//div[@class='ui-menu-item-wrapper']"))[rInt].Click();

            var searchPhrase = driver.FindElement(By.Id("search")).GetAttribute("value");
            searchPhrase.Should().Be(presentedVal);
        }
    }
}