using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Navy.Core;

namespace Navy
{
    public partial class PersonRequestForm : Form
    {
        #region Field
        private RTCRepository rtcRepository = new RTCRepository();
        private Parameters.PersonRequest param;
        private PersonRequest personShortDetailData;

        private string navyid;
        #endregion

        #region Constructors

        public PersonRequestForm()
        {
            InitializeComponent();
        }

        public PersonRequestForm(string navyid)
        {
            InitializeComponent();

            this.navyid = navyid;
            personShortDetailData = Function.GetRTCRespository().GetPersonRequestDetail(navyid);
            InitialzeForm();
        }

        #endregion

        #region Methods
        private void InitialzeForm()
        {
            InitialControls();
            InitialValue();
        }

        private void InitialControls()
        {
            //Load person detail            
            personShortDetailView1.InitialValue(personShortDetailData);
            personShortDetailView1.Dock = DockStyle.Fill;

            //Load data into ComboBox
            if (cbbUnit.DataSource == null)
                Function.InitCBUnit(cbbUnit, personShortDetailData.request.unit);

            if (cbbRequester1.DataSource == null)
                Function.InitCBAskBy(cbbRequester1, String.IsNullOrWhiteSpace(personShortDetailData.request.askby) ? "" : personShortDetailData.request.askby.Substring(0, 2));

            //Load new copy data into ComboBox
            if (cbbUnit2.DataSource == null)
            {
                DataTable unit = new DataTable();                
                try
                {
                    unit = Function.GetUnitTab().Copy();
                    cbbUnit2.DataSource = unit;
                    cbbUnit2.DisplayMember = "UNITNAME";
                    cbbUnit2.ValueMember = "REFNUM";
                    cbbUnit2.AutoCompleteMode = AutoCompleteMode.Append;
                    cbbUnit2.AutoCompleteSource = AutoCompleteSource.ListItems;
                    if (personShortDetailData.person.unit3 == string.Empty)
                        cbbUnit2.SelectedIndex = -1;
                    else
                        cbbUnit2.SelectedValue = personShortDetailData.person.unit3;
                }
                catch (Exception)
                {
                    cbbUnit2.DataSource = null;
                }
            }
                
        }

        private void InitialValue()
        {
            //tbRequester2.Text = String.IsNullOrWhiteSpace(personShortDetailData.request.askby) ? "" : personShortDetailData.request.askby.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
            tbRequester2.Text = String.IsNullOrWhiteSpace(personShortDetailData.request.askby) ? "" : ((personShortDetailData.request.askby.Length > 2) ? personShortDetailData.request.askby.Remove(0, 3) : "");
            tbRemark.Text = personShortDetailData.request.remark;
            tbRemark2.Text = personShortDetailData.request.remark2;
            cbbNUM.SelectedIndex = cbbNUM.FindStringExact(personShortDetailData.request.num);
        }

        private string CheckRequireField()
        {
            if (cbbUnit.SelectedIndex < 0)
            { return "หน่วย"; }

            if (cbbRequester1.SelectedIndex < 0)
            { return "ผู้ขอ"; }

            if (cbbNUM.SelectedIndex < 0)
            { return "ลำดับ"; }

            return "";
        }

        private void UpdateValue()
        {
            param.navyid = this.navyid;
            param.askby = Convert.ToString(cbbRequester1.SelectedValue) + " " + Function.GetTextOrNull(tbRequester2.Text, "-");
            param.unit = Function.GetTextOrNull(Convert.ToString(cbbUnit.SelectedValue));
            param.num = Function.GetTextOrNull(Convert.ToString(cbbNUM.SelectedValue));
            param.remark = Function.GetTextOrNull(tbRemark.Text);
            param.remark2 = Function.GetTextOrNull(tbRemark2.Text);
            param.flag = "F";
            param.upddate = DateTime.Now;
            param.piority = "0";
            param.username = Function.GetTextOrNull(System.Environment.MachineName);
            param.updatecount = personShortDetailData.request.updatecount;
        }

        #endregion

        #region Event
        private void PersonRequestForm_Load(object sender, EventArgs e)
        {
            cbbUnit.Select();
        }

        private void PersonRequestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string chkControl = CheckRequireField();
            if (chkControl != "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูล (" + chkControl + ")");
            }
            else
            {
                UpdateValue();
                try
                {
                    bool isSuccess = rtcRepository.UpdatePersonRequest(personShortDetailData, param);
                    if (isSuccess == true)
                    {
                        MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                        //personShortDetailData = Function.GetRTCRespository().GetPersonRequestDetail(navyid);
                        this.Close();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitialzeForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ต้องการลบ การร้องขอนี้ ใช่หรือไม่", "ลบรายการ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {              
                try
                {
                    bool isSuccess = rtcRepository.DeletePersonRequest(personShortDetailData);
                    if (isSuccess == true)
                    {
                        MessageBox.Show("ลบข้อมูลเรียบร้อย");

                        personShortDetailData = Function.GetRTCRespository().GetPersonRequestDetail(navyid);
                        InitialzeForm();
                        cbbUnit.SelectedIndex = -1;
                        cbbRequester1.SelectedIndex = -1;
                    }
                    else
                    {
                        //MessageBox.Show("พบข้อผิดพลาด ในการลบข้อมูล");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void cbbRequester1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Function.InitCBRequestAskNUM(cbbNUM, Convert.ToString(cbbRequester1.SelectedValue), personShortDetailData.person.yearin);
        }

        private void cbbUnit_Enter(object sender, EventArgs e)
        {
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void tbRequester2_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((TextBox)sender).SelectAll(); });
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void tbRemark_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((TextBox)sender).SelectAll(); });
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void tbRemark2_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((TextBox)sender).SelectAll(); });
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }

        private void cbbUnit2_Enter(object sender, EventArgs e)
        {
            Function.SetKeyboardLayout(Function.GetInputLanguageByName("thai"));
        }
                
        private void cbbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                //this.SelectNextControl((Control)sender, true, true, true, true);
                cbbRequester1.Select();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cbbRequester1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                tbRequester2.Select();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tbRequester2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cbbNUM.Select();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control & e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void cbbNUM_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                tbRemark.Select();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tbRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                tbRemark2.Select();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control & e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void tbRemark2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                btnSubmit.Select();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control & e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void cbbUnit2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                btnSubmit2.Select();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control & e.KeyCode == Keys.A)
            {
                ((ComboBox)sender).SelectAll();
            }
        }

        private void tbRequester2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab))
            {
                ProcessKeyDown(e.KeyCode);
                //cbbNUM.Select();
            }
        }

        private bool ProcessKeyDown(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Up:
                    {
                        // act on up arrow
                        return true;
                    }
                case Keys.Down:
                    {
                        // act on down arrow
                        return true;
                    }
                case Keys.Left:
                    {
                        // act on left arrow
                        return true;
                    }
                case Keys.Right:
                    {
                        // act on right arrow
                        return true;
                    }
                case Keys.Tab:
                    {
                        // act on tab
                        return true;
                    }
            }
            return false;
        }

        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            string unit3 = "";
            if (cbbUnit2.SelectedIndex >= 0)
            {
                unit3 = Function.GetTextOrNull(Convert.ToString(cbbUnit2.SelectedValue));
            }

            try
            {
                bool isSuccess = rtcRepository.UpdatePersonUnit3(personShortDetailData.person.navyid, unit3);
                if (isSuccess == true)
                {
                    MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                    personShortDetailData = Function.GetRTCRespository().GetPersonRequestDetail(navyid);
                    InitialzeForm();
                    //this.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion


    }
}
