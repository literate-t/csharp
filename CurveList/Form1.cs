using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace CurveList {
    public partial class Form1 : Form {
        private int x, y;
        private ArrayList ar;
        

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            x = e.X;
            y = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if(Capture && MouseButtons.Left == e.Button) {
                Graphics G = CreateGraphics();
                //Rectangle R = new Rectangle();
                G.DrawLine(Pens.Black, x, y, e.X, e.Y);
                //R.X = x;
                //R.Y = y;
                //R.Width = e.X;
                //R.Height = e.Y;
                
                ar.Add(Rectangle.FromLTRB(x, y, e.X, e.Y));

                x = e.X;
                y = e.Y;
                G.Dispose();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            foreach(Rectangle r in ar)
                e.Graphics.DrawLine(Pens.Black, r.Left, r.Top, r.Right, r.Bottom);
        }

        public Form1() {
            ar = new ArrayList();            
            InitializeComponent();
        }
    }
}
