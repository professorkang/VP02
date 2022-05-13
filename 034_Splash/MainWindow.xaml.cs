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

namespace _034_Splash
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    List<Border> borderList;
    DispatcherTimer t = new DispatcherTimer();
    Random r = new Random();

    public MainWindow()
    {
      InitializeComponent();
      borderList = new List<Border>
      {
        bd1, bd2, bd3, bd4, bd5, 
        bd6, bd7, bd8, bd9, bd10,
        bd11, bd12, bd13, bd14, bd15, 
        bd16, bd17, bd18, bd19, bd20
      };
      t.Interval = new TimeSpan(0, 0, 1); // 1초
      t.Tick += T_Tick;
    }

    private void T_Tick(object sender, EventArgs e)
    {
      string date = DateTime.Now.ToString("yyyy-MM-dd");
      string time = DateTime.Now.ToString("HH:mm:ss");
      lblDate.Text = date;
      lblTime.Text = time;

      byte[] colors = new byte[20];
      for(int i = 0; i < 20; i++)
      {
        colors[i] = (byte)(r.Next(256));
        borderList[i].Background
          = new SolidColorBrush(
            Color.FromRgb(colors[i], (byte)0, (byte)0));
      }

      string s = "";
      s += date + " " + time + " ";
      for (int i = 0; i < 20; i++)
        s += colors[i] + " ";
      lstDB.Items.Add(s);
    }

    private void btnRandom_Click(object sender, RoutedEventArgs e)
    {
      t.Start();

    }

    private void btnDB_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
