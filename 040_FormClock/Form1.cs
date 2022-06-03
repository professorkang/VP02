using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _040_FormClock
{
  public partial class Form1 : Form
  {
    Graphics g;
    bool aClock_Flag = false;
    Point center;   // 시계의 중심점
    double radius;  // 시계의 반지름
    int hourHand;   // 시침의 길이
    int minHand;    // 분침
    int secHand;    // 초침
    Timer t = new Timer();
    public Form1()
    {
      InitializeComponent();

      this.Text = "FormClock";
      g = panel1.CreateGraphics();

      aClockSetting();
      TimerSetting();
    }

    private void TimerSetting()
    {
      t.Interval = 1000;  // 1초
      t.Tick += T_Tick;
      t.Start();
    }

    private void T_Tick(object sender, EventArgs e)
    {
      DateTime c = DateTime.Now;

      DrawClockFace();  // 시계판 그리기

      // 시침, 분침, 초침의 각도 구하기
      double degHr = (c.Hour % 12) * 30 + c.Minute * 0.5;
      double degMin = c.Minute * 6 + c.Second * 0.1;
      double degSec = c.Second * 6;

      // 라디안으로 변화
      double radHr = Math.PI * degHr / 180;
      double radMin = Math.PI * degMin / 180;
      double radSec = Math.PI * degSec / 180;

    }

    private void DrawClockFace()
    {
      throw new NotImplementedException();
    }

    private void aClockSetting()
    {
      center = new Point(panel1.Width / 2, 
        panel1.Height / 2);
      radius = panel1.Height / 2;
      hourHand = (int)(radius * 0.45);
      minHand = (int)(radius * 0.55);
      secHand = (int)(radius * 0.65);
    }
  }
}
