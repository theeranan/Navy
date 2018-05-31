namespace Navy.MyControls
{
    partial class YearInControl
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
            this.mtxtYearin = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // mtxtYearin
            // 
            this.mtxtYearin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtxtYearin.Location = new System.Drawing.Point(0, 0);
            this.mtxtYearin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtxtYearin.Mask = "0/00";
            this.mtxtYearin.Name = "mtxtYearin";
            this.mtxtYearin.Size = new System.Drawing.Size(34, 22);
            this.mtxtYearin.TabIndex = 0;
            this.mtxtYearin.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtYearin_MaskInputRejected);
            this.mtxtYearin.Enter += new System.EventHandler(this.mtxtYearin_Enter);
            // 
            // YearInControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mtxtYearin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "YearInControl";
            this.Size = new System.Drawing.Size(34, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtxtYearin;
    }
}
