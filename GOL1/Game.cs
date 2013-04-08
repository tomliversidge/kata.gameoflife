namespace GOL1
{
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private readonly List<Cell> cells;

        public Game(params Cell[] cells)
        {
            this.cells = new List<Cell>(cells);
        }

        public Game Evolve()
        {
            var nextGeneration = cells.Where(a => this.GetAdjacentLiveCells(a) == 2 || this.GetAdjacentLiveCells(a) == 3);
            return new Game(nextGeneration.ToArray());
        }

        private decimal GetAdjacentLiveCells(Cell cell)
        {
            int adjacentLiveCells = 0;
            var adjacentHorizontalRange = Enumerable.Range(-1, 3);
            foreach (var x in adjacentHorizontalRange)
            {
                var adjacentVerticalRange = Enumerable.Range(-1, 3);
                foreach (var y in adjacentVerticalRange)
                {
                    adjacentLiveCells += cells.Where(a => !a.Equals(cell)).Count(a => a.X == cell.X + x && a.Y == cell.Y + y);
                }
            }
            return adjacentLiveCells;
        }

        public bool IsAlive(Cell coordinate)
        {
            return this.cells.Contains(coordinate);
        }
    }
}