using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcWindowsFormsApplication
{
    public partial class Form1 : Form
    {
        Brain brain = new Brain();
        public Form1()
        {
            InitializeComponent();
            brain.invoker = ShowInfo;
        }
        public void ShowInfo(string msg)
        {
            textBox1.Text = msg;
        }
        public void BtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            brain.Process(btn.Text);
        }
    }
}
