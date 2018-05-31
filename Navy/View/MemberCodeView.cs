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
    public partial class MemberCodeView : UserControl
    {
        public event KeyEventHandler cbA2KeyDown;
        public MemberCodeView()
        {
            InitializeComponent();
            Function.InitCBMemberCodeA1(cbA1, string.Empty);

        }

        private void cbA1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Function.InitCBMemberCodeA2(cbA2, Convert.ToString(cbA1.SelectedValue), string.Empty);
        }

        public string GetMemberCode()
        {
            if (cbA2.SelectedIndex >= 0)
            {
                return Convert.ToString(cbA2.SelectedValue);
            }
            else if (cbA1.SelectedIndex >= 0)
            {
                return Convert.ToString(cbA1.SelectedValue);
            }
            else
                return string.Empty;
        }

        public void SetMemberCode(string membercode)
        {
            string structureid = Function.GetStructureID(membercode);

            if (structureid == "A1")
            {
                cbA1.SelectedValue = membercode;
                cbA2.SelectedIndex = -1;
            }
            else if (structureid == "A2")
            {
                cbA1.SelectedValue = Function.GetMemberCodeParent(membercode);
                cbA2.SelectedValue = membercode;
            }
            else
            {
                cbA1.SelectedIndex = -1;
                cbA2.SelectedIndex = -1;
            }
        }

        private void cbA1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void cbA2_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.cbA2KeyDown != null)
                this.cbA2KeyDown(this, e);
        }


    }
}
