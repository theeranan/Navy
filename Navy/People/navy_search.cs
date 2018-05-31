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

namespace Navy.People
{
    public partial class navy_search : Form
    {
      
        DataCoreLibrary dcore;
        public string id13, navyid;
        public string mode_search=string.Empty;
        public navy_search(string id13, string name, string sname, string status,string mode)
        {
            dcore =   new DataCoreLibrary();
            InitializeComponent();
            DataControls.LoadComboBoxData(cmbselectaddress, DataDefinition.GetUnitTab(), "unitname", "REFNUM");
            if (!string.IsNullOrEmpty(txtid13.Text.Trim()))
            {
                id13 = txtid13.Text.Trim();
            }
            else if (!string.IsNullOrEmpty(id13))
            {

                txtid13.Text = id13;
            }
           
            if (!string.IsNullOrEmpty(txtname.Text.Trim()))
            {
                name = txtname.Text.Trim();
            }
            else if (!string.IsNullOrEmpty(name))
            {

                txtname.Text = name;
            }
            if (!string.IsNullOrEmpty(txtlname.Text.Trim()))
            {
                sname = txtlname.Text.Trim();
            }
            else if (!string.IsNullOrEmpty(sname))
            {

                txtlname.Text = sname;
            }
            mode_search = mode;
            
            GetData(id13, name, sname, status);
        }
        #region GridControl
        private void grdData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //var dataIndexNo = grdData.Rows[e.RowIndex].Index.ToString();

            //if (grdData.Rows.Count > 0)
            //{
            //    if (mode_search == "new" || mode_search == "out")
            //    {
            //        id13 = grdData.Rows[e.RowIndex].Cells["id13"].Value.ToString();
            //        navyid = grdData.Rows[e.RowIndex].Cells["navyid"].Value.ToString();
            //        this.Close();
            //    }
            //    else {
            //        id13 = grdData.Rows[e.RowIndex].Cells["id13"].Value.ToString();

            //            People.PeopleForm f = new People.PeopleForm("edit", id13);
            //            f.StartPosition = FormStartPosition.CenterParent;
            //            f.ShowDialog();


            //    }
            //}
        }
        private void grdData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataIndexNo = grdData.Rows[e.RowIndex].Index.ToString();

            if (grdData.Rows.Count > 0)
            {
                if (mode_search == "new" )
                {
                    id13 = grdData.Rows[e.RowIndex].Cells["id13"].Value.ToString();
                    navyid = grdData.Rows[e.RowIndex].Cells["navyid"].Value.ToString();
                    this.Close();
                }
                else
                {
                    id13 = grdData.Rows[e.RowIndex].Cells["id13"].Value.ToString();
                    if (!grdData.Rows[e.RowIndex].Cells["StatusName"].Value.ToString().Equals("ยังไม่ย้ายเข้า"))
                    {
                        People.PeopleForm f = new People.PeopleForm("edit", id13);
                        f.StartPosition = FormStartPosition.CenterParent;
                        f.ShowDialog();
                    }
                    else {

                        MessageBox.Show("ยังไม่มีข้อมูลย้ายเข้า");
                    
                    }


                }
            }
        }
        #endregion
        #region Showdata
        public void GetData(string id13, string name, string sname, string status)
        {

            
            if (string.IsNullOrEmpty(id13) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(sname) && string.IsNullOrEmpty(status)
                && string.IsNullOrEmpty(txtbook_number.Text) && string.IsNullOrEmpty(txtrank.Text) && mtxtYearin.Text.Equals(" /")&&!chkmove_in.Checked&&string.IsNullOrEmpty(DataControls.GetSelectedValueComboBoxToString(cmbselectaddress)))
            {
                //    grdData.DataSource = dcore.GetSearchPerson(id13, name, sname, status, mode_search);
            }
            else
            {

                switch (mode_search)
                {
                    case "new":

                      //  grdData.DataSource = dcore.GetSearchPerson(id13, name, sname, status, mode_search);
                        grdData.DataSource = dcore.GetSearchListPreAddressmore(txtname.Text, txtlname.Text, "", txtbook_number.Text, txtrank.Text, id13, mtxtYearin.Text,chkmove_in.Checked,DataControls.GetSelectedValueComboBoxToString(cmbselectaddress));
                        lblcount.Text = string.Format("{0} {1}", grdData.RowCount, "Record");
                        break;
                    case "edit":
                        //  if (!(string.IsNullOrEmpty(id13) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(sname)))
                        //   {
                     //   grdData.DataSource = dcore.GetSearchPerson(id13, name, sname, status, mode_search);
                        //   }
                        grdData.DataSource = dcore.GetSearchListPreAddressmore(txtname.Text, txtlname.Text, "", txtbook_number.Text, txtrank.Text, id13, mtxtYearin.Text, chkmove_in.Checked, DataControls.GetSelectedValueComboBoxToString(cmbselectaddress));
                        lblcount.Text = string.Format("{0:0,0} {1}", grdData.RowCount, "Record");
                        break;
                



                }
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("Bookman Old Style", 8, FontStyle.Bold);
                grdData.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                grdData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                grdData.Columns[0].HeaderText = "ชื่อ";
                grdData.Columns[1].HeaderText = "สกุล";
                grdData.Columns[2].HeaderText = "NAVYID";
                grdData.Columns[3].HeaderText = "ผลัด";
                grdData.Columns[4].HeaderText = "ทะเบียน";
                grdData.Columns[5].HeaderText = "หน่วย";
                grdData.Columns[6].HeaderText = "สถานะ";
                grdData.Columns[7].HeaderText = "ครั้งที่พิมพ์";
                grdData.Columns[8].HeaderText = "ID13";
                grdData.Columns[9].HeaderText = "เล่มที่";
                grdData.Columns[10].HeaderText = "ลำดับที่";
                //if (grdData.Rows.Count == 1 && (mode_search == "new" || mode_search == "out"))
                //{

                //    MessageBox.Show("ไม่มีข้อมูล");
                //    this.Close();
                //}

            }
            txtname.Focus();
            mtxtYearin.SelectAll();
            txtname.SelectAll();
            txtlname.SelectAll();
            txtid13.SelectAll();
            txtrank.SelectAll();
            txtbook_number.SelectAll();


        }
        #endregion
        #region Control
        private void btnsearch_Click(object sender, EventArgs e)
        {
            GetData(txtid13.Text.Trim(), txtname.Text.Trim(), txtlname.Text.Trim(), "");
        }
        private void txtid13_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }     
        #endregion     

        private void chkmove_in_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmove_in.Checked)
            {


            }
            else { 
            
            
            }
        }

        private void txtrank_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
