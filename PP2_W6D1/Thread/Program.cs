using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Hi!");*/

            ThreadStart ts = new ThreadStart(DoIt);
            System.Threading.Thread t = new System.Threading.Thread(ts);
            t.Start();

            ThreadStart ts2 = new ThreadStart(DoIt2);
            System.Threading.Thread t2 = new System.Threading.Thread(ts2);
            t2.Start();

            //DoIt();
        }

        private static void DoIt()
        {
            while (true)
            {
                Console.WriteLine("Hello world!");
                System.Threading.Thread.Sleep(1000);
            }
            //Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        private static void DoIt2()
        {
            while (true)
            {
                Console.WriteLine("Hi!");
                System.Threading.Thread.Sleep(2000);
            }
            //Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }
}
