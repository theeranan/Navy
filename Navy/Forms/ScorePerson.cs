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
    public partial class ScorePerson : Form
    {
        //TelephoneSearch PersonTel;
        DataCoreLibrary dcore;
        DataTable dtUpdate;
        int count = -1;
        public ScorePerson()
        {
            InitializeComponent();
            AddEnterKeyDown();
            Cmb_Company.SelectAll();//กองร้อย
            Cmb_Batt.SelectAll();//กองพัน
            setCmbItem();//add combobox กองร้อย กองพัน
            // dtUpdate = setDataTable();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            dcore = new DataCoreLibrary();
            Label_Batt.Text = Cmb_Batt.Text;
            Label_Company.Text = Cmb_Company.Text;
            loaddatatelephone();
            Cmb_Company.SelectAll();
            Cmb_Batt.SelectAll();
            /*string searchValue = searchtextBox.Text;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Equals(searchValue))
                        {
                            int rowIndex = row.Index;
                            dataGridView1.Rows[rowIndex].Selected = true;
                            valueResult = true;
                            break;
                        }
                    }

                }
                if (!valueResult)
                {
                    MessageBox.Show("Unable to find " + searchtextBox.Text, "Not Found");
                    return;
                }*/
            }
        private void loaddatatelephone()
        {
            //ดึงข้อมูลจากการค้นหาเกบไว้ใน dtUpdate
            dtUpdate = dcore.GetSearchScore(Cmb_Batt.Text, Cmb_Company.Text,txtname.Text,txtsname.Text,mtxtid8.Text, out count);
            //dtUpdate = ConvertListToDataTable(PersonTel);
            Set_dtColumnName(dtUpdate);
            label_Count.Text = count.ToString() + " Record";
            gvResultPhonNumber.DataSource = dtUpdate;
            for (int i = 0; i <= gvResultPhonNumber.Columns.Count - 1; i++)
            {
                int colw = gvResultPhonNumber.Columns[i].Width;
                gvResultPhonNumber.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

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

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            string navyid = "", Percent = "";
            try
            {
                foreach (DataRow datarow in dtUpdate.Rows)
                {
                    int count = 0;
                    navyid = "";
                    Percent = "";
                    foreach (var cell in datarow.ItemArray)
                    {
                        if (count == 0)
                        { //navyid
                            navyid = cell.ToString();
                            // Console.Write("navyid = "+ cell);
                        }
                        else if (count == 7) //Telephone
                        {
                            Percent = cell.ToString();
                            //Console.Write(" Tel = " + cell);
                        }
                       
                        count++;
                    }
                    dcore.UpdateScore(navyid, Percent);
                }
                Console.WriteLine("==============================");
                MessageBox.Show("อัพเดตเสร็จสิ้น");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtname.Text = "";
            txtsname.Text = "";
            mtxtid8.Text = "";
            txtname.Focus();
        }


        //public DataTable ConvertListToDataTable<TelephoneSearch>(List<TelephoneSearch> items)
        //{
        //    DataTable dataTable = new DataTable(typeof(TelephoneSearch).Name);
        //    //Get all the properties
        //    PropertyInfo[] Props = typeof(TelephoneSearch).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in Props)
        //    {
        //        //Setting column names as Property names
        //        dataTable.Columns.Add(prop.Name);
        //    }      
        //    foreach (TelephoneSearch item in items)
        //    {
        //        var values = new object[Props.Length];
        //        for (int i = 0; i < Props.Length; i++)
        //        {
        //            //inserting property values to datatable rows
        //            values[i] = Props[i].GetValue(item, null);
        //        }
        //        dataTable.Rows.Add(values);
        //    }
        //    //put a breakpoint here and check datatable
        //    return dataTable;
        //}

        private void AddEnterKeyDown()
        {
            Cmb_Company.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            Cmb_Batt.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            txtname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            txtsname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            mtxtid8.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            Btn_Search.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
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

        private void Set_dtColumnName(DataTable dtUpdate) {
            dtUpdate.Columns["NAVYID"].ColumnName = "navyid";
            dtUpdate.Columns["BATT"].ReadOnly = true;
            dtUpdate.Columns["COMPANY"].ReadOnly = true;
            dtUpdate.Columns["PLATOON"].ReadOnly = true;
            dtUpdate.Columns["PSEQ"].ReadOnly = true;
            dtUpdate.Columns["NAME"].ReadOnly = true;
            dtUpdate.Columns["SNAME"].ReadOnly = true;
            dtUpdate.Columns["BATT"].ColumnName = "พัน";
            dtUpdate.Columns["COMPANY"].ColumnName = "ร้อย";
            dtUpdate.Columns["PLATOON"].ColumnName = "มว.";
            dtUpdate.Columns["PSEQ"].ColumnName = "ลำดับ";
            dtUpdate.Columns["NAME"].ColumnName = "ชื่อ";
            dtUpdate.Columns["SNAME"].ColumnName = "นามสกุล";
            dtUpdate.Columns["Percent"].ColumnName = "คะแนนสอบ";

        }
        
    }
}
