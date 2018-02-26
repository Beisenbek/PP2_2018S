using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class GameObject
    {
        public List<Point> body { get;}
        public char sign { get; }
        public ConsoleColor color { get; }

        public GameObject(Point firstPoint, ConsoleColor color, char sign)
        {
            this.body = new List<Point>();
            if (firstPoint != null)
            {
                this.body.Add(firstPoint);
            }
            this.color = color;
            this.sign = sign;
        }
        public void Clear()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
    }
}
