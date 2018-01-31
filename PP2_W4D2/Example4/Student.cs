using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
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
}
