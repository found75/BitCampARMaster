using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        bool DrawingPen = false, DrawClear = false, DrawingErj = false;
        Point LasPos = new Point(0, 0);
        System.Drawing.SolidBrush brushPen = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        System.Drawing.SolidBrush brusherr = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        List<MouseMove> mousemovelist = new List<MouseMove>();
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DrawingPen = true;
            DrawingErj = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DrawingPen = false;
            DrawingErj = true;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
       
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            PenMouseMove(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownPen(e);
        }

        private void MouseDownPen(MouseEventArgs e)
        {
            if (DrawingPen == true)
            {
                LasPos = e.Location;
            }
            if (DrawingErj == true)
            {
                LasPos = e.Location;
            }
        }

        private void PenMouseMove(MouseEventArgs e)
        {
            if (DrawingPen == true)
            {
                if ((e.Button & System.Windows.Forms.MouseButtons.Left) == System.Windows.Forms.MouseButtons.Left)
                {
                    using (System.Drawing.Graphics oGraphics = this.CreateGraphics())
                    {
                        if (LasPos != new Point(0, 0))
                        {
                            oGraphics.DrawLine(new Pen(Color.Black), e.X, e.Y, LasPos.X, LasPos.Y);
                        }
                        oGraphics.FillEllipse(brushPen, e.X, e.Y, 1, 1);
                        LasPos = e.Location;
                    }
                }
            }
            if (DrawingErj == true)
            {
                if ((e.Button & System.Windows.Forms.MouseButtons.Left) == System.Windows.Forms.MouseButtons.Left)
                {
                    using (System.Drawing.Graphics oGraphics = this.CreateGraphics())
                    {
                        if (LasPos != new Point(0, 0))
                        {
                            oGraphics.DrawLine(new Pen(Color.White), e.X, e.Y, LasPos.X, LasPos.Y);
                        }
                        oGraphics.FillEllipse(brusherr, e.X, e.Y, 100, 100);
                        LasPos = e.Location;
                    }
                }
            }

        }

    }
}
