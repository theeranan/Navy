using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navy.Core
{
    class DataControls
    {
        public static void LoadComboBoxData(ComboBox combobox, DataTable datasource, string textField, string valueField)
        {
            combobox.DataSource = datasource;
            combobox.DisplayMember = textField;
            combobox.ValueMember = valueField;
            combobox.AutoCompleteMode = AutoCompleteMode.Append;
            combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            combobox.SelectedIndex = -1;
            combobox.SelectedText = "";
            combobox.SelectedItem = null;
            combobox.Text = "";
        }

        public static void LoadComboBoxData(ComboBox combobox, DataTable datasource, string textField, string valueField, string value)
        {
            try
            {
                combobox.DataSource = datasource;
                combobox.DisplayMember = textField;
                combobox.ValueMember = valueField;
                combobox.AutoCompleteMode = AutoCompleteMode.Append;
                combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
                if (value == string.Empty)
                {
                    combobox.SelectedIndex = -1;
                    combobox.SelectedText = "";
                    combobox.SelectedItem = null;
                    combobox.Text = "";
                }
                else
                {
                    combobox.SelectedValue = value;
                }
            }

            catch (Exception)
            {
                combobox.DataSource = null;
            }
        }

        public static string GetSelectedValueComboBoxToString(ComboBox cbb)
        {
            try
            {
              
                return cbb.SelectedValue.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static string GetSelectedTextComboBoxToString(ComboBox cbb)
        {
            try
            {
                return cbb.Text.ToString();
            }
            catch
            {
                return "";
            }
        }
        public class ControlFinder<T> where T : Control
        {
            private readonly List<T> _foundControls = new List<T>();
            public IEnumerable<T> FoundControls
            {
                get { return _foundControls; }
            }

            public void FindChildControlsRecursive(Control control)
            {
                foreach (Control childControl in control.Controls)
                {
                    if (childControl.GetType() == typeof(T))
                    {
                        _foundControls.Add((T)childControl);
                    }
                    else
                    {
                        FindChildControlsRecursive(childControl);
                    }
                }
            }
        }

        // Townname Tab Management
        // Province - City - Tumbon
        public class TownnameTab
        {
            public DataTable province { get; set; }
            public DataTable city { get; set; }
            public DataTable tumbon { get; set; }

            public string SelectedProvince { get; set; }
            public string SelectedCity { get; set; }
            public string SelectedTumbon { get; set; }
            
            public TownnameTab()
            {
                province = DataDefinition.GetTownnameLV1().Copy();
                city = new DataTable();
                tumbon = new DataTable();
            }

            public TownnameTab(DataTable dataSourceProvince, DataTable dataSourceCity, DataTable dataSourceTumbon)
            {
                province = dataSourceProvince.Copy();
                city = dataSourceCity.Copy();
                tumbon = dataSourceTumbon.Copy();
            }

            //build-in function for controls
            public void LoadProvinceToComboBox(ComboBox cbb)
            {
                LoadComboBoxData(cbb, province, "TOWNNAME", "TOWNCODE");
                SelectedProvince = "";
            }

            public void LoadProvinceToComboBox(ComboBox cbb, string towncodeLV1)
            {
                LoadComboBoxData(cbb, province, "TOWNNAME", "TOWNCODE", towncodeLV1);
                SelectedProvince = towncodeLV1;
            }
                       
            public void LoadCityToComboBox(ComboBox cbb, string towncodeLV1)
            {
                city = DataDefinition.GetTownnameLV2(towncodeLV1).Copy();
                LoadComboBoxData(cbb, city, "TOWNNAME", "TOWNCODE");
                SelectedCity = "";
            }

            public void LoadCityToComboBox(ComboBox cbb, string towncodeLV1, string towncodeLV2)
            {
                city = DataDefinition.GetTownnameLV2(towncodeLV1).Copy();
                LoadComboBoxData(cbb, city, "TOWNNAME", "TOWNCODE", towncodeLV2);
                SelectedCity = towncodeLV2;
            }

            public void LoadTumbonToComboBox(ComboBox cbb, string towncodeLV2)
            {
                tumbon = DataDefinition.GetTownnameLV3(towncodeLV2).Copy();
                LoadComboBoxData(cbb, tumbon, "TOWNNAME", "TOWNCODE");
                SelectedTumbon = "";
            }

            public void LoadTumbonToComboBox(ComboBox cbb, string towncodeLV2, string towncodeLV3)
            {
                tumbon = DataDefinition.GetTownnameLV3(towncodeLV2).Copy();
                LoadComboBoxData(cbb, tumbon, "TOWNNAME", "TOWNCODE", towncodeLV3);
                SelectedTumbon = towncodeLV3;
            }
            
          
          
        }


    }
}
