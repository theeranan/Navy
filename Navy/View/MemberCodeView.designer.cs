namespace Navy.View
{
    partial class MemberCodeView
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
            this.cbA1 = new System.Windows.Forms.ComboBox();
            this.cbA2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.cbA1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbA2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbA1
            // 
            this.cbA1.FormattingEnabled = true;
            this.cbA1.Location = new System.Drawing.Point(3, 3);
            this.cbA1.Name = "cbA1";
            this.cbA1.Size = new System.Drawing.Size(150, 21);
            this.cbA1.TabIndex = 0;
            this.cbA1.SelectedIndexChanged += new System.EventHandler(this.cbA1_SelectedIndexChanged);
            this.cbA1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbA1_KeyDown);
            // 
            // cbA2
            // 
            this.cbA2.FormattingEnabled = true;
            this.cbA2.Location = new System.Drawing.Point(168, 3);
            this.cbA2.Name = "cbA2";
            this.cbA2.Size = new System.Drawing.Size(170, 21);
            this.cbA2.TabIndex = 1;
            this.cbA2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbA2_KeyDown);
            // 
            // MemberCodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MemberCodeView";
            this.Size = new System.Drawing.Size(550, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbA1;
        private System.Windows.Forms.ComboBox cbA2;
    }
}
