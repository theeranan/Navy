namespace Navy.Forms
{
    partial class AddNewIndictment
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
            this.txtDetails = new System.Windows.Forms.RichTextBox();
            this.txtBox_Indictment = new System.Windows.Forms.TextBox();
            this.Btn_saveIndictment = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBox_capture = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDetails
            // 
            this.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetails.Font = new System.Drawing.Font("Angsana New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetails.Location = new System.Drawing.Point(6, 6);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.Size = new System.Drawing.Size(525, 97);
            this.txtDetails.TabIndex = 4;
            this.txtDetails.Text = ";#พลทหาร  ;@firstname \t\t;#นามสกุล ;@sname\n;#ผลัด ;@oldyearin\t\t\t;#เครื่องหมาย ;@si" +
    "gn\t;@id8\n;#หมายเลขประจำตัว ;@id10\t;#เลขบัตรประจำตัวประชาชน ;@id13";
            // 
            // txtBox_Indictment
            // 
            this.txtBox_Indictment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtBox_Indictment.Location = new System.Drawing.Point(6, 17);
            this.txtBox_Indictment.Multiline = true;
            this.txtBox_Indictment.Name = "txtBox_Indictment";
            this.txtBox_Indictment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_Indictment.Size = new System.Drawing.Size(519, 85);
            this.txtBox_Indictment.TabIndex = 2;
            // 
            // Btn_saveIndictment
            // 
            this.Btn_saveIndictment.Location = new System.Drawing.Point(456, 213);
            this.Btn_saveIndictment.Name = "Btn_saveIndictment";
            this.Btn_saveIndictment.Size = new System.Drawing.Size(75, 23);
            this.Btn_saveIndictment.TabIndex = 4;
            this.Btn_saveIndictment.Text = "บันทึก";
            this.Btn_saveIndictment.UseVisualStyleBackColor = true;
            this.Btn_saveIndictment.Click += new System.EventHandler(this.Btn_saveIndictment_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBox_Indictment);
            this.groupBox1.Location = new System.Drawing.Point(6, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "กรอกข้อหา";
            // 
            // txtBox_capture
            // 
            this.txtBox_capture.Location = new System.Drawing.Point(81, 215);
            this.txtBox_capture.Mask = "00/00/0000";
            this.txtBox_capture.Name = "txtBox_capture";
            this.txtBox_capture.Size = new System.Drawing.Size(100, 20);
            this.txtBox_capture.TabIndex = 3;
            this.txtBox_capture.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "วันที่ถูกจับกุม";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(184, 219);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(113, 13);
            this.label36.TabIndex = 528;
            this.label36.Text = "(ตัวอย่าง. 27/02/2539)";
            // 
            // AddNewIndictment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 241);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_capture);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_saveIndictment);
            this.Controls.Add(this.txtDetails);
            this.Name = "AddNewIndictment";
            this.Text = "เพิ่มข้อหาพลทหาร";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDetails;
        private System.Windows.Forms.TextBox txtBox_Indictment;
        private System.Windows.Forms.Button Btn_saveIndictment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtBox_capture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label36;
    }
}