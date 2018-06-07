namespace Navy.Forms
{
    partial class SelectDatabaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDatabaseForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.txtHost, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUser, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDatabase, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbDatabase, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirm, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnDefault, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblHost, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUser, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-69, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 516);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtHost
            // 
            this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHost.Location = new System.Drawing.Point(262, 34);
            this.txtHost.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(239, 30);
            this.txtHost.TabIndex = 1;
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            this.txtHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHost_KeyDown);
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUser.Location = new System.Drawing.Point(262, 104);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(239, 30);
            this.txtUser.TabIndex = 2;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(168, 174);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPassword.Location = new System.Drawing.Point(262, 174);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(239, 30);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(167, 244);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(81, 23);
            this.lblDatabase.TabIndex = 6;
            this.lblDatabase.Text = "Database";
            // 
            // cbDatabase
            // 
            this.cbDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(262, 243);
            this.cbDatabase.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(239, 31);
            this.cbDatabase.TabIndex = 4;
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            this.cbDatabase.Click += new System.EventHandler(this.cbDatabase_Click);
            this.cbDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDatabase_KeyDown);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Location = new System.Drawing.Point(262, 304);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(112, 40);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "ตกลง";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.Location = new System.Drawing.Point(142, 304);
            this.btnDefault.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(112, 40);
            this.btnDefault.TabIndex = 11;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // lblHost
            // 
            this.lblHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(203, 34);
            this.lblHost.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(45, 23);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(204, 104);
            this.lblUser.Margin = new System.Windows.Forms.Padding(10, 13, 10, 13);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(44, 23);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User";
            // 
            // SelectDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "SelectDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ฐานข้อมูล";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Button btnDefault;
    }
}