using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    class DFloodFill
    {
        Color originColor;
        Color fillColor;
        Bitmap bmp;
        Queue<Point> q = new Queue<Point>();
        PictureBox pb;

        public DFloodFill(PictureBox pb, Color originColor, Color fillColor, Point originPoint, Bitmap bmp)
        {
            this.pb = pb;
            this.originColor = originColor;
            this.fillColor = fillColor;
            this.bmp = bmp;

            q.Enqueue(originPoint);
        }

        public void Step(int x, int y)
        {
            if (x < 0 || y < 0) return;
            if (x >= bmp.Width || y >= bmp.Height) return;
            if (bmp.GetPixel(x, y) != originColor) return;
            q.Enqueue(new Point(x, y));
        }

        public void Fill()
        {
            while(q.Count != 0)
            {
                Point curPoint = q.Dequeue();
                bmp.SetPixel(curPoint.X, curPoint.Y, fillColor);
                pb.Refresh();
                Step(curPoint.X - 1, curPoint.Y);
                Step(curPoint.X + 1, curPoint.Y);
                Step(curPoint.X, curPoint.Y - 1);
                Step(curPoint.X, curPoint.Y + 1);
            }
        }
    }
}
