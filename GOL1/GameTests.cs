using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL1
{
    using NUnit.Framework;

    [TestFixture]
    public class GameTests
    {
        /// <summary>
        /// Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        /// Any live cell with two or three live neighbours lives on to the next generation.
        /// Any live cell with more than three live neighbours dies, as if by overcrowding.
        /// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        /// </summary>

        [Test]
        public void TestUnderPopulation_Death()
        {
            // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
            var game = new Game(new Cell(1,1), new Cell(0,0));
            var evolvedGame = game.Evolve();
            Assert.IsFalse(evolvedGame.IsAlive(new Cell(1, 1)));
        }

        [Test]
        public void TestUnderPopulation_Life()
        {
            // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
            var game = new Game(new Cell(0, 0), new Cell(0, 1), new Cell(1, 0), new Cell(1,1));
            var evolvedGame = game.Evolve();
            Assert.IsTrue(evolvedGame.IsAlive(new Cell(1, 1)));
        }
    }
}
