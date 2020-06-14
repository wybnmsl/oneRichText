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
using origin.Properties;
using 一个.Model;
using Microsoft.Data.Sqlite;
using trrrry;
using System.Security.Policy;

namespace origin
{

    public partial class Form1 : Form
    {
        //用作存储打开文本的路径
        public static string pname = @"./1.txt";
        //用作存储点击分区的路径
        public static string fenquname;
        //获得文件位置 wrz
        public static string rootpath;
        //储存右键菜单栏的位置 wrz
        public static string menupath;
        //日志类
        public Logger log;

        //新的部分
        private VirManager vir;
        private string copyNote, copyZone;



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
        #region 陈成瀚
        private void Form1_Load(object sender, EventArgs e)
        {
            vir = new VirManager();
            分区InitListView();

            //分区InitListView(this.分区listView);


            toolTip1.InitialDelay = 100;
            log = Logger.GetLogger();
            log.Info("启动程序");
        }

        public void 分区InitListView()
        {
            分区listView.Items.Clear();
            //打开指定文件位置
            foreach (String zone in vir.zones)
            {
                ListViewItem tn1 = default(ListViewItem);
                try
                {
                    tn1 = new ListViewItem(zone);
                    tn1.Tag = "分区";
                    分区listView.Items.Add(tn1);
                }
                catch (Exception)
                {
                    Console.WriteLine("出错了");
                }
            }
            分区listView.Update();
        }

        public void 知识库IniListView()
        {
            知识库listView.Items.Clear();
            vir.get_notes();
            foreach (string note in vir.noteNames)
            {
                ListViewItem tn1 = default(ListViewItem);
                try
                {
                    tn1 = new ListViewItem(note);
                    tn1.Tag = "知识库";
                    知识库listView.Items.Add(tn1);
                }
                catch (Exception)
                {
                    Console.WriteLine("出错了");
                }
            }
            知识库listView.Update();
        }
        private int get_max_id()
        {
            int num = vir.notes.Count;
            while (id_in_notes(num))
            {
                num++;
            }
            return num;
        }
        private bool id_in_notes(int a)
        {
            foreach (Note note in vir.notes)
            {
                if (note.id == a)
                    return true;
            }
            return false;

        }
        private bool is分区(string manupath)
        {
            if (manupath.Equals("分区"))
            {
                return true;
            }
            return false;

        }

        #endregion
        #region 黄启东
        //分区目录初始化
        public void 分区InitListView(ListView lv)
        {
            //打开指定文件位置
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.SelectedPath = rootpath + @"\" + "txt";
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



        //添加分区按钮监听事件hqd
        private void button1_Click_2(object sender, EventArgs e)
        {
            int Itemnumber = 分区listView.Items.Count + 1;
            string 分区名 = "新分区" + Itemnumber.ToString();
            while (vir.zones.Contains(分区名))
            {
                Itemnumber++;
                分区名 = "新分区" + Itemnumber;
            }
            string 知识库名 = "新知识库";
            Note newNote = new Note() { zone = 分区名, note = 知识库名, text = string.Empty, id = get_max_id() };
            vir.insert_db(newNote);
            vir.initial_zones();
            分区InitListView();
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

        private void 知识库刷新()
        {
            知识库IniListView();
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
                String path = e.LinkText.Substring(e.LinkText.LastIndexOf("File-") + 5);
                System.Diagnostics.Process.Start(path);
                log.Info("打开文件：" + path);
                return;
            }
            System.Diagnostics.Process.Start(e.LinkText);
            log.Info("打开链接：" + e.LinkText);


        }
        #endregion

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

            FileStream fb = new FileStream(pname, FileMode.Open);
            byte[] b = new Byte[fb.Length];
            fb.Read(b, 0, (int)fb.Length);
            fb.Close();
            vir.curCont = System.Text.Encoding.Default.GetString(b);
            vir.update_text(new Note() { zone = vir.curZone, note = vir.curNote, text = vir.curCont });
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
            rtbInfo.Update();
        }


        //分区点击状态更改事件，显示该分区下的知识库目录
        private void 分区listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (分区listView.SelectedItems.Count == 0) return;
            ListView li = (ListView)sender;
            vir.curZone = li.FocusedItem.Text;
            知识库IniListView();
        }


