namespace Navy.Forms
{
    partial class IndictmentForm
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
            this.chkBox_HaveIndictment = new System.Windows.Forms.CheckBox();
            this.TxtBox_ID8 = new System.Windows.Forms.MaskedTextBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.TxtBox_Yearin = new System.Windows.Forms.MaskedTextBox();
            this.TxtBox_ID13 = new System.Windows.Forms.TextBox();
            this.TxtBox_Sname = new System.Windows.Forms.TextBox();
            this.TxtBox_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Yearin = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gv_result = new System.Windows.Forms.DataGridView();
            this.Btn_GetIndictData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_result)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBox_HaveIndictment);
            this.groupBox1.Controls.Add(this.TxtBox_ID8);
            this.groupBox1.Controls.Add(this.Btn_Search);
            this.groupBox1.Controls.Add(this.TxtBox_Yearin);
            this.groupBox1.Controls.Add(this.TxtBox_ID13);
            this.groupBox1.Controls.Add(this.TxtBox_Sname);
            this.groupBox1.Controls.Add(this.TxtBox_Name);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_Yearin);
            this.groupBox1.Location = new System.Drawing.Point(18, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox1.Size = new System.Drawing.Size(1143, 194);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ฟอร์มค้นหา";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkBox_HaveIndictment
            // 
            this.chkBox_HaveIndictment.AutoSize = true;
            this.chkBox_HaveIndictment.Location = new System.Drawing.Point(28, 151);
            this.chkBox_HaveIndictment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chkBox_HaveIndictment.Name = "chkBox_HaveIndictment";
            this.chkBox_HaveIndictment.Size = new System.Drawing.Size(178, 27);
            this.chkBox_HaveIndictment.TabIndex = 72;
            this.chkBox_HaveIndictment.Text = "ค้นหาเฉพาะผู้ที่มีข้อหา";
            this.chkBox_HaveIndictment.UseVisualStyleBackColor = true;
            this.chkBox_HaveIndictment.CheckedChanged += new System.EventHandler(this.chkBox_HaveIndictment_CheckedChanged);
            // 
            // TxtBox_ID8
            // 
            this.TxtBox_ID8.Location = new System.Drawing.Point(370, 45);
            this.TxtBox_ID8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TxtBox_ID8.Mask = "a.a.0000";
            this.TxtBox_ID8.Name = "TxtBox_ID8";
            this.TxtBox_ID8.Size = new System.Drawing.Size(95, 30);
            this.TxtBox_ID8.TabIndex = 67;
            this.TxtBox_ID8.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TxtBox_ID8_MaskInputRejected);
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(1016, 144);
            this.Btn_Search.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(112, 40);
            this.Btn_Search.TabIndex = 71;
            this.Btn_Search.Text = "ค้นหา";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // TxtBox_Yearin
            // 
            this.TxtBox_Yearin.Location = new System.Drawing.Point(75, 45);
            this.TxtBox_Yearin.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.TxtBox_Yearin.Mask = "0/00";
            this.TxtBox_Yearin.Name = "TxtBox_Yearin";
            this.TxtBox_Yearin.Size = new System.Drawing.Size(62, 30);
            this.TxtBox_Yearin.TabIndex = 66;
            this.TxtBox_Yearin.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TxtBox_Yearin_MaskInputRejected);
            // 
            // TxtBox_ID13
            // 
            this.TxtBox_ID13.Location = new System.Drawing.Point(762, 101);
            this.TxtBox_ID13.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TxtBox_ID13.Name = "TxtBox_ID13";
            this.TxtBox_ID13.Size = new System.Drawing.Size(181, 30);
            this.TxtBox_ID13.TabIndex = 70;
            this.TxtBox_ID13.TextChanged += new System.EventHandler(this.TxtBox_ID13_TextChanged);
            // 
            // TxtBox_Sname
            // 
            this.TxtBox_Sname.Location = new System.Drawing.Point(370, 101);
            this.TxtBox_Sname.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TxtBox_Sname.Name = "TxtBox_Sname";
            this.TxtBox_Sname.Size = new System.Drawing.Size(170, 30);
            this.TxtBox_Sname.TabIndex = 69;
            this.TxtBox_Sname.TextChanged += new System.EventHandler(this.TxtBox_Sname_TextChanged);
            // 
            // TxtBox_Name
            // 
            this.TxtBox_Name.Location = new System.Drawing.Point(75, 99);
            this.TxtBox_Name.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TxtBox_Name.Name = "TxtBox_Name";
            this.TxtBox_Name.Size = new System.Drawing.Size(169, 30);
            this.TxtBox_Name.TabIndex = 68;
            this.TxtBox_Name.TextChanged += new System.EventHandler(this.TxtBox_Name_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 49);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 23);
            this.label5.TabIndex = 65;
            this.label5.Text = "ทะเบียน";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(588, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 23);
            this.label4.TabIndex = 64;
            this.label4.Text = "เลขประจำตัวประชาชน";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 23);
            this.label3.TabIndex = 63;
            this.label3.Text = "นามสกุล";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 23);
            this.label2.TabIndex = 62;
            this.label2.Text = "ชื่อ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_Yearin
            // 
            this.label_Yearin.AutoSize = true;
            this.label_Yearin.Location = new System.Drawing.Point(26, 49);
            this.label_Yearin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Yearin.Name = "label_Yearin";
            this.label_Yearin.Size = new System.Drawing.Size(39, 23);
            this.label_Yearin.TabIndex = 61;
            this.label_Yearin.Text = "ผลัด";
            this.label_Yearin.Click += new System.EventHandler(this.label_Yearin_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gv_result);
            this.groupBox2.Location = new System.Drawing.Point(18, 227);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Size = new System.Drawing.Size(1143, 683);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ผลการค้นหา";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // gv_result
            // 
            this.gv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_result.Location = new System.Drawing.Point(9, 33);
            this.gv_result.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gv_result.Name = "gv_result";
            this.gv_result.ReadOnly = true;
            this.gv_result.Size = new System.Drawing.Size(1119, 638);
            this.gv_result.TabIndex = 74;
            this.gv_result.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_result_CellContentClick);
            this.gv_result.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_result_CellDoubleClick);
            // 
            // Btn_GetIndictData
            // 
            this.Btn_GetIndictData.Location = new System.Drawing.Point(1034, 921);
            this.Btn_GetIndictData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Btn_GetIndictData.Name = "Btn_GetIndictData";
            this.Btn_GetIndictData.Size = new System.Drawing.Size(112, 40);
            this.Btn_GetIndictData.TabIndex = 78;
            this.Btn_GetIndictData.Text = "ดูข้อมูล";
            this.Btn_GetIndictData.UseVisualStyleBackColor = true;
            this.Btn_GetIndictData.Click += new System.EventHandler(this.Btn_GetIndictData_Click);
            // 
            // IndictmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 975);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btn_GetIndictData);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "IndictmentForm";
            this.Text = "ข้อหาพลทหาร";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox TxtBox_ID8;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.MaskedTextBox TxtBox_Yearin;
        private System.Windows.Forms.TextBox TxtBox_ID13;
        private System.Windows.Forms.TextBox TxtBox_Sname;
        private System.Windows.Forms.TextBox TxtBox_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Yearin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gv_result;
        private System.Windows.Forms.Button Btn_GetIndictData;
        private System.Windows.Forms.CheckBox chkBox_HaveIndictment;
    }
}