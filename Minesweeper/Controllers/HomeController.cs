using Minesweeper.Constants;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    /// <summary>
    /// HomeController Class
    /// </summary>
    /// 
    /// <remarks>
    /// Descr.:     This controller handles the home page.
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
    public class HomeController : Controller
    {
        /// <summary>
        /// Go to index.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Go to About Page
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "About Page";
            return View();
        }

        /// <summary>
        /// Go to Contact Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Go to sign in page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Game()
        {
            Globals.Grid = new Models.Game.Grid(0, 10, 10, 0, false);

            return RedirectToAction("Index", "Game");
        }
    }
}