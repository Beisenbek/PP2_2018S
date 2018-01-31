using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2_W4D2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.SetGPA(2.4);
            Console.WriteLine(s.GetGPA("admin"));
            s.SetGPA(5);
            Console.WriteLine(s.GetGPA("student"));

            Student2 s2 = new Student2();
            s2.GPA = 4;
            Console.WriteLine(s2.GPA);

            Student3 s3 = new Student3();
            s3.GPA = 3;
            Console.WriteLine(s3.GPA);
        }
    }
}
