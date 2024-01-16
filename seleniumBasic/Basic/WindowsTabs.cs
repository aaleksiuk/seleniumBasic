using OpenQA.Selenium;
using SeleniumBasic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Basic
{
    public class WindowsTabs : TestBase
    {
        public WindowsTabs(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WindowsTables()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/windows-tabs.php");
            var originalWindow = driver.CurrentWindowHandle;
            //BrowserWindow
            driver.FindElement(By.CssSelector("#newBrowserWindow")).Click();
            foreach (var window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            TableExercise();

            driver.Close();
            driver.SwitchTo().Window(originalWindow);

            //MessageWindow
            driver.FindElement(By.CssSelector("#newMessageWindow")).Click();
            foreach (var window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    var actualMsg = driver.FindElement(By.CssSelector("body")).Text;
                    break;
                }
            }
            var expectedMsg = "Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.";
            
            driver.Close();
            driver.SwitchTo().Window(originalWindow);

            //BrowserTab
            driver.FindElement(By.CssSelector("#newBrowserTab")).Click();
            foreach (var window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            TableExercise();
            driver.Close();
            driver.SwitchTo().Window(originalWindow);

            Thread.Sleep(1000);

        }

        private void TableExercise()
        {
            var definedCountry = "Switzerland";
            var definedHeight = 4000;

            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            foreach (var row in rows)
            {
                var rank = int.Parse(row.FindElement(By.CssSelector("th")).Text);
                var peak = row.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                var state = row.FindElement(By.CssSelector("td:nth-child(4)")).Text;
                var height = int.Parse(row.FindElement(By.CssSelector("td:nth-child(5)")).Text);

                if (state.Contains(definedCountry) && (height > definedHeight))
                {
                    output.WriteLine(rank + " " + peak + " " + height);
                }
            }
        }
    }

}
