using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopy
{
    class FileManager
    {
        //private Form1 form;
        //public FileManager(Form1 form)
        //{
        //    this.form = form;
        //}

        public event EventHandler<double> InProgress;

        // 이 메소드가 특정 UI에 의존할 필요가 없다
        public void Copy(string srcFile, string destFile)
        {
            byte[] buffer = new byte[1024];
            int pos = 0;

            // file size
            var fi = new FileInfo(srcFile);
            var fileSize = fi.Length;

            // file copy
            using (BinaryReader rd = new BinaryReader(File.Open(srcFile, FileMode.Open)))
            using (BinaryWriter wr = new BinaryWriter(File.Open(destFile, FileMode.Create)))
            {
                while(pos < fileSize)
                {
                    int count = rd.Read(buffer, 0, buffer.Length);
                    wr.Write(buffer, 0, count);
                    pos += count;

                    // progressBar
                    // C# 윈폼에서 UI는UI 쓰레드만 접근할 수 있다
                    double pct = (pos / (double)fileSize) * 100;
                    if (InProgress != null)
                    {
                        // event handler 호출
                        InProgress(this, pct);
                    }

                    //form.progressBar1.Value = (int)pct;
                    //form.lbPct.Text = string.Format("{0} %", (int)pct);
                }
            }
        }
    }
}
