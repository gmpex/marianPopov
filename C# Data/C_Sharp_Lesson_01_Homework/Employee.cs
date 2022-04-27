using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lesson_01_Homework
{
    public class Employee
    {
        public string name { set { this.name = name; } get { return this.name; } }
        public double rate { set { this.rate = rate; } get { return this.rate; } }
        public DateTime employmentDate { set { this.employmentDate = employmentDate; } get { return this.employmentDate; } }

        public Employee(string name, double rate, DateTime employmentDate)
        {
            this.name = name;
            this.rate = rate;
            this.employmentDate = employmentDate;
        }
    }
}
