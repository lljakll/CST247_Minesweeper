using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models.Game
{
    public class Grid
    {
        public string Id { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int UserId { get; set; }
        public bool GameOver { get; set; }
        public Cell[,] Cells { get; set; }
        public int ClickCount { get; set; }
        public int TimeInSeconds { get; set; }

        public Grid(string id, int rows, int cols, int userId, bool gameOver)
        {
            Id = id;
            Rows = rows;
            Cols = cols;
            UserId = userId;
            GameOver = gameOver;

            ClickCount = 0;
        }

        public Grid(string id, int rows, int cols, int userId, bool gameOver, Cell[,] cells)
        {
            Id = id;
            Rows = rows;
            Cols = cols;
            UserId = userId;
            GameOver = gameOver;
            Cells = cells;

            ClickCount = 0;
        }

        public void SetLiveCount()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    // North (-1, 0)
                    if (i - 1 >= 0)
                    {
                        if (Cells[i - 1, j].Live == true)
                        {
                            Cells[i, j].LiveNeighbors += 1;
                        }
                    }

                    // NorthWest (-1, -1)
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        if (Cells[i - 1, j - 1].Live == true)
                        {
                            Cells[i, j].LiveNeighbors += 1;
                        }
                    }

                    // NorthEast (-1, +1)
                    if (i - 1 >= 0 && j + 1 < Cols)
                    {
                        if (Cells[i - 1, j + 1].Live == true)
                        {
                            Cells[i, j].LiveNeighbors += 1;
                        }
                    }

                    // South (+1, 0)
                    if (i + 1 < Rows)
                    {
                        if (Cells[i + 1, j].Live == true)
                        {
                            Cells[i, j].LiveNeighbors += 1;
                        }
                    }

                    // SouthWest (+1, -1)
                    if (i + 1 < Rows && j - 1 >= 0)
                    {
                        if (Cells[i + 1, j - 1].Live == true)
                        {
                            Cells[i, j].LiveNeighbors += 1;
                        }
                    }

                    // SouthEast (+1, +1)
                    if (i + 1 < Rows && j + 1 < Cols)
                    {
                        if (Cells[i + 1, j + 1].Live == true)
                        {
                            Cells[i, j].LiveNeighbors += 1;
                        }
                    }

                    // Check East (0, +1)
                    if (j + 1 < Cols)
                    {
                        if (Cells[i, j + 1].Live == true)
                        {
                            Cells[i, j].LiveNeighbors += 1;
                        }
                    }

                    // Check West (0, -1)
                    if (j - 1 >= 0)
                    {
                        if (Cells[i, j - 1].Live == true)
                        {
                            Cells[i, j].LiveNeighbors += 1;
                        }
                    }
                }
            }
        }
    }
}