namespace Navy.Forms
{
    partial class selectlabel_test
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
            this.cmbunit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnummerperlabel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnumberlaber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtselect_number = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblselectol = new System.Windows.Forms.Label();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnclearall = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "หน่วย";
            // 
            // cmbunit
            // 
            this.cmbunit.FormattingEnabled = true;
            this.cmbunit.Location = new System.Drawing.Point(150, 30);
            this.cmbunit.Name = "cmbunit";
            this.cmbunit.Size = new System.Drawing.Size(121, 21);
            this.cmbunit.TabIndex = 1;
            this.cmbunit.SelectedIndexChanged += new System.EventHandler(this.cmbunit_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "จำนวนคนต่อฉลาก";
            // 
            // txtnummerperlabel
            // 
            this.txtnummerperlabel.Location = new System.Drawing.Point(150, 90);
            this.txtnummerperlabel.Name = "txtnummerperlabel";
            this.txtnummerperlabel.Size = new System.Drawing.Size(121, 20);
            this.txtnummerperlabel.TabIndex = 3;
            this.txtnummerperlabel.TextChanged += new System.EventHandler(this.txtnummerperlabel_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "จำนวนฉลาก";
            // 
            // txtnumberlaber
            // 
            this.txtnumberlaber.Location = new System.Drawing.Point(150, 120);
            this.txtnumberlaber.Name = "txtnumberlaber";
            this.txtnumberlaber.Size = new System.Drawing.Size(121, 20);
            this.txtnumberlaber.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "เลือกหมายเลข";
            // 
            // txtselect_number
            // 
            this.txtselect_number.Location = new System.Drawing.Point(150, 145);
            this.txtselect_number.Name = "txtselect_number";
            this.txtselect_number.Size = new System.Drawing.Size(290, 20);
            this.txtselect_number.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(169, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "จำนวนคนในหน่วย";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(150, 65);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(0, 13);
            this.lbltotal.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "หมายเลขที่ใช้ไปแล้ว";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 12;
            // 
            // lblselectol
            // 
            this.lblselectol.AutoSize = true;
            this.lblselectol.Location = new System.Drawing.Point(157, 272);
            this.lblselectol.Name = "lblselectol";
            this.lblselectol.Size = new System.Drawing.Size(0, 13);
            this.lblselectol.TabIndex = 13;
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(250, 187);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 23);
            this.btnclear.TabIndex = 14;
            this.btnclear.Text = "ล้างข้อมูล";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnclearall
            // 
            this.btnclearall.Location = new System.Drawing.Point(332, 187);
            this.btnclearall.Name = "btnclearall";
            this.btnclearall.Size = new System.Drawing.Size(91, 23);
            this.btnclearall.TabIndex = 15;
            this.btnclearall.Text = "ล้างข้อมูลทั้งหมด";
            this.btnclearall.UseVisualStyleBackColor = true;
            this.btnclearall.Click += new System.EventHandler(this.btnclearall_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "คน";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "คน";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "สุ่มหมายเลขฉลาก";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectlabel_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 328);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnclearall);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.lblselectol);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtselect_number);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtnumberlaber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnummerperlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbunit);
            this.Controls.Add(this.label1);
            this.Name = "selectlabel_test";
            this.Text = "กำหนดหมายเลขฉลาก";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbunit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnummerperlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnumberlaber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtselect_number;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblselectol;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnclearall;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}