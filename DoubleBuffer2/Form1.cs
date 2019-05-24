using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleBuffer2 {
    public partial class Form1 : Form {
        int ex = 10, ey = 100;
        const int r = 15;
        Bitmap B;

        public Form1() {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            if (B != null) {
                e.Graphics.DrawImage(B, 0, 0);
            }
        }

        //protected override void OnPaintBackground(PaintEventArgs e) {

        //}

        private void Timer1_Tick(object sender, EventArgs e) {
            if (B == null || B.Width != ClientSize.Width || B.Height != ClientSize.Height) {
                B = new Bitmap(ClientSize.Width, ClientSize.Height);
            }

            Graphics G = Graphics.FromImage(B);
            //G.Clear(SystemColors.Window)           

            ex += 6;
            if (ex > ClientRectangle.Right) ex = 0;

            for (int x = 0; x < ClientRectangle.Right; x += 10) {
                G.DrawLine(Pens.Black, x, 0, x, ClientRectangle.Bottom);
            }

            for (int y = 0; y < ClientRectangle.Bottom; y += 10) {
                G.DrawLine(Pens.Black, 0, y, ClientRectangle.Right, y);
            }
            G.FillEllipse(new SolidBrush(Color.LightGreen), ex - r, ey - r, r * 2, r * 2);
            G.DrawEllipse(new Pen(Color.Blue, 5), ex - r, ey - r, r * 2, r * 2);

            Invalidate();
        }
    }
}
