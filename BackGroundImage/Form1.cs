﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace BackGroundImage {
    public partial class Form1 : Form {
        private Bitmap B = new Bitmap(600, 400);
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(B, 0, 0);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Graphics G = Graphics.FromImage(B);
                //G.Clear(BackColor);
                Random R = new Random();

                for (int i = 0; i < 500; i++) {
                    SolidBrush Br = new SolidBrush(Color.FromArgb(R.Next(256), R.Next(256), R.Next(256), R.Next(256)));
                    G.FillEllipse(Br, R.Next(600), R.Next(400), R.Next(70) + 30, R.Next(70) + 30);
                }
                Invalidate();
            }
        }
    }
}
