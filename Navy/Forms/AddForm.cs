using Navy.Core;
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
    public partial class AddForm : Form
    {
        DataCoreLibrary dcore;
        DataTable dtUpdate;
        int count = -1;
        string navyid;
        string mode = "";
        public AddForm()
        {
            InitializeComponent();
            LoadControlsValue();
            AddEnterKeyDown();
            cbb.SelectAll();
            txtname.SelectAll();
            txtsname.SelectAll();
            mtxtid8.SelectAll();

        }
        public AddForm(string m)
        {
            mode = m;
            InitializeComponent();
            LoadControlsValue();
            AddEnterKeyDown();
            cbb.SelectAll();
            txtname.SelectAll();
            txtsname.SelectAll();
            mtxtid8.SelectAll();
        }
        public void LoadControlsValue()
        {
            cbb.Items.Clear();
            cbb.SelectedIndex = -1;
            switch (mode)
            {
                case "addictive": {
                        DataControls.LoadComboBoxData(cbb, DataDefinition.GetAddictive_Status(), "addname", "addcode", "");
                        lblText.Text = "กลุ่ม";
                    } break;
                default: {
                        DataControls.LoadComboBoxData(cbb, DataDefinition.Getkptclass(), "kptclass", "kptcode", "");
                        lblText.Text = "หลักสูตร";
                    } break;
            }
            lblcountkptclass.Text = "";
            lblcountsearch.Text = "";
        }

        private void cbbkptclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            string cbbcode;
            if (cbb.SelectedIndex != -1)
            {
                dcore = new DataCoreLibrary();
                if (cbb.Text.Trim() != "" && cbb.Text.Trim() !="System.Data.DataRowView")
                {
                    cbbcode = DataControls.GetSelectedValueComboBoxToString(cbb);
                    
                    switch (mode)
                    {
                        case "addictive":
                            {
                                dtUpdate = dcore.getaddictive(cbbcode, out count);
                                Set_dtColumnName(dtUpdate);
                            }
                            break;
                        default:
                            {
                                dtUpdate = dcore.getkptclass(cbbcode, out count);
                                Set_dtColumnName(dtUpdate);
                            }
                            break;
                    }
                    lblcountkptclass.Text = count.ToString() + " Record";
                    gvKptclass.DataSource = dtUpdate;
                    gvKptclass.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    gvKptclass.MultiSelect = false;
                    gvKptclass.ReadOnly = true;
                    for (int i = 0; i <= gvKptclass.Columns.Count - 1; i++)
                    {
                        int colw = gvKptclass.Columns[i].Width;
                        gvKptclass.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                else
                {
                    cbbcode = null;
                }
            }
        }
        private void Set_dtColumnName(DataTable dtUpdate)
        {
            dtUpdate.Columns["navyid"].ReadOnly = true;
            dtUpdate.Columns["NAME"].ReadOnly = true;
            dtUpdate.Columns["SNAME"].ReadOnly = true;
            dtUpdate.Columns["NAME"].ColumnName = "ชื่อ";
            dtUpdate.Columns["SNAME"].ColumnName = "นามสกุล";
            dtUpdate.Columns["ID8"].ColumnName = "ทะเบียน";
            

        }
        private void Set_dtSeachColumnName(DataTable dtUpdate)
        {
            dtUpdate.Columns["navyid"].ReadOnly = true;
            dtUpdate.Columns["NAME"].ReadOnly = true;
            dtUpdate.Columns["SNAME"].ReadOnly = true;
            dtUpdate.Columns["NAME"].ColumnName = "ชื่อ";
            dtUpdate.Columns["SNAME"].ColumnName = "นามสกุล";
            dtUpdate.Columns["ID8"].ColumnName = "ทะเบียน";
            switch (mode)
            {
                case "addictive":
                    {
                        dtUpdate.Columns["addname"].ColumnName = "ผลตรวจสารเสพติด";
                    }
                    break;
                default:
                    {
                        dtUpdate.Columns["kptclass"].ColumnName = "คพท";
                    }
                    break;
            }

        }
        private void gvKptclass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dtUpdate = dcore.getsearchpersonAddDoc(txtname.Text,txtsname.Text,mtxtid8.Text,mode, out count);
            
            Set_dtSeachColumnName(dtUpdate);
            lblcountsearch.Text = count.ToString() + " Record";
            gvSearch.DataSource = dtUpdate;
            gvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvSearch.MultiSelect = false;
            gvKptclass.ReadOnly = true;
            if (count > 0)
            {
                for (int i = 0; i <= gvSearch.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = gvSearch.Columns[i].Width;
                    //remove autosizing
                    gvSearch.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //set width to calculated by autosize
                    //gvSearch.Columns[i].Width = colw;
                }
                gvSearch.Rows[0].Selected = true;
                gvSearch.Focus();
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
                txtname.Focus();
            }
        }

        private void gvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            navyid = gvSearch.SelectedRows[0].Cells["navyid"].Value.ToString();
        }
        
        private void gvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                navyid = gvSearch.SelectedRows[0].Cells["navyid"].Value.ToString();
                if (navyid != "" && navyid != null)
                {
                    updateDoc();
                }
            }
        }
        private bool updateDoc()
        {
            dcore = new DataCoreLibrary();
            string cbbcode;
            cbbcode = DataControls.GetSelectedValueComboBoxToString(cbb);
            if (cbbcode != "" && cbbcode != null)
            {
                switch (mode)
                {
                    case "addictive":
                        {
                            dcore.UpdateAddictive(navyid, cbbcode);
                        }
                        break;
                    default:
                        {
                            if (gvSearch.SelectedRows[0].Cells["คพท"].Value.ToString() != "")
                            {
                                DialogResult dialogResult = MessageBox.Show(
                                    "พลฯ " + gvSearch.SelectedRows[0].Cells["ชื่อ"].Value.ToString()
                                    + " " + gvSearch.SelectedRows[0].Cells["นามสกุล"].Value.ToString()
                                    + " มีสาขาอาชีพ" + gvSearch.SelectedRows[0].Cells["คพท"].Value.ToString()
                                    + " ยืนยันการเปลี่ยนสาขาอาชีพหรือไม่?", "แจ้งเตือน", MessageBoxButtons.YesNo);
                                /*if (dialogResult == DialogResult.Yes)
                                {
                                    updateDoc();
                                }*/
                                if (dialogResult == DialogResult.No)
                                {
                                    return false;
                                }
                            }
                            dcore.UpdateKptclass(navyid, cbbcode);
                        }
                        break;
                }
                MessageBox.Show("เสร็จสิีน");
                load();
                txtname.Text = "";
                txtsname.Text = "";
                mtxtid8.Text = "";
                txtname.Focus();
                return true;
            }
            else
            {
                MessageBox.Show("เลือกสาขาอาชีพก่อน");
                cbb.Focus();
                return false;
            }
        }
        private void gvSearch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvSearch.RowCount > 1)
            {
                navyid = gvSearch.SelectedRows[0].Cells["navyid"].Value.ToString();
                if (navyid != "" && navyid != null)
                {
                    updateDoc();
                }
            }
        }
        private void AddEnterKeyDown()
        {
            txtname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            txtsname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            mtxtid8.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            btn_search.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            btnadd.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);

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
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (gvSearch.RowCount > 1)
            {
                navyid = gvSearch.SelectedRows[0].Cells["navyid"].Value.ToString();
                
                if (navyid != "" && navyid != null) { 
                    {
                        updateDoc();
                    }
                
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            deleteDoc();
        }
        private void deleteDoc()
        {
            if (gvKptclass.RowCount > 1)
            {
                navyid = gvKptclass.SelectedRows[0].Cells["navyid"].Value.ToString();
                if (navyid != "" && navyid != null)
                {
                    switch (mode)
                    {
                        case "addictive":
                            {
                                dcore.DeleteAddictive(navyid);
                            }
                            break;
                        default:
                            {
                                dcore.DeleteKptclass(navyid);
                            }
                            break;
                    }
                    MessageBox.Show("เสร็จสิีน");
                    load();
                }
            }
        }
        private void gvKptclass_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            deleteDoc();
        }
    }
}
