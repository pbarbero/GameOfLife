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

        public void SetRandomSeed(int height, int width)
        {
            var random = new Random();
            var numberAlivedCells = random.Next(0, height*width);

            for (int i = 0; i < numberAlivedCells; i++)
            {
                var randomHeight = random.Next(0, Height);
                var randomWidth = random.Next(0, Width);

                var cell = GetCell(randomWidth, randomHeight);
                cell.IsAlive = true;
            }
        }

        public void SetCenterSeed(int numberCells, int height, int width)
        {
            var cellsToBeAlive = new List<Cell>();
            var random = new Random();
            var centerX = width / 2;
            var centerY = height / 2;

            var centerCell = GetCell(centerX, centerY);
            cellsToBeAlive.Add(centerCell);
            var radius = 1;

            for (int i = 0; i < numberCells; i++)
            {
                var randomX = random.Next(centerX  - radius, centerX + radius);
                var randomY = random.Next(centerY -radius, centerY + radius);

                if (0 <= randomX && randomX < width && 0 <= randomY && randomY < height)
                {
                    var otherCell = GetCell(randomX, randomY);
                    cellsToBeAlive.Add(otherCell);

                    if (numberCells % 5 == 0)
                    {
                        radius++;
                    }
                }
            }

            cellsToBeAlive.ForEach(cell => cell.IsAlive = true);
        }
    }
}
