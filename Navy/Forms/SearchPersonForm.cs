using Navy.Core;
using Navy.Data;
using Navy.Data.DataTemplate;
using Navy.MyControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navy.Forms
{
    public partial class SearchPersonForm : Form
    {
        DataTable personTable;
        List<PersonSearch> personNavyData;
        public PersonSearch personSelected;
        DataCoreLibrary dcore;
        ParamSearchPerson paramSearch;
        //DataControls.TownnameTab townnameManage;
        int count = -1;
        int itemsPerPage = Constants.countItemResult;
        int page = 1;
        int totalPage = -1;
        public static string SetValueForText1 = "";
        //public static string SetValueForText2 = "";
        enum PersonGroups { All, Prepare, Trans, Request, SelectExam, Educ, Skill, General };
        PersonGroups pgroup = PersonGroups.All;
        DataTable dtPersonAll;
        DataTable dtPersonPrepare;
        DataTable dtPersonTrans;
        DataTable dtPersonRequest;
        DataTable dtPersonSelectExam;
        DataTable dtPersonEduc;
        DataTable dtPersonSkill;
        DataTable dtPersonGeneral;

        public SearchPersonForm()
        {
            InitializeComponent();
            mtxtYearin.Focus();
            mtxtYearin.SelectAll();
            mTextBoxID8.SelectAll();
            textBoxID13.SelectAll();
            textBoxRunNum.SelectAll();
            textBoxName.SelectAll();
            textBoxSname.SelectAll();
            cbbCompany.SelectAll();
            cbbBatt.SelectAll();
            setBattCompanyValue();
            AddEnterKeyDown();
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;
            GVsSetAutoSizeColumns();
            pgroup = PersonGroups.Prepare;
            DataControls.LoadComboBoxData(cbbProvince, DataDefinition.GetArmtownTab(), "ARMNAME", "ARMID");
        }

        private void EnableButtonPage()
        {
            if (page < totalPage)
            {
                btnNextPage.Enabled = true;
                btnPrevPage.Enabled = true;
            }
            else if (page == totalPage)
            {
                btnNextPage.Enabled = false;
                btnPrevPage.Enabled = true;
            }

            if (page == 1)
            {
                btnPrevPage.Enabled = false;
            }

            btnSubmit.Enabled = count > 0 ? true : false;
        }

        #region Search function
        private void Search(DataGridView dgv)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                paramSearch = new ParamSearchPerson();
                paramSearch.name = textBoxName.Text;
                paramSearch.sname = textBoxSname.Text;
                paramSearch.id8 = mTextBoxID8.Text;
                paramSearch.id13 = textBoxID13.Text;
                paramSearch.yearin = mtxtYearin.Text;
                paramSearch.runcode = textBoxRunNum.Text.Trim();
                paramSearch.company = cbbCompany.Text.Trim();
                paramSearch.batt = cbbBatt.Text.Trim();

                if (checkBoxSearchNivyAll.Checked)
                {
                    personTable = dcore.GetSearchPersonTable("", paramSearch, itemsPerPage, page, out count);
                    dgv.DataSource = personTable;
                }
                else
                {
                    //personTable = dcore.GetSearchPersonTable("", tempInput, itemsPerPage, page, out count);
                    personNavyData = dcore.GetSearchPerson("", DataControls.GetSelectedValueComboBoxToString(cbbProvince), paramSearch, itemsPerPage, page, out count);
                    dgv.DataSource = personNavyData;
                    try
                    {
                        dgv.Columns["navyid"].Visible = false;
                        dgv.Columns["id13"].Visible = false;
                    }
                    catch { }
                }

                if (count <= itemsPerPage)
                {
                    totalPage = Function.CalTotalPage(count, itemsPerPage);
                    labelCountSearchRecord.Text = Convert.ToString(count) + " Record(s)";
                    labelPaging.Text = page.ToString() + "/" + totalPage.ToString();
                }
                else
                {
                    totalPage = Function.CalTotalPage(count, itemsPerPage);
                    labelCountSearchRecord.Text = Convert.ToString((page * itemsPerPage) - itemsPerPage + 1) + " - " + Convert.ToString(page * itemsPerPage) + " of " + Convert.ToString(count) + " Record(s)";
                    labelPaging.Text = page.ToString() + "/" + totalPage.ToString();
                }
                EnableButtonPage();
                dgv.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            watch.Stop();
            label8.Text = String.Format("{0}m {1}s {2}ms", watch.Elapsed.Minutes, watch.Elapsed.Seconds, watch.Elapsed.Milliseconds);
        }

        private void Search(MyControls.GridviewResultControl dgv)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                paramSearch = new ParamSearchPerson();
                paramSearch.name = textBoxName.Text;
                paramSearch.sname = textBoxSname.Text;
                paramSearch.id8 = mTextBoxID8.Text;
                paramSearch.yearin = mtxtYearin.Text;
                paramSearch.id13 = textBoxID13.Text;
                paramSearch.runcode = textBoxRunNum.Text.Trim();

                if (checkBoxSearchNivyAll.Checked)
                {
                    if (dgv.EnablePagingData)
                    {
                        personTable = dcore.GetSearchPersonTable("", paramSearch, dgv.itemsPerPage, dgv.page, out dgv.count);
                        dgv.BindDataToGridView(personTable);
                        dgv.ConfigButtonPage();
                    }
                    else
                    {
                        personTable = dcore.GetSearchPersonTable("", paramSearch, out dgv.count);
                        dgv.BindDataToGridView(personTable);
                    }
                }
                else
                {
                    if (dgv.EnablePagingData)
                    {
                        personNavyData = dcore.GetSearchPerson("", DataControls.GetSelectedValueComboBoxToString(cbbProvince), paramSearch, dgv.itemsPerPage, dgv.page, out dgv.count);
                        dgv.BindDataToGridView(Function.ConvertToDataTable<PersonSearch>(personNavyData));
                        dgv.BindDataPaging(dgv.page);
                        dgv.ConfigButtonPage();
                    }
                    else
                    {
                        personNavyData = dcore.GetSearchPerson("", DataControls.GetSelectedValueComboBoxToString(cbbProvince), paramSearch);
                        dgv.count = personNavyData.Count;
                        dgv.BindDataToGridView(Function.ConvertToDataTable<PersonSearch>(personNavyData));
                    }

                    try
                    {
                        dgv.Columns["navyid"].Visible = false;
                        dgv.Columns["id13"].Visible = false;
                    }
                    catch { }
                }
                dgv.CalculatePaging();
                dgv.Refresh();
                dgv.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            watch.Stop();
            dgv.LbTimeExecute.Text = String.Format("{0}m {1}s {2}ms", watch.Elapsed.Minutes, watch.Elapsed.Seconds, watch.Elapsed.Milliseconds);
        }

        public void GetSearchData()
        {
                Search(gvResult);
        }
        #endregion

        #region Button Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dcore = new DataCoreLibrary();
            page = 1;
            GetSearchData();
            mtxtYearin.Focus();
            mtxtYearin.SelectAll();
            mTextBoxID8.SelectAll();
            textBoxID13.SelectAll();
            textBoxRunNum.SelectAll();
            textBoxName.SelectAll();
            textBoxSname.SelectAll();
            SetValueForText1 = textBoxID13.Text;


        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            page = page <= 1 ? 1 : page - 1;
            GetSearchData();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            page = page >= totalPage ? totalPage : page + 1;
            GetSearchData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                try
                {
                    AddNewPersonForm f = new AddNewPersonForm(gvResult.SelectedRows[0].Cells["navyid"].Value.ToString());
                    f.SetbtnSubmitAndNewVisible(false);
                    f.SetbtnSubmitVisible(true);
                    f.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("พบข้อผิดพลาดในการเรียกดูข้อมูล .. " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อน");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("ต้องการลบข้อมูลของบุคคลนี้ ใช่หรือไม่", "ลบข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();
                        string id13 = gvResult.SelectedRows[0].Cells["id13"].Value.ToString();
                        if (dcore.DeletePerson(navyid))
                        {
                            DataCoreLibrary dcore2 = new DataCoreLibrary();
                            dcore2.ChangeDB("midb");
                            dcore2.UpdatePersonUnUsed(id13);
                            MessageBox.Show("ลบข้อมูลเรียบร้อย");
                            Search(gvResult);
                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถลบข้อมูลได้");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดพลาดในการลบข้อมูล .. " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูล ก่อนทำการลบ");
            }
        }

        private void gvBtnPrevPage_Click(object sender, EventArgs e)
        {
            string f = ((Button)sender).FindForm().Name;
            MessageBox.Show(f);
            GetSearchData();
        }

        private void gvBtnNextPage_Click(object sender, EventArgs e)
        {
            string f = ((Button)sender).FindForm().Name;
            MessageBox.Show(f);
            GetSearchData();
        }
        #endregion

        #region Controls Event
        private void gvResult_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void gvResult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                gvResult.Focus();
                //personNivyRow = personNivyData.FindByID13(gvResult.SelectedRows[0].Cells["ID13"].Value.ToString());
            }
        }

        private void gvResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  btnSubmit_Click(sender, e);
                ViewForm f = new ViewForm(gvResult.SelectedRows[0].Cells["navyid"].Value.ToString());
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
                e.Handled = true;
            }
        }

        private void gvResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //  btnSubmit_Click(sender, e);
            ViewForm f = new ViewForm(gvResult.SelectedRows[0].Cells["navyid"].Value.ToString());
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (tabControl1.SelectedIndex == 1)
            {
                pgroup = PersonGroups.Prepare;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                pgroup = PersonGroups.Trans;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                pgroup = PersonGroups.Request;
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                pgroup = PersonGroups.SelectExam;
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                pgroup = PersonGroups.Educ;
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                pgroup = PersonGroups.Skill;
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                pgroup = PersonGroups.General;
            }
            else
            {
                pgroup = PersonGroups.All;
            }*/
        }

        //input number only
        private void textBoxRunNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region SelectAll Action

        private void SetTextboxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((TextBox)sender).SelectAll(); });
        }

        private void SetMaskedTextboxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((MaskedTextBox)sender).SelectAll(); });
        }

        private void SetComboBoxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((ComboBox)sender).SelectAll(); });
        }

        private void SetControlSelectAll()
        {
            foreach (Control c in groupBox1.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.Enter += new System.EventHandler(this.SetComboBoxSelectAll);
                }

                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.Enter += new System.EventHandler(this.SetTextboxSelectAll);
                }

                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.Enter += new System.EventHandler(this.SetMaskedTextboxSelectAll);
                }
            }
        }
        #endregion

        #region KeyPress Enter Event
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
            mTextBoxID8.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxID13.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxName.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxSname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxRunNum.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            cbbProvince.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            cbbCompany.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            cbbBatt.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
        }
        #endregion

        #region Gridview Config
        public void GVsSetAutoSizeColumns()
        {
            //
            DataControls.ControlFinder<DataGridView> cf = new DataControls.ControlFinder<DataGridView>();
            cf.FindChildControlsRecursive(groupBox2);

            foreach (DataGridView gv in cf.FoundControls)
            {
                gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

            ////set button event
            //DataControls.ControlFinder<GridviewResultControl> cf2 = new DataControls.ControlFinder<GridviewResultControl>();
            //cf2.FindChildControlsRecursive(groupBox2);

            //foreach (GridviewResultControl gv in cf2.FoundControls)
            //{
            //    gv.ButtonPrevPageClick += new EventHandler(gvBtnPrevPage_Click);
            //    gv.ButtonNextPageClick += new EventHandler(gvBtnNextPage_Click); 
            //}
        }
        #endregion

        private void gvResult_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void setBattCompanyValue()
        {
            cbbBatt.Items.Add("1");
            cbbBatt.Items.Add("2");
            cbbBatt.Items.Add("3");
            cbbBatt.Items.Add("4");
            cbbCompany.Items.Add("1");
            cbbCompany.Items.Add("2");
            cbbCompany.Items.Add("3");
            cbbCompany.Items.Add("4");
            cbbCompany.Items.Add("5");
            cbbCompany.Items.Add("6");
        }

    }
}
