using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWindowsFormsApplication
{
    delegate void MyDelegate(string msg);

    class Brain
    {
        public MyDelegate invoker;
        public void Process(string operation)
        {
            invoker.Invoke(operation + "_" + operation);
        }
    }
}
