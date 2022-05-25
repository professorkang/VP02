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
using System.Data.SqlClient;
using System.Threading;

namespace _035_Splash
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    string connStr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\807PC02\source\repos\VP01\035_Splash\Colors.mdf;Integrated Security = True";

    List<Border> borderList;
    // Timer t = new Timer();
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

    int index = 0;
    private void T_Tick(object sender, EventArgs e)
    {
      string date = DateTime.Now.ToString("yyyy-MM-dd");
      string time = DateTime.Now.ToString("hh:mm:ss");
      lblDate.Text = date;
      lblTime.Text = time;
            
      byte[] colors = new byte[20];
      for(int i = 0; i < colors.Length; i++)
      {
        colors[i] = (byte)(r.Next(255));
        borderList[i].Background =
          new SolidColorBrush(Color.FromRgb(0, colors[i], 0));
      }

      string s = "";
      s += date + " " + time + " ";
      for(int i = 0; i < borderList.Count; i++)
      {
        s += colors[i] + " ";
      }

      lstDB.Items.Add(s);

      // 리스트박스의 스크롤
      lstDB.SelectedIndex = index++;
      lstDB.ScrollIntoView(lstDB.SelectedItem);

      // 데이터베이스에 저장
      string sql = string.Format(
        "INSERT INTO ColorTable Values ('{0}', '{1}'",
        date, time);
      for(int i = 0; i < 20; i++)
      {
        sql += ", " + colors[i];
      }
      sql += ")";
      //MessageBox.Show(sql);

      using(SqlConnection conn= new SqlConnection(connStr))
      using(SqlCommand comm = new SqlCommand(sql, conn))
      {
        conn.Open();
        comm.ExecuteNonQuery();
      }
    }

    bool flag = false;
    private void btnRandom_Click(object sender, RoutedEventArgs e)
    {
      if (flag == false)
      {
        t.Start();
        btnRandom.Content = "중지";
        flag = true;
      }
      else
      {
        t.Stop();
        btnRandom.Content = "Random색깔표시";
        flag = false;
      }

      
    }

    int id = 0; // 스크롤을 위해서 필요
    // DB에서 읽어오기
    private void btnDB_Click(object sender, RoutedEventArgs e)
    {
      lstDB.Items.Clear();

      string sql = "SELECT * FROM ColorTable";
      int[] colors = new int[20];

      using(SqlConnection conn = new SqlConnection(connStr))
      using(SqlCommand comm = new SqlCommand(sql, conn))
      {
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();

        string s = "";
        while(reader.Read())
        {
          s = "";
          lblDate.Text = reader["Date"].ToString();
          s += lblDate.Text + " ";
          lblTime.Text = reader["Time"].ToString();
          s += lblTime.Text + " ";
          for(int i=0; i<20; i++)
          {
            colors[i] = int.Parse(reader[i + 3].ToString());
            s += colors[i] + " ";
          }
          lstDB.Items.Add(s);
          lstDB.SelectedIndex = id++;
          lstDB.ScrollIntoView(lstDB.SelectedItem);

          for(int i=0; i<colors.Length; i++)
          {
            borderList[i].Background = new SolidColorBrush(
              Color.FromRgb(0, (byte)colors[i], 0));
          }

          // WPF delay 주기
          Dispatcher.Invoke((ThreadStart)(() => { }),
            DispatcherPriority.ApplicationIdle);
          Thread.Sleep(20); // 20ms 
        }
      }
    }

    // DB의 값을 지운다
    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      lstDB.Items.Clear();
      string sql = "DELETE FROM ColorTable";
      using (SqlConnection conn = new SqlConnection(connStr))
      using (SqlCommand comm = new SqlCommand(sql, conn))
      {
        conn.Open();
        comm.ExecuteNonQuery();
      }
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }
}
