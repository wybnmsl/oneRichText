using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 一个.model;

namespace 一个
{
    public partial class Form1 : Form
    {
        int pointY = -25;
        int musicplay = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void 图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicRichFomat richFomat = new PicRichFomat();
            richFomat.SetFormat(this.文本编辑区);
        }

        private void 音乐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            o.Title = "请选择音乐";
            o.Filter = "音频文件(&.mp3)|*.mp3";
            if (o.ShowDialog() == DialogResult.OK) {
                string fileName = o.FileName;
                this.文本编辑区.Controls.Add(CreateSoundPic(fileName));
            }
        }

        private PictureBox CreateSoundPic(string mediaPath) {
            pointY += 25;
            PictureBox picBox = new PictureBox();
            picBox.Location = new Point(this.文本编辑区.Location.X + 10, this.文本编辑区.Location.Y + pointY);
            picBox.Image = Image.FromFile(Application.StartupPath + "\\Images\\sound.png");
            picBox.SizeMode = PictureBoxSizeMode.AutoSize;
            /*picBox.Width = 20;
            picBox.Height = 20;*/
            picBox.Tag = mediaPath;
            picBox.Cursor = Cursors.Hand;
            picBox.Parent = this.文本编辑区;
            picBox.Click += new EventHandler(picBox_Click);
            return picBox;
        }

        private void picBox_Click(object sender, EventArgs e) {
            PictureBox pic = sender as PictureBox;

            MP3Player mp3 = new MP3Player();
            mp3.filepath = pic.Tag.ToString();
            if (musicplay == 0)
            {
                mp3.Play();
                musicplay = 1;
            }
            else {
                mp3.Stop();
                musicplay = 0;
            }
                
            

                

        }
    }
}
