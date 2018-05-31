namespace Navy.View
{
    partial class MemberCode5View
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbStructure = new System.Windows.Forms.ComboBox();
            this.cbMemberCode5 = new System.Windows.Forms.ComboBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.cbStructure, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbMemberCode5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLink, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbStructure
            // 
            this.cbStructure.FormattingEnabled = true;
            this.cbStructure.Location = new System.Drawing.Point(3, 3);
            this.cbStructure.Name = "cbStructure";
            this.cbStructure.Size = new System.Drawing.Size(150, 21);
            this.cbStructure.TabIndex = 0;
            this.cbStructure.SelectedIndexChanged += new System.EventHandler(this.cbStructure_SelectedIndexChanged);
            this.cbStructure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbStructure_KeyDown);
            // 
            // cbMemberCode5
            // 
            this.cbMemberCode5.FormattingEnabled = true;
            this.cbMemberCode5.Location = new System.Drawing.Point(168, 3);
            this.cbMemberCode5.Name = "cbMemberCode5";
            this.cbMemberCode5.Size = new System.Drawing.Size(170, 21);
            this.cbMemberCode5.TabIndex = 1;
            this.cbMemberCode5.SelectedIndexChanged += new System.EventHandler(this.cbMemberCode_SelectedIndexChanged);
            this.cbMemberCode5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMemberCode5_KeyDown);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(360, 3);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(170, 20);
            this.txtLink.TabIndex = 2;
            this.txtLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLink_KeyDown);
            // 
            // MemberCode5View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MemberCode5View";
            this.Size = new System.Drawing.Size(550, 30);
            this.Load += new System.EventHandler(this.MemberCode5View_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbMemberCode5;
        private System.Windows.Forms.TextBox txtLink;
        public System.Windows.Forms.ComboBox cbStructure;
    }
}
