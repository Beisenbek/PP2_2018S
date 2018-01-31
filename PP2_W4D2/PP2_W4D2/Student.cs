using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2_W4D2
{
    class Student
    {
        private double gpa;

        public void SetGPA(double gpa)
        {
            if (gpa <= 4)
            {
                this.gpa = gpa;
            }
        }

        public string GetGPA(string user)
        {
            if (user == "admin")
            {
                return this.gpa.ToString();
            }else
            {
                return "permission denied!";
            }
        }
    }
}
