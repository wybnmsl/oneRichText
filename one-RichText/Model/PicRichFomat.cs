using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace origin.Model
{
    class PicRichFomat{
        public void SetFormat(RichTextBox rtbInfo)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            o.Title = "请选择图片";
            o.Filter = "jpeg|*.jpeg|jpg|*.jpg|png|*.png|gif|*.gif";
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = o.FileName;
                try
                {
                    Image bmp = Image.FromFile(fileName);
                    Clipboard.SetDataObject(bmp);

                    DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (rtbInfo.CanPaste(dataFormat))
                    {
                        rtbInfo.Paste(dataFormat);
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show("图片插入失败。" + exc.Message, "提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            rtbInfo.Focus();
        }
    }
}
