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
    public partial class RuncodeCheckForm : Form
    {
        public RuncodeCheckForm()
        {
            InitializeComponent();
        }

        private void RuncodeCheckForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ยังทำไม่เสร็จ");
        }
    }
}
