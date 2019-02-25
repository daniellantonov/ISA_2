using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(string firstName, string lastname, int salary)
        {
            FirstName = firstName;
            LastName = lastname;
            Salary = salary;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}
