using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _037_graph
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      this.Text = "Graph using Chart Control";
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      chart1.ChartAreas[0].BackColor = Color.Black;

      // x축, y축을 설정
      chart1.ChartAreas[0].AxisX.Minimum = 0;
      chart1.ChartAreas[0].AxisX.Maximum = 20;
      chart1.ChartAreas[0].AxisX.Interval = 1;
      chart1.ChartAreas[0].AxisX.MajorGrid.LineColor 
        = Color.Gray;
      chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle 
        = ChartDashStyle.Dash;

      chart1.ChartAreas[0].AxisY.Minimum = -0.4;
      chart1.ChartAreas[0].AxisY.Maximum = 1;
      chart1.ChartAreas[0].AxisY.Interval = 0.2;
      chart1.ChartAreas[0].AxisY.MajorGrid.LineColor
        = Color.Gray;
      chart1.ChartAreas[0].AxisY.LineDashStyle
        = ChartDashStyle.Dash;

      // Series 설정(Sin)
      chart1.Series[0].ChartType = SeriesChartType.Line;
      chart1.Series[0].Color = Color.LightGreen;
      chart1.Series[0].BorderWidth = 2;
      chart1.Series[0].LegendText = "sin(x)/x";

      //if(chart1.Series.Count == 1)
      //  chart1.Series.Add("Cos");
      //chart1.Series[1].ChartType = SeriesChartType.Line;
      //chart1.Series[1].Color = Color.Orange;
      //chart1.Series[1].BorderWidth = 2;
      //chart1.Series[1].LegendText = "cos(x)/x";

      // 시리즈에 데이터를 추가
      for(double x = 0; x<20; x+=0.1)
      {
        double y = Math.Sin(x) / x;
        chart1.Series[0].Points.AddXY(x, y);
        //y = Math.Cos(x) / x;
        //chart1.Series[1].Points.AddXY(x, y);
      }
    }

  }
}
