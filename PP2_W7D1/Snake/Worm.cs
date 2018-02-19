using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Worm:GameObject
    {
        public Worm(Point firstPoint, ConsoleColor color, char sign):base(firstPoint,color,sign)
        {

        }

        public Worm() { }
        public void Move(int dx, int dy)
        {
            Point newHeadPos = new Point { X = body[0].X + dx, Y = body[0].Y + dy };

            for(int i = body.Count -1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0] = newHeadPos;
        }
    }
}
