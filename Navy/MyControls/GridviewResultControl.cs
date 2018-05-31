using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Core;

namespace Navy.MyControls
{
    public partial class GridviewResultControl : UserControl
    {
        public int count = -1;
        public int itemsPerPage = Navy.Core.Constants.countItemResult;
        public int page = 1;
        public int totalPage = -1;
        public bool EnablePagingData { get; set; }
        public bool ExternalDataSource { get; set; }
        enum PagingDataSource { NotPagingInternalDataSource, NotPagingExternalDataSource, PagingInternalDataSource, PagingExternalDataSource }

        DataTable _DataSource = new DataTable();

        public DataTable DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
            }
        }

        public DataGridViewColumnCollection Columns
        {
            get { return this.gvResult.Columns; }
        }

        public DataGridView GvResult
        {
            get { return this.gvResult; }
        }

        public Label LbCountRecord
        {
            get { return this.labelCountSearchRecord; }
        }

        public Label LbTimeExecute
        {
            get { return this.labelTimeExecute; }
        }

        public Button ButtonPrevPage
        {
            get { return btnPrevPage; }
        }

        public Button ButtonNextPage
        {
            get { return btnNextPage; }
        }

        public event EventHandler ButtonPrevPageClick;
        public event EventHandler ButtonNextPageClick;

        public GridviewResultControl()
        {
            InitializeComponent();
            EnablePagingData = false;
            ExternalDataSource = false;
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;
        }

        #region Data Manage
        public void BindDataToGridView(object dt)
        {
            ExternalDataSource = true;
            //DataSource = (DataTable)dt;
            gvResult.DataSource = dt;
        }

        public void BindDataPaging(int pageNumber)
        {
            if (!ExternalDataSource)
            {
                gvResult.DataSource = GetDataToShow(pageNumber);
                ConfigButtonPage();
            }            
        }

        private DataTable GetDataToShow(int pageNumber)
        {
            DataTable dt = new DataTable();
            int startIndex = itemsPerPage * (pageNumber - 1);
            var result = DataSource.AsEnumerable().Where((s, k) => (k >= startIndex && k < (startIndex + itemsPerPage)));

            foreach (DataColumn colunm in DataSource.Columns)
            {
                dt.Columns.Add(colunm.ColumnName);
            }

            foreach (var item in result)
            {
                dt.ImportRow(item);
            }

            labelPaging.Text = string.Format("{0}/{1}", pageNumber, (DataSource.Rows.Count / itemsPerPage) + 1);
            count = DataSource.Rows.Count;
            return dt;
        }
        #endregion

        #region Control Event
        public void CalculatePaging()
        {
            if (EnablePagingData)
            {
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
            }
            else
            {
                totalPage = 1;
                labelCountSearchRecord.Text = Convert.ToString(count) + " Record(s)";
                labelPaging.Text = "1";
            }
        }

        public void ConfigButtonPage()
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

            //btnSubmit.Enabled = count > 0 ? true : false;
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            page = page <= 1 ? 1 : page - 1;
            if (EnablePagingData && ExternalDataSource)
            {
                if (this.ButtonPrevPageClick != null)
                    this.ButtonPrevPageClick(this, e);
            }
            else
            {
                BindDataPaging(page);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            page = page >= totalPage ? totalPage : page + 1;
            if (EnablePagingData && ExternalDataSource)
            {
                if (this.ButtonNextPageClick != null)
                    this.ButtonNextPageClick(this, e);
            }
            else 
            {
                BindDataPaging(page);
            }
        }
        #endregion

    }
}
