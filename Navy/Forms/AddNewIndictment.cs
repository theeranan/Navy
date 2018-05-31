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
    public partial class AddNewIndictment : Form
    {
        //RTCDetails _rtcDetails;
        string navyid = "";
        string IndictmentTxt = "";
        string datecapture = "";
        string FlagFunction = "";
        DataCoreLibrary dcore;
        public AddNewIndictment()
        {
            InitializeComponent();
        }

        //Add New Data Indictment
        public AddNewIndictment(string navyid, RTCDetails rtcDetails)
        {
            InitializeComponent();
            txtBox_Indictment.Focus();
            AddEnterKeyDown();
            this.navyid = navyid;
            dcore = new DataCoreLibrary();
            //_rtcDetails = rtcDetails;
            SetDetailsText(rtcDetails);
            SetRTBStyle(txtDetails);
            FlagFunction = "save";


        }
        //Edit Data Indictment
        public AddNewIndictment(string navyid, RTCDetails rtcDetails,string indictmentTxt,string datecapture)
        {
            InitializeComponent();
            txtBox_Indictment.Focus();
            AddEnterKeyDown();
            dcore = new DataCoreLibrary();
            this.navyid = navyid;
            this.IndictmentTxt = indictmentTxt;
            this.datecapture = datecapture;
            //_rtcDetails = rtcDetails;
            SetDetailsText(rtcDetails);
            SetRTBStyle(txtDetails);
            FlagFunction = "edit";
            txtBox_capture.Text = convertUNDate(datecapture);
            AddEnterKeyDown();
        }

        private void SetDetailsText(RTCDetails rtcDetails)
        {
            txtDetails.Text = txtDetails.Text.Replace("@firstname", rtcDetails.name);
            txtDetails.Text = txtDetails.Text.Replace("@sname", rtcDetails.sname);
            txtDetails.Text = txtDetails.Text.Replace("@oldyearin", rtcDetails.oldyearin);
            txtDetails.Text = txtDetails.Text.Replace("@yearin", rtcDetails.yearin);
            txtDetails.Text = txtDetails.Text.Replace("@sign", rtcDetails.sign);
            txtDetails.Text = txtDetails.Text.Replace("@id8", rtcDetails.id8);
            txtDetails.Text = txtDetails.Text.Replace("@id10", rtcDetails.id);
            txtDetails.Text = txtDetails.Text.Replace("@id13", rtcDetails.id13);
            txtDetails.Text = txtDetails.Text.Replace("@birthdate", rtcDetails.birthdate);
            txtBox_Indictment.Text = IndictmentTxt;

        }

        private void SetRTBStyle(RichTextBox rtb)
        {
            string[] str = rtb.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            rtb.Rtf = "";
            for (int i = 0; i < str.Length; i++)
            {
                rtb.DeselectAll();
                if (str[i][0].ToString() == "#")
                {
                    rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Regular);
                    rtb.SelectionColor = Color.DarkBlue;
                    str[i] = str[i].ToString().Remove(0, 1);
                }
                else
                {
                    rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Regular);
                    rtb.SelectionColor = Color.Black;
                }

                rtb.AppendText(str[i]);
            }
        }
        private void Btn_saveIndictment_Click(object sender, EventArgs e)
        {
            if (FlagFunction == "save")
            {
                if (MessageBox.Show("ต้องการเพิ่มข้อมูลนี้ ใช่หรือไม่", "เพิ่มข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqlInsert = "";
                    try
                    {
                        sqlInsert += "INSERT INTO indictmenttab (NavyID,Cause,Date_captured)\n";
                        sqlInsert += "VALUES ('" + navyid + "', '" + txtBox_Indictment.Text+ "', '" + ConvertDate(txtBox_capture.Text.Trim()) + "')\n";
                    }
                    catch (Exception ex) { MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง"); }
                    string result1 = "";
                    DBConnection.runCmdTransaction(sqlInsert, dcore.getConnection(), out result1);
                    if (result1 != "OK")
                    {
                        MessageBox.Show("มีปัญหาในการเพิ่มข้อมูล กรุณาติดต่อ ผู้ดูแลระบบโดยด่วน!! " + result1);
                        return;
                    }

                    MessageBox.Show("เพิ่มข้อมูลเรียบร้อย");
                }
            }
            else if (FlagFunction == "edit")
            {
                if (MessageBox.Show("ต้องการแก้ไขข้อมูลนี้ ใช่หรือไม่", "แก้ไขข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    string sqlUpdate = "";
                    try
                    {
                        sqlUpdate += "update indictmenttab SET Cause = '" + txtBox_Indictment.Text.Trim() + "',  Date_captured = '" + ConvertDate(txtBox_capture.Text.Trim()) + "'\n";
                        sqlUpdate += "WHERE Cause = '" + IndictmentTxt + "' AND NavyID = '" + navyid + "'\n";
                    }
                    catch (Exception ex) { MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง"); }
                   
                    string result1 = "";
                    DBConnection.runCmdTransaction(sqlUpdate, dcore.getConnection(), out result1);
                    if (result1 != "OK")
                    {
                        MessageBox.Show("มีปัญหาในการแก้ไขข้อมูล กรุณาติดต่อ ผู้ดูแลระบบโดยด่วน!! " + result1);
                        return;
                    }

                    MessageBox.Show("อัพเดตข้อมูลเรียบร้อย");
                }
            }
            this.Close();
        }

        private void AddEnterKeyDown()
        {
            txtBox_Indictment.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            txtBox_capture.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
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

        private string ConvertDate(string str) {
            string dateConverted = "";
            string[] strsplit = str.Split('/');
            int UNYear = Int32.Parse(strsplit[2]) - 543;
            string ThDate = strsplit[0]+"/"+ strsplit[1] + "/" + UNYear.ToString();
            DateTime date = DateTime.Parse(ThDate);
            dateConverted = String.Format("{0:yyyy-MM-dd}", date);
            return dateConverted;
        }

        private string convertUNDate(string strDate)
        {
            int Thyear;
            string dateconverted = "";
            string[] datesplit = strDate.Split('/');
            if (Int32.Parse(datesplit[2]) < 2500)
            {
                Thyear = Int32.Parse(datesplit[2]) + 543;
            }
            dateconverted = datesplit[0] + "/" + convertMonth2Number(datesplit[1]) + "/" + Int32.Parse(datesplit[2]).ToString();

            return dateconverted;
        }
        private string convertMonth2Number(string month)
        {
            string THmonth = "";
            switch (month)
            {
                case "ม.ค.":
                    THmonth = "01";
                    break;
                case "ก.พ.":
                    THmonth = "02";
                    break;
                case "มี.ค.":
                    THmonth = "03";
                    break;
                case "เม.ย.":
                    THmonth = "04";
                    break;
                case "พ.ค.":
                    THmonth = "05";
                    break;
                case "มิ.ย.":
                    THmonth = "06";
                    break;
                case "ก.ค.":
                    THmonth = "07";
                    break;
                case "ส.ค.":
                    THmonth = "08";
                    break;
                case "ก.ย.":
                    THmonth = "09";
                    break;
                case "ต.ค.":
                    THmonth = "10";
                    break;
                case "พ.ย.":
                    THmonth = "11";
                    break;
                case "ธ.ค.":
                    THmonth = "12";
                    break;
            }
            return THmonth;
        }
    }
}
