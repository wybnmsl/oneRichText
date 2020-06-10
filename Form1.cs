using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace 一个
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            分区listView.View = View.List;
            知识库listView.View = View.List;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            分区InitListView(this.分区listView);
            知识库InitListView(this.知识库listView);
        }

        public ListView InsertListView(ListView lv)
        {
            //获取文本框中的值
            string name = "新分区";
            //创建行对象
            ListViewItem li = new ListViewItem(name);
            //添加同一行的数据
            //将行对象绑定在listview对象中
            lv.Items.Add(li);

            //MessageBox.Show("新增数据成功！");
            return lv;
        }

        public void 分区InitListView(ListView lv)
        {
    /*        //添加列名
            ColumnHeader c1 = new ColumnHeader();
            c1.Width = 200;
            c1.Text="分区";
           
            //设置属性
            //lv.GridLines = true;  //显示网格线
            lv.FullRowSelect = true;  //显示全行
            lv.MultiSelect = false;  //设置只能单选
            lv.View = View.Details;  //设置显示模式为详细
            //lv.HoverSelection = true;  //当鼠标停留数秒后自动选择
            //把列名添加到listview中
            lv.Columns.Add(c1);
          */
          
            
        }

        public void 知识库InitListView(ListView lv)
        {
            ColumnHeader c1 = new ColumnHeader();
            c1.Width = 200;
            c1.Text = "当前分区下知识库";

            //设置属性
            //lv.GridLines = true;  //显示网格线
            lv.FullRowSelect = true;  //显示全行
            lv.MultiSelect = false;  //设置只能单选
            lv.View = View.Details;  //设置显示模式为详细
            //lv.HoverSelection = true;  //当鼠标停留数秒后自动选择
            //把列名添加到listview中
            lv.Columns.Add(c1);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textpannel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
          /*  if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem tn = new ListViewItem(Path.GetDirectoryName(dlg.SelectedPath));
                tn.Name = Path.GetDirectoryName(dlg.SelectedPath);
                //分区listView.Items.Add(tn);
                分区LoadPath(dlg.SelectedPath, tn);
                // 如果路径为空，重新选择

            }*/
            dlg.SelectedPath = "C:\\Users\\acer\\Desktop\\txt";
            ListViewItem tn = new ListViewItem(Path.GetDirectoryName(dlg.SelectedPath));
            tn.Name = Path.GetDirectoryName(dlg.SelectedPath);
            分区LoadPath(dlg.SelectedPath, tn);
        }
        // 路径合法，添加到view的根目录
        // ListViewItem root = new ListViewItem(selectedPath);
        private void 分区LoadPath(string p, ListViewItem tn)
        {
            DirectoryInfo di = new DirectoryInfo(p);
            foreach (var item in di.GetDirectories())
            {
                ListViewItem tn1 = default(ListViewItem);
                try
                {
                    tn1 = new ListViewItem(Path.GetFileName(item.FullName));
                    分区listView.Items.Add(tn1);
                    //知识库LoadPath(item.FullName, tn1);
                }
                catch
                {
                    if (tn1 != null)
                        知识库listView.Items.Remove(tn1);
                }
                Application.DoEvents();
            }

            foreach (var txt in di.GetFiles("*.txt", SearchOption.TopDirectoryOnly))
            {
                ListViewItem tn2 = new ListViewItem(Path.GetFileName(txt.FullName));
                tn2.Tag = txt.FullName;
                知识库listView.Items.Add(tn2);
                // nodeList.Add(tn1);
                //treeView2.Nodes.Add(tn1);
            }
        }

        private void 知识库LoadPath(string p, ListViewItem tn)
        {
            DirectoryInfo di = new DirectoryInfo(p);
            foreach (var item in di.GetDirectories())
            {
                ListViewItem tn1 = default(ListViewItem);
                try
                {
                    tn1 = new ListViewItem(Path.GetFileName(item.FullName));
                    知识库listView.Items.Add(tn1);
                    //LoadPath(item.FullName, tn1);
                }
                catch
                {
                    if (tn1 != null)
                        知识库listView.Items.Remove(tn1);
                }
                Application.DoEvents();
            }

            foreach (var txt in di.GetFiles("*.txt", SearchOption.TopDirectoryOnly))
            {
                ListViewItem tn2 = new ListViewItem(Path.GetFileName(txt.FullName));
                tn2.Tag = txt.FullName;
                知识库listView.Items.Add(tn2);
                // nodeList.Add(tn1);
                //treeView2.Nodes.Add(tn1);
            }
        }


        private void 知识库刷新LoadPath(string p, ListViewItem tn)
        {
            DirectoryInfo di = new DirectoryInfo(p);

            foreach (var txt in di.GetFiles("*.txt", SearchOption.TopDirectoryOnly))
            {
                ListViewItem tn2 = new ListViewItem(Path.GetFileName(txt.FullName));
                tn2.Tag = txt.FullName;
                知识库listView.Items.Add(tn2);
                // nodeList.Add(tn1);
                //treeView2.Nodes.Add(tn1);
            }
        }
        private void LoadText(StringBuilder sb, string p)
        {
            
                            string s = File.ReadAllText(p);
                            sb.Append(s);
                            sb.Append("\r\n");                    
        }

        private void 分区listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (分区listView.SelectedItems.Count == 0) return;
            ListView li = (ListView)sender;
          
            string name = li.FocusedItem.Text;
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string path= "C:\\Users\\acer\\Desktop\\txt\\" + name;
            dlg.SelectedPath = path;

           
            ListViewItem tn = new ListViewItem(Path.GetDirectoryName(dlg.SelectedPath));
            知识库listView.Items.Clear();
            知识库刷新LoadPath(dlg.SelectedPath, tn);
        
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 知识库listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (知识库listView.SelectedItems.Count == 0) return;
            ListView livi = (ListView)sender;
            StringBuilder sb = new StringBuilder();
            string name = livi.FocusedItem.Tag.ToString();
          
         //   LoadText(sb,)

             LoadText(sb, name);
            文本编辑区.Text = sb.ToString();
        }

        private void 分区listView_Click(object sender, EventArgs e)
        {
          
        }
    }
}
