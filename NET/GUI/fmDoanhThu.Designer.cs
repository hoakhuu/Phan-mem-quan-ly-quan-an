namespace NET.GUI
{
    partial class fmDoanhThu
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtgvDT = new System.Windows.Forms.DataGridView();
            this.lablek = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDT)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.button1.Location = new System.Drawing.Point(294, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 34);
            this.button1.TabIndex = 14;
            this.button1.Text = "Lọc";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtgvDT
            // 
            this.dtgvDT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(228)))));
            this.dtgvDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDT.Location = new System.Drawing.Point(95, 122);
            this.dtgvDT.Name = "dtgvDT";
            this.dtgvDT.RowHeadersWidth = 62;
            this.dtgvDT.RowTemplate.Height = 33;
            this.dtgvDT.Size = new System.Drawing.Size(337, 133);
            this.dtgvDT.TabIndex = 13;
            this.dtgvDT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDT_CellContentClick);
            // 
            // lablek
            // 
            this.lablek.AutoSize = true;
            this.lablek.Location = new System.Drawing.Point(108, 76);
            this.lablek.Name = "lablek";
            this.lablek.Size = new System.Drawing.Size(70, 25);
            this.lablek.TabIndex = 9;
            this.lablek.Text = " Tháng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(140, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "Doanh Thu Tháng";
            // 
            // cbMto
            // 
            this.cbMto.FormattingEnabled = true;
            this.cbMto.Location = new System.Drawing.Point(184, 71);
            this.cbMto.Name = "cbMto";
            this.cbMto.Size = new System.Drawing.Size(82, 33);
            this.cbMto.TabIndex = 15;
            // 
            // fmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(542, 316);
            this.Controls.Add(this.cbMto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgvDT);
            this.Controls.Add(this.lablek);
            this.Controls.Add(this.label1);
            this.Name = "fmDoanhThu";
            this.Text = "fmDoanhThu";
            this.Load += new System.EventHandler(this.fmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private DataGridView dtgvDT;
        private Label lablek;
        private Label label1;
        private ComboBox cbMto;
    }
}