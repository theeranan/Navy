using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Core;

namespace Navy.Forms
{
    public partial class PersonRequestEditNUMForm : Form
    {
        public bool submitValue = false;
        public string NUM
        {
            set { }
            get { return this.textBox1.Text; }
        }

        public PersonRequestEditNUMForm()
        {
            InitializeComponent();
        }

        public PersonRequestEditNUMForm(string num)
        {
            InitializeComponent();
            this.textBox1.Text = num;
            SetControlSelectAll();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                submitValue = true;
                this.Close();
            }
        }

        private void PersonRequestEditNUMForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        #region SelectAll Action

        private void SetTextboxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((TextBox)sender).SelectAll(); });
        }

        private void SetMaskedTextboxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((MaskedTextBox)sender).SelectAll(); });
        }

        private void SetComboBoxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((ComboBox)sender).SelectAll(); });
        }

        private void SetControlSelectAll()
        {
            foreach (Control c in this.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.Enter += new System.EventHandler(this.SetComboBoxSelectAll);
                }

                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.Enter += new System.EventHandler(this.SetTextboxSelectAll);
                }

                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.Enter += new System.EventHandler(this.SetMaskedTextboxSelectAll);
                }
            }
        }
        #endregion
    }
}
