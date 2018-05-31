namespace Navy.View
{
    partial class PersonSearchBoxView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbId8 = new System.Windows.Forms.GroupBox();
            this.txtID8 = new System.Windows.Forms.MaskedTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbYearin = new System.Windows.Forms.GroupBox();
            this.txtYearin = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.gbName.SuspendLayout();
            this.gbId8.SuspendLayout();
            this.gbYearin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbName);
            this.panel1.Controls.Add(this.gbId8);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.gbYearin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(200, 486);
            this.panel1.TabIndex = 1;
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.txtSName);
            this.gbName.Controls.Add(this.txtName);
            this.gbName.Controls.Add(this.label2);
            this.gbName.Controls.Add(this.lblName);
            this.gbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbName.Location = new System.Drawing.Point(10, 114);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(180, 100);
            this.gbName.TabIndex = 3;
            this.gbName.TabStop = false;
            this.gbName.Text = "ชื่อ - สกุล";
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(68, 62);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(100, 20);
            this.txtSName.TabIndex = 3;
            this.txtSName.Enter += new System.EventHandler(this.txtSName_Enter);
            this.txtSName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSName_KeyDown);
            this.txtSName.Leave += new System.EventHandler(this.txtSName_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(68, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "นามสกุล";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(42, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(20, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "ชื่อ";
            // 
            // gbId8
            // 
            this.gbId8.Controls.Add(this.txtID8);
            this.gbId8.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbId8.Location = new System.Drawing.Point(10, 60);
            this.gbId8.Name = "gbId8";
            this.gbId8.Size = new System.Drawing.Size(180, 54);
            this.gbId8.TabIndex = 2;
            this.gbId8.TabStop = false;
            this.gbId8.Text = "ทะเบียน";
            // 
            // txtID8
            // 
            this.txtID8.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtID8.Location = new System.Drawing.Point(63, 19);
            this.txtID8.Mask = "a.a.0000";
            this.txtID8.Name = "txtID8";
            this.txtID8.Size = new System.Drawing.Size(58, 20);
            this.txtID8.TabIndex = 3;
            this.txtID8.Enter += new System.EventHandler(this.txtID8_Enter);
            this.txtID8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID8_KeyDown);
            this.txtID8.Leave += new System.EventHandler(this.txtID8_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(115, 440);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbYearin
            // 
            this.gbYearin.Controls.Add(this.txtYearin);
            this.gbYearin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbYearin.Location = new System.Drawing.Point(10, 10);
            this.gbYearin.Name = "gbYearin";
            this.gbYearin.Size = new System.Drawing.Size(180, 50);
            this.gbYearin.TabIndex = 1;
            this.gbYearin.TabStop = false;
            this.gbYearin.Text = "ผลัด";
            // 
            // txtYearin
            // 
            this.txtYearin.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtYearin.Location = new System.Drawing.Point(63, 19);
            this.txtYearin.Mask = "0/00";
            this.txtYearin.Name = "txtYearin";
            this.txtYearin.Size = new System.Drawing.Size(46, 20);
            this.txtYearin.TabIndex = 1;
            this.txtYearin.Enter += new System.EventHandler(this.txtYearin_Enter);
            this.txtYearin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYearin_KeyDown);
            // 
            // PersonSearchBoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PersonSearchBoxView";
            this.Size = new System.Drawing.Size(200, 486);
            this.panel1.ResumeLayout(false);
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.gbId8.ResumeLayout(false);
            this.gbId8.PerformLayout();
            this.gbYearin.ResumeLayout(false);
            this.gbYearin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbYearin;
        private System.Windows.Forms.GroupBox gbId8;
        private System.Windows.Forms.MaskedTextBox txtYearin;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.MaskedTextBox txtID8;
    }
}
