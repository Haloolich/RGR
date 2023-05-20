using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
    public class Wolf
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Saturation { get; set; } // Changed the 'Saturation' property to allow modification

        public Wolf(int x, int y, int saturation)
        {
            X = x;
            Y = y;
            Saturation = saturation;
        }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
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

        public int Sex()
        {
            Saturation = 5;
            return Saturation;
        }
    }
}