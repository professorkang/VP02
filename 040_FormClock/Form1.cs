using System;
using System.Drawing;
using System.Windows.Forms;

namespace _040_FormClock
{
  public partial class Form1 : Form
  {
    private Graphics g;
    private bool aClock_Flag = true;
    private Point center;   // 시계의 중심점
    private int radius;  // 시계의 반지름
    private int faceSize; // 시계판 크기의 절반
    private int hourHand;   // 시침의 길이
    private int minHand;    // 분침
    private int secHand;    // 초침
    private Timer t = new Timer();
    public Form1()
    {
      InitializeComponent();

      this.Text = "FormClock";
      //this.ClientSize = new Size(300, 300+menuStrip1.Height);
      panel1.Size = new Size(300, 300);
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
      panel1.Refresh(); // 지우기

      if (aClock_Flag == true)
      {        
        DrawClockFace();  // 시계판 그리기

        // 시침, 분침, 초침의 각도 구하기
        double degHr = (c.Hour % 12) * 30 + c.Minute * 0.5;
        double degMin = c.Minute * 6 + c.Second * 0.1;
        double degSec = c.Second * 6;

        // 라디안으로 변화
        double radHr = Math.PI * degHr / 180;
        double radMin = Math.PI * degMin / 180;
        double radSec = Math.PI * degSec / 180;

        DrawHands(radHr, radMin, radSec);
      } 
      else  // 디지털 시계
      {
        string date = DateTime.Today.ToString("D");
        string time = string.Format("{0:D2}:{1:D2}:{2:D2}",
          c.Hour, c.Minute, c.Second);
        g.DrawString(date, 
          new Font("맑은 고딕", 12, FontStyle.Bold), 
          Brushes.SkyBlue, 
          new Point(center.X - 90, center.Y - 30));
        g.DrawString(time,
          new Font("맑은 고딕", 32, 
            FontStyle.Bold | FontStyle.Italic),
          Brushes.SteelBlue,
          new Point(center.X - 100, center.Y));
      }
    }

    // 시계바늘 그리기
    private void DrawHands(double radHr, double radMin, 
      double radSec)
    {
      // 시침
      DrawLine(
        (int)(hourHand * Math.Sin(radHr)),
        (int)(-hourHand * Math.Cos(radHr)), 0, 0,
        Brushes.RoyalBlue, 12, center.X, center.Y);
      // 분침
      DrawLine(
        (int)( minHand * Math.Sin(radMin)),
        (int)(-minHand * Math.Cos(radMin)), 0, 0,
        Brushes.SkyBlue, 8, center.X, center.Y);
      // 초침
      DrawLine(
        (int)(secHand * Math.Sin(radSec)),
        (int)(-secHand * Math.Cos(radSec)), 0, 0,
        Brushes.OrangeRed, 5, center.X, center.Y);

      // 배꼽
      int coreSize = 16;
      Rectangle r = new Rectangle(
        center.X - coreSize/2, center.Y - coreSize/2, 
        coreSize, coreSize);
      g.FillEllipse(Brushes.Gold, r);
      Pen p = new Pen(Brushes.DarkRed, 3);
      g.DrawEllipse(p, r);
    }

    // 시계바늘 그리기 using GDI+
    private void DrawLine(int x1, int y1, int x2, int y2, 
      Brush color, int thick, int Cx, int Cy)
    {
      Pen pen = new Pen(color, thick);
      pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
      pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
      g.DrawLine(pen, x1 + Cx, y1 + Cy, x2 + Cx, y2 + Cy);
    }

    // 시계판 그리기
    private void DrawClockFace()
    {
      Pen pen = new Pen(Brushes.LightSteelBlue, 30);
      g.DrawEllipse(pen, 
        center.X - faceSize, center.Y - faceSize,
        (int)(faceSize*2), (int)(faceSize *2));
    }

    private void aClockSetting()
    {
      center = new Point(panel1.Width / 2, 
        panel1.Height / 2);      
      radius = panel1.Height / 2;
      faceSize = (int)(radius * 0.80);
      hourHand = (int)(radius * 0.45);
      minHand = (int)(radius * 0.55);
      secHand = (int)(radius * 0.65);
    }

    private void 아날로그ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      aClock_Flag = true;
    }

    private void 디지털ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      aClock_Flag = false;
    }

    private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
