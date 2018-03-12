using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates2
{
    abstract class Inform
    {
        public abstract void ShowInfo(string msg);
    }

    class Informer:Inform
    {
        public override void ShowInfo(string msg)
        {
            Console.Clear();
            Console.WriteLine("##########");
            Console.WriteLine(msg);
        }
    }


    class Informer2 : Inform
    {
        public override void ShowInfo(string msg)
        {
            Console.Clear();
            Console.WriteLine("=========");
            Console.WriteLine(msg);
        }
    }

    class Uploader
    {
        Inform informer;
        public Uploader(Inform informer)
        {
            this.informer = informer;
        }
        public void Upload()
        {
            Thread.Sleep(2000);
            informer.ShowInfo("done!");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Uploader u = new Uploader(new Informer());
            u.Upload();
        }
    }
}
