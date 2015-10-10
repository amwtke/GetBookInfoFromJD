namespace GetJDBookInfo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_load = new System.Windows.Forms.Button();
            this.tx_url = new System.Windows.Forms.TextBox();
            this.rtx_info = new System.Windows.Forms.RichTextBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_load
            // 
            this.bt_load.Location = new System.Drawing.Point(2, 47);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(75, 22);
            this.bt_load.TabIndex = 0;
            this.bt_load.Text = "load";
            this.bt_load.UseVisualStyleBackColor = true;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // tx_url
            // 
            this.tx_url.Location = new System.Drawing.Point(2, 21);
            this.tx_url.Name = "tx_url";
            this.tx_url.Size = new System.Drawing.Size(530, 25);
            this.tx_url.TabIndex = 1;
            this.tx_url.Text = "https://api.douban.com/v2/book/search?q=C%E8%AF%AD%E8%A8%80&count=1";
            // 
            // rtx_info
            // 
            this.rtx_info.Location = new System.Drawing.Point(2, 84);
            this.rtx_info.Name = "rtx_info";
            this.rtx_info.Size = new System.Drawing.Size(269, 334);
            this.rtx_info.TabIndex = 2;
            this.rtx_info.Text = "";
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(277, 84);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(449, 488);
            this.picBox.TabIndex = 3;
            this.picBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "douban";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 584);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.rtx_info);
            this.Controls.Add(this.tx_url);
            this.Controls.Add(this.bt_load);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.TextBox tx_url;
        private System.Windows.Forms.RichTextBox rtx_info;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button button1;
    }
}

