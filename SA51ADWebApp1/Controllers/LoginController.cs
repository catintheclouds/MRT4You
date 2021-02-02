﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA51ADWebApp1.Models;
using SA51ADWebApp1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA51ADWebApp1.Controllers
{
    public class LoginController : Controller
    {
        protected Database dbcontext;

        public LoginController (Database dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [Route("/")]
        [Route("/login")]
        public IActionResult Login()
        {
            Admin newLogin = new Admin();
            return View(newLogin);
        }

        [HttpPost]
        public IActionResult ValidateLogin(Admin newLogin)
        {
            Admin inDatabase = dbcontext.Admins.Where(x => x.username == newLogin.username && x.password == newLogin.password).FirstOrDefault();
            if (inDatabase == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                string sessionId = System.Guid.NewGuid().ToString();
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Append("sessionId", sessionId, options);
            }
            return View("Home");
        }

        [Route("/logout")]
        public IActionResult Logout()
        {
            return View("Logout");
        }
    }
}
