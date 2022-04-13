using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _021_ScoreCal
{
  public partial class Form1 : Form
  {
    TextBox[] titles;
    ComboBox[] crds;
    ComboBox[] grds;
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      textBox1.Text = "인체의구조와기능I";
      textBox2.Text = "일반수학I";
      textBox3.Text = "설계및프로젝트기본I";
      textBox4.Text = "자료구조";
      textBox5.Text = "비주얼프로그래밍";
      textBox6.Text = "기업가정신";
      textBox7.Text = "";

      titles = new TextBox[] {
        textBox1, textBox2, textBox3,textBox4,
        textBox5, textBox6, textBox7 };
      crds = new ComboBox[] {
        crd1, crd2, crd3, crd4, crd5, crd6, crd7};
      grds = new ComboBox[] {
        grd1, grd2, grd3, grd4, grd5, grd6, grd7 };
      int[] arrCredit = { 1, 2, 3, 4, 5 };
      List<string> listGrade = new List<string> {
        "A+","A0","B+","B0","C+","C0","D+","D0","F"};

      foreach(var cb in crds)
      {
        foreach(var c in arrCredit)
          cb.Items.Add(c);
        cb.SelectedItem = 3;
      }

      foreach(var cb in grds)
      {
        foreach (var gr in listGrade)
          cb.Items.Add(gr);
      }
    }

    private void btnCalc_Click(object sender, EventArgs e)
    {
      double totalScore = 0;
      int totalCredits = 0;

      for(int i=0; i < crds.Length; i++)
      {
        if (titles[i].Text != "")
        {
          int crd
            = int.Parse(crds[i].SelectedItem.ToString());
          totalCredits += crd;
          totalScore 
            += crd * GetGrade(grds[i].SelectedItem.ToString());
        }
      }
      txtResult.Text
        = (totalScore / totalCredits).ToString("0.00");
    }

    private double GetGrade(string v)
    {      
      if (v == "A+") return 4.5;
      else if (v == "A0") return 4.0;
      else if (v == "B0") return 3.5;
      else if (v == "B0") return 3.0;
      else if (v == "C+") return 2.5;
      else if (v == "C0") return 2.0;
      else if (v == "D+") return 1.5;
      else if (v == "D0") return 1.0;
      else return 0;
    }
  }
}
