using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _020_listBox
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      listBox2.Items.Add("뉴질랜드, 오클랜드");
      listBox2.Items.Add("일본, 오사카");
      listBox2.Items.Add("호주, 아델레이드");
      listBox2.Items.Add("뉴질랜드, 오클랜드");
      listBox2.Items.Add("일본, 오사카");
      listBox2.Items.Add("호주, 아델레이드");
      listBox2.Items.Add("뉴질랜드, 오클랜드");
      listBox2.Items.Add("일본, 오사카");
      listBox2.Items.Add("호주, 아델레이드");
      listBox2.Items.Add("호주, 아델레이드");

      List<string> happiness = new List<string>{
        "핀란드", "덴마트", "아이슬란드", "스위스",
        "네덜란드", "룩셈부르크", "스웨덴", "노르웨이",
        "이스라엘", "뉴질랜드" };
      listBox3.DataSource = happiness;
    }

    // 이벤트 처리 메소드
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListBox lst = sender as ListBox;
      txtSIndex1.Text = lst.SelectedIndex.ToString();
      txtSItem1.Text = lst.SelectedItem.ToString();
    }

    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListBox l = sender as ListBox;
      txtSIndex2.Text = l.SelectedIndex.ToString();
      txtSItem2.Text = l.SelectedItem.ToString();
    }

    private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListBox l = sender as ListBox;
      txtSIndex3.Text = l.SelectedIndex.ToString();
      txtSItem3.Text = l.SelectedItem.ToString();
    }
  }
}
