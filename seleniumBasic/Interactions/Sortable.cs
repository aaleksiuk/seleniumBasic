using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumBasic;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Interactions
{
    public class Sortable : TestBase
    {
        public Sortable(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void SortByMathchShuffledTable()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/sortable.php");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='sortable']")));
            IList<IWebElement> originalList = driver.FindElements(By.XPath("//*[@id='sortable']/li"));

            var shuffledList = Shuffle(originalList.ToList());

            for (var i = 0; i < shuffledList.Count; i++)
            {
                var from = shuffledList[i];
                var to = originalList[i];

                new Actions(driver)
                    .DragAndDrop(from, to)
                    .Perform();
            }
        }

        private IList<IWebElement> Shuffle<T>(List<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list.Cast<IWebElement>().ToList();
        }
    }
}