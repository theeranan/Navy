using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Navy.View;
using Navy.Core;


namespace Navy
{
    public partial class PersonSearchForm : Form
    {
        private PersonSearchBoxView personSearchBox;
        private List<Person> listPerson;
        private string navyid;

        public PersonSearchForm()
        {
            InitializeComponent();
        }

        public PersonSearchForm(string taskHeader)
        {
            InitializeComponent();

            this.Text = taskHeader;
            InitialForm();
        }

        private void InitialForm()
        {            
            //Initial SearchBox
            personSearchBox = new PersonSearchBoxView();
            personSearchBox.SearchButtonClick += new EventHandler(memberSearchBox_SearchButtonClick);
            personSearchBox.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(personSearchBox);

        }

        private void memberSearchBox_SearchButtonClick(object sender, EventArgs e)
        {
            listPerson = new List<Person>();
            listPerson = Function.GetRTCRespository().SearchPerson(personSearchBox.GetSearchParameter());
            gvListMember.DataSource = listPerson;
            lblStatus.Text = listPerson.Count.ToString() + " records";

            gvListMember.Columns[0].Visible = false;
            gvListMember.Focus();
        }

        private void splitContainer_SizeChanged(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = 200;
        }

        private void gvListMember_KeyDown(object sender, KeyEventArgs e)
        {
            // CTRL + Enter
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                DisplayPersonRequestForm(navyid);

                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //btnRequest.Focus();
                DisplayPersonRequestForm(navyid);

                e.Handled = true;
            }

            ShortcutToInput(e);
        }

        private void gvListMember_SelectionChanged(object sender, EventArgs e)
        {
            int index;

            foreach (DataGridViewRow row in gvListMember.SelectedRows)
            {
                navyid = row.Cells["navyid"].Value.ToString();
                index = listPerson.FindIndex(x => x.navyid == navyid);
            }

        }
        
        private void gvListMember_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = gvListMember["navyid", e.RowIndex].Value.ToString(); //NavyID
                DisplayPersonRequestForm(id);
            }
        }

        private void btnMemberCodeHistory_Click(object sender, EventArgs e)
        {
            ChangeMemberCodeForm changeMemberCodeForm;
            changeMemberCodeForm = new ChangeMemberCodeForm(navyid);
            changeMemberCodeForm.StartPosition = FormStartPosition.CenterParent;
            changeMemberCodeForm.ShowDialog();

        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            DisplayPersonRequestForm(navyid);
        }

        private void DisplayPersonRequestForm(string navyid)
        {
            try
            {
                PersonRequestForm personRequestForm = new PersonRequestForm(navyid);
                personRequestForm.StartPosition = FormStartPosition.CenterParent;
                personRequestForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShortcutToInput(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                try
                {
                    Panel p = (Panel)this.Controls.Find("Panel1", true).FirstOrDefault();
                    MaskedTextBox t = (MaskedTextBox)p.Controls.Find("txtYearin", true).FirstOrDefault();
                    e.Handled = true;
                    t.Select();
                }
                catch { }
            }
            else if (e.KeyCode == Keys.F2)
            {
                // txtID8.Select();
                try
                {
                    Panel p = (Panel)this.Controls.Find("Panel1", true).FirstOrDefault();
                    MaskedTextBox t = (MaskedTextBox)p.Controls.Find("txtID8", true).FirstOrDefault();
                    e.Handled = true;
                    t.Select();
                }
                catch { }
            }
            else if (e.KeyCode == Keys.F3)
            {
                // txtName.Select();
                try
                {
                    Panel p = (Panel)this.Controls.Find("Panel1", true).FirstOrDefault();
                    TextBox t = (TextBox)p.Controls.Find("txtName", true).FirstOrDefault();
                    e.Handled = true;
                    t.Select();
                }
                catch { }
            }
            else if (e.KeyCode == Keys.F4)
            {
                // txtSName.Select();
                try
                {
                    Panel p = (Panel)this.Controls.Find("Panel1", true).FirstOrDefault();
                    TextBox t = (TextBox)p.Controls.Find("txtSName", true).FirstOrDefault();
                    e.Handled = true;
                    t.Select();
                }
                catch { }
            }
        }
    }
}
