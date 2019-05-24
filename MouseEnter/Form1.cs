using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseEnter {
    public partial class Form1 : Form {
        private int count;
        private string Status;
        public Form1() {
            Status = "unknown";
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            //e.Graphics.Clear(BackColor);
            e.Graphics.DrawString(Status, Font, Brushes.Black, 10, 10);
            e.Graphics.DrawString("count : " + count.ToString(), Font, Brushes.Black, 10, 30);
        }

        private void Form1_MouseEnter(object sender, EventArgs e) {
            Status = "Mouse In Control";
            Invalidate();
        }

        private void Form1_MouseHover(object sender, EventArgs e) {
            count++;
            Invalidate();
        }

        private void Form1_MouseLeave(object sender, EventArgs e) {
            Status = "Mouse Out of control";
            Invalidate();
        }
    }
}
