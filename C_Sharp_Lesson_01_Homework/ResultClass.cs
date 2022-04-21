using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lesson_01_Homework
{
    public class ResultClass
    {
        public string ResultExercise1_1()
        {
            return "The value should be greater then zero";
        }

        public string ResultExercise1_2()
        {
            return "Odd";
        }
        public string ResultExercise1_3()
        {
            return "Even";
        }

        public string ResultExercise2_1()
        {
            return "The number divide to 4";
        }

        public string ResultExercise2_2()
        {
            return "The number doesn't divide to 4";
        }

        public string TXTNumbDays()
        {
            return "The number of day of week is: ";
        }
        public string ResultExercise3_wrong()
        {
            return "Wrong value! Please give a day of a week";
        }
            public string ResultExercise3_monday()
        {
            return TXTNumbDays() + "1";
        }
        public string ResultExercise3_tuesday()
        {
            return TXTNumbDays() + "2";
        }

        public string ResultExercise3_wednesday()
        {
            return TXTNumbDays() + "3";
        }

        public string ResultExercise3_thursday()
        {
            return TXTNumbDays() + "4";
        }

        public string ResultExercise3_friday()
        {
            return TXTNumbDays() + "5";
        }

        public string ResultExercise3_saturday()
        {
            return TXTNumbDays() + "6";
        }

        public string ResultExercise3_sunday()
        {
            return TXTNumbDays() + "7";
        }
        public string Exercise4_if()
        {
            return " (IF)";
        }

        public string Exercise4_switch()
        {
            return " (SWITCH)";
        }

        public string ResultExercise4_vowel()
        {
            return " is a vowel";
        }

        public string ResultExercise4_consonant()
        {
            return " is a consonant";
        }

        public string ResultExercise4_noLetter()
        {
            return " not a letter";
        }
    }
}
