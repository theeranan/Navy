namespace Navy.Forms
{
    partial class PersonRequestForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.personShortDetailView1 = new Navy.MyControls.PersonShortDetailView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRemark2 = new System.Windows.Forms.TextBox();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRequester2 = new System.Windows.Forms.TextBox();
            this.cbbNUM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbRequester1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbUnit = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnSubmit2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbUnit2 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.personShortDetailView1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 286);
            this.panel1.TabIndex = 1;
            // 
            // personShortDetailView1
            // 
            this.personShortDetailView1.Location = new System.Drawing.Point(57, 1);
            this.personShortDetailView1.Name = "personShortDetailView1";
            this.personShortDetailView1.Size = new System.Drawing.Size(444, 271);
            this.personShortDetailView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbRemark2);
            this.groupBox1.Controls.Add(this.tbRemark);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbRequester2);
            this.groupBox1.Controls.Add(this.cbbNUM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbRequester1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbUnit);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "แบบฟอร์มร้องขอ";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(90, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(9, 100);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "คืนค่าเริ่มต้น";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(464, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(383, 100);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "บันทึก";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ขอต่อ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "หมายเหตุ";
            // 
            // tbRemark2
            // 
            this.tbRemark2.Location = new System.Drawing.Point(78, 76);
            this.tbRemark2.MaxLength = 50;
            this.tbRemark2.Name = "tbRemark2";
            this.tbRemark2.Size = new System.Drawing.Size(369, 20);
            this.tbRemark2.TabIndex = 5;
            this.tbRemark2.Enter += new System.EventHandler(this.tbRemark2_Enter);
            this.tbRemark2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRemark2_KeyDown);
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(78, 49);
            this.tbRemark.MaxLength = 50;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(369, 20);
            this.tbRemark.TabIndex = 4;
            this.tbRemark.Enter += new System.EventHandler(this.tbRemark_Enter);
            this.tbRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRemark_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ลำดับ";
            // 
            // tbRequester2
            // 
            this.tbRequester2.Location = new System.Drawing.Point(297, 19);
            this.tbRequester2.MaxLength = 30;
            this.tbRequester2.Name = "tbRequester2";
            this.tbRequester2.Size = new System.Drawing.Size(150, 20);
            this.tbRequester2.TabIndex = 2;
            this.tbRequester2.Enter += new System.EventHandler(this.tbRequester2_Enter);
            this.tbRequester2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRequester2_KeyDown);
            this.tbRequester2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbRequester2_PreviewKeyDown);
            // 
            // cbbNUM
            // 
            this.cbbNUM.FormattingEnabled = true;
            this.cbbNUM.Location = new System.Drawing.Point(486, 19);
            this.cbbNUM.Name = "cbbNUM";
            this.cbbNUM.Size = new System.Drawing.Size(40, 21);
            this.cbbNUM.TabIndex = 3;
            this.cbbNUM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbNUM_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ผู้ขอ";
            // 
            // cbbRequester1
            // 
            this.cbbRequester1.FormattingEnabled = true;
            this.cbbRequester1.Location = new System.Drawing.Point(251, 19);
            this.cbbRequester1.Name = "cbbRequester1";
            this.cbbRequester1.Size = new System.Drawing.Size(40, 21);
            this.cbbRequester1.TabIndex = 1;
            this.cbbRequester1.SelectedIndexChanged += new System.EventHandler(this.cbbRequester1_SelectedIndexChanged);
            this.cbbRequester1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbRequester1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "หน่วยที่เลือก";
            // 
            // cbbUnit
            // 
            this.cbbUnit.FormattingEnabled = true;
            this.cbbUnit.Location = new System.Drawing.Point(78, 19);
            this.cbbUnit.Name = "cbbUnit";
            this.cbbUnit.Size = new System.Drawing.Size(121, 21);
            this.cbbUnit.TabIndex = 0;
            this.cbbUnit.Enter += new System.EventHandler(this.cbbUnit_Enter);
            this.cbbUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbUnit_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel2);
            this.groupBox2.Controls.Add(this.btnSubmit2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbbUnit2);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 130);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "แก้ไขหน่วยปัจจุบัน";
            // 
            // btnCancel2
            // 
            this.btnCancel2.Location = new System.Drawing.Point(464, 100);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(75, 23);
            this.btnCancel2.TabIndex = 16;
            this.btnCancel2.Text = "ยกเลิก";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit2
            // 
            this.btnSubmit2.Location = new System.Drawing.Point(383, 100);
            this.btnSubmit2.Name = "btnSubmit2";
            this.btnSubmit2.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit2.TabIndex = 11;
            this.btnSubmit2.Text = "บันทึก";
            this.btnSubmit2.UseVisualStyleBackColor = true;
            this.btnSubmit2.Click += new System.EventHandler(this.btnSubmit2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "หน่วยที่เลือก";
            // 
            // cbbUnit2
            // 
            this.cbbUnit2.FormattingEnabled = true;
            this.cbbUnit2.Location = new System.Drawing.Point(78, 19);
            this.cbbUnit2.Name = "cbbUnit2";
            this.cbbUnit2.Size = new System.Drawing.Size(121, 21);
            this.cbbUnit2.TabIndex = 10;
            this.cbbUnit2.Enter += new System.EventHandler(this.cbbUnit2_Enter);
            this.cbbUnit2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbUnit2_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 304);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 166);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 140);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ร้องขอ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(552, 140);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "หน่วยปัจจุบัน";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PersonRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 480);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "PersonRequestForm";
            this.Text = "ฟอร์มร้องขอย้ายหน่วย";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PersonRequestForm_FormClosed);
            this.Load += new System.EventHandler(this.PersonRequestForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Navy.MyControls.PersonShortDetailView personShortDetailView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRemark2;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRequester2;
        private System.Windows.Forms.ComboBox cbbNUM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbRequester1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSubmit2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbUnit2;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

    }
}