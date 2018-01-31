using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    [Serializable]
    public class University
    {
        Student s;
        string name;
        public University(string name, Student s)
        {
            this.name = name;
            this.s = s;
        }

        public override string ToString()
        {
            return s.GetInfo() + " " + name;
        }

        public void Save()
        {
            using (FileStream fs = new FileStream("student.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this);
            }
        }

        public static University Load()
        {
            University res;
            using (FileStream fs = new FileStream("student.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                res = bf.Deserialize(fs) as University;
            }
            return res;
        }
    }
}
