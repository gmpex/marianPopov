using System.Collections.Generic;

namespace C_Sharp_Lesson_03_Homework
{
    public class Homework
    {
        public void GetCentralElementFromMatrix(int[,] matrixOfIntegers)
        {
            /*print to console the central element from matrixOfIntegers, if not exist print: "This matrix doesn't have a central element"
             * |   input           | result             |
             * |-------------------|--------------------|
             * | {                 |                    |
             * |  { 1,   3,  5},   |    The central     |
             * |  {-1, 100, 11},   |  element is 100    |
             * |  { 2,  15, 44}    |                    |
             * |  }                |                    |
             * |----------------------------------------|
             * |{                  |                    |
             * | { 1,  6, 21,  8 },| This matrix doesn't|
             * | { 5, -4,  5,  7 },| have a central     |
             * | {77,  5,  0, 74 } |  element           |
             * | }                 |                    |
             * ------------------------------------------
             *    
             */
            var middleRow = matrixOfIntegers.GetLength(0) / 2; // 3/2 = 1.5 (1)
            var middleCol = matrixOfIntegers.GetLength(1) / 2; // 3/2 = 1.5 (1) 

            //daca restul impartirii lungimei elementelor din rand nu va fi 0 SI daca restul impartirii lungimei elementelor din coloana nu va fi 0
            if (matrixOfIntegers.GetLength(0)%2 != 0 && matrixOfIntegers.GetLength(1) % 2 != 0) // cu alte cuvinte verificam daca matricea este patrata:
            {
                Console.WriteLine(matrixOfIntegers[middleRow, middleCol]); // printeaza elemtentul din matrixOfIntegers cu pozitia de pe indexul valoarei variabilei middleRow si middleCol adica matrixOfIntegers[1,1]
            }
            else
            {
                Console.WriteLine("This matrix doesn't have a central element");
            }
        }
        
        public void GetSummOfDiagonalsElements(int[,] matrixOfIntegers)
        {
            /*print to console the central element from matrixOfIntegers, if not exist print: "This matrix doesn't have a central element"
             * |   input           | result              |
             * |-------------------|---------------------|
             * | {                 |                     |
             * |  { 1,   3,  5},   | First diagonal: 145 |
             * |  {-1, 100, 11},   | Second diagonal: 107|
             * |  { 2,  15, 44}    |                     |
             * |  }                |                     |
             * |-----------------------------------------|
             * |{                  |                     |
             * | { 1,  6, 21,  8 },| This matrix doesn't |
             * | { 5, -4,  5,  7 },| have a diagonals    |
             * | {77,  5,  0, 74 } |                     |
             * | }                 |                     |
             * ------------------------------------------
             *    
             */
            var middleRow = matrixOfIntegers.GetLength(0) / 2; // 3/2 = 1.5 (1)
            var middleCol = matrixOfIntegers.GetLength(1) / 2; // 3/2 = 1.5 (1) 
            int suma1 = 0, suma2 = 0, x = 0;

            //daca restul impartirii lungimei elementelor din rand nu va fi 0 SI daca restul impartirii lungimei elementelor din coloana nu va fi 0
            if (matrixOfIntegers.GetLength(0) % 2 != 0 && matrixOfIntegers.GetLength(1) % 2 != 0) // cu alte cuvinte verificam daca matricea este patrata:
            {
                for (int i = 0; i < matrixOfIntegers.GetLength(0); i++)
                    suma1 += matrixOfIntegers[i, i];
                Console.WriteLine("Sum for First diagonal {0}", suma1);

                for (int j = 0; j < matrixOfIntegers.GetLength(0); j++)
                    suma2 += matrixOfIntegers[x++, j];
                Console.WriteLine("Sum for Second diagonal {0}", suma2);
            }
            else
            {
                Console.WriteLine("This matrix doesn't have a central element");
            }
        }
        public void StarPrinter(int triangleHight)
        {
            /* Write a programm that will print a triagle of stars  with hight = triangleHight
             *  Example: triangleHight = 3;
             *  Result:   *
             *           * *
             *          * * * 
             */
            for (int i = 1; i <= triangleHight; ++i)
            {
                for (int j = triangleHight; j > i; --j)
                    Console.Write(" ");

                for (int j = 1; j < 2 * i; ++j)
                    Console.Write("*");

                Console.WriteLine();
            }
        }
        public void SortList(IList<int> listOfNumbers)
        {
            //Print to console elements of  listOfNumbers in ascending order

            //Bublesort method
            for (int i = 0; i < listOfNumbers.Count; i++) // atata timp cat i e mai mic decat numarul de elemente din listOfNumbers se va executa (cu alte cuvinte de cate ori se va executa acest for in cazul dat de 7 ori)
            {
                for (int j = 0; j < listOfNumbers.Count - 1; j++) // atata timp cat j e mai mic decat numarul de elemente din listOfNumbers minus 1 element, ca forul dat va merge anume pe indecsi respectiv trebuie sa fie 6 indecsi
                {
                    if (listOfNumbers[j] > listOfNumbers[j + 1]) // comparam daca valoarea indexului j e mai maire decat valoarea indexului j+1 (cum ar fi index 0 cu index 1) 
                    {
                        int temp = listOfNumbers[j]; // daca Valoarea indexului j e mai mare decat valoarea indexului j+1, atunci valoarea indexului j o stocam intro variabila temporara temp
                        listOfNumbers[j] = listOfNumbers[j + 1]; // asa cum valoarea din j am salvato, acum putem atribui valoarea din j+1 in j
                        listOfNumbers[j + 1] = temp; // acum valoarea pentru j+1 o punem pe aia din variabila temporara 
                    }
                }
            }

            foreach (int sortedList in listOfNumbers)
            {
                Console.Write(sortedList +" ");
            };
            Console.WriteLine("");

        }
        public static void Main(String[] args)
        {
            Homework homework = new Homework();
            IList<int> list = new List<int>() { -5, 8, -7, 0, 44, 121, -7 };
            int[,] matrix = new int[3, 3] {
                { 1,   3,  5},
                {-1, 100, 11},
                { 2,  15, 44} };
            int[,] matrix2 = new int[3, 4] {
                { 1,   3,  5,   6},
                { 2,   3,  5,  78},
                {100, 56 , -54, 6} };

            Console.WriteLine("--------- GetCentralElementFromMatrix --------- ");
            homework.GetCentralElementFromMatrix(matrix);

            Console.WriteLine("\n--------- GetCentralElementFromMatrix 2 --------- ");
            homework.GetCentralElementFromMatrix(matrix2);

            Console.WriteLine("\n--------- GetSummOfDiagonalsElements --------- ");
            homework.GetSummOfDiagonalsElements(matrix);

            Console.WriteLine("\n--------- GetSummOfDiagonalsElements 2 --------- ");
            homework.GetSummOfDiagonalsElements(matrix2);

            Console.WriteLine("\n--------- StarPrinter --------- ");
            homework.StarPrinter(4);

            Console.WriteLine("--------- SortList --------- ");
            homework.SortList(list);

        }

    }
}