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

namespace Navy.Forms
{
    public partial class LostInformation : Form
    {
        private string Yearin;
        private DataCoreLibrary dcore;
        private DataTable dataReport;
        private string reportName = "";

        public LostInformation()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();
            reportViewer1.LocalReport.Refresh();
            mtxtYearin.Focus();
            mtxtYearin.SelectAll();
        }

        private void Btn_CreateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (mtxtYearin.Text != " /")
                {
                    //ดึงข้อมูลเก็บไว้ใน DataTable
                    dataReport = getDataLostInformation(mtxtYearin.Text.Trim());

                    if (dataReport != null)
                    {


                        setReportParameter();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูล");
                    }
                    // setRecordLabel
                    setRecordLabel(dataReport);
                }
                else
                {
                    MessageBox.Show("กรุณากรอกผลัดที่ต้องการออกรายงาน");
                }
            }
            catch(Exception ex) { MessageBox.Show("Error : "+ex.ToString()); }

            if (dataReport.Rows.Count > 0)
            {
                foreach (DataRow row in dataReport.Rows)
                {
                    Console.WriteLine("--- Row ---");
                    foreach (var item in row.ItemArray)
                    {
                        Console.Write("Item: "); // Print label.
                        Console.WriteLine(item);
                    }
                }
            }
            else { MessageBox.Show("ไม่พบข้อมูล"); }
        }

        private DataTable getDataLostInformation(string yearin)
        {
            DataTable dt = new DataTable();
            try
            {
                if (radioBtn_CheckID13.Checked)
                {
                    dt = dcore.GetReportCheclLostInformation_ID13(yearin);
                    reportName = "Navy.Reports.ReportLostInformation_ID13.rdlc";
                }
                else if (radioBtn_Educate.Checked)
                {
                    dt = dcore.GetReportCheclLostInformation_Educate(yearin);
                    reportName = "Navy.Reports.ReportLostInformation_Educate.rdlc";
                }
                else if (radioBtn_AccountNum.Checked)
                {
                    dt = dcore.GetReportCheclLostInformation_AccountNum(yearin);
                    reportName = "Navy.Reports.ReportLostInformation_AccountNum.rdlc";
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกข้อมูลที่จะตรวจสอบ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                dataReport = null;
            }
            return dt;
        }

        private void setRecordLabel(DataTable dataReport)
        {
            if (dataReport != null)
            {
                label_countRecord.Text = dataReport.Rows.Count.ToString() + " Records";
            }
            else
            {
                label_countRecord.Text = "0 Records";
            }
        }

        private void setReportParameter()
        {
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportEmbeddedResource = reportName;
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataReport));
            //Process and render the report
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
