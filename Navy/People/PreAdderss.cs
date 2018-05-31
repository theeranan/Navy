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
using Microsoft.Reporting.WinForms;

namespace Navy.People
{
    public partial class PreAdderss : Form
    {
        DataCoreLibrary dcore;
        DataCoreLibrary dcoreUpdateUsedPerson;
        public string navyid = string.Empty;
        public string StatusName = string.Empty;
        public PreAdderss()
        {
            dcore = new DataCoreLibrary();
            dcoreUpdateUsedPerson = new DataCoreLibrary();
            QueryString.Search query = new QueryString.Search();
            InitializeComponent();
            rdedit.Checked = true;
          
           
        }

        private void PreAdderss_Load(object sender, EventArgs e)
        {
            
        }
        public void GetData() {

            grdData.DataSource = dcore.GetSearchListPreAddressmore(txtname.Text, txtlname.Text, "","","",""," /",false,"");
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Bookman Old Style", 8, FontStyle.Bold);
            grdData.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            grdData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            grdData.Columns[0].HeaderText = "ชื่อ";
            grdData.Columns[1].HeaderText = "สกุล";
            grdData.Columns[2].HeaderText = "NAVYID";
            grdData.Columns[3].HeaderText = "ผลัด";
            grdData.Columns[4].HeaderText = "ทะเบียน";
            grdData.Columns[5].HeaderText = "หน่วย";
            grdData.Columns[6].HeaderText = "สถานะ";
            grdData.Columns[7].HeaderText = "ครั้งที่พิมพ์";
            txtname.SelectAll();
            txtlname.SelectAll();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
            
        }

        private void btnreport_number_Click(object sender, EventArgs e)
        {
            string report_number = dcore.GetReport_number();
            txtreport_number.Text = report_number;
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        private void grdData_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            navyid = grdData.Rows[e.RowIndex].Cells["navyid"].Value.ToString();
            StatusName = grdData.Rows[e.RowIndex].Cells["StatusName"].Value.ToString();
        }

        private void txtreport_number2_TextChanged(object sender, EventArgs e)
        {
            
           
        
        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void rdnew_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnew.Checked)
            {
                txtreport_number.Enabled = false;
                string report_number = dcore.GetReport_number();
                txtreport_number.Text = report_number;
            }
          
        }

        private void rdedit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdedit.Checked) {
                txtreport_number.Enabled = true;
                txtreport_number.Text = string.Empty;
            
            }
        }

        private void txtreport_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdData.Rows[e.RowIndex].Cells["StatusName"].Value.ToString() == "ย้ายเข้า")
            {
                ViewProfile f = new ViewProfile(grdData.Rows[e.RowIndex].Cells["navyid"].Value.ToString());
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                SelectAddressmore f = new SelectAddressmore(navyid, txtreport_number.Text.Trim());
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
                try
                {
                    
                  //  MessageBox.Show("บันทึกข้อมูลสำเร็จ");
                    grdData.DataSource = dcore.GetSearchListPreAddressmore(txtname.Text, txtlname.Text, "", "", "", "", " /", false, "");
                    navyid = string.Empty;
                    StatusName = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());


                }

            }
            //if (Check())
            //{

            //}
            txtname.Focus();
            txtname.SelectAll();
            txtlname.SelectAll();
           // txtname.SelectionLength = txtname.Text.Length;
        }
        protected bool Check() {
            bool ch = true;
            StringBuilder str = new StringBuilder();
            if (rdedit.Checked)
            {
                if (txtreport_number.Text != string.Empty)
                {

                    DataTable dt = dcore.GetSearchListPreAddressmore(string.Empty, string.Empty, txtreport_number.Text.Trim(), "", "", "", " /", false, "");
                    if (dt.Rows.Count == 0 || dt == null)
                    {

                        ch = false;
                        str.AppendLine("กรุณากรอกครั้งที่พิมพ์เอกสารให้ถูกต้อง");
                       
                    }

                

                    if (navyid == string.Empty)
                    {
                        str.AppendLine("กรุณาเลือกข้อมูลก่อนบันทึก");
                       
                        ch = false;
                    }
                }
                else {

                    ch = false;
                    str.AppendLine("กรุณากรอกครั้งที่พิมเอกสารก่อนบันทึก");
                  
                }
            }
            if (rdnew.Checked) {

                if (navyid == string.Empty)
                {                  
                    str.AppendLine("กรุณาเลือกข้อมูลก่อนบันทึก");
                    ch = false;
                }
            
            
            }
            if (StatusName != "ย้ายเข้า") {
                str.AppendLine(StatusName);
                ch = false;
            }
            if (str.Length > 0) {
                MessageBox.Show(str.ToString());
            }
            return ch;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    dcoreUpdateUsedPerson.Clearreport_number(navyid);

                    MessageBox.Show("ลบข้อมูลสำเร็จ");
                    grdData.DataSource = dcore.GetSearchListPreAddressmore(txtname.Text, txtlname.Text, "", "", "", "", " /", false, "");
                    navyid = string.Empty;
                    StatusName = string.Empty;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message.ToString());
                
                
                }

            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            Reports.ReportDisplay f = new Reports.ReportDisplay();
            DataTable dataSource = dcore.GetReportListPeople(txtreport_number2.Text.Trim());
            List<ReportParameter> reportParam = new List<ReportParameter>();
            //  reportParam.Add(new ReportParameter("yearin", dcore.GetMaxYearin()));
            reportViewer1.Reset();

            //Setup Report Value
            reportViewer1.LocalReport.ReportEmbeddedResource = "Navy.Reports.ReportPropleList.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dataSource));
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void txtlname_CursorChanged(object sender, EventArgs e)
        {
           
        }

        private void grdData_CursorChanged(object sender, EventArgs e)
        {

        }

        private void PreAdderss_CursorChanged(object sender, EventArgs e)
        {

        }

        private void PreAdderss_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Tab == e.KeyCode)
            {
               // OnTabIndexChanged(e);
                // SendKeys.Send("{TAB}");
                //  e.Handled = true;//set to false if you need that textbox gets enter key
            }
        }

        private void PreAdderss_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar ==(char)Keys.Tab)
            {
                // OnTabIndexChanged(e);
                // SendKeys.Send("{TAB}");
                //  e.Handled = true;//set to false if you need that textbox gets enter key
            }
        }
        
        

       
    }
}
