namespace Navy
{
    partial class MainWindowFormLite
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.เพมขอมลToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.รายงานToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportRTCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportOtherUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.เครองมอToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportSqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ลางฐานขอมลToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.เพมขอมลToolStripMenuItem,
            this.รายงานToolStripMenuItem,
            this.เครองมอToolStripMenuItem,
            this.SelectDBToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(327, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // เพมขอมลToolStripMenuItem
            // 
            this.เพมขอมลToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PersonRequestToolStripMenuItem});
            this.เพมขอมลToolStripMenuItem.Name = "เพมขอมลToolStripMenuItem";
            this.เพมขอมลToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.เพมขอมลToolStripMenuItem.Text = "เพิ่มข้อมูล";
            // 
            // PersonRequestToolStripMenuItem
            // 
            this.PersonRequestToolStripMenuItem.Name = "PersonRequestToolStripMenuItem";
            this.PersonRequestToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.PersonRequestToolStripMenuItem.Text = "ร้องขอย้ายหน่วย";
            this.PersonRequestToolStripMenuItem.Click += new System.EventHandler(this.PersonRequestToolStripMenuItem_Click);
            // 
            // รายงานToolStripMenuItem
            // 
            this.รายงานToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportRTCToolStripMenuItem,
            this.ReportOtherUnitToolStripMenuItem});
            this.รายงานToolStripMenuItem.Name = "รายงานToolStripMenuItem";
            this.รายงานToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.รายงานToolStripMenuItem.Text = "รายงาน";
            // 
            // reportRTCToolStripMenuItem
            // 
            this.reportRTCToolStripMenuItem.Name = "reportRTCToolStripMenuItem";
            this.reportRTCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reportRTCToolStripMenuItem.Text = "สังกัดศฝท.";
            this.reportRTCToolStripMenuItem.Click += new System.EventHandler(this.reportRTCToolStripMenuItem_Click);
            // 
            // ReportOtherUnitToolStripMenuItem
            // 
            this.ReportOtherUnitToolStripMenuItem.Name = "ReportOtherUnitToolStripMenuItem";
            this.ReportOtherUnitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ReportOtherUnitToolStripMenuItem.Text = "สังกัดหน่วยอื่น";
            this.ReportOtherUnitToolStripMenuItem.Click += new System.EventHandler(this.ReportOtherUnitToolStripMenuItem_Click);
            // 
            // เครองมอToolStripMenuItem
            // 
            this.เครองมอToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportSqlToolStripMenuItem,
            this.ลางฐานขอมลToolStripMenuItem});
            this.เครองมอToolStripMenuItem.Name = "เครองมอToolStripMenuItem";
            this.เครองมอToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.เครองมอToolStripMenuItem.Text = "เครื่องมือ";
            this.เครองมอToolStripMenuItem.Visible = false;
            // 
            // ExportSqlToolStripMenuItem
            // 
            this.ExportSqlToolStripMenuItem.Name = "ExportSqlToolStripMenuItem";
            this.ExportSqlToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ExportSqlToolStripMenuItem.Text = "ส่งออกข้อมูลเป็นไฟล์ .sql";
            // 
            // ลางฐานขอมลToolStripMenuItem
            // 
            this.ลางฐานขอมลToolStripMenuItem.Name = "ลางฐานขอมลToolStripMenuItem";
            this.ลางฐานขอมลToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ลางฐานขอมลToolStripMenuItem.Text = "ล้างฐานข้อมูล";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.AboutToolStripMenuItem.Text = "เกี่ยวกับ";
            this.AboutToolStripMenuItem.Visible = false;
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // SelectDBToolStripMenuItem
            // 
            this.SelectDBToolStripMenuItem.Name = "SelectDBToolStripMenuItem";
            this.SelectDBToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.SelectDBToolStripMenuItem.Text = "ตั้งค่าฐานข้อมูล";
            this.SelectDBToolStripMenuItem.Click += new System.EventHandler(this.SelectDBToolStripMenuItem_Click);
            // 
            // MainWindowFormLite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(327, 196);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindowFormLite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navy Lite";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem เพมขอมลToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PersonRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem รายงานToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem เครองมอToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportSqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ลางฐานขอมลToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportRTCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportOtherUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectDBToolStripMenuItem;
    }
}