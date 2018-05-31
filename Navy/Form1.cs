using System;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Navy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateValue();
        }

        private void UpdateValue()
        {
            labelCulture.Text = Thread.CurrentThread.CurrentCulture.DisplayName
                + ", " + Thread.CurrentThread.CurrentCulture.EnglishName
                + ", " + Thread.CurrentThread.CurrentCulture.Name
                + ", " + Thread.CurrentThread.CurrentCulture.NativeName
                + ", " + Thread.CurrentThread.CurrentCulture.ThreeLetterISOLanguageName
                + ", " + Thread.CurrentThread.CurrentCulture.ThreeLetterWindowsLanguageName
                + ", " + Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName
                + " , datetime format [" + Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern.ToString() + "]";
            labelCultureUI.Text = Thread.CurrentThread.CurrentUICulture.Name
                + " , datetime format [" + Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern.ToString() + "]";

            labelDTpickerValue.Text = dateTimePicker1.Value.ToString();
            datetimepickerformat.Text = dateTimePicker1.Format.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Now;
            DateTime dd1 = new DateTime(2558, 10, 6, new System.Globalization.ThaiBuddhistCalendar());
            DateTime dd2 = new DateTime(2558, 10, 6);

            string s1 = dd1.Date.ToString("d MMM yyyy",new System.Globalization.CultureInfo("th-TH"));
            string s2 = dd1.Date.ToString("d MMM yyyy", new System.Globalization.CultureInfo("en-US"));
            string s3 = dd1.Date.ToString("d MMM yyyy");
            string ss1 = dd2.Date.ToString("d MMM yyyy", new System.Globalization.CultureInfo("th-TH"));
            string ss2 = dd2.Date.ToString("d MMM yyyy", new System.Globalization.CultureInfo("en-US"));
            string ss3 = dd2.Date.ToString("d MMM yyyy");

            string aaa = dateTimePicker1.Value.ToString("d MMMM yyyy HH:mm:ss",new System.Globalization.CultureInfo("en-US"));
            MessageBox.Show(aaa);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture.Name == Core.Constants.string_cultureTH)
            {
                string aaa = dateTimePicker1.Value.ToUniversalTime().ToString();
                MessageBox.Show(aaa);
            }
            else
            {
                //btnChangeCultureTH_Click(sender, e);
            }
        }

        private void btnChangeCultureTH_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            UpdateValue();
        }

        private void btnChangeCultureUS_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            UpdateValue();
        }

        private void btnChangeCultureUITH_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("th-TH");
            UpdateValue();
        }

        private void btnChangeCultureUIUS_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            UpdateValue();
        }
        
        private void btnChangeCultureIV_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture =  System.Globalization.CultureInfo.InvariantCulture;
            UpdateValue();
        }

        private void btnChangeCultureUIIV_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            UpdateValue();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Core.DBConnection db = new Core.DBConnection();


            System.Collections.Generic.Dictionary<string, string> person = new System.Collections.Generic.Dictionary<string, string>();
            System.Collections.Generic.Dictionary<string, string> person2 = new System.Collections.Generic.Dictionary<string, string>();


            person = db.getDictionaryPrototype<string, string>("SELECT NAVYID,WIDTH FROM person ", "NAVYID", "WIDTH");
            foreach (var p in person)
            {
                string[] w = p.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (w.Length == 2)
                {
                    int w1 = Int16.Parse(w[0]);
                    int w2 = Int16.Parse(w[1]);

                    if (w1 > w2)
                    {
                        person2.Add(p.Key, w2.ToString() + "/" + w1.ToString());
                    }
                }
            }

            string sqlUpdate = "";
            foreach (var p in person2)
            {
                sqlUpdate += "UPDATE person SET WIDTH='" + p.Value + "' WHERE NAVYID='" + p.Key + "';\n";
            }

            string a = sqlUpdate;
        }
    }
}
