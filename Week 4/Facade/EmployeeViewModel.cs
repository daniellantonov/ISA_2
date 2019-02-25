using System;
using Core;

namespace Facade
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(Employee emp, string username)
        {
            SetName(emp);
            SetSalary(emp);
            SetColor(emp);
            SetUserName(username);
        }

        public string EmployeeName { get; set; }
        public string Salary { get; set; }
        public string SalaryColor { get; private set; } = "red";
        public string UserName { get; set; }

        public void SetName(Employee e)
        {
            EmployeeName = e.FirstName + " " + e.LastName;
        }

        public void SetColor(Employee e)
        {
            if (!ReferenceEquals(null, e))
                SalaryColor = e.Salary > 15000 ? "yellow" : "green";
            else SalaryColor = "red";
        }

        public void SetSalary(Employee e)
        {
            Salary = e.Salary.ToString("C");
        }

        public void SetUserName(string userName)
        {
            UserName = userName ?? string.Empty;
        }
    }
}
