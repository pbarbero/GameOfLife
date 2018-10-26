using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = 10;
            var width = 20;
            var grid = new Grid(height, width);
            //grid.SetRandomSeed(height, width);
            grid.SetCenterSeed(20, height, width);

            int numberIterations = 100;

            for (int i = 0; i < numberIterations; i++)
            {
                PrintIteration(grid);
                Console.WriteLine("----------------------------");
                grid.NextIteration();
            }

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
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
