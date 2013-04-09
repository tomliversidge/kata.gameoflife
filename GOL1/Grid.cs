namespace GOL1
{
    using System.Collections.Generic;
    using System.Linq;

    public class Grid
    {
        private HashSet<Cell> liveCells;

        public Grid(params Cell[] cells)
        {
            this.liveCells = new HashSet<Cell>(cells);
        }

        public void Evolve()
        {
            // get the surviving cells based on the first 3 rules
            var cellsThatSurvive = liveCells.Where(cell => this.GetLiveAdjacentCells(cell).Count() == 2 || this.GetLiveAdjacentCells(cell).Count() == 3);

            // get the cells to revive based on the 4th rule
            var cellsThatRevive = liveCells.SelectMany(GetDeadAdjacentCells).Where(cell => GetLiveAdjacentCells(cell).Count() == 3);

            // join the two collections together and set the cells
            liveCells = new HashSet<Cell>(cellsThatSurvive.Union(cellsThatRevive));
        }
        
        private IEnumerable<Cell> GetAdjacentCells(Cell cell)
        {
            // for the passed in cell, find the adjacent cells by their co-ordinates
            // excluding the current cell 
            var adjacentCells = new int[]{-1,0,1};
            return from x in adjacentCells 
                   from y in adjacentCells 
                   where !(IsCurrentCell(x, y)) 
                   select new Cell(cell.X + x, cell.Y + y);
        }

        private static bool IsCurrentCell(int x, int y)
        {
            return x == 0 && y == 0;
        }

        public bool IsAlive(Cell coordinate)
        {
            return this.liveCells.Contains(coordinate);
        }

        private IEnumerable<Cell> GetLiveAdjacentCells(Cell cell)
        {
            return GetAdjacentCells(cell).Where(IsAlive);
        }

        private IEnumerable<Cell> GetDeadAdjacentCells(Cell cell)
        {
            return GetAdjacentCells(cell).Where(c => !IsAlive(c));
        }
    }
}