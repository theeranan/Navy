using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Forms;
using Navy.Core;

namespace Navy
{
    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();
            DBConnection.GetConStringFormFile();
        }

        private void settingDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDatabaseForm form = new SelectDatabaseForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void newPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewPersonOptionForm form = new AddNewPersonOptionForm();
            form.ShowDialog();

            if (form.hasValue)
            {
                string yearin = "";
                string armtown = "";
                DateTime regisDate = DateTime.MinValue;
                DateTime comeDate = DateTime.MinValue;
                string originId = "";

                yearin = form.yearin;
                armtown = form.armtown;
                regisDate = form.regisDate;
                comeDate = form.comeDate;
                originId = form.originId;

                AddNewPersonForm form2 = new AddNewPersonForm(form.yearin, form.armtown, form.regisDate, form.comeDate, form.originId);
                form2.MdiParent = this;
                form2.WindowState = FormWindowState.Maximized;
                //form2.StartPosition = FormStartPosition.CenterParent;                
                form2.Show();
            }
            else
            { }

        }

        private void dateFormatSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void searchPersonAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchNivyForm2 f = new SearchNivyForm2();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchPersonForm f = new SearchPersonForm();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void processCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessPersonCardForm f = new ProcessPersonCardForm();
            f.Show();
        }

        private void testPersonCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OCRForm f = new OCRForm();
            f.Show();
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateFolder f = new FormCreateFolder();
            f.Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm f = new AboutProgramForm();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void reportPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportAddNewPersonForm f = new Reports.ReportAddNewPersonForm();
            f.Show();
        }

        private void summaryNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportSummaryPersonForm f = new Reports.ReportSummaryPersonForm();
            f.Show();
        }

        private void DevideUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.DevideUnitForm f = new Reports.DevideUnitForm();
            f.Show();
        }
        private void PersonRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SearchPersonRequestForm f = new SearchPersonRequestForm();
            //f.MdiParent = this;
            //f.WindowState = FormWindowState.Maximized;
            //f.Show();
            PersonSearchForm personSearchForm = new PersonSearchForm(PersonRequestToolStripMenuItem.Text);
            personSearchForm.MdiParent = this;
            personSearchForm.WindowState = FormWindowState.Maximized;
            personSearchForm.Show();
        }

        private void personTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            SearchPersonTransferForm f = new SearchPersonTransferForm();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void addNLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectlabel_test f = new selectlabel_test();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void HistoryBooktoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportHistorybook f = new Reports.ReportHistorybook();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            People.PeopleForm f = new People.PeopleForm("new","");
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

       

        private void SearchToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            People.navy_search f = new People.navy_search("","","","","edit");
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

       

        private void ReportPeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ReportFromPeople f = new Reports.ReportFromPeople();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
       

        private void AddressMore_Click(object sender, EventArgs e)
        {
            Reports.ReportAddressMore f = new Reports.ReportAddressMore();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();

        }

        private void tspreaddressmore_Click(object sender, EventArgs e)
        {
            People.PreAdderss f = new People.PreAdderss();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void toolSubUnit_Click(object sender, EventArgs e)
        {
            //People.AddSubUnit f = new People.AddSubUnit();
            //f.MdiParent = this;
            //f.WindowState = FormWindowState.Maximized;
            //f.Show();
        }

        private void Sclick(object sender, EventArgs e)
        {

            Reports.ReportSumpeople f = new Reports.ReportSumpeople();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void ChangeFileName(object sender, EventArgs e)
        {
            ChangeFileName f = new ChangeFileName();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void ReportEducateAndOccup_Click(object sender, EventArgs e)
        {
            Reports.ReportEducateAndOccup f = new Reports.ReportEducateAndOccup();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void Indictment_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndictmentForm f = new IndictmentForm();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Normal;
            f.Show();
        }

        private void TelephoneNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelephoneNumber_Collection f = new TelephoneNumber_Collection();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void AddscoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScorePerson f = new ScorePerson();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }


        private void ScancardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scancardsetting s = new Scancardsetting();
            s.Show();
        }

        private void AddNewPersonScanCardMode_Click(object sender, EventArgs e)
        {
            AddNewPersonOptionForm form = new AddNewPersonOptionForm();
            form.ShowDialog();

            if (form.hasValue)
            {
                string yearin = "";
                string armtown = "";
                DateTime regisDate = DateTime.MinValue;
                DateTime comeDate = DateTime.MinValue;
                string originId = "";

                yearin = form.yearin;
                armtown = form.armtown;
                regisDate = form.regisDate;
                comeDate = form.comeDate;
                originId = form.originId;

                AddNewPersonForm form2 = new AddNewPersonForm(form.yearin, form.armtown, form.regisDate, form.comeDate, form.originId,"ScanCard");
                //form2.MdiParent = this;
                //form2.WindowState = FormWindowState.Maximized;
                //form2.StartPosition = FormStartPosition.CenterParent;                
                form2.Show();
            }
            else
            { }
        }

        private void CheckRuncodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
             RuncodeCheckForm r = new RuncodeCheckForm();
            r.MdiParent = this;
            r.WindowState = FormWindowState.Maximized;
            r.StartPosition = FormStartPosition.CenterParent;                
            r.Show();
        }

        private void LostInformation_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LostInformation l = new LostInformation();
            l.StartPosition = FormStartPosition.CenterParent;
            l.Show();
        }

        private void AddkptclassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm l = new AddForm();
            l.StartPosition = FormStartPosition.CenterParent;
            l.Show();
        }

        private void AddictiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm l = new AddForm("addictive");
            l.StartPosition = FormStartPosition.CenterParent;
            l.Show();
        }

    }
}
