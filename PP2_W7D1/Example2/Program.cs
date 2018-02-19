using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread tr = null;

            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();

                switch (pressedButton.Key)
                {
                    case ConsoleKey.Spacebar:
                        tr.Abort();
                        break;
                    case ConsoleKey.Enter:
                        tr = new Thread(new ThreadStart(DoIt));
                        tr.Start();
                        break;
                }
            }
            
        }

        static void DoIt()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now.Ticks);
                Thread.Sleep(2000);
            }
        }
    }
}
