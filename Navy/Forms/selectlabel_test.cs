using Navy.Core;
using Navy.Data;
using Navy.Data.DataTemplate;
using Navy.MyControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Navy.Forms
{
    public partial class selectlabel_test : Form
    {
        DataCoreLibrary dcore;
        DataTable personTable;
        DataTable NlabelTable;
        DataTable SelectNlabelTable;
        DataCoreLibrary dcoreUpdateUsedPerson;
        DataTable NlabelNotInUnit;
        int count = -1;
        int itemsPerPage = Constants.countItemResult;
        int page = 1;
        decimal totalunit = 0;
        decimal totalnumber_label = 0;
        string[] arr;
        string[] arr_new;
        public selectlabel_test()
        {
            InitializeComponent();
            dcore = new DataCoreLibrary();
            DataControls.LoadComboBoxData(cmbunit, DataDefinition.GetUnitTab(), "UNITNAME", "REFNUM");
            cmbunit.SelectedValue = 0;
           
        }
        protected void UpdateNLabel() {
            string number_label = string.Empty;
            int checkcount = 0;
            int num=0;// เช็คหมายเลขฉลาก
            string ID=string.Empty;
           string Nlabel = string.Empty;
             dcoreUpdateUsedPerson = new DataCoreLibrary();
          
           // List<string> Nlabel = new List<string>();
                foreach(DataRow dr in personTable.Rows){

                    if (checkcount % totalnumber_label == 0)
                    {
                        number_label = arr_new[num];

                        ID = dr["NAVYID"].ToString();
                        Nlabel=number_label;
                        dcoreUpdateUsedPerson.UpdateNLabelPerson(ID, Nlabel);
                        num++;
                    }
                    else {
                        ID = dr["NAVYID"].ToString();
                        Nlabel=number_label;
                        dcoreUpdateUsedPerson.UpdateNLabelPerson(ID, Nlabel);
                    
                    }
                    checkcount++;
              
                }
        
        }
        protected int ConverValuetoInt(string txt) {

            try
            {
                return Convert.ToInt32(txt);

            }
            catch (Exception ex) {

                return 0;
            }
        
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
          
            string str = txtselect_number.Text;
            bool check = false;
            arr = new string[]{};
          
            int counts =0;
            arr = str.Trim().Split(' ');
            for (int i = 0; i < arr.Length;i++ )
            {
                if (arr[i].Trim() != "") {
                    
                    counts++;
                }

            }
            arr_new = new string[counts];
            counts = 0;
            
            string textlabel = string.Empty;
            string textNlabel = string.Empty;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j].Trim() != "")
                {
                    textlabel = arr[j];
                    NlabelNotInUnit  = dcore.GetNlabelNotInUnit(DataControls.GetSelectedValueComboBoxToString(cmbunit), out count);
                    if (NlabelNotInUnit.Rows.Count > 0) {
                        foreach (DataRow dr in NlabelNotInUnit.Rows) {

                            if (textlabel.Equals(dr["NLABEL"].ToString())) {
                                check = true;
                                textNlabel += textlabel+" ";
                               
                            }
                        }
                    
                    }
                   
                    arr_new[counts] = textlabel;
                    
                    counts++;
                }

            }
            if (check)
            {
                MessageBox.Show("ฉลากหมายเลข" + textNlabel + "ถูกใช้งานไปแล้ว");
              
            }else if (ConverValuetoInt(txtnumberlaber.Text) != counts && counts!=0)
            {

                MessageBox.Show("กรุณากรอกหมายเลขฉลากให้เท่ากับจำนวนฉลาก");
            }
            else if (txtnummerperlabel.Text == string.Empty)
            {
                MessageBox.Show("กรุณากรอกจำนวนคนต่อฉลาก");

            }
            else if (txtnumberlaber.Text == string.Empty)
            {
                MessageBox.Show("กรุณากรอกจำนวนฉลาก");

            }
            else if (txtselect_number.Text == string.Empty)
            {
                MessageBox.Show("กรุณากรอกหมายเลขฉลาก");

            }
           
            else {

                UpdateNLabel();
                GetData();
                MessageBox.Show("บันทึกข้อมูลสำเร็จ");
            }
            counts = 0;
           
           
           
        }
        protected void GetData() {

            string text = string.Empty;
            string select = string.Empty;
           
            personTable = dcore.GetTotalselectunit(DataControls.GetSelectedValueComboBoxToString(cmbunit), out count);

            NlabelTable = dcore.GetNlabelInUnit(DataControls.GetSelectedValueComboBoxToString(cmbunit), out count);
            SelectNlabelTable = dcore.GetNlabelInUnit("", out count);
        
            foreach (DataRow dr in SelectNlabelTable.Rows)
            {

                select = select + dr["NLABEL"].ToString() + " ";
            }
            lblselectol.Text = select;

            foreach (DataRow dr in NlabelTable.Rows)
            {


                text = text + dr["NLABEL"].ToString() + " ";

            }

            txtselect_number.Text = text;
            lbltotal.Text = personTable.Rows.Count.ToString();
            txtnummerperlabel.Text = string.Empty;
            txtnumberlaber.Text = string.Empty;
        }
        private void cmbunit_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetData();

        }
        private void txtnummerperlabel_TextChanged(object sender, EventArgs e)
        {
            if (lbltotal.Text != "" && txtnummerperlabel.Text != "")
            {
                totalunit = Convert.ToDecimal(lbltotal.Text);
                totalnumber_label = Convert.ToDecimal(txtnummerperlabel.Text);
                txtnumberlaber.Text = (Math.Ceiling(totalunit / totalnumber_label)).ToString();
            }
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการล้างล้างข้อมูลหมายเลขฉลากใช่หรือไม่", "ล้างข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dcoreUpdateUsedPerson = new DataCoreLibrary();
                dcoreUpdateUsedPerson.ClearNLabelPerson(DataControls.GetSelectedValueComboBoxToString(cmbunit));
                GetData();
                MessageBox.Show("ล้างข้อมูลสำเร็จ", "ล้างข้อมูล", MessageBoxButtons.OK);
             //   System.Windows.Forms.Application.Exit();
            }
            else
            {
                this.Activate();
            }   
           
        }
        private void btnclearall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการล้างล้างข้อมูลหมายเลขฉลากทั้งหมดใช่หรือไม่", "ล้างข้อมูลทั้งหมด", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dcoreUpdateUsedPerson = new DataCoreLibrary();
                dcoreUpdateUsedPerson.ClearAllNLabelPerson();
                GetData();
                MessageBox.Show("ล้างข้อมูลทั้งหมดสำเร็จ", "ล้างข้อมูลทั้งหมด", MessageBoxButtons.OK);
                //   System.Windows.Forms.Application.Exit();
            }
            else
            {
                this.Activate();
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>() { "John", "Anna", "Monica" };
            var result = String.Join(", ", names.ToArray());
        }

   
    }
}
