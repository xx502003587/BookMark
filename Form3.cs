using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMark {
    public partial class Form3 : Form {
        public Form3() {
            InitializeComponent();
        }

        public string typeName {
            get { return this.TypeNameText.Text; }
        }

        private void ButtonOk_Click(object sender, EventArgs e) {
            string msg;
            if (checkInput(out msg)) {
                this.DialogResult = DialogResult.OK;
            } else {
                MessageBox.Show(msg, "错误提示");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool checkInput(out string msg) {
            var name = this.TypeNameText.Text.Trim();
            if (name.Length == 0) {
                msg = "输入值不能为空，请重新输入";
                return false;
            }

            var utils = Utils.GetInstance();
            var fileNames = utils.files;
            if (fileNames.Exists(t => t == (name+".sav"))) {
                msg = "该类别已存在，请重新输入";
                return false;
            }
            msg = "";
            return true;
        }

        private void KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ButtonOk_Click(this.ButtonOk, null);
            }
        }
    }
}
