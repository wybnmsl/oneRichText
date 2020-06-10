namespace 一个
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.上菜单栏menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.插入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.音乐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分区知识库tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.分区listView = new System.Windows.Forms.ListView();
            this.知识库listView = new System.Windows.Forms.ListView();
            this.添加分区button = new System.Windows.Forms.Button();
            this.添加知识库button = new System.Windows.Forms.Button();
            this.文本编辑区 = new System.Windows.Forms.RichTextBox();
            this.上菜单栏menuStrip.SuspendLayout();
            this.分区知识库tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // 上菜单栏menuStrip
            // 
            this.上菜单栏menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.上菜单栏menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.开始ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.插入ToolStripMenuItem});
            this.上菜单栏menuStrip.Location = new System.Drawing.Point(0, 0);
            this.上菜单栏menuStrip.Name = "上菜单栏menuStrip";
            this.上菜单栏menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.上菜单栏menuStrip.Size = new System.Drawing.Size(1005, 25);
            this.上菜单栏menuStrip.TabIndex = 0;
            this.上菜单栏menuStrip.Text = "menuStrip1";
            this.上菜单栏menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.新建ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导入ToolStripMenuItem.Text = "导入";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.粘贴ToolStripMenuItem});
            this.开始ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 插入ToolStripMenuItem
            // 
            this.插入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem1,
            this.图片ToolStripMenuItem,
            this.音乐ToolStripMenuItem});
            this.插入ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.插入ToolStripMenuItem.Name = "插入ToolStripMenuItem";
            this.插入ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.插入ToolStripMenuItem.Text = "插入";
            // 
            // 文件ToolStripMenuItem1
            // 
            this.文件ToolStripMenuItem1.Name = "文件ToolStripMenuItem1";
            this.文件ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.文件ToolStripMenuItem1.Text = "文件";
            // 
            // 图片ToolStripMenuItem
            // 
            this.图片ToolStripMenuItem.Name = "图片ToolStripMenuItem";
            this.图片ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.图片ToolStripMenuItem.Text = "图片";
            this.图片ToolStripMenuItem.Click += new System.EventHandler(this.图片ToolStripMenuItem_Click);
            // 
            // 音乐ToolStripMenuItem
            // 
            this.音乐ToolStripMenuItem.Name = "音乐ToolStripMenuItem";
            this.音乐ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.音乐ToolStripMenuItem.Text = "音乐";
            this.音乐ToolStripMenuItem.Click += new System.EventHandler(this.音乐ToolStripMenuItem_Click);
            // 
            // 分区知识库tableLayout
            // 
            this.分区知识库tableLayout.BackColor = System.Drawing.Color.Silver;
            this.分区知识库tableLayout.ColumnCount = 2;
            this.分区知识库tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.分区知识库tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.分区知识库tableLayout.Controls.Add(this.label1, 0, 0);
            this.分区知识库tableLayout.Controls.Add(this.label2, 1, 0);
            this.分区知识库tableLayout.Controls.Add(this.分区listView, 0, 1);
            this.分区知识库tableLayout.Controls.Add(this.知识库listView, 1, 1);
            this.分区知识库tableLayout.Controls.Add(this.添加分区button, 0, 2);
            this.分区知识库tableLayout.Controls.Add(this.添加知识库button, 1, 2);
            this.分区知识库tableLayout.Dock = System.Windows.Forms.DockStyle.Left;
            this.分区知识库tableLayout.Location = new System.Drawing.Point(0, 25);
            this.分区知识库tableLayout.Name = "分区知识库tableLayout";
            this.分区知识库tableLayout.RowCount = 3;
            this.分区知识库tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.861456F));
            this.分区知识库tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.13854F));
            this.分区知识库tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.分区知识库tableLayout.Size = new System.Drawing.Size(371, 562);
            this.分区知识库tableLayout.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "分区";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(188, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "知识库";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 分区listView
            // 
            this.分区listView.BackColor = System.Drawing.Color.Gainsboro;
            this.分区listView.HideSelection = false;
            this.分区listView.Location = new System.Drawing.Point(3, 33);
            this.分区listView.Name = "分区listView";
            this.分区listView.Size = new System.Drawing.Size(179, 486);
            this.分区listView.TabIndex = 2;
            this.分区listView.UseCompatibleStateImageBehavior = false;
            // 
            // 知识库listView
            // 
            this.知识库listView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.知识库listView.HideSelection = false;
            this.知识库listView.Location = new System.Drawing.Point(188, 33);
            this.知识库listView.Name = "知识库listView";
            this.知识库listView.Size = new System.Drawing.Size(180, 486);
            this.知识库listView.TabIndex = 3;
            this.知识库listView.UseCompatibleStateImageBehavior = false;
            // 
            // 添加分区button
            // 
            this.添加分区button.BackColor = System.Drawing.Color.DimGray;
            this.添加分区button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.添加分区button.ForeColor = System.Drawing.Color.FloralWhite;
            this.添加分区button.Location = new System.Drawing.Point(3, 525);
            this.添加分区button.Name = "添加分区button";
            this.添加分区button.Size = new System.Drawing.Size(179, 34);
            this.添加分区button.TabIndex = 4;
            this.添加分区button.Text = "添加分区";
            this.添加分区button.UseVisualStyleBackColor = false;
            this.添加分区button.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // 添加知识库button
            // 
            this.添加知识库button.BackColor = System.Drawing.Color.DimGray;
            this.添加知识库button.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.添加知识库button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.添加知识库button.Location = new System.Drawing.Point(188, 525);
            this.添加知识库button.Name = "添加知识库button";
            this.添加知识库button.Size = new System.Drawing.Size(180, 34);
            this.添加知识库button.TabIndex = 5;
            this.添加知识库button.Text = "添加知识库";
            this.添加知识库button.UseVisualStyleBackColor = false;
            // 
            // 文本编辑区
            // 
            this.文本编辑区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.文本编辑区.Location = new System.Drawing.Point(371, 25);
            this.文本编辑区.Name = "文本编辑区";
            this.文本编辑区.Size = new System.Drawing.Size(634, 562);
            this.文本编辑区.TabIndex = 13;
            this.文本编辑区.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1005, 587);
            this.Controls.Add(this.文本编辑区);
            this.Controls.Add(this.分区知识库tableLayout);
            this.Controls.Add(this.上菜单栏menuStrip);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.上菜单栏menuStrip;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "Mynote";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.上菜单栏menuStrip.ResumeLayout(false);
            this.上菜单栏menuStrip.PerformLayout();
            this.分区知识库tableLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip 上菜单栏menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 插入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 音乐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel 分区知识库tableLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView 分区listView;
        private System.Windows.Forms.ListView 知识库listView;
        private System.Windows.Forms.Button 添加分区button;
        private System.Windows.Forms.Button 添加知识库button;
        private System.Windows.Forms.RichTextBox 文本编辑区;
    }
}

