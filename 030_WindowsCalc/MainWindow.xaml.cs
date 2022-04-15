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

namespace _030_WindowsCalc
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private bool opFlag;
    private double saved;
    private string op;
    private bool afterCalc;
    private double memory;
    private bool memFlag;

    public MainWindow()
    {
      InitializeComponent();

      btnMC.IsEnabled = false;
      btnMR.IsEnabled = false;
    }

    private void btn_Click(object sender, RoutedEventArgs e)
    {
      Button btn = (Button)sender; // sender as Buuton;
      string s = btn.Content.ToString();

      if (txtResult.Text == "0" || opFlag == true ||
        afterCalc == true || memFlag == true)
      {
        txtResult.Text = s;
        opFlag = false;
        afterCalc = false;
        memFlag = false;
      }
      else
        txtResult.Text += s;
    }

    // 소수점 버튼
    private void btnDot_Click(object sender, RoutedEventArgs e)
    {
      if (txtResult.Text.Contains("."))
        return;
      else
        txtResult.Text += ".";
    }

    // +- 버튼
    private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = 
        (-1 * double.Parse(txtResult.Text)).ToString();
    }

    // +-*/
    private void op_Click(object sender, RoutedEventArgs e)
    {
      Button btn = (Button)sender;
      string s = btn.Content.ToString();
      txtExp.Text = txtResult.Text + s;

      opFlag = true;
      saved = double.Parse(txtResult.Text);
      op = s;
    }

    // = 버튼
    private void btnEqual_Click(object sender, RoutedEventArgs e)
    {
      double v = double.Parse(txtResult.Text);
      txtExp.Text += txtResult.Text + "=";

      switch(op)
      {
        case "+":
          txtResult.Text = (saved+v).ToString();
          break;
        case "-":
          txtResult.Text = (saved - v).ToString();
          break;
        case "×":
          txtResult.Text = (saved * v).ToString();
          break;
        case "÷":
          txtResult.Text = (saved / v).ToString();
          break;
        default:
          break;
      }
      afterCalc = true;
    }

    // % 버튼
    private void btnPercent_Click(object sender, RoutedEventArgs e)
    {
      double p = double.Parse(txtResult.Text);
      p = saved * p / 100;
      txtResult.Text = p.ToString();
      txtExp.Text = "";
    }

    // 제곱근
    private void btnSqrt_Click(object sender, RoutedEventArgs e)
    {
      if(txtExp.Text == "")
        txtExp.Text = "√(" + txtResult.Text + ")";
      else
        txtExp.Text = "√(" + txtExp.Text + ")";

      txtResult.Text = 
        (Math.Sqrt( double.Parse(txtResult.Text))).ToString();
    }

    // 제곱 버튼
    private void btnSqr_Click(object sender, RoutedEventArgs e)
    {
      if (txtExp.Text == "")
        txtExp.Text = "sqr(" + txtResult.Text + ")";
      else
        txtExp.Text = "sqr(" + txtExp.Text + ")";

      double v = double.Parse(txtResult.Text);
      txtResult.Text = (v*v).ToString();
        
    }

    // 1/x 버튼
    private void btnRecip_Click(object sender, RoutedEventArgs e)
    {
      if (txtExp.Text == "")
        txtExp.Text = "1/(" + txtResult.Text + ")";
      else
        txtExp.Text = "1/(" + txtExp.Text + ")";

      double v = double.Parse(txtResult.Text);
      txtResult.Text = (1/v).ToString();
    }

    private void btnCE_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = "";
    }

    private void btnC_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = "0";
      txtExp.Text = "";
      saved = 0;
      op = "";
      opFlag = false;
      afterCalc = false;
    }

    // Delete 버튼
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text 
        = txtResult.Text.Remove(txtResult.Text.Length - 1);
      if (txtResult.Text.Length == 0)
        txtResult.Text = "0";
    }

    // MS
    private void btnMS_Click(object sender, RoutedEventArgs e)
    {
      memory = double.Parse(txtResult.Text);
      btnMR.IsEnabled = true;
      btnMC.IsEnabled = true;
      memFlag = true;
    }

    // MR
    private void btnMR_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = memory.ToString();
      memFlag = true;
    }

    // MC
    private void btnMC_Click(object sender, RoutedEventArgs e)
    {
      memory = 0;
      btnMC.IsEnabled = false;
      btnMR.IsEnabled = false;
    }

    // M+
    private void btnMPlus_Click(object sender, RoutedEventArgs e)
    {
      memory += double.Parse(txtResult.Text);
    }

    private void btnMMinus_Click(object sender, RoutedEventArgs e)
    {
      memory -= double.Parse(txtResult.Text);
    }
  }
}
