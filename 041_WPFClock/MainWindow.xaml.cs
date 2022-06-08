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
    public MainWindow()
    {
      InitializeComponent();

      aClockSetting();
      timerSetting();
    }

    private void timerSetting()
    {
      DispatcherTimer timer = new DispatcherTimer();
      timer.Interval = new TimeSpan(0, 0, 0, 0, 10); // 10밀리초
      timer.Tick += Timer_Tick;
      timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      DateTime c = DateTime.Now;

      canvas1.Children.Clear();
      DrawClockFace();  // 시계판 그리기

      // 시간에 따라 시계바늘을 그린다
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
  }
}
