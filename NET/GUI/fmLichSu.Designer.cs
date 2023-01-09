namespace NET.GUI
{
    partial class fmLichSu
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
            this.label1 = new System.Windows.Forms.Label();
            this.lablek = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mskTo = new System.Windows.Forms.MaskedTextBox();
            this.mskFrom = new System.Windows.Forms.MaskedTextBox();
            this.dtgvLS = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(319, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lịch sử bán hàng";
            // 
            // lablek
            // 
            this.lablek.AutoSize = true;
            this.lablek.Location = new System.Drawing.Point(133, 92);
            this.lablek.Name = "lablek";
            this.lablek.Size = new System.Drawing.Size(36, 25);
            this.lablek.TabIndex = 1;
            this.lablek.Text = "Từ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến:";
            // 
            // mskTo
            // 
            this.mskTo.Location = new System.Drawing.Point(175, 86);
            this.mskTo.Mask = "0000-00-00";
            this.mskTo.Name = "mskTo";
            this.mskTo.Size = new System.Drawing.Size(150, 31);
            this.mskTo.TabIndex = 4;
            // 
            // mskFrom
            // 
            this.mskFrom.Location = new System.Drawing.Point(408, 86);
            this.mskFrom.Mask = "0000-00-00";
            this.mskFrom.Name = "mskFrom";
            this.mskFrom.Size = new System.Drawing.Size(150, 31);
            this.mskFrom.TabIndex = 5;
            this.mskFrom.ValidatingType = typeof(System.DateTime);
            // 
            // dtgvLS
            // 
            this.dtgvLS.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(218)))));
            this.dtgvLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLS.Location = new System.Drawing.Point(82, 136);
            this.dtgvLS.Name = "dtgvLS";
            this.dtgvLS.RowHeadersWidth = 62;
            this.dtgvLS.RowTemplate.Height = 33;
            this.dtgvLS.Size = new System.Drawing.Size(687, 313);
            this.dtgvLS.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(83)))), ((int)(((byte)(74)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(617, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Lọc";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fmLichSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(218)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(847, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgvLS);
            this.Controls.Add(this.mskFrom);
            this.Controls.Add(this.mskTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lablek);
            this.Controls.Add(this.label1);
            this.Name = "fmLichSu";
            this.Text = "fmLichSu";
            this.Load += new System.EventHandler(this.fmLichSu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label lablek;
        private Label label3;
        private MaskedTextBox mskTo;
        private MaskedTextBox mskFrom;
        private DataGridView dtgvLS;
        private Button button1;
    }
}