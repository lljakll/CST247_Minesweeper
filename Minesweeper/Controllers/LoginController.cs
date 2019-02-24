using System;
using System.Web.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    /// <summary>
    /// LoginController Class
    /// </summary>
    /// 
    /// <remarks>
    /// Descr.:     This controller handles the login process. Simple verification of
    ///             user credentials through the database service. Redirects to 
    ///             "SUCCESS" or "FAIL" during login attempt.
    /// 
    /// Authors:    Jay Wilson
    ///             Chase Hausman
    ///             Jacki Adair
    ///             Nathan Ford
    ///             Richard Boyd
    ///             
    /// Date:       02/21/19
    /// Version:    1.0.0
    /// </remarks>
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
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
                // Store username and password
                // NOTE: Will likely need to hash the password to protect it.
                string username = collection["username"].Trim();
                string password = collection["password"].Trim();

                // Verification of input field length
                if (String.IsNullOrEmpty(username))
                {
                    ModelState.AddModelError("username", "You must enter a username to login.");
                }

                // Verification of input field length
                if (String.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("password", "You must enter a password to login.");
                }

                // Check for errors added to ModelState
                if (!ModelState.IsValid)
                {
                    return View("Login");
                }

                // Validate User and get view
                return ValidateUser(username, password);
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Method to validate user.
        /// </summary>
        /// <param name="username">User to validate.</param>
        /// <param name="password">Password to validate.</param>
        /// <returns></returns>
        private ActionResult ValidateUser(string username, string password)
        {
            // Get database service
            DatabaseService dbService = new DatabaseService();

            // Retrieve user info
            UserModel user = dbService.RetrieveUser(username);

            try
            {
                // If user name and password match input, then success!
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return View("Success");
                }
            }
            catch
            {
                // Exception if user is null for some reason.
            }

            // Failure to login with correct credentials and possible other errors.
            return View("Failure");
        }
    }
}