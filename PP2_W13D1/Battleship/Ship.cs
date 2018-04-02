using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum ShipType
    {
        D1,
        D2,
        D3,
        D4
    }
    class Ship
    {
        public List<Point> body = new List<Point>();
        ShipType type;

        public Ship(Point p, ShipType type)
        {
            this.type = type;
            GenerateBody(p);
        }

        public void GenerateBody(Point p)
        {
            switch (type)
            {
                case ShipType.D1:
                    body.Add(new Point(p.X,p.Y));
                    break;
                case ShipType.D2:
                    body.Add(new Point(p.X, p.Y));
                    body.Add(new Point(p.X + 1, p.Y));
                    break;
                case ShipType.D3:
                    body.Add(new Point(p.X, p.Y));
                    body.Add(new Point(p.X + 1, p.Y));
                    body.Add(new Point(p.X + 2, p.Y));
                    break;
                case ShipType.D4:
                    body.Add(new Point(p.X, p.Y));
                    body.Add(new Point(p.X + 1, p.Y));
                    body.Add(new Point(p.X + 2, p.Y));
                    body.Add(new Point(p.X + 3, p.Y));
                    break;
                default:
                    break;
            }

        }
    }
}
