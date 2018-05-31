using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Core;
using Navy.Data;
using Navy.Data.DataTemplate;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace Navy.Reports
{
    public partial class ReportDisplay : Form
    {
        public ReportDisplay()
        {
            InitializeComponent();
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }

        private void ReportDisplay_Load(object sender, EventArgs e)
        {
            
        }

        public ReportViewer ReportViewer
        {
            get { return this.reportViewer1; }
        }

        public void DisplayReport(object dataSource, string rdlcResource, List<ReportParameter> reportParam)
        {
            Core.ReportCoreLibrary.DisplayReport(this.reportViewer1, dataSource, rdlcResource, reportParam);
        }

        public void DisplayReport(DataTable dataSource, string rdlcResource)
        {
           
            Core.ReportCoreLibrary.DisplayReport(this.reportViewer1, dataSource, rdlcResource);
        }

        public void DisplayReport(object dataSource)
        {
            Core.ReportCoreLibrary.DisplayReport(this.reportViewer1, dataSource);
        }
    }
}
