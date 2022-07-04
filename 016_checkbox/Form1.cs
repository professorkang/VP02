using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _016_checkbox
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      string checkStates = "";
      CheckBox[] cBox = {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4,
                checkBox5 };

      for (int i = 0; i < cBox.Length; i++)
      {
        checkStates += string.Format("{0} : {1}\n",
            cBox[i].Text, cBox[i].Checked);
      }
      foreach (var c in cBox)
      {
        checkStates += string.Format("{0} : {1}\n",
            c.Text, c.Checked);
      }
      MessageBox.Show(checkStates, "Summary");

      string summary = string.Format("좋아하는 과일은 :");
      foreach (var c in cBox)
      {
        if (c.Checked == true)
          summary += c.Text + " ";
      }
      MessageBox.Show(summary, "Summary");
    }
  }
}
