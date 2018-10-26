using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Library
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
        public Grid Grid { get; set; }

        public Cell(int x, int y, Grid grid)
        {
            X = x;
            Y = y;
            Grid = grid;
            IsAlive = false;
        }

        public void UpdateCellStatus()
        {
            IsAlive = WillBeAlive();
        }

        public bool WillBeAlive()
        {
            var neighbors = GetNeighbors();
            var alivedNeighBors = neighbors.Where(cell => cell.IsAlive).Count();
            var deadNeighbors = neighbors.Where(cell => !cell.IsAlive).Count();

            if (IsAlive)
            {
                return alivedNeighBors == 2 || alivedNeighBors == 3;
            }
            else
            {
                return alivedNeighBors == 3;
            }
        }

        public List<Cell> GetNeighbors()
        {
            return Grid.Cells.Where(cell => !(cell.X == X && cell.Y == Y)
                                   && (X-1 <= cell.X 
                                   && cell.X <= X+1
                                   && Y-1 <= cell.Y
                                   && cell.Y <= Y+1)
                                   ).ToList();
        }
    }
}
