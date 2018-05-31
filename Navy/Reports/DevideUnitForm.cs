using Navy.Core;
using Navy.Data;
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

namespace Navy.Reports
{
    public partial class DevideUnitForm : Form
    {
        ReportCoreLibrary rcore;
        QueryString.Search query = new QueryString.Search();
        int personPerNlabel = 150;
        int allNLabel = 0;
        Dicccccc nnn;
       
        public DevideUnitForm()
        {
            InitializeComponent();
            rcore = new ReportCoreLibrary();
            mtxtYearin.Text = "1/59";//rcore.dcore.GetMaxYearin();
            nnn = new Dicccccc();
        }

        private void ShowData()
        {
              DataTable dt = new DataTable();
            dt = rcore.dcore.getDataTablePrototype(query.countUNIT3(mtxtYearin.Text));
            dt.Columns.Add(new DataColumn("count_nlabel_per_unit", typeof(int)));
            dt.Columns.Add(new DataColumn("count_person_per_nlabel", typeof(int)));

            int count = dt.Rows.Count;
            if (count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int countPersonUnit = 0;
                    countPersonUnit = Convert.ToInt32(dr["count_person_per_unit"]);

                    int countNLabel = 0;
                    countNLabel = (int)(Math.Ceiling((float)countPersonUnit / (float)personPerNlabel));

                    dr["count_nlabel_per_unit"] = countNLabel;
                    dr["count_person_per_nlabel"] = countPersonUnit / countNLabel;
                    allNLabel += countNLabel;
                }
               
                nnn = new Dicccccc(allNLabel);                
            }
            gvResult.DataSource = dt;
        }

        private void AssignNLabel()
        {
            if (gvResult.Columns["nlabel"] != null)
            {
                gvResult.Columns.Add("nlabel", "nlabel");
            }

            foreach (DataGridViewRow dr in gvResult.Rows)
            {
                int countPersonUnit = (int)(dr.Cells["count_person_per_unit"].Value);
                int countNLabel = (int)(dr.Cells["count_nlabel_per_unit"].Value);
                int countPersonPerNlabel = (int)(dr.Cells["count_person_per_nlabel"].Value);


                int i = 1;
                while (i <= countNLabel)
                {


                    i++;
                }

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnCreateLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            rcore.ShowReportDevideUnitPersonList(mtxtYearin.Text);
        }

        public class Dicccccc
        {
            public class ddddd
            {
                public int nlabel;
                public bool used;

                public ddddd()
                {
                    nlabel = 0;
                    used = false;
                }

                public ddddd(int label, bool used)
                {
                    nlabel = label;
                    used = false;
                }
            }

            public List<ddddd> nlabel;

            public Dicccccc()
            {
                nlabel = new List<ddddd>();
            }

            public Dicccccc(int countNLabel)
            {
                nlabel = new List<ddddd>();
                for (int i = 0; i < countNLabel; i++)
                {
                    nlabel.Add(new ddddd(i + 1, false));
                }
                shuffle();
            }

            public void shuffle()
            {
                nlabel = nlabel.OrderBy(x => Guid.NewGuid()).ToList<ddddd>();
            }
        }



        
    }
}
