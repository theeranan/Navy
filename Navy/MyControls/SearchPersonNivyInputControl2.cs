using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Data.DataTemplate;

namespace Navy.MyControls
{
    public partial class SearchPersonNivyInputControl2 : UserControl
    {
        public event EventHandler SearchButtonClick;

        public SearchPersonNivyInputControl2()
        {
            InitializeComponent();
            AddEnterKeyDown();
            SetControlSelectAll();
        }

        public InputSearchPersonNivy GetInput()
        {
            return new InputSearchPersonNivy(textBoxID13.Text.Trim(), textBoxName.Text.Trim(), textBoxSname.Text.Trim(), textBoxYearBD.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.SearchButtonClick != null)
                this.SearchButtonClick(this, e);
        }

        public Button GetButtonSearch()
        {
            return this.btnSearch;
        }

        public void SetInput(InputSearchPersonNivy input)
        {
            textBoxID13.Text = input.id13;
            textBoxName.Text = input.name;
            textBoxSname.Text = input.sname;
            textBoxYearBD.Text = input.yearBD;
        }

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

        private void EventEnterKeyForNextControl(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void AddEnterKeyDown()
        {
            textBoxID13.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxName.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxSname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxYearBD.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
        }

        public void SetFocusID13()
        {
            textBoxID13.Focus();
        }
    }
}
