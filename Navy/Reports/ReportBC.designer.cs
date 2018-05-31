namespace Navy.Reports
{
    partial class ReportBC
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbprovince = new System.Windows.Forms.ComboBox();
            this.gridSearch = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnreportin = new System.Windows.Forms.Button();
            this.btnreportout = new System.Windows.Forms.Button();
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numBatt = new System.Windows.Forms.TextBox();
            this.numcompany = new System.Windows.Forms.TextBox();
            this.numP = new System.Windows.Forms.TextBox();
            this.numPseq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mid8 = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkoldyearin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ผลัด";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "จังหวัด";
            // 
            // cmbprovince
            // 
            this.cmbprovince.FormattingEnabled = true;
            this.cmbprovince.Location = new System.Drawing.Point(126, 100);
            this.cmbprovince.Name = "cmbprovince";
            this.cmbprovince.Size = new System.Drawing.Size(121, 21);
            this.cmbprovince.TabIndex = 3;
            // 
            // gridSearch
            // 
            this.gridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSearch.Location = new System.Drawing.Point(66, 187);
            this.gridSearch.Name = "gridSearch";
            this.gridSearch.Size = new System.Drawing.Size(579, 179);
            this.gridSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(126, 141);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnreportin
            // 
            this.btnreportin.Location = new System.Drawing.Point(208, 141);
            this.btnreportin.Name = "btnreportin";
            this.btnreportin.Size = new System.Drawing.Size(127, 23);
            this.btnreportin.TabIndex = 6;
            this.btnreportin.Text = "ออกรายงานส่วนใน";
            this.btnreportin.UseVisualStyleBackColor = true;
            this.btnreportin.Click += new System.EventHandler(this.btnreportin_Click);
            // 
            // btnreportout
            // 
            this.btnreportout.Location = new System.Drawing.Point(501, 141);
            this.btnreportout.Name = "btnreportout";
            this.btnreportout.Size = new System.Drawing.Size(144, 23);
            this.btnreportout.TabIndex = 7;
            this.btnreportout.Text = "ออกรายงานทั้งเล่ม";
            this.btnreportout.UseVisualStyleBackColor = true;
            this.btnreportout.Click += new System.EventHandler(this.btnreportout_Click);
            // 
            // mtxtYearin
            // 
            this.mtxtYearin.Location = new System.Drawing.Point(126, 65);
            this.mtxtYearin.Mask = "0/00";
            this.mtxtYearin.Name = "mtxtYearin";
            this.mtxtYearin.Size = new System.Drawing.Size(31, 20);
            this.mtxtYearin.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "ออกรายงานส่วนนอก";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numBatt
            // 
            this.numBatt.Location = new System.Drawing.Point(321, 68);
            this.numBatt.Name = "numBatt";
            this.numBatt.Size = new System.Drawing.Size(100, 20);
            this.numBatt.TabIndex = 10;
            // 
            // numcompany
            // 
            this.numcompany.Location = new System.Drawing.Point(501, 68);
            this.numcompany.Name = "numcompany";
            this.numcompany.Size = new System.Drawing.Size(100, 20);
            this.numcompany.TabIndex = 11;
            // 
            // numP
            // 
            this.numP.Location = new System.Drawing.Point(321, 100);
            this.numP.Name = "numP";
            this.numP.Size = new System.Drawing.Size(100, 20);
            this.numP.TabIndex = 12;
            // 
            // numPseq
            // 
            this.numPseq.Location = new System.Drawing.Point(501, 97);
            this.numPseq.Name = "numPseq";
            this.numPseq.Size = new System.Drawing.Size(100, 20);
            this.numPseq.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "หมวด";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "กองพัน";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "กองร้อย";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(457, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "ลำดับ";
            // 
            // mid8
            // 
            this.mid8.Location = new System.Drawing.Point(208, 68);
            this.mid8.Mask = "a.a.0000";
            this.mid8.Name = "mid8";
            this.mid8.Size = new System.Drawing.Size(60, 20);
            this.mid8.TabIndex = 18;
            this.mid8.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "ทะเบียน";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // chkoldyearin
            // 
            this.chkoldyearin.AutoSize = true;
            this.chkoldyearin.Location = new System.Drawing.Point(126, 123);
            this.chkoldyearin.Name = "chkoldyearin";
            this.chkoldyearin.Size = new System.Drawing.Size(92, 17);
            this.chkoldyearin.TabIndex = 20;
            this.chkoldyearin.Text = "ทหารสมทบฝึก";
            this.chkoldyearin.UseVisualStyleBackColor = true;
            this.chkoldyearin.CheckedChanged += new System.EventHandler(this.chkoldyearin_CheckedChanged);
            // 
            // ReportBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 378);
            this.Controls.Add(this.chkoldyearin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mid8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPseq);
            this.Controls.Add(this.numP);
            this.Controls.Add(this.numcompany);
            this.Controls.Add(this.numBatt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mtxtYearin);
            this.Controls.Add(this.btnreportout);
            this.Controls.Add(this.btnreportin);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gridSearch);
            this.Controls.Add(this.cmbprovince);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReportBC";
            this.Text = "ReportBC";
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbprovince;
        private System.Windows.Forms.DataGridView gridSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnreportin;
        private System.Windows.Forms.Button btnreportout;
        private System.Windows.Forms.MaskedTextBox mtxtYearin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox numBatt;
        private System.Windows.Forms.TextBox numcompany;
        private System.Windows.Forms.TextBox numP;
        private System.Windows.Forms.TextBox numPseq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mid8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkoldyearin;
    }
}