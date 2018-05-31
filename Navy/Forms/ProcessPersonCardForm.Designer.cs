namespace Navy.Forms
{
    partial class ProcessPersonCardForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cbbArmtown = new System.Windows.Forms.ComboBox();
            this.labelCountImageFiles = new System.Windows.Forms.Label();
            this.btnImgPre = new System.Windows.Forms.Button();
            this.btnImgNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCountFileSaved = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gvFileList = new System.Windows.Forms.DataGridView();
            this.searchPersonNivyInputControl1 = new Navy.MyControls.SearchPersonNivyInputControl();
            this.personCardControl1 = new Navy.MyControls.PersonCardControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.personCardControl1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(335, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 222);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "บัตรประจำตัวประชาชน";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvResult);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(15, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 248);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลจากฐานข้อมูล";
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Location = new System.Drawing.Point(7, 22);
            this.gvResult.Margin = new System.Windows.Forms.Padding(4);
            this.gvResult.MultiSelect = false;
            this.gvResult.Name = "gvResult";
            this.gvResult.ReadOnly = true;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(420, 219);
            this.gvResult.TabIndex = 5;
            this.gvResult.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResult_RowEnter);
            this.gvResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvResult_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.searchPersonNivyInputControl1);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(457, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 192);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ข้อมูลจากการประมวลผล";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(697, 526);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "บันทึก";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbbArmtown
            // 
            this.cbbArmtown.FormattingEnabled = true;
            this.cbbArmtown.Location = new System.Drawing.Point(81, 9);
            this.cbbArmtown.Name = "cbbArmtown";
            this.cbbArmtown.Size = new System.Drawing.Size(121, 24);
            this.cbbArmtown.TabIndex = 5;
            this.cbbArmtown.SelectedIndexChanged += new System.EventHandler(this.cbbArmtown_SelectedIndexChanged);
            // 
            // labelCountImageFiles
            // 
            this.labelCountImageFiles.AutoSize = true;
            this.labelCountImageFiles.Location = new System.Drawing.Point(359, 12);
            this.labelCountImageFiles.Name = "labelCountImageFiles";
            this.labelCountImageFiles.Size = new System.Drawing.Size(15, 16);
            this.labelCountImageFiles.TabIndex = 6;
            this.labelCountImageFiles.Text = "0";
            // 
            // btnImgPre
            // 
            this.btnImgPre.Location = new System.Drawing.Point(339, 269);
            this.btnImgPre.Name = "btnImgPre";
            this.btnImgPre.Size = new System.Drawing.Size(75, 23);
            this.btnImgPre.TabIndex = 7;
            this.btnImgPre.Text = "<";
            this.btnImgPre.UseVisualStyleBackColor = true;
            this.btnImgPre.Click += new System.EventHandler(this.btnImgPre_Click);
            // 
            // btnImgNext
            // 
            this.btnImgNext.Location = new System.Drawing.Point(420, 269);
            this.btnImgNext.Name = "btnImgNext";
            this.btnImgNext.Size = new System.Drawing.Size(75, 23);
            this.btnImgNext.TabIndex = 8;
            this.btnImgNext.Text = ">";
            this.btnImgNext.UseVisualStyleBackColor = true;
            this.btnImgNext.Click += new System.EventHandler(this.btnImgNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "เลือกจังหวัด";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "ทั้งหมด";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "บันทึกแล้ว";
            // 
            // labelCountFileSaved
            // 
            this.labelCountFileSaved.AutoSize = true;
            this.labelCountFileSaved.Location = new System.Drawing.Point(499, 13);
            this.labelCountFileSaved.Name = "labelCountFileSaved";
            this.labelCountFileSaved.Size = new System.Drawing.Size(15, 16);
            this.labelCountFileSaved.TabIndex = 12;
            this.labelCountFileSaved.Text = "0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(209, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "โหลด";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvFileList);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox4.Location = new System.Drawing.Point(16, 39);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 248);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ไฟล์รูปภาพ";
            // 
            // gvFileList
            // 
            this.gvFileList.AllowUserToAddRows = false;
            this.gvFileList.AllowUserToDeleteRows = false;
            this.gvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFileList.Location = new System.Drawing.Point(7, 22);
            this.gvFileList.Margin = new System.Windows.Forms.Padding(4);
            this.gvFileList.MultiSelect = false;
            this.gvFileList.Name = "gvFileList";
            this.gvFileList.ReadOnly = true;
            this.gvFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFileList.Size = new System.Drawing.Size(299, 219);
            this.gvFileList.TabIndex = 5;
            this.gvFileList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFileList_RowEnter);
            // 
            // searchPersonNivyInputControl1
            // 
            this.searchPersonNivyInputControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPersonNivyInputControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.searchPersonNivyInputControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchPersonNivyInputControl1.Location = new System.Drawing.Point(3, 18);
            this.searchPersonNivyInputControl1.Margin = new System.Windows.Forms.Padding(4);
            this.searchPersonNivyInputControl1.Name = "searchPersonNivyInputControl1";
            this.searchPersonNivyInputControl1.Size = new System.Drawing.Size(309, 171);
            this.searchPersonNivyInputControl1.TabIndex = 0;
            // 
            // personCardControl1
            // 
            this.personCardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personCardControl1.Location = new System.Drawing.Point(3, 18);
            this.personCardControl1.Margin = new System.Windows.Forms.Padding(4);
            this.personCardControl1.Name = "personCardControl1";
            this.personCardControl1.Size = new System.Drawing.Size(431, 201);
            this.personCardControl1.TabIndex = 0;
            // 
            // ProcessPersonCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.labelCountFileSaved);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImgNext);
            this.Controls.Add(this.btnImgPre);
            this.Controls.Add(this.labelCountImageFiles);
            this.Controls.Add(this.cbbArmtown);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProcessPersonCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ตรวจสอบบัตรประจำตัวประชาชน";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvFileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControls.PersonCardControl personCardControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private MyControls.SearchPersonNivyInputControl searchPersonNivyInputControl1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.ComboBox cbbArmtown;
        private System.Windows.Forms.Label labelCountImageFiles;
        private System.Windows.Forms.Button btnImgPre;
        private System.Windows.Forms.Button btnImgNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCountFileSaved;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView gvFileList;
    }
}