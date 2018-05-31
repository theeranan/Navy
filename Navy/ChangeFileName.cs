using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Navy.Core;

namespace Navy
{
    public partial class ChangeFileName : Form
    {
        DataCoreLibrary dcore;
        public string[] files;
        public ChangeFileName()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();
            
        }
        protected void ChangeFileNameAndMoveLocation() {
            DataTable dt = null;
            int index = 0;

         
            files = Directory.GetFiles(@"D:\ร้อยเตรียม\3x5", "*.jpg", SearchOption.AllDirectories);
                    
                 
                    dt = dcore.GetSearchPerson("5", "0", "0", "");
                    foreach (DataRow dr in dt.Rows) {

                        File.Copy(files[index], @"D:\3.59.5\" + dr["navyid"].ToString()+ ".jpg", true);
                        index++;
                        
                    }
              
                MessageBox.Show("Cpmplete");
            
        }

      private void Change_Click(object sender, EventArgs e)
        {
            ChangeFileNameAndMoveLocation();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
