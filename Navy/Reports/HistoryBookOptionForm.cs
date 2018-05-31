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

namespace Navy.Reports
{
    public partial class HistoryBookOptionForm : Form
    {
        ReportCoreLibrary rcore;

        public HistoryBookOptionForm()
        {
            InitializeComponent();
            rcore = new ReportCoreLibrary();
        }

        private void GetParam()
        {

        }

        private void btnPrintFrontCover_Click(object sender, EventArgs e)
        {

            DataTable dt = rcore.dcore.getDataTablePrototype(rcore.dcore.search.reportHistoryBook(mTextBoxYearin.Text.Trim(), tbBatt.Text.Trim(), tbCompany.Text.Trim(), tbPlatoon.Text.Trim()));
            if(dt.Rows.Count>0)
            {
                rcore.ShowReportPrintHistoryBook(dt,mTextBoxYearin.Text);
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
            }
        }

        private void btnPrintInside_Click(object sender, EventArgs e)
        {

        }
    }
}
