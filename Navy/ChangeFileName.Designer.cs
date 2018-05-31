namespace Navy
{
    partial class ChangeFileName
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
            this.numBatt = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numCom = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numP = new System.Windows.Forms.NumericUpDown();
            this.Change = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numBatt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP)).BeginInit();
            this.SuspendLayout();
            // 
            // numBatt
            // 
            this.numBatt.Location = new System.Drawing.Point(89, 52);
            this.numBatt.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numBatt.Name = "numBatt";
            this.numBatt.Size = new System.Drawing.Size(120, 20);
            this.numBatt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "กองพัน";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "กองร้อย";
            // 
            // numCom
            // 
            this.numCom.Location = new System.Drawing.Point(89, 78);
            this.numCom.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numCom.Name = "numCom";
            this.numCom.Size = new System.Drawing.Size(120, 20);
            this.numCom.TabIndex = 2;
            this.numCom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "หมวด";
            // 
            // numP
            // 
            this.numP.Location = new System.Drawing.Point(89, 104);
            this.numP.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numP.Name = "numP";
            this.numP.Size = new System.Drawing.Size(120, 20);
            this.numP.TabIndex = 4;
            this.numP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(89, 160);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(75, 23);
            this.Change.TabIndex = 6;
            this.Change.Text = "เปลี่ยนชื่อรูป";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // ChangeFileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numCom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numBatt);
            this.Name = "ChangeFileName";
            this.Text = "ChangeFileName";
            ((System.ComponentModel.ISupportInitialize)(this.numBatt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numBatt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numP;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}