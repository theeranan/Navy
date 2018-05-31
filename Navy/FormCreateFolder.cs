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
using Navy.Core;

namespace Navy
{
    public partial class FormCreateFolder : Form
    {
        string path;
        int newFolderCreated = 0;
        public FormCreateFolder()
        {
            InitializeComponent();
            path = Path.GetFullPath(System.Configuration.ConfigurationManager.AppSettings["PhotoPath_personcard"] + "\\preprocess");
            labelPathEx.Text = path + "\\พิษณุโลก_38";
            textBox1.Text = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = Path.GetFullPath(folderBrowserDialog1.SelectedPath);
                labelPathEx.Text = path + "\\พิษณุโลก_38";
                textBox1.Text = path ;
            }
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            string newFolder = "";
            newFolderCreated = 0;
            DataTable dt = DataDefinition.GetArmtownTab();

            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    newFolder = path + "\\" + dr["ARMNAME"].ToString() + "_" + dr["ARMID"].ToString().Substring(0, 2);
                    if (!System.IO.Directory.Exists(newFolder))
                    {
                        System.IO.Directory.CreateDirectory(newFolder);
                        newFolderCreated += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR at [" + newFolder + "] .. " + ex.Message);
            }
        }

    }
}
