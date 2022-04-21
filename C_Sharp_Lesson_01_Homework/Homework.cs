
namespace C_Sharp_Lesson_01_Homework
{
    public class Homework
    {
        ResultClass txt = new ResultClass();
        TableFormatting table = new TableFormatting();

        public void CheckIfNumberIsEvenOrOdd(int number)
        {
       /* Exercise 1
        * using "if" write a programm that checks whether an integer is greater then zero and even or odd
        * Example:
        * -------------------------------------------------
        * |input   | result                               |
        * |--------|--------------------------------------|
        * |  1     | odd                                  |
        * |--------|--------------------------------------|
        * |  2     | even                                 |
        * |--------|--------------------------------------|
        * | -1     | the value should be greater then zero|
        * -------------------------------------------------
        */
            if (number < 0)
            {
                Console.WriteLine(table.IntFormatForTable(number, txt.ResultExercise1_1()));
            }
            else if (number % 2 != 0)
            {
                Console.WriteLine(table.IntFormatForTable(number, txt.ResultExercise1_2()));
            }
            else
            {
                Console.WriteLine(table.IntFormatForTable(number, txt.ResultExercise1_3()));
            }
        }
        public void NumberDivideToFour(int number)
        {
       /* Exercise 2
        * using a ternary operator write a program that print if number divide to 4
        * Example: 
        * --------------------------------------------
        * |input   | result                          |
        * |--------|---------------------------------|
        * |  -4    | The number divide to 4          |
        * |--------|---------------------------------|
        * |   2    | The number doesn't divide to 4  |
        * --------------------------------------------
        */
            Console.WriteLine((number % 4 == 0) ? table.IntFormatForTable(number, txt.ResultExercise2_1()) : table.IntFormatForTable(number, txt.ResultExercise2_2()));
        }
        public void DayOfWeek(string day)
        {
       /* Exercise 3
        * using "switch" statement write a program that print the number of day of week
        * Example: monday - 1, tuesday - 2 etc. 
        * ---------------------------------------------------------
        * |day           |number                                  |
        * |--------------|----------------------------------------|
        * |monday        |   1                                    |
        * |tuesday       |   2                                    |
        * |wednesday     |   3                                    |
        * |thursday      |   4                                    |
        * |friday        |   5                                    |
        * |saturday      |   6                                    |
        * |sunday        |   7                                    |
        * |default value |Wrong value! Please give a day of a week|
        * ---------------------------------------------------------
        */
            switch (day.ToLower())
            {
                case "monday":
                    Console.WriteLine(table.StringFormatForTable(day, txt.ResultExercise3_monday()));
                    break;
                case "tuesday":
                    Console.WriteLine(table.StringFormatForTable(day, txt.ResultExercise3_tuesday()));
                    break;
                case "wednesday":
                    Console.WriteLine(table.StringFormatForTable(day, txt.ResultExercise3_wednesday()));
                    break;
                case "thursday":
                    Console.WriteLine(table.StringFormatForTable(day, txt.ResultExercise3_thursday()));
                    break;
                case "friday":
                    Console.WriteLine(table.StringFormatForTable(day, txt.ResultExercise3_friday()));
                    break;
                case "saturday":
                    Console.WriteLine(table.StringFormatForTable(day, txt.ResultExercise3_saturday()));
                    break;
                case "sunday":
                    Console.WriteLine(table.StringFormatForTable(day, txt.ResultExercise3_sunday()));
                    break;
                default:
                    Console.WriteLine(table.StringFormatForTable(day, txt.ResultExercise3_wrong()));
                    break;
            }
        }
        public void CheckLetterIfVowel(char character)
        {
       /* Exercise 4
        * write a program that will print input character is a vowel, consonant or not a letter
        * Method 1: using a switch case
        * Method 2: using if
        * ---------------------------
        * |input| result            |
        * |-----|-------------------|
        * |  a  | a is a vowel      |
        * |  b  | b is a consonant  |
        * ---------------------------
        */
            // Method 1: using a switch case
            if (character >= 'a' && character <= 'z')
            {
                switch (character)
                {
                    case ('a'):
                        Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_vowel() + txt.Exercise4_switch()));
                        break;
                    case ('e'):
                        Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_vowel() + txt.Exercise4_switch()));
                        break;
                    case ('i'):
                        Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_vowel() + txt.Exercise4_switch()));
                        break;
                    case ('o'):
                        Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_vowel() + txt.Exercise4_switch()));
                        break;
                    case ('u'):
                        Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_vowel() + txt.Exercise4_switch()));
                        break;
                    case ('y'):
                        Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_vowel() + txt.Exercise4_switch()));
                        break;
                    default:
                        Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_consonant() + txt.Exercise4_switch()));
                        break;
                }
            }
            else
            {
                Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_noLetter() + txt.Exercise4_switch()));
            }
            // Method 2: using if
            if (character == 'a' ||
                character == 'e' ||
                character == 'i' ||
                character == 'o' ||
                character == 'u' ||
                character == 'y')
            {
                Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_vowel() + txt.Exercise4_if()));
            }
            else if (!Char.IsLetter(character))
            {
                Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_noLetter() + txt.Exercise4_if()));
            }
            else
            {
                Console.WriteLine(table.CharFormatForTable(character, txt.ResultExercise4_consonant() + txt.Exercise4_if()));
            }
        }
    }
}
