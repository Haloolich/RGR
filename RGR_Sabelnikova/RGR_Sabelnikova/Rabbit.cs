using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR_Sabelnikova
{
    internal class Rabbit
    {
        public int x;  // координата x
        public int y;  // координата y

        public Rabbit(int startX, int startY)
        {
            x = startX;
            y = startY;
        }

        public void Move(Random random)
        {
            // генеруємо випадкове число від 0 до 8 (включно)
            int direction = random.Next(9);

            // змінюємо координати кролика в залежності від напрямку руху
            switch (direction)
            {
                case 0: x--; y--; break;
                case 1: y--; break;
                case 2: x++; y--; break;
                case 3: x--; break;
                case 4: /* нерухомо */ break;
                case 5: x++; break;
                case 6: x--; y++; break;
                case 7: y++; break;
                case 8: x++; y++; break;
            }
        }

        public void Reproduce(Random random)
        {
            if (random.NextDouble() <= 0.2)  // з ймовірністю 0.2
            {
                // створюємо нового кролика
                Rabbit newRabbit = new Rabbit(x, y);
                // ...
            }
        }

        // додайте інші методи та властивості, які необхідні для вашої програми
        // ...
    }
}
