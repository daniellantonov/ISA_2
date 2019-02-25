using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;
using Facade;
using Infra;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Laborid.Controllers
{
    public class TestController : Controller
    {
        public string GetString()
        {
            return "Hello World!";
        }
        // GET: /<controller>/
        public ActionResult GetView()
        {
            var emp = new Employee("Daniel", "Antonov", 20000);
            var model = new EmployeeListViewModel();
            var employees = Employees.Get();
            var list = new List<EmployeeViewModel>();
            foreach (var e in employees)
            {
                var employee = new EmployeeViewModel(e);
                list.Add(employee);
            }
            model.Employees = list;
            model.UserName = "Admin";
            return View("MyView", model);
        }
    }
}
