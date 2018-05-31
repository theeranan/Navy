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
    public partial class MemberCodeHistoryView : UserControl
    {
        private string navyid;

        public MemberCodeHistoryView()
        {
            InitializeComponent();
        }

        public MemberCodeHistoryView(string navyid)
        {
            InitializeComponent();

            this.navyid = navyid;

            RefreshGridView();
        }

        public void RefreshGridView()
        {
            gvResult.DataSource = Function.GetRTCRespository().ListMemberCodeHistory(navyid);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvResult.SelectedRows)
            {
                if(Function.GetRTCRespository().DeleteHistory(row.Cells["id"].Value.ToString()))
                    MessageBox.Show("ลบประวัติเรียบร้อย");
                else
                    MessageBox.Show("ไม่สามารถลบได้");
            }
            RefreshGridView();
        }


    }
}
