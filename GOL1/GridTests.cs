using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL1
{
    using NUnit.Framework;

    [TestFixture]
    public class GridTests
    {
        /// <summary>
        /// Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        /// Any live cell with two or three live neighbours lives on to the next generation.
        /// Any live cell with more than three live neighbours dies, as if by overcrowding.
        /// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        /// </summary>

        [Test]
        public void CellDiesWithNoNeighbours()
        {
            // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
            var grid = new Grid(new Cell(1,1));
            grid.Evolve();
            Assert.IsFalse(grid.IsAlive(new Cell(1, 1)));
        }

        [Test]
        public void CellDiesWithOneNeighbour()
        {
            // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
            var grid = new Grid(new Cell(0, 0), new Cell(0, 1));
            grid.Evolve();
            Assert.IsFalse(grid.IsAlive(new Cell(0, 0)));
        }

        [Test]
        public void CellLivesWithTwoNeighbours()
        {
            // Any live cell with two or three live neighbours lives on to the next generation.
            var grid = new Grid(new Cell(0, 0), new Cell(0, 1), new Cell(1, 0));
            grid.Evolve();
            Assert.IsTrue(grid.IsAlive(new Cell(0, 0))); // cell had two neighbours, should survive
        }

        [Test]
        public void CellLivesWithThreeNeighbours()
        {
            // Any live cell with two or three live neighbours lives on to the next generation.
            var grid = new Grid(new Cell(0, 0), new Cell(0, 1), new Cell(1, 0), new Cell(1, 1));
            grid.Evolve();
            Assert.IsTrue(grid.IsAlive(new Cell(0, 0))); // cell had three neighbours, should survive
        }

        [Test]
        public void CellDiesWithFourNeighbours()
        {
            // Any live cell with more than three live neighbours dies, as if by overcrowding.
            var grid = new Grid(new Cell(1, 1), new Cell(0, 1), new Cell(1, 0), new Cell(2, 1), new Cell(1,2));
            grid.Evolve();
            Assert.IsFalse(grid.IsAlive(new Cell(1, 1))); // cell had four neighbours, should die
        }

        [Test]
        public void CellDiesWithFiveNeighbours()
        {
            // Any live cell with more than three live neighbours dies, as if by overcrowding.
            var grid = new Grid(new Cell(1, 1), new Cell(0, 1), new Cell(1, 0), new Cell(2, 1), new Cell(1, 2), new Cell(0,0));
            grid.Evolve();
            Assert.IsFalse(grid.IsAlive(new Cell(1, 1))); // cell had four neighbours, should die
        }

        [Test]
        public void CellDoesNotReviveWithTwoLiveNeighbours()
        {
            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            var grid = new Grid(new Cell(0, 0), new Cell(0, 1));
            grid.Evolve();
            Assert.IsFalse(grid.IsAlive(new Cell(1, 1)));
        }

        [Test]
        public void CellRevivesWithThreeLiveNeighbours()
        {
            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            var grid = new Grid(new Cell(0, 0), new Cell(0, 1), new Cell(1, 0));
            grid.Evolve();
            Assert.IsTrue(grid.IsAlive(new Cell(1, 1)));
        } 
        
        [Test]
        public void CellDoesNotReviveWithFourLiveNeighbours()
        {
            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            var grid = new Grid(new Cell(0, 0), new Cell(0, 1), new Cell(1, 0), new Cell(2,1));
            grid.Evolve();
            Assert.IsFalse(grid.IsAlive(new Cell(1, 1)));
        }
    }
}
