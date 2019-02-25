using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

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
            Employee emp = new Employee
            {
                FirstName = "Daniel",
                LastName = "Antonov",
                Salary = 50000
            };
            ViewData["Employee"] = emp;
            return View("MyView");
        }
    }
}
