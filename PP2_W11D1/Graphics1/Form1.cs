using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics1
{
    public partial class Form1 : Form
    {
        Point firstPoint = default(Point);
        Point secondPoint = default(Point);
        Graphics gfx = default(Graphics);
        Pen pen = new Pen(Color.Red, 3);

        public Form1()
        {
            InitializeComponent();
            gfx = Graphics.FromHwnd(this.Handle);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            //pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawLine(pen,firstPoint, secondPoint);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            secondPoint = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;
                gfx.DrawLine(pen, firstPoint, secondPoint);

                RectangleF r = new RectangleF(secondPoint.X - pen.Width / 2, secondPoint.Y - pen.Width / 2, pen.Width, pen.Width);
                gfx.FillEllipse(pen.Brush, r);

                firstPoint = secondPoint;
            }
        }

        private void palleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }
    }
}
