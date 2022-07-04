using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _016_Label
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      label1.Text = "";
      label2.Text = "";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string munch = " 1863년 12월 12일 ~ 1944년 1월 23일)는 노르웨이 출신의 표현주의 화가";
      string history = "노르웨이에서는 국민적인 화가이다. 그의 초상이 1,000 크로네 지폐에도 그려져 있다." +
"처음에는 신(新)인상파의 영향을 받아 점묘의 수법을 사용하여 삶과 죽음에의 극적이고 내면적인 그림을 그렸다. 1892년 베를린으로 이주, 그곳의 미술 협회에 출품했다. 그는 나면서부터 몸이 약해 작품에도 그 영향이 드러나 있는데, 나치스는 퇴폐예술이라는 이유로 그의 그림을 몰수하기도 했다.작품으로<절규>, < 병든 소녀 > 등이 있다." +
"생과 죽음의 문제 그리고 인간 존재의 근원에 존재하는 고독, 질투, 불안 등을 응시하는 인물을, 인물화를 통해 표현했다. 표현주의적인 화풍의 화가로 알려져 있다.";

      label1.Text = munch;  
      label2.Text = history;        

    }
  }
}
