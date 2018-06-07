namespace Navy.Forms
{
    partial class View_Indictment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Indictment));
            this.panelDetail = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gv_Indictment = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Add_Indictment = new System.Windows.Forms.Button();
            this.Remove_Indictment = new System.Windows.Forms.Button();
            this.Edit_Indictment = new System.Windows.Forms.Button();
            this.panelDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Indictment)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.button1);
            this.panelDetail.Location = new System.Drawing.Point(9, 118);
            this.panelDetail.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(1203, 562);
            this.panelDetail.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1158, 513);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 49);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(4, 6);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(1185, 39);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.txtName, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1194, 75);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(1097, 252);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(75, 36);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "พิมพ์";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox1.Size = new System.Drawing.Size(1203, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // gv_Indictment
            // 
            this.gv_Indictment.AllowUserToAddRows = false;
            this.gv_Indictment.AllowUserToDeleteRows = false;
            this.gv_Indictment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gv_Indictment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.gv_Indictment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gv_Indictment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_Indictment.Location = new System.Drawing.Point(4, 29);
            this.gv_Indictment.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gv_Indictment.MultiSelect = false;
            this.gv_Indictment.Name = "gv_Indictment";
            this.gv_Indictment.ReadOnly = true;
            this.gv_Indictment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_Indictment.Size = new System.Drawing.Size(1195, 408);
            this.gv_Indictment.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gv_Indictment);
            this.groupBox2.Location = new System.Drawing.Point(9, 691);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Size = new System.Drawing.Size(1203, 443);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อหา";
            // 
            // Add_Indictment
            // 
            this.Add_Indictment.Location = new System.Drawing.Point(18, 1144);
            this.Add_Indictment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Add_Indictment.Name = "Add_Indictment";
            this.Add_Indictment.Size = new System.Drawing.Size(112, 40);
            this.Add_Indictment.TabIndex = 8;
            this.Add_Indictment.Text = "เพิ่มข้อหา";
            this.Add_Indictment.UseVisualStyleBackColor = true;
            this.Add_Indictment.Click += new System.EventHandler(this.Add_Indictment_Click);
            // 
            // Remove_Indictment
            // 
            this.Remove_Indictment.Location = new System.Drawing.Point(968, 1144);
            this.Remove_Indictment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Remove_Indictment.Name = "Remove_Indictment";
            this.Remove_Indictment.Size = new System.Drawing.Size(112, 40);
            this.Remove_Indictment.TabIndex = 9;
            this.Remove_Indictment.Text = "ลบข้อหา";
            this.Remove_Indictment.UseVisualStyleBackColor = true;
            this.Remove_Indictment.Click += new System.EventHandler(this.Remove_Indictment_Click);
            // 
            // Edit_Indictment
            // 
            this.Edit_Indictment.Location = new System.Drawing.Point(1089, 1144);
            this.Edit_Indictment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Edit_Indictment.Name = "Edit_Indictment";
            this.Edit_Indictment.Size = new System.Drawing.Size(112, 40);
            this.Edit_Indictment.TabIndex = 10;
            this.Edit_Indictment.Text = "แก้ไข";
            this.Edit_Indictment.UseVisualStyleBackColor = true;
            this.Edit_Indictment.Click += new System.EventHandler(this.Edit_Indictment_Click);
            // 
            // View_Indictment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 1055);
            this.Controls.Add(this.Edit_Indictment);
            this.Controls.Add(this.Remove_Indictment);
            this.Controls.Add(this.Add_Indictment);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "View_Indictment";
            this.Text = "ข้อมูลข้อหาทหาร";
            this.panelDetail.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Indictment)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gv_Indictment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Add_Indictment;
        private System.Windows.Forms.Button Remove_Indictment;
        private System.Windows.Forms.Button Edit_Indictment;
        private System.Windows.Forms.Button button1;
    }
}