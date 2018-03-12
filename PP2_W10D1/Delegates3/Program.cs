using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates3
{
    delegate void MyDelegate(string msg);
     
    abstract class Inform
    {
        public abstract void ShowInfo(string msg);
    }

    class Informer : Inform
    {
        public override void ShowInfo(string msg)
        {
            Console.WriteLine("##########");
            Console.WriteLine(msg);
        }
    }


    class Informer2 : Inform
    {
        public override void ShowInfo(string msg)
        {
            Console.WriteLine("=========");
            Console.WriteLine(msg);
        }
    }

    class Informer3 : Inform
    {
        public override void ShowInfo(string msg)
        {
            Console.WriteLine("++++++++++");
            Console.WriteLine(msg);
        }
    }

    class Uploader
    {
        MyDelegate informer;
        public Uploader(MyDelegate informer)
        {
            this.informer = informer;
        }
        public void Upload()
        {
            Thread.Sleep(2000);
            informer.Invoke("done!");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Informer informer = new Informer();
            Informer2 informer2 = new Informer2();
            Informer3 informer3 = new Informer3();

            MyDelegate md = informer.ShowInfo;
            md += informer2.ShowInfo;
            md += informer3.ShowInfo;



            Uploader u = new Uploader(md);
            u.Upload();
        }
    }
}
