using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Worm
    {
        public Worm(Point head, char sign, ConsoleColor color)
        {
            this.body = new List<Point>();
            this.body.Add(head);
            this.sign = sign;
            this.color = color;
        }

        public List<Point> body { get; set; }
        public char sign { get;}
        public ConsoleColor color { get;}
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }

        public void Move(int dx, int dy)
        {
            body[0].X = body[0].X + dx;
            body[0].Y = body[0].Y + dy;
        }
    }
}
