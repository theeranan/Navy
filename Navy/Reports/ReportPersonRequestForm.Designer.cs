namespace Navy.Reports
{
    partial class ReportPersonRequestForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPersonHasRequest = new System.Windows.Forms.RadioButton();
            this.rbRequestAll = new System.Windows.Forms.RadioButton();
            this.rbRequestMultiple = new System.Windows.Forms.RadioButton();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRequestMultiple);
            this.groupBox1.Controls.Add(this.rbRequestAll);
            this.groupBox1.Controls.Add(this.rbPersonHasRequest);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ตัวเลือกรายงาน";
            // 
            // rbPersonHasRequest
            // 
            this.rbPersonHasRequest.AutoSize = true;
            this.rbPersonHasRequest.Location = new System.Drawing.Point(6, 21);
            this.rbPersonHasRequest.Name = "rbPersonHasRequest";
            this.rbPersonHasRequest.Size = new System.Drawing.Size(164, 20);
            this.rbPersonHasRequest.TabIndex = 0;
            this.rbPersonHasRequest.TabStop = true;
            this.rbPersonHasRequest.Text = "รายชื่อทหารที่ได้รับการร้องขอ";
            this.rbPersonHasRequest.UseVisualStyleBackColor = true;
            // 
            // rbRequestAll
            // 
            this.rbRequestAll.AutoSize = true;
            this.rbRequestAll.Location = new System.Drawing.Point(6, 47);
            this.rbRequestAll.Name = "rbRequestAll";
            this.rbRequestAll.Size = new System.Drawing.Size(119, 20);
            this.rbRequestAll.TabIndex = 1;
            this.rbRequestAll.TabStop = true;
            this.rbRequestAll.Text = "ข้อมูลร้องขอทั้งหมด";
            this.rbRequestAll.UseVisualStyleBackColor = true;
            // 
            // rbRequestMultiple
            // 
            this.rbRequestMultiple.AutoSize = true;
            this.rbRequestMultiple.Location = new System.Drawing.Point(6, 73);
            this.rbRequestMultiple.Name = "rbRequestMultiple";
            this.rbRequestMultiple.Size = new System.Drawing.Size(115, 20);
            this.rbRequestMultiple.TabIndex = 2;
            this.rbRequestMultiple.TabStop = true;
            this.rbRequestMultiple.Text = "ข้อมูลร้องขอซ้ำซ้อน";
            this.rbRequestMultiple.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(111, 132);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "ดูรายงาน";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // ReportPersonRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 176);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReportPersonRequestForm";
            this.Text = "รายงาน ร้องขอทหารย้ายหน่วย";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRequestMultiple;
        private System.Windows.Forms.RadioButton rbRequestAll;
        private System.Windows.Forms.RadioButton rbPersonHasRequest;
        private System.Windows.Forms.Button btnReport;
    }
}