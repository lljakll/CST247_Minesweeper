using Minesweeper.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Services
{
    public class GameServices
    {
        public Grid CreateGrid(Grid grid, int width, int height)
        {
            // Create new grid object
            grid = new Grid(0, width, height, 0, false);

            // Create cell matrix
            Cell[,] cells = new Cell[width, height];


            // Develop the Cell map using new cell generation
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }

            // Activate the cells
            PopulateMinefield(20, width, height, cells, grid);

            // Force Gameover to equal false
            grid.GameOver = false;

            return grid;
        }

        public void PopulateMinefield(int percentage, int width, int height, Cell[,] cells, Grid grid)
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
                var cell = cells[
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

            grid.Cells = cells;

            grid.SetLiveCount();
        }

        public void ActivateLocation(Grid grid, int x, int y)
        {
            // Get reference to cell to use
            Cell cell = grid.Cells[x, y];

            // Set visited
            cell.Visited = true;

            // Check if gameover
            if (cell.Live)
            {
                grid.GameOver = true;
            }
            else
            {
                // Reveal board if not live
                if (cell.LiveNeighbors == 0)
                {
                    RevealSurroundingCells(grid, cell.X, cell.Y);
                }
            }
        }

        public void RevealAll(Grid grid)
        {
            grid.GameOver = true;

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    grid.Cells[i, j].Visited = true;
                }
            }
        }

        public bool RevealSurroundingCells(Grid grid, int x, int y)
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
                        RevealSurroundingCells(grid, westLocation.X, westLocation.Y);
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
                        RevealSurroundingCells(grid, northLocation.X, northLocation.Y);
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
                        RevealSurroundingCells(grid, southLocation.X, southLocation.Y);
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
                        RevealSurroundingCells(grid, eastLocation.X, eastLocation.Y);
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
    }
}