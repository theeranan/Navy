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

namespace Navy.People
{
    public partial class PeopleForm : Form
    {
        #region properties
        DataCoreLibrary dcore;
        public string navyid = string.Empty;
        public string cardid = string.Empty;
        public string modes = "new";
        DataControls.TownnameTab townnameManage;
        DataControls.TownnameTab townnameManage_old;
        #endregion  
        public PeopleForm(string mode,string id13)
        {          
            modes = mode;
            townnameManage_old = new DataControls.TownnameTab();
            townnameManage = new DataControls.TownnameTab();
            dcore = new DataCoreLibrary();        
            InitializeComponent();
            //dp_indate.Format = DateTimePickerFormat.Custom;
            //dp_indate.CustomFormat = " ";
            //dp_outdate.Format = DateTimePickerFormat.Custom;
            //dp_outdate.CustomFormat = " ";
            cardid =  id13;
            townnameManage.LoadProvinceToComboBox(cmbprovince, "");
            townnameManage.LoadProvinceToComboBox(cmbprovince_old, "");
            //townnameManage.LoadCityToComboBox(cmbdistrict, "");
            //townnameManage.LoadTumbonToComboBox(cmbsub_district, "");
            if (modes == "new")
            {
                chkout.Enabled = false;
            }
            else {
                chkout.Enabled = true;          
            }
          //  DataControls.LoadComboBoxData(cmbselectaddress, DataDefinition.GetUnitmoreTab(), "unit_name", "unit_id");
           // DataControls.LoadComboBoxData(cmbselect_out, DataDefinition.Getstatusmore(), "status_name", "status_id");
            GetData(id13);
         //   UploadExhibitor();
        }
        #region Showdata
        public void GetData(string id13)
        {
            DataRow dr = null;

            if (modes == "new")
            {
                if (!string.IsNullOrEmpty(id13))
                {
                    dr = dcore.GetSearchPerson(id13);

                }
                if (dr != null)
                {
                    txtname.Text = dr["name"].ToString();
                    txtlname.Text = dr["sname"].ToString();

                    
                    txtid13.Text = dr["id13"].ToString();
                    if (!string.IsNullOrEmpty(dr["yearin"].ToString()))
                    {
                        lblyearintext.Text = dr["yearin"].ToString();
                    }
                    else
                    {
                        lblyearintext.Text = "-";
                    }
                    if (!string.IsNullOrEmpty(dr["unit3"].ToString()))
                    {
                        lblunittext.Text = dr["unit3"].ToString();
                    }
                    else
                    {
                        lblunittext.Text = "-";
                    }
                    if (!string.IsNullOrEmpty(dr["oldyearin"].ToString()))
                    {
                        lbloldyearintext.Text = dr["oldyearin"].ToString();
                    }
                    else
                    {
                        lbloldyearintext.Text = "-";
                    }
                    txtaddress_old.Text = dr["ADDRESS"].ToString();
                    txtaddress_mu_old.Text = dr["ADDRESS_MU"].ToString();
                    txtaddress_soid_old.Text = dr["ADDRESS_SOIL"].ToString();
                    txtaddress_road_old.Text = dr["ADDRESS_ROAD"].ToString();

                    string tcode = dr["TOWNCODE"].ToString();
                    try
                    {
                        townnameManage_old.LoadProvinceToComboBox(cmbprovince_old, tcode);
                        cmbprovince_old.SelectedValue = tcode.Substring(0, 2) + "0000";
                        townnameManage_old.LoadCityToComboBox(cmbdistrict_old, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                        townnameManage_old.LoadTumbonToComboBox(cmbsub_district_old, tcode.Substring(0, 4) + "00", tcode);

                    }
                    catch { }


                }
            }
            else
            {
                if (!string.IsNullOrEmpty(id13))
                {
                    dr = dcore.GetSearchPeople(id13, "", "");
                }
                if (dr != null)
                {
                    if (!string.IsNullOrEmpty(dr["yearin"].ToString()))
                    {
                        lblyearintext.Text = dr["yearin"].ToString();
                    }
                    else
                    {
                        lblyearintext.Text = "-";
                    }
                    if (!string.IsNullOrEmpty(dr["unit3"].ToString()))
                    {
                        lblunittext.Text = dr["unit3"].ToString();
                    }
                    else
                    {
                        lblunittext.Text = "-";
                    }
                    if (!string.IsNullOrEmpty(dr["oldyearin"].ToString()))
                    {
                        lbloldyearintext.Text = dr["oldyearin"].ToString();
                    }
                    else
                    {
                        lbloldyearintext.Text = "-";
                    }
                    txtname.Text = dr["name"].ToString();
                    txtlname.Text = dr["sname"].ToString();
                    txtpeoole_name.Text = dr["people_name"].ToString();
                    txtpeople_lname.Text = dr["people_lname"].ToString();
                    txtid13.Text = dr["id13"].ToString();
                    txtaddress_old.Text = dr["address_in"].ToString();
                    txtaddress_mu_old.Text = dr["address_mu_in"].ToString();
                    txtaddress_soid_old.Text = dr["address_soid_in"].ToString();
                    txtaddress_road_old.Text = dr["address_road_in"].ToString();
                    if (dr["people_name"].ToString() != string.Empty || dr["people_lname"].ToString() != string.Empty)
                    {
                        cmbchengename.Checked = true;
                        txtpeoole_name.Enabled = true;
                        txtpeople_lname.Enabled = true;

                    }
                    else {

                        cmbchengename.Checked = false;
                        txtpeoole_name.Enabled = false;
                        txtpeople_lname.Enabled = false;
                    }
                    string tcode = dr["towncode_in"].ToString();
                    try
                    {
                        townnameManage_old.LoadProvinceToComboBox(cmbprovince_old, tcode);
                        cmbprovince_old.SelectedValue = tcode.Substring(0, 2) + "0000";
                        townnameManage_old.LoadCityToComboBox(cmbdistrict_old, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                        townnameManage_old.LoadTumbonToComboBox(cmbsub_district_old, tcode.Substring(0, 4) + "00", tcode);

                    }
                    catch { }
                    if (!string.IsNullOrEmpty(dr["in_date"].ToString()))
                    {
                        dp_indate.Value = Convert.ToDateTime(dr["in_date"]);
                    }
                    txtrank.Text = dr["rank"].ToString();
                    txtbooknumber.Text = dr["book_number"].ToString();
                    if (dr["status"].ToString() == "1")
                    {
                        chkout.Checked = false;
                        chkout.Enabled = true;
                        lblstatus.Text = "ย้ายเข้า";
                    }
                    if (dr["status"].ToString() == "2" || dr["status"].ToString() == "3" || dr["status"].ToString() == "4" || dr["status"].ToString() == "5")
                    {
                        DataControls.LoadComboBoxData(cmbselect_out, DataDefinition.Getstatusmore(), "status_name", "status_id", dr["status"].ToString());

                        chkout.Checked = true;
                        chkout.Enabled = true;
                        lblstatus.Text = DataControls.GetSelectedTextComboBoxToString(cmbselect_out);
                        lblstatus.ForeColor = Color.Red;
                        panel_out.Visible = true;
                        if (dr["out_date"].ToString() != "1/1/0544 0:00:00" && !string.IsNullOrEmpty(dr["out_date"].ToString()))
                        {

                            dp_outdate.Value = Convert.ToDateTime(dr["out_date"]);
                        }
                        //  
                        txtaddress.Text = dr["address_out"].ToString();
                        txtaddress_mu.Text = dr["address_mu_out"].ToString();
                        txtaddress_soid.Text = dr["address_soid_out"].ToString();
                        txtaddress_road.Text = dr["address_road_out"].ToString();
                        DataControls.LoadComboBoxData(cmbselectaddress, DataDefinition.GetUnitmoreTab(), "unit_name", "unit_id", dr["type_out"].ToString());

                        tcode = dr["towncode_out"].ToString();
                        try
                        {
                            townnameManage.LoadProvinceToComboBox(cmbprovince, tcode);
                            cmbprovince.SelectedValue = tcode.Substring(0, 2) + "0000";
                            townnameManage.LoadCityToComboBox(cmbdistrict, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                            townnameManage.LoadTumbonToComboBox(cmbsub_district, tcode.Substring(0, 4) + "00", tcode);



                        }
                        catch { }
                    }


                }
            }






        }
        #endregion              
        #region button
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (!Ischeck())
            {
                #region ADD/EDIT
                if (modes == "new")
                {
                    DataRow dr = dcore.GetSearchPeople("", txtrank.Text.Trim(), txtbooknumber.Text.Trim());
                    if (dr != null)
                    {
                        if (dr["rank"].ToString() == txtrank.Text.Trim() && dr["book_number"].ToString() == txtbooknumber.Text.Trim())
                        {
                            MessageBox.Show("ลำดับเล่มที่" + txtbooknumber.Text.Trim() + " ลำดับที่" + txtrank.Text.Trim() + "มีอยู่แล้วในระบบ");

                        }


                    }
                    else
                    {
                        DataRow param = dcore.GetListPeople("", "", "").NewRow();
                        param["id13"] = txtid13.Text.Trim();
                        param["navyid"] = navyid;
                        param["people_name"] = txtpeoole_name.Text.Trim();
                        param["people_lname"] = txtpeoole_name.Text.Trim();
                        param["address_in"] = txtaddress_old.Text.Trim();
                        param["address_in"] = txtaddress_old.Text.Trim();

                        param["address_mu_in"] = txtaddress_mu_old.Text.Trim();
                        param["address_soid_in"] = txtaddress_soid_old.Text.Trim();
                        param["address_road_in"] = txtaddress_road_old.Text.Trim();
                        if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old)))
                        {

                            param["towncode_in"] = DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old);
                        }
                        else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old)))
                        {
                            param["towncode_in"] = DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old);

                        }
                        else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbprovince_old)))
                        {

                            param["towncode_in"] = DataControls.GetSelectedValueComboBoxToString(cmbprovince_old);
                        }

                        param["book_number"] = txtbooknumber.Text.Trim();
                        param["rank"] = txtrank.Text.Trim();
                        param["status"] = "1";
                        param["type_out"] = "26";
                        if (this.dp_indate.CustomFormat != " " && dp_indate.Value.Date!=DateTime.Now)
                        {
                            param["in_date"] = dp_indate.Value.Date;
                        }
                        if (dcore.InsertPeople(param))
                        {
                            MessageBox.Show("บันทึกสำเร็จ");
                            ClearControl();
                        }
                        else
                        {
                            MessageBox.Show("บันทึกผิดพลาด");
                        }
                    }
                }
                else
                {

                    DataRow param = dcore.GetSearchPeople(cardid, "", "");
                    if (param != null)
                    {
                        param["id13"] = txtid13.Text.Trim();
                        param["navyid"] = param["navyid"].ToString();
                        param["people_name"] = txtpeoole_name.Text.Trim();
                        param["people_lname"] = txtpeople_lname.Text.Trim();
                        param["address_in"] = txtaddress_old.Text.Trim();
                        param["address_mu_in"] = txtaddress_mu_old.Text.Trim();
                        param["address_soid_in"] = txtaddress_soid_old.Text.Trim();
                        param["address_road_in"] = txtaddress_road_old.Text.Trim();
                        if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old)))
                        {

                            param["towncode_in"] = DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old);
                        }
                        else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old)))
                        {
                            param["towncode_in"] = DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old);

                        }
                        else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbprovince_old)))
                        {

                            param["towncode_in"] = DataControls.GetSelectedValueComboBoxToString(cmbprovince_old);
                        }

                        param["book_number"] = txtbooknumber.Text.Trim();
                        param["rank"] = txtrank.Text.Trim();
                        param["type_out"] = "26";
                        param["status"] = "1";
                        if (chkout.Checked)
                        {
                            param["address_out"] = txtaddress.Text.Trim();
                            param["address_mu_out"] = txtaddress_mu.Text.Trim();
                            param["address_soid_out"] = txtaddress_soid.Text.Trim();
                            param["address_road_out"] = txtaddress_road.Text.Trim();


                            if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbsub_district)))
                            {

                                param["towncode_out"] = DataControls.GetSelectedValueComboBoxToString(cmbsub_district);
                            }
                            else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbdistrict)))
                            {
                                param["towncode_out"] = DataControls.GetSelectedValueComboBoxToString(cmbdistrict);

                            }
                            else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbprovince)))
                            {

                                param["towncode_out"] = DataControls.GetSelectedValueComboBoxToString(cmbprovince);
                            }

                            param["status"] = DataControls.GetSelectedValueComboBoxToString(cmbselect_out);
                            if (this.dp_outdate.CustomFormat != " " && dp_indate.Value.Date != DateTime.Now)
                            {
                                param["out_date"] = dp_outdate.Value.Date;
                            }
                            param["type_out"] = DataControls.GetSelectedValueComboBoxToString(cmbselectaddress);
                        }
                        if (dcore.UpdatePeople(param))
                        {
                            MessageBox.Show("บันทึกสำเร็จ");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("บันทึกผิดพลาด");
                        }
                    }
                }
                #endregion
               
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
           // UploadExhibitorfrom_report();
           // UploadExhibitormove();
            UploadExhibitor();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            navy_search f = new navy_search(txtid13.Text, txtname.Text, txtlname.Text, "", "new");
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            if (!string.IsNullOrEmpty(f.id13))
            {
                DataRow dr = dcore.GetSearchPeople(f.id13, "", "");
                if (dr != null)
                {
                    modes = "edit";
                    cardid = f.id13;
                }
                GetData(f.id13);
                navyid = f.navyid;
            }
        }
        #endregion
        #region Control 
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (chkout.Checked)
            {
                panel_out.Visible = true;
            }
            else {
                panel_out.Visible = false;            
            }
        }
        public void ClearControl(){
            foreach (Control c in panel_in.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.SelectedText = "";
                    cbb.SelectedIndex = -1;
                    cbb.Text = "";
                    //cbb.SelectedValue = null;
                }
                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.ResetText();
                }
                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.ResetText();
                }
            }
            foreach (Control c in panel_out.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.SelectedText = "";
                    cbb.SelectedIndex = -1;
                    cbb.Text = "";
                    //cbb.SelectedValue = null;
                }
                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.ResetText();
                }
                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.ResetText();
                }
            }
            chkout.Checked = false;       
            cardid = string.Empty;
            navyid = string.Empty;
            lblyearintext.Text = string.Empty;
            lblunittext.Text = string.Empty;
            lbloldyearintext.Text = string.Empty;
        }
        protected bool Ischeck() {

            StringBuilder str = new StringBuilder();
            #region Check
            bool check = false;
            if (string.IsNullOrEmpty(txtbooknumber.Text))
            {
                check = true;
                str.AppendLine("-กรุณากรอก เลขที่เล่ม");

            }
            if (txtid13.Text.Length != 13)
            {
                check = true;
                str.AppendLine("-กรุณากรอก เลขบัตรประจำตัวประชาชนให้ถูกต้อง");

            }
            if (string.IsNullOrEmpty(txtrank.Text))
            {

                check = true;
                str.AppendLine("-กรุณากรอก ลำดับที่");

            }
            if (check)
            {

                MessageBox.Show(str.ToString());
            }
            return check;
            #endregion        
        }
        private void cbbArmtown_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdistrict.DataSource = null;
            cmbsub_district.DataSource = null;
            object value = ((ComboBox)sender).SelectedValue;
            if (value != null)
            {
                townnameManage.SelectedProvince = value.ToString();
                townnameManage.LoadCityToComboBox(cmbdistrict, value.ToString());
                cbbCity_SelectedIndexChanged(cmbsub_district, e);
            }
        }
        private void cbbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbsub_district.DataSource = null;
            object value = ((ComboBox)sender).SelectedValue;
            if (value != null)
            {
                townnameManage.SelectedCity = value.ToString();
                townnameManage.LoadTumbonToComboBox(cmbsub_district, value.ToString());
            }
        }
        private void cbbArmtownOld_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdistrict_old.DataSource = null;
            cmbsub_district_old.DataSource = null;
            object value = ((ComboBox)sender).SelectedValue;
            if (value != null)
            {
                townnameManage_old.SelectedProvince = value.ToString();
                townnameManage_old.LoadCityToComboBox(cmbdistrict_old, value.ToString());
                cbbCityOld_SelectedIndexChanged(cmbsub_district_old, e);
            }
        }
        private void cbbCityOld_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbsub_district_old.DataSource = null;
            object value = ((ComboBox)sender).SelectedValue;
            if (value != null)
            {
                townnameManage_old.SelectedCity = value.ToString();
                townnameManage_old.LoadTumbonToComboBox(cmbsub_district_old, value.ToString());
            }
        }
      
        private void cmbselectaddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataRow dr = dcore.GetAddress(DataControls.GetSelectedValueComboBoxToString(cmbselectaddress));
            //if (dr != null)
            //{
            //    txtaddress.Text = dr["ADDRESS"].ToString();
            //    txtaddress_mu.Text = dr["ADDRESS_MU"].ToString();
            //    txtaddress_soid.Text = dr["ADDRESS_SOIL"].ToString();
            //    txtaddress_road.Text = dr["ADDRESS_ROAD"].ToString();
            //    string tcode = dr["TOWNCODE"].ToString();
            //    if (!string.IsNullOrEmpty(tcode))
            //    {
            //        try
            //        {
            //            townnameManage.LoadProvinceToComboBox(cmbprovince, tcode);
            //            cmbprovince.SelectedValue = tcode.Substring(0, 2) + "0000";
            //            townnameManage.LoadCityToComboBox(cmbdistrict, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
            //            townnameManage.LoadTumbonToComboBox(cmbsub_district, tcode.Substring(0, 4) + "00", tcode);
            //        }
            //        catch { }
            //    }
            //}
        }
        private void UploadExhibitor()
        {try
            {
            StringBuilder str2 = new StringBuilder();
            #region Import Excel Connection
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            
            MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\insertpeople.xls';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet2$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "TestTable");
            

            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            DataTable dt = DtSet.Tables[0];
            MyConnection.Close();
            #endregion
            int index = 0;
            #region Import Data To Database
            foreach (DataRow dr in dt.Rows)
            {
              
                string id13 = string.Empty;
                    DataRow drpeople = null;
                    DataRow drdup = null;
                    id13 = dr["id13"].ToString();

                    if (!string.IsNullOrEmpty(id13))
                    {
                        progressBar1.Maximum = dt.Rows.Count;
                        progressBar1.Step = 1;
                        if (!string.IsNullOrEmpty(id13))
                        {
                            drpeople = dcore.GetSearchPerson(id13);
                            drdup = dcore.GetSearchPeople(id13, "", "");
                        }
                        if (drpeople != null && drdup == null)
                        {
                            DataRow param = dcore.GetListPeople("", "", "").NewRow();
                            param["id13"] = id13;
                            param["navyid"] = drpeople["navyid"];
                            param["address_in"] = drpeople["ADDRESS"];
                            param["address_mu_in"] = drpeople["ADDRESS_MU"];
                            param["address_soid_in"] = drpeople["ADDRESS_SOIL"];
                            param["address_road_in"] = drpeople["ADDRESS_ROAD"];
                            param["towncode_in"] = drpeople["TOWNCODE"];
                            param["book_number"] = dr["booknumber"].ToString();
                            param["rank"] = dr["rank"].ToString();
                            param["status"] = "1";
                            param["pseq"] = dr["pseq"].ToString();
                            // param["type_out"] = "26";
                            dcore.InsertPeople(param);
                            progressBar1.PerformStep();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(id13))
                            {
                                str2.AppendLine(dr["id13"].ToString() + ":" + dr["booknumber"].ToString() + ":" + dr["rank"].ToString());
                            }

                        }
                    }
               
            }   
 
            string pathApp = AppDomain.CurrentDomain.BaseDirectory + string.Format("LOG_Import/{0:yyyy}/{0:MM}/", DateTime.Now);
                    string pathFile = pathApp + string.Format("LOG_Import_CREATE{0:yyyy-MM-dd}.txt", DateTime.Now);
                    if (!Directory.Exists(pathApp))
                        Directory.CreateDirectory(pathApp);
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathFile, true))
                    {
                        file.Write(str2.ToString());
                    }
            #endregion  
                    MessageBox.Show("บันทึกสำเร็จ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UploadExhibitorfrom_report()
        {
            StringBuilder str2 = new StringBuilder();
            #region Import Excel Connection
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\2.xls';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "TestTable");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            DataTable dt = DtSet.Tables[0];
            MyConnection.Close();
            #endregion
            #region Import Data To Database
            foreach (DataRow dr in dt.Rows)
            {
                string id13 = string.Empty;
                
                DataRow drdup = null;
                string[] s = dr["id"].ToString().Split("\n".ToCharArray());
                string[] str = s[1].Split("-".ToCharArray());

              
                    for (int i = 0; i < str.Length; i++)
                    {

                        id13 += str[i];

                    }

              
                progressBar1.Maximum = dt.Rows.Count;
                progressBar1.Step = 1;
                if (!string.IsNullOrEmpty(id13))
                {
                   
                    drdup = dcore.GetSearchPeople(id13, "", "");
                }
                if ( drdup != null)
                {

                    drdup["report_number"] = "2";
                    drdup["report_date"] = DateTime.Now;


                    dcore.UpdatePeople(drdup);
                    progressBar1.PerformStep();
                }
             
            }

         
            #endregion
            MessageBox.Show("บันทึกสำเร็จ");
        }
        private void UploadExhibitormove()
        {
            StringBuilder str2 = new StringBuilder();
            int count = 0;
            #region Import Excel Connection
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\move_out.xls';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "TestTable");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            DataTable dt = DtSet.Tables[0];
            MyConnection.Close();
            #endregion
            #region Import Data To Database
            foreach (DataRow dr in dt.Rows)
            {
                string id13 = string.Empty;

                DataRow drdup = null;
                id13 = dr["id13"].ToString();
             

            
                if (!string.IsNullOrEmpty(id13))
                {

                    drdup = dcore.GetSearchPeople(id13, "", "");
                }
                if (drdup != null)
                {

                    drdup["status"] = "2";
                    drdup["report_date"] = DateTime.Now;

                    try
                    {
                        count++;
                        dcore.UpdatePeople(drdup);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    progressBar1.PerformStep();
                }
                else {

                    str2.AppendLine(id13);
                }

            }


            #endregion
            MessageBox.Show("บันทึกสำเร็จ");
        }
        #region FormatDate
        private void dp_indate_ValueChanged(object sender, EventArgs e)
        {
            this.dp_indate.Format = DateTimePickerFormat.Long;
        }
        private void dp_outdate_ValueChanged(object sender, EventArgs e)
        {
            this.dp_outdate.Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region CheckInputNumber
        private void txtid13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar != '.'))//เช็คให้พิมพ์เฉพาะตัวเลข
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }
        private void txtbooknumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar != '.'))//เช็คให้พิมพ์เฉพาะตัวเลข
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }
        private void txtrank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar != '.'))//เช็คให้พิมพ์เฉพาะตัวเลข
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }      
        #endregion

        private void cmbsub_district_old_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                        object value = ((ComboBox)sender).SelectedValue;
            if (value != null)
            {
                townnameManage_old.SelectedCity = value.ToString();
            }
        }
       
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void cmbchengename_Click(object sender, EventArgs e)
        {
            if (cmbchengename.Checked)
            {
                txtpeoole_name.Enabled = true;
                txtpeople_lname.Enabled = true;
            }
            else
            {
                txtpeoole_name.Enabled = false;
                txtpeople_lname.Enabled = false;
            }
        }

        private void btncopy_Click(object sender, EventArgs e)
        {
                        txtaddress.Text = txtaddress_old.Text;
                        txtaddress_mu.Text = txtaddress_mu_old.Text;
                        txtaddress_soid.Text =  txtaddress_soid_old.Text;
                        txtaddress_road.Text = txtaddress_road_old.Text;
                       string  tcode=string.Empty;
                         if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old)))
                        {

                            tcode = DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old);
                        }
                        else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old)))
                        {
                            tcode = DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old);

                        }
                        else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbprovince_old)))
                        {

                            tcode = DataControls.GetSelectedValueComboBoxToString(cmbprovince_old);
                        }

                         try
                         {
                             townnameManage.LoadProvinceToComboBox(cmbprovince, tcode);
                             cmbprovince.SelectedValue = tcode.Substring(0, 2) + "0000";
                             townnameManage.LoadCityToComboBox(cmbdistrict, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                             townnameManage.LoadTumbonToComboBox(cmbsub_district, tcode.Substring(0, 4) + "00", tcode);

                         }
                         catch { }
        }

        private void cmbselect_out_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
