using Navy.Core;
using Navy.Data.DataTemplate;
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
    public partial class AddData_Collection : Form
    {
        //TelephoneSearch PersonTel;
        DataCoreLibrary dcore;
        DataTable dtUpdate;
        int count = -1;
        int currentRow;
        string mode="";
        public AddData_Collection()
        {
            InitializeComponent();
            AddEnterKeyDown();
            Cmb_Company.SelectAll();
            Cmb_Batt.SelectAll();
            setCmbItem();
            // dtUpdate = setDataTable();
        }
        public AddData_Collection(string m)
        {
            mode = m;
            InitializeComponent();
            AddEnterKeyDown();
            Cmb_Company.SelectAll();
            Cmb_Batt.SelectAll();
            setCmbItem();
            // dtUpdate = setDataTable();
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            dcore = new DataCoreLibrary();
            Label_Batt.Text = Cmb_Batt.Text;
            Label_Company.Text = Cmb_Company.Text;
            loaddata();
            Cmb_Company.SelectAll();
            Cmb_Batt.SelectAll();
            }
        private void loaddata()
        {
            dtUpdate = dcore.GetSearchPersonCollection(Cmb_Batt.Text, Cmb_Company.Text,txtname.Text,txtsname.Text,mtxtid8.Text,mode, out count);
            //dtUpdate = ConvertListToDataTable(PersonTel);
            Set_dtColumnName(dtUpdate);
            label_Count.Text = count.ToString() + " Record";
            gvResult.DataSource = dtUpdate;
            
            gvResult.Columns["navyid"].Visible = false;
            for (int i = 0; i <= gvResult.Columns.Count - 1; i++)
            {
                int colw = gvResult.Columns[i].Width;
                gvResult.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            gvResult.CurrentCell = gvResult.Rows[0].Cells[7];
            gvResult.Focus();
        }
        private void setCmbItem() {
            Cmb_Company.Items.Add(1);
            Cmb_Company.Items.Add(2);
            Cmb_Company.Items.Add(3);
            Cmb_Company.Items.Add(4);
            Cmb_Company.Items.Add(5);
            Cmb_Company.Items.Add(6);
            Cmb_Company.Items.Add(0);
            Cmb_Batt.Items.Add(1);
            Cmb_Batt.Items.Add(2);
            Cmb_Batt.Items.Add(3);
            Cmb_Batt.Items.Add(4);
            Cmb_Batt.Items.Add(5);
            Cmb_Batt.Items.Add(6);
            Cmb_Batt.Items.Add(7);
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Update(currentRow);
            txtname.Text = "";
            txtsname.Text = "";
            mtxtid8.Text = "";
            txtname.Focus();
        }

        private void AddEnterKeyDown()
        {
            Cmb_Company.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            Cmb_Batt.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            txtname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            txtsname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            mtxtid8.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            Btn_Search.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            
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

        private void gvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;
        }

        private void Set_dtColumnName(DataTable dtUpdate) {
            dtUpdate.Columns["NAME"].ReadOnly = true;
            dtUpdate.Columns["SNAME"].ReadOnly = true;
            dtUpdate.Columns["BATT"].ReadOnly = true;
            dtUpdate.Columns["COMPANY"].ReadOnly = true;
            dtUpdate.Columns["PLATOON"].ReadOnly = true;
            dtUpdate.Columns["PSEQ"].ReadOnly = true;
            dtUpdate.Columns["BATT"].ColumnName = "พัน";
            dtUpdate.Columns["COMPANY"].ColumnName = "ร้อย";
            dtUpdate.Columns["PLATOON"].ColumnName = "มว.";
            dtUpdate.Columns["PSEQ"].ColumnName = "ลำดับ";
            dtUpdate.Columns["NAME"].ColumnName = "ชื่อ";
            dtUpdate.Columns["SNAME"].ColumnName = "นามสกุล";

            switch (mode)
            {
                case "":
                    {
                        dtUpdate.Columns["Telephone"].ColumnName = "เบอร์โทรศัพท์";
                        dtUpdate.Columns["FTelephone"].ColumnName = "เบอร์โทรศัพท์บิดา";
                        dtUpdate.Columns["MTelephone"].ColumnName = "เบอร์โทรศัพท์มารดา";
                        dtUpdate.Columns["PTelephone"].ColumnName = "เบอร์โทรศัพท์ผู้ปกครอง";
                    }
                    break;
                case "Percent":
                    {
                        dtUpdate.Columns["Percent"].ColumnName = "คะแนนสอบ";
                    }
                    break;
                default:
                    {
                        MessageBox.Show("โหมดผิดพลาด " + mode);
                    }break;
            }


            
        }

        private void gvResult_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Update(e.RowIndex);
        }
        private void Update(int RowIndex)
        {
            string navyid = "", 
                TelNumber = "", 
                FTelNumber = "", 
                MTelNumber = "", 
                PTelNumber = "",
                Percent = "";
            try
            {

                navyid = gvResult.Rows[RowIndex].Cells["navyid"].Value.ToString();
                switch (mode)
                {
                    case "":
                        {
                            TelNumber = gvResult.Rows[RowIndex].Cells[7].Value.ToString();
                            FTelNumber = gvResult.Rows[RowIndex].Cells[8].Value.ToString();
                            MTelNumber = gvResult.Rows[RowIndex].Cells[9].Value.ToString();
                            PTelNumber = gvResult.Rows[RowIndex].Cells[10].Value.ToString();
                            dcore.UpdateTelephone(navyid, TelNumber, FTelNumber, MTelNumber, PTelNumber);
                        }
                        break;
                    case "Percent":
                        {
                            Percent = gvResult.Rows[RowIndex].Cells[7].Value.ToString();
                            dcore.UpdatePercent(navyid, Percent);
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("โหมดผิดพลาด " + mode);
                        }
                        break;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
