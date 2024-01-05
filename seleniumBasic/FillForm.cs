using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Repeat;

namespace SeleniumBasic
{
    public class FillForm : TestBase, IDisposable
    {
        [Theory] //check "Form send with success"
        [Repeat(30)]
        public void Successfully(int iterationNumber)
        {
            Random r = new Random();

            //name
            SetFirstName("Jan");

            //lastname
            SetLastName("Kowalski");

            //mail
            SetEmail("mail@mail.com");

            //sex
            var count = driver.FindElements(By.CssSelector("[name=gridRadiosSex]")).Count();
            var rInt = r.Next(0, count);
            driver.FindElements(By.CssSelector("[name=gridRadiosSex]"))[rInt].Click();

            //age
            driver.FindElement(By.CssSelector("#inputAge3")).SendKeys("18");

            //experience
            count = driver.FindElements(By.CssSelector("[name=gridRadiosExperience]")).Count();
            rInt = r.Next(0, count);
            driver.FindElements(By.CssSelector("[name=gridRadiosExperience]"))[rInt].Click();

            //profession
            driver.FindElement(By.CssSelector("[for=gridCheckAutomationTester]")).Click();

            //continents
            count = driver.FindElements(By.CssSelector("#selectContinents *")).Count();
            rInt = r.Next(1, count);
            driver.FindElements(By.CssSelector("option"))[rInt].Click();

            //selenium_command
            SelectElement select = new SelectElement(driver.FindElement(By.Id("selectSeleniumCommands")));
            select.SelectByValue("switch-commands");
            select.SelectByValue("wait-commands");

            //file
            IWebElement fileInput = driver.FindElement(By.CssSelector("input[type=file]"));
            //string baseDirectory = AppContext.BaseDirectory;
            string relativePath = Path.Combine("Fixtures", "file.jpg");
            string uploadFile = Path.GetFullPath(relativePath);
            //string uploadFile = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
            fileInput.SendKeys(uploadFile);

            //submit
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Assert.NotNull(driver.FindElement(By.CssSelector("button[type='submit']")));

            //check "Form send with success"
            Assert.NotNull(driver.FindElement(By.Id("validator-message")));
            var acutalMsg = driver.FindElement(By.Id("validator-message")).Text;
            var expectedMsg = "Form send with success";
            Assert.Equal(acutalMsg, expectedMsg);
        }

        private void SetFirstName(string text)
        {
            driver.FindElement(By.CssSelector("#inputFirstName3")).SendKeys(text);
        }
        private void SetLastName(string text)
        {
            driver.FindElement(By.CssSelector("#inputLastName3")).SendKeys(text);
        }
        private void SetEmail(string text)
        {
            driver.FindElement(By.CssSelector("#inputEmail3")).SendKeys(text);
        }
    }
}