using FluentAssertions;
using OpenQA.Selenium;
using SeleniumBasic;
using System;
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

            MoveSliderTo(50);
            MoveSliderTo(80);
            MoveSliderTo(80);
            MoveSliderTo(20);
            MoveSliderTo(0);
        }

        private int CurrentPosition()
        {
            return int.Parse(driver.FindElement(By.CssSelector("#custom-handle")).Text);
        }

        private void MoveSliderTo(int desiredPosition)
        {
            var currentPosition = CurrentPosition();
            var counter = Math.Abs(desiredPosition - currentPosition);
            var slider = driver.FindElement(By.CssSelector("#custom-handle"));
            var keyToPress = (desiredPosition > currentPosition) ? Keys.ArrowRight : Keys.ArrowLeft;

            for (var i = 0; i < counter; i++)
            {
                slider.SendKeys(keyToPress);
            }
            CurrentPosition().Should().Be(desiredPosition);
        }
    }
}