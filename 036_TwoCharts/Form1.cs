using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _036_TwoCharts
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      this.Text = "Using Chart Control";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      ch1.Titles.Add("중간고사");
      ch1.Series.Add("Series2");
      ch1.Series["Series1"].LegendText = "수학";
      ch1.Series["Series2"].LegendText = "영어";

      ch1.ChartAreas.Add("ChartArea2");
      ch1.Series["Series2"].ChartArea = "ChartArea2";

      Random r = new Random();
      for(int i=0; i<10; i++)
      {
        ch1.Series["Series1"].Points.AddXY(i, r.Next(100));
        ch1.Series["Series2"].Points.AddXY(i, r.Next(100));
      }
    }

    private void btnOneChart_Click(object sender, EventArgs e)
    {
      ch1.ChartAreas.RemoveAt(ch1.ChartAreas.IndexOf("ChartArea2"));
      ch1.Series["Series2"].ChartArea = "ChartArea1";
    }

    private void btnTwoChart_Click(object sender, EventArgs e)
    {
      ch1.ChartAreas.Add("ChartArea2");
      ch1.Series["Series2"].ChartArea = "ChartArea2";
    }
  }
}
