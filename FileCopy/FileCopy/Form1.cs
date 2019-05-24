using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(CopyFile);
            t.Start();                      
        }

        private void CopyFile()
        {
            FileManager fm = new FileManager();

            // 동일 이벤트에 이벤트 핸들러 가입하기
            fm.InProgress += Fm_InProgress;
            fm.InProgress += Fm_InProgress2;
            fm.Copy("jdk-8u211-windows-x64.exe", "copy.exe");
        }

        private void Fm_InProgress2(object sender, double e)
        {
            Debug.WriteLine("Progress {0}", e);
        }

        private void Fm_InProgress(object sender, double e)
        {
            // 멀티 쓰레드 관련 처리
            // UI 쓰레드와 워커 쓰레드가 분리되어 있어
            // 쓰레드를 따로 발생시킬 필요가 있을 때 하는 듯
            if (InvokeRequired)
            {
                Invoke(new EventHandler<double>(Fm_InProgress), sender, e);
            }
            else
            {
                progressBar1.Value = (int)e;
                lbPct.Text = string.Format("{0} %", (int)e);
            }
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
