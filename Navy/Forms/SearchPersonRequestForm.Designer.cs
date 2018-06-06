namespace Navy.Forms
{
    partial class SearchPersonRequestForm
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
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mTextBoxID8 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSname = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbSorting = new System.Windows.Forms.RadioButton();
            this.rbEditOrDelete = new System.Windows.Forms.RadioButton();
            this.rbAddNew = new System.Windows.Forms.RadioButton();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Location = new System.Drawing.Point(8, 26);
            this.gvResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvResult.MultiSelect = false;
            this.gvResult.Name = "gvResult";
            this.gvResult.ReadOnly = true;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(744, 477);
            this.gvResult.TabIndex = 1;
            this.gvResult.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvResult_CellMouseDoubleClick);
            this.gvResult.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResult_RowEnter);
            this.gvResult.SelectionChanged += new System.EventHandler(this.gvResult_SelectionChanged);
            this.gvResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvResult_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.mTextBoxID8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mtxtYearin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxSname);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(123, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(653, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ฟอร์มค้นหา";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(385, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // mTextBoxID8
            // 
            this.mTextBoxID8.Location = new System.Drawing.Point(246, 26);
            this.mTextBoxID8.Mask = "a.a.0000";
            this.mTextBoxID8.Name = "mTextBoxID8";
            this.mTextBoxID8.Size = new System.Drawing.Size(65, 26);
            this.mTextBoxID8.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "ทะเบียน";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "ผลัด";
            // 
            // mtxtYearin
            // 
            this.mtxtYearin.Location = new System.Drawing.Point(45, 26);
            this.mtxtYearin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.mtxtYearin.Mask = "0/00";
            this.mtxtYearin.Name = "mtxtYearin";
            this.mtxtYearin.Size = new System.Drawing.Size(43, 26);
            this.mtxtYearin.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "นามสกุล";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "ชื่อ";
            // 
            // textBoxSname
            // 
            this.textBoxSname.Location = new System.Drawing.Point(246, 63);
            this.textBoxSname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSname.MaxLength = 50;
            this.textBoxSname.Name = "textBoxSname";
            this.textBoxSname.Size = new System.Drawing.Size(132, 26);
            this.textBoxSname.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(45, 63);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(132, 26);
            this.textBoxName.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.statusStrip1);
            this.groupBox2.Controls.Add(this.gvResult);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(16, 153);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(760, 549);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ผลการค้นหา";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(4, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(752, 29);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLabel1.Text = "x Record(s)";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(668, 713);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 32);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "ดูข้อมูล";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(16, 713);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 32);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbSorting);
            this.groupBox3.Controls.Add(this.rbEditOrDelete);
            this.groupBox3.Controls.Add(this.rbAddNew);
            this.groupBox3.Location = new System.Drawing.Point(16, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(100, 113);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "การทำงาน";
            // 
            // rbSorting
            // 
            this.rbSorting.AutoSize = true;
            this.rbSorting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSorting.Location = new System.Drawing.Point(8, 85);
            this.rbSorting.Name = "rbSorting";
            this.rbSorting.Size = new System.Drawing.Size(87, 27);
            this.rbSorting.TabIndex = 2;
            this.rbSorting.Text = "จัดลำดับ";
            this.rbSorting.UseVisualStyleBackColor = true;
            // 
            // rbEditOrDelete
            // 
            this.rbEditOrDelete.AutoSize = true;
            this.rbEditOrDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbEditOrDelete.Location = new System.Drawing.Point(8, 55);
            this.rbEditOrDelete.Name = "rbEditOrDelete";
            this.rbEditOrDelete.Size = new System.Drawing.Size(92, 27);
            this.rbEditOrDelete.TabIndex = 1;
            this.rbEditOrDelete.Text = "แก้ไข/ลบ";
            this.rbEditOrDelete.UseVisualStyleBackColor = true;
            // 
            // rbAddNew
            // 
            this.rbAddNew.AutoSize = true;
            this.rbAddNew.Checked = true;
            this.rbAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbAddNew.Location = new System.Drawing.Point(8, 25);
            this.rbAddNew.Name = "rbAddNew";
            this.rbAddNew.Size = new System.Drawing.Size(95, 27);
            this.rbAddNew.TabIndex = 0;
            this.rbAddNew.TabStop = true;
            this.rbAddNew.Text = "เพิ่มข้อมูล";
            this.rbAddNew.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(560, 713);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 32);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "ออกรายงาน";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // SearchPersonRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 760);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchPersonRequestForm";
            this.Text = "ค้นหาข้อมูล ร้องขอย้ายหน่วย";
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSname;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtYearin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox mTextBoxID8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbEditOrDelete;
        private System.Windows.Forms.RadioButton rbAddNew;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.RadioButton rbSorting;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}