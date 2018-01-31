using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    [Serializable]
    public class Student
    {
        public Student(string name, double gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }
        private string name;
        public double gpa;
        public string GetInfo()
        {
            return gpa + " " + name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F1();
            F2();  
        }

        private static void F2()
        {
            FileStream fs = new FileStream("student.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Student s = bf.Deserialize(fs) as Student;
            Console.WriteLine(s.GetInfo());
            fs.Close();
        }

        private static void F1()
        {
            FileStream fs = new FileStream("student.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Student s = new Student("ABC",2);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, s);

            fs.Close();
        }
    }
}
