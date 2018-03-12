using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsoleApp
{
    delegate void MyDelegate(string msg);

    class Brain
    {
        public MyDelegate invoker;
        public void Process(string operation)
        {
            invoker.Invoke(operation + "_" + operation);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Brain brain = new Brain();
            brain.invoker = ShowInfo;

            while (true)
            {
                ConsoleKeyInfo pressedKeyInfo = Console.ReadKey();
                brain.Process(pressedKeyInfo.Key.ToString());
            }
        }

        static void ShowInfo(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
