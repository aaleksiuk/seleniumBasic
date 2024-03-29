﻿using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Basic
{
    public class Alerts : TestBase
    {
        public Alerts(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void SimpleAlertPopUp()
        {
            var expectedMsg = "OK button pressed";

            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/alerts.php");
            driver.FindElement(By.CssSelector("#simple-alert")).Click();
            driver.SwitchTo().Alert().Accept();

            expectedMsg.Should().Be(expectedMsg);
        }

        [Fact]
        public void PromptAlertBox()
        {
            var inputText = "Lord Vader";
            var expectedMsg = "Hello" + inputText + "! How are you today";

            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/alerts.php");
            driver.FindElement(By.CssSelector("#prompt-alert")).Click();
            driver.SwitchTo().Alert().SendKeys(Keys.Control + "a" + Keys.Delete);
            driver.SwitchTo().Alert().SendKeys(inputText);

            expectedMsg.Should().Be(expectedMsg);
        }

        [Fact]
        public void ConfirmAlertBox()
        {
            var expectedMsg_Ok = "You pressed OK!";
            var expectedMsg_Cancel = "You pressed Cancel!";

            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/alerts.php");
            driver.FindElement(By.CssSelector("#confirm-alert")).Click();
            driver.SwitchTo().Alert().Accept();
            expectedMsg_Ok.Should().Be(expectedMsg_Ok);

            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/alerts.php");
            driver.FindElement(By.CssSelector("#confirm-alert")).Click();
            driver.SwitchTo().Alert().Dismiss();
            expectedMsg_Cancel.Should().Be(expectedMsg_Cancel);
        }

        [Fact]
        public void DelayedAlert()
        {
            var expectedMsg_Pressed = "OK button pressed";
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/alerts.php");
            driver.FindElement(By.CssSelector("#delayed-alert")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(ExpectedConditions.AlertIsPresent());

            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("#delayed-alert-label"));
            expectedMsg_Pressed.Should().Be(expectedMsg_Pressed);
        }
    }
}