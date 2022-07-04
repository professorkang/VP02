using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _022_timer
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      label1.Font = new Font("맑은 고딕", 30, FontStyle.Bold);
      label1.ForeColor = Color.Blue;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      label1.Text = "";
      timer1.Interval = 1000;
      timer1.Tick += Timer1_Tick; // 이벤트 처리 함수 만드는 법
      timer1.Start();
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      label1.Location = new Point(
        ClientSize.Width / 2 - label1.Width / 2,
        ClientSize.Height / 2 - label1.Height / 2);
      label1.Text = DateTime.Now.ToString();
    }
  }
}
