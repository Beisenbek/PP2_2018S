using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    public partial class Form1 : Form
    {
        Point firstPoint = default(Point);
        Point secondPoint = default(Point);
        Bitmap bmp = default(Bitmap);
        Graphics gfx = default(Graphics);
        Pen pen = new Pen(Color.Black, 1);

        Tools activeTool = Tools.Pen;

        public Form1()
        {
            InitializeComponent();

            SetupPictureBox(BmpCreationMode.Init, "");
         
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void SetupPictureBox(BmpCreationMode mode, string fileName)
        {

            if (mode == BmpCreationMode.Init)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }else if(mode == BmpCreationMode.FromFile)
            {
                bmp = new Bitmap(Bitmap.FromFile(openFileDialog1.FileName));
            }

            gfx = Graphics.FromImage(bmp);

            if (mode == BmpCreationMode.Init)
            {
                gfx.Clear(Color.White);
            }

            pictureBox1.Image = bmp;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            if(activeTool == Tools.Fill)
            {
                //DFloodFill fill = new DFloodFill(pictureBox1, bmp.GetPixel(e.X, e.Y), pen.Color, firstPoint, bmp);
                //fill.Fill();

                MapFill mf = new MapFill();
                mf.Fill(gfx, firstPoint, pen.Color,ref bmp);
                SetupPictureBox(BmpCreationMode.AfterFill, "");
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;

                switch (activeTool)
                {
                    case Tools.Pen:
                        gfx.DrawLine(pen, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;
                    case Tools.Fill:
                        break;
                    case Tools.Rectangle:
                        break;
                    case Tools.Circle:
                        break;
                    case Tools.Triangle:
                        break;
                    case Tools.Line:
                       
                        break;
                    default:
                        break;
                }

                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Pen;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = float.Parse(numericUpDown1.Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Line;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Rectangle;

        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Circle;

        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Triangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activeTool = Tools.Fill;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            

            switch (activeTool)
            {
                case Tools.Pen:
                    break;
                case Tools.Fill:
                    break;
                case Tools.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Circle:
                    e.Graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Triangle:
                    break;
                case Tools.Line:
                    e.Graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
                default:
                    break;
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (activeTool)
            {
                case Tools.Pen:
                    break;
                case Tools.Fill:
                    break;
                case Tools.Rectangle:
                    gfx.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Circle:
                    gfx.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Triangle:
                    break;
                case Tools.Line:
                    gfx.DrawLine(pen, firstPoint, secondPoint);
                    break;
                default:
                    break;
            }
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            Rectangle rec = new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            return rec;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SetupPictureBox(BmpCreationMode.FromFile, openFileDialog1.FileName);
            }
        }
    }

    enum Tools
    {
        Pen,
        Fill,
        Rectangle,
        Circle,
        Triangle,
        Line
    }

    enum BmpCreationMode
    {
        AfterFill,
        FromFile,
        Init
    }
}
