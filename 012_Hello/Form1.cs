using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _012_Hello
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

    }

    bool flag = false;
    private void button1_Click(object sender, EventArgs e)
    {
      if (flag == false)
      {
        label1.Text
          = "Hello! Windows Form Programming";
        flag = true;
      } 
      else
      {
        label1.Text = "";
        flag= false;
      }
      //if (label1.Text == "")
      //  label1.Text
      //    = "Hello Windows Form Programming";
      //else
      //  label1.Text = "";
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
