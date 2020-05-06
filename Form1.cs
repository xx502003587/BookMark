using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMark {
    public partial class Form1 : Form {
        private Utils utils;
        // 当前界面上的书签Button实例
        private Dictionary<int, Button> buttonIns;
        private ToolStripMenuItem currentCheckedType;
        public Form1() {
            InitializeComponent();
            buttonIns = new Dictionary<int, Button>();
            currentCheckedType = ToolStripMenuItemType_default;
            this.Text = "常用网站——默认";
            this.Load += new EventHandler(Form1_Load);
        }
        /// <summary>
        /// 程序启动后自动调用的方法
        /// 1. 初始化utils
        /// 2. 进行界面的绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e) {
            utils = Utils.GetInstance();
            this.drawButtons();
            this.drawToolStripMenuItem();
        }
        /// <summary>
        /// 根据所有的书签信息在界面上绘制按钮，并为按钮添加点击事件
        /// </summary>
        private void drawButtons() {
            var books = utils.books[utils.type];
            int bookNumber = utils.GetCurrentBooksCount();
            for (int i = 0; i < bookNumber; ++i) {
                Button btn = new Button();
                SetBtnAttribute(ref btn, books[i].id, books[i].urlName,
                                new Point(books[i].posX, books[i].posY));
                this.buttonIns.Add(books[i].id, btn);
                this.Controls.Add(btn);
            }
        }
        /// <summary>
        /// 根据所有的书签信息在菜单栏绘制菜单选项，并添加点击事件
        /// </summary>
        private void drawToolStripMenuItem() {
            var files = utils.files;
            var count = files.Count();
            if (count == 1) {
                return;
            }
            for (int i = 1; i < count; ++i) {
                ToolStripMenuItem type = new ToolStripMenuItem();
                var typeName = files[i].Split('.')[0];
                type.Name = "ToolStripMenuItemType_" + typeName;
                type.Text = typeName;
                type.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
                type.Click += new System.EventHandler(this.ToolStripMenuItemType_Click);
                this.ToolStripMenuItemType.DropDownItems.Add(type);
            }
        }

        /// <summary>
        /// “添加书签”点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddWebsite_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.CenterScreen;
            if (form2.ShowDialog() == DialogResult.OK) {
                int newPosX = 0, newPosY = 0, newId = 0;
                bool result = utils.AddBookMark(form2.UrlName, form2.UrlValue, out newId, out newPosX, out newPosY);
                if (result) {
                    Button btn = new Button();
                    SetBtnAttribute(ref btn, newId, form2.UrlName,
                                new Point(newPosX, newPosY));
                    this.buttonIns.Add(newId, btn);
                    this.Controls.Add(btn);
                }
            }
        }
        private void SetBtnAttribute(ref Button btn, int id, string text, Point point) {
            btn.Name = "bookmark_" + id;
            btn.Text = text;
            btn.Width = utils.width;
            btn.Height = utils.height;
            btn.Location = point;
            btn.Font = new Font("宋体", 14);
            btn.MouseDown += new MouseEventHandler(BtnMouseDown);
        }
        /// <summary>
        ///  鼠标在按钮上点击后的处理事件
        ///  左键单击——打开页面
        ///  右键单击——弹出右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMouseDown(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            int urlId;
            int.TryParse(btn.Name.Split('_')[1], out urlId);
            if (e.Button == MouseButtons.Right) {
                //MessageBox.Show("右键");
                this.ToolStripMenuItemUpdate.Name = "ToolStripMenuItemUpdate_" + urlId;
                this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete_" + urlId;
                Point _Point = ContextMenuStrip.PointToClient(Cursor.Position);
                ContextMenuStrip.Show(MousePosition.X, MousePosition.Y);
            } else {
                //调用系统默认的浏览器 
                try {
                    System.Diagnostics.Process.Start(utils.books[utils.type][urlId].urlValue);
                } catch (Exception e1) {
                    Console.WriteLine("Exception caught: {0}", e1);
                    MessageBox.Show("该书签的网址错误，无法打开，请更正后再试", "错误");
                }
            }
        }
        /// <summary>
        ///  右键菜单点击修改后，弹出对应按钮的数据信息，修改后进行文件更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemUpdate_Click(object sender, EventArgs e) {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            int id;
            int.TryParse(toolStripMenuItem.Name.Split('_')[1], out id);
            var books = utils.books[utils.type];
            
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.UrlName = books[id].urlName;
            form2.UrlValue = books[id].urlValue;

            if (form2.ShowDialog() == DialogResult.OK) {
                if (!utils.IsTextModified(books[id].urlName, books[id].urlValue,
                                         form2.UrlName, form2.UrlValue)) {
                    return;
                }
                // 如果内容发生了变化，则进行数据更新
                var tbook = books[id];
                books.RemoveAt(id);
                tbook.urlName = form2.UrlName.Trim();
                tbook.urlValue = form2.UrlValue.Trim();
                books.Add(tbook);
                // 更新文件
                utils.WriteDataToFileByType();
            }
        }
        /// <summary>
        ///  右键菜单点击“删除”后，删除对应的书签
        ///  对books对象的id和pos进行更新，进行文件更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e) {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            int id;
            int.TryParse(toolStripMenuItem.Name.Split('_')[1], out id);
            var books = utils.books[utils.type];
            // 1. 从界面上删除所有按钮
            this.removeAllBtns();

            // 2. 从utils的books中删除对象
            utils.RemoveBookMarkById(id);

            // 3. 对utils的books中的对象的id和pos进行更新
            utils.ReGenerateBooksIdAndPos();

            // 4. 重新绘制当前界面上的按钮
            this.drawButtons();

            // 5. 将utils的books的的对象写入文件
            utils.WriteDataToFileByType();
        }


        /// <summary>
        ///  “设置”菜单栏中选择“新增类别”时，添加类别信息，更新文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddType_Click(object sender, EventArgs e) {
            Form3 form3 = new Form3();
            form3.StartPosition = FormStartPosition.CenterScreen;

            if (form3.ShowDialog() == DialogResult.OK) {
                var typeName = form3.typeName;
                // 1. 添加菜单项
                ToolStripMenuItem type = new ToolStripMenuItem();
                type.Name = "ToolStripMenuItemType_" + typeName;
                type.Text = typeName;
                type.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
                type.Click += new System.EventHandler(this.ToolStripMenuItemType_Click);
                this.ToolStripMenuItemType.DropDownItems.Add(type);

                // 2. 清除界面上的按钮及其实体
                this.removeAllBtns();

                // 4. 将新的类别信息写入文件
                this.utils.AddType(typeName);

                // 3. 将菜单中的类别进行自动切换，调用菜单选项的点击
                ToolStripMenuItemType_Click(type, null);
            }
        }
        /// <summary>
        ///  “类别”菜单中选择一项类别后，修改菜单单选条目，更新界面按钮，更新程序名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemType_Click(object sender, EventArgs e) {
            // 1. 修改菜单的选中状态
            this.currentCheckedType.Checked = false;
            var itemType = (ToolStripMenuItem)sender;
            itemType.Checked = true;
            this.currentCheckedType = itemType;

            // 2. 将当前的类别值进行更换
            if (itemType.Text == "默认") {
                utils.type = "default";
            } else {
                utils.type = itemType.Text;
            }
            
            // 3. 清除界面上的按钮及其实体
            this.removeAllBtns();

            // 4. 绘制按钮
            this.drawButtons();

            // 5. 修改程序名称，显示当前类别的名字
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            this.Text = "常用网站——" + toolStripMenuItem.Text;
            Console.WriteLine("DEBUG");
        }
        

        private void removeAllBtns() {
            foreach (var btn in this.buttonIns) {
                this.Controls.Remove(btn.Value);
            }
            this.buttonIns.Clear();
            GC.Collect();
        }
    }
}
