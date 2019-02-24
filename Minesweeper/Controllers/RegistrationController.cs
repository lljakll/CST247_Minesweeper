using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "FirstName,LastName,Gender,Age,State,Email,Username,Password,ConfirmPassword")] Minesweeper.Models.UserModel submission)
        {
            // Check for errors
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            // Do controller things

            return RedirectToAction("Index", "Home");
        }
    }
}