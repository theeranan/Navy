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
    public partial class MoveToAddressOld : Form
    {
        public string navyid = string.Empty;
        public string report_number = string.Empty;
        DataControls.TownnameTab townnameManage_old;
        DataCoreLibrary dcore;
        public MoveToAddressOld(string id,string selectmove,string number)
        {
            navyid = id;
            report_number = number;
            townnameManage_old = new DataControls.TownnameTab();
            dcore = new DataCoreLibrary();  
            InitializeComponent();
            MessageBox.Show(selectmove + id);
            if (selectmove.Equals("Old"))
            {

                label4.Text = "ภูมิลำเนาเดิม";
                MessageBox.Show(id);
                GetData(id, selectmove);
              //  f.Text = "ย้ายกลับภูมิลำเนาเดิม";
            }
            else {

                label4.Text = "ที่อยู่ใหม่";
                townnameManage_old.LoadProvinceToComboBox(cmbprovince_old, "");
                GetData(id, selectmove);
               // f.Text = "ย้ายไปที่อยู่ใหม่";
            }
        }
        protected void GetData(string navyid,string selectmove) { 
        
            DataRow dr =null;
               
                if (!string.IsNullOrEmpty(navyid))
                {
                   
                    dr = dcore.GetSearchPeople(navyid);
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
                    lblname.Text = dr["name"].ToString();
                    lblsname.Text = dr["sname"].ToString();

                    label9.Text = dr["id13"].ToString();

                    if (selectmove.Equals("Old"))
                    {
                        if (string.IsNullOrEmpty(dr["report_number"].ToString()))
                        {
                            txtaddress_old.Text = dr["address_in"].ToString();
                            txtaddress_mu_old.Text = dr["address_mu_in"].ToString();
                            txtaddress_soid_old.Text = dr["address_soid_in"].ToString();
                            txtaddress_road_old.Text = dr["address_road_in"].ToString();

                            string tcode = dr["towncode_in"].ToString();
                            try
                            {
                                townnameManage_old.LoadProvinceToComboBox(cmbprovince_old, tcode);
                                cmbprovince_old.SelectedValue = tcode.Substring(0, 2) + "0000";
                                townnameManage_old.LoadCityToComboBox(cmbdistrict_old, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                                townnameManage_old.LoadTumbonToComboBox(cmbsub_district_old, tcode.Substring(0, 4) + "00", tcode);

                            }
                            catch { }
                        }
                        else
                        {

                            txtaddress_old.Text = dr["address_out"].ToString();
                            txtaddress_mu_old.Text = dr["address_mu_out"].ToString();
                            txtaddress_soid_old.Text = dr["address_soid_out"].ToString();
                            txtaddress_road_old.Text = dr["address_road_out"].ToString();

                            string tcode = dr["towncode_out"].ToString();
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
                    else {
                        if (!string.IsNullOrEmpty(dr["report_number"].ToString()))
                        {
                            txtaddress_old.Text = dr["address_out"].ToString();
                            txtaddress_mu_old.Text = dr["address_mu_out"].ToString();
                            txtaddress_soid_old.Text = dr["address_soid_out"].ToString();
                            txtaddress_road_old.Text = dr["address_road_out"].ToString();

                            string tcode = dr["towncode_out"].ToString();
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
                }
        
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow param = dcore.GetSearchPeople(navyid);
            param["address_out"] = txtaddress_old.Text.Trim();
            param["address_mu_out"] = txtaddress_mu_old.Text.Trim();
            param["address_soid_out"] = txtaddress_soid_old.Text.Trim();
            param["address_road_out"] = txtaddress_road_old.Text.Trim();


            if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old)))
            {

                param["towncode_out"] = DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old);
            }
            else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old)))
            {
                param["towncode_out"] = DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old);

            }
            else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbprovince_old)))
            {

                param["towncode_out"] = DataControls.GetSelectedValueComboBoxToString(cmbprovince_old);
            }
            param["report_number"] = report_number;
            
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
    }
}
