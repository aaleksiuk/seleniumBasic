using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace seleniumBasic.POP
{

    public class FormPage
    {
        
        public FormPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "inputFirstName3")]
        private IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "inputLastName3")]
        private IWebElement LastName;

        [FindsBy(How = How.Id, Using = "inputEmail3")]
        private IWebElement Email;

        [FindsBy(How = How.CssSelector, Using = "[name='gridRadiosSex']")]
        private IList<IWebElement> Sex;

        [FindsBy(How = How.Id, Using = "inputAge3")]
        private IWebElement Age;

        [FindsBy(How = How.CssSelector, Using = "[name='gridRadiosExperience']")]
        private IList<IWebElement> Experience;

        [FindsBy(How = How.CssSelector, Using = "[name='gridCheckboxProfession']")]
        private IList<IWebElement> Professions;

        [FindsBy(How = How.CssSelector, Using = "#selectContinents *")]
        private IList<IWebElement> Continents;

        [FindsBy(How = How.Id, Using = "selectSeleniumCommands")]
        private IWebElement Selenium_command;

        [FindsBy(How = How.CssSelector, Using = "input[type=file]")]
        private IWebElement File;

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement Submit;

        [FindsBy(How = How.Id, Using = "validator-message")]
        private IWebElement SuccessMessage;

        public FormPage SetFirstName(string firstName)
        {
            FirstName.SendKeys(firstName);
            return this;
        }
        public FormPage SetLastName(string lastName)
        {
            LastName.SendKeys(lastName);
            return this;
        }
        public FormPage SetEmail(string email)
        {
            Email.SendKeys(email);
            return this;
        }
        public FormPage SetSex()
        {
            var count = Sex.Count();
            var r = new Random();
            var randomIndex = r.Next(0, count);
            Sex[randomIndex].Click();
            return this;
        }
        public FormPage SetAge(string age)
        {
            Age.SendKeys(age);
            return this;
        }
        public FormPage SetRandomExperience()
        {
            var count = Experience.Count();
            var r = new Random();
            var randomIndex = r.Next(0, count);
            Experience[randomIndex].Click();
            return this;
        }
        public FormPage SelectRandomProfession()
        {
            var count = Professions.Count();
            var r = new Random();
            var randomIndex = r.Next(0, count);
            Professions[randomIndex].Click();
            return this;
        }
        public FormPage SelectContinent(string continent)
        {
            var continentElement = Continents.FirstOrDefault(element => element.Text == continent);
            continentElement?.Click();
            return this;
            //var allText = new string[_continents.Count];

            //for (int i = 0; i < _continents.Count; i++)
            //{
            //    var currentElement = _continents[i];
            //    allText[i] = currentElement.Text;
            //    if (string.Equals(allText[i], continent)
            //    {
            //        currentElement.Click();
            //        break;
            //    }
            //}
        }
        public FormPage SetSeleniumCommand(params string[] commands)
        {
            var select = new SelectElement(Selenium_command);
            foreach (var command in commands)
            {
                select.SelectByValue(command);
            }
            return this;
        }
        public FormPage SetSelectFile()
        {
            var relativePath = Path.Combine("Fixtures", "file.jpg");
            var uploadFile = Path.GetFullPath(relativePath);
            File.SendKeys(uploadFile);
            return this;
        }
        public FormPage SetSubmit()
        {
            Submit.Click();
            return this;
        }
        public string GetValidationMsg()
        {
            return SuccessMessage.Text;
        }
    }
}