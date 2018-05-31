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
    public partial class IndictmentForm : Form
    {
        List<PersonSearch> personNavyData;
        public PersonSearch personSelected;
        DataCoreLibrary dcore;
        ParamSearchPerson paramSearch;
        int count = -1;
        int itemsPerPage = Constants.countItemResult;
        int page = 1;

        public IndictmentForm()
        {
            InitializeComponent();
            TxtBox_Yearin.Focus();
            TxtBox_ID8.SelectAll();
            TxtBox_ID13.SelectAll();
            TxtBox_Name.SelectAll();
            TxtBox_Sname.SelectAll();
            AddEnterKeyDown();         
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            dcore = new DataCoreLibrary();
            page = 1;
            Search(gv_result);
            TxtBox_Yearin.Focus();
            TxtBox_ID8.SelectAll();
            TxtBox_ID13.SelectAll();
            TxtBox_Name.SelectAll();
            TxtBox_Sname.SelectAll();
            GVsSetAutoSizeColumns();
        }

        private void Search(DataGridView dgv)
        {
            try
            {
                paramSearch = new ParamSearchPerson();
                paramSearch.name = TxtBox_Name.Text;
                paramSearch.sname = TxtBox_Sname.Text;
                paramSearch.id8 = TxtBox_ID8.Text;
                paramSearch.id13 = TxtBox_ID13.Text;
                paramSearch.yearin = TxtBox_Yearin.Text;

                if (chkBox_HaveIndictment.Checked)
                {
                    personNavyData = dcore.GetSearchPersonOnlyIndictment("", "", paramSearch, itemsPerPage, page, out count);
                    dgv.DataSource = personNavyData;
                }
                else
                {
                    personNavyData = dcore.GetSearchPerson("", "", paramSearch, itemsPerPage, page, out count);
                    dgv.DataSource = personNavyData;
                }
                //เลือกไม่แสดง Column 
                try
                {
                    dgv.Columns["navyid"].Visible = false;
                    dgv.Columns["birthdate"].Visible = false;
                    dgv.Columns["oldyearin"].Visible = false;
                }
                catch { }

                dgv.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddEnterKeyDown()
        {
            TxtBox_Yearin.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            TxtBox_ID8.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            TxtBox_Name.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            TxtBox_Sname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            TxtBox_ID13.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
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

        public void GVsSetAutoSizeColumns()
        {
            this.gv_result.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_result.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gv_result.MultiSelect = false;
        }

        private void Btn_GetIndictData_Click(object sender, EventArgs e)
        {
            //Call Gridview_CelldoubleClick
            gv_result_CellDoubleClick(this.gv_result, new DataGridViewCellEventArgs(this.gv_result.CurrentCell.ColumnIndex,this.gv_result.CurrentRow.Index));
        }

        private void gv_result_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            View_Indictment f = new View_Indictment(gv_result.SelectedRows[0].Cells["navyid"].Value.ToString());
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void chkBox_HaveIndictment_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TxtBox_ID8_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void gv_result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtBox_Yearin_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TxtBox_ID13_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBox_Sname_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBox_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label_Yearin_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
