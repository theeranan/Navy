using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Forms;
using Navy.Core;
using Navy.Data;
using Navy.Data.DataTemplate;

namespace Navy
{
    public partial class MainWindowFormLite : Form
    {
        PersonRequestDataSet.PersonRequestDataTable dataSource;
        ReportCoreLibrary rcore;

        public MainWindowFormLite()
        {
            InitializeComponent();
            Constants.fullMode = false;
            DBConnection.GetConStringFormFile();

            if (Constants.currentConString == "")
            {
                Constants.currentConString = System.Configuration.ConfigurationManager.ConnectionStrings["navdb_request"].ConnectionString;
            }

            rcore = new ReportCoreLibrary();
        }

        private void ShowReportRequestPerson(QueryString.Search.RequestPersonFilter reportType)
        {
            try
            {
                rcore.ShowReportRequestPerson(reportType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("พบข้อผิดพลาดในการเรียกดูข้อมูล .. " + ex.Message);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm f = new AboutProgramForm();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void PersonRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchPersonRequestForm f = new SearchPersonRequestForm();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void reportRTCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportRequestPerson(QueryString.Search.RequestPersonFilter.RTC);
        }

        private void ReportOtherUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportRequestPerson(QueryString.Search.RequestPersonFilter.Other);
        }

        private void settingDBToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateFormatSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SelectDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDatabaseForm form = new SelectDatabaseForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            rcore = new ReportCoreLibrary();
        }
    }
}
