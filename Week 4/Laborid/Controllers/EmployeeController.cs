using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;
using Facade;
using Infra;
using Microsoft.AspNetCore.Authorization;
using Laborid.Filters;
using Microsoft.EntityFrameworkCore;

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
                employee.EmployeeID = e.EmployeeID;
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
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Employee employee = db.Employees.Find(id);
            if (employee == null) return NotFound();
            return View("Delete", employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await db.Employees.SingleOrDefaultAsync
                (m => m.EmployeeID == id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var employee = await db.Employees.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null) return NotFound();
            return View("Edit", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("EmployeeID,FirstName,LastName,Salary")] Employee employee)
        {
            if (id != employee.EmployeeID) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(employee);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID)) return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
