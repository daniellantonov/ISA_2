using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC.Views.Employee
{
    public class NewLinkViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.Session.GetString("SessionKeyName") == "Admin") return View("AddNewLink");
            return Content(string.Empty);
        }
    }
}