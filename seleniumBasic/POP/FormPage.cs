using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

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
    }
}