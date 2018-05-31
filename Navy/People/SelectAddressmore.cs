using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Navy.People
{
    public partial class SelectAddressmore : Form
    {
        public string id = string.Empty;
        public string report_number = string.Empty;
        public SelectAddressmore(string navyid,string number)
        {
            InitializeComponent();
            id = navyid;
            report_number = number;
        }

        private void btnaddress_old_Click(object sender, EventArgs e)
        {

            MoveToAddressOld f = new MoveToAddressOld(id, "Old", report_number);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            this.Close();
           
            
        }

        private void btnaddress_new_Click(object sender, EventArgs e)
        {
            MoveToAddressOld f = new MoveToAddressOld(id, "New", report_number);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            this.Close();
           
        }

        private void btnaddressunit_Click(object sender, EventArgs e)
        {
            MoveToAddressUnit f = new MoveToAddressUnit(id, report_number);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            this.Close();
        }
    }
}
