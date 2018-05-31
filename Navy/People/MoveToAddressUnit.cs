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
    public partial class MoveToAddressUnit : Form
    {
        DataCoreLibrary dcore;
        DataControls.TownnameTab townnameManage;
        public string navyid = string.Empty;
        public string report_number = string.Empty;
        public MoveToAddressUnit(string id, string number)
        {
            report_number = number;
            navyid = id;
             dcore = new DataCoreLibrary();
             townnameManage = new DataControls.TownnameTab();
            InitializeComponent();
            GetData(id);
            DataControls.LoadComboBoxData(cmbUnit, DataDefinition.GetUnitmoreTab(), "unit_name", "unit_id");
        }
        protected void GetData(string navyid)
        {

            DataRow dr = null;
           
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

                label10.Text = dr["id13"].ToString();

                if (!string.IsNullOrEmpty(dr["report_number"].ToString()))
                {
                    txtaddress_old.Text = dr["address_out"].ToString();
                    txtaddress_mu_old.Text = dr["address_mu_out"].ToString();
                    txtaddress_soid_old.Text = dr["address_soid_out"].ToString();
                    txtaddress_road_old.Text = dr["address_road_out"].ToString();

                    string tcode = dr["towncode_out"].ToString();
                    try
                    {
                        townnameManage.LoadProvinceToComboBox(cmbprovince_old, tcode);
                        cmbprovince_old.SelectedValue = tcode.Substring(0, 2) + "0000";
                        townnameManage.LoadCityToComboBox(cmbdistrict_old, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                        townnameManage.LoadTumbonToComboBox(cmbsub_district_old, tcode.Substring(0, 4) + "00", tcode);

                    }
                    catch { }
                }
            }

        }
        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubUnit.DataSource = null;
            object value = ((ComboBox)sender).SelectedValue;
            if (value != null)
            {
              
                DataControls.LoadComboBoxData(cmbSubUnit, DataDefinition.GetSubUnitmoreTab(DataControls.GetSelectedValueComboBoxToString(cmbUnit)), "unit_name", "subunit_id");
                DataRow dr = dcore.GetAddress(DataControls.GetSelectedValueComboBoxToString(cmbUnit));
                if (dr != null)
                {
                    txtaddress_old.Text = dr["ADDRESS"].ToString();
                    txtaddress_mu_old.Text = dr["ADDRESS_MU"].ToString();
                    txtaddress_soid_old.Text = dr["ADDRESS_SOIL"].ToString();
                    txtaddress_road_old.Text = dr["ADDRESS_ROAD"].ToString();
                    string tcode = dr["TOWNCODE"].ToString();
                    if (!string.IsNullOrEmpty(tcode))
                    {
                        try
                        {
                            townnameManage.LoadProvinceToComboBox(cmbprovince_old, tcode);
                            cmbprovince_old.SelectedValue = tcode.Substring(0, 2) + "0000";
                            townnameManage.LoadCityToComboBox(cmbdistrict_old, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                            townnameManage.LoadTumbonToComboBox(cmbsub_district_old, tcode.Substring(0, 4) + "00", tcode);
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

        private void cmbSubUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow dr = dcore.GetSubAddress(DataControls.GetSelectedValueComboBoxToString(cmbSubUnit));
            if (dr != null)
            {
                txtaddress_old.Text = dr["ADDRESS"].ToString();
                txtaddress_mu_old.Text = dr["ADDRESS_MU"].ToString();
                txtaddress_soid_old.Text = dr["ADDRESS_SOIL"].ToString();
                txtaddress_road_old.Text = dr["ADDRESS_ROAD"].ToString();
                string tcode = dr["TOWNCODE"].ToString();
                if (!string.IsNullOrEmpty(tcode))
                {
                    try
                    {
                        townnameManage.LoadProvinceToComboBox(cmbprovince_old, tcode);
                        cmbprovince_old.SelectedValue = tcode.Substring(0, 2) + "0000";
                        townnameManage.LoadCityToComboBox(cmbdistrict_old, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                        townnameManage.LoadTumbonToComboBox(cmbsub_district_old, tcode.Substring(0, 4) + "00", tcode);
                    }
                    catch { }
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbprovince_old_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbdistrict_old_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbsub_district_old_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtaddress_soid_old_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtaddress_road_old_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtaddress_mu_old_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtaddress_old_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
