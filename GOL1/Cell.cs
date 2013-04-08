using System;
using System.Text;
using System.Threading.Tasks;

namespace GOL1
{
    public struct Cell : IEquatable<Cell>
    {
        private readonly int x;

        private readonly int y;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Y {
            get
            {
                return y;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public bool Equals(Cell other)
        {
            return this.X == other.x && this.Y == other.y;
        }
    }
}
