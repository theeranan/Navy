namespace Navy
{
    partial class Form1
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeCultureTH = new System.Windows.Forms.Button();
            this.btnChangeCultureUS = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChangeCultureUIUS = new System.Windows.Forms.Button();
            this.btnChangeCultureUITH = new System.Windows.Forms.Button();
            this.labelCulture = new System.Windows.Forms.Label();
            this.labelCultureUI = new System.Windows.Forms.Label();
            this.labelDTpickerValue = new System.Windows.Forms.Label();
            this.datetimepickerformat = new System.Windows.Forms.Label();
            this.btnChangeCultureIV = new System.Windows.Forms.Button();
            this.btnChangeCultureUIIV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbTestPerson = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "d MMMM yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(260, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "system culture :";
            // 
            // btnChangeCultureTH
            // 
            this.btnChangeCultureTH.Location = new System.Drawing.Point(16, 95);
            this.btnChangeCultureTH.Name = "btnChangeCultureTH";
            this.btnChangeCultureTH.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCultureTH.TabIndex = 3;
            this.btnChangeCultureTH.Text = "TH";
            this.btnChangeCultureTH.UseVisualStyleBackColor = true;
            this.btnChangeCultureTH.Click += new System.EventHandler(this.btnChangeCultureTH_Click);
            // 
            // btnChangeCultureUS
            // 
            this.btnChangeCultureUS.Location = new System.Drawing.Point(97, 95);
            this.btnChangeCultureUS.Name = "btnChangeCultureUS";
            this.btnChangeCultureUS.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCultureUS.TabIndex = 4;
            this.btnChangeCultureUS.Text = "US";
            this.btnChangeCultureUS.UseVisualStyleBackColor = true;
            this.btnChangeCultureUS.Click += new System.EventHandler(this.btnChangeCultureUS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ui culture :";
            // 
            // btnChangeCultureUIUS
            // 
            this.btnChangeCultureUIUS.Location = new System.Drawing.Point(97, 167);
            this.btnChangeCultureUIUS.Name = "btnChangeCultureUIUS";
            this.btnChangeCultureUIUS.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCultureUIUS.TabIndex = 7;
            this.btnChangeCultureUIUS.Text = "US";
            this.btnChangeCultureUIUS.UseVisualStyleBackColor = true;
            this.btnChangeCultureUIUS.Click += new System.EventHandler(this.btnChangeCultureUIUS_Click);
            // 
            // btnChangeCultureUITH
            // 
            this.btnChangeCultureUITH.Location = new System.Drawing.Point(16, 167);
            this.btnChangeCultureUITH.Name = "btnChangeCultureUITH";
            this.btnChangeCultureUITH.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCultureUITH.TabIndex = 6;
            this.btnChangeCultureUITH.Text = "TH";
            this.btnChangeCultureUITH.UseVisualStyleBackColor = true;
            this.btnChangeCultureUITH.Click += new System.EventHandler(this.btnChangeCultureUITH_Click);
            // 
            // labelCulture
            // 
            this.labelCulture.AutoSize = true;
            this.labelCulture.Location = new System.Drawing.Point(100, 79);
            this.labelCulture.Name = "labelCulture";
            this.labelCulture.Size = new System.Drawing.Size(62, 13);
            this.labelCulture.TabIndex = 8;
            this.labelCulture.Text = "labelCulture";
            // 
            // labelCultureUI
            // 
            this.labelCultureUI.AutoSize = true;
            this.labelCultureUI.Location = new System.Drawing.Point(75, 151);
            this.labelCultureUI.Name = "labelCultureUI";
            this.labelCultureUI.Size = new System.Drawing.Size(73, 13);
            this.labelCultureUI.TabIndex = 9;
            this.labelCultureUI.Text = "labelCultureUI";
            // 
            // labelDTpickerValue
            // 
            this.labelDTpickerValue.AutoSize = true;
            this.labelDTpickerValue.Location = new System.Drawing.Point(12, 59);
            this.labelDTpickerValue.Name = "labelDTpickerValue";
            this.labelDTpickerValue.Size = new System.Drawing.Size(102, 13);
            this.labelDTpickerValue.TabIndex = 10;
            this.labelDTpickerValue.Text = "datetimepickervalue";
            // 
            // datetimepickerformat
            // 
            this.datetimepickerformat.AutoSize = true;
            this.datetimepickerformat.Location = new System.Drawing.Point(13, 39);
            this.datetimepickerformat.Name = "datetimepickerformat";
            this.datetimepickerformat.Size = new System.Drawing.Size(105, 13);
            this.datetimepickerformat.TabIndex = 11;
            this.datetimepickerformat.Text = "datetimepickerformat";
            // 
            // btnChangeCultureIV
            // 
            this.btnChangeCultureIV.Location = new System.Drawing.Point(178, 95);
            this.btnChangeCultureIV.Name = "btnChangeCultureIV";
            this.btnChangeCultureIV.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCultureIV.TabIndex = 12;
            this.btnChangeCultureIV.Text = "IV";
            this.btnChangeCultureIV.UseVisualStyleBackColor = true;
            this.btnChangeCultureIV.Click += new System.EventHandler(this.btnChangeCultureIV_Click);
            // 
            // btnChangeCultureUIIV
            // 
            this.btnChangeCultureUIIV.Location = new System.Drawing.Point(178, 167);
            this.btnChangeCultureUIIV.Name = "btnChangeCultureUIIV";
            this.btnChangeCultureUIIV.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCultureUIIV.TabIndex = 13;
            this.btnChangeCultureUIIV.Text = "IV";
            this.btnChangeCultureUIIV.UseVisualStyleBackColor = true;
            this.btnChangeCultureUIIV.Click += new System.EventHandler(this.btnChangeCultureUIIV_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "us format";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "UTC";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbTestPerson
            // 
            this.lbTestPerson.AutoSize = true;
            this.lbTestPerson.Location = new System.Drawing.Point(16, 236);
            this.lbTestPerson.Name = "lbTestPerson";
            this.lbTestPerson.Size = new System.Drawing.Size(35, 13);
            this.lbTestPerson.TabIndex = 16;
            this.lbTestPerson.Text = "label3";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(441, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbTestPerson);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChangeCultureUIIV);
            this.Controls.Add(this.btnChangeCultureIV);
            this.Controls.Add(this.datetimepickerformat);
            this.Controls.Add(this.labelDTpickerValue);
            this.Controls.Add(this.labelCultureUI);
            this.Controls.Add(this.labelCulture);
            this.Controls.Add(this.btnChangeCultureUIUS);
            this.Controls.Add(this.btnChangeCultureUITH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangeCultureUS);
            this.Controls.Add(this.btnChangeCultureTH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeCultureTH;
        private System.Windows.Forms.Button btnChangeCultureUS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeCultureUIUS;
        private System.Windows.Forms.Button btnChangeCultureUITH;
        private System.Windows.Forms.Label labelCulture;
        private System.Windows.Forms.Label labelCultureUI;
        private System.Windows.Forms.Label labelDTpickerValue;
        private System.Windows.Forms.Label datetimepickerformat;
        private System.Windows.Forms.Button btnChangeCultureIV;
        private System.Windows.Forms.Button btnChangeCultureUIIV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbTestPerson;
        private System.Windows.Forms.Button button3;
    }
}

