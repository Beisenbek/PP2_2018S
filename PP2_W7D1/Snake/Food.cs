using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food:GameObject
    {
        public Food(Point firstPoint, ConsoleColor color, char sign):base(firstPoint,color,sign)
        {

        }

        public Food() { }
    }
}
