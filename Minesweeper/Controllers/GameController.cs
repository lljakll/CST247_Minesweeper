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

        // POST
        public ActionResult RightClick(FormCollection form)
        {
            // F for flag.  
            // TODO: Incorporate a flag pic using css background .addClass()/.removeClass() jQuery
            string status = "F";

            // Return message to view
            return Json(new { found = true, row = form["row"], column = form["column"], message = status });
        }

        // POST
        public ActionResult LeftClick(FormCollection form)
        {
            string status;

            // set cells visited flag when left clicked
            game.GameBoard[int.Parse(form["row"]), int.Parse(form["column"])].Visited = true;

            // Display 'x' if live, else return LiveNeighbors
            // TODO: Incorporate an explosiion pic using css background .addClass()/.removeClass() jQuery 
            if (game.GameBoard[int.Parse(form["row"]), int.Parse(form["column"])].IsLive == true)
            {
                // TODO: Display Explosion, end game, show stats
                status = "Game Over! You have hit a mine."; // X for explosion
            }

            else
            {
                // TODO: display all open cells connected to this cell and number of live cells on cells at the border of this "wave"

                // sets message if not dead
                if (game.GameBoard[int.Parse(form["row"]), int.Parse(form["column"])].LiveNeighbors == 0)
                {
                    status = "(" + form["row"] + ", " + form["column"] + ") is clear.  Opening up all surrounding cells that are not mined.";
                }
                else
                {
                    // TODO: Add in logic to change the icon on the button , expose  the field of nonlive/no live neighbors and wait for another click. also need to add a custom click graphic to change the clicked buttons so they are visible.  color maybe?

                    status = "(" + form["row"] + ", " + form["column"] + ") has " + game.GameBoard[int.Parse(form["row"]),int.Parse(form["column"])].LiveNeighbors + " live neighbors.";
                }

                
            }

            // Return message to view
            // need to remove this and use .text() jQuery update to update the cell markings or something like that.

            return Json(new { found = true, row = form["row"], column = form["column"], message = status });
        }
    }
}