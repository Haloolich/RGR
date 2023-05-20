using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
    internal class SheWolf
    {
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Saturation { get; set; }

            public SheWolf(int x, int y, int saturation)
            {
                X = x;
                Y = y;
                Saturation = saturation;
            }

            public void Move(int x, int y)
            {
                X = x;
                Y = y;   
            }

        public bool IsHungry(int saturation)
        {
            Saturation = saturation;
            return Saturation <= 0; // Changed to '<' to correctly indicate when the wolf is hungry
        }

        public int Eat()
        {
            Saturation = 10;
            return Saturation;
        }

        public int ReduceSaturation(int saturation)
        {
            Saturation = saturation - 1;
            return Saturation;
        }
    }
}
