using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lesson_01_Homework
{
    internal class TableFormatting
    {
        int exNumber = 1;
        public void TopSide()
        {
            Console.WriteLine("|=======================[Exercise {0}]=======================|", exNumber++);
            Console.WriteLine("|{0,10}    | {1,-41} |", "INPUT", "RESULT");
            Console.WriteLine("|{0,10}|{1,-41}|", "--------------", "-------------------------------------------");
        }

        public void BottomSide()
        {
            Console.WriteLine("|----------------------------------------------------------|");
            Console.WriteLine("");
        }

        public string StringFormatForTable(string a, string b)
        {
            return String.Format("|{0,10}    | {1,-41} |", a, b);
        }

        public string IntFormatForTable(int a, string b)
        {
            return String.Format("|{0,10}    | {1,-41} |", a, b);
        }

        public string CharFormatForTable(char a, string b)
        {
            return String.Format("|{0,10}    | {1,-41} |", a, b);
        }
    }
}
