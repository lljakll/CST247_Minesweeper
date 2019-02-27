using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models
{
    public class BoardModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public CellModel[,] GameBoard;

        public BoardModel(int width, int height)
        {
            Width = width;
            Height = height;
            SetUpBoard();
            SetLiveNeighbors();
        }

        private void SetUpBoard()
        {
            GameBoard = new CellModel[Height, Width];
            for(int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    GameBoard[i,j] = new CellModel();
                }
            }
        }

        private void SetLiveNeighbors()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int count = 0;

                    count += CheckNeighbor(i + 1, j + 1);
                    count += CheckNeighbor(i + 1, j);
                    count += CheckNeighbor(i + 1, j - 1);
                    count += CheckNeighbor(i, j + 1);
                    count += CheckNeighbor(i, j - 1);
                    count += CheckNeighbor(i - 1, j + 1);
                    count += CheckNeighbor(i - 1, j);
                    count += CheckNeighbor(i - 1, j - 1);

                    GameBoard[i, j].LiveNeighbors = count;
                }
            }
        }

        private int CheckNeighbor(int e, int d)
        {
            if (e == -1 || e == Height || d == -1 || d == Width)
                return 0;

            if (GameBoard[e,d].IsLive)
            {
                return 1;
            }
            return 0;
        }
    }
}