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

namespace _035_Chart
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Random r = new Random();
      chart1.Titles.Add("중간고사 성적");
      for (int i = 0; i < 10; i++)
        chart1.Series["Series1"].Points.Add(r.Next(100));

      chart1.Series["Series1"].LegendText = "비주얼프로그래밍";
      chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
    }
  }
}
