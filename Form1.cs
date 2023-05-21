using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float R = 200;
            DateTime dt = DateTime.Now;
            int w = this.Width;
            int h = this.Height;
            Pen cir_pen = new Pen(Color.Black, 4);
            Brush brush = new SolidBrush(Color.Indigo);
            Graphics g = e.Graphics;
            GraphicsState gs;
            g.TranslateTransform(w / 2, h / 2);
            //g.ScaleTransform(w / 1000, h / 1000);
            g.DrawEllipse(cir_pen, -R, -R, 2*R, 2*R);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(new Rectangle((int)-R, (int)-R, (int)(2 * R), (int)(2 * R)), Color.Gray, Color.Sienna, LinearGradientMode.Horizontal);
            g.FillEllipse(gradientBrush, -R, -R, 2 * R, 2 * R);
            for (int i = 0; i < 12; i++)
            {
                float a = (float)(R * Math.Cos(i * Math.PI / 6));
                float b = (float)(-R * Math.Sin(i * Math.PI / 6));
                float c = (float)(0.9 * R * Math.Cos(i * Math.PI / 6));
                float d = (float)(-0.9 * R * Math.Sin(i * Math.PI / 6));
                g.DrawLine(cir_pen, a, b, c, d);
                switch (i)
                {
                    case 0:
                        g.DrawString("3", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-15, d-10));
                        break;
                    case 1:
                        g.DrawString("2", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-15, d));
                        break;
                    case 2:
                        g.DrawString("1", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-15, d));
                        break;
                    case 3:
                        g.DrawString("12", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-14, d));
                        break;
                    case 4:
                        g.DrawString("11", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c, d));
                        break;
                    case 5:
                        g.DrawString("10", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c, d));
                        break;
                    case 6:
                        g.DrawString("9", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c, d));
                        break;
                    case 7:
                        g.DrawString("8", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-5, d-20));
                        break;
                    case 8:
                        g.DrawString("7", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-5, d-20));
                        break;
                    case 9:
                        g.DrawString("6", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-8, d-20));
                        break;
                    case 10:
                        g.DrawString("5", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-15, d-15));
                        break;
                    case 11:
                        g.DrawString("4", new Font("Arial", 14, FontStyle.Regular), brush, new PointF(c-15, d-15));
                        break;
                }
            }
            gs = g.Save();
            Pen p_s = new Pen(Color.Aqua, 4);
            p_s.CustomEndCap = new AdjustableArrowCap(3, 7);
            g.RotateTransform(6*dt.Second);
            g.DrawLine(p_s, 0, 0, 0, (float)-0.8 * R);
            g.Restore(gs);
            g.RotateTransform(6 * (dt.Minute+(float)dt.Second/60));
            g.DrawLine(new Pen(new SolidBrush(Color.BlueViolet), 4), 0, 0, 0, (float)-0.8 * R);
            g.Restore(gs);
            g.RotateTransform(30 * dt.Hour + (float)dt.Minute / 2+(float)dt.Second/120);
            g.DrawLine(new Pen(new SolidBrush(Color.OrangeRed), 4), 0, 0, 0, (float)-0.8 * R);
            g.Restore(gs);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
