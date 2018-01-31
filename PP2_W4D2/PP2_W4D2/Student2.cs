using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2_W4D2
{
    class Student2
    {
        private double gpa;
        public double GPA {
            get {
                return this.gpa;
            }
            set
            {
                if (value <= 4)
                {
                    this.gpa = value;
                }
            }
        }
    }
}
