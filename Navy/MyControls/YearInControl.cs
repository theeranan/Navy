using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navy.MyControls
{
    public partial class YearInControl : UserControl
    {        
        public YearInControl()
        {
            InitializeComponent();
        }

        public MaskedTextBox GetMaskedTextBoxYearIn()
        {
            return this.mtxtYearin;
        }

        private void mtxtYearin_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((MaskedTextBox)sender).SelectAll(); });
            Navy.Core.Function.SetKeyboardLayout(Navy.Core.Function.GetInputLanguageByName("en"));
        }

        private void mtxtYearin_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //MessageBox.Show("Please input Number Only!!");
        }
    }
}
