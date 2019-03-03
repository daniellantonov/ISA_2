using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core;
using Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Laborid.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
	        public async Task<IActionResult> DoLogin(UserDetails u)
        {
            if (Employees.IsValidUser(u))
            {
                await setIdentity(u);
                return RedirectToAction("Index", "Employee");
            }
            ModelState.AddModelError("CredentialError", "Invalid Username or Password");
            return View("Login");
        }

        private async Task setIdentity(UserDetails u)
        {
            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, u.UserName) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(scheme: "AuthScheme", principal: principal);
        }
    }
}