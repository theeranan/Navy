namespace Navy.Forms
{
    partial class LostInformation
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
            this.label_countRecord = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_CreateReport = new System.Windows.Forms.Button();
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.radioBtn_CheckID13 = new System.Windows.Forms.RadioButton();
            this.radioBtn_AccountNum = new System.Windows.Forms.RadioButton();
            this.radioBtn_Educate = new System.Windows.Forms.RadioButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "ผลลัพธ์";
            // 
            // label_countRecord
            // 
            this.label_countRecord.Location = new System.Drawing.Point(56, 549);
            this.label_countRecord.Name = "label_countRecord";
            this.label_countRecord.Size = new System.Drawing.Size(84, 17);
            this.label_countRecord.TabIndex = 8;
            this.label_countRecord.Text = ".";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Btn_CreateReport);
            this.groupBox1.Controls.Add(this.mtxtYearin);
            this.groupBox1.Controls.Add(this.radioBtn_CheckID13);
            this.groupBox1.Controls.Add(this.radioBtn_AccountNum);
            this.groupBox1.Controls.Add(this.radioBtn_Educate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 133);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลที่ต้องการตรวจสอบ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(22, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 183;
            this.label2.Text = "ผลัด";
            // 
            // Btn_CreateReport
            // 
            this.Btn_CreateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Btn_CreateReport.Location = new System.Drawing.Point(760, 85);
            this.Btn_CreateReport.Name = "Btn_CreateReport";
            this.Btn_CreateReport.Size = new System.Drawing.Size(91, 42);
            this.Btn_CreateReport.TabIndex = 1;
            this.Btn_CreateReport.Text = "ออกรายงาน";
            this.Btn_CreateReport.UseVisualStyleBackColor = true;
            this.Btn_CreateReport.Click += new System.EventHandler(this.Btn_CreateReport_Click);
            // 
            // mtxtYearin
            // 
            this.mtxtYearin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.mtxtYearin.Location = new System.Drawing.Point(56, 23);
            this.mtxtYearin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxtYearin.Mask = "0/00";
            this.mtxtYearin.Name = "mtxtYearin";
            this.mtxtYearin.Size = new System.Drawing.Size(35, 20);
            this.mtxtYearin.TabIndex = 182;
            // 
            // radioBtn_CheckID13
            // 
            this.radioBtn_CheckID13.AutoSize = true;
            this.radioBtn_CheckID13.Location = new System.Drawing.Point(25, 52);
            this.radioBtn_CheckID13.Name = "radioBtn_CheckID13";
            this.radioBtn_CheckID13.Size = new System.Drawing.Size(193, 17);
            this.radioBtn_CheckID13.TabIndex = 2;
            this.radioBtn_CheckID13.TabStop = true;
            this.radioBtn_CheckID13.Text = "ตรวจสอบเลขบัตรประจำตัวประชาชน";
            this.radioBtn_CheckID13.UseVisualStyleBackColor = true;
            // 
            // radioBtn_AccountNum
            // 
            this.radioBtn_AccountNum.AutoSize = true;
            this.radioBtn_AccountNum.Location = new System.Drawing.Point(25, 98);
            this.radioBtn_AccountNum.Name = "radioBtn_AccountNum";
            this.radioBtn_AccountNum.Size = new System.Drawing.Size(219, 17);
            this.radioBtn_AccountNum.TabIndex = 4;
            this.radioBtn_AccountNum.TabStop = true;
            this.radioBtn_AccountNum.Text = "ตรวจสอบหมายเลขบัญชี หรือสังกัดธนาคาร";
            this.radioBtn_AccountNum.UseVisualStyleBackColor = false;
            // 
            // radioBtn_Educate
            // 
            this.radioBtn_Educate.AutoSize = true;
            this.radioBtn_Educate.Location = new System.Drawing.Point(25, 75);
            this.radioBtn_Educate.Name = "radioBtn_Educate";
            this.radioBtn_Educate.Size = new System.Drawing.Size(131, 17);
            this.radioBtn_Educate.TabIndex = 3;
            this.radioBtn_Educate.TabStop = true;
            this.radioBtn_Educate.Text = "ตรวจสอบวุฒิการศึกษา";
            this.radioBtn_Educate.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 154);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(857, 387);
            this.reportViewer1.TabIndex = 9;
            // 
            // LostInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 584);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_countRecord);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "LostInformation";
            this.Text = "LostInformation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_countRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_CreateReport;
        private System.Windows.Forms.MaskedTextBox mtxtYearin;
        private System.Windows.Forms.RadioButton radioBtn_CheckID13;
        private System.Windows.Forms.RadioButton radioBtn_AccountNum;
        private System.Windows.Forms.RadioButton radioBtn_Educate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}