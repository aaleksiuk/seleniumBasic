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
        public IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "inputLastName3")]
        public IWebElement LastName;

        [FindsBy(How = How.Id, Using = "inputEmail3")]
        public IWebElement Email;

        [FindsBy(How = How.CssSelector, Using = "[name='gridRadiosSex']")]
        public IList<IWebElement> Sex;

        [FindsBy(How = How.Id, Using = "inputAge3")]
        public IWebElement Age;

        [FindsBy(How = How.CssSelector, Using = "[name='gridRadiosExperience']")]
        public IList<IWebElement> Experience;

        [FindsBy(How = How.CssSelector, Using = "[name='gridCheckboxProfession']")]
        public IList<IWebElement> Professions;

        [FindsBy(How = How.CssSelector, Using = "#selectContinents *")]
        public IList<IWebElement> Continents;

        [FindsBy(How = How.Id, Using = "selectSeleniumCommands")]
        public IWebElement Selenium_command;

        [FindsBy(How = How.CssSelector, Using = "input[type=file]")]
        public IWebElement File;

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement Submit;

        [FindsBy(How = How.Id, Using = "validator-message")]
        public IWebElement SuccessMessage;



        public void SetFirstName(string firstName)
        {
            FirstName.SendKeys(firstName);
        }
        public void SetLastName(string lastName)
        {
            LastName.SendKeys(lastName);
        }
        public void SetEmail(string email)
        {
            Email.SendKeys(email);
        }
        public void SetSex()
        {
            var count = Sex.Count();
            var r = new Random();
            var randomIndex = r.Next(0, count);
            Sex[randomIndex].Click();
        }
        public void SetAge(string age)
        {
            Age.SendKeys(age);
        }
        public void SetRandomExperience()
        {
            var count = Experience.Count();
            var r = new Random();
            var randomIndex = r.Next(0, count);
            Experience[randomIndex].Click();
        }
        public void SelectRandomProfession()
        {
            var count = Professions.Count();
            var r = new Random();
            var randomIndex = r.Next(0, count);
            Professions[randomIndex].Click();
        }
        public void SelectContinent(string continent)
        {
            var continentElement = Continents.FirstOrDefault(element => element.Text == continent);
            continentElement?.Click();
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
        public void SetSeleniumCommand(params string[] commands)
        {
            var select = new SelectElement(Selenium_command);
            foreach (var command in commands)
            {
                select.SelectByValue(command);
            }
        }
        public void SetSelectFile()
        {
            var relativePath = Path.Combine("Fixtures", "file.jpg");
            var uploadFile = Path.GetFullPath(relativePath);
            File.SendKeys(uploadFile);
        }
        public void SetSubmit()
        {
            Submit.Click();
        }
        public string GetValidationMsg()
        {
            return SuccessMessage.Text;
        }
    }
}