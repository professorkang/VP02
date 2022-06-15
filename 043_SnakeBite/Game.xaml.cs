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
using System.Windows.Shapes;

namespace _043_SnakeBite
{
  /// <summary>
  /// Game.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class Game : Window
  {
    Random r = new Random();
    Ellipse[] snake = new Ellipse[30];
    Ellipse egg;
    int W = 10; // 뱀과 알의 크기
    int visibleCount = 5; // 눈에 보이는 뱀의 길이
    public Game()
    {
      InitializeComponent();

      InitEgg();
      InitSnake();
    }

    private void InitSnake()
    {
      // 뱀의 머리 위치
      int x = r.Next((int)(field.Width) / W); // 40
      int y = r.Next((int)(field.Height) / W); // 30

      for(int i = 0; i < 30; i++)
      {
        snake[i] = new Ellipse();
        snake[i].Width = W;
        snake[i].Height = W;
        snake[i].Stroke = Brushes.Black;
        if (i == 0) // 머리
          snake[i].Fill = Brushes.Chocolate;
        else if (i % 5 == 0)
          snake[i].Fill = Brushes.Green;
        else
          snake[i].Fill = Brushes.Gold;

        snake[i].Tag = new Point(x * W, (y + i) * W);
        field.Children.Add(snake[i]);
        Canvas.SetLeft(snake[i], x * W);
        Canvas.SetTop(snake[i], (y + i) * W);
      }

      for (int i = visibleCount; i < 30; i++)
        snake[i].Visibility = Visibility.Hidden;

    }

    private void InitEgg()
    {
      egg = new Ellipse();
      egg.Width = W;
      egg.Height = W;
      egg.Stroke = Brushes.Black;
      egg.Fill = Brushes.Red;

      int x = r.Next((int)(field.Width) / W); // 40
      int y = r.Next((int)(field.Height) / W); // 30
      egg.Tag = new Point(x, y);

      field.Children.Add(egg);
      Canvas.SetLeft(egg, x * W);
      Canvas.SetTop(egg, y * W);
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {

    }
  }
}
