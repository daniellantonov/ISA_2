using System;
using Core;

namespace Facade
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(Employee emp)
        {
            if (emp is null) return;
            SetName(emp);
            SetSalary(emp);
            SetColor(emp);
        }

        public string EmployeeName { get; set; }
        public string Salary { get; set; } = 0.ToString("C");
        public string SalaryColor { get; private set; } = "red";


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

    }
}
