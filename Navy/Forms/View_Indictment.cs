using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Data;
using Navy.Core;
using Navy.Data.DataTemplate;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using Navy.View;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Navy.Forms
{
    public partial class View_Indictment : Form
    {
        List<IndicmentDataSearch> IndictmentData;
        //ReportCoreLibrary rcore;
        DataCoreLibrary dcore;
        private RTCDetail_IndictmentView rtcDetailView;
        //private RTCTransactionView rtcTransactionView;

        private RTCDetails rtcDetails;
        private string navyid;

        public View_Indictment()
        {
            InitializeComponent();

        }

        public View_Indictment(string navyid)
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();
            //dcore.ChangeDB("navdb");
           // rcore = new ReportCoreLibrary();
            this.navyid = navyid;
            GetandSetInitialForm(navyid);
        }

        private void GetandSetInitialForm(string navyid) {
            rtcDetails = Function.GetRTCRespository().GetSelectedDetail(navyid);
            InitialForm();
            DisplayIndictment(navyid);
            GVsSetAutoSizeColumns();
        }

        public void InitialForm()
        {
            txtName.Text = "พลทหาร " + rtcDetails.name + "  " + rtcDetails.sname;
            //linkStatus.Text = "[" + rtcDetails.stitle + "]";

            //Personnal Detail View
            rtcDetailView = new RTCDetail_IndictmentView(rtcDetails);
            rtcDetailView.Dock = DockStyle.Fill;

            //Transaction View
            //rtcTransactionView = new RTCTransactionView(navyid);
            //rtcTransactionView.Dock = DockStyle.Fill;
      
            panelDetail.Controls.Add(rtcDetailView);

        }

        public void DisplayIndictment(string navyid) {
            IndictmentData = dcore.GetIndictmentData(navyid);
            gv_Indictment.DataSource = IndictmentData;
            try
            {
                gv_Indictment.Columns["navyid"].Visible = false;
            }
            catch { }
            //gv_Indictment.Focus();
        }

        public void GVsSetAutoSizeColumns()
        {
            //this.gv_Indictment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_Indictment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gv_Indictment.MultiSelect = false;

            foreach (DataGridViewColumn c in gv_Indictment.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Angsana New", 14);
            }
            gv_Indictment.Columns[1].Width = 653;
            gv_Indictment.Columns[0].Width = gv_Indictment.Width - gv_Indictment.Columns[1].Width;
        }


        private void Remove_Indictment_Click(object sender, EventArgs e)
        {
            if (gv_Indictment.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("ต้องการลบข้อมูลนี้ ใช่หรือไม่", "ลบข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string IndictmentCause = gv_Indictment.SelectedRows[0].Cells["indictment"].Value.ToString();
                    string sqlDelete = "";
                    sqlDelete += "DELETE FROM indictmenttab WHERE Cause = '" + IndictmentCause + "';\n";
                    string result1 = "";
                    DBConnection.runCmdTransaction(sqlDelete, dcore.getConnection(), out result1);
                    if (result1 != "OK")
                    {
                        MessageBox.Show("มีปัญหาในการลบข้อมูล กรุณาติดต่อ ผู้ดูแลระบบโดยด่วน!! " + result1);
                        return;
                    }

                    MessageBox.Show("ลบข้อมูลเรียบร้อย");

                    //Refresh Form
                    GetandSetInitialForm(navyid);
                }
            }
        }

        private void Edit_Indictment_Click(object sender, EventArgs e)
        {
            if (gv_Indictment.SelectedRows.Count > 0)
            {
                    AddNewIndictment f = new AddNewIndictment(navyid, rtcDetails, gv_Indictment.SelectedRows[0].Cells["indictment"].Value.ToString(),gv_Indictment.SelectedRows[0].Cells["datecapture"].Value.ToString());
                    f.Text = "แก้ไขข้อหา";
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog();         
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            GetandSetInitialForm(navyid);
        }

        private void Add_Indictment_Click(object sender, EventArgs e)
        {
            AddNewIndictment f = new AddNewIndictment(navyid, rtcDetails);
            f.Text = "เพิ่มข้อหา";
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

    }
}
