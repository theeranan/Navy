namespace Navy.Forms
{
    partial class TelephoneNumber_Collection
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
            this.gvResultPhonNumber = new System.Windows.Forms.DataGridView();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Cmb_Company = new System.Windows.Forms.ComboBox();
            this.Cmb_Batt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Count = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResultPhonNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_Batt);
            this.groupBox1.Controls.Add(this.Label_Company);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Label_Batt
            // 
            this.Label_Batt.AutoSize = true;
            this.Label_Batt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Batt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_Batt.Location = new System.Drawing.Point(531, 14);
            this.Label_Batt.Name = "Label_Batt";
            this.Label_Batt.Size = new System.Drawing.Size(16, 22);
            this.Label_Batt.TabIndex = 12;
            this.Label_Batt.Text = ".";
            // 
            // Label_Company
            // 
            this.Label_Company.AutoSize = true;
            this.Label_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Company.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_Company.Location = new System.Drawing.Point(280, 14);
            this.Label_Company.Name = "Label_Company";
            this.Label_Company.Size = new System.Drawing.Size(16, 22);
            this.Label_Company.TabIndex = 13;
            this.Label_Company.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(449, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "กองพันที่";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(193, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "กองร้อยที่";
            // 
            // gvResultPhonNumber
            // 
            this.gvResultPhonNumber.AllowUserToOrderColumns = true;
            this.gvResultPhonNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResultPhonNumber.Location = new System.Drawing.Point(12, 91);
            this.gvResultPhonNumber.Name = "gvResultPhonNumber";
            this.gvResultPhonNumber.Size = new System.Drawing.Size(773, 467);
            this.gvResultPhonNumber.TabIndex = 1;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Save.Location = new System.Drawing.Point(681, 566);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(104, 39);
            this.Btn_Save.TabIndex = 6;
            this.Btn_Save.Text = "บันทึก";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "กองร้อย";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(183, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "กองพัน";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(361, 14);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 23);
            this.Btn_Search.TabIndex = 4;
            this.Btn_Search.Text = "ค้นหา";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Cmb_Company
            // 
            this.Cmb_Company.FormattingEnabled = true;
            this.Cmb_Company.Location = new System.Drawing.Point(62, 14);
            this.Cmb_Company.Name = "Cmb_Company";
            this.Cmb_Company.Size = new System.Drawing.Size(88, 21);
            this.Cmb_Company.TabIndex = 2;
            // 
            // Cmb_Batt
            // 
            this.Cmb_Batt.FormattingEnabled = true;
            this.Cmb_Batt.Location = new System.Drawing.Point(230, 14);
            this.Cmb_Batt.Name = "Cmb_Batt";
            this.Cmb_Batt.Size = new System.Drawing.Size(88, 21);
            this.Cmb_Batt.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 566);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ผลลัพธ์";
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Location = new System.Drawing.Point(58, 566);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(10, 13);
            this.label_Count.TabIndex = 11;
            this.label_Count.Text = ".";
            // 
            // TelephoneNumber_Collection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 612);
            this.Controls.Add(this.label_Count);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cmb_Batt);
            this.Controls.Add(this.Cmb_Company);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.gvResultPhonNumber);
            this.Controls.Add(this.groupBox1);
            this.Name = "TelephoneNumber_Collection";
            this.Text = "ฟอร์มกรอกเบอร์โทรศัพท์";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResultPhonNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Label_Batt;
        private System.Windows.Forms.Label Label_Company;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvResultPhonNumber;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.ComboBox Cmb_Company;
        private System.Windows.Forms.ComboBox Cmb_Batt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_Count;
    }
}