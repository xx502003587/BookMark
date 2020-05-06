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
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }

        public string UrlName {
            get {
                return UrlNameText.Text.Trim();
            }
            set {
                UrlNameText.Text = value;
            }
        }

        public string UrlValue {
            get {
                return UrlValueText.Text.Trim();
            }
            set {
                UrlValueText.Text = value;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ButtonOk_Click(object sender, EventArgs e) {
            if (checkInput()) {
                this.DialogResult = DialogResult.OK;
            } else {
                MessageBox.Show("输入值不能为空，请重新输入","错误提示");
            }
        }

        private bool checkInput() {
            var name = this.UrlNameText.Text.Trim();
            if (name.Length == 0) {
                return false;
            }
            var value = this.UrlValueText.Text.Trim();
            if (value.Length == 0) {
                return false;
            }
            return true;
        }

        private void KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ButtonOk_Click(this.ButtonOk, null);
            }
        }
    }
}
