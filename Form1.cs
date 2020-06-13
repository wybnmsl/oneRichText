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
using Microsoft.VisualBasic;
using System.Collections;

namespace origin
{
    
    public partial class Form1 : Form
    {
        //用作存储打开文本的路径
        public static string pname;
        //用作存储点击分区的路径
        public static string fenquname;
        //获得文件位置 wrz
        public static string rootpath;
        //储存右键菜单栏的位置 wrz
        public static string menupath;

        #region 覃宇
        int pointY = -25;
        int musicplay = 0;
        #endregion
        public Form1()
        {
            InitializeComponent();
            rootpath = Directory.GetCurrentDirectory();
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
            
            dlg.SelectedPath = rootpath+ @"\"+ "txt" ;
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


        #region 没有必要看
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        #endregion

        //添加分区按钮监听事件hqd
        private void button1_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.SelectedPath= rootpath + @"\" + "txt";
            //Directory.CreateDirectory(folder.SelectedPath);
            DirectoryInfo dir = new DirectoryInfo(folder.SelectedPath);
            int Itemnumber=分区listView.Items.Count+1;
            dir.CreateSubdirectory("新分区"+Itemnumber);
                      
            分区刷新(folder.SelectedPath);
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
                    tn1.Tag = item.FullName;
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
               
            }
        }

