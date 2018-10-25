﻿using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(10, 20);
            grid.Create();

            int numberIterations = 10;

            for (int i = 0; i < numberIterations; i++)
            {
                PrintIteration(grid);
                Console.WriteLine("----------------------------------------");
                grid.NextIteration();
            }
        }

        private static void PrintIteration(Grid grid)
        {
            for (int i = 0; i < grid.Height; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    var cell = grid.GetCell(j, i);

                    if (cell.IsAlive)
                    {
                        Console.Write("o");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }

                Console.WriteLine("");
            }
        }
    }
}
