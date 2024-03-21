using SeleniumBasic;
using SeleniumBasic.Basic;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.POP
{
    public class FormTestPop : TestBase
    {
        private FormPage formPage;

        public FormTestPop(ITestOutputHelper output) : base(output)
        {
            
        }


        [Fact] //check "Form send with success"
        public void Successfully()
        {
            var formPage = new FormPage(driver);

            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/form.php");


            formPage.SetFirstName("Jan");
            formPage.SetLastName("Kowalski");
            formPage.SetEmail("mail@mail.com");
            formPage.SetSex();
            formPage.SetAge("18");
            formPage.SetRandomExperience();
            formPage.SelectRandomProfession();
            formPage.SelectContinent("Antarctica");
            formPage.SetSeleniumCommand("switch-commands", "webelement-commands");
            formPage.SetSelectFile();
            formPage.SetSubmit();
            var expectedMsg = "Form send with success";
            Assert.Equal(formPage.GetValidationMsg(), expectedMsg);
        }
    }
}
