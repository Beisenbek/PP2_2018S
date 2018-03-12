using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegates4
{
    delegate void MyDelegate(string msg);

    public partial class Form1 : Form
    {
        Uploader u;

        public Form1()
        {
            InitializeComponent();

            Informer5 i = new Informer5();
            MyDelegate md = i.ShowMySuperMessage;

            u = new Uploader(md);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            u.Upload();
        }
    }

    class Informer5
    {
        public void ShowMySuperMessage(string msg)
        {
            MessageBox.Show(msg);
        }
    }

    class Uploader
    {
        MyDelegate informer;
        public Uploader(MyDelegate informer)
        {
            this.informer = informer;
        }
        public void Upload()
        {
            Thread.Sleep(2000);
            informer.Invoke("done!");
        }

    }
}
