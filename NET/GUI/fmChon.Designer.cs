namespace NET.GUI
{
    partial class fmChon
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSobanHuy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTrangThai = new System.Windows.Forms.Label();
            this.lbtenKh = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(234)))), ((int)(((byte)(177)))));
            this.btnHuy.Location = new System.Drawing.Point(23, 126);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 34);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy ";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bàn số:";
            // 
            // lbSobanHuy
            // 
            this.lbSobanHuy.AutoSize = true;
            this.lbSobanHuy.Location = new System.Drawing.Point(171, 21);
            this.lbSobanHuy.Name = "lbSobanHuy";
            this.lbSobanHuy.Size = new System.Drawing.Size(27, 25);
            this.lbSobanHuy.TabIndex = 2;
            this.lbSobanHuy.Text = "lb";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Trạng thái:";
            // 
            // lbTrangThai
            // 
            this.lbTrangThai.AutoSize = true;
            this.lbTrangThai.Location = new System.Drawing.Point(171, 71);
            this.lbTrangThai.Name = "lbTrangThai";
            this.lbTrangThai.Size = new System.Drawing.Size(27, 25);
            this.lbTrangThai.TabIndex = 4;
            this.lbTrangThai.Text = "lb";
            // 
            // lbtenKh
            // 
            this.lbtenKh.AutoSize = true;
            this.lbtenKh.Location = new System.Drawing.Point(171, 46);
            this.lbtenKh.Name = "lbtenKh";
            this.lbtenKh.Size = new System.Drawing.Size(27, 25);
            this.lbtenKh.TabIndex = 7;
            this.lbtenKh.Text = "lb";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên Khách Hàng:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(259, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(234)))), ((int)(((byte)(177)))));
            this.button2.Location = new System.Drawing.Point(141, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 9;
            this.button2.Text = "Đặt món";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fmChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(186)))), ((int)(((byte)(115)))));
            this.ClientSize = new System.Drawing.Size(402, 229);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbtenKh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTrangThai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSobanHuy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHuy);
            this.Name = "fmChon";
            this.Text = "fmCancel";
            this.Load += new System.EventHandler(this.fmCancel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnHuy;
        private Label label1;
        private Label lbSobanHuy;
        private Label label3;
        private Label lbTrangThai;
        private Label lbtenKh;
        private Label label4;
        private Button button1;
        private Button button2;
    }
}