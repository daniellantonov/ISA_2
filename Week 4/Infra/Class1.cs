using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Microsoft.CodeAnalysis;

namespace Infra
{
        public class Employees
    {
        public static List<Employee> Get(SalesDbContext db)
        {
            return db.Employees.ToList();
        }

        public Employee Save(Employee e, SalesDbContext db)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return e;
        }
    }
}