using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(string firstName, string lastname = null, int salary = 0)
        {
            FirstName = firstName ?? string.Empty;
            LastName = lastname ?? string.Empty;
            Salary = salary;
        }

        public int EmployeeID { get; set; }
        [NameValidation]
        public string FirstName { get; set; }
        [NameValidation]
        public string LastName { get; set; }
        [SalaryValidation]
        public int Salary { get; set; }
    }
}
