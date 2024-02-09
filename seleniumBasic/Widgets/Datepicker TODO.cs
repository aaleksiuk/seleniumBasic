using SeleniumBasic;
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
        public void Datepicker_pick()
        {
            //            Tutaj zadanie bardziej na rozmienienie jak całość napisać optymalnie.Nie róbcie wszystkiego w 1
            //wielkiej metodzie testowej tylko porozbijajcie sobie kod na jak najwięcej metod prywatnych, aby kod
            //czytało się ładnie i był reużywalny.
            //To jest dość uciążliwy datepicker, bo trzeba ręcznie przechodzić do konkretnego miesiąca i roku.
            //Trzeba też wpaść na pomysł jak porównać jaki miesiąc jest większy(porównując to po teście)
            //Wszystkie kroki powinny być wykonane w 1 teście.
            //Sam test może wglądać tak:
            //            selectDate(xxxx)
            //assercja sprawdzająca czy dobra data została wybrana
            //selectDate(yyyy)
            //assercja sprawdzająca czy dobra data została wybrana
            //selectDate(zzzzzz)
            //assercja sprawdzająca czy dobra data została wybrana
            //A metoda selectDate powinna być napisana tak, że przeniesie nas do dowolnej daty, niezależnie od
            //tego jaka data jest wybrana.
            //Poszczególne kroki są tak dopasowane, żeby sprawdzić czy na pewno wasz ‘algorytm’ przechodzenia
            //po datepickerze zadziała zawsze->niezależnie od tego czy wybieramy datę z aktualnego miesiąca,
            //kolejnego/ poprzedniego miesiąca / roku.
            //Dodatkowo trzeba uważać, bo lista dni miesiąca zawiera dni z danego miesiąca, ale też miesiąca
            //kolejnego i poprzedniego. Dzięki temu na liście dni może być dwukrotnie dzień z numerem ‘1’. 
            //Uważajcie na to wykonując test, aby przypadkiem nie wybrać złego numerka dnia z listy.
            //Test steps:
            //Select the dates below. After each selection assert if the correct date is shown in 'Date' input
            //• Today
            //• 1st day from next month
            //• Last day from January in next year
            //• Select same day again(same was selected in step 3)
            //• Random day from previous month
            //• Random date from last year}
        }
    }
}
