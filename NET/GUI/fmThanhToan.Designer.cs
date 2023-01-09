namespace NET.GUI
{
    partial class fmThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmThanhToan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgvThanhToan = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTong = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lbTenKH = new System.Windows.Forms.Label();
            this.lbSDT = new System.Windows.Forms.Label();
            this.lbBan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(349, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "HÓA ĐƠN THANH TOÁN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(617, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bàn số:";
            // 
            // dtgvThanhToan
            // 
            this.dtgvThanhToan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(218)))));
            this.dtgvThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThanhToan.Location = new System.Drawing.Point(199, 185);
            this.dtgvThanhToan.Name = "dtgvThanhToan";
            this.dtgvThanhToan.RowHeadersWidth = 62;
            this.dtgvThanhToan.RowTemplate.Height = 33;
            this.dtgvThanhToan.Size = new System.Drawing.Size(668, 347);
            this.dtgvThanhToan.TabIndex = 4;
            this.dtgvThanhToan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThanhToan_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 583);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tổng tiền:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(617, 544);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Khuyến mãi:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(731, 544);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "km";
            // 
            // lbTong
            // 
            this.lbTong.AutoSize = true;
            this.lbTong.Location = new System.Drawing.Point(731, 583);
            this.lbTong.Name = "lbTong";
            this.lbTong.Size = new System.Drawing.Size(24, 25);
            this.lbTong.TabIndex = 8;
            this.lbTong.Text = "tt";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(412, 627);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(145, 34);
            this.btnThanhToan.TabIndex = 9;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lbTenKH
            // 
            this.lbTenKH.AutoSize = true;
            this.lbTenKH.Location = new System.Drawing.Point(295, 94);
            this.lbTenKH.Name = "lbTenKH";
            this.lbTenKH.Size = new System.Drawing.Size(59, 25);
            this.lbTenKH.TabIndex = 10;
            this.lbTenKH.Text = "label9";
            // 
            // lbSDT
            // 
            this.lbSDT.AutoSize = true;
            this.lbSDT.Location = new System.Drawing.Point(295, 139);
            this.lbSDT.Name = "lbSDT";
            this.lbSDT.Size = new System.Drawing.Size(59, 25);
            this.lbSDT.TabIndex = 11;
            this.lbSDT.Text = "label9";
            // 
            // lbBan
            // 
            this.lbBan.AutoSize = true;
            this.lbBan.Location = new System.Drawing.Point(692, 94);
            this.lbBan.Name = "lbBan";
            this.lbBan.Size = new System.Drawing.Size(59, 25);
            this.lbBan.TabIndex = 12;
            this.lbBan.Text = "label9";
            // 
            // fmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1049, 690);
            this.Controls.Add(this.lbBan);
            this.Controls.Add(this.lbSDT);
            this.Controls.Add(this.lbTenKH);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.lbTong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgvThanhToan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fmThanhToan";
            this.Text = "fmThanhToan";
            this.Load += new System.EventHandler(this.fmThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThanhToan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dtgvThanhToan;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lbTong;
        private Button btnThanhToan;
        private Label lbTenKH;
        private Label lbSDT;
        private Label lbBan;
    }
}