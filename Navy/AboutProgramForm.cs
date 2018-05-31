using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navy
{
    public partial class AboutProgramForm : Form
    {
        public AboutProgramForm()
        {
            InitializeComponent();

            lbAppName.Text = Application.ProductName + " ©";
            lbVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();//Application.ProductVersion;
            lbUpdate.Text = Application.CompanyName;

            string text = "";
            try
            {
                text = File.ReadAllText(@"changelog.txt", UTF8Encoding.UTF8);
            }
            catch(Exception ex) 
            {
                text = ex.Message;
            }
            richTextBox1.Text = text;
        }
    }
}
