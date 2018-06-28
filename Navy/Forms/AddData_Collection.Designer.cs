namespace Navy.Forms
{
    partial class AddData_Collection
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
            this.Label_Batt = new System.Windows.Forms.Label();
            this.Label_Company = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Cmb_Company = new System.Windows.Forms.ComboBox();
            this.Cmb_Batt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Count = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtsname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mtxtid8 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_Batt);
            this.groupBox1.Controls.Add(this.Label_Company);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1031, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Label_Batt
            // 
            this.Label_Batt.AutoSize = true;
            this.Label_Batt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Batt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_Batt.Location = new System.Drawing.Point(708, 17);
            this.Label_Batt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Batt.Name = "Label_Batt";
            this.Label_Batt.Size = new System.Drawing.Size(19, 26);
            this.Label_Batt.TabIndex = 12;
            this.Label_Batt.Text = ".";
            // 
            // Label_Company
            // 
            this.Label_Company.AutoSize = true;
            this.Label_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Company.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_Company.Location = new System.Drawing.Point(373, 17);
            this.Label_Company.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Company.Name = "Label_Company";
            this.Label_Company.Size = new System.Drawing.Size(19, 26);
            this.Label_Company.TabIndex = 13;
            this.Label_Company.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(599, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "กองพันที่";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(257, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "กองร้อยที่";
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToOrderColumns = true;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Location = new System.Drawing.Point(16, 112);
            this.gvResult.Margin = new System.Windows.Forms.Padding(4);
            this.gvResult.Name = "gvResult";
            this.gvResult.Size = new System.Drawing.Size(1031, 575);
            this.gvResult.TabIndex = 1;
            this.gvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResult_CellClick);
            this.gvResult.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResult_CellValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "กองร้อย";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(213, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "กองพัน";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Search.Location = new System.Drawing.Point(947, 14);
            this.Btn_Search.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(100, 31);
            this.Btn_Search.TabIndex = 7;
            this.Btn_Search.Text = "ค้นหา";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Cmb_Company
            // 
            this.Cmb_Company.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Company.FormattingEnabled = true;
            this.Cmb_Company.Location = new System.Drawing.Point(84, 14);
            this.Cmb_Company.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_Company.Name = "Cmb_Company";
            this.Cmb_Company.Size = new System.Drawing.Size(116, 31);
            this.Cmb_Company.TabIndex = 2;
            // 
            // Cmb_Batt
            // 
            this.Cmb_Batt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Batt.FormattingEnabled = true;
            this.Cmb_Batt.Location = new System.Drawing.Point(278, 14);
            this.Cmb_Batt.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_Batt.Name = "Cmb_Batt";
            this.Cmb_Batt.Size = new System.Drawing.Size(116, 31);
            this.Cmb_Batt.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 697);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "ผลลัพธ์";
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Location = new System.Drawing.Point(77, 697);
            this.label_Count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(12, 17);
            this.label_Count.TabIndex = 11;
            this.label_Count.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(410, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "ชื่อ";
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(446, 14);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(100, 30);
            this.txtname.TabIndex = 4;
            // 
            // txtsname
            // 
            this.txtsname.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsname.Location = new System.Drawing.Point(603, 14);
            this.txtsname.Name = "txtsname";
            this.txtsname.Size = new System.Drawing.Size(100, 30);
            this.txtsname.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(558, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "สกุล";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(723, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "ทะเบียน";
            // 
            // mtxtid8
            // 
            this.mtxtid8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtid8.Location = new System.Drawing.Point(790, 14);
            this.mtxtid8.Mask = "?.?.0000";
            this.mtxtid8.Name = "mtxtid8";
            this.mtxtid8.Size = new System.Drawing.Size(92, 30);
            this.mtxtid8.TabIndex = 6;
            // 
            // AddData_Collection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 753);
            this.Controls.Add(this.mtxtid8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtsname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_Count);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cmb_Batt);
            this.Controls.Add(this.Cmb_Company);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gvResult);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddData_Collection";
            this.Text = "ฟอร์มกรอกเบอร์โทรศัพท์";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Label_Batt;
        private System.Windows.Forms.Label Label_Company;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.ComboBox Cmb_Company;
        private System.Windows.Forms.ComboBox Cmb_Batt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtsname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mtxtid8;
    }
}