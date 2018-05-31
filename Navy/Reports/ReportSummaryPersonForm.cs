using Microsoft.Reporting.WinForms;
using Navy.Core;
using Navy.Data;
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
    public partial class ReportSummaryPersonForm : Form
    {
        //Core.Report reportManage;
        DataCoreLibrary dcore;
        PersonDataSet.SummaryPersonDataTable sumPerson;
        public ReportSummaryPersonForm()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();


            GetReportData();
            mtxtYearin.Focus();
        }

        private void ReportSummaryPersonForm_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void GetReportData()
        {
            string yearin = dcore.GetMaxYearin();
            List<ReportParameter> rp = new List<ReportParameter>();
            rp.Add(new ReportParameter("max_yearin", yearin));

            sumPerson = dcore.ReportSummaryNewPersonByArmtown();

            //Core.Report.DisplayReport(this.reportViewer1, sumPerson);
            //Core.Report.DisplayReport(this.reportViewer1, sumPerson, this.reportViewer1.LocalReport.ReportEmbeddedResource);
            Core.ReportCoreLibrary.DisplayReport(this.reportViewer1, sumPerson, this.reportViewer1.LocalReport.ReportEmbeddedResource, rp);
        }

        private void mtxtYearin_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((MaskedTextBox)sender).SelectAll(); });
            Navy.Core.Function.SetKeyboardLayout(Navy.Core.Function.GetInputLanguageByName("en"));
        }

        private void EventEnterKeyForNextControl(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void AddEnterKeyDown()
        {
            mtxtYearin.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("count_all",typeof(string));
            dt.Columns.Add("count_register", typeof(string));

            dt.Rows.Add("1", "2");
            dt.Rows.Add("3", "4");

            PersonDataSet.SummaryPersonDataTable sumPerson2;
            sumPerson2 = Function.ConvertToUserDefineTable<PersonDataSet.SummaryPersonDataTable>(dt);
            GetReportData();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
