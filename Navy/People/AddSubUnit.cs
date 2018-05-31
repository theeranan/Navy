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
    public partial class AddSubUnit : Form
    {
        DataCoreLibrary dcore;
        DataControls.TownnameTab townnameManage_old;
        public AddSubUnit()
        {
            dcore = new DataCoreLibrary();
            townnameManage_old = new DataControls.TownnameTab();
            InitializeComponent();
            townnameManage_old.LoadProvinceToComboBox(cmbprovince_old, "");
            DataControls.LoadComboBoxData(cmbUnit, DataDefinition.GetUnitmoreTab(), "unit_name", "unit_id");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newsubid = string.Empty;
            string str =    dcore.GetMaxSubUnit(DataControls.GetSelectedValueComboBoxToString(cmbUnit));
            if (string.IsNullOrEmpty(str))
            {
                newsubid = DataControls.GetSelectedValueComboBoxToString(cmbUnit) + "01";
            }
            else {

                newsubid = DataControls.GetSelectedValueComboBoxToString(cmbUnit) + string.Format("{0:00}",Convert.ToInt32(str)+1);
            }
            DataRow param = dcore.GetListAddress("").NewRow();
            param["unit_id"] = DataControls.GetSelectedValueComboBoxToString(cmbUnit);
            param["unit_name"] = txtsubunit.Text.Trim();
            param["subunit_id"] = newsubid;
            param["ADDRESS"] = txtaddress_old.Text.Trim();
            param["ADDRESS_MU"] = txtaddress_mu_old.Text.Trim();
            param["ADDRESS_SOIL"] = txtaddress_soid_old.Text.Trim();
            param["ADDRESS_ROAD"] = txtaddress_road_old.Text.Trim();
            
            param["level"] = "1";


            string s = string.Empty;
            if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old)))
            {

                param["TOWNCODE"] = DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old);
                s = DataControls.GetSelectedValueComboBoxToString(cmbsub_district_old);
            }
            else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old)))
            {
                param["TOWNCODE"] = DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old);
                s = DataControls.GetSelectedValueComboBoxToString(cmbdistrict_old);

            }
            else if (!string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbprovince_old)))
            {

                param["TOWNCODE"] = DataControls.GetSelectedValueComboBoxToString(cmbprovince_old);
                s= DataControls.GetSelectedValueComboBoxToString(cmbprovince_old);
            }
            
            //if (dcore.InsertSubunit(param))
            //{



            //    MessageBox.Show("บันทึกสำเร็จ");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("บันทึกผิดพลาด");
            //}
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
