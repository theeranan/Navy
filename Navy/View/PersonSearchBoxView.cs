using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Navy.Core;

namespace Navy.View
{
    public partial class PersonSearchBoxView : UserControl
    {
        public event EventHandler SearchButtonClick;

        #region Constructors

        public PersonSearchBoxView()
        {
            InitializeComponent();

            InitialForm();
        }

        #endregion


        #region Events


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.SearchButtonClick != null)
                this.SearchButtonClick(this, e);
        }

        private void txtYearin_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { SetMaskedTextBoxSelectAll((MaskedTextBox)sender); });
        }

        private void txtID8_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { SetMaskedTextBoxSelectAll((MaskedTextBox)sender); });
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void txtID8_Leave(object sender, EventArgs e)
        {
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("en"));
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.SelectAll();
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("en"));
        }

        private void txtSName_Enter(object sender, EventArgs e)
        {
            txtSName.SelectAll();
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void txtSName_Leave(object sender, EventArgs e)
        {
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("en"));
        }

        private void SetMaskedTextBoxSelectAll(MaskedTextBox txtbox)
        {
            txtbox.SelectAll();
        }
        

        #region Press enter to select next control
        private void txtYearin_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtID8_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtSName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        #endregion
        
        #endregion


        #region Methods

        private void InitialForm()
        {

        }
        
        public Parameters.PersonSearch GetSearchParameter()
        {
            Parameters.PersonSearch personSearch = new Parameters.PersonSearch();

            personSearch.yearin = txtYearin.Text;
            personSearch.id8 = txtID8.Text;
            personSearch.name = txtName.Text;
            personSearch.sname = txtSName.Text;

            return personSearch;
        }

        #endregion


    }
}
