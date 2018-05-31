namespace Navy.Reports
{
    partial class HistoryBookOptionForm
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
            this.btnPrintFrontCover = new System.Windows.Forms.Button();
            this.btnPrintInside = new System.Windows.Forms.Button();
            this.chkBoxPrintForNavyHR = new System.Windows.Forms.CheckBox();
            this.tbBatt = new System.Windows.Forms.TextBox();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.tbPlatoon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mTextBoxYearin = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnPrintFrontCover
            // 
            this.btnPrintFrontCover.Location = new System.Drawing.Point(292, 75);
            this.btnPrintFrontCover.Name = "btnPrintFrontCover";
            this.btnPrintFrontCover.Size = new System.Drawing.Size(75, 23);
            this.btnPrintFrontCover.TabIndex = 0;
            this.btnPrintFrontCover.Text = "พิมพ์ปกสมุด";
            this.btnPrintFrontCover.UseVisualStyleBackColor = true;
            this.btnPrintFrontCover.Click += new System.EventHandler(this.btnPrintFrontCover_Click);
            // 
            // btnPrintInside
            // 
            this.btnPrintInside.Location = new System.Drawing.Point(292, 104);
            this.btnPrintInside.Name = "btnPrintInside";
            this.btnPrintInside.Size = new System.Drawing.Size(75, 23);
            this.btnPrintInside.TabIndex = 1;
            this.btnPrintInside.Text = "พิมพ์ด้านใน";
            this.btnPrintInside.UseVisualStyleBackColor = true;
            this.btnPrintInside.Click += new System.EventHandler(this.btnPrintInside_Click);
            // 
            // chkBoxPrintForNavyHR
            // 
            this.chkBoxPrintForNavyHR.AutoSize = true;
            this.chkBoxPrintForNavyHR.Location = new System.Drawing.Point(267, 49);
            this.chkBoxPrintForNavyHR.Name = "chkBoxPrintForNavyHR";
            this.chkBoxPrintForNavyHR.Size = new System.Drawing.Size(100, 20);
            this.chkBoxPrintForNavyHR.TabIndex = 2;
            this.chkBoxPrintForNavyHR.Text = "พิมพ์ส่ง กพ.ทร.";
            this.chkBoxPrintForNavyHR.UseVisualStyleBackColor = true;
            // 
            // tbBatt
            // 
            this.tbBatt.Location = new System.Drawing.Point(49, 40);
            this.tbBatt.Name = "tbBatt";
            this.tbBatt.Size = new System.Drawing.Size(100, 22);
            this.tbBatt.TabIndex = 4;
            this.tbBatt.Text = "1";
            // 
            // tbCompany
            // 
            this.tbCompany.Location = new System.Drawing.Point(49, 68);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(100, 22);
            this.tbCompany.TabIndex = 5;
            this.tbCompany.Text = "1";
            // 
            // tbPlatoon
            // 
            this.tbPlatoon.Location = new System.Drawing.Point(49, 96);
            this.tbPlatoon.Name = "tbPlatoon";
            this.tbPlatoon.Size = new System.Drawing.Size(100, 22);
            this.tbPlatoon.TabIndex = 6;
            this.tbPlatoon.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "กองพัน";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "กองร้อย";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "หมวด";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "ผลัด";
            // 
            // mTextBoxYearin
            // 
            this.mTextBoxYearin.Location = new System.Drawing.Point(49, 12);
            this.mTextBoxYearin.Mask = "0/00";
            this.mTextBoxYearin.Name = "mTextBoxYearin";
            this.mTextBoxYearin.Size = new System.Drawing.Size(100, 22);
            this.mTextBoxYearin.TabIndex = 11;
            // 
            // HistoryBookOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.mTextBoxYearin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPlatoon);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.tbBatt);
            this.Controls.Add(this.chkBoxPrintForNavyHR);
            this.Controls.Add(this.btnPrintInside);
            this.Controls.Add(this.btnPrintFrontCover);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HistoryBookOptionForm";
            this.Text = "พิมพ์สมุดประวัติ - ตัวเลือก";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintFrontCover;
        private System.Windows.Forms.Button btnPrintInside;
        private System.Windows.Forms.CheckBox chkBoxPrintForNavyHR;
        private System.Windows.Forms.TextBox tbBatt;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.TextBox tbPlatoon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mTextBoxYearin;
    }
}