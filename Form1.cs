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
using origin.Model;

namespace origin
{
    
    public partial class Form1 : Form
    {
        //用作存储打开文本的路径
        public static string pname;

        #region 覃宇
        int pointY = -25;
        int musicplay = 0;
        #endregion
        public Form1()
        {
            InitializeComponent();
            #region 黄启东
            分区listView.View = View.List;
            知识库listView.View = View.List;
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            分区InitListView(this.分区listView);
        }

        #region 黄启东
        //分区目录初始化
        public void 分区InitListView(ListView lv)
        {
            //打开指定文件位置
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
        #endregion

        #region 黄启东
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
        #endregion

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

        
        //添加分区按钮监听事件hqd
        private void button1_Click_2(object sender, EventArgs e)
        {
        /*    //打开指定文件位置
            FolderBrowserDialog dlg = new FolderBrowserDialog();
              if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              {
                  ListViewItem tn = new ListViewItem(Path.GetDirectoryName(dlg.SelectedPath));
                  tn.Name = Path.GetDirectoryName(dlg.SelectedPath);
                  //分区listView.Items.Add(tn);
                  分区LoadPath(dlg.SelectedPath, tn);
                  // 如果路径为空，重新选择

              }
              */
              
         /*   dlg.SelectedPath = "C:\\Users\\acer\\Desktop\\txt";
            ListViewItem tn = new ListViewItem(Path.GetDirectoryName(dlg.SelectedPath));
            tn.Name = Path.GetDirectoryName(dlg.SelectedPath);
            分区LoadPath(dlg.SelectedPath, tn);

            */
        }

        #region 黄启东分区LoadPath
        //获取知识库目录
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
        #endregion

        #region 黄启东知识库刷新LoadPath
        //获取分区下的知识库目录
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
        #endregion

        #region 黄启东LoadText获取文本
        //获取文本
        private void LoadText(StringBuilder sb, string p)
        {
            string s = File.ReadAllText(p);
            sb.Append(s);
            sb.Append("\r\n");
        }
        #endregion

        private void 图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicRichFomat richFomat = new PicRichFomat();
            richFomat.SetFormat(this.rtbInfo);
        }

        #region 覃宇音乐ToolStripMenuItem_Click
        private void 音乐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            o.Title = "请选择音乐";
            o.Filter = "音频文件(&.mp3)|*.mp3";
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = o.FileName;
                this.rtbInfo.Controls.Add(CreateSoundPic(fileName));
            }
        }
        #endregion

        #region 覃宇CreateSoundPic
        private PictureBox CreateSoundPic(string mediaPath)
        {
            pointY += 25;
            PictureBox picBox = new PictureBox();
            picBox.Location = new Point(this.rtbInfo.Location.X + 10, this.rtbInfo.Location.Y + pointY);
            picBox.Image = Image.FromFile(Application.StartupPath + "\\Images\\sound.png");
            picBox.SizeMode = PictureBoxSizeMode.AutoSize;
            /*picBox.Width = 20;
            picBox.Height = 20;*/
            picBox.Tag = mediaPath;
            picBox.Cursor = Cursors.Hand;
            picBox.Parent = this.rtbInfo;
            picBox.Click += new EventHandler(picBox_Click);
            return picBox;
        }
        #endregion

        #region 覃宇picBox_Click
        private void picBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            MP3Player mp3 = new MP3Player();
            mp3.filepath = pic.Tag.ToString();
            if (musicplay == 0)
            {
                mp3.Play();
                musicplay = 1;
            }
            else
            {
                mp3.Stop();
                musicplay = 0;
            }
        }
        #endregion

        public void btnButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            BTNType btnType;
            if (Enum.TryParse<BTNType>(btn.Tag.ToString(), out btnType))
            {
                if (btnType == BTNType.Search)
                {
                    if (!string.IsNullOrEmpty(this.txtSearch.Text.Trim()))
                    {
                        this.rtbInfo.Tag = this.txtSearch.Text.Trim();
                    }
                    else
                    {
                        return;
                    }

                }
                IRichFormat richFomat = RichFormatFactory.CreateRichFormat(btnType);
                richFomat.SetFormat(this.rtbInfo);
            }
        }

        private void combFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fsize = 12.0f;
            if (combFontSize.SelectedIndex > -1)
            {
                if (float.TryParse(combFontSize.SelectedItem.ToString(), out fsize))
                {
                    rtbInfo.Tag = fsize.ToString();
                    IRichFormat richFomat = RichFormatFactory.CreateRichFormat(BTNType.FontSize);
                    richFomat.SetFormat(this.rtbInfo);
                }
                return;
            }
        }

       
        private void rtbInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void SaveToFile()
        {
            //saveFileDialog.InitialDirectory = pname;//设置保存的默认目录
            saveFileDialog.FileName = pname;
            saveFileDialog.Filter = "txt files(*.txt)|*.txt|all files(*.*)|*.*";
            saveFileDialog.FilterIndex = 1;//默认显示保存类型为TXT
            saveFileDialog.RestoreDirectory = true;
            rtbInfo.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            //fileName = saveFileDialog.FileName;
            //bFileNamed = true;
            this.Text = saveFileDialog.FileName + " ";

            /*   saveFileDialog.InitialDirectory = "D:\\";//设置保存的默认目录
               saveFileDialog.Filter = "txt files(*.txt)|*.txt|all files(*.*)|*.*";
               saveFileDialog.FilterIndex = 1;//默认显示保存类型为TXT
               saveFileDialog.RestoreDirectory = true;
               if (saveFileDialog.ShowDialog() == DialogResult.OK)
               {
                   rtbInfo.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                   //fileName = saveFileDialog.FileName;
                   //bFileNamed = true;
                   this.Text = saveFileDialog.FileName + " ";
               }
               */
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void OpenFromFile()
        {
            openFileDialog.Filter = "txt格式（*.txt）|*.txt|所有文件|*.*";
            openFileDialog.Title = "打开";
            openFileDialog.FileName = pname;
            rtbInfo.Clear();
            rtbInfo.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            //rtbInfo.MdiParent = this;
            rtbInfo.Show();

            /*   if (openFileDialog.ShowDialog() == DialogResult.OK)
               {

                   rtbInfo.Text = openFileDialog.FileName;
                   rtbInfo.Clear();
                   rtbInfo.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                   //rtbInfo.MdiParent = this;
                   rtbInfo.Show();

                  // printDocument1.DocumentName = openFileDialog.FileName;
               }
               */
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFromFile();
        }

        //分区点击时间，显示该分区下的知识库目录
        private void 分区listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (分区listView.SelectedItems.Count == 0) return;
            ListView li = (ListView)sender;

            string name = li.FocusedItem.Text;
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string path = "C:\\Users\\acer\\Desktop\\txt\\" + name;
            dlg.SelectedPath = path;          

            ListViewItem tn = new ListViewItem(Path.GetDirectoryName(dlg.SelectedPath));
            知识库listView.Items.Clear();
            知识库刷新LoadPath(dlg.SelectedPath, tn);
        }

        //知识库目录点击事件，显示该知识库文本
        private void 知识库listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (知识库listView.SelectedItems.Count == 0) return;
            ListView livi = (ListView)sender;
            StringBuilder sb = new StringBuilder();
            string name = livi.FocusedItem.Tag.ToString();
            //   LoadText(sb,)
            pname = name;

            OpenFromFile();
            //LoadText(sb, name);
            //rtbInfo.Text = sb.ToString();
        }
    }
}
