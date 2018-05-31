using Navy.Core;
using Navy.Data;
using Navy.Data.DataTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Navy.Reports
{
    public partial class ReportBC : Form
    {
       
        ReportCoreLibrary rcore;
        QueryString.Search query = new QueryString.Search();
        public ReportBC()
        {
        
            rcore = new ReportCoreLibrary();
            InitializeComponent();
            DataControls.LoadComboBoxData(cmbprovince, DataDefinition.GetArmtownTab(), "ARMNAME", "ARMID");
        }
        private void ShowData()
        {
          //  DataTable dt = new DataTable();
         //   dt = rcore.dcore.getDataTablePrototype(query.reportListPerson(txtYearin.Text, DataControls.GetSelectedValueComboBoxToString(cmbprovince)));            
        //    gridSearch.DataSource = dt;
        }

        private void btnreportin_Click(object sender, EventArgs e)
        {
            ShowData();
            rcore.ShowReportListPersonin(mtxtYearin.Text, DataControls.GetSelectedValueComboBoxToString(cmbprovince), numBatt.Text.Trim(), numcompany.Text.Trim(), numP.Text.Trim(), numPseq.Text.Trim(), mid8.Text, chkoldyearin.Checked);
        }

        private void btnreportout_Click(object sender, EventArgs e)
        {
            ShowData();

            rcore.ShowReportListPersonALL(mtxtYearin.Text, DataControls.GetSelectedValueComboBoxToString(cmbprovince), numBatt.Text.Trim(), numcompany.Text.Trim(), numP.Text.Trim(), numPseq.Text.Trim(),mid8.Text,chkoldyearin.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();

            rcore.ShowReportListPersonOut(mtxtYearin.Text, DataControls.GetSelectedValueComboBoxToString(cmbprovince), numBatt.Text.Trim(), numcompany.Text.Trim(), numP.Text.Trim(), numPseq.Text.Trim(), mid8.Text, chkoldyearin.Checked);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void chkoldyearin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
