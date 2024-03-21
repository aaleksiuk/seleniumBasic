using SeleniumBasic;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.POP
{
    public class FormTest : TestBase
    {
        private readonly FormPage _formPage;

        public FormTest(ITestOutputHelper output) : base(output)
        {
            _formPage = new FormPage(driver);
        }

        [Fact] //check "Form send with success"
        public void Successfully()
        {
            var fillForm = new FormTestPop(_formPage);

            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/form.php");

            fillForm.SetFirstName("Jan");
            fillForm.SetLastName("Kowalski");
            fillForm.SetEmail("mail@mail.com");
            fillForm.SetSex();
            fillForm.SetAge("18");
            fillForm.SetRandomExperience();
            fillForm.SelectRandomProfession();
            fillForm.SelectContinent("Antarctica");
            fillForm.SetSeleniumCommand("switch-commands", "webelement-commands");
            fillForm.SetSelectFile();
            fillForm.SetSubmit();
            var expectedMsg = "Form send with success";
            Assert.Equal(fillForm.GetValidationMsg(), expectedMsg);
        }
    }
}
