using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegates
{
    public delegate void MyDelegate();

    public partial class Form1 : Form
    {
        MyDelegate delegateInstance;

        public Form1()
        {
            InitializeComponent();
            delegateInstance = DoIt2;
            delegateInstance += DoIt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delegateInstance.Invoke();
        }

        private void DoIt()
        {
            MessageBox.Show("hello world!");
        }

        private void DoIt2()
        {
            MessageBox.Show("hello world2");
        }
    }
}
