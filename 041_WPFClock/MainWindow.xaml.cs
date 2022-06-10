using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _041_WPFClock
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    Point center;
    int radius;
    int hourHand;
    int minHand;
    int secHand;
    bool aFlag = true;  // true:아날로그 false:디지털
    bool msFlag = false; // false: 초단위 true:ms단위
    DispatcherTimer timer;
    public MainWindow()
    {
      InitializeComponent();

      aClockSetting();
      timerSetting();
    }

    private void timerSetting()
    {
      timer = new DispatcherTimer();
      timer.Interval = new TimeSpan(0, 0, 0, 1); // 10밀리초
      timer.Tick += Timer_Tick;
      timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      DateTime c = DateTime.Now;

      canvas1.Children.Clear();

      if (aFlag == true)   // 아날로그 시계
      {
        DrawClockFace();  // 시계판 그리기

        // 시간에 따라 시계바늘을 그린다
        // 시침, 분침, 초침의 각도 구하기
        double degHr = (c.Hour % 12) * 30 + c.Minute * 0.5;
        double degMin = c.Minute * 6 + c.Second * 0.1;
        double degSec = c.Second * 6 + c.Millisecond * 6.0 / 1000;
        //double degSec;
        //if (msFlag == true)
        //  degSec =
        //    c.Second * 6 + c.Millisecond * 6.0 / 1000;
        //else
        //  degSec = c.Second * 6;

        // 라디안으로 변화
        double radHr = Math.PI * degHr / 180;
        double radMin = Math.PI * degMin / 180;
        double radSec = Math.PI * degSec / 180;

        DrawHands(radHr, radMin, radSec);
      } 
      else // 디지털 시계
      {
        txtDate.Text = DateTime.Today.ToString("D");
        if(msFlag == false) // 초단위
          txtTime.Text = String.Format(
            "{0:D2}:{1:D2}:{2:D2}",
            c.Hour, c.Minute, c.Second);
        else // 밀리초 단위
          txtTime.Text = String.Format(
            "{0:D2}:{1:D2}:{2:D2}.{3:D3}",
            c.Hour, c.Minute, c.Second, c.Millisecond);
      }
    }

    private void DrawHands(double radHr, double radMin, double radSec)
    {
      // 시침
      DrawLine(
        (int)(hourHand * Math.Sin(radHr)),
        (int)(-hourHand * Math.Cos(radHr)), 0, 0,
        Brushes.RoyalBlue, 12, center.X, center.Y);
      // 분침
      DrawLine(
        (int)(minHand * Math.Sin(radMin)),
        (int)(-minHand * Math.Cos(radMin)), 0, 0,
        Brushes.SkyBlue, 8, center.X, center.Y);
      // 초침
      DrawLine(
        (int)(secHand * Math.Sin(radSec)),
        (int)(-secHand * Math.Cos(radSec)), 0, 0,
        Brushes.OrangeRed, 5, center.X, center.Y);

      // 배꼽

      //Rectangle r = new Rectangle(
      //  center.X - coreSize / 2, center.Y - coreSize / 2,
      //  coreSize, coreSize);
      //g.FillEllipse(Brushes.Gold, r);
      //Pen p = new Pen(Brushes.DarkRed, 3);
      //g.DrawEllipse(p, r);

      int coreSize = 16;
      Ellipse core = new Ellipse();
      core.Margin = new Thickness(
        center.X - coreSize / 2, center.Y - coreSize / 2, 
        0, 0);
      core.Stroke = Brushes.DarkRed;
      core.StrokeThickness = 3;
      core.Fill = Brushes.Gold;
      core.Width = coreSize;
      core.Height = coreSize;
      canvas1.Children.Add(core);
    }

    private void DrawLine(int x1, int y1, int x2, int y2,
      Brush color, int thick, double Cx, double Cy)
    {
      Line line = new Line();
      line.X1 = x1;
      line.Y1 = y1;
      line.X2 = x2;
      line.Y2 = y2;
      line.Stroke = color;
      line.StrokeThickness = thick;
      line.Margin = new Thickness(Cx, Cy, 0,0);
      line.StrokeStartLineCap = PenLineCap.Round;
      canvas1.Children.Add(line);
    }

    private void DrawClockFace()
    {
      aClock.Stroke = Brushes.LightSteelBlue;
      aClock.StrokeThickness = 30;
      canvas1.Children.Add(aClock);
    }

    private void aClockSetting()
    {
      center = new Point(canvas1.Width/2, 
        canvas1.Height / 2);
      radius = (int)canvas1.Width / 2;
      hourHand = (int)(radius * 0.45);
      minHand = (int)(radius * 0.55);
      secHand = (int)(radius * 0.65);
    }

    private void Analog_Clcik(object sender, RoutedEventArgs e)
    {
      aFlag = true;
      txtDate.Text = "";
      txtTime.Text = "";
    }

    private void Digital_Clcik(object sender, RoutedEventArgs e)
    {
      aFlag = false;
    }

    private void Exit_Clcik(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void Sec_Clcik(object sender, RoutedEventArgs e)
    {
      msFlag = false;
      timer.Interval = new TimeSpan(0, 0, 0, 1);// 1초
      
    }

    private void MSec_Clcik(object sender, RoutedEventArgs e)
    {
      msFlag = true;
      timer.Interval = new TimeSpan(0, 0, 0, 0, 10); // 0.01초
    }
  }
}
