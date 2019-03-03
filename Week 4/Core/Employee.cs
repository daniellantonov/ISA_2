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

        public Employee(string firstName, string lastname=null, int salary=0)
        {
            FirstName = firstName?? string.Empty;
            LastName = lastname?? string.Empty;
            Salary = salary;
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}
