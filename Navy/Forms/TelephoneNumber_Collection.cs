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
    public partial class TelephoneNumber_Collection : Form
    {
        public TelephoneNumber_Collection()
        {
            InitializeComponent();
            AddEnterKeyDown();
            Cmb_Company.SelectAll();
            Cmb_Batt.SelectAll();
            setCmbItem();
        }



        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Btn_Search_Click(object sender, EventArgs e)
        {
            Label_Batt.Text = Cmb_Batt.Text;
            Label_Company.Text = Cmb_Company.Text;
            Cmb_Company.SelectAll();
            Cmb_Batt.SelectAll();
        }

        private void AddEnterKeyDown()
        {
            Cmb_Company.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            Cmb_Batt.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            Btn_Search.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            TxtBox_PhoneNumber.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            Btn_Save.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
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

        private void TelephoneNumber_Collection_Load(object sender, EventArgs e)
        {

        }

        private void setCmbItem() {
            Cmb_Company.Items.Add(1);
            Cmb_Company.Items.Add(2);
            Cmb_Company.Items.Add(3);
            Cmb_Company.Items.Add(4);
            Cmb_Company.Items.Add(5);
            Cmb_Company.Items.Add(6);
            Cmb_Batt.Items.Add(1);
            Cmb_Batt.Items.Add(2);
            Cmb_Batt.Items.Add(3);
            Cmb_Batt.Items.Add(4);
            Cmb_Batt.Items.Add(5);
        }
    }
}
