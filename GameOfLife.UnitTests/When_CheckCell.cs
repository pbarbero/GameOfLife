using System;
using Xunit;
using GameOfLife;

namespace GameOfLife.UnitTests
{
    public class When_CheckCell
    {
        private Grid Grid { get; set; }

        public When_CheckCell()
        {
            Grid = new Grid(2,2);
            Grid.Create();
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
