using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            BoardModel game = new BoardModel(7, 7);

            ViewBag.Height = game.Height;
            ViewBag.Width = game.Width;
            ViewBag.board = game.GameBoard;

            return View();
        }
    }
}