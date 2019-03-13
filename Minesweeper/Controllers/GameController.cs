using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper.Constants;
using Minesweeper.Models;
using Minesweeper.Models.Game;

namespace Minesweeper.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            if (Globals.Grid.GameOver == false)
            {
                Grid grid = CreateGrid(Globals.Grid.Rows, Globals.Grid.Rows);
            }

            return View("Game", Globals.Grid);
        }

        //// GET: Game
        //public ActionResult Index(int size)
        //{
        //    Grid grid = createGrid(size, size);

        //    return View("Game", TEMP.grid);
        //}

        public Grid CreateGrid(int width, int height)
        {
            // Grid(id, w, h, userid, gameover)
            Globals.Grid = new Grid(0, width, height, 0, false);
            Cell[,] cells = new Cell[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }

            // Activate the cells
            ActivateCells(20, width, height, cells, Globals.Grid);
            Globals.Grid.GameOver = false;

            // Pass Grid to datalayer??

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
        public ActionResult ActivateCell(string id, string x, string y)
        {
            int X = int.Parse(x.Trim());
            int Y = int.Parse(y.Trim());

            Cell cell = Globals.Grid.Cells[X, Y];

            cell.Visited = true;

            if (cell.Live)
            {
                //for (int i = 0; i < Globals.Grid.Rows; i++)
                //{
                //    for (int j = 0; j < Globals.Grid.Cols; j++)
                //    {
                //        Globals.Grid.Cells[X, Y].Visited = true;
                //    }
                //}

                EndGame();

                return Index();

                // System.Diagnostics.Debug.WriteLine("Hit bomb at: " + X + ", " + Y);
            }
            else
            {
                if (cell.LiveNeighbors == 0)
                {
                    revealSurroundingCells(Globals.Grid, cell.X, cell.Y);
                }
            }

            return View("Game", Globals.Grid);
        }

        private ActionResult EndGame()
        {
            RevealAll();

            return Index();
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
                var northLocation = grid.Cells[cell.X, cell.Y - 1];

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

            if (cell.X - 1 >= 0)
            {
                var westLocation = grid.Cells[cell.X - 1, cell.Y];

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

                if (cell.Y + 1 < grid.Cols)
                {
                    var southwestLocation = grid.Cells[cell.X - 1, cell.Y + 1];

                    if (!southwestLocation.Live && !southwestLocation.Visited)
                    {
                        if (southwestLocation.LiveNeighbors == 0)
                        {
                            revealSurroundingCells(grid, southwestLocation.X, southwestLocation.Y);
                        }
                        else
                        {
                            southwestLocation.Visited = true;
                            //westLocation.Reveal();
                            //vistedCount += 1;
                            // Update Score
                        }
                    }
                }

                if (cell.Y - 1 >= 0)
                {
                    var northwestLocation = grid.Cells[cell.X - 1, cell.Y - 1];

                    if (!northwestLocation.Live && !northwestLocation.Visited)
                    {
                        if (northwestLocation.LiveNeighbors == 0)
                        {
                            revealSurroundingCells(grid, northwestLocation.X, northwestLocation.Y);
                        }
                        else
                        {
                            northwestLocation.Visited = true;
                            //westLocation.Reveal();
                            //vistedCount += 1;
                            // Update Score
                        }
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

                if (cell.Y + 1 < grid.Cols)
                {
                    var southeastLocation = grid.Cells[cell.X + 1, cell.Y + 1];

                    if (!southeastLocation.Live && !southeastLocation.Visited)
                    {
                        if (southeastLocation.LiveNeighbors == 0)
                        {
                            revealSurroundingCells(grid, southeastLocation.X, southeastLocation.Y);
                        }
                        else
                        {
                            southeastLocation.Visited = true;
                            //westLocation.Reveal();
                            //vistedCount += 1;
                            // Update Score
                        }
                    }
                }

                if (cell.Y - 1 >= 0)
                {
                    var northeastLocation = grid.Cells[cell.X + 1, cell.Y - 1];

                    if (!northeastLocation.Live && !northeastLocation.Visited)
                    {
                        if (northeastLocation.LiveNeighbors == 0)
                        {
                            revealSurroundingCells(grid, northeastLocation.X, northeastLocation.Y);
                        }
                        else
                        {
                            northeastLocation.Visited = true;
                            //westLocation.Reveal();
                            //vistedCount += 1;
                            // Update Score
                        }
                    }
                }

            }

            return false;
        }

        [HttpGet]
        public ActionResult ResetGrid()
        {
            int size = Globals.Grid.Rows;

            Globals.Grid = new Grid(0, size, size, 0, false);

            //returns view
            return Index();
        }

        [HttpGet]
        public ActionResult SetDifficulty(string difficulty)
        {
            Globals.Grid.GameOver = false;

            int size = 10;

            switch (difficulty)
            {
                case "Easy":
                    size = 10;
                    break;
                case "Medium":
                    size = 15;
                    break;
                case "Hard":
                    size = 20;
                    break;
            }
            Globals.Grid = new Grid(0, size, size, 0, false);

            //returns view
            return Index();
        }

        public ActionResult RightClick()
        {
            return View("None");
        }

    }
}