        private void store_string()
        {
            File.Create(pname).Close();
            FileStream fs = new FileStream(pname, FileMode.Open);
            byte[] byteArray = Encoding.Default.GetBytes(vir.curCont);
            fs.Write(byteArray, 0, vir.curCont.Length);
            fs.Close();
        }
        //知识库目录点击状态更改事件，显示该知识库文本
        private void 知识库listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (知识库listView.SelectedItems.Count == 0) return;
            ListView livi = (ListView)sender;
            StringBuilder sb = new StringBuilder();
            vir.curNote = livi.FocusedItem.Text;
            vir.get_content();
            store_string();
            OpenFromFile();
        }


        #region 导入导出功能
        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (分区listView.SelectedItems.Count == 0 || !is分区(menupath)) return;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt格式（*.txt）|*.txt|所有文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbInfo.Clear();
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        StringBuilder sb = new StringBuilder();
                        string filename = openFileDialog1.FileName;
                        string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filename);// 没有扩展名的文件名 “Default”
                        StreamReader st = new StreamReader(filename, Encoding.Default);
                        string str = st.ReadLine();
                        while (str != null)
                        {
                            sb.Append(str);
                            str = st.ReadLine();
                        }
                        Note note = new Note() { zone = vir.curZone, id = get_max_id(), text = sb.ToString(), note = fileNameWithoutExtension };
                        vir.insert_db(note);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件错误:" + ex.Message);
                }
            }
            知识库刷新();

        }

        #endregion


        //新建知识库
        private void 添加知识库button_Click(object sender, EventArgs e)
        {
            if (分区listView.SelectedItems.Count == 0) return;
            int Itemnumber = 知识库listView.Items.Count;
            string 新知识库 = "新知识库" + Itemnumber;
            while (vir.noteNames.Contains(新知识库))
            {
                Itemnumber++;
                新知识库 = "新知识库" + Itemnumber;
            }
            Note note1 = new Note { note = 新知识库, text = string.Empty, zone = vir.curZone, id = get_max_id() };
            vir.insert_db(note1);
            知识库刷新();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            ListView livi = (ListView)menu.SourceControl;
            //ToolStripItem toolStripItem = (ToolStripItem)livi.SelectedIndices;
            ListView.SelectedIndexCollection c = livi.SelectedIndices;
            if (livi.FocusedItem == null) return;
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
            if (is分区(menupath))
            {
                MessageBox.Show("不支持复制文件夹");
            }
            else
            {
                copyNote = vir.curNote;
                copyZone = vir.curZone;
                MessageBox.Show("复制文件成功");
            }
            COM = 1;
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            originpath = menupath;
            if (is分区(menupath))
            {
                MessageBox.Show("不支持剪切文件夹");
            }
            else
            {
                copyNote = vir.curNote;
                copyZone = vir.curZone;
                MessageBox.Show("复制剪切成功");
            }
            COM = 2;
        }


        private void 粘贴ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!is分区(menupath))
            {
                MessageBox.Show("粘贴失败，粘贴目标应该为文件夹");
            }
            else
            {
                if (COM == 1)
                {
                    Note note = new Note();
                    /*ControlFileClass.CopyFile(temppath, menupath, filename);*/
                    foreach (Note notee in vir.notes)
                    {
                        if (notee.note == copyNote & notee.zone == copyZone)
                        {
                            note.id = get_max_id();
                            note.text = notee.text;
                            note.zone = vir.curZone;
                            note.note = notee.note;
                            break;
                        }
                    }
                    if (note != null)
                    {
                        vir.insert_db(note);
                    }

                    COM = 0;
                }
                else if (COM == 2)
                {
                    vir.move(copyZone, copyNote, vir.curZone);
                    /*vir.update_zone()*/
                    /*ControlFileClass.MoveFile(temppath, menupath, filename);*/
                    COM = 0;
                }
                else
                {
                    MessageBox.Show("剪切板中没有任何文件");
                }

            }
            vir.initial_list();
            知识库刷新();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is分区(menupath))
            {
                vir.delete_zone_by_name(vir.curZone);
            }
            else
            {
                vir.delete_note_by_name(vir.curZone, vir.curNote);
            }
            vir.initial_zones();
            vir.initial_list();
            分区InitListView();
            知识库IniListView();

        }

        [Obsolete]
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is分区(menupath))
            {
                string str = Interaction.InputBox("请输入目标的名字", "重命名文件夹", "在这里输入", -1, -1);
                if (str.Length == 0)
                {
                    MessageBox.Show("没有输入,无效操作");
                    return;
                }
                if (vir.zones.Contains(str))//判断重命名是否和原名字相同
                {
                    MessageBox.Show("文件夹名不能相同或者重名，请重新输入");
                    return;
                }
                vir.update_zone(vir.curZone, str);
                vir.curZone = str;
                
            }
            else
            {
                string str = Interaction.InputBox("请输入目标的名字", "重命名文件", "在这里输入文件名,自动添加后缀", -1, -1);
                if (str.Length == 0)
                {
                    MessageBox.Show("没有输入,无效操作");
                    return;
                }
                if (vir.noteNames.Contains(str))//判断重命名是否和原名字相同
                {
                    MessageBox.Show("文件名不能相同或者重名，请重新输入");
                    return;
                }
                vir.update_note(vir.curZone, vir.curNote,str);
                vir.curNote = str;
            }
            vir.initial_list();
            vir.initial_zones();
            分区InitListView();
            知识库刷新();
        }

        private void 导出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                if (is分区(menupath))
                {
                    string zonepath = foldPath +@"/"+ vir.curZone;
                    Directory.CreateDirectory(zonepath);
                    foreach (Note note in vir.notes)
                    {
                        if (note.zone == vir.curZone)
                        {
                            string file = zonepath + @"/" + vir.curNote + ".txt";
                            StreamWriter sw = new StreamWriter(file);
                            sw.Write(note.text);
                            sw.Close();
                        }
                    }
                    MessageBox.Show("知识导出成功");
                }
                else
                {
                    foreach (Note note in vir.notes)
                    {
                        if (note.note == vir.curNote & note.zone == vir.curZone)
                        {
                            string file = foldPath + @"/" + vir.curNote + ".txt";
                            File.Create(file).Close();
                            StreamWriter sw = new StreamWriter(file);
                            sw.Write(note.text);
                            sw.Close();
                            MessageBox.Show("知识导出成功");
                        }
                    }
                }

            }
        }

        #endregion

        private void button1_Click_3(object sender, EventArgs e)
        {
            搜索结果listView.Items.Clear();
            string 搜索内容 = textBox1.Text;
            vir.initial_list();
            if (搜索内容 != null)
            {
                foreach (Note note in vir.notes)
                {
                    if (note.zone.Contains(搜索内容))
                    {
                        ListViewItem tn1 = default(ListViewItem);
                        try
                        {
                            tn1 = new ListViewItem("分区:" + note.zone);
                            tn1.Tag = note.zone;
                            搜索结果listView.Items.Add(tn1);
                        }
                        catch
                        {
                            if (tn1 != null)
                                搜索结果listView.Items.Remove(tn1);
                        }
                    }
                    if (note.note.Contains(搜索内容))
                    {
                        ListViewItem tn2 = default(ListViewItem);
                        try
                        {
                            tn2 = new ListViewItem("分区 " + note.zone + " 知识库:" + note.note);
                            tn2.Tag = note.zone + "?" + note.note;
                            搜索结果listView.Items.Add(tn2);
                        }
                        catch
                        {
                            if (tn2 != null)
                                搜索结果listView.Items.Remove(tn2);
                        }
                    }
                    if (note.text.Contains(搜索内容))
                    {
                        File.Create(pname).Close();
                        FileStream fs = new FileStream(pname, FileMode.Open);
                        fs.Write(Encoding.Default.GetBytes(note.text), 0, note.text.Length);
                        fs.Close();

                        StreamReader 文件内容 = new StreamReader(pname, Encoding.Default);
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
                                        tn3 = new ListViewItem("分区 " + note.zone + " 知识库 " + note.note + ": 第" + line + "行");
                                        tn3.Tag = note.zone + "?" + note.note;
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
                        文件内容.Close();
                    }
                }
            }
        }
        private void 聚焦列表(string 聚焦名, ListView 列表名)
        {
            ListViewItem foundItem = 列表名.FindItemWithText(聚焦名, true, 0);
            if (foundItem != null)
            {
                列表名.TopItem = foundItem;  //定位到该项
                foundItem.Focused = true;//没有先focus会跟前面 分区listView_SelectedIndexChanged 的代码出现产生异常
                foundItem.Selected = true;//目前只能是聚焦没办法选中
                /*分区listView_SelectedIndexChanged(分区listView,EventArgs.Empty);*/
            }
        }

        private void 搜索结果listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (搜索结果listView.SelectedItems.Count == 0) return;
            ListView livi = (ListView)sender;
            string type = livi.FocusedItem.Text;
            tabControl1.SelectedIndex = 0;
            if (type.Contains("分区:"))
            {
                聚焦列表(livi.FocusedItem.Tag.ToString(), this.分区listView);
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
                vir.curZone = livi.FocusedItem.Tag.ToString().Split("?".ToCharArray())[0];
                vir.curNote = livi.FocusedItem.Tag.ToString().Split("?".ToCharArray())[1];
                vir.get_content();
                store_string();
                OpenFromFile();
            }
        }

        #region 王荣正重构插入多媒体
        private void btnPicture_Click(object sender, EventArgs e)
        {
            PicRichFomat richFomat = new PicRichFomat();
            richFomat.SetFormat(this.rtbInfo);
        }

        private void btnFile_Click(object sender, EventArgs e)
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
                log.Info("插入文件：" + o.FileName);
            }
            else
            {
                log.Error("插入文件失败:未选择文件");
            }
        }

        private void btnMusic_Click(object sender, EventArgs e)
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
                log.Info("插入音乐：" + o.FileName);
            }
            else
            {
                log.Error("插入音乐失败:未选择音乐");
            }
        }

        #endregion

        #region 多媒体使用帮助说明显示
        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("保存", btnSave);
        }

        private void 插入图片_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("插入图片", btnPicture);
        }

        private void 插入音乐_MouseHover(object sender, EventArgs e)
        {
            toolTip3.Show("插入音乐", btnMusic);
        }

        private void 插入附件_MouseHover(object sender, EventArgs e)
        {
            toolTip4.Show("插入附件", btnFile);
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.Info("关闭程序");
        }
    }
}