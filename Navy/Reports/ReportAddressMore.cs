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
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Threading;

namespace Navy.Reports
{
    public partial class ReportAddressMore : Form
    {
        public DataCoreLibrary dcore;
        public ReportAddressMore()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();


            DataControls.LoadComboBoxData(cmbselectaddress, DataDefinition.GetUnitTab(), "UNITNAME", "REFNUM");
        }

        private void cmbselectaddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            int recodeperpage = 20;
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            //ถ้าไม่มี Folder ไว้เก็บข้อมูลที่ desktop จะสร้าง Folder นั้นขึ้นมาก่อน
            string FilePathDesktopForOutputData = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.');
            if (!Directory.Exists(FilePathDesktopForOutputData))
            {
                Directory.CreateDirectory(FilePathDesktopForOutputData);
            }

            try
            {
                Reports.ReportDisplay f = new Reports.ReportDisplay();
                DataTable dataSource = dcore.GetReportListAddressmore(mtxtYearin.Text.Trim(), DataControls.GetSelectedValueComboBoxToString(cmbselectaddress));
                List<ReportParameter> reportParam = new List<ReportParameter>();

                //reportParam.Add(new ReportParameter("unit_name", "test"));
                reportViewer1.Reset();

                if (dataSource.Rows.Count > 0)
                {
                    while ((dataSource.Rows.Count % recodeperpage) > 20 || (dataSource.Rows.Count % recodeperpage) == 0)
                    {
                        recodeperpage--;
                    }
                    string str = string.Empty;
                    //Setup Report Value
                    string[] str1 = dpdateR.Text.Split(' ');

                    // ============== Export Image Checked =============
                    if (chkimage.Checked)
                    {
                        try
                        {
                            //Create Folder for image output
                            string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.') + "//" + DataControls.GetSelectedTextComboBoxToString(cmbselectaddress);
                            if (!Directory.Exists(FilePath))
                            {
                                Directory.CreateDirectory(FilePath);
                            }
                            else
                            {
                                System.IO.Directory.Delete(FilePath, true);
                                System.IO.Directory.CreateDirectory(FilePath);
                            }

                            //Copy Image file in to folder
                            foreach (DataRow dr in dataSource.Rows)
                            {
                                //string path = @"\\192.168.0.1\NavyImages\" + dr["YEARIN"].ToString().Replace('/', '.') + @"\" + dr["NAVYID"].ToString() + ".jpg";
                                //if (File.Exists(path))
                                //{
                                //
                                //    System.IO.File.Copy(@"\\192.168.0.1\NavyImages\" + dr["YEARIN"].ToString().Replace('/', '.') + @"\" + dr["NAVYID"].ToString() + ".jpg"
                                //       , Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"//" + dr["unitname"].ToString() + @"//" + dr["NAME"].ToString() + "  " + dr["SNAME"].ToString() + "  " + dr["NAVYID"].ToString() + ".jpg", true);
                                // }
                                string path = @"\\192.168.0.1\NavyImages\" + dr["YEARIN"].ToString().Replace('/', '.') + @"\" + dr["NAVYID"].ToString() + ".jpg";
                                if (File.Exists(path))
                                {
                                    {

                                        System.IO.File.Copy(@"\\192.168.0.1\NavyImages\" + dr["YEARIN"].ToString().Replace('/', '.') + @"\" + dr["NAVYID"].ToString() + ".jpg"
                                           , Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.') + "//" + dr["unitname"].ToString() + @"//" + dr["NAME"].ToString() + "  " + dr["SNAME"].ToString() + "  " + dr["NAVYID"].ToString() + ".jpg", true);
                                    }
                                }


                            }


                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message.ToString());
                        }

                    }

                    // ============== Export Report PDF Checked =============
                    if (chk.Checked)
                    {
                        // string  str11 =  dpdateR.Text.Replace("มีนาคม","มี.ค.");
                        if (checkBox1.Checked)
                        {
                            reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.Report2.rdlc";
                            reportParam.Add(new ReportParameter("Title", string.Format("บัญชีรายชื่อทหารกองประจำการจัดแบ่งให้หน่วย  {0}", DataControls.GetSelectedTextComboBoxToString(cmbselectaddress))));
                            reportParam.Add(new ReportParameter("date", string.Format("วันที่ส่งมอบ  {0} {1} {2}", str1[0], ConvertM(str1[1]), (Convert.ToInt32(str1[2])) - 2500).ToString()));
                            reportParam.Add(new ReportParameter("TitleNotation", "หมายเหตุ"));
                            reportParam.Add(new ReportParameter("notationaddict", "ผลการคัดกรองสารเสพติด " +
                                                                                    "กลุ่ม 1 = ผู้ไม่เคยใช้สารเสพติด " +
                                                                                    "กลุ่ม 2 = กลุ่มเสี่ยง(เคยทดลอง) " +
                                                                                    "กลุ่ม 3 = กลุ่มผู้เสพ " +
                                                                                    "กลุ่ม 4 = กลุ่มผู้ติด"));
                            reportParam.Add(new ReportParameter("text", txttext.Text.Trim()));
                            reportParam.Add(new ReportParameter("rank", txtrank.Text.Trim()));
                            reportParam.Add(new ReportParameter("name", txtname.Text.Trim()));
                            reportParam.Add(new ReportParameter("position", txtposition.Text.Trim()));
                            reportParam.Add(new ReportParameter("day", dpday.Text.Trim()));
                            reportParam.Add(new ReportParameter("recodeperpage", recodeperpage.ToString()));
                            this.reportViewer1.LocalReport.SetParameters(reportParam);
                        }
                        else
                        {
                            reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.Report2None.rdlc";
                            reportParam.Add(new ReportParameter("Title", string.Format("บัญชีรายชื่อทหารกองประจำการจัดแบ่งให้หน่วย  {0}", DataControls.GetSelectedTextComboBoxToString(cmbselectaddress))));
                            reportParam.Add(new ReportParameter("date", string.Format("วันที่ส่งมอบ  {0} {1} {2}", str1[0], ConvertM(str1[1]), (Convert.ToInt32(str1[2])) - 2500).ToString()));
                            reportParam.Add(new ReportParameter("TitleNotation", "หมายเหตุ"));
                            reportParam.Add(new ReportParameter("notationaddict", "ผลการคัดกรองสารเสพติด " +
                                                                                    "กลุ่ม 1 = ผู้ไม่เคยใช้สารเสพติด " +
                                                                                    "กลุ่ม 2 = กลุ่มเสี่ยง(เคยทดลอง) " +
                                                                                    "กลุ่ม 3 = กลุ่มผู้เสพ " +
                                                                                    "กลุ่ม 4 = กลุ่มผู้ติด"));
                            reportParam.Add(new ReportParameter("recodeperpage", recodeperpage.ToString()));
                            this.reportViewer1.LocalReport.SetParameters(reportParam);
                        }


                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSource));


                        byte[] bytes = reportViewer1.LocalReport.Render(
                            "PDF", null, out mimeType, out encoding, out filenameExtension,
                            out streamids, out warnings);

                        try
                        {
                            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.') + "//" + DataControls.GetSelectedTextComboBoxToString(cmbselectaddress) + ".pdf", FileMode.Create))
                            {
                                fs.Write(bytes, 0, bytes.Length);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }

                    }


                    // reportViewer1.LocalReport.Refresh();
                    // reportViewer1.RefreshReport();
                    // ============== Export Excel Checked =============
                    if (chkexport.Checked)
                    {
                        Reports.ReportDisplay f1 = new Reports.ReportDisplay();
                        DataTable dataSource1 = dcore.GetReportExportToExcel(mtxtYearin.Text.Trim(), DataControls.GetSelectedValueComboBoxToString(cmbselectaddress));
                        List<ReportParameter> reportParam1 = new List<ReportParameter>();

                        //reportParam.Add(new ReportParameter("unit_name", "test"));
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.ExportToExcel.rdlc";
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSource1));


                        Warning[] warningsE;
                        string[] streamidsE;
                        string mimeTypeE;
                        string encodingE;
                        string extensionE;


                        byte[] bytesE = reportViewer1.LocalReport.Render(
                           "Excel", null, out mimeTypeE, out encodingE,
                            out extensionE,
                           out streamidsE, out warningsE);



                        try
                        {
                            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.') + "//" + DataControls.GetSelectedTextComboBoxToString(cmbselectaddress) + ".xls", FileMode.Create))
                            {
                                fs.Write(bytesE, 0, bytesE.Length);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        //Reports.ReportDisplay f1 = new Reports.ReportDisplay();
                        //DataTable dataSource1 = dcore.GetReportExportToExcel(mtxtYearin.Text.Trim(), DataControls.GetSelectedValueComboBoxToString(cmbselectaddress));
                        //List<ReportParameter> reportParam1 = new List<ReportParameter>();

                        ////reportParam.Add(new ReportParameter("unit_name", "test"));
                        //reportViewer1.Reset();
                        //reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.ExportToExcel.rdlc";
                        //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSource1));


                        //Warning[] warningsE;
                        //string[] streamidsE;
                        //string mimeTypeE;
                        //string encodingE;
                        //string extensionE;


                        //byte[] bytesE = reportViewer1.LocalReport.Render(
                        //   "Excel", null, out mimeTypeE, out encodingE,
                        //    out extensionE,
                        //   out streamidsE, out warningsE);



                        //try
                        //{
                        //    using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + DataControls.GetSelectedTextComboBoxToString(cmbselectaddress) + ".xls", FileMode.Create))
                        //    {
                        //        fs.Write(bytesE, 0, bytesE.Length);
                        //    }
                        //     MessageBox.Show("สร้าง Excel สำเร็จ");
                        // }
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message.ToString());
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
            MessageBox.Show("ออกรายงานสำเร็จ");
        }

        public string ConvertM(string m)
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


        //======================= ออกรายงานทั้งหมด (ทุกหน่วย, ทุกรูป, ทุก Excel)
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 22;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            //ถ้าไม่มี Folder ไว้เก็บข้อมูลที่ desktop จะสร้าง Folder นั้นขึ้นมาก่อน
            string FilePathDesktopForOutputData = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.');
            if (!Directory.Exists(FilePathDesktopForOutputData))
            {
                Directory.CreateDirectory(FilePathDesktopForOutputData);
            }
            try
            {
                for (int i = 0; i < 35; i++)
                {

                    int recodeperpage = 20;
                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string filenameExtension;
                    Reports.ReportDisplay f = new Reports.ReportDisplay();
                    DataTable dataSource = dcore.GetReportListAddressmore(mtxtYearin.Text.Trim(), i.ToString());
                    List<ReportParameter> reportParam = new List<ReportParameter>();

                    //reportParam.Add(new ReportParameter("unit_name", "test"));
                    reportViewer1.Reset();

                    if (dataSource.Rows.Count > 0)
                    {
                        DataControls.LoadComboBoxData(cmbselectaddress, DataDefinition.GetUnitTab(), "UNITNAME", "REFNUM", i.ToString());
                        string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.') + "//" + DataControls.GetSelectedTextComboBoxToString(cmbselectaddress);
                        if (!Directory.Exists(FilePath))
                        {
                            Directory.CreateDirectory(FilePath);
                        }
                        else
                        {
                            System.IO.Directory.Delete(FilePath, true);
                            System.IO.Directory.CreateDirectory(FilePath);
                        }
                        if (checkBox1.Checked)
                        {
                            while ((dataSource.Rows.Count % recodeperpage) > 20 || (dataSource.Rows.Count % recodeperpage) == 0)
                            {
                                recodeperpage--;
                            }
                        }
                        string str = string.Empty;
                        //Setup Report Value
                        string[] str1 = dpdateR.Text.Split(' ');

                        // ============== Export Image Checked =============
                        if (chkimage.Checked)
                        {
                            try
                            {
                                foreach (DataRow dr in dataSource.Rows)
                                {
                                    string path = @"\\192.168.0.1\NavyImages\" + dr["YEARIN"].ToString().Replace('/', '.') + @"\" + dr["NAVYID"].ToString() + ".jpg";
                                    if (File.Exists(path))
                                    {

                                        System.IO.File.Copy(@"\\192.168.0.1\NavyImages\" + dr["YEARIN"].ToString().Replace('/', '.') + @"\" + dr["NAVYID"].ToString() + ".jpg"
                                           , Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.') + "//" + dr["unitname"].ToString() + @"//" + dr["NAME"].ToString() + "  " + dr["SNAME"].ToString() + "  " + dr["NAVYID"].ToString() + ".jpg", true);
                                    }
                                }


                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message.ToString());
                            }

                        }


                        // ============== Export Report PDF Checked =============
                        if (chk.Checked)
                        {
                            // string  str11 =  dpdateR.Text.Replace("มีนาคม","มี.ค.");
                            // ----------------- ลายเซ็น Check ---------------
                            if (checkBox1.Checked)
                            {
                                reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.Report2.rdlc";
                                reportParam.Add(new ReportParameter("Title", string.Format("บัญชีรายชื่อทหารกองประจำการจัดแบ่งให้หน่วย  {0}", DataControls.GetSelectedTextComboBoxToString(cmbselectaddress))));
                                reportParam.Add(new ReportParameter("date", string.Format("วันที่ส่งมอบ  {0} {1} {2}", str1[0], ConvertM(str1[1]), (Convert.ToInt32(str1[2])) - 2500).ToString()));
                                reportParam.Add(new ReportParameter("TitleNotation", "หมายเหตุ"));
                                reportParam.Add(new ReportParameter("notationaddict", "ผลการคัดกรองสารเสพติด " +
                                                                                        "กลุ่ม 1 = ผู้ไม่เคยใช้สารเสพติด " +
                                                                                        "กลุ่ม 2 = กลุ่มเสี่ยง(เคยทดลอง) " +
                                                                                        "กลุ่ม 3 = กลุ่มผู้เสพ " +
                                                                                        "กลุ่ม 4 = กลุ่มผู้ติด"));
                                reportParam.Add(new ReportParameter("text", txttext.Text.Trim()));
                                reportParam.Add(new ReportParameter("rank", txtrank.Text.Trim()));
                                reportParam.Add(new ReportParameter("name", txtname.Text.Trim()));
                                reportParam.Add(new ReportParameter("position", txtposition.Text.Trim()));
                                reportParam.Add(new ReportParameter("day", dpday.Text.Trim()));
                                reportParam.Add(new ReportParameter("recodeperpage", recodeperpage.ToString()));
                                this.reportViewer1.LocalReport.SetParameters(reportParam);
                            }
                            else
                            {
                                reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.Report2None.rdlc";
                                reportParam.Add(new ReportParameter("Title", string.Format("บัญชีรายชื่อทหารกองประจำการจัดแบ่งให้หน่วย  {0}", DataControls.GetSelectedTextComboBoxToString(cmbselectaddress))));
                                reportParam.Add(new ReportParameter("date", string.Format("วันที่ส่งมอบ  {0} {1} {2}", str1[0], ConvertM(str1[1]), (Convert.ToInt32(str1[2])) - 2500).ToString()));
                                reportParam.Add(new ReportParameter("TitleNotation", "หมายเหตุ"));
                                reportParam.Add(new ReportParameter("notationaddict", "ผลการคัดกรองสารเสพติด " +
                                                                                        "กลุ่ม 1 = ผู้ไม่เคยใช้สารเสพติด " +
                                                                                        "กลุ่ม 2 = กลุ่มเสี่ยง(เคยทดลอง) " +
                                                                                        "กลุ่ม 3 = กลุ่มผู้เสพ " +
                                                                                        "กลุ่ม 4 = กลุ่มผู้ติด"));
                                reportParam.Add(new ReportParameter("recodeperpage", recodeperpage.ToString()));
                                this.reportViewer1.LocalReport.SetParameters(reportParam);
                            }


                            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSource));


                            byte[] bytes = reportViewer1.LocalReport.Render(
                                "PDF", null, out mimeType, out encoding, out filenameExtension,
                                out streamids, out warnings);

                            try
                            {
                                using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.') + "//" + DataControls.GetSelectedTextComboBoxToString(cmbselectaddress) + ".pdf", FileMode.Create))
                                {
                                    fs.Write(bytes, 0, bytes.Length);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }

                        }


                        // reportViewer1.LocalReport.Refresh();
                        // reportViewer1.RefreshReport();
                        if (chkexport.Checked)
                        {
                            Reports.ReportDisplay f1 = new Reports.ReportDisplay();
                            DataTable dataSource1 = dcore.GetReportExportToExcel(mtxtYearin.Text.Trim(), DataControls.GetSelectedValueComboBoxToString(cmbselectaddress));
                            List<ReportParameter> reportParam1 = new List<ReportParameter>();

                            //reportParam.Add(new ReportParameter("unit_name", "test"));
                            reportViewer1.Reset();
                            reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.ExportToExcel.rdlc";
                            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSource1));


                            Warning[] warningsE;
                            string[] streamidsE;
                            string mimeTypeE;
                            string encodingE;
                            string extensionE;


                            byte[] bytesE = reportViewer1.LocalReport.Render(
                               "Excel", null, out mimeTypeE, out encodingE,
                                out extensionE,
                               out streamidsE, out warningsE);



                            try
                            {
                                using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + mtxtYearin.Text.Trim().Replace('/', '.') + "//" + DataControls.GetSelectedTextComboBoxToString(cmbselectaddress) + ".xls", FileMode.Create))
                                {
                                    fs.Write(bytesE, 0, bytesE.Length);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    progressBar1.PerformStep();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
            MessageBox.Show("ออกรายงานสำเร็จ");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            // progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            //   this.Text = e.ProgressPercentage.ToString();
        }
    }
}
