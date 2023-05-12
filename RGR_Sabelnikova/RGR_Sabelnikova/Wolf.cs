using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR_Sabelnikova
{
    internal class Wolf
    {
        private float score;
        private int x;
        private int y;

        public Wolf( int x, int y, float Score)
        {
            this.score = 0;
            this.x = x;
            this.y = y;
        }

        public void Move(int maxX, int maxY)
        {
            Random random = new Random();
            int newX = x + random.Next(-1, 2);
            int newY = y + random.Next(-1, 2);

            // Check if new position is within the bounds of the grid
            if (newX >= 0 && newX < maxX && newY >= 0 && newY < maxY)
            {
                x = newX;
                y = newY;
            }
        }

        public bool Hunt(Rabbit rabbit)
        {
            
            // Check if rabbit is adjacent to the wolf
            if (Math.Abs(rabbit.x - x) <= 1 && Math.Abs(rabbit.y - y) <= 1)
            {
                // Wolf eats rabbit and gains a point
                score++;
                //rabbit.Eaten = true;
                return true;
            }
            else
            {
                // Wolf loses 0.1 points for not finding rabbit
                score -= 0.1f;
                return false;
            }
        }

        public float Score
        {
            get { return score; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public bool IsAlive
        {
            get { return score >= 0; }
        }
    }
}
