using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using seleniumBasic.Extensions;

namespace seleniumBasic.POP.Form
{
    public class LepszyFormPage(IWebDriver driver)
    {
        private IWebElement FirstName => driver.WaitAndFind(By.Id("inputFirstName3"));
        private IWebElement LastName => driver.WaitAndFind(By.Id("inputLastName3"));
        private IWebElement Email => driver.WaitAndFind(By.Id("inputEmail3"));
        private IList<IWebElement> Sex => driver.WaitAndFindAll(By.CssSelector("[name='gridRadiosSex']"));
        private IWebElement Age => driver.WaitAndFind(By.Id("inputAge3"));
        private IList<IWebElement> Experience => driver.WaitAndFindAll(By.CssSelector("[name='gridRadiosExperience']"));
        private IList<IWebElement> Professions => driver.WaitAndFindAll(By.CssSelector("[name='gridCheckboxProfession']"));
        private IList<IWebElement> Continents => driver.WaitAndFindAll(By.CssSelector("#selectContinents *"));
        private IWebElement Selenium_command => driver.WaitAndFind(By.Id("selectSeleniumCommands"));
        private IWebElement File => driver.WaitAndFind(By.CssSelector("input[type=file]"));
        private IWebElement Submit => driver.WaitAndFind(By.CssSelector("button[type='submit']"));
        private IWebElement SuccessMessage => driver.WaitAndFind(By.Id("validator-message"));

        public LepszyFormPage SetFirstName(string firstName)
        {
            FirstName.SendKeys(firstName);
            return this;
        }
        public LepszyFormPage SetLastName(string lastName)
        {
            LastName.SendKeys(lastName);
            return this;
        }
        public LepszyFormPage SetEmail(string email)
        {
            Email.SendKeys(email);
            return this;
        }
        public LepszyFormPage SetSex()
        {
            RandomlySelectElementFromList(Sex);
            return this;
        }
        public LepszyFormPage SetAge(string age)
        {
            Age.SendKeys(age);
            return this;
        }
        public LepszyFormPage SetRandomExperience()
        {
            RandomlySelectElementFromList(Experience);
            return this;
        }
        public LepszyFormPage SelectRandomProfession()
        {
            RandomlySelectElementFromList(Professions);
            return this;
        }
        public LepszyFormPage SelectContinent(string continent)
        {
            var continentElement = Continents.FirstOrDefault(element => element.Text == continent);
            continentElement?.Click();
            return this;
        }
        public LepszyFormPage SetSeleniumCommand(params string[] commands)
        {
            var select = new SelectElement(Selenium_command);
            foreach (var command in commands)
            {
                select.SelectByValue(command);
            }
            return this;
        }
        public LepszyFormPage SetSelectFile()
        {
            var relativePath = Path.Combine("Fixtures", "file.jpg");
            var uploadFile = Path.GetFullPath(relativePath);
            File.SendKeys(uploadFile);
            return this;
        }
        public LepszyFormPage SetSubmit()
        {
            Submit.Click();
            return this;
        }
        public string GetValidationMsg() => SuccessMessage.Text;

        private void RandomlySelectElementFromList(IList<IWebElement> elements)
        {
            var count = elements.Count();
            var randomIndex = new Random().Next(0, count);
            elements[randomIndex].Click();
        }
    }
}