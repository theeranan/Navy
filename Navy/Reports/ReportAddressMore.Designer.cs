namespace Navy.Reports
{
    partial class ReportAddressMore
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
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.cmbselectaddress = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtrank = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtposition = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttext = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dpday = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dpdateR = new System.Windows.Forms.DateTimePicker();
            this.chkimage = new System.Windows.Forms.CheckBox();
            this.chkexport = new System.Windows.Forms.CheckBox();
            this.chk = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(33, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 5;
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
            this.mtxtYearin.TabIndex = 4;
            // 
            // cmbselectaddress
            // 
            this.cmbselectaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cmbselectaddress.FormattingEnabled = true;
            this.cmbselectaddress.Location = new System.Drawing.Point(101, 62);
            this.cmbselectaddress.Name = "cmbselectaddress";
            this.cmbselectaddress.Size = new System.Drawing.Size(200, 21);
            this.cmbselectaddress.TabIndex = 129;
            this.cmbselectaddress.SelectedIndexChanged += new System.EventHandler(this.cmbselectaddress_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(33, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 130;
            this.label3.Text = "หน่วย";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 330);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(830, 37);
            this.reportViewer1.TabIndex = 131;
            this.reportViewer1.Visible = false;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearch.Location = new System.Drawing.Point(101, 259);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 36);
            this.btnSearch.TabIndex = 132;
            this.btnSearch.Text = "ออกรายงาน";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(151, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 134;
            this.label1.Text = "วันที่ส่งมอบ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(33, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 16);
            this.label4.TabIndex = 135;
            this.label4.Text = "ยศ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(33, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 136;
            this.label5.Text = "ชื่อ-สกุล";
            // 
            // txtrank
            // 
            this.txtrank.Location = new System.Drawing.Point(101, 116);
            this.txtrank.Name = "txtrank";
            this.txtrank.Size = new System.Drawing.Size(200, 20);
            this.txtrank.TabIndex = 137;
            this.txtrank.Text = "น.ท.";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(101, 143);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(200, 20);
            this.txtname.TabIndex = 138;
            this.txtname.Text = "(รวีกฤษฎิ์ ล้อเลิศวิไล)";
            // 
            // txtposition
            // 
            this.txtposition.Location = new System.Drawing.Point(101, 169);
            this.txtposition.Name = "txtposition";
            this.txtposition.Size = new System.Drawing.Size(200, 20);
            this.txtposition.TabIndex = 141;
            this.txtposition.Text = "นกพ.ศฝท.ยศ.ทร.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(33, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 139;
            this.label7.Text = "ตำแหน่ง";
            // 
            // txttext
            // 
            this.txttext.Location = new System.Drawing.Point(101, 89);
            this.txttext.Name = "txttext";
            this.txttext.Size = new System.Drawing.Size(200, 20);
            this.txttext.TabIndex = 145;
            this.txttext.Text = "ตรวจถูกต้อง";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(33, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 144;
            this.label8.Text = "ข้อความ";
            // 
            // dpday
            // 
            this.dpday.Location = new System.Drawing.Point(101, 195);
            this.dpday.Name = "dpday";
            this.dpday.Size = new System.Drawing.Size(200, 20);
            this.dpday.TabIndex = 147;
            this.dpday.Text = "เม.ย.61";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(33, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 146;
            this.label6.Text = "ลงวันที่";
            // 
            // dpdateR
            // 
            this.dpdateR.Location = new System.Drawing.Point(219, 32);
            this.dpdateR.Name = "dpdateR";
            this.dpdateR.Size = new System.Drawing.Size(200, 20);
            this.dpdateR.TabIndex = 148;
            // 
            // chkimage
            // 
            this.chkimage.AutoSize = true;
            this.chkimage.Location = new System.Drawing.Point(456, 64);
            this.chkimage.Name = "chkimage";
            this.chkimage.Size = new System.Drawing.Size(98, 17);
            this.chkimage.TabIndex = 149;
            this.chkimage.Text = "รูปภาพส่งหน่วย";
            this.chkimage.UseVisualStyleBackColor = true;
            // 
            // chkexport
            // 
            this.chkexport.AutoSize = true;
            this.chkexport.Location = new System.Drawing.Point(560, 64);
            this.chkexport.Name = "chkexport";
            this.chkexport.Size = new System.Drawing.Size(95, 17);
            this.chkexport.TabIndex = 150;
            this.chkexport.Text = "export to excel";
            this.chkexport.UseVisualStyleBackColor = true;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.Location = new System.Drawing.Point(321, 65);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(129, 17);
            this.chk.TabIndex = 151;
            this.chk.Text = "รายชื่อทหารย้ายหน่วย";
            this.chk.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(200, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 36);
            this.button1.TabIndex = 152;
            this.button1.Text = "ออกรายงานทั้งหมด";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 301);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(830, 23);
            this.progressBar1.TabIndex = 153;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(101, 221);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 154;
            this.checkBox1.Text = "ลงนาม";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ReportAddressMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 388);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chk);
            this.Controls.Add(this.chkexport);
            this.Controls.Add(this.chkimage);
            this.Controls.Add(this.dpdateR);
            this.Controls.Add(this.dpday);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txttext);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtposition);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtrank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cmbselectaddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtYearin);
            this.Name = "ReportAddressMore";
            this.Text = "รายชื่อพลทหารกองประจำการจัดแบ่งให้หน่วย";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtYearin;
        private System.Windows.Forms.ComboBox cmbselectaddress;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtrank;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtposition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox dpday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DateTimePicker dpdateR;
        private System.Windows.Forms.CheckBox chkimage;
        private System.Windows.Forms.CheckBox chkexport;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}