using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;
using Facade;
using Infra;
using Microsoft.AspNetCore.Authorization;
using ASP.NET_MVC.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Laborid.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly SalesDbContext db;

        public EmployeeController(SalesDbContext db) { this.db = db; }
        
        public ActionResult Index()
        {
            
            var model = new EmployeeListViewModel();
            model.UserName = User.Identity.Name;
            var employees = Employees.Get(db);
            var list = new List<EmployeeViewModel>();
            foreach (var e in employees)
            {
                var employee = new EmployeeViewModel(e);
                list.Add(employee);
            }
            model.Employees = list;
            model.FooterData = new FooterViewModel();
            model.FooterData.CompanyName = "TalTech";
            model.FooterData.Year = DateTime.Now.Year.ToString();
            return View("Index", model);
        }

        [Authorize]
        [AdminFilter]
        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        [Authorize]
        [AdminFilter]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            if (BtnSubmit != "Save Employee") return RedirectToAction("Index");
            if (!ModelState.IsValid) return View("CreateEmployee");
            return save(e);
        }

        private ActionResult save(Employee e)
        {
            Employees emp = new Employees();
            emp.Save(e, db);
            return RedirectToAction("Index");
        }
    }
}
