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
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_load
            // 
            this.bt_load.Location = new System.Drawing.Point(2, 50);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(75, 23);
            this.bt_load.TabIndex = 0;
            this.bt_load.Text = "load";
            this.bt_load.UseVisualStyleBackColor = true;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // tx_url
            // 
            this.tx_url.Location = new System.Drawing.Point(2, 22);
            this.tx_url.Name = "tx_url";
            this.tx_url.Size = new System.Drawing.Size(530, 22);
            this.tx_url.TabIndex = 1;
            this.tx_url.Text = "http://item.jd.com/11750397.html";
            // 
            // rtx_info
            // 
            this.rtx_info.Location = new System.Drawing.Point(2, 90);
            this.rtx_info.Name = "rtx_info";
            this.rtx_info.Size = new System.Drawing.Size(269, 356);
            this.rtx_info.TabIndex = 2;
            this.rtx_info.Text = "";
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(277, 90);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(449, 521);
            this.picBox.TabIndex = 3;
            this.picBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 623);
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
    }
}