        private void 分区刷新(string p)
        {
            分区listView.Items.Clear();
            知识库listView.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(p);
            foreach (var item in di.GetDirectories())
            {
                ListViewItem tn1 = default(ListViewItem);
                try
                {
                    tn1 = new ListViewItem(Path.GetFileName(item.FullName));
                    tn1.Tag = item.FullName;
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
                try
                {                    
                    tn2.Tag = txt.FullName;
                    知识库listView.Items.Add(tn2);
                }
                catch
                {
                    if (tn2 != null)
                        知识库listView.Items.Remove(tn2);
                }
                Application.DoEvents();

            }
        }       

        private void 知识库刷新(string p)
        {
            知识库listView.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(p);

            foreach (var txt in di.GetFiles("*.txt", SearchOption.TopDirectoryOnly))
            {
                ListViewItem tn2 = new ListViewItem(Path.GetFileName(txt.FullName));
                try
                {
                    tn2.Tag = txt.FullName;
                    知识库listView.Items.Add(tn2);
                }
                catch
                {
                    if (tn2 != null)
                        知识库listView.Items.Remove(tn2);
                }
                Application.DoEvents();
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

        #region 覃宇音乐插入多媒体
        private void 图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicRichFomat richFomat = new PicRichFomat();
            richFomat.SetFormat(this.rtbInfo);
        }

        private void 文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            o.Title = "请选择文件";
            o.Filter = "文件|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = "<文件：http://File-" + o.FileName + " >\n";
                rtbInfo.AppendText(fileName);
                //this.rtbInfo.Controls.Add(CreateSoundPic(fileName));
            }
        }

       
        private void 音乐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            o.Title = "请选择音乐";
            o.Filter = "音频文件(&.mp3)|*.mp3";
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = "<音乐：http://Music-" + o.FileName + " >\n";
                rtbInfo.AppendText(fileName);
                //this.rtbInfo.Controls.Add(CreateSoundPic(fileName));
            }
        }

        private void rtbInfo_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText.LastIndexOf("Music-") != -1)
            {
                MP3Player mp3 = new MP3Player();
                mp3.filepath = e.LinkText.Substring(e.LinkText.LastIndexOf("Music-") + 6);
                if (musicplay == 0)
                {
                    mp3.Play();
                    musicplay = 1;
                    return;
                }
                else
                {
                    mp3.Stop();
                    musicplay = 0;
                    return;
                }
            }
            if (e.LinkText.LastIndexOf("File-") != -1)
            {
                System.Diagnostics.Process.Start(e.LinkText.Substring(e.LinkText.LastIndexOf("File-") + 5));
                return;
            }
            System.Diagnostics.Process.Start(e.LinkText);


        }
        #endregion

  /*      #region 覃宇CreateSoundPic
        private PictureBox CreateSoundPic(string mediaPath)
        {
            pointY += 25;
            PictureBox picBox = new PictureBox();
            picBox.Location = new Point(this.rtbInfo.Location.X + 10, this.rtbInfo.Location.Y + pointY);
            picBox.Image = Image.FromFile(Application.StartupPath + "\\Images\\sound.png");
            picBox.SizeMode = PictureBoxSizeMode.AutoSize;
            //picBox.Width = 20;
            //picBox.Height = 20;
            picBox.Tag = mediaPath;
            picBox.Cursor = Cursors.Hand;
            picBox.Parent = this.rtbInfo;
            picBox.Click += new EventHandler(picBox_Click);
            return picBox;
        }
        #endregion
    */

        #region 覃宇picBox_Click
  /*      private void picBox_Click(object sender, EventArgs e)
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
        }*/
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
          
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFromFile();
        }

        //分区点击状态更改事件，显示该分区下的知识库目录
        private void 分区listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (分区listView.SelectedItems.Count == 0) return;
            ListView li = (ListView)sender;
          
            string name = li.FocusedItem.Text;
            fenquname = li.FocusedItem.Tag.ToString();
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string path = rootpath + @"\" + "txt" + @"\" + name;
            dlg.SelectedPath = path;          

            知识库刷新(dlg.SelectedPath);
            
        }

        #region 分区目录点击事件备胎（鼠标单击）
        //分区目录鼠标点击事件
        private void 分区listView_MouseClick(object sender, MouseEventArgs e)
        {
           // if (分区listView.SelectedItems.Count == 0) return;
            ListView li = (ListView)sender;

            string name = li.FocusedItem.Text;
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string path = "C:\\Users\\acer\\Desktop\\txt\\" + name;
            dlg.SelectedPath = path;

            ListViewItem tn = new ListViewItem(Path.GetDirectoryName(dlg.SelectedPath));
            知识库listView.Items.Clear();
            知识库刷新LoadPath(dlg.SelectedPath, tn);
        }
        #endregion

        //知识库目录点击状态更改事件，显示该知识库文本
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

        #region 知识库目录点击事件备胎（鼠标单击）
        //知识库目录点击事件
        private void 知识库listView_MouseClick(object sender, MouseEventArgs e)
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
        #endregion

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter= "txt格式（*.txt）|*.txt|所有文件|*.*";
            openFileDialog1.RestoreDirectory = true;           

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fsname = System.IO.Path.GetFileName(openFileDialog1.FileName);
                FileStream fs = new FileStream(fenquname + "\\" + fsname, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                rtbInfo.Clear();
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {                                                
                        StreamReader st = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding("gb2312"));
                        string str = st.ReadLine();
                        while (str != null)
                        {
                            sw.Write(str);
                            rtbInfo.AppendText(str);
                            rtbInfo.AppendText("\n");
                            sw.Write("\r\n");
                            str = st.ReadLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件错误:" + ex.Message);
                }
                sw.Close();
                fs.Close();
            }
            知识库刷新(fenquname);
                          
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = pname;//设置保存的默认目录           
            saveFileDialog.Filter = "txt files(*.txt)|*.txt|all files(*.*)|*.*";
            saveFileDialog.FilterIndex = 1;//默认显示保存类型为TXT
            saveFileDialog.RestoreDirectory = true;           
            //fileName = saveFileDialog.FileName;
            //bFileNamed = true;           

               saveFileDialog.InitialDirectory = "D:\\";//设置保存的默认目录
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
               
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //新建知识库
        private void 添加知识库button_Click(object sender, EventArgs e)
        {
            int Itemnumber = 知识库listView.Items.Count;
            string txtname = fenquname + "\\新知识库" + Itemnumber + ".txt";
            FileStream fs = new FileStream(txtname, FileMode.Create, FileAccess.Write);
            //File.Create(txtname);
            fs.Close();      
            知识库刷新(fenquname);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            ListView livi = (ListView)menu.SourceControl;
            //ToolStripItem toolStripItem = (ToolStripItem)livi.SelectedIndices;
            ListView.SelectedIndexCollection c = livi.SelectedIndices;

            menupath = livi.FocusedItem.Tag.ToString();//wrz ::记录下在哪个item下


            //判断右键位置是否有item
            if (c.Count > 0)
            {
                //有item就正常显示右键菜单
            }
            //没有item就没有反应
            else
                e.Cancel = true;
        }

        #region 王荣正 右键菜单栏中所有功能

        public string originpath;
        public int COM = 0; 
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            originpath = menupath;
            if (ControlFileClass.IsFolder(menupath))
            {
                MessageBox.Show("不支持复制文件夹");
            }
            else
            {
                MessageBox.Show("复制文件成功");
            }
            COM = 1;

        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            originpath = menupath;
            if (ControlFileClass.IsFolder(menupath))
            {
                MessageBox.Show("不支持剪切文件夹");
            }
            else
            {
                MessageBox.Show("复制剪切成功");
            }
            COM = 2;
        }


        private void 粘贴ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!ControlFileClass.IsFolder(menupath))
            {
                MessageBox.Show("粘贴失败，粘贴目标应该为文件夹");
            }
            else
            {
                string filename = ControlFileClass.GetFileName(originpath);
                originpath = ControlFileClass.GetFolderPath(originpath);
                if (COM == 1)
                {
                    ControlFileClass.CopyFile(originpath, menupath, filename);
                    COM = 0;
                }
                else if (COM == 2)
                {
                    ControlFileClass.MoveFile(originpath, menupath, filename);
                    COM = 0;
                }
                else
                {
                    MessageBox.Show("剪切板中没有任何文件");
                }
                
            }
            知识库刷新(fenquname);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
               if (ControlFileClass.IsFolder(menupath))
                {
                    ControlFileClass.DeleteFolder(menupath);
                    分区刷新(rootpath + @"\" + "txt"); ;
                    MessageBox.Show("文件夹删除成功");
                }
                else
                {
                if (File.Exists(menupath))
                {                                        
                        File.Delete(menupath);
                        知识库刷新(fenquname);                   
                }
                }
              
        }

        
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ControlFileClass.IsFolder(menupath))
            {
                string str = Interaction.InputBox("请输入目标的名字", "重命名文件夹", "在这里输入", -1, -1);
                if (str.Length == 0)
                {
                    MessageBox.Show("没有输入,无效操作");
                    return ;
                }
                Directory.SetCurrentDirectory(rootpath + @"\" + "txt");
                if (ControlFileClass.GetFileName(menupath) == str )//判断重命名是否和原名字相同
                {
                    MessageBox.Show("文件夹名不能相同，请重新输入");
                    return;
                }
                ControlFileClass test = new ControlFileClass(rootpath + @"\" + "txt", false);
                ArrayList x = test.FileListName;
                foreach(String temp in x)
                {
                    if(temp == str)//判断重命名是否与其他文件夹重名
                    {
                        MessageBox.Show("已存在目标名文件夹，请重新输入");
                        return;
                    }
                }
                Directory.Move(ControlFileClass.GetFileName(menupath), str);//使用filename但是get的是folder
                Directory.SetCurrentDirectory(rootpath);
                分区刷新(rootpath + @"\" + "txt"); ;
            }
            else
            {
                string str = Interaction.InputBox("请输入目标的名字", "重命名文件", "在这里输入文件名,自动添加后缀", -1, -1);
                if (str.Length == 0)
                {
                    MessageBox.Show("没有输入,无效操作");
                    return;
                }
                string filename = ControlFileClass.GetFileName(menupath);
                string foldername = ControlFileClass.GetFileName(ControlFileClass.GetFolderPath(menupath));
                Directory.SetCurrentDirectory(rootpath + @"\" + "txt" + @"\" + foldername);
                if(filename == str + ".txt")//判断重命名是否和原名字相同
                {
                    MessageBox.Show("文件名不能相同，请重新输入");
                    return;
                }
                ControlFileClass test = new ControlFileClass(rootpath + @"\" + "txt" + @"\" + foldername, false);
                ArrayList x = test.FileListName;
                foreach (String temp in x)
                {
                    if (temp == str + ".txt")//判断重命名是否与其他文件重名
                    {
                        MessageBox.Show("已存在目标名文件，请重新输入");
                        return;
                    }
                }
                Directory.Move(filename, str + ".txt");//使用filename但是get的是folder
                Directory.SetCurrentDirectory(rootpath);
                知识库刷新(fenquname);
            }
            
        }

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            搜索结果listView.Items.Clear();
            string 搜索内容 = textBox1.Text;
            string 默认路径 = rootpath + @"\" + "txt";
            if (搜索内容 != null)
            {
                DirectoryInfo di = new DirectoryInfo(默认路径);
                foreach (var item in di.GetDirectories())
                {
                    if (item.Name.Contains( 搜索内容))
                    {
                        ListViewItem tn1 = default(ListViewItem);
                        try
                        {
                            tn1 = new ListViewItem("分区:"+Path.GetFileName(item.FullName));
                            tn1.Tag = item.Name;
                            搜索结果listView.Items.Add(tn1);
                        }
                        catch
                        {
                            if (tn1 != null)
                                搜索结果listView.Items.Remove(tn1);
                        }
                    }
                    Application.DoEvents();
                    DirectoryInfo 分区名 = new DirectoryInfo(item.FullName);
                    foreach(var 知识文件 in 分区名.GetFiles())
                    {
                        if (知识文件.Name.Contains(搜索内容))
                        {
                            ListViewItem tn2 = default(ListViewItem);
                            try
                            {
                                tn2 = new ListViewItem(" 知识库:" + Path.GetFileName(知识文件.FullName));
                                tn2.Tag = 分区名.Name+"?"+知识文件.Name;
                                搜索结果listView.Items.Add(tn2);
                            }
                            catch
                            {
                                if (tn2 != null)
                                    搜索结果listView.Items.Remove(tn2);
                            }
                        }
                        StreamReader 文件内容 = new StreamReader(知识文件.FullName, Encoding.UTF8);
                        string aLine;
                        // 控制while循环是否进行的变量，true打印文本，false跳出循环
                        int line = 1;
                        while (true)
                        {
                            
                            aLine = 文件内容.ReadLine();
                            // aline=null -> 文本读完了，那么控制量condition结合if语句 跳出循环
                            if (aLine == null)
                            {
                                break;
                            }
                            else
                            {
                                if (aLine.Contains(搜索内容))
                                {
                                    ListViewItem tn3 = default(ListViewItem);
                                    try
                                    {
                                        tn3 = new ListViewItem("  内容:" + Path.GetFileName(知识文件.FullName)+"第"+line+"行");
                                        tn3.Tag = 分区名.Name + "?" + 知识文件.Name+"?"+知识文件.FullName;
                                        搜索结果listView.Items.Add(tn3);
                                    }
                                    catch
                                    {
                                        if (tn3 != null)
                                            搜索结果listView.Items.Remove(tn3);
                                    }
                                }
                            }
                            line++;
                        }
                    }       
                }
            }
        }
        private void 聚焦列表(string 聚焦名,ListView 列表名)
        {
            ListViewItem foundItem = 列表名.FindItemWithText(聚焦名, true, 0);
            if (foundItem != null)
            {
                列表名.TopItem = foundItem;  //定位到该项
                foundItem.Focused=true;//没有先focus会跟前面 分区listView_SelectedIndexChanged 的代码出现产生异常
                foundItem.Selected = true;//目前只能是聚焦没办法选中
                /*分区listView_SelectedIndexChanged(分区listView,EventArgs.Empty);*/
            }
        }
       
        private void 搜索结果listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (搜索结果listView.SelectedItems.Count == 0) return;
            ListView livi = (ListView)sender;
            string type = livi.FocusedItem.Text;
            tabControl1.SelectedIndex=0;
            if (type.Contains("分区:"))
            {
                聚焦列表(livi.FocusedItem.Tag.ToString(),this.分区listView);
            }
            else if (type.Contains("知识库:"))
            {
                聚焦列表(livi.FocusedItem.Tag.ToString().Split("?".ToCharArray())[0], this.分区listView);
                聚焦列表(livi.FocusedItem.Tag.ToString().Split("?".ToCharArray())[1], this.知识库listView);
            }
            else
            {
                聚焦列表(livi.FocusedItem.Tag.ToString().Split("?".ToCharArray())[0], this.分区listView);
                聚焦列表(livi.FocusedItem.Tag.ToString().Split("?".ToCharArray())[1], this.知识库listView);
                string name = livi.FocusedItem.Tag.ToString().Split("?".ToCharArray())[2];
                pname = name;
                OpenFromFile();
            }


        }
    }
}
