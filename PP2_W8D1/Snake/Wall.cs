using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Wall:GameObject
    {
        public Wall(Point firstPoint, ConsoleColor color, char sign):base(firstPoint,color,sign)
        {

        }

        public void LoadLevel(GameLevel level)
        {
            string fname = "";

            switch (level)
            {
                case GameLevel.First:
                    fname = @"Levels\Level1.txt";
                    break;
                case GameLevel.Second:
                    break;
                case GameLevel.Bonus:
                    break;
                default:
                    break;
            }

            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int y = 0;

            while ((line = sr.ReadLine()) != null)
            {
                for(int x = 0; x < line.Length; ++x)
                {
                    if(line[x] == '#')
                    {
                        this.body.Add(new Point { X = x, Y = y });
                    }
                }
                y++;
            }

            sr.Close();
            fs.Close();
        }
    }
}
