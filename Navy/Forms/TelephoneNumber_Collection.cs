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
            TxtBox_Company.Focus();
            TxtBox_Company.SelectAll();
            TxtBox_Batt.SelectAll();
        }



        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Btn_Search_Click(object sender, EventArgs e)
        {
            //set label text
            Label_Batt.Text = TxtBox_Batt.Text;
            Label_Company.Text = TxtBox_Company.Text;
        }

        private void AddEnterKeyDown()
        {
            TxtBox_Company.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            TxtBox_Batt.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
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
    }
}
