namespace BookMark {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.UrlNameLabel = new System.Windows.Forms.Label();
            this.UrlNameText = new System.Windows.Forms.TextBox();
            this.UrlValueText = new System.Windows.Forms.TextBox();
            this.UrlValueLabel = new System.Windows.Forms.Label();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UrlNameLabel
            // 
            this.UrlNameLabel.AutoSize = true;
            this.UrlNameLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UrlNameLabel.Location = new System.Drawing.Point(45, 37);
            this.UrlNameLabel.Name = "UrlNameLabel";
            this.UrlNameLabel.Size = new System.Drawing.Size(115, 21);
            this.UrlNameLabel.TabIndex = 0;
            this.UrlNameLabel.Text = "网页名称：";
            // 
            // UrlNameText
            // 
            this.UrlNameText.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UrlNameText.Location = new System.Drawing.Point(159, 34);
            this.UrlNameText.Name = "UrlNameText";
            this.UrlNameText.Size = new System.Drawing.Size(250, 31);
            this.UrlNameText.TabIndex = 1;
            // 
            // UrlValueText
            // 
            this.UrlValueText.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UrlValueText.Location = new System.Drawing.Point(159, 92);
            this.UrlValueText.Multiline = true;
            this.UrlValueText.Name = "UrlValueText";
            this.UrlValueText.Size = new System.Drawing.Size(250, 126);
            this.UrlValueText.TabIndex = 3;
            this.UrlValueText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown);
            // 
            // UrlValueLabel
            // 
            this.UrlValueLabel.AutoSize = true;
            this.UrlValueLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UrlValueLabel.Location = new System.Drawing.Point(45, 95);
            this.UrlValueLabel.Name = "UrlValueLabel";
            this.UrlValueLabel.Size = new System.Drawing.Size(115, 21);
            this.UrlValueLabel.TabIndex = 2;
            this.UrlValueLabel.Text = "网页地址：";
            // 
            // ButtonOk
            // 
            this.ButtonOk.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonOk.Location = new System.Drawing.Point(88, 247);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(134, 38);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "确定";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonCancel.Location = new System.Drawing.Point(239, 247);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(134, 38);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 314);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.UrlValueText);
            this.Controls.Add(this.UrlValueLabel);
            this.Controls.Add(this.UrlNameText);
            this.Controls.Add(this.UrlNameLabel);
            this.Name = "Form2";
            this.Text = "添加书签";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UrlNameLabel;
        private System.Windows.Forms.TextBox UrlNameText;
        private System.Windows.Forms.TextBox UrlValueText;
        private System.Windows.Forms.Label UrlValueLabel;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
    }
}