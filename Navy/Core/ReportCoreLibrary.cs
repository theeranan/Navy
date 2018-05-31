using Microsoft.Reporting.WinForms;
using Navy.Data.DataTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace Navy.Core
{
    class ReportCoreLibrary
    {
        public DataCoreLibrary dcore;
        private RTCDetails rtcDetails;
        public ReportCoreLibrary()
        {
            dcore = new DataCoreLibrary();
        }
        
        public static void DisplayReport(ReportViewer reportViewer, object dataSource, string rdlcResource, List<ReportParameter> reportParam)
        {
            try
            {
                //Reset ReportViewer
                reportViewer.Reset();

                //Setup Report Value
                reportViewer.LocalReport.ReportEmbeddedResource = rdlcResource;
                reportViewer.LocalReport.SetParameters(reportParam);
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSource));

                //Refresh Report
                Refresh(reportViewer);
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message);
            }
        }

        public static void DisplayReport(ReportViewer reportViewer, object dataSource, string rdlcResource)
        {
            try
            {
                //Reset ReportViewer
                reportViewer.Reset();
                reportViewer.LocalReport.DataSources.Clear();
                //Setup Report Value
                reportViewer.LocalReport.EnableExternalImages = true;
                reportViewer.LocalReport.ReportEmbeddedResource = rdlcResource;
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSource));

                //Refresh Report
                Refresh(reportViewer);
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message);
            }
        }

        public static void DisplayReport(ReportViewer reportViewer, object dataSource)
        {
            DisplayReport(reportViewer, dataSource, reportViewer.LocalReport.ReportEmbeddedResource);
        }

        public static void Refresh(ReportViewer reportViewer)
        {
            //Refresh Report
            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }

        #region ร้องขอ
        public void ShowReportRequestPerson(QueryString.Search.RequestPersonFilter reportType)
        {
            ParamSearchPerson param = new ParamSearchPerson();
            param.yearin = dcore.GetMaxYearin();
            ShowReportRequestPerson(param, reportType);
        }

        public void ShowReportRequestPerson(ParamSearchPerson param, QueryString.Search.RequestPersonFilter reportType)
        {
            try
            {
                var dataSource = dcore.GetSearchRequest(param, reportType);
                Reports.ReportDisplay f = new Reports.ReportDisplay();

                if (!Constants.fullMode)
                {
                    //f.ReportViewer.ShowExportButton = false;
                }

                string headerText = "";
                if (reportType == QueryString.Search.RequestPersonFilter.RTC)
                {
                    headerText = "รายชื่อเสนอความต้องการทหารกองประจำการลงสังกัด ศฝท.";
                }
                else
                {
                    headerText = "รายชื่อเสนอความต้องการทหารกองประจำการไปสังกัดหน่วยต่างๆ";
                }

                List<ReportParameter> reportParam = new List<ReportParameter>();
                reportParam.Add(new ReportParameter("reportHeaderText", headerText));
                reportParam.Add(new ReportParameter("yearin", param.yearin));

                f.ReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                f.DisplayReport(dataSource, "Navy.Reports.ReportRequestPerson.rdlc", reportParam);
                f.Show();
            }
            catch
            {
                throw;
            }
        }

        public void ShowReportRequestPerson(object dataSource, QueryString.Search.RequestPersonFilter reportType)
        {
            try
            {
                Reports.ReportDisplay f = new Reports.ReportDisplay();

                if (!Constants.fullMode)
                {
                    //f.ReportViewer.ShowExportButton = false;
                }

                string headerText = "";
                if (reportType == QueryString.Search.RequestPersonFilter.RTC)
                {
                    headerText = "รายชื่อเสนอความต้องการทหารกองประจำการลงสังกัด ศฝท.";
                }
                else
                {
                    headerText = "รายชื่อเสนอความต้องการทหารกองประจำการไปสังกัดหน่วยต่างๆ";
                }

                List<ReportParameter> reportParam =  new List<ReportParameter>() ;
                reportParam.Add(new ReportParameter("reportHeaderText", headerText));
                reportParam.Add(new ReportParameter("yearin", dcore.GetMaxYearin()));


                f.ReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                f.DisplayReport(dataSource, "Navy.Reports.ReportRequestPerson.rdlc", reportParam);
                f.Show();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region แบ่งทหาร
        public void ShowReportDevideUnitPersonList(string yearin)
        {
            try
            {

                Reports.ReportDisplay f = new Reports.ReportDisplay();
                var dataSource = dcore.ReportLabelUnitListPerson(yearin);
                List<ReportParameter> reportParam = new List<ReportParameter>();
                reportParam.Add(new ReportParameter("yearin", dcore.GetMaxYearin()));

                f.DisplayReport(dataSource, "Navy.Reports.ReportDevideUnit.rdlc");
                f.Show();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region สมุดประวัติ
        public void ShowReportPrintHistoryBook(System.Data.DataTable dataSource,string yearin)
        {
            try
            {
                Reports.ReportDisplay f = new Reports.ReportDisplay();

                if (dataSource.Rows.Count > 0)
                {
                    System.Data.DataColumn dc = new System.Data.DataColumn("imagepath", typeof(string));
                    dataSource.Columns.Add(dc);

                    string imageserver = dcore.getConnection().DataSource;
                    yearin = yearin.Replace("/", ".");

                    foreach (System.Data.DataRow dr in dataSource.Rows)
                    {
                        string imagepath = @"\\"+ imageserver + @"\navyimages\" + yearin + @"\" + dr["NAVYID"].ToString() + @".jpg";
                        dr["imagepath"] = imagepath;
                    }

                    f.ReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    f.DisplayReport(dataSource, "Navy.Reports.ReportHistoryBook.rdlc");
                    f.ReportViewer.LocalReport.EnableExternalImages = true;
                    Refresh(f.ReportViewer);
                    f.Show();
                }
                else
                {

                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region คัดประวัติ
        public void ShowReportViewProfile(string navyid)
        {
            try
            {
                Reports.ReportDisplay f = new Reports.ReportDisplay();
                rtcDetails = Function.GetRTCRespository().GetSelectedDetail(navyid);
                DataTable dataSource = dcore.GetViewdata(navyid);
                //  List<ReportParameter> reportParam = new List<ReportParameter>();
                //  reportParam.Add(new ReportParameter("pathimg", ConfigurationManager.AppSettings["PhotoPath"].ToString() + "/" + rtcDetails.yearin + "/" + rtcDetails.navyid + ".jpg"));
                dataSource.Rows[0]["address"] = rtcDetails.address_all;
             

                dataSource.Rows[0]["birthdate"] = rtcDetails.birthdate;
                dataSource.Rows[0]["regdate"] = rtcDetails.regdate;
                dataSource.Rows[0]["repdate"] = rtcDetails.repdate;
                dataSource.Rows[0]["MOVEDATE"] = rtcDetails.MOVEDATE;
                dataSource.Rows[0]["IS_REQUEST"] = rtcDetails.IS_REQUEST;
                
                f.DisplayReport(dataSource, "Navy.Reports.ReportViewProfile.rdlc");
                f.Show();
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
