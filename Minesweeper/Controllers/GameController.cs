using System;
using System.Web.Mvc;
using Minesweeper.Constants;
using Minesweeper.Models.Game;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            if (Globals.Grid.GameOver == false)
            {
                Grid grid = CreateGrid(Session["user"].ToString(), Globals.Grid.Rows, Globals.Grid.Rows);
            }

            Session["time_a"] = DateTime.Now;

            ViewBag.Time = Session["time_a"];

            ViewBag.SavedTime = DateTime.Now.AddMinutes(-10).ToString();

            return View("Index", Globals.Grid);
        }

        public Grid CreateGrid(string username, int width, int height)
        {
            // Grid(id, w, h, userid, gameover)
            Globals.Grid = new Grid(Session["user"].ToString(), width, height, 0, false);
            Cell[,] cells = new Cell[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new Cell(x, y);
                    cells[x, y].Id = username;
                }
            }

            // Activate the cells
            ActivateCells(20, width, height, cells, Globals.Grid);
            Globals.Grid.GameOver = false;

            return Globals.Grid;
        }

        public void ActivateCells(int percentage, int width, int height, Cell[,] mineField, Grid grid)
        {
            Random random = new Random();

            int TotalLiveCount = 0;

            if (percentage > 100 || percentage < 1)
            {
                percentage = 20;
            }
            else
            {
                percentage = (int)((width * height) * (percentage / 100.00));

                TotalLiveCount = percentage;
            }

            while (percentage > 0)
            {
                var cell = mineField[
                    random.Next(0, width),
                    random.Next(0, height)];

                if (cell.Live == false)
                {
                    cell.Live = true;
                    percentage -= 1;
                }
                else
                {
                    continue;
                }
            }

            grid.Cells = mineField;

            grid.SetLiveCount();
        }

        //public ActionResult

        [HttpPost]
        public PartialViewResult ActivateCell(string id, string x, string y)
        {
            int X = int.Parse(x.Trim());
            int Y = int.Parse(y.Trim());

            Cell cell = Globals.Grid.Cells[X, Y];

            if (cell.Visited == false)
            {
                Globals.Grid.ClickCount += 1;
            }

            cell.Visited = true;

            if (cell.Live)
            {
                return EndGame();
            }
            else
            {
                if (cell.LiveNeighbors == 0)
                {
                    revealSurroundingCells(Globals.Grid, cell.X, cell.Y);
                }
            }

            return PartialView("Game", Globals.Grid);
            //return View("Index", Globals.Grid);
        }

        private PartialViewResult EndGame()
        {
            RevealAll();

            return PartialView("Game", Globals.Grid);
        }

        private void RevealAll()
        {
            Grid g = Globals.Grid;

            g.GameOver = true;

            for (int i = 0; i < g.Rows; i++)
            {
                for (int j = 0; j < g.Cols; j++)
                {
                    g.Cells[i, j].Visited = true;
                }
            }
        }

        private bool revealSurroundingCells(Grid grid, int x, int y)
        {
            Cell cell = grid.Cells[x, y];
            cell.Visited = true;

            //grid.Cells[x, y].Reveal();
            // visted count

            if (cell.LiveNeighbors > 0)
            {
                return false;
            }

            if (cell.Y - 1 >= 0)
            {
                var westLocation = grid.Cells[cell.X, cell.Y - 1];

                if (!westLocation.Live && !westLocation.Visited)
                {
                    if (westLocation.LiveNeighbors == 0)
                    {
                        revealSurroundingCells(grid, westLocation.X, westLocation.Y);
                    }
                    else
                    {
                        westLocation.Visited = true;
                        //westLocation.Reveal();
                        //vistedCount += 1;
                        // Update Score
                    }
                }
            }

            if (cell.X - 1 >= 0)
            {
                var northLocation = grid.Cells[cell.X - 1, cell.Y];

                if (!northLocation.Live && !northLocation.Visited)
                {
                    if (northLocation.LiveNeighbors == 0)
                    {
                        revealSurroundingCells(grid, northLocation.X, northLocation.Y);
                    }
                    else
                    {
                        northLocation.Visited = true;
                        //westLocation.Reveal();
                        //vistedCount += 1;
                        // Update Score
                    }
                }
            }

            if (cell.Y + 1 < grid.Cols)
            {
                var southLocation = grid.Cells[cell.X, cell.Y + 1];

                if (!southLocation.Live && !southLocation.Visited)
                {
                    if (southLocation.LiveNeighbors == 0)
                    {
                        revealSurroundingCells(grid, southLocation.X, southLocation.Y);
                    }
                    else
                    {
                        southLocation.Visited = true;
                        //westLocation.Reveal();
                        //vistedCount += 1;
                        // Update Score
                    }
                }
            }

            if (cell.X + 1 < grid.Rows)
            {
                var eastLocation = grid.Cells[cell.X + 1, cell.Y];

                if (!eastLocation.Live && !eastLocation.Visited)
                {
                    if (eastLocation.LiveNeighbors == 0)
                    {
                        revealSurroundingCells(grid, eastLocation.X, eastLocation.Y);
                    }
                    else
                    {
                        eastLocation.Visited = true;
                        //westLocation.Reveal();
                        //vistedCount += 1;
                        // Update Score
                    }
                }
            }

            return false;
        }

        public ActionResult ResetGrid()
        {
            int size = Globals.Grid.Rows;

            Globals.Grid = CreateGrid(Session["user"].ToString(), size, size);

            //returns view
            // return PartialView("Game", Globals.Grid);
            return Index();
        }

        //[HttpPost]
        //public ActionResult SetDifficulty(string difficulty)
        //{
        //    // Default
        //    int toughness = 10;

        //    if (difficulty.Equals("Easy"))
        //    {
        //        toughness = 10;
        //    }

        //    if (difficulty.Equals("Medium"))
        //    {
        //        toughness = 15;
        //    }

        //    if (difficulty.Equals("Hard"))
        //    {
        //        toughness = 20;
        //    }
        //    // Create New Grid
        //    Globals.Grid = CreateGrid(toughness, toughness);

        //    //returns view
        //    return PartialView("Game", Globals.Grid);
        //}

        public ActionResult RightClick()
        {
            return View("None");
        }

        public ActionResult SaveGame()
        {
            // Calc Time
            DateTime a = DateTime.Parse(Session["time_a"].ToString());
            DateTime b = DateTime.Now;

            // Get database service
            DatabaseService dbService = new DatabaseService();
            GameServices gameService = new GameServices();

            // handle Time
            int timeInSeconds = (int)b.Subtract(a).TotalSeconds;

            // Store Time
            Globals.Grid.TimeInSeconds = timeInSeconds;

            // Parse Time
            string totalTime = "";

            TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);

            totalTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                time.Hours,
                time.Minutes,
                time.Seconds);

            ViewBag.TotalTime = totalTime;

            string username = Session["user"].ToString();

            dbService.SaveGame(
                username, 
                timeInSeconds, 
                Globals.Grid.ClickCount, 
                gameService.ConvertToText(
                    Globals.Grid.Cells, 
                    Globals.Grid.Rows, 
                    Globals.Grid.Cols));

            ViewBag.Username = username;

            return View("Account", Globals.Grid);
        }

        public ActionResult ContinueGame()
        {
            string username = Session["user"].ToString();

            DatabaseService dbService = new DatabaseService();
            Globals.Grid = new Grid("", 0, 0, 0, false);

            // get grid from database
            Globals.Grid = dbService.GetSavedGrid(username);

            return View("Index", Globals.Grid);
        }

        public ActionResult NewGame()
        {
            return null;
        }

    }
}