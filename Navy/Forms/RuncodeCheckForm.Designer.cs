namespace Navy.Forms
{
    partial class RuncodeCheckForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.textBoxRuncode_From = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_RuncodeTo = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 47);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(876, 587);
            this.reportViewer1.TabIndex = 0;
            // 
            // textBoxRuncode_From
            // 
            this.textBoxRuncode_From.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRuncode_From.Location = new System.Drawing.Point(95, 9);
            this.textBoxRuncode_From.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRuncode_From.Name = "textBoxRuncode_From";
            this.textBoxRuncode_From.Size = new System.Drawing.Size(112, 30);
            this.textBoxRuncode_From.TabIndex = 1;
            this.textBoxRuncode_From.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Runcode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            // 
            // textBox_RuncodeTo
            // 
            this.textBox_RuncodeTo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_RuncodeTo.Location = new System.Drawing.Point(236, 9);
            this.textBox_RuncodeTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_RuncodeTo.Name = "textBox_RuncodeTo";
            this.textBox_RuncodeTo.Size = new System.Drawing.Size(112, 30);
            this.textBox_RuncodeTo.TabIndex = 4;
            this.textBox_RuncodeTo.Text = "4000";
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(367, 8);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(105, 30);
            this.btn_submit.TabIndex = 5;
            this.btn_submit.Text = "ค้นหา";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // RuncodeCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 647);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.textBox_RuncodeTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRuncode_From);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RuncodeCheckForm";
            this.Text = "RuncodeCheckForm";
            this.Load += new System.EventHandler(this.RuncodeCheckForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox textBoxRuncode_From;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_RuncodeTo;
        private System.Windows.Forms.Button btn_submit;
    }
}