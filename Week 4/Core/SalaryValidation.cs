using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class SalaryValidation : NameValidation
    {
        protected const string salaryRange = "Salary must be between {0} and {1}";
        protected int minSalary = 5000;
        protected int maxSalary = 50000;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return error(requiredField);
            var i = value as int?;
            if (i < minSalary) return error(salary);
            if (i > maxSalary) return error(salary);
            return ValidationResult.Success;
        }

        private string salary
        {
            get
            {
                var min = minSalary.ToString("C");
                var max = maxSalary.ToString("C");
                var s = string.Format(salaryRange, min, max);
                return s;
            }
        }
    }
}
