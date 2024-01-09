﻿using SeleniumBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using OpenQA.Selenium;

namespace seleniumBasic
{
    public class Iframes : TestBase
    {
        [Fact]
        public void SwitchFrames()
        {
            Random r = new Random();
            driver.Navigate().GoToUrl("http://automation-practice.emilos.pl/iframes.php");

            driver.SwitchTo().Frame("iframe1");
            driver.FindElement(By.CssSelector("#inputFirstName3")).SendKeys("Anna");
            driver.FindElement(By.CssSelector("#inputSurname3")).SendKeys("Nazwisko");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame("iframe2");
            driver.FindElement(By.CssSelector("#inputLogin")).SendKeys("stute");
            driver.FindElement(By.CssSelector("#inputPassword")).SendKeys("12341234");

            var count = driver.FindElements(By.CssSelector("#inlineFormCustomSelectPref *")).Count();
            var rInt = r.Next(1, count);
            driver.FindElements(By.CssSelector("option"))[rInt].Click();

            count = driver.FindElements(By.CssSelector("[name=gridRadios]")).Count();
            rInt = r.Next(0, count);
            driver.FindElements(By.CssSelector("[name=gridRadios]"))[rInt].Click();

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.CssSelector(".nav-link.dropdown-toggle")).Click();
        }
    }
}
