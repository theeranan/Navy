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
    public partial class Addkptclass : Form
    {
        DataCoreLibrary dcore;
        DataTable dtUpdate;
        int count = -1;
        string navyid;
        public Addkptclass()
        {
            InitializeComponent();
            LoadControlsValue();
            setdatagrid();
            AddEnterKeyDown();
            cbbkptclass.SelectAll();
            txtname.SelectAll();
            txtsname.SelectAll();
            mtxtid8.SelectAll();

        }
        private void setdatagrid()
        {
            
            //gvSearch.Columns[0].Selected = true;
            //gvKptclass.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            //gvKptclass.Columns[0].Selected = true;
        }
        public void LoadControlsValue()
        {
            DataControls.LoadComboBoxData(cbbkptclass, DataDefinition.Getkptclass(), "kptclass", "kptcode", "");
        }

        private void cbbkptclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadkpt();
        }
        private void loadkpt()
        {
            string kptclass;
            if (cbbkptclass.SelectedIndex != -1)
            {
                dcore = new DataCoreLibrary();
                if (cbbkptclass.Text.Trim() != "")
                {
                    kptclass = DataControls.GetSelectedValueComboBoxToString(cbbkptclass);
                    dtUpdate = dcore.getkptclass(kptclass, out count);
                    Set_dtColumnName(dtUpdate);
                    //label_Count.Text = count.ToString() + " Record";
                    gvKptclass.DataSource = dtUpdate;
                    gvKptclass.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    gvKptclass.MultiSelect = false;
                    gvKptclass.ReadOnly = true;
                }
                else
                {
                    kptclass = null;
                }
            }
        }
        private void Set_dtColumnName(DataTable dtUpdate)
        {
            dtUpdate.Columns["NAME"].ReadOnly = true;
            dtUpdate.Columns["SNAME"].ReadOnly = true;
            dtUpdate.Columns["NAME"].ColumnName = "ชื่อ";
            dtUpdate.Columns["SNAME"].ColumnName = "นามสกุล";
            dtUpdate.Columns["ID8"].ColumnName = "ทะเบียน";
        }
        private void Set_dtSeachColumnName(DataTable dtUpdate)
        {

            dtUpdate.Columns["NAME"].ColumnName = "ชื่อ";
            dtUpdate.Columns["SNAME"].ColumnName = "นามสกุล";
            dtUpdate.Columns["ID8"].ColumnName = "ทะเบียน";
            dtUpdate.Columns["kptclass"].ColumnName = "คพท";
            
        }
        private void gvKptclass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dtUpdate = dcore.getsearchpersonkpt(txtname.Text,txtsname.Text,mtxtid8.Text, out count);
            
            Set_dtSeachColumnName(dtUpdate);
            //label_Count.Text = count.ToString() + " Record";

            gvSearch.DataSource = dtUpdate;
            gvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvSearch.MultiSelect = false;
            gvKptclass.ReadOnly = true;
            if (count > 0)
            {
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
                    updatekptclass();
                }
            }
        }

        private void gvSearch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvSearch.RowCount > 1)
            {
                navyid = gvSearch.SelectedRows[0].Cells["navyid"].Value.ToString();
                if (navyid != "" && navyid != null)
                {
                    updatekptclass();
                }
            }
        }
        private void updatekptclass()
        {
            dcore = new DataCoreLibrary();
            string kptcode;
            kptcode = DataControls.GetSelectedValueComboBoxToString(cbbkptclass);
            if(kptcode!="" && kptcode != null)
            {
                dcore.UpdateKptclass(navyid, kptcode);
                MessageBox.Show("เสร็จสิีน");
                loadkpt();
                txtname.Text = "";
                txtsname.Text = "";
                mtxtid8.Text = "";
                txtname.Focus();
            }
            else
            {
                MessageBox.Show("เลือกสาขาอาชีพก่อน");
                cbbkptclass.Focus();
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
                if (navyid != "" && navyid != null)
                {
                    updatekptclass();
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            deletekpt();
        }
        private void deletekpt()
        {
            if (gvKptclass.RowCount > 1)
            {
                navyid = gvKptclass.SelectedRows[0].Cells["navyid"].Value.ToString();
                if (navyid != "" && navyid != null)
                {
                    dcore.DeleteKptclass(navyid);
                    MessageBox.Show("เสร็จสิีน");
                    loadkpt();
                }
            }
        }
        private void gvKptclass_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            deletekpt();
        }
    }
}
