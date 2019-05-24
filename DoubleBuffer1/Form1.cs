using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleBuffer1 {
    public partial class Form1 : Form {
        int ex = 10, ey = 100;
        const int r = 15;        

        public Form1() {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            for(int x = 0; x < ClientRectangle.Right; x+=10) {
                e.Graphics.DrawLine(Pens.Black, x, 0, x, ClientRectangle.Bottom);
            }

            for (int y = 0; y < ClientRectangle.Bottom; y += 10) {
                e.Graphics.DrawLine(Pens.Black, 0, y, ClientRectangle.Right, y);
            }

            e.Graphics.FillEllipse(new SolidBrush(Color.LightGreen), ex - r, ey - r, r * 2, r * 2);
            e.Graphics.DrawEllipse(new Pen(Color.Blue), ex - r, ey - r, r * 2, r * 2);
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            ex += 6;
            if (ex > ClientRectangle.Right) ex = 0;
            Invalidate();
        }
    }
}
