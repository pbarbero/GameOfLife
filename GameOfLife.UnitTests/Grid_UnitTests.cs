using GameOfLife.Library;
using System.Linq;
using Xunit;

namespace GameOfLife.UnitTests
{
    public class Grid_UnitTests
    {
        private Grid Grid { get; set; }

        public Grid_UnitTests()
        {
            Grid = new Grid(4, 4);
        }

        [Fact]
        public void When_CreateGrid_Then_GridIsCreated()
        {
            Assert.True(4 == Grid.Height);
            Assert.True(4 == Grid.Width);
            Assert.True(16 == Grid.Cells.Count);
        }

        [Fact(Skip = "not implemented")]
        public void When_SetSeed_Then_SeedIsSeted()
        {
            Grid.SetRandomSeed(4,4);

            Assert.True(7 >= Grid.Cells.Where(cell => cell.IsAlive).Count());
        }
    }
}
