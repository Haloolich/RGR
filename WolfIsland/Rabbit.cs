using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
    public class Rabbit
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Rabbit(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
    }
}
