using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _043_SnakeBite
{
  /// <summary>
  /// Game.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class Game : Window
  {
    Random r = new Random();
    Ellipse[] snakes = new Ellipse[30];
    Ellipse egg = new Ellipse();
    private int size = 12;         // Egg와 Body의사이즈
    private int visibleCount = 5;  // 처음에 보이는 뱀의 길이
    private string move = "";      // 뱀의 이동방향
    private int eaten = 0;         // 먹은 알의 개수
    DispatcherTimer t = new DispatcherTimer();
    Stopwatch sw = new Stopwatch();
    private bool startFlag = false;

    public Game()
    {
      InitializeComponent();

      InitEgg();
      InitSnake();
      t.Interval = new TimeSpan(0, 0, 0, 0, 100);// 0.1초
      t.Tick += T_Tick;
    }

    private void InitSnake()
    {
      for (int i = 0; i < 30; i++)
      {
        snakes[i] = new Ellipse();
        snakes[i].Width = size;
        snakes[i].Height = size;
        if (i == 0)
          snakes[i].Fill = Brushes.Chocolate; // 머리 색깔변경
        else if (i % 5 == 0)
          snakes[i].Fill = Brushes.YellowGreen; // 5번째 마디 색깔변경
        else
          snakes[i].Fill = Brushes.Gold;
        snakes[i].Stroke = Brushes.Black;
        field.Children.Add(snakes[i]);
      }

      for (int i = visibleCount; i < 30; i++)
      {
        snakes[i].Visibility = Visibility.Hidden;
      }

      int x = r.Next(1, 480 / size) * size;
      int y = r.Next(1, 380 / size) * size;

      CreateSnake(x, y);
    }

    private void CreateSnake(int x, int y)
    {
      for (int i = 0; i < visibleCount; i++)
      {
        snakes[i].Tag = new Point(x, y + i * size);
        Canvas.SetLeft(snakes[i], x);
        Canvas.SetTop(snakes[i], y + i * size);
      }
    }

    // 12의 배수 좌표를 랜덤하게 갖도록 하여 Tag에 저장
    private void InitEgg()
    {
      egg = new Ellipse();
      egg.Tag = new Point(r.Next(1, 480 / size) * size,
         r.Next(1, 380 / size) * size);  // 알의 위치
      egg.Width = size;
      egg.Height = size;
      egg.Stroke = Brushes.Black;
      egg.Fill = Brushes.Red;

      Point p = (Point)egg.Tag;
      field.Children.Add(egg);
      Canvas.SetLeft(egg, p.X);
      Canvas.SetTop(egg, p.Y);
    }

    private void T_Tick(object sender, EventArgs e)
    {
      if (move != "")
      {
        startFlag = true;

        // 꼬리 하나를 더 계산
        for (int i = visibleCount; i >= 1; i--)
        {
          Point p = (Point)snakes[i - 1].Tag;
          snakes[i].Tag = new Point(p.X, p.Y);
        }

        Point pnt = (Point)snakes[0].Tag;
        if (move == "Right")
          snakes[0].Tag = new Point(pnt.X + size, pnt.Y);
        else if (move == "Left")
          snakes[0].Tag = new Point(pnt.X - size, pnt.Y);
        else if (move == "Up")
          snakes[0].Tag = new Point(pnt.X, pnt.Y - size);
        else if (move == "Down")
          snakes[0].Tag = new Point(pnt.X, pnt.Y + size);
        EatEgg();   // 알을 먹었는지 체크
      }

      if (startFlag == true)
      {
        TimeSpan ts = sw.Elapsed;
        txtTime.Text = String.Format("Time = {0:00}:{1:00}.{2:00}",
           ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        DrawSnakes();
      }
    }

    private void DrawSnakes()
    {
      for (int i = 0; i < visibleCount; i++)
      {
        Point p = (Point)snakes[i].Tag;
        Canvas.SetLeft(snakes[i], p.X);
        Canvas.SetTop(snakes[i], p.Y);
      }
    }

    private void EatEgg()
    {
      Point pS = (Point)snakes[0].Tag;
      Point pE = (Point)egg.Tag;

      if (pS.X == pE.X && pS.Y == pE.Y)
      {
        egg.Visibility = Visibility.Hidden;
        visibleCount++;
        // 꼬리를 하나 늘림
        snakes[visibleCount - 1].Visibility = Visibility.Visible;
        txtScore.Text = "Eggs = " + (++eaten).ToString();

        if (visibleCount == 30)
        {
          t.Stop();
          sw.Stop();
          DrawSnakes();
          TimeSpan ts = sw.Elapsed;
          string tElapsed = String.Format("Time = {0:00}:{1:00}.{2:00}",
              ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
          MessageBox.Show("Success!!!  " + tElapsed + " sec");
          this.Close();
        }

        Point p = new Point(r.Next(1, 480 / size) * size,
          r.Next(1, 380 / size) * size);
        egg.Tag = p;
        egg.Visibility = Visibility.Visible;
        Canvas.SetLeft(egg, p.X);
        Canvas.SetTop(egg, p.Y);
      }

      
    }
    private void Window_KeyDown_1(
        object sender, KeyEventArgs e)
    {
      if (move == "") // 맨 처음 키가 눌리면 게임 시작(sw 시작)
      {
        sw.Start();
        t.Start();
      }

      if (e.Key == Key.Right)
        move = "Right";
      else if (e.Key == Key.Left)
        move = "Left";
      else if (e.Key == Key.Up)
        move = "Up";
      else if (e.Key == Key.Down)
        move = "Down";
      else if (e.Key == Key.Escape)
        // move = "";
        t.Stop();
    }
  }
}
