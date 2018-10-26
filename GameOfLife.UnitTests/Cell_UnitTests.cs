using GameOfLife.Library;
using Xunit;

namespace GameOfLife.UnitTests
{
    public class Cell_UnitTests
    {
        private Grid Grid { get; set; }

        public Cell_UnitTests()
        {
            Grid = new Grid(2,2);
        }

        [Fact]
        public void When_Cell_HasFewer2Neighbors_Then_Dies()
        {
            var cell = Grid.GetCell(0,0);
            var willBeAlive = cell.WillBeAlive();

            Assert.False(willBeAlive);
        }
    }
}
