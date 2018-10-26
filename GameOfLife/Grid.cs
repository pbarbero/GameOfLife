using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Grid
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Cell> Cells { get; set; }

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public void Create()
        {
            Cells = new List<Cell>();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cells.Add(new Cell(j, i, this));
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return Cells.FirstOrDefault(cell => cell.Y == y && cell.X == x);
        }

        public void NextIteration()
        {
            Task[] tasks = new Task[Height * Width];

            var numberCells = 0;
            foreach (var cell in Cells)
            {
                var task = Task.Factory.StartNew(() => cell.UpdateCellStatus());
                tasks[numberCells] = task;
                numberCells++;
            }

            Task.WaitAll(tasks);
        }

        public void SetSeed()
        {
            var random = new Random();

            for (int i = 0; i < Height*Width/3; i++)
            {
                var randomHeight = random.Next(0, Height);
                var randomWidth = random.Next(0, Width);

                var cell = GetCell(randomWidth, randomHeight);
                cell.IsAlive = true;
            }
        }
    }
}
