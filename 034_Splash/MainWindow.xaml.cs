using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
    SqlConnection conn;
    string connStr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\807PC02\source\repos\VP02\034_Splash\Colors.mdf;Integrated Security = True";

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

    int index = 0;
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
            Color.FromRgb((byte)0, (byte)0, colors[i]));
      }

      string sql = string.Format(
        "INSERT INTO ColorTable VALUES ('{0}', '{1}'",
        date, time);
      for(int i = 0; i < 20; i++)
      {
        sql += string.Format(", {0}", colors[i]);
      }
      sql += ")";
      //MessageBox.Show(sql);

      using(conn = new SqlConnection(connStr))
      using(SqlCommand cmd = new SqlCommand(sql, conn))
      {
        conn.Open();
        cmd.ExecuteNonQuery();
      }

      string s = "";
      s += date + " " + time + " ";
      for (int i = 0; i < 20; i++)
        s += colors[i] + " ";
      lstDB.Items.Add(s);

      // 리스트 박스의 스크롤
      lstDB.SelectedIndex = index++;
      lstDB.ScrollIntoView(lstDB.SelectedItem);
    }

    bool flag = false;
    private void btnRandom_Click(object sender, RoutedEventArgs e)
    {
      if (flag == false)
      {
        t.Start();
        btnRandom.Content = "정지";
        flag = true;
      }
      else
      {
        t.Stop();
        btnRandom.Content = "랜덤 색깔 표시";
        flag= false;
      }

    }

    int id = 0;
    // DB에 저장된 색깔 표시
    private void btnDB_Click(object sender, RoutedEventArgs e)
    {
      lstDB.Items.Clear();

      string sql = "SELECT * FROM ColorTable";
      int[] colors = new int[20];

      using (conn = new SqlConnection(connStr))
      using (SqlCommand cmd = new SqlCommand(sql, conn))
      {
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
          lblDate.Text = reader["Date"].ToString();
          lblTime.Text = reader["Time"].ToString();
          for(int i=0; i<20; i++)
          {
            colors[i] = int.Parse(reader[i+3].ToString());
          }

          string s = "";
          s += reader["Date"].ToString() + " " 
            + reader["Time"].ToString();
          for(int i=0; i<20; i++)
          {
            s += " " + reader[i + 3].ToString();
          }

          lstDB.Items.Add(s);
          // 스크롤 기능
          lstDB.SelectedIndex = id++;
          lstDB.ScrollIntoView(lstDB.SelectedItem);

          for(int i=0; i<20; i++)
          {
            borderList[i].Background =
              new SolidColorBrush(
                Color.FromRgb((byte)0, (byte)0, (byte)colors[i]));

            // WPF에서 delay 주기
            Dispatcher.Invoke((ThreadStart)(() => { }),
              DispatcherPriority.ApplicationIdle);
            Thread.Sleep(20);  // 0.02 초 delay
          }
        }
      }
    }

    // DB의 내용을 다 지운다
    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      lstDB.Items.Clear();
      string sql = "DELETE FROM ColorTable";

      using(conn= new SqlConnection(connStr))
      using(SqlCommand cmd = new SqlCommand(sql, conn))
      {
        conn.Open();
        cmd.ExecuteNonQuery();
      }
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
