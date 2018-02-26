using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    public class Worm:GameObject
    {
        public bool IsAlive { get; set; }
        public int DX { get; set; }
        public int DY { get; set; }
        public bool IsPaused { get; set; }
        public Worm(Point firstPoint, ConsoleColor color, char sign):base(firstPoint,color,sign)
        {
            IsAlive = true;
        }

        public void Move()
        {
            Point newHeadPos = new Point { X = body[0].X + DX, Y = body[0].Y + DY };

            for(int i = body.Count -1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0] = newHeadPos;
        }

        

    }
}
