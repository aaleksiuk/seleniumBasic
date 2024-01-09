using FluentAssertions;
using OpenQA.Selenium;
using SeleniumBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace seleniumBasic
{
    public class Tables : TestBase
    {
        [Fact]
        public void SimpleAlertPopUp()
        {
            var expectedMsg = "OK button pressed";
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/alerts.php");
            driver.FindElement(By.CssSelector("#simple-alert")).Click();
            driver.SwitchTo().Alert().Accept();
            expectedMsg.Should().Be(expectedMsg);
        }
    }
}
