using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lesson_01_Homework
{
    public interface IEmployeeOperations
    {
       double SalaryCalculator(int numberOfDays, double rate);
       int Experience(DateTime dateOfEmploymnet);
    }
}
