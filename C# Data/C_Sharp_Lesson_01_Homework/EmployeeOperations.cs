using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lesson_01_Homework
{
    public class EmployeeOperations : IEmployeeOperations
    {
        public int Experience(DateTime dateOfEmploymnet)
        {
            return DateTime.Now.Year - dateOfEmploymnet.Year;
        }

        public double SalaryCalculator(int numberOfDays, double rate)
        {
            return numberOfDays * rate * 8;
        }
    }
}
