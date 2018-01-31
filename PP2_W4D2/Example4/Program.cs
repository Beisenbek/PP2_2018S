using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("ABC",2);
            University u = new University("KBTU", s);
            Console.WriteLine(u);
            u.Save();

            University u2 = University.Load();
            Console.WriteLine(u2);
        }
    }
}
