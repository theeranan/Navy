using Navy.Core;
using Navy.Data;
using Navy.Data.DataTemplate;
using Navy.MyControls;
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
    public partial class SearchNivyForm2 : Form
    {
        List<PersonNavy> personNavyData;
        public PersonNavy personSelected;
        SearchPersonNivyInputControl2 inputSearch;
        DataCoreLibrary dcore;
        InputSearchPersonNivy tempInput;
        int count = -1;
        int itemsPerPage = Constants.countItemResult;
        int page = 1;
        int totalPage = -1;

        public SearchNivyForm2()
        {
            InitializeComponent();
            tempInput = new InputSearchPersonNivy();
            inputSearch = new SearchPersonNivyInputControl2();
            inputSearch.Dock = DockStyle.Top;
            inputSearch.SearchButtonClick += new EventHandler(SearchPersonNivy_ButtonSubmitClick);
            groupBox1.Controls.Add(inputSearch);
            inputSearch.SetFocusID13();
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;
            pictureBox1.Visible = false;
        }

        public SearchNivyForm2(string id13)
        {
            InitializeComponent();
            tempInput = new InputSearchPersonNivy();
            inputSearch = new SearchPersonNivyInputControl2();
            inputSearch.Dock = DockStyle.Top;
            inputSearch.SearchButtonClick += new EventHandler(SearchPersonNivy_ButtonSubmitClick);
            groupBox1.Controls.Add(inputSearch);
            inputSearch.SetFocusID13();
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;
            pictureBox1.Visible = false;
            
            try
            {
                tempInput.id13 = id13;
                inputSearch.SetInput(tempInput);
                if (id13.Trim() != "")
                {
                    SearchPersonNivy_ButtonSubmitClick(inputSearch.GetButtonSearch(), null);
                }

                //Control[] c = (inputSearch.Controls.Find("textBoxID13", true));
                //if (c.Length > 0)
                //{
                //    ((TextBox)c[0]).Text = id13;

                //    SearchPersonNivy_ButtonSubmitClick(inputSearch.GetButtonSearch(), null);
                //    //dcore = new DataCoreLibrary(System.Configuration.ConfigurationManager.ConnectionStrings["midb"].ConnectionString);
                //    //Search();
                //    //gvResult.Focus();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void Search()
        {
            pictureBox1.Visible = true;
            try
            {
                tempInput = inputSearch.GetInput();
                if (checkBoxSearchNivyAll.Checked)
                {
                    personNavyData = dcore.GetSearchPersonNavy(tempInput, true, itemsPerPage, page, out count);
                }
                else
                {
                    personNavyData = dcore.GetSearchPersonNavy(tempInput, false, itemsPerPage, page, out count);
                }
                gvResult.DataSource = personNavyData;

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

                gvResult.ClearSelection();
                bool focus = gvResult.Focus();
                if (gvResult.Rows.Count > 0)
                {
                    gvResult.Rows[0].Cells[0].Selected = true;
                    gvResult.BeginEdit(true);
                    //gvResult.CurrentRow.Selected = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            pictureBox1.Visible = false;
        }

        private void SearchPersonNivy_ButtonSubmitClick(object sender, EventArgs e)
        {
            dcore = new DataCoreLibrary();
            dcore.ChangeDB("midb");
            Search();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            page = page <= 1 ? 1 : page - 1;
            Search();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            page = page >= totalPage ? totalPage : page + 1;
            Search();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                personSelected = personNavyData.First(p => p.pid == (gvResult.SelectedRows[0].Cells["PID"].Value.ToString()));
                this.Close();
            }
        }

        private void gvResult_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void gvResult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                //gvResult.Focus();
                //personNivyRow = personNivyData.FindByID13(gvResult.SelectedRows[0].Cells["ID13"].Value.ToString());
            }
        }

        private void gvResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(sender, e);
                e.Handled = true;
            }
        }

        private void gvResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSubmit_Click(sender, e);
        }

        private void SearchNivyForm2_Activated(object sender, EventArgs e)
        {
            if (gvResult.Rows.Count > 0)
            {
                gvResult.Focus();
            }
            else
            {
                inputSearch.SetFocusID13();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
