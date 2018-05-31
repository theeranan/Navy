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
    public partial class ViewProfile : Form
    {
        DataControls.TownnameTab townnameManage_old;
        DataControls.TownnameTab townnameManage;
        DataCoreLibrary dcore;
        public ViewProfile(string id)

        {
            townnameManage_old = new DataControls.TownnameTab();
            townnameManage = new DataControls.TownnameTab();
            dcore = new DataCoreLibrary();  
            InitializeComponent();
            GetData(id, "");
        }
        protected void GetData(string navyid, string selectmove)
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
                lbname.Text = dr["name"].ToString();
                lblsname.Text = dr["sname"].ToString();

                lblid13.Text = dr["id13"].ToString();

              
                    
                        lbladdress_old.Text = dr["address_in"].ToString();
                        lbladdress_mu_old.Text = dr["address_mu_in"].ToString();
                        lbladdress_soid_old.Text = dr["address_soid_in"].ToString();
                        lbladdress_road_old.Text = dr["address_road_in"].ToString();

                        string tcode = dr["towncode_in"].ToString();
                        try
                        {
                           DataTable  city = DataDefinition.GetTownnameLV2(tcode).Copy();

                           townnameManage_old.LoadProvinceToComboBox(cmbprovince_old, tcode);
                           cmbprovince_old.SelectedValue = tcode.Substring(0, 2) + "0000";
                           townnameManage_old.LoadCityToComboBox(cmbdistrict_old, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                           townnameManage_old.LoadTumbonToComboBox(cmbsub_district_old, tcode.Substring(0, 4) + "00", tcode);

                        }
                        catch { }
                        lbladdress.Text = dr["address_out"].ToString();
                        lbladdress_mu.Text = dr["address_mu_out"].ToString();
                        lbladdress_soid.Text = dr["address_soid_out"].ToString();
                        lbladdress_road.Text = dr["address_road_out"].ToString();

                        string tcode_out = dr["towncode_out"].ToString();
                        try
                        {
                            DataTable city = DataDefinition.GetTownnameLV2(tcode_out).Copy();

                            townnameManage.LoadProvinceToComboBox(cmbprovince, tcode);
                            cmbprovince.SelectedValue = tcode_out.Substring(0, 2) + "0000";
                            townnameManage.LoadCityToComboBox(cmbdistrict, tcode_out.Substring(0, 2) + "0000", tcode_out.Substring(0, 4) + "00");
                            townnameManage.LoadTumbonToComboBox(cmbsubdistrict, tcode_out.Substring(0, 4) + "00", tcode_out);

                        }
                        catch { }
                   
            }

        }
    }
}
