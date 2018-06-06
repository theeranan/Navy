namespace Navy.Forms
{
    partial class AddNewPersonOptionForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbArmtown = new System.Windows.Forms.ComboBox();
            this.dtpRegisDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpComeDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbOrigin = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 245);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "เริ่มบันทึก";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mtxtYearin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbArmtown);
            this.groupBox1.Controls.Add(this.dtpRegisDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpComeDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbOrigin);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(264, 225);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลเริ่มต้น";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 172);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "ประเภท";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "ผลัด";
            // 
            // mtxtYearin
            // 
            this.mtxtYearin.Location = new System.Drawing.Point(112, 25);
            this.mtxtYearin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.mtxtYearin.Mask = "0/00";
            this.mtxtYearin.Name = "mtxtYearin";
            this.mtxtYearin.Size = new System.Drawing.Size(143, 30);
            this.mtxtYearin.TabIndex = 1;
            this.mtxtYearin.TextChanged += new System.EventHandler(this.mtxtYearin_TextChanged);
            this.mtxtYearin.Enter += new System.EventHandler(this.mtxtYearin_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "วันมาถึง";
            // 
            // cbbArmtown
            // 
            this.cbbArmtown.FormattingEnabled = true;
            this.cbbArmtown.Location = new System.Drawing.Point(112, 61);
            this.cbbArmtown.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbbArmtown.Name = "cbbArmtown";
            this.cbbArmtown.Size = new System.Drawing.Size(143, 31);
            this.cbbArmtown.TabIndex = 2;
            this.cbbArmtown.SelectedIndexChanged += new System.EventHandler(this.cbbArmtown_SelectedIndexChanged);
            this.cbbArmtown.Enter += new System.EventHandler(this.cbbArmtown_Enter);
            // 
            // dtpRegisDate
            // 
            this.dtpRegisDate.Location = new System.Drawing.Point(112, 97);
            this.dtpRegisDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpRegisDate.Name = "dtpRegisDate";
            this.dtpRegisDate.Size = new System.Drawing.Size(143, 30);
            this.dtpRegisDate.TabIndex = 3;
            this.dtpRegisDate.ValueChanged += new System.EventHandler(this.dtpRegisDate_ValueChanged);
            this.dtpRegisDate.Enter += new System.EventHandler(this.dtpRegisDate_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "วันเข้ารับราชการ";
            // 
            // dtpComeDate
            // 
            this.dtpComeDate.Location = new System.Drawing.Point(112, 132);
            this.dtpComeDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpComeDate.Name = "dtpComeDate";
            this.dtpComeDate.Size = new System.Drawing.Size(143, 30);
            this.dtpComeDate.TabIndex = 4;
            this.dtpComeDate.Enter += new System.EventHandler(this.dtpComeDate_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "จังหวัด";
            // 
            // cbbOrigin
            // 
            this.cbbOrigin.FormattingEnabled = true;
            this.cbbOrigin.Location = new System.Drawing.Point(112, 169);
            this.cbbOrigin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbbOrigin.Name = "cbbOrigin";
            this.cbbOrigin.Size = new System.Drawing.Size(143, 31);
            this.cbbOrigin.TabIndex = 5;
            this.cbbOrigin.Enter += new System.EventHandler(this.cbbOrigin_Enter);
            // 
            // AddNewPersonOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 291);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "AddNewPersonOptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "งานรับทหารใหม่ - ข้อมูลเริ่มต้น";
            this.Activated += new System.EventHandler(this.AddNewPersonOptionForm_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtYearin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbArmtown;
        private System.Windows.Forms.DateTimePicker dtpRegisDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpComeDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbOrigin;
    }
}