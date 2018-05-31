using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Navy.Core;
using Microsoft.Reporting.WinForms;

namespace Navy.Reports
{
    public partial class ReportSumpeople : Form
    {
        public DataCoreLibrary dcore;
        public ReportSumpeople()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();
            Getreport();
        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();

        }
        protected void Getreport() {
            Reports.ReportDisplay f = new Reports.ReportDisplay();
            DataTable dataSource = dcore.GetReportSumpeople();
            List<ReportParameter> reportParam = new List<ReportParameter>();

            //reportParam.Add(new ReportParameter("unit_name", "test"));
            reportViewer1.Reset();


            //Setup Report Value
            reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.ReportSumpeople.rdlc";
            //reportParam.Add(new ReportParameter("Title", string.Format("{0} {1}", "รายชื่อทหารกองประจำการ ย้ายทะเบียนบ้าน สังกัด ", DataControls.GetSelectedTextComboBoxToString(cmbselectaddress))));
            //this.reportViewer1.LocalReport.SetParameters(reportParam);
            //ReportParameter[] parameters = new ReportParameter[1];
            //   parameters[0] = new ReportParameter("Title", "test");
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSource));
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
