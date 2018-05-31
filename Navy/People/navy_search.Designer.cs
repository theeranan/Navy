namespace Navy.People
{
    partial class navy_search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtlname = new System.Windows.Forms.TextBox();
            this.txtid13 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbselectaddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkmove_in = new System.Windows.Forms.CheckBox();
            this.txtrank = new System.Windows.Forms.TextBox();
            this.txtbook_number = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblcount = new System.Windows.Forms.Label();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Location = new System.Drawing.Point(32, 206);
            this.grdData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(1196, 490);
            this.grdData.TabIndex = 0;
            this.grdData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellContentDoubleClick);
            this.grdData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdData_CellMouseDoubleClick);
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsearch.Location = new System.Drawing.Point(877, 102);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(167, 34);
            this.btnsearch.TabIndex = 6;
            this.btnsearch.Text = "ค้นหา";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtname.Location = new System.Drawing.Point(460, 30);
            this.txtname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtname.MaxLength = 50;
            this.txtname.Multiline = true;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(184, 26);
            this.txtname.TabIndex = 1;
            // 
            // txtlname
            // 
            this.txtlname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtlname.Location = new System.Drawing.Point(751, 30);
            this.txtlname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtlname.MaxLength = 50;
            this.txtlname.Multiline = true;
            this.txtlname.Name = "txtlname";
            this.txtlname.Size = new System.Drawing.Size(168, 26);
            this.txtlname.TabIndex = 2;
            // 
            // txtid13
            // 
            this.txtid13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtid13.Location = new System.Drawing.Point(208, 65);
            this.txtid13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtid13.MaxLength = 13;
            this.txtid13.Multiline = true;
            this.txtid13.Name = "txtid13";
            this.txtid13.Size = new System.Drawing.Size(168, 26);
            this.txtid13.TabIndex = 3;
            this.txtid13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtid13_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbselectaddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkmove_in);
            this.groupBox1.Controls.Add(this.txtrank);
            this.groupBox1.Controls.Add(this.txtbook_number);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.txtid13);
            this.groupBox1.Controls.Add(this.btnsearch);
            this.groupBox1.Controls.Add(this.txtlname);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.mtxtYearin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(67, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1081, 145);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ฟอร์มค้นหา";
            // 
            // cmbselectaddress
            // 
            this.cmbselectaddress.FormattingEnabled = true;
            this.cmbselectaddress.Location = new System.Drawing.Point(751, 63);
            this.cmbselectaddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbselectaddress.Name = "cmbselectaddress";
            this.cmbselectaddress.Size = new System.Drawing.Size(168, 28);
            this.cmbselectaddress.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(695, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "หน่วย";
            // 
            // chkmove_in
            // 
            this.chkmove_in.AutoSize = true;
            this.chkmove_in.Location = new System.Drawing.Point(24, 108);
            this.chkmove_in.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkmove_in.Name = "chkmove_in";
            this.chkmove_in.Size = new System.Drawing.Size(182, 24);
            this.chkmove_in.TabIndex = 29;
            this.chkmove_in.Text = "แสดงเฉพาะคนย้ายเข้า";
            this.chkmove_in.UseVisualStyleBackColor = true;
            this.chkmove_in.CheckedChanged += new System.EventHandler(this.chkmove_in_CheckedChanged);
            // 
            // txtrank
            // 
            this.txtrank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtrank.Location = new System.Drawing.Point(583, 65);
            this.txtrank.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtrank.MaxLength = 13;
            this.txtrank.Multiline = true;
            this.txtrank.Name = "txtrank";
            this.txtrank.Size = new System.Drawing.Size(61, 26);
            this.txtrank.TabIndex = 5;
            this.txtrank.TextChanged += new System.EventHandler(this.txtrank_TextChanged);
            // 
            // txtbook_number
            // 
            this.txtbook_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtbook_number.Location = new System.Drawing.Point(460, 65);
            this.txtbook_number.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbook_number.MaxLength = 13;
            this.txtbook_number.Multiline = true;
            this.txtbook_number.Name = "txtbook_number";
            this.txtbook_number.Size = new System.Drawing.Size(59, 26);
            this.txtbook_number.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(524, 70);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "ลำดับที่";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "เลขบัตรประจำตัวประชาชน";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "เล่มที่";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "ผลัด";
            // 
            // mtxtYearin
            // 
            this.mtxtYearin.Location = new System.Drawing.Point(208, 27);
            this.mtxtYearin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mtxtYearin.Mask = "0/00";
            this.mtxtYearin.Name = "mtxtYearin";
            this.mtxtYearin.Size = new System.Drawing.Size(56, 26);
            this.mtxtYearin.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(680, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "นามสกุล";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(423, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "ชื่อ";
            // 
            // lblcount
            // 
            this.lblcount.AutoSize = true;
            this.lblcount.Location = new System.Drawing.Point(28, 706);
            this.lblcount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(54, 17);
            this.lblcount.TabIndex = 30;
            this.lblcount.Text = "Record";
            // 
            // navy_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 777);
            this.Controls.Add(this.lblcount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdData);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "navy_search";
            this.Text = "ค้นหาข้อมูลทะเบียนบ้าน";
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtlname;
        private System.Windows.Forms.TextBox txtid13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtrank;
        private System.Windows.Forms.TextBox txtbook_number;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mtxtYearin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkmove_in;
        private System.Windows.Forms.Label lblcount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbselectaddress;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
    }
}