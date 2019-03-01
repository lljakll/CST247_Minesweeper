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
        BoardModel game = new BoardModel(7);

        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Game(int size)
        {

            var id = "";

            try
            {
                id = Request.Params
                        .Cast<string>()
                        .Where(p => p.StartsWith("location"))
                        .Select(p => p.Substring("location".Length + 1))
                        .First();

                System.Console.WriteLine(id);
            }
            catch
            {
                // No value.
            }

            // BoardModel game = new BoardModel(7);

            ViewBag.Size = game.Size;
            ViewBag.Board = game.GameBoard;
            //ViewBag.Location = new int[game.Size, game.Size];

            //ViewBag.X = new int();
            //ViewBag.Y = new int();

            return View();
        }
    }
}