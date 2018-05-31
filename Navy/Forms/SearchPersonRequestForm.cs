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
    public partial class SearchPersonRequestForm : Form
    {
        PersonRequestDataSet.PersonDataTable pTable ;
        PersonRequestDataSet.PersonRequestDataTable prTable ;
        BindingSource soucre = new BindingSource();

        DataCoreLibrary dcore;
        ReportCoreLibrary rcore;
        ParamSearchPerson paramSearch;
        int count = 0;
        public SearchPersonRequestForm()
        {
            InitializeComponent();
            AddEnterKeyDown();

            rbAddNew.Checked = true;
            rbEditOrDelete.Checked = false;
            paramSearch = new ParamSearchPerson();
            pTable = new PersonRequestDataSet.PersonDataTable();
            prTable = new PersonRequestDataSet.PersonRequestDataTable();
            dcore = new DataCoreLibrary();
            rcore = new ReportCoreLibrary();
            mtxtYearin.Text = dcore.GetMaxYearin();
        }

        private void Search()
        {            
            try
            {
                ParamSearchPerson param = new ParamSearchPerson();
                param.name = textBoxName.Text;
                param.sname = textBoxSname.Text;
                param.id8 = mTextBoxID8.Text;
                param.yearin = mtxtYearin.Text;

                gvResult.Columns.Clear();
                if (rbAddNew.Checked)
                {
                    pTable = dcore.GetSearchPersonForRequest(param);
                    setDataSource(pTable);
                    gvResult.DataSource = soucre;
                    gvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    try
                    {
                        gvResult.Columns["navyid"].Visible = false;
                        gvResult.Columns["oldyearin"].Visible = false;
                    }
                    catch { }
                    count = pTable.Rows.Count;
                }
                else if (rbEditOrDelete.Checked)
                {
                    prTable = dcore.GetSearchRequest(param, QueryString.Search.RequestPersonFilter.All);                    
                    setDataSource(prTable);
                    gvResult.DataSource = soucre;
                    gvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    try
                    {
                        gvResult.Columns["navyid"].Visible = false;
                        gvResult.Columns["unit"].Visible = false;
                        gvResult.Columns["num"].Visible = false;
                        gvResult.Columns["oldyearin"].Visible = false;
                        gvResult.Columns["updatecount"].Visible = false;
                    }
                    catch { }
                    count = prTable.Rows.Count;
                }
                else if(rbSorting.Checked)
                {
                    prTable = dcore.GetSearchRequest(param, QueryString.Search.RequestPersonFilter.All);
                    //gvResult.DataSource = prTable;
                    setDataSource(prTable);
                    gvResult.DataSource = soucre;
                    gvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    try
                    {
                        gvResult.Columns["navyid"].Visible = false;
                        gvResult.Columns["unit"].Visible = false;
                        gvResult.Columns["oldyearin"].Visible = false;
                        gvResult.Columns["updatecount"].Visible = false;
                    }
                    catch { }
                    count = prTable.Rows.Count;
                }
                toolStripStatusLabel1.Text = Convert.ToString(count) + " Record(s)";
                gvResult.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal delegate void SetDataSourceDelegate(object table);
        private void setDataSource(object table)
        {
            // Invoke method if required:
            if (this.InvokeRequired)
            {
                this.Invoke(new SetDataSourceDelegate(setDataSource), table);
            }
            else
            {
                soucre.DataSource = table;
                toolStripProgressBar1.Visible = false;
            }
        }

        private void EditNUM(string num)
        {
            PersonRequestEditNUMForm f = new PersonRequestEditNUMForm(num);
            f.ShowDialog();

            if (f.submitValue)
            {
                Navy.Core.PersonRequest pr = new Navy.Core.PersonRequest();
                pr.person.navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();
                pr.person.yearin = gvResult.SelectedRows[0].Cells["yearin"].Value.ToString();
                pr.person.name = gvResult.SelectedRows[0].Cells["name"].Value.ToString();
                pr.person.sname = gvResult.SelectedRows[0].Cells["sname"].Value.ToString();
                pr.person.id8 = gvResult.SelectedRows[0].Cells["id8"].Value.ToString();
                pr.request.navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString(); //for edit mode

                ParamPersonRequest param = new ParamPersonRequest();
                param.navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();
                param.unit = gvResult.SelectedRows[0].Cells["unit"].Value.ToString();
                param.askby = gvResult.SelectedRows[0].Cells["askby"].Value.ToString();
                param.num = num;
                param.remark = gvResult.SelectedRows[0].Cells["remark"].Value.ToString();
                param.remark2 = gvResult.SelectedRows[0].Cells["remark2"].Value.ToString();
                param.flag = "F";
                param.piority = "0";
                param.username = Environment.MachineName;
                param.updatecount = (Convert.ToInt16(gvResult.SelectedRows[0].Cells["updatecount"].Value) + 1);

                try
                {
                    bool isSuccess = dcore.UpdateRequest(pr, param);
                    if (isSuccess)
                    {
                        //Data.PersonRequestDataSet.PersonRequestDataTable listReq = dcore.GetRequestNUMHigher(param.askby, param.num);
                        //listReq = listReq.Select("").CopyToDataTable;

                        //isSuccess = dcore.ReOrderNUMRequest(listReq, param);
                        if (isSuccess)
                        {
                            MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                            //this.Close();
                        }
                        else
                        {
                            MessageBox.Show("พบข้อผิดพลาดในการแก้ไขข้อมูล การแทรกลำดับ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("แก้ไขข้อมูลไม่สำเร็จ");
                        //this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dcore = new DataCoreLibrary();
            //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Search));
            //thread.Start();
            Search();
            //gvResult.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                try
                {
                    string navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();
                    if (rbAddNew.Checked)
                    {
                        PersonRequestForm f = new PersonRequestForm(navyid);
                        f.ShowDialog();
                    }
                    else if (rbEditOrDelete.Checked)
                    {
                        string askby = gvResult.SelectedRows[0].Cells["askby"].Value.ToString();
                        string unit = gvResult.SelectedRows[0].Cells["unit"].Value.ToString();
                        PersonRequestForm f = new PersonRequestForm(navyid, askby, unit);
                        f.ShowDialog();
                    }
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
                if (MessageBox.Show("ต้องการลบข้อมูล การร้องขอนี้ ใช่หรือไม่", "ลบข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();
                        string askby = gvResult.SelectedRows[0].Cells["askby"].Value.ToString();
                        string unit = gvResult.SelectedRows[0].Cells["unit"].Value.ToString();

                        if (dcore.DeletePersonRequest(navyid,askby,unit))
                        {
                            gvResult.Rows.Remove(gvResult.SelectedRows[0]);
                            MessageBox.Show("ลบข้อมูลเรียบร้อย");
                            Search();
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
            if (gvResult.SelectedRows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (rbSorting.Checked)
                    {
                        string num = gvResult.SelectedRows[0].Cells["num"].Value.ToString();
                        EditNUM(num);                        
                    }
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    btnSubmit_Click(sender, e);
                }

                if (e.KeyCode == Keys.Delete)
                {

                }
            }
        }

        private void gvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            //{
            //        DataGridViewCell cell = gvResult["num", e.RowIndex];
            //        gvResult.CurrentCell = cell;
            //        gvResult.BeginEdit(true);                
            //}
        }

        private void gvResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (rbSorting.Checked)
            {
                string num = gvResult.SelectedRows[0].Cells["num"].Value.ToString();
                EditNUM(num);
            }
            else
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                object dataSource;                
                if (gvResult.DataSource != null)
                {
                    dataSource = gvResult.DataSource;
                    //rcore.ShowReportRequestPerson(dataSource, reportType);
                }
                else
                {
                    ParamSearchPerson param = new ParamSearchPerson();
                    param.name = textBoxName.Text;
                    param.sname = textBoxSname.Text;
                    param.id8 = mTextBoxID8.Text;
                    param.yearin = mtxtYearin.Text;
                    //rcore.ShowReportRequestPerson(param, reportType);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("พบข้อผิดพลาดในการเรียกดูข้อมูล .. " + ex.Message);
            }
        }

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
            textBoxName.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxSname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
        }
        #endregion


    }
}
