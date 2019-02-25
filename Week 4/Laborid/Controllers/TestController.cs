using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;
using Facade;

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
        public IActionResult GetView()
        {
            var emp = new Employee("Daniel", "Antonov", 20000);

            var vmEmp = new EmployeeViewModel(emp, "Admin");
            return View("MyView", vmEmp);
        }
    }
}
