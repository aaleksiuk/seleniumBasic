using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Widgets
{
    public class ModalDialog : TestBase
    {
        public ModalDialog(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ModalDialogCreateUser()
        {

            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/modal-dialog.php");
            driver.FindElement(By.CssSelector("#create-user")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#dialog-form")));
            var expectedName = "Jan Kowalski";
            var expectedMail = "mail@mail.com";
            var expectedPassword = "qwe123";
            SetName(expectedName);
            SetEmail(expectedMail);
            SetPassword(expectedPassword);

            driver.FindElement(By.XPath("//button[.='Create an account']")).Click();
            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            var lastRow = rows.Last();

            var name = lastRow.FindElement(By.CssSelector("td:nth-child(1)")).Text;
            var email = lastRow.FindElement(By.CssSelector("td:nth-child(2)")).Text;
            var password = lastRow.FindElement(By.CssSelector("td:nth-child(3)")).Text;

            expectedName.Should().Be(name);
            expectedMail.Should().Be(email);
            expectedPassword.Should().Be(password);
        }

        private void SetName(string text)
        {
            driver.FindElement(By.CssSelector("#name")).Clear();
            driver.FindElement(By.CssSelector("#name")).SendKeys(text);
        }
        private void SetEmail(string text)
        {
            driver.FindElement(By.CssSelector("#email")).Clear();
            driver.FindElement(By.CssSelector("#email")).SendKeys(text);
        }
        private void SetPassword(string text)
        {
            driver.FindElement(By.CssSelector("#password")).Clear();
            driver.FindElement(By.CssSelector("#password")).SendKeys(text);
        }
    }

}