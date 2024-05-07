using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace seleniumBasic.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement WaitAndFind(this IWebDriver driver, By by)
        {
            // poczekaj aż ten element będzie visible Z LAMBDĄ
            return driver.FindElement(by);
        }
        public static List<IWebElement> WaitAndFindAll(this IWebDriver driver, By by)
        {
            // poczekaj aż count > 0 z LAMDBĄ
            return driver.FindElements(by).ToList();
        }
    }
}
