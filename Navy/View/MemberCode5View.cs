using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Navy.Core;

namespace Navy.View
{
    public partial class MemberCode5View : UserControl
    {
        private string membercode5;
        private string link;

        public event KeyEventHandler txtLinkKeyDown;

        #region Constructors

        public MemberCode5View()
        {
            InitializeComponent();
            membercode5 = string.Empty;
            link = string.Empty;
            InitialForm();
        }

        public MemberCode5View(string membercode5, string link)
        {
            InitializeComponent();
            this.membercode5 = membercode5;
            this.link = link;
            InitialForm();
        }

        #endregion

        #region Events

        private void MemberCode5View_Load(object sender, EventArgs e)
        {
        
        }

        private void cbStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            Function.InitCBMemberCode5(cbMemberCode5, Convert.ToString(cbStructure.SelectedValue), "");
        }

        private void cbMemberCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Methods

        public void InitialForm()
        {
            string structureid = string.Empty;

            if (membercode5.Trim() != string.Empty)
            {
                structureid = Function.GetStructureID(membercode5);
            }
            Function.InitCBStructure(cbStructure, structureid);
            Function.InitCBMemberCode5(cbMemberCode5, structureid, membercode5);
            txtLink.Text = link.ToString();
        
        }

        public string GetMembercode5()
        {
            if (cbMemberCode5.SelectedIndex >= 0)
                return Convert.ToString(cbMemberCode5.SelectedValue);

            return null;
        }

        public string GetLink()
        {
            return txtLink.Text.Trim() == string.Empty ? null : txtLink.Text ;
        }

        public void SetMemberCode5(string membercode5)
        {
            if (membercode5 == null)
            {
                cbStructure.SelectedIndex = -1;
                cbMemberCode5.SelectedIndex = -1;
            }
            else
            {
                //Bug
                cbStructure.SelectedValue = Function.GetStructureID(membercode5);
                cbMemberCode5.SelectedValue = membercode5;
            }
        }

        public void SetLink(string link)
        {
            txtLink.Text = link;
        }

        #endregion 

        private void cbStructure_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cbMemberCode5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtLinkKeyDown != null)
                this.txtLinkKeyDown(this, e);
        }
    }
}
