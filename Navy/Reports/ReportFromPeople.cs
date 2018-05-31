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
using Microsoft.Reporting.WinForms;

namespace Navy.Reports
{
    public partial class ReportFromPeople : Form
    {
        public DataCoreLibrary dcore;
        public ReportFromPeople()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();
            DataControls.LoadComboBoxData(cmbselectaddress, DataDefinition.GetUnitmoreTab(), "unit_name", "unit_id");
        }

        private void ReportFromPeople_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          //  Reports.ReportDisplay f = new Reports.ReportDisplay();
          //  DataTable dataSource = dcore.GetReportListPeople(mtxtYearin.Text.Trim(), DataControls.GetSelectedValueComboBoxToString(cmbselectaddress));
          //  List<ReportParameter> reportParam = new List<ReportParameter>();
          ////  reportParam.Add(new ReportParameter("yearin", dcore.GetMaxYearin()));
          //  reportViewer1.Reset();
            
          //  //Setup Report Value
          //  reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.ReportPropleList.rdlc";
          //  reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dataSource));
          //  reportViewer1.LocalReport.Refresh();
          //  reportViewer1.RefreshReport();
        }

        private void cmbselectaddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
