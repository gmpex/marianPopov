using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lesson_03_Homework
{
    public class Exercises
    {
        public static void Main(string[] args)
        {
            // Generic colections
            Console.WriteLine("============= Generic 1 =============");
            ICollection<int> list = new List<int>();
            list.Add(633);
            list.Add(52);
            list.Add(83);
            list.Add(-5);

            //print all elements from list
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            //print some text if value 52 is exist in list
            if (list.Contains(52))
            {
                Console.WriteLine("In this array have value 52");
            }

            //remove all elements from list
            list.Clear();

            //check if count of elements is 0
            if (list.Count == 0)
            {
                Console.WriteLine("Element count is 0");
            }

            /* ----------------------------------------------------------- */
            Console.WriteLine("============= Generic 2 =============");
            List<int> numbers = new List<int>();
            numbers.Add(4);
            numbers.Add(22);
            numbers.Add(-22);
            numbers.Add(11);

            var orderedNumbers1 = numbers.OrderByDescending(p => p);
            var orderedNumbers2 = numbers.OrderBy(p => p);

            foreach (int i in orderedNumbers1)
                Console.WriteLine("OrderByDescending " + i);

            Console.WriteLine("");
            foreach (int i in orderedNumbers2)
                Console.WriteLine("OrderByAscending " + i);

            numbers.RemoveAt(0);
            numbers.Remove(11);

            foreach (int i in numbers)
                Console.WriteLine("After Remove " + i);

        }
    }
}
