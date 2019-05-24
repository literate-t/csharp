using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventView {
    public partial class Form1 : Form {
        private int count = 1;
        public Form1() {
            InitializeComponent();
        }

        private void AddEvent(string Name) {
            if(checkBox1.Checked == false) {
                textBox1.Text += (count + ":" + Name + "\r\n");
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();
                count++;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            AddEvent("Load");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
            //AddEvent("CheckedChanged");
        }

        private void Button1_Click(object sender, EventArgs e) {
            textBox1.Text = "";
            count = 1;
        }

        private void Form1_Activated(object sender, EventArgs e) {
            AddEvent("Activated");
        }

        private void Form1_Deactivate(object sender, EventArgs e) {
            AddEvent("Deactivate");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            //AddEvent("MouseMove");
        }

        private void Form1_Resize(object sender, EventArgs e) {
            AddEvent("Resize");
        }

        private void Form1_Shown(object sender, EventArgs e) {
            AddEvent("Shown");
        }

        private void Form1_Move(object sender, EventArgs e) {
            AddEvent("Move");
        }

        private void Form1_Layout(object sender, LayoutEventArgs e) {
            AddEvent("Layout");
        }
    }
}
