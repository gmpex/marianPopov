using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lesson_01_Homework
{
    public class MainClass
    {
        public static void Main(String[] args)
        {
            Homework homework = new Homework();
            TableFormatting table = new TableFormatting();

            table.TopSide();
            homework.CheckIfNumberIsEvenOrOdd(-11);
            homework.CheckIfNumberIsEvenOrOdd(11);
            homework.CheckIfNumberIsEvenOrOdd(8);
            table.BottomSide();
            //---------------------------------------
            table.TopSide();
            homework.NumberDivideToFour(10);
            homework.NumberDivideToFour(16);
            table.BottomSide();
            //---------------------------------------
            table.TopSide();
            homework.DayOfWeek("Monday");
            homework.DayOfWeek("Sunday");
            homework.DayOfWeek("some day");
            table.BottomSide();
            //---------------------------------------
            table.TopSide();
            homework.CheckLetterIfVowel(Char.ToLower('p'));
            homework.CheckLetterIfVowel(Char.ToLower('i'));
            homework.CheckLetterIfVowel(Char.ToLower('5'));
            table.BottomSide();
        }
    }
}
