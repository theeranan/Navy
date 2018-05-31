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
    public partial class SearchNivyForm : Form
    {
        PersonDataSet.PersonNivyDataTable personNivyData;
        public PersonDataSet.PersonNivyRow personNivyRow;
        SearchPersonNivyInputControl2 inputSearch;
        DataCoreLibrary dcore;
        InputSearchPersonNivy tempInput;
        int count = -1;
        int itemsPerPage = Constants.countItemResult;
        int page = 1;
        int totalPage = -1;

        public SearchNivyForm()
        {
            InitializeComponent();
            tempInput = new InputSearchPersonNivy();
            inputSearch = new SearchPersonNivyInputControl2();
            inputSearch.Dock = DockStyle.Top;
            inputSearch.SearchButtonClick += new EventHandler(SearchPersonNivy_ButtonSubmitClick);
            groupBox1.Controls.Add(inputSearch);
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;
            pictureBox1.Visible = false;
        }

        public SearchNivyForm(string id13)
        {
            InitializeComponent();
            tempInput = new InputSearchPersonNivy();
            inputSearch = new SearchPersonNivyInputControl2();
            inputSearch.Dock = DockStyle.Top;
            inputSearch.SearchButtonClick += new EventHandler(SearchPersonNivy_ButtonSubmitClick);
            groupBox1.Controls.Add(inputSearch);
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;
            pictureBox1.Visible = false;

            try
            {
                Control[] c = (inputSearch.Controls.Find("textBoxID13", true));
                if (c.Length > 0)
                {
                    ((TextBox)c[0]).Text = id13;
                    //SearchPersonNivy_ButtonSubmitClick(null, null);
                    dcore = new DataCoreLibrary();
                    Search();
                    gvResult.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void EnableButtonPage()
        {
            if(page < totalPage)
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
            try
            {
                if (!tempInput.CheckSameValue(inputSearch.GetInput()))
                {
                    tempInput = inputSearch.GetInput();
                    personNivyData = dcore.GetSearchPersonNivyTemplate(tempInput, itemsPerPage, page, out count);
                    gvResult.DataSource = personNivyData;
                }
                else
                {
                    tempInput = inputSearch.GetInput();
                    personNivyData = dcore.GetSearchPersonNivyTemplate(tempInput, itemsPerPage, page, out count);
                    gvResult.DataSource = personNivyData;
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
                gvResult.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchPersonNivy_ButtonSubmitClick(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            pictureBox1.Visible = true;

            dcore = new DataCoreLibrary();
            if (checkBoxSearchNivyAll.Checked)
            {
                dcore = new DataCoreLibrary(System.Configuration.ConfigurationManager.ConnectionStrings["midb"].ConnectionString);
            }

            Search();
            gvResult.Focus();

            //if (backgroundWorker1.WorkerSupportsCancellation == true)
            //{
            //    // Cancel the asynchronous operation.
            //    backgroundWorker1.CancelAsync();
            //}
            pictureBox1.Visible = false;
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
                personNivyRow = personNivyData.FindByID13(gvResult.SelectedRows[0].Cells["ID13"].Value.ToString());
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
                gvResult.Focus();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            pictureBox1.Visible=true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
        }
    }
}
