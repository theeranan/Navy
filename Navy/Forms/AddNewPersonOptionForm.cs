using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Core;

namespace Navy.Forms
{
    public partial class AddNewPersonOptionForm : Form
    {
        public string yearin = "";
        public string armtown = "";
        public DateTime regisDate = DateTime.MinValue;
        public DateTime comeDate = DateTime.MinValue;
        public string originId = "";
        public bool hasValue = false;
        
        public AddNewPersonOptionForm()
        {
            InitializeComponent();
            AddEnterKeyDown();
            LoadControlsValue();
        }

        private void LoadControlsValue()
        {
            if (cbbArmtown.DataSource == null)
            {
                DataControls.LoadComboBoxData(cbbArmtown, DataDefinition.GetArmtownTab(), "ARMNAME", "ARMID");
            }

            if (cbbOrigin.DataSource == null)
            {
                DataControls.LoadComboBoxData(cbbOrigin, DataDefinition.GetOriginTab(), "origin", "origincode", "1");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resultVal = "";
            object objectValidate = CheckRequireField(out resultVal);
            if (resultVal == "")
            {
                SetValue();
                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูล [" + resultVal + "]");
                ((Control)objectValidate).Focus();
            }
        }

        private object CheckRequireField(out string objectNameDisplay)
        {
            if (!Function.ValidateYearinFormat(mtxtYearin.Text))
            {
                objectNameDisplay = "ผลัด";
                return mtxtYearin;
            }
            
            if (cbbArmtown.SelectedIndex < 0)
            {
                objectNameDisplay = "จังหวัด";
                return cbbArmtown;
            }

            if (cbbOrigin.SelectedIndex < 0)
            {
                objectNameDisplay = "ประเภทการเข้าเป็นทหาร";
                return cbbOrigin;
            }

            objectNameDisplay = "";
            return null;
        }

        private void SetValue()
        {
            yearin = mtxtYearin.Text;
            armtown = cbbArmtown.SelectedValue.ToString();
            regisDate = dtpRegisDate.Value;
            comeDate = dtpComeDate.Value;
            originId = cbbOrigin.SelectedValue.ToString();
            hasValue = true;            
        }

        private void mtxtYearin_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((MaskedTextBox)sender).SelectAll(); });
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("en"));
        }

        private void cbbArmtown_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((ComboBox)sender).SelectAll(); });
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void dtpRegisDate_Enter(object sender, EventArgs e)
        {

        }

        private void dtpComeDate_Enter(object sender, EventArgs e)
        {

        }

        private void cbbOrigin_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((ComboBox)sender).SelectAll(); });
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void AddNewPersonOptionForm_Activated(object sender, EventArgs e)
        {
            mtxtYearin.Focus();
        }

        private void cbbArmtown_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpComeDate.Value = dtpRegisDate.Value;
            string value = DataControls.GetSelectedValueComboBoxToString(cbbArmtown);
            if (DataDefinition.GetArmtownLegion(value) == "4")
            {
                dtpComeDate.Value = dtpRegisDate.Value.AddDays(1);
            }
        }

        private void mtxtYearin_TextChanged(object sender, EventArgs e)
        {
            if (Function.ValidateYearinFormat(mtxtYearin.Text))
            {
                dtpRegisDate.Value = Function.GetFirstDateOfYearin(mtxtYearin.Text);
            }
        }

        private void dtpRegisDate_ValueChanged(object sender, EventArgs e)
        {
            cbbArmtown_SelectedIndexChanged(sender, e);
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

        private void AddEnterKeyDown()
        {
            mtxtYearin.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            cbbArmtown.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            dtpRegisDate.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            dtpComeDate.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            cbbOrigin.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
        }
    }
}
