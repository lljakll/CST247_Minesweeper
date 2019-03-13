
using Minesweeper.Services;
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
        public ActionResult Register([Bind(Include = "FirstName,LastName,Gender,Age,State,Email,Username,Password,ConfirmPassword")] Models.UserModel submission)
        {
            // Check for errors
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                return NewUser(submission);
            }

        }

        /// <summary>
        /// Method that returns the proper view upon successful or unsuccessful user registration.
        /// </summary>
        /// <param name="user">The user object.</param>
        private ActionResult NewUser(Models.UserModel user)
        {
            // Get database service
            DatabaseService dbService = new DatabaseService();

            // Add user to database.
            if (dbService.AddNewUser(user))
            {
                // If successful...
                return View("Success");
            }
            else
            {
                // If not successfull
                return View("Failure");
            }
        }
    }
}