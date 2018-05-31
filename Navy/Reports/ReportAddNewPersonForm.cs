using Microsoft.Reporting.WinForms;
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
    public partial class ReportAddNewPersonForm : Form
    {
        List<PersonSD18> pSD18 = new List<PersonSD18>();
        DataCoreLibrary dcore;
        QueryString.Search query = new QueryString.Search();
        int count = -1;
        int itemsPerPage = Constants.countItemResult;
        int page = 1;
        int totalPage = -1;

        public ReportAddNewPersonForm()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();
            DataControls.LoadComboBoxData(cbbProvince, DataDefinition.GetArmtownTab().Copy(), "ARMNAME", "ARMID");
        }

        private void ReportAddNewPersonForm_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }

        private void reportViewer_Drillthrough(object sender, Microsoft.Reporting.WinForms.DrillthroughEventArgs e)
        {

        }
        
        private void DisplayReport(DataTable dt)
        {
            try
            {
                //Reset ReportViewer
                reportViewer.Reset();

                //reportRTCRepository = new ReportRTCRepository();
                //reportRTC = new List<ReportRTC>();
                //reportDataSource = new ReportDataSource();
                //reportParameter = new List<ReportParameter>();

                ////Prepare Report DataSource
                //reportDataSource = GetReportDataSource();

                ////Prepare Report Parmeters
                //reportParameter = GetReportParameter();

                ////Prepare Report Name
                //reportName = GetReportName();
                
                //Setup Report Value
                reportViewer.LocalReport.ReportEmbeddedResource = "Navy.Reports.ReportPersonSD18.rdlc";
                //reportViewer.LocalReport.SetParameters(reportParameter);
                //reportViewer.LocalReport.DataSources.Add(reportDataSource);
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                //Refresh Report
                reportViewer.LocalReport.Refresh();
                this.reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Search()
        {
            try
            {
                string armid = DataControls.GetSelectedValueComboBoxToString(cbbProvince);
                DataTable dt = new DataTable();
                pSD18 = new List<PersonSD18>();

                string sql = query.reportPrintNewPerson(armid);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, dcore.getConnection());
                dcore.getConnection().Open();
                using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pSD18.Add(new PersonSD18(reader));
                    }
                }

                dt = Function.ConvertToDataTable<PersonSD18>(pSD18);         
                DisplayReport(dt);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dcore.getConnection().Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
