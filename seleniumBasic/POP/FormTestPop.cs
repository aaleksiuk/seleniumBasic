using SeleniumBasic;
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

            formPage.SetFirstName("Jan")
                    .SetLastName("Kowalski")
                    .SetEmail("mail@mail.com")
                    .SetSex()
                    .SetAge("18")
                    .SetRandomExperience()
                    .SelectRandomProfession()
                    .SelectContinent("Antarctica")
                    .SetSeleniumCommand("switch-commands", "webelement-commands")
                    .SetSelectFile()
                    .SetSubmit();
            var expectedMsg = "Form send with success";
            Assert.Equal(formPage.GetValidationMsg(), expectedMsg);
        }
    }
}
