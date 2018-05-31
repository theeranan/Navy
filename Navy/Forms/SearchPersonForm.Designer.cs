﻿namespace Navy.Forms
{
    partial class SearchPersonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchPersonForm));
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxID13 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRunNum = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.mTextBoxID8 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSname = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbProvince = new System.Windows.Forms.ComboBox();
            this.checkBoxSearchNivyAll = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCountSearchRecord = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.labelPaging = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridviewResultControl1 = new Navy.MyControls.GridviewResultControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridviewResultControl2 = new Navy.MyControls.GridviewResultControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gridviewResultControl3 = new Navy.MyControls.GridviewResultControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gridviewResultControl4 = new Navy.MyControls.GridviewResultControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.gridviewResultControl5 = new Navy.MyControls.GridviewResultControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.gridviewResultControl6 = new Navy.MyControls.GridviewResultControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.gridviewResultControl7 = new Navy.MyControls.GridviewResultControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Location = new System.Drawing.Point(8, 23);
            this.gvResult.Margin = new System.Windows.Forms.Padding(4);
            this.gvResult.MultiSelect = false;
            this.gvResult.Name = "gvResult";
            this.gvResult.ReadOnly = true;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(744, 375);
            this.gvResult.TabIndex = 1;
            this.gvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResult_CellContentClick);
            this.gvResult.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvResult_CellMouseDoubleClick);
            this.gvResult.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvResult_RowEnter);
            this.gvResult.SelectionChanged += new System.EventHandler(this.gvResult_SelectionChanged);
            this.gvResult.Click += new System.EventHandler(this.gvResult_Click);
            this.gvResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvResult_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxID13);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxRunNum);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.mTextBoxID8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mtxtYearin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxSname);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbProvince);
            this.groupBox1.Controls.Add(this.checkBoxSearchNivyAll);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(783, 95);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ฟอร์มค้นหา";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "เลขประจำตัวประชาชน";
            // 
            // textBoxID13
            // 
            this.textBoxID13.Location = new System.Drawing.Point(374, 19);
            this.textBoxID13.MaxLength = 13;
            this.textBoxID13.Name = "textBoxID13";
            this.textBoxID13.Size = new System.Drawing.Size(186, 22);
            this.textBoxID13.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "RunCode";
            // 
            // textBoxRunNum
            // 
            this.textBoxRunNum.Location = new System.Drawing.Point(673, 20);
            this.textBoxRunNum.MaxLength = 10;
            this.textBoxRunNum.Name = "textBoxRunNum";
            this.textBoxRunNum.Size = new System.Drawing.Size(100, 22);
            this.textBoxRunNum.TabIndex = 5;
            this.textBoxRunNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRunNum_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(657, 67);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // mTextBoxID8
            // 
            this.mTextBoxID8.Location = new System.Drawing.Point(166, 19);
            this.mTextBoxID8.Mask = "a.a.0000";
            this.mTextBoxID8.Name = "mTextBoxID8";
            this.mTextBoxID8.Size = new System.Drawing.Size(65, 22);
            this.mTextBoxID8.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "ทะเบียน";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "ผลัด";
            // 
            // mtxtYearin
            // 
            this.mtxtYearin.Location = new System.Drawing.Point(44, 19);
            this.mtxtYearin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxtYearin.Mask = "0/00";
            this.mtxtYearin.Name = "mtxtYearin";
            this.mtxtYearin.Size = new System.Drawing.Size(43, 22);
            this.mtxtYearin.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "นามสกุล";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "ชื่อ";
            // 
            // textBoxSname
            // 
            this.textBoxSname.Location = new System.Drawing.Point(245, 51);
            this.textBoxSname.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSname.MaxLength = 50;
            this.textBoxSname.Name = "textBoxSname";
            this.textBoxSname.Size = new System.Drawing.Size(132, 22);
            this.textBoxSname.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(44, 51);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(132, 22);
            this.textBoxName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "จังหวัด";
            // 
            // cbbProvince
            // 
            this.cbbProvince.DropDownWidth = 100;
            this.cbbProvince.FormattingEnabled = true;
            this.cbbProvince.Location = new System.Drawing.Point(460, 51);
            this.cbbProvince.Name = "cbbProvince";
            this.cbbProvince.Size = new System.Drawing.Size(121, 24);
            this.cbbProvince.TabIndex = 6;
            // 
            // checkBoxSearchNivyAll
            // 
            this.checkBoxSearchNivyAll.AutoSize = true;
            this.checkBoxSearchNivyAll.Location = new System.Drawing.Point(7, 73);
            this.checkBoxSearchNivyAll.Name = "checkBoxSearchNivyAll";
            this.checkBoxSearchNivyAll.Size = new System.Drawing.Size(126, 20);
            this.checkBoxSearchNivyAll.TabIndex = 10;
            this.checkBoxSearchNivyAll.Text = "แสดงข้อมูลทุกคอลัมน์";
            this.checkBoxSearchNivyAll.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Controls.Add(this.gvResult);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox3.Location = new System.Drawing.Point(7, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(762, 437);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ผลการค้นหา";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(8, 404);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.labelCountSearchRecord);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(744, 27);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "ใช้เวลา";
            // 
            // labelCountSearchRecord
            // 
            this.labelCountSearchRecord.AutoSize = true;
            this.labelCountSearchRecord.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCountSearchRecord.Location = new System.Drawing.Point(0, 11);
            this.labelCountSearchRecord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCountSearchRecord.Name = "labelCountSearchRecord";
            this.labelCountSearchRecord.Size = new System.Drawing.Size(77, 16);
            this.labelCountSearchRecord.TabIndex = 0;
            this.labelCountSearchRecord.Text = "x Record(s)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "label8";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrevPage);
            this.panel1.Controls.Add(this.btnNextPage);
            this.panel1.Controls.Add(this.labelPaging);
            this.panel1.Location = new System.Drawing.Point(361, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 22);
            this.panel1.TabIndex = 2;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrevPage.Location = new System.Drawing.Point(0, 0);
            this.btnPrevPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(67, 22);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.Text = "< ย้อนกลับ";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNextPage.Location = new System.Drawing.Point(133, 0);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(55, 22);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.Text = "ต่อไป >";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // labelPaging
            // 
            this.labelPaging.AutoSize = true;
            this.labelPaging.Location = new System.Drawing.Point(75, 3);
            this.labelPaging.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPaging.Name = "labelPaging";
            this.labelPaging.Size = new System.Drawing.Size(28, 16);
            this.labelPaging.TabIndex = 3;
            this.labelPaging.Text = "หน้า";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(676, 615);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 28);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "แก้ไขข้อมูล";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(24, 615);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(11, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 480);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(775, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ทั้งหมด";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridviewResultControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ร้อยเตรียม";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridviewResultControl1
            // 
            this.gridviewResultControl1.EnablePagingData = false;
            this.gridviewResultControl1.ExternalDataSource = false;
            this.gridviewResultControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridviewResultControl1.Location = new System.Drawing.Point(7, 7);
            this.gridviewResultControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridviewResultControl1.Name = "gridviewResultControl1";
            this.gridviewResultControl1.Size = new System.Drawing.Size(752, 426);
            this.gridviewResultControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gridviewResultControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(775, 451);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "เหตุ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gridviewResultControl2
            // 
            this.gridviewResultControl2.EnablePagingData = false;
            this.gridviewResultControl2.ExternalDataSource = false;
            this.gridviewResultControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridviewResultControl2.Location = new System.Drawing.Point(7, 7);
            this.gridviewResultControl2.Margin = new System.Windows.Forms.Padding(4);
            this.gridviewResultControl2.Name = "gridviewResultControl2";
            this.gridviewResultControl2.Size = new System.Drawing.Size(752, 426);
            this.gridviewResultControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gridviewResultControl3);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(775, 451);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ขอลงหน่วย";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gridviewResultControl3
            // 
            this.gridviewResultControl3.EnablePagingData = false;
            this.gridviewResultControl3.ExternalDataSource = false;
            this.gridviewResultControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridviewResultControl3.Location = new System.Drawing.Point(7, 7);
            this.gridviewResultControl3.Margin = new System.Windows.Forms.Padding(4);
            this.gridviewResultControl3.Name = "gridviewResultControl3";
            this.gridviewResultControl3.Size = new System.Drawing.Size(752, 426);
            this.gridviewResultControl3.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gridviewResultControl4);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(775, 451);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "คัดเลือกหน่วย";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // gridviewResultControl4
            // 
            this.gridviewResultControl4.EnablePagingData = false;
            this.gridviewResultControl4.ExternalDataSource = false;
            this.gridviewResultControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridviewResultControl4.Location = new System.Drawing.Point(7, 7);
            this.gridviewResultControl4.Margin = new System.Windows.Forms.Padding(4);
            this.gridviewResultControl4.Name = "gridviewResultControl4";
            this.gridviewResultControl4.Size = new System.Drawing.Size(752, 426);
            this.gridviewResultControl4.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.gridviewResultControl5);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(775, 451);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "การศึกษา";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // gridviewResultControl5
            // 
            this.gridviewResultControl5.EnablePagingData = false;
            this.gridviewResultControl5.ExternalDataSource = false;
            this.gridviewResultControl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridviewResultControl5.Location = new System.Drawing.Point(7, 7);
            this.gridviewResultControl5.Margin = new System.Windows.Forms.Padding(4);
            this.gridviewResultControl5.Name = "gridviewResultControl5";
            this.gridviewResultControl5.Size = new System.Drawing.Size(752, 426);
            this.gridviewResultControl5.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.gridviewResultControl6);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(775, 451);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "ความรู้พิเศษ";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // gridviewResultControl6
            // 
            this.gridviewResultControl6.EnablePagingData = false;
            this.gridviewResultControl6.ExternalDataSource = false;
            this.gridviewResultControl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridviewResultControl6.Location = new System.Drawing.Point(7, 7);
            this.gridviewResultControl6.Margin = new System.Windows.Forms.Padding(4);
            this.gridviewResultControl6.Name = "gridviewResultControl6";
            this.gridviewResultControl6.Size = new System.Drawing.Size(752, 426);
            this.gridviewResultControl6.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.gridviewResultControl7);
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(775, 451);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "สามัญ";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // gridviewResultControl7
            // 
            this.gridviewResultControl7.EnablePagingData = false;
            this.gridviewResultControl7.ExternalDataSource = false;
            this.gridviewResultControl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridviewResultControl7.Location = new System.Drawing.Point(7, 7);
            this.gridviewResultControl7.Margin = new System.Windows.Forms.Padding(4);
            this.gridviewResultControl7.Name = "gridviewResultControl7";
            this.gridviewResultControl7.Size = new System.Drawing.Size(752, 426);
            this.gridviewResultControl7.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(16, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 502);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ผลการค้นหา";
            // 
            // SearchPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 647);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchPersonForm";
            this.Text = "ค้นหาข้อมูล ทหารพลกองประจำการ";
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCountSearchRecord;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelPaging;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckBox checkBoxSearchNivyAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbProvince;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox mTextBoxID8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtYearin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSname;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRunNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private MyControls.GridviewResultControl gridviewResultControl1;
        private MyControls.GridviewResultControl gridviewResultControl2;
        private MyControls.GridviewResultControl gridviewResultControl3;
        private MyControls.GridviewResultControl gridviewResultControl4;
        private MyControls.GridviewResultControl gridviewResultControl5;
        private MyControls.GridviewResultControl gridviewResultControl6;
        private MyControls.GridviewResultControl gridviewResultControl7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxID13;
    }
}