using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Timer2
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Elapsed += DoIt;
            t.Start();

            Timer t2 = new Timer();
            t2.Interval = 2000;
            t2.Elapsed += DoIt2;
            t2.Start();

            while (true)
            {

            }

            t.Stop();
        }

        private static void DoIt(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("ok");

        }

        private static void DoIt2(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("ok2");
        }
    }
}
