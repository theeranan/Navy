namespace Navy.People
{
    partial class SelectAddressmore
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
            this.btnaddress_old = new System.Windows.Forms.Button();
            this.btnaddress_new = new System.Windows.Forms.Button();
            this.btnaddressunit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnaddress_old
            // 
            this.btnaddress_old.Location = new System.Drawing.Point(60, 22);
            this.btnaddress_old.Name = "btnaddress_old";
            this.btnaddress_old.Size = new System.Drawing.Size(213, 32);
            this.btnaddress_old.TabIndex = 0;
            this.btnaddress_old.Text = "ย้ายกลับภูมิลำเนาเดิม";
            this.btnaddress_old.UseVisualStyleBackColor = true;
            this.btnaddress_old.Click += new System.EventHandler(this.btnaddress_old_Click);
            // 
            // btnaddress_new
            // 
            this.btnaddress_new.Location = new System.Drawing.Point(60, 60);
            this.btnaddress_new.Name = "btnaddress_new";
            this.btnaddress_new.Size = new System.Drawing.Size(213, 32);
            this.btnaddress_new.TabIndex = 1;
            this.btnaddress_new.Text = "ย้ายไปที่อยู่ใหม่";
            this.btnaddress_new.UseVisualStyleBackColor = true;
            this.btnaddress_new.Click += new System.EventHandler(this.btnaddress_new_Click);
            // 
            // btnaddressunit
            // 
            this.btnaddressunit.Location = new System.Drawing.Point(60, 98);
            this.btnaddressunit.Name = "btnaddressunit";
            this.btnaddressunit.Size = new System.Drawing.Size(213, 33);
            this.btnaddressunit.TabIndex = 2;
            this.btnaddressunit.Text = "ย้ายเข้าหน่วย ทร.";
            this.btnaddressunit.UseVisualStyleBackColor = true;
            this.btnaddressunit.Click += new System.EventHandler(this.btnaddressunit_Click);
            // 
            // SelectAddressmore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 143);
            this.Controls.Add(this.btnaddressunit);
            this.Controls.Add(this.btnaddress_new);
            this.Controls.Add(this.btnaddress_old);
            this.Name = "SelectAddressmore";
            this.Text = "เลือกสถานที่ย้ายกลับ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnaddress_old;
        private System.Windows.Forms.Button btnaddress_new;
        private System.Windows.Forms.Button btnaddressunit;
    }
}