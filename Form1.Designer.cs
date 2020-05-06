namespace BookMark
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.MenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddType = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemType = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemType_default = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSetting,
            this.ToolStripMenuItemType});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(747, 27);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // MenuItemSetting
            // 
            this.MenuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAddWebsite,
            this.MenuItemAddType});
            this.MenuItemSetting.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuItemSetting.Name = "MenuItemSetting";
            this.MenuItemSetting.Size = new System.Drawing.Size(59, 23);
            this.MenuItemSetting.Text = "设置";
            // 
            // MenuItemAddWebsite
            // 
            this.MenuItemAddWebsite.Name = "MenuItemAddWebsite";
            this.MenuItemAddWebsite.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.MenuItemAddWebsite.Size = new System.Drawing.Size(180, 40);
            this.MenuItemAddWebsite.Text = "添加网站";
            this.MenuItemAddWebsite.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.MenuItemAddWebsite.Click += new System.EventHandler(this.MenuItemAddWebsite_Click);
            // 
            // MenuItemAddType
            // 
            this.MenuItemAddType.Name = "MenuItemAddType";
            this.MenuItemAddType.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.MenuItemAddType.Size = new System.Drawing.Size(180, 40);
            this.MenuItemAddType.Text = "添加类别";
            this.MenuItemAddType.Click += new System.EventHandler(this.MenuItemAddType_Click);
            // 
            // ToolStripMenuItemType
            // 
            this.ToolStripMenuItemType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemType_default});
            this.ToolStripMenuItemType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ToolStripMenuItemType.Name = "ToolStripMenuItemType";
            this.ToolStripMenuItemType.Size = new System.Drawing.Size(59, 23);
            this.ToolStripMenuItemType.Text = "类别";
            // 
            // ToolStripMenuItemType_default
            // 
            this.ToolStripMenuItemType_default.Checked = true;
            this.ToolStripMenuItemType_default.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItemType_default.Name = "ToolStripMenuItemType_default";
            this.ToolStripMenuItemType_default.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.ToolStripMenuItemType_default.Size = new System.Drawing.Size(116, 38);
            this.ToolStripMenuItemType_default.Text = "默认";
            this.ToolStripMenuItemType_default.Click += new System.EventHandler(this.ToolStripMenuItemType_Click);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.AllowMerge = false;
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemUpdate,
            this.ToolStripMenuItemDelete});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // ToolStripMenuItemUpdate
            // 
            this.ToolStripMenuItemUpdate.Name = "ToolStripMenuItemUpdate";
            this.ToolStripMenuItemUpdate.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemUpdate.Text = "修改";
            this.ToolStripMenuItemUpdate.Click += new System.EventHandler(this.ToolStripMenuItemUpdate_Click);
            // 
            // ToolStripMenuItemDelete
            // 
            this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemDelete.Text = "删除";
            this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(747, 428);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "常用网站";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddWebsite;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUpdate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemType;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemType_default;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddType;
    }
}

