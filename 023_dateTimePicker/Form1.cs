using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _023_dateTimePicker
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
      DateTime today = DateTime.Today;
      DateTime Sday = dateTimePicker1.Value;

      textBox1.Text 
        = today.Subtract(Sday).TotalDays.ToString("0");  
    }
  }
}
