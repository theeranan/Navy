using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ThaiNationalIDCard;

namespace Navy.Forms
{
    public partial class Scancardsetting : Form
    {
        private ThaiIDCard idcard;
        private PageSetupDialog setupDlg;
        private PrintDialog printDlg;
        private PrintDocument printDoc;

        public Scancardsetting()
        {
            InitializeComponent();
            cbbPrinter.Items.Clear();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cbbPrinter.Items.Add(printer);
            }
            LoadConfig();
            var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var path = Path.Combine(systemPath, "Slip_Plant.txt");
            string myText = "";
            if (File.Exists(path))
            {
                myText = File.ReadAllText(path, Encoding.UTF8);

            }
            rtb_plant.Text = myText;
            // Create a PaperSize and specify the custom paper size through the constructor and add to combobox.
        }
        public Scancardsetting(ThaiIDCard card)
        {
            idcard = card;
            InitializeComponent();
            LoadConfig();
        }
        private void LoadConfig()
        {

            // For read access you do not need to call OpenExeConfiguraton
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                switch (key)
                {
                    case "batt_1": { TextBox_Batt1.Text = value; } break;
                    case "batt_2": { TextBox_Batt2.Text = value; } break;
                    case "batt_3": { TextBox_Batt3.Text = value; } break;
                    case "batt_4": { TextBox_Batt4.Text = value; } break;
                    case "batt_5": { TextBox_Batt5.Text = value; } break;
                    case "batt_6": { TextBox_Batt6.Text = value; } break;
                    case "batt_7": { TextBox_Batt7.Text = value; } break;
                    case "runcode_from": { TextBox_RuncodeFrom.Text = value; } break;
                    case "runcode_to": { TextBox_RuncodeTo.Text = value; } break;
                    case "Color_batt_1": { btn_Color_Batt1.BackColor = Color.FromArgb(Convert.ToInt32(value)); } break;
                    case "Color_batt_2": { btn_Color_Batt2.BackColor = Color.FromArgb(Convert.ToInt32(value)); } break;
                    case "Color_batt_3": { btn_Color_Batt3.BackColor = Color.FromArgb(Convert.ToInt32(value)); } break;
                    case "Color_batt_4": { btn_Color_Batt4.BackColor = Color.FromArgb(Convert.ToInt32(value)); } break;
                    case "Color_batt_5": { btn_Color_Batt5.BackColor = Color.FromArgb(Convert.ToInt32(value)); } break;
                    case "Color_batt_6": { btn_Color_Batt6.BackColor = Color.FromArgb(Convert.ToInt32(value)); } break;
                    case "Color_batt_7": { btn_Color_Batt7.BackColor = Color.FromArgb(Convert.ToInt32(value)); } break;
                    case "PaperSizeW": { textBoxWidth.Text = value; } break;
                    case "PaperSizeH": { textBoxHeight.Text = value; } break;
                    case "Printer": { cbbPrinter.SelectedIndex = cbbPrinter.FindStringExact(value);} break;
                    case "FontSize": { rtbSize.Text = value;} break;
                        /*case "host": { TextBox_Host.Text = value; } break;
                        case "user": { TextBox_User.Text = value; } break;
                        case "pass": { TextBox_Password.Text = value; } break;
                        case "database": { ComboBox_Database.Text = value; } break;*/
                }
                
            }

        }
        private void Button_Database_Click(object sender, EventArgs e)
        {
            try
            {

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Add an Application Setting.
                config.AppSettings.Settings.Remove("batt_1");
                config.AppSettings.Settings.Add("batt_1", TextBox_Batt1.Text);
                config.AppSettings.Settings.Remove("batt_2");
                config.AppSettings.Settings.Add("batt_2", TextBox_Batt2.Text);
                config.AppSettings.Settings.Remove("batt_3");
                config.AppSettings.Settings.Add("batt_3", TextBox_Batt3.Text);
                config.AppSettings.Settings.Remove("batt_4");
                config.AppSettings.Settings.Add("batt_4", TextBox_Batt4.Text);
                config.AppSettings.Settings.Remove("batt_5");
                config.AppSettings.Settings.Add("batt_5", TextBox_Batt5.Text);
                config.AppSettings.Settings.Remove("batt_6");
                config.AppSettings.Settings.Add("batt_6", TextBox_Batt6.Text);
                config.AppSettings.Settings.Remove("batt_7");
                config.AppSettings.Settings.Add("batt_7", TextBox_Batt7.Text);
                config.AppSettings.Settings.Remove("runcode_from");
                config.AppSettings.Settings.Add("runcode_from", TextBox_RuncodeFrom.Text);
                config.AppSettings.Settings.Remove("runcode_to");
                config.AppSettings.Settings.Add("runcode_to", TextBox_RuncodeTo.Text);
                config.AppSettings.Settings.Remove("Color_batt_1");
                config.AppSettings.Settings.Add("Color_batt_1", btn_Color_Batt1.BackColor.ToArgb().ToString());
                config.AppSettings.Settings.Remove("Color_batt_2");
                config.AppSettings.Settings.Add("Color_batt_2", btn_Color_Batt2.BackColor.ToArgb().ToString());
                config.AppSettings.Settings.Remove("Color_batt_3");
                config.AppSettings.Settings.Add("Color_batt_3", btn_Color_Batt3.BackColor.ToArgb().ToString());
                config.AppSettings.Settings.Remove("Color_batt_4");
                config.AppSettings.Settings.Add("Color_batt_4", btn_Color_Batt4.BackColor.ToArgb().ToString());
                config.AppSettings.Settings.Remove("Color_batt_5");
                config.AppSettings.Settings.Add("Color_batt_5", btn_Color_Batt5.BackColor.ToArgb().ToString());
                config.AppSettings.Settings.Remove("Color_batt_6");
                config.AppSettings.Settings.Add("Color_batt_6", btn_Color_Batt6.BackColor.ToArgb().ToString());
                config.AppSettings.Settings.Remove("Color_batt_7");
                config.AppSettings.Settings.Add("Color_batt_7", btn_Color_Batt7.BackColor.ToArgb().ToString());
                config.AppSettings.Settings.Remove("Printer");
                config.AppSettings.Settings.Add("Printer", cbbPrinter.Text);
                config.AppSettings.Settings.Remove("PaperSizeW");
                config.AppSettings.Settings.Add("PaperSizeW", textBoxWidth.Text);
                config.AppSettings.Settings.Remove("PaperSizeH");
                config.AppSettings.Settings.Add("PaperSizeH", textBoxHeight.Text);
                config.AppSettings.Settings.Remove("FontSize");
                config.AppSettings.Settings.Add("FontSize", rtbSize.Text.Replace("&#xA;", ""));
                config.Save(ConfigurationSaveMode.Modified, true);

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
                var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var path = Path.Combine(systemPath, "Slip_Plant.txt");
                using (StreamWriter sw = new StreamWriter(File.Open(path, FileMode.Create), Encoding.UTF8))
                {
                    sw.Write(rtb_plant.Text);
                }
                MessageBox.Show("บันทึกเสร็จสิ้น");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_DefaultServer_Click(object sender, EventArgs e)
        {
            //DBConnection.SetConnectionString("192.168.0.1", "root", "", "midb");
            //DataDefinition.NewConnection();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Add an Application Setting.
            config.AppSettings.Settings.Remove("batt_1");
            config.AppSettings.Settings.Add("batt_1", "แดง");
            config.AppSettings.Settings.Remove("batt_2");
            config.AppSettings.Settings.Add("batt_2", "น้ำเงิน");
            config.AppSettings.Settings.Remove("batt_3");
            config.AppSettings.Settings.Add("batt_3", "เหลือง");
            config.AppSettings.Settings.Remove("batt_4");
            config.AppSettings.Settings.Add("batt_4", "เขียว");
            config.AppSettings.Settings.Remove("batt_5");
            config.AppSettings.Settings.Add("batt_5", "ต");
            config.AppSettings.Settings.Remove("batt_6");
            config.AppSettings.Settings.Add("batt_6", "ล");
            config.AppSettings.Settings.Remove("batt_7");
            config.AppSettings.Settings.Add("batt_7", "กนร");
            config.AppSettings.Settings.Remove("runcode_from");
            config.AppSettings.Settings.Add("runcode_from", "1");
            config.AppSettings.Settings.Remove("runcode_to");
            config.AppSettings.Settings.Add("runcode_to", "4000");
            config.AppSettings.Settings.Remove("Color_batt_1");
            config.AppSettings.Settings.Add("Color_batt_1", "-65536");
            config.AppSettings.Settings.Remove("Color_batt_2");
            config.AppSettings.Settings.Add("Color_batt_2", "-16744193");
            config.AppSettings.Settings.Remove("Color_batt_3");
            config.AppSettings.Settings.Add("Color_batt_3", "-256");
            config.AppSettings.Settings.Remove("Color_batt_4");
            config.AppSettings.Settings.Add("Color_batt_4", "-16711936");
            config.AppSettings.Settings.Remove("Color_batt_5");
            config.AppSettings.Settings.Add("Color_batt_5", "-32768");
            config.AppSettings.Settings.Remove("Color_batt_6");
            config.AppSettings.Settings.Add("Color_batt_6", "-8355585");
            config.AppSettings.Settings.Remove("Color_batt_7");
            config.AppSettings.Settings.Add("Color_batt_7", "-65408");
            config.AppSettings.Settings.Remove("Printer");
            config.AppSettings.Settings.Add("Printer", "");
            config.AppSettings.Settings.Remove("PaperSizeW");
            config.AppSettings.Settings.Add("PaperSizeW", "9");
            config.AppSettings.Settings.Remove("PaperSizeH");
            config.AppSettings.Settings.Add("PaperSizeH", "7");
            config.AppSettings.Settings.Remove("FontSize");
            config.AppSettings.Settings.Add("FontSize", "16,10,10,10,10,10,10,10,16,10,10,10");

            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
            LoadConfig();
            rtb_plant.Text = "";
            rtb_plant.Text = "@title\n";
            rtb_plant.Text += "------------------------------------------\n";
            rtb_plant.Text += "@id13\n";
            rtb_plant.Text += "@name\n";
            rtb_plant.Text += "ผลัด @yearin\n";
            rtb_plant.Text += "@address\n";
            rtb_plant.Text += "@address2\n";
            rtb_plant.Text += "\n";
            rtb_plant.Text += "ร้อย @company พัน @batt(มว.@platoon @pseq)";
            rtb_plant.Text += "\n";
            rtb_plant.Text += "\n";
            rtb_plant.Text += "------------------------------------------";
            rtbSize.Text = "";
            rtbSize.Text = "16,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "14,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10,\n";
            rtbSize.Text += "10";
        }

        private void btn_Color_Batt1_Click(object sender, EventArgs e)
        {
            
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_Color_Batt1.BackColor = colorDialog1.Color;
            }
        }

        private void btn_Color_Batt2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_Color_Batt1.BackColor = colorDialog1.Color;
            }
        }

        private void btn_Color_Batt2_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_Color_Batt2.BackColor = colorDialog1.Color;
            }
        }

        private void btn_Color_Batt3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_Color_Batt3.BackColor = colorDialog1.Color;
            }
        }

        private void btn_Color_Batt4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_Color_Batt4.BackColor = colorDialog1.Color;
            }
        }

        private void btn_Color_Batt5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_Color_Batt5.BackColor = colorDialog1.Color;
            }
        }

        private void btn_Color_Batt6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_Color_Batt6.BackColor = colorDialog1.Color;
            }
        }

        private void btn_Color_Batt7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_Color_Batt7.BackColor = colorDialog1.Color;
            }
        }
        public void RefreshDriver()
        {
            CheckedListBox_Driver.Items.Clear();

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                idcard = new ThaiIDCard();
                string[] readers = idcard.GetReaders();

                if (readers.Length <= 0)
                {
                    config.AppSettings.Settings.Remove("Driver");
                    config.AppSettings.Settings.Add("Driver", "");
                    config.Save(ConfigurationSaveMode.Modified);
                    // Force a reload of a changed section.
                    ConfigurationManager.RefreshSection("appSettings");
                    return;
                }


                foreach (string r in readers)
                {
                    CheckedListBox_Driver.Items.Add(r);
                }
                for (int i = 0; i < CheckedListBox_Driver.Items.Count; i++)
                {
                    CheckedListBox_Driver.SetItemChecked(i, true);
                }
                string item = "";
                if (CheckedListBox_Driver.CheckedItems != null)
                {
                    foreach (object itemChecked in CheckedListBox_Driver.CheckedItems)
                    {
                        if (item == "")
                        {
                            item = itemChecked.ToString();
                        }
                        else
                        {
                            item += "," + itemChecked.ToString();
                        }
                        //idcard.MonitorStart(itemChecked.ToString());

                    }
                }
               

                // Add an Application Setting.
                config.AppSettings.Settings.Remove("Driver");
                config.AppSettings.Settings.Add("Driver", item);
                config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Button_RefreshDriver_Click(object sender, EventArgs e)
        {
            RefreshDriver();
        }

        private void cbbPrinter_Click(object sender, EventArgs e)
        {
            cbbPrinter.Items.Clear();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cbbPrinter.Items.Add(printer);
            }
        }
        
        
    }
}
