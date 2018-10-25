using System;
using Xunit;
using GameOfLife;

namespace GameOfLife.UnitTests
{
    public class When_CreateGrid
    {
        [Fact]
        public void When_CreateGrid_Then_GridIsCreated()
        {
            var grid = new Grid(2, 2);
            grid.Create();

            Assert.True(2 == grid.Height);
            Assert.True(2 == grid.Width);
            Assert.True(4 == grid.Cells.Count);
        }
    }
}
