using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                string Username = collection["username"].Trim();
                string Password = collection["password"].Trim();

                if (String.IsNullOrEmpty(Username))
                {
                    ModelState.AddModelError("username", "You must enter a username to login.");
                }

                if (String.IsNullOrEmpty(Password))
                {
                    ModelState.AddModelError("password", "You must enter a password to login.");
                }

                if (!ModelState.IsValid)
                {
                    return View("index");
                }

                // Actual Controller Stuff Can Go Here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}