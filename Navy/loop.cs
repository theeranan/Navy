using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Navy
{
    public partial class loop : Form
    {
       
        public loop()
        {
            InitializeComponent();
            navyloop();
        }
        protected void navyloop() {

            for (int day = 1; day <= 365; day++) {

                if (day % 30 != 0)
                {


                }
                else {
                    day += 10;
                }
            
            }
        
        }
    }
}
