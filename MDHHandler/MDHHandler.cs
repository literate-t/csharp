using System;
using System.Drawing;
using System.Windows.Forms;

class MDHHandler : Form {
    public static void Main() {
        MDHHandler MyForm = new MDHHandler();
        MyForm.Paint += MyForm.MyPaint;
        Application.Run(MyForm);
    }
    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        e.Graphics.DrawString("OnPaint 메서드 호출", Font, Brushes.Black, 10, 10);
    }

    void MyPaint(Object sendler, PaintEventArgs e) {
        e.Graphics.DrawString("Paint의 이벤트 핸들러 호출", Font, Brushes.Black, 10, 30);
    }
}