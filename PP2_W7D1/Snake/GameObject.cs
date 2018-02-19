using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    public abstract class GameObject
    {
        public List<Point> body { get; set; }
        public char sign { get; set; }
        public ConsoleColor color { get; set; }

        public GameObject()
        {
        }

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
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
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
        public void Save()
        {
            Type t = this.GetType();
            string fname = t.Name + ".xml";

            using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(t);
                xs.Serialize(fs, this);
            }
        }

        public GameObject Load()
        {
            GameObject res = null;
            Type t = this.GetType();
            string fname = t.Name + ".xml";

            using (FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(t);
                res = xs.Deserialize(fs) as GameObject;
            }

            return res;
        }
    }
}
