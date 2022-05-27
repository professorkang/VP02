using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _038_EcgPpt
{
  public partial class Form1 : Form
  {
    private double[] ecg = new double[100000];
    private double[] ppg = new double[100000];
    private int ecgCount; // ecg 데이터 갯수
    private int ppgCount; // ppg 데이터 갯수
    private Timer t = new Timer();
    public Form1()
    {
      InitializeComponent();
      this.Text = "ECG/PPG";
      this.WindowState = FormWindowState.Maximized;

      EcgRead();
      PpgRead();

      ChartSetting();

      t.Interval = 10; // 0.01초
      t.Tick += T_Tick;
    }

    int cursorX = 0;  // 디스플레이되는 데이터의 시작점
    bool scrolling = false; // true 일 때 스크롤

    private void T_Tick(object sender, EventArgs e)
    {
      // 한 화면에 500개의 데이터를 보여줄 예정
      if (cursorX + dataCount < ecgCount)
        ch.ChartAreas[0].AxisX.ScaleView.Zoom(
          cursorX, cursorX + dataCount);
      else
        t.Stop();
      cursorX += 2;
    }

    private void ChartSetting()
    {
      // 커서 사용 가능
      ch.ChartAreas[0].CursorX.IsUserEnabled = true; 
      // zoom 범위 선택 가능
      ch.ChartAreas[0].CursorX.IsUserSelectionEnabled
        = true;

      // chart 영역 설정
      ch.ChartAreas[0].BackColor = Color.Black;
      ch.ChartAreas[0].AxisX.Minimum = 0;
      ch.ChartAreas[0].AxisX.Maximum = ecgCount;
      ch.ChartAreas[0].AxisX.Interval = 50;
      ch.ChartAreas[0].AxisX.MajorGrid.LineColor =
        Color.Gray;
      ch.ChartAreas[0].AxisX.MajorGrid.LineDashStyle =
        ChartDashStyle.Dash;

      ch.ChartAreas[0].AxisY.Minimum = -2;
      ch.ChartAreas[0].AxisY.Maximum = 6;
      ch.ChartAreas[0].AxisY.Interval = 0.5;
      ch.ChartAreas[0].AxisY.MajorGrid.LineColor =
        Color.Gray;
      ch.ChartAreas[0].AxisY.MajorGrid.LineDashStyle =
        ChartDashStyle.Dash;

      // Series 2개 새로 만들기
      ch.Series.Clear();
      ch.Series.Add("ECG");
      ch.Series.Add("PPG");

      ch.Series["ECG"].ChartType = SeriesChartType.Line;
      // ch.Series[0].ChartType = SeriesChartType.Line;
      ch.Series["ECG"].Color = Color.Orange;
      ch.Series["ECG"].BorderWidth = 2;
      ch.Series["ECG"].LegendText = "ECG";

      ch.Series["PPG"].ChartType = SeriesChartType.Line;
      // ch.Series[1].ChartType = SeriesChartType.Line;
      ch.Series["PPG"].Color = Color.LightGreen;
      ch.Series["PPG"].BorderWidth = 2;
      ch.Series["PPG"].LegendText = "PPG";

      // 데이터를 series에 추가
      foreach(var v in ecg)
      {
        ch.Series["ECG"].Points.Add(v);
      }
      foreach (var v in ppg)
      {
        ch.Series["PPG"].Points.Add(v);
      }
    }

    private void PpgRead()
    {
      string fileName = "../../Data/ppg.txt";
      string[] lines = File.ReadAllLines(fileName);

      double min = double.MaxValue;
      double max = double.MinValue;

      int i = 0;
      foreach (var line in lines)
      {
        ppg[i] = double.Parse(line);
        if (ppg[i] < min) min = ppg[i];
        if (ppg[i] > max) max = ppg[i];
        i++;
      }
      ppgCount = i;
      string s = string.Format(
        "PPG: Count={0}, min={1}, max={2}",
        ppgCount, min, max);
      MessageBox.Show(s);
    }

    private void EcgRead()
    {
      string fileName = "../../Data/ecg.txt";
      string[] lines = File.ReadAllLines(fileName);

      double min = double.MaxValue;
      double max = double.MinValue;

      int i = 0;
      foreach(var line in lines)
      {
        ecg[i] = double.Parse(line) + 3;
        if(ecg[i] < min) min = ecg[i];
        if(ecg[i] > max) max = ecg[i];
        i++;
      }
      ecgCount = i;
      string s = string.Format(
        "ECG: Count={0}, min={1}, max={2}",
        ecgCount, min, max);
      MessageBox.Show(s);
    }

    private void autoScrollToolStripMenuItem_Click(object sender, EventArgs e)
    {
      t.Start();
      scrolling = true;
    }

    private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ch.ChartAreas[0].AxisX.ScaleView.Zoom(0, ecgCount);
      t.Stop();
      scrolling = false;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    bool isTimerRunning = true;
    private int dataCount = 500;

    private void ch_Click(object sender, EventArgs e)
    {
      if(isTimerRunning)
      {
        t.Stop();
        isTimerRunning = false;
      }
      else
      {
        t.Start();
        isTimerRunning = true;
      }
    }

    private void ch_MouseClick(object sender, MouseEventArgs e)
    {
      HitTestResult htr = ch.HitTest(e.X, e.Y);
      if(htr.ChartElementType == ChartElementType.DataPoint)
      {
        t.Stop();
        string s = string.Format(
          "Count: {0}, ECG: {1}, PPG:{2}",
          htr.PointIndex,
          ch.Series["ECG"].Points[htr.PointIndex].YValues[0],
          ch.Series["PPG"].Points[htr.PointIndex].YValues[0]);
        MessageBox.Show(s);
      }
    }

    private void dataCountToolStripMenuItem_Click(object sender, EventArgs e)
    {
      dataCount = dataCount*2;
    }

    private void dataCountToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      dataCount = dataCount / 2;
    }
  }
}
