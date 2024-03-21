using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;

namespace seleniumBasic.POP
{
    public class FormTestPop
    {
        protected readonly FormPage formPage;
        private readonly Random _random;

        public FormTestPop(FormPage _formPage)
        {
            formPage = _formPage;
            _random = new Random();
        }

        public void SetFirstName(string firstName)
        {
            formPage.FirstName.SendKeys(firstName);
        }
        public void SetLastName(string lastName)
        {
            formPage.LastName.SendKeys(lastName);
        }
        public void SetEmail(string email)
        {
            formPage.Email.SendKeys(email);
        }
        public void SetSex()
        {
            var count = formPage.Sex.Count();
            var randomIndex = _random.Next(0, count);
            formPage.Sex[randomIndex].Click();
        }
        public void SetAge(string age)
        {
            formPage.Age.SendKeys(age);
        }
        public void SetRandomExperience()
        {
            var count = formPage.Experience.Count();
            var randomIndex = _random.Next(0, count);
            formPage.Experience[randomIndex].Click();
        }
        public void SelectRandomProfession()
        {
            var count = formPage.Professions.Count();

            var randomIndex = _random.Next(0, count);
            formPage.Professions[randomIndex].Click();
        }
        public void SelectContinent(string continent)
        {
            var continentElement = formPage.Continents.FirstOrDefault(element => element.Text == continent);
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
            var select = new SelectElement(formPage.Selenium_command);
            foreach (var command in commands)
            {
                select.SelectByValue(command);
            }
        }
        public void SetSelectFile()
        {
            var relativePath = Path.Combine("Fixtures", "file.jpg");
            var uploadFile = Path.GetFullPath(relativePath);
            formPage.File.SendKeys(uploadFile);
        }
        public void SetSubmit()
        {
            formPage.Submit.Click();
        }
        public string GetValidationMsg()
        {
            return formPage.SuccessMessage.Text;
        }
    }
}
