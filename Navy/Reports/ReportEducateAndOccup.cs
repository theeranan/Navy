using Microsoft.Reporting.WinForms;
using Navy.Core;
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
    public partial class ReportEducateAndOccup : Form
    {
        public string Yearin;
        public DataCoreLibrary dcore;

        public ReportEducateAndOccup()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();
            reportViewer1.LocalReport.Refresh();
        }

        private void Print_Report_Click(object sender, EventArgs e)
        {
            double sumAllPersonEducate = 0;
            double sumAllPersonOccupation = 0;

            DataTable dataSourceEducate = dcore.GetReportEducation(mtxtYearin.Text.Trim());
            DataTable dataSourceOccupation = dcore.GetReportOccupation(mtxtYearin.Text.Trim());
            List<ReportParameter> reportParam = new List<ReportParameter>();

            DataTable DataEducateToReport = new DataTable();
            DataTable DataOccupationToReport = new DataTable();


            // Console.WriteLine("Found " + dataSourceEducate.Rows.Count + "item");

            if (dataSourceEducate.Rows.Count > 0 && dataSourceOccupation.Rows.Count > 0)
            {
                //==============================================================
                //===================== Education ==========================
                //==============================================================
                #region "Education"
                //นับ count ทั้งหมดที่พบ --> เพื่อใช้หา percent ต่อไป
                foreach (DataRow dr in dataSourceEducate.Rows)
                {
                    sumAllPersonEducate += Convert.ToInt32(dr["Educount"]);  //get summary
                }
                if (checkBox1.Checked)
                {
                    DataEducateToReport = Create_DataTableEducation_Signature();
                    //Add data into Dataset
                    foreach (DataRow dr in dataSourceEducate.Rows)
                    {
                        DataEducateToReport.Rows.Add("ผนวก ก",
                                                     "ข้อมูลความรู้ของทหารกองประจำการ รุ่น พ.ศ." + SplitYear_Yearin(mtxtYearin.Text) + " ผลัดที่ " + SplitCount_Yearin(mtxtYearin.Text),
                                                     Convert_EducateType(dr["EduType"].ToString()),
                                                     Convert.ToInt32(dr["Educount"]),
                                                     Convert.ToDouble(String.Format("{0:0.00}", Convert.ToInt32(dr["Educount"]) * 100.00 / sumAllPersonEducate)),
                                                     txttext.Text.Trim(),
                                                     txtrank.Text.Trim(),
                                                     txtname.Text.Trim(),
                                                     txtposition.Text.Trim(),
                                                     Convert_ThNumber(dpday.Text.Trim())
                                                     );
                    }
                }
                else
                {
                    DataEducateToReport = Create_DataTableEducation();
                    //Add data into Dataset
                    foreach (DataRow dr in dataSourceEducate.Rows)
                    {
                        DataEducateToReport.Rows.Add("ผนวก ก",
                                                     "ข้อมูลความรู้ของทหารกองประจำการ รุ่น พ.ศ." + SplitYear_Yearin(mtxtYearin.Text) + " ผลัดที่ " + SplitCount_Yearin(mtxtYearin.Text),
                                                     Convert_EducateType(dr["EduType"].ToString()),
                                                     Convert.ToInt32(dr["Educount"]),
                                                     Convert.ToDouble(String.Format("{0:0.00}", Convert.ToInt32(dr["Educount"]) * 100.00 / sumAllPersonEducate)));
                    }
                }
                #endregion


                //==============================================================
                //===================== Occupation ==========================
                //==============================================================
                #region "Occupation"
                //นับ count ทั้งหมดที่พบ --> เพื่อใช้หา percent ต่อไป
                foreach (DataRow dr2 in dataSourceOccupation.Rows)
                {
                    sumAllPersonOccupation += Convert.ToInt32(dr2["OccCount"]);  //get summary
                }

                if (checkBox1.Checked)
                {
                    DataOccupationToReport = Create_DataTableOccupation_Signature();
                    foreach (DataRow dr2 in dataSourceOccupation.Rows)
                    {
                        DataOccupationToReport.Rows.Add("ผนวก ข",
                                                        "ข้อมูลอาชีพก่อนเข้ารับราชการของทหารกองประจำการ รุ่น พ.ศ." + SplitYear_Yearin(mtxtYearin.Text) + " ผลัดที่ " + SplitCount_Yearin(mtxtYearin.Text),
                                                        Convert_OccuptType(dr2["OccType"].ToString()),
                                                        Convert.ToInt32(dr2["OccCount"]),
                                                        Convert.ToDouble(String.Format("{0:0.00}", Convert.ToDouble(dr2["OccCount"]) * 100.00 / sumAllPersonOccupation)),
                                                        txttext.Text.Trim(),
                                                        txtrank.Text.Trim(),
                                                        txtname.Text.Trim(),
                                                        txtposition.Text.Trim(),
                                                        Convert_ThNumber(dpday.Text.Trim())
                                                        )
                                                        ;
                    }
                }
                else
                {
                    DataOccupationToReport = Create_DataTableOccupation();
                    foreach (DataRow dr2 in dataSourceOccupation.Rows)
                    {
                        DataOccupationToReport.Rows.Add("ผนวก ข",
                                                        "ข้อมูลอาชีพก่อนเข้ารับราชการของทหารกองประจำการ รุ่น พ.ศ." + SplitYear_Yearin(mtxtYearin.Text) + " ผลัดที่ " + SplitCount_Yearin(mtxtYearin.Text),
                                                        Convert_OccuptType(dr2["OccType"].ToString()),
                                                        Convert.ToInt32(dr2["OccCount"]),
                                                        Convert.ToDouble(String.Format("{0:0.00}", Convert.ToInt32(dr2["OccCount"]) * 100.00 / sumAllPersonOccupation))
                                                        );
                    }
                }

                //==================== Make Report ========================
                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.Report_EducateandOccuption.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataEducateToReport));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", DataOccupationToReport));
                //Process and render the report
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
                //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataEducateToReport));

                #endregion

            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
            }
        }

        #region "Support Function"
        private string SplitYear_Yearin(string Yearin)
        {
            string[] year = Yearin.Split('/');

            return "25" + year[1];
        }

        private string SplitCount_Yearin(string Yearin)
        {
            string[] year = Yearin.Split('/');
            return year[0];
        }

        private DataTable Create_DataTableEducation()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AppendixA", typeof(string));
            dt.Columns.Add("TitleA", typeof(string));
            dt.Columns.Add("EducateType", typeof(string));
            dt.Columns.Add("EducateCount", typeof(int));
            dt.Columns.Add("PercentA", typeof(double));

            return dt;
        }
        private DataTable Create_DataTableEducation_Signature()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AppendixA", typeof(string));
            dt.Columns.Add("TitleA", typeof(string));
            dt.Columns.Add("EducateType", typeof(string));
            dt.Columns.Add("EducateCount", typeof(int));
            dt.Columns.Add("PercentA", typeof(double));
            dt.Columns.Add("TextA", typeof(string));
            dt.Columns.Add("RankA", typeof(string));
            dt.Columns.Add("NameA", typeof(string));
            dt.Columns.Add("PositionA", typeof(string));
            dt.Columns.Add("dpDayA", typeof(string));

            return dt;
        }

        private DataTable Create_DataTableOccupation()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AppendixB", typeof(string));
            dt.Columns.Add("TitleB", typeof(string));
            dt.Columns.Add("OccupType", typeof(string));
            dt.Columns.Add("OccupCount", typeof(int));
            dt.Columns.Add("PercentB", typeof(double));

            return dt;
        }

        private DataTable Create_DataTableOccupation_Signature()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AppendixB", typeof(string));
            dt.Columns.Add("TitleB", typeof(string));
            dt.Columns.Add("OccupType", typeof(string));
            dt.Columns.Add("OccupCount", typeof(int));
            dt.Columns.Add("PercentB", typeof(double));
            dt.Columns.Add("TextB", typeof(string));
            dt.Columns.Add("RankB", typeof(string));
            dt.Columns.Add("NameB", typeof(string));
            dt.Columns.Add("PositionB", typeof(string));
            dt.Columns.Add("dpDayB", typeof(string));
            return dt;
        }

        private string Convert_EducateType(string number)
        {
            string EducateType = "";
            switch (number)
            {
                case "1":
                    EducateType = "ความรู้ สูงกว่ามัธยมศึกษาตอนปลาย";
                    break;
                case "2":
                    EducateType = "ความรู้ มัธยมศึกษาตอนปลาย หรือเทียบเท่า";
                    break;
                case "3":
                    EducateType = "ความรู้ มัธยมศึกษาตอนต้น หรือเทียบเท่า";
                    break;
                case "4":
                    EducateType = "ความรู้ ประถมศึกษาปีที่ 4 ถึงปีที่ 6 หรือเทียบเท่า";
                    break;
                case "5":
                    EducateType = "ความรู้ อ่านออกเขียนได้แต่ต่ำกว่าชั้นประถมศึกษาปีที่ 4";
                    break;
                case "6":
                    EducateType = "อ่านออกเขียนได้";
                    break;
                case "7":
                    EducateType = "อ่านเขียนไม่ได้";
                    break;
                case "8":
                    EducateType = "ไม่ระบุ";
                    break;

            }

            return EducateType;
        }

        private string Convert_OccuptType(string number)
        {
            string OccuptType = "";
            switch (number)
            {
                case "1":
                    OccuptType = "ทำนา";
                    break;
                case "2":
                    OccuptType = "รับจ้าง";
                    break;
                case "3":
                    OccuptType = "ค้าขาย";
                    break;
                case "4":
                    OccuptType = "ทำสวน";
                    break;
                case "5":
                    OccuptType = "ทำไร่";
                    break;
                case "6":
                    OccuptType = "ประมง";
                    break;
                case "7":
                    OccuptType = "รับราชการ";
                    break;
                case "8":
                    OccuptType = "ไม่ระบุอาชีพ";
                    break;
            }

            return OccuptType;
        }

        private string ConvertM(string m)
        {
            string str = string.Empty;
            switch (m)
            {
                case "มกราคม":
                    str = "ม.ค.";
                    break;
                case "กุมภาพันธ์":
                    str = "ก.พ.";
                    break;
                case "มีนาคม":
                    str = "มี.ค.";
                    break;
                case "เมษายน":
                    str = "เม.ย.";
                    break;
                case "พฤษภาคม":
                    str = "พ.ค.";
                    break;
                case "มิถุนายน":
                    str = "มิ.ย.";
                    break;
                case "กรกฎาคม":
                    str = "ก.ค.";
                    break;
                case "สิงหาคม":
                    str = "ส.ค.";
                    break;
                case "กันยายน":
                    str = "ก.ย.";
                    break;
                case "ตุลาคม":
                    str = "ต.ค.";
                    break;
                case "พฤศจิกายน":
                    str = "พ.ย.";
                    break;
                case "ธันวาคม":
                    str = "ธ.ค.";
                    break;
            }
            return str;
        }

        private string Convert_ThNumber(string str)
        {
            char[] strSubString;
            strSubString = str.ToCharArray();
            string ReturnStr = string.Empty;
            char Temp;
            foreach (char m in strSubString)
            {
                switch (m)
                {
                    case '0':
                        Temp = '๐';
                        break;
                    case '1':
                        Temp = '๑';
                        break;
                    case '2':
                        Temp = '๒';
                        break;
                    case '3':
                        Temp = '๓';
                        break;
                    case '4':
                        Temp = '๔';
                        break;
                    case '5':
                        Temp = '๕';
                        break;
                    case '6':
                        Temp = '๖';
                        break;
                    case '7':
                        Temp = '๗';
                        break;
                    case '8':
                        Temp = '๘';
                        break;
                    case '9':
                        Temp = '๙';
                        break;
                    default:
                        Temp = m;
                        break;
                }
                ReturnStr += Temp;
            }
            return ReturnStr;
        }

        #endregion

    }
}
