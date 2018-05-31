namespace Navy.Reports
{
    partial class ReportEducateAndOccup
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dpdateR = new System.Windows.Forms.DateTimePicker();
            this.dpday = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttext = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtposition = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtrank = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Print_Report = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 259);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(830, 404);
            this.reportViewer1.TabIndex = 196;
            // 
            // checkBox1
            // 
            this.checkBox1.AllowDrop = true;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(101, 194);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 195;
            this.checkBox1.Text = "ลงนาม";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dpdateR
            // 
            this.dpdateR.Location = new System.Drawing.Point(219, 32);
            this.dpdateR.Name = "dpdateR";
            this.dpdateR.Size = new System.Drawing.Size(200, 20);
            this.dpdateR.TabIndex = 194;
            // 
            // dpday
            // 
            this.dpday.Location = new System.Drawing.Point(101, 168);
            this.dpday.Name = "dpday";
            this.dpday.Size = new System.Drawing.Size(200, 20);
            this.dpday.TabIndex = 193;
            this.dpday.Text = "เม.ย.60";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(33, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 192;
            this.label6.Text = "ลงวันที่";
            // 
            // txttext
            // 
            this.txttext.Location = new System.Drawing.Point(101, 62);
            this.txttext.Name = "txttext";
            this.txttext.Size = new System.Drawing.Size(200, 20);
            this.txttext.TabIndex = 191;
            this.txttext.Text = "ตรวจถูกต้อง";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(33, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 190;
            this.label8.Text = "ข้อความ";
            // 
            // txtposition
            // 
            this.txtposition.Location = new System.Drawing.Point(101, 142);
            this.txtposition.Name = "txtposition";
            this.txtposition.Size = new System.Drawing.Size(200, 20);
            this.txtposition.TabIndex = 189;
            this.txtposition.Text = "นกพ.ศฝท.ยศ.ทร.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(33, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 188;
            this.label7.Text = "ตำแหน่ง";
            // 
            // txtrank
            // 
            this.txtrank.Location = new System.Drawing.Point(101, 89);
            this.txtrank.Name = "txtrank";
            this.txtrank.Size = new System.Drawing.Size(200, 20);
            this.txtrank.TabIndex = 186;
            this.txtrank.Text = "น.ท.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(33, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 185;
            this.label5.Text = "ชื่อ-สกุล";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(33, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 16);
            this.label4.TabIndex = 184;
            this.label4.Text = "ยศ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(151, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 183;
            this.label1.Text = "วันที่ส่งมอบ";
            // 
            // Print_Report
            // 
            this.Print_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Print_Report.Location = new System.Drawing.Point(101, 217);
            this.Print_Report.Name = "Print_Report";
            this.Print_Report.Size = new System.Drawing.Size(93, 36);
            this.Print_Report.TabIndex = 182;
            this.Print_Report.Text = "ออกรายงาน";
            this.Print_Report.UseVisualStyleBackColor = true;
            this.Print_Report.Click += new System.EventHandler(this.Print_Report_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(33, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 181;
            this.label2.Text = "ผลัด";
            // 
            // mtxtYearin
            // 
            this.mtxtYearin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.mtxtYearin.Location = new System.Drawing.Point(101, 35);
            this.mtxtYearin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxtYearin.Mask = "0/00";
            this.mtxtYearin.Name = "mtxtYearin";
            this.mtxtYearin.Size = new System.Drawing.Size(43, 20);
            this.mtxtYearin.TabIndex = 180;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(101, 116);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(200, 20);
            this.txtname.TabIndex = 187;
            this.txtname.Text = "(รวีกฤษฎิ์ ล้อเลิศวิไล)";
            // 
            // ReportEducateAndOccup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 676);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dpdateR);
            this.Controls.Add(this.dpday);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txttext);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtposition);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtrank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Print_Report);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtYearin);
            this.Controls.Add(this.txtname);
            this.Name = "ReportEducateAndOccup";
            this.Text = "ReportEducateAndOccup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dpdateR;
        private System.Windows.Forms.TextBox dpday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtposition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtrank;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Print_Report;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtYearin;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtname;
    }
}