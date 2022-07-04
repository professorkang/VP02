using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _003_bmi
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string s = textBox1.Text;
      double weight = double.Parse(s);
      s = textBox2.Text;
      double height = double.Parse(s);
      double bmi = weight / (height / 100 * height / 100);
      label3.Text = "BMI = " + bmi;
    }
  }
}
