using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2_W3D1
{
    class FAR
    {
        public FAR(string path)
        {
            this.activeLayer = new Layer(path, 0);
        }
        Stack<Layer> layerHistory = new Stack<Layer>();
        Layer activeLayer;
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            DirectoryInfo dirInfo = new DirectoryInfo(activeLayer.path);
            DirectoryInfo[] x = dirInfo.GetDirectories();

            for (int i = 0; i < x.Length; ++i)
            {
                if (i == activeLayer.index)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine(x[i].Name);
            }
        }
        public void Process(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    activeLayer.Process(-1);
                    break;
                case ConsoleKey.DownArrow:
                    activeLayer.Process(1);
                    break;
                case ConsoleKey.Enter:
                    layerHistory.Push(activeLayer);
                    activeLayer = new Layer(activeLayer.GetSelectedDirInfo(), 0);
                    break;
                case ConsoleKey.Backspace:
                    activeLayer = layerHistory.Pop();
                    break;
                default:
                    break;
            }

        }
    }
}
