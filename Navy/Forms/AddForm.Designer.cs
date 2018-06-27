namespace Navy.Forms
{
    partial class AddForm
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
            this.lblText = new System.Windows.Forms.Label();
            this.cbb = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gvKptclass = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblcountkptclass = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_search = new System.Windows.Forms.Button();
            this.mtxtid8 = new System.Windows.Forms.MaskedTextBox();
            this.txtsname = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblcountsearch = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvKptclass)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(9, 17);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(65, 23);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "หลักสูตร";
            // 
            // cbb
            // 
            this.cbb.FormattingEnabled = true;
            this.cbb.Location = new System.Drawing.Point(80, 14);
            this.cbb.Name = "cbb";
            this.cbb.Size = new System.Drawing.Size(277, 31);
            this.cbb.TabIndex = 1;
            this.cbb.SelectedIndexChanged += new System.EventHandler(this.cbbkptclass_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1047, 559);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gvKptclass);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 553);
            this.panel1.TabIndex = 0;
            // 
            // gvKptclass
            // 
            this.gvKptclass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKptclass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvKptclass.Location = new System.Drawing.Point(0, 107);
            this.gvKptclass.Name = "gvKptclass";
            this.gvKptclass.RowTemplate.Height = 24;
            this.gvKptclass.Size = new System.Drawing.Size(412, 416);
            this.gvKptclass.TabIndex = 2;
            this.gvKptclass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvKptclass_CellContentClick);
            this.gvKptclass.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvKptclass_CellMouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblText);
            this.panel3.Controls.Add(this.cbb);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(412, 107);
            this.panel3.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblcountkptclass);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 523);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(412, 30);
            this.panel6.TabIndex = 4;
            // 
            // lblcountkptclass
            // 
            this.lblcountkptclass.AutoSize = true;
            this.lblcountkptclass.Location = new System.Drawing.Point(61, 3);
            this.lblcountkptclass.Name = "lblcountkptclass";
            this.lblcountkptclass.Size = new System.Drawing.Size(55, 23);
            this.lblcountkptclass.TabIndex = 1;
            this.lblcountkptclass.Text = "label7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "ผลลัพท์:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvSearch);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(525, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 553);
            this.panel2.TabIndex = 1;
            // 
            // gvSearch
            // 
            this.gvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvSearch.Location = new System.Drawing.Point(0, 107);
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.RowTemplate.Height = 24;
            this.gvSearch.Size = new System.Drawing.Size(519, 416);
            this.gvSearch.TabIndex = 1;
            this.gvSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSearch_CellContentClick);
            this.gvSearch.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvSearch_CellMouseDoubleClick);
            this.gvSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvSearch_KeyDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_search);
            this.panel4.Controls.Add(this.mtxtid8);
            this.panel4.Controls.Add(this.txtsname);
            this.panel4.Controls.Add(this.txtname);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(519, 107);
            this.panel4.TabIndex = 0;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(379, 62);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(78, 30);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "ค้นหา";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // mtxtid8
            // 
            this.mtxtid8.Location = new System.Drawing.Point(368, 14);
            this.mtxtid8.Mask = "?.?.0000";
            this.mtxtid8.Name = "mtxtid8";
            this.mtxtid8.Size = new System.Drawing.Size(89, 30);
            this.mtxtid8.TabIndex = 5;
            // 
            // txtsname
            // 
            this.txtsname.Location = new System.Drawing.Point(196, 14);
            this.txtsname.Name = "txtsname";
            this.txtsname.Size = new System.Drawing.Size(100, 30);
            this.txtsname.TabIndex = 4;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(48, 14);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(100, 30);
            this.txtname.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "ทะเบียน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "สกุล";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "ชื่อ";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblcountsearch);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 523);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(519, 30);
            this.panel7.TabIndex = 2;
            // 
            // lblcountsearch
            // 
            this.lblcountsearch.AutoSize = true;
            this.lblcountsearch.Location = new System.Drawing.Point(63, 3);
            this.lblcountsearch.Name = "lblcountsearch";
            this.lblcountsearch.Size = new System.Drawing.Size(55, 23);
            this.lblcountsearch.TabIndex = 2;
            this.lblcountsearch.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "ผลลัพท์:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btndelete);
            this.panel5.Controls.Add(this.btnadd);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(421, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(98, 553);
            this.panel5.TabIndex = 2;
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(3, 98);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(92, 30);
            this.btndelete.TabIndex = 8;
            this.btndelete.Text = ">>";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(3, 62);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(92, 30);
            this.btnadd.TabIndex = 7;
            this.btnadd.Text = "<<";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // Addkptclass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Addkptclass";
            this.Text = "Addkptclass";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvKptclass)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.ComboBox cbb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gvKptclass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MaskedTextBox mtxtid8;
        private System.Windows.Forms.TextBox txtsname;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblcountkptclass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblcountsearch;
        private System.Windows.Forms.Label label6;
    }
}