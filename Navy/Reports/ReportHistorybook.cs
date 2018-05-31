using Navy.Core;
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
using CrystalDecisions.CrystalReports.Engine;
namespace Navy.Reports
{
    public partial class ReportHistorybook : Form
    {
        DataCoreLibrary dcore;
        public ReportHistorybook()
        {
            dcore = new DataCoreLibrary();
            InitializeComponent();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            DataTable dt = dcore.GetReportHistrory();
            string path = Application.StartupPath + "\\Reports\\HistoryIN.rpt";
            rpt.Load(path);
            rpt.SetDataSource(dt);
            this.crystalReportViewer1.ReportSource = rpt;
            this.crystalReportViewer1.Refresh();
        }
    }
}
