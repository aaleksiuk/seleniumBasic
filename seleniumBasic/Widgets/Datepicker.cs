using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Widgets
{
    public class Datepicker : TestBase
    {
        public Datepicker(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Datepicker_selectDate()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/datepicker.php");

            var today = DateTime.Today;
            var nextMonthFirstDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1);
            var lastDayOfNextYearJanuary = new DateTime(DateTime.Today.Year + 1, 1, DateTime.DaysInMonth(DateTime.Today.Year + 1, 1));

            var sameDayPreviousMonth = DateTime.Today.AddMonths(-1);
            var random = new Random();
            var randomDay = random.Next(1, DateTime.DaysInMonth(sameDayPreviousMonth.Year, sameDayPreviousMonth.Month));
            var randomDayFromPreviousMonth = new DateTime(sameDayPreviousMonth.Year, sameDayPreviousMonth.Month, randomDay);

            var randomMonth = random.Next(1, 12);
            var randomDateFromLastYear = new DateTime(DateTime.Today.Year - 1, randomMonth, randomDay);

            SelectDate(driver, today, "today");
            SelectDate(driver, nextMonthFirstDay, "nextMonthFirstDay");
            SelectDate(driver, lastDayOfNextYearJanuary, "lastDayOfNextYearJanuary");
            SelectDate(driver, lastDayOfNextYearJanuary, "lastDayOfNextYearJanuary2");
            SelectDate(driver, randomDayFromPreviousMonth, "randomDayFromPreviousMonth");
            SelectDate(driver, randomDateFromLastYear, "randomDateFromLastYear");
        }

        private void SelectDate(IWebDriver driver, DateTime dateToBeSelected, string dateDescription)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            OpenDatePicker(driver, wait);

            var targetDay = dateToBeSelected.Day;
            var targetMonth = dateToBeSelected.Month;
            var targetYear = dateToBeSelected.Year;
            var currentlySetYear = GetCurrentlySetYear(driver, wait);
            var currentlySetmonthNumber = GetCurrentlySetMonthNumberByItsName(driver, wait);
            var monthDifference = CalculateDifferenceInMonths(targetMonth, targetYear, currentlySetYear, currentlySetmonthNumber);

            NavigateToSetTargetMonthAndYear(driver, monthDifference);

            SelectTargetDay(driver, targetDay, targetMonth);
            VerifyThatDatepickerInputIsSetAsExpected(driver, dateToBeSelected, dateDescription, wait);
        }

        private static void VerifyThatDatepickerInputIsSetAsExpected(IWebDriver driver, DateTime dateToBeSelected, string dateDescription, WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("datepicker")));
            var actualSelectedDate = driver.FindElement(By.Id("datepicker")).GetAttribute("value");
            var expectedDate = dateToBeSelected.ToString("MM/dd/yyyy");

            Assert.True(actualSelectedDate == expectedDate, $"{dateDescription} - Expected: {expectedDate}, Actual: {actualSelectedDate}");
        }

        private static void SelectTargetDay(IWebDriver driver, int targetDay, int targetMonth)
        {
            var selectDay = driver.FindElement(By.XPath($"//td[@data-month='{targetMonth - 1}']/a[text()='{targetDay}']"));
            selectDay.Click();
        }

        private static void NavigateToSetTargetMonthAndYear(IWebDriver driver, int monthDifference)
        {
            var buttonSwitchClassName = monthDifference > 0 ? "ui-datepicker-next" : "ui-datepicker-prev";

            for (var i = 0; i < Math.Abs(monthDifference); i++)
            {
                driver.FindElement(By.ClassName(buttonSwitchClassName)).Click();
            }
        }

        private static int CalculateDifferenceInMonths(int targetMonth, int targetYear, string currentlySetYear, int currentlySetmonthNumber)
        {
            var yearDifference = targetYear - int.Parse(currentlySetYear);
            var monthDifference = targetMonth - currentlySetmonthNumber;

            monthDifference = monthDifference + 12 * yearDifference;
            return monthDifference;
        }

        private static int GetCurrentlySetMonthNumberByItsName(IWebDriver driver, WebDriverWait wait)
        {
            wait.Until(d => !string.IsNullOrEmpty(d.FindElement(By.XPath("//span[@class='ui-datepicker-month']")).Text));
            var currentlySetMonth = driver.FindElement(By.XPath("//span[@class='ui-datepicker-month']")).Text;
            var currentlySetmonthNumber = Array.IndexOf(CultureInfo.GetCultureInfo("en-US").DateTimeFormat.MonthNames, currentlySetMonth) + 1;
            return currentlySetmonthNumber;
        }

        private static string GetCurrentlySetYear(IWebDriver driver, WebDriverWait wait)
        {
            wait.Until(d => !string.IsNullOrEmpty(d.FindElement(By.XPath("//span[@class='ui-datepicker-year']")).Text));
            var currentlySetYear = driver.FindElement(By.XPath("//span[@class='ui-datepicker-year']")).Text;
            return currentlySetYear;
        }

        private static void OpenDatePicker(IWebDriver driver, WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("datepicker")));
            var datePicker = driver.FindElement(By.Id("datepicker"));
            datePicker.Click();
        }
    }
}