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
            Employee emp = new Employee();
            emp.FirstName = "Daniel";
            emp.LastName = "Antonov";
            emp.Salary = 50000;
            return View("MyView", emp);
        }
    }
}
