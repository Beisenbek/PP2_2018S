using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    abstract class GameObject
    {
        public void Save()
        {
            File.Create(this.GetType().Name + ".xml");
        }
    }
    class Worm:GameObject
    {

    }

    class Food:GameObject
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Worm w = new Worm();
            Food f = new Food();
            w.Save();
            f.Save();
        }
    }
}
