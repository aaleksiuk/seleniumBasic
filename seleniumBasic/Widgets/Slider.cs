using FluentAssertions;
using OpenQA.Selenium;
using SeleniumBasic;
using Xunit;
using Xunit.Abstractions;

namespace seleniumBasic.Widgets
{
    public class Slider : TestBase
    {
        public Slider(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public void MoveSlider()
        {
            driver.Navigate().GoToUrl("http://www.seleniumui.moderntester.pl/slider.php");

            moveSlider(50);
            currentPosition().Should().Be(50);
            moveSlider(80);
            currentPosition().Should().Be(80);
            moveSlider(80);
            currentPosition().Should().Be(80);
            moveSlider(20);
            currentPosition().Should().Be(20);
            moveSlider(0);
            currentPosition().Should().Be(0);
        }

        private int currentPosition()
        {
            return int.Parse(driver.FindElement(By.CssSelector("#custom-handle")).Text);
        }

        private int moveSlider(int times)
        {
            int acutalValue = currentPosition();
            IWebElement Slider = driver.FindElement(By.CssSelector("#custom-handle"));

            for (int i = 0; i <= times; i++)
            {
                if (times > acutalValue)
                {
                    do
                    {
                        Slider.SendKeys(Keys.ArrowRight);
                        acutalValue++;
                    }
                    while (times > acutalValue);
                }
                else if (times < acutalValue)
                {
                    do
                    {
                        Slider.SendKeys(Keys.ArrowLeft);
                        times++;
                    }
                    while (times < acutalValue);
                }
                else
                {
                    break;
                }
            }
            return acutalValue;
        }
    }
}