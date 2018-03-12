using CalcWindowsFormsApplication2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsoleApplication2
{
    class Program
    {
        static Brain brain = new Brain();

        static void Main(string[] args)
        {
            brain.invoker = ShowInfo;

            while (true)
            {
                ConsoleKeyInfo pk = Console.ReadKey(true);
                string k = pk.KeyChar.ToString();
                brain.Process(k);
            }
        }

        public static void ShowInfo(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
        }
    }
}
