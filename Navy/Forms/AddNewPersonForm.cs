using System;
using System.Windows.Forms;
using Navy.Data;
using Navy.Core;
using Navy.Data.DataTemplate;
using System.Linq;
using ThaiNationalIDCard;
using System.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using System.Text;
using System.Diagnostics;

namespace Navy.Forms
{
    public partial class AddNewPersonForm : Form
    {
        public PersonDataSet.PersonNivyRow personNivyData;
        ParamPerson param;
        QueryString.UpdateRecord queryPerson = new QueryString.UpdateRecord();
        DataCoreLibrary dcore;
        DataCoreLibrary dcoreUpdateUsedPerson;
        DataControls.TownnameTab townnameManage;
        private ThaiIDCard idcard; 
        string mode = "new";
        string modecard = "";
        string navyid = "";
        string readfromIDCard = "";
        string batt = "", company = "", platoon = "", pseq = "";
        List<string> driver;
        private StreamReader streamToPrint;
        private Font printFont;
        string year;

        public AddNewPersonForm()
        {
            InitializeComponent();
            DataControls.LoadComboBoxData(cmbskill, DataDefinition.GetSkillTab(), "SKILL", "SKILLCODE", "B");
            param = new ParamPerson();
            if (mode == "new")
            {
                dpregdate.Format = DateTimePickerFormat.Custom;
                dpregdate.CustomFormat = " ";
                dprepdate.Format = DateTimePickerFormat.Custom;
                dprepdate.CustomFormat = " ";
            }
            LoadNewFormControls();
            LoadControlsValue();
            
            //idcard.MonitorStart();
        }
        private void AddNewPersonForm_Load(object sender, EventArgs e)
        {
            if (mode == "new")
            {
                lbl_belong.Text = "ร้อย - พัน - หมวด - ลำดับ -";
                //เอาฟิลด์ไม่จำเป็นออก
                LoadNewFormControls();
                LoadControlsValue();
                setOptionAddNewperson();
                this.Size = new Size(876, 493);
            }
            else
            {
                print_slip.Visible = true;
                this.Size = new Size(1202, 493);
            }
        }

        //โหมดแสกนบัตร
        public AddNewPersonForm(string yearin, string armtown, DateTime regisDate, DateTime comeDate, string origin,string m)
        {
            InitializeComponent();
            if (mode == "new")
            {
                dpregdate.Format = DateTimePickerFormat.Custom;
                dpregdate.CustomFormat = " ";
                dprepdate.Format = DateTimePickerFormat.Custom;
                dprepdate.CustomFormat = " ";
            }
            DataControls.LoadComboBoxData(cmbskill, DataDefinition.GetSkillTab(), "SKILL", "SKILLCODE", "B");
            DataControls.LoadComboBoxData(cmBoxkpt, DataDefinition.Getkptclass(), "kptclass", "kptcode", "");
            // DataControls.LoadComboBoxData(cmbPatient_status, DataDefinition.GetPatient_Status(), "TITLE", "STATUSCODE", "");
            DataControls.LoadComboBoxData(cmb_Addictive_Status, DataDefinition.GetAddictive_Status(), "addname", "addcode", "");
            SetInitialPerson(yearin, armtown, regisDate, comeDate, origin);
            LoadNewFormControls();
            LoadControlsValue();
            this.cbbProvince.Enabled = false;
            groupBox5.Visible = false;
            btnReadcard.Visible = true;
            lblplatoon.Visible = true;
            lblbatt.Visible = true;
            lblcompany.Visible = true;
            lblpseq.Visible = true;
            textBoxBatt.Visible = true;
            textBoxCompany.Visible = true;
            textBoxPlatoon.Visible = true;
            textBoxPseq.Visible = true;
            btn_chechruncode.Visible = true;
            modecard = m;
            year = yearin;
            RefreshDriver();


        }
        private void RefreshDriver()
        {
            try
            {
                idcard = new ThaiIDCard();
                Scancardsetting s = new Scancardsetting();
                s.RefreshDriver();
                driver = ConfigurationManager.AppSettings["Driver"].Split(',').ToList<string>();
                if(driver[0] != "")
                {
                    foreach (string d in driver)
                    {
                        idcard.MonitorStart(d);
                    }
                    //btnReadcard.BackColor = Color.FromArgb(23, 222, 39);
                    //btnReadcard.Text = "อ่านบัตร";
                }
                else
                {
                   // btnReadcard.BackColor = Color.FromName("Red");
                    //btnReadcard.Text = "ไม่พบเครื่องอ่านบัตร";
                }
                idcard.eventCardInserted += new handleCardInserted(CardInserted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CardInserted(Personal personal)
        {
            if (personal == null)
            {
                if (idcard.ErrorCode() > 0)
                {
                    //MessageBox.Show(idcard.Error());
                    return;
                }
                return;
            }

            textBoxID13.Invoke(new MethodInvoker(delegate { textBoxID13.Text = personal.Citizenid; }));
            mtextBoxBD.Invoke(new MethodInvoker(delegate { mtextBoxBD.Text = personal.Birthday.ToString("dd/MM/yyyy"); }));
            textBoxName.Invoke(new MethodInvoker(delegate { textBoxName.Text = personal.Th_Firstname; }));
            textBoxSName.Invoke(new MethodInvoker(delegate { textBoxSName.Text = personal.Th_Lastname; }));
            //if (personal.addrHouseNo != "")
            //{
            //    textBoxHomeNum.Invoke(new MethodInvoker(delegate { textBoxHomeNum.Text = personal.addrHouseNo; }));
            //}
            //if (personal.addrVillageNo != "")
            //{
            //    textBoxMoo.Invoke(new MethodInvoker(delegate { textBoxMoo.Text = personal.addrVillageNo.Substring(8); }));
            //}
            //if (personal.addrLane != "")
            //{
            //    textBoxSoy.Invoke(new MethodInvoker(delegate { textBoxSoy.Text = personal.addrLane.Substring(4); }));
            //}
            //if (personal.addrRoad != "")
            //{
            //    textBoxRoad.Invoke(new MethodInvoker(delegate { textBoxRoad.Text = personal.addrRoad.Substring(4); }));
            //}
            //if (personal.addrProvince != "")
            //{
            //    cbbProvince.Invoke(new MethodInvoker(delegate
            //    {
            //        cbbProvince.SelectedIndex = cbbProvince.FindStringExact(personal.addrProvince.Substring(0, 7) == "จังหวัด" ? personal.addrProvince.Substring(7) : personal.addrProvince);

            //    }));
            //}
            //if (personal.addrAmphur != "")
            //{
            //    cbbCity.Invoke(new MethodInvoker(delegate
            //    {
            //        cbbCity.SelectedIndex = cbbCity.FindString(personal.addrAmphur.Substring(0, 5) == "อำเภอ" ? personal.addrAmphur.Substring(5) : personal.addrAmphur);
            //        if (cbbCity.SelectedIndex == -1)
            //        {
            //            cbbCity.SelectedIndex = cbbCity.FindString(personal.addrAmphur.Substring(0, 5) == "อำเภอ" ? "กิ่งอำเภอ" + personal.addrAmphur.Substring(5) : "กิ่งอำเภอ" + personal.addrAmphur);
            //        }
            //    }));
            //}

            //if (personal.addrTambol != "")
            //{
            //    cbbTumbon.Invoke(new MethodInvoker(delegate
            //    {
            //        cbbTumbon.SelectedIndex = cbbTumbon.FindString(personal.addrTambol.Substring(0, 4) == "ตำบล" ? personal.addrTambol.Substring(4) : personal.addrTambol);
            //    }));
            //}
            cbbType.Invoke(new MethodInvoker(delegate { cbbType.Focus(); }));
        }

        //โหมดกรอกธรรมดา
        public AddNewPersonForm(string yearin, string armtown, DateTime regisDate, DateTime comeDate, string origin)
        {
            InitializeComponent();
            if (mode == "new")
            {
                dpregdate.Format = DateTimePickerFormat.Custom;
                dpregdate.CustomFormat = " ";
                dprepdate.Format = DateTimePickerFormat.Custom;
                dprepdate.CustomFormat = " ";
            }
            DataControls.LoadComboBoxData(cmbskill, DataDefinition.GetSkillTab(), "SKILL", "SKILLCODE", "B");
            DataControls.LoadComboBoxData(cmBoxkpt, DataDefinition.Getkptclass(), "kptclass", "kptcode", "");
            // DataControls.LoadComboBoxData(cmbPatient_status, DataDefinition.GetPatient_Status(), "TITLE", "STATUSCODE", "");
            DataControls.LoadComboBoxData(cmb_Addictive_Status, DataDefinition.GetAddictive_Status(), "addname", "addcode", "");
            SetInitialPerson(yearin, armtown, regisDate, comeDate, origin);
            LoadNewFormControls();
            LoadControlsValue();
            this.cbbProvince.Enabled = false;
            modecard = "";
        }

        // edit mode
        public AddNewPersonForm(string navyid)
        {
            InitializeComponent();
            DataControls.LoadComboBoxData(cmbskill, DataDefinition.GetSkillTab(), "SKILL", "SKILLCODE","B");
            DataControls.LoadComboBoxData(cmBoxkpt, DataDefinition.Getkptclass(), "kptclass", "kptcode", "");
            //DataControls.LoadComboBoxData(cmbPatient_status, DataDefinition.GetPatient_Status(), "TITLE", "STATUSCODE", "");
            DataControls.LoadComboBoxData(cmb_Addictive_Status, DataDefinition.GetAddictive_Status(), "addname", "addcode", "");
            LoadNewFormControls();

            this.navyid = navyid;
            param = dcore.GetPersonParam(navyid);
            //this.reportViewer1.LocalReport.SetParameters(param);
            //this.reportViewer1.RefreshReport();
            LoadControlsValueEdit(param);
            checkDatafromIDCard(param);

            //Editmode ปิดปุ่ม checkruncode กับปุ่ม print_slip
            btn_chechruncode.Visible = false;
            print_slip.Visible = false;
        }

        #region LoadInitialFormValue
        private void SetInitialPerson(string yearin, string armtown, DateTime regisDate, DateTime comeDate, string origin)
        {
            param = new ParamPerson();
            param.yearin = yearin;
            param.armid = armtown;
            param.regDate = regisDate;
            param.repDate = comeDate;
            param.origincode = origin;
        }

        private void LoadNewFormControls()
        {
            dcore = new DataCoreLibrary();
            dcoreUpdateUsedPerson = new DataCoreLibrary(System.Configuration.ConfigurationManager.ConnectionStrings["midb"].ConnectionString);
            townnameManage = new DataControls.TownnameTab();
            SetControlSelectAll();
            AddEnterKeyDown();
        }

        private void LoadControlsValue()
        {
            lbYearin.Text = param.yearin;
            lbYearRegis.Text = "25" + Function.GetRegYear(param.yearin);
            lbRegDate.Text = param.regDate.Date.ToString(Constants.subDateFormat_TH);
            lbComeDate.Text = param.repDate.Date.ToString(Constants.subDateFormat_TH);
            lbArmtown.Text = DataDefinition.GetArmtownName(param.armid);
            lbOrigin.Text = DataDefinition.GetOriginName(param.origincode);

            townnameManage.LoadProvinceToComboBox(cbbProvince, DataDefinition.GetTowncodeByArmtownID(param.armid));
            textBoxID8_1.Text = DataDefinition.GetArmtownAbbName(param.armid);

            //if (cbbType.DataSource == null)
            DataControls.LoadComboBoxData(cbbType, DataDefinition.GetPerTypeTab(), "name", "id", "1");

            //if (cbbEdu.DataSource == null)
            DataControls.LoadComboBoxData(cbbEdu, DataDefinition.GetEducTab(), "EDUCNAME", "ECODE0");

            //if (cbbOcc.DataSource == null)
            DataControls.LoadComboBoxData(cbbOcc, DataDefinition.GetOccTab(), "OCCNAME", "OCCCODE", "H");

            //if (cbbReligion.DataSource == null)
            DataControls.LoadComboBoxData(cbbReligion, DataDefinition.GetReligionTab(), "RELIGION", "REGCODE", "1");

         //   DataControls.LoadComboBoxData(cmbskill, DataDefinition.GetSkillTab(), "SKILL", "SKILLCODE", "B");

            checkBoxRequest.Checked = false;
            LoadID8Number(param.armid);
            textBoxRunNum.Enabled = true;

            this.Name = "เพิ่มข้อมูลทหาร";
            mode = "new";
            textBoxID13.Focus();
        }

        // load value from person for edit
        private void LoadControlsValueEdit(ParamPerson paramFormPersonTable)
        {
            lbYearin.Text = paramFormPersonTable.yearin;
            lbYearRegis.Text = "25" + Function.GetRegYear(paramFormPersonTable.yearin);
            lbRegDate.Text = paramFormPersonTable.regDate.Date.ToString(Constants.subDateFormat_TH);
            lbComeDate.Text = paramFormPersonTable.repDate.Date.ToString(Constants.subDateFormat_TH);
            lbArmtown.Text = DataDefinition.GetArmtownName(paramFormPersonTable.armid);
            lbOrigin.Text = DataDefinition.GetOriginName(paramFormPersonTable.origincode);

            textBoxID13.Text = paramFormPersonTable.id13;
            textBoxName.Text = paramFormPersonTable.name;
            textBoxSName.Text = paramFormPersonTable.sname;
            textBoxFname.Text = paramFormPersonTable.father;
            textBoxFSname.Text = paramFormPersonTable.fsname;
            textBoxMname.Text = paramFormPersonTable.mother;
            textBoxMSname.Text = paramFormPersonTable.msname;
            textBoxTelephone.Text = paramFormPersonTable.telephone;
            textBoxFTelephone.Text = paramFormPersonTable.ftelephone;
            textBoxMTelephone.Text = paramFormPersonTable.mtelephone;
            textBoxPTelephone.Text = paramFormPersonTable.ptelephone;
            textPercent.Text = paramFormPersonTable.percent;
            textBoxAccountNum.Text = paramFormPersonTable.AccountNum;
            try
            {
                //if (cbbType.DataSource == null)
                DataControls.LoadComboBoxData(cbbType, DataDefinition.GetPerTypeTab(), "name", "id", paramFormPersonTable.pertype);
                DataControls.LoadComboBoxData(cmbskill, DataDefinition.GetSkillTab(), "SKILL", "SKILLCODE", paramFormPersonTable.skill);
                DataControls.LoadComboBoxData(cmBoxkpt, DataDefinition.Getkptclass(), "kptclass", "kptcode", paramFormPersonTable.cmBoxkpt);
                DataControls.LoadComboBoxData(cbbBankID, DataDefinition.GetBanktab(), "EngShortName", "BankCode", paramFormPersonTable.BankCode);
                //DataControls.LoadComboBoxData(cmbPatient_status, DataDefinition.GetPatient_Status(), "TITLE", "STATUSCODE", paramFormPersonTable.cmbPatient_status);
                DataControls.LoadComboBoxData(cmb_Addictive_Status, DataDefinition.GetAddictive_Status(), "addname", "addcode", paramFormPersonTable.cmbAddictive_status);

                //if (cbbEdu.DataSource == null)
                string educode = paramFormPersonTable.educode1 + paramFormPersonTable.educode2;
                if (paramFormPersonTable.educode0 != "")
                { educode = paramFormPersonTable.educode0; }
                DataControls.LoadComboBoxData(cbbEdu, DataDefinition.GetEducTab(), "EDUCNAME", "ECODE0", educode);

                //if (cbbOcc.DataSource == null)
                DataControls.LoadComboBoxData(cbbOcc, DataDefinition.GetOccTab(), "OCCNAME", "OCCCODE", paramFormPersonTable.occcode);

                //if (cbbReligion.DataSource == null)
                DataControls.LoadComboBoxData(cbbReligion, DataDefinition.GetReligionTab(), "RELIGION", "REGCODE", paramFormPersonTable.regcode);
            }
            catch { }

            try
            {
                string tempDOB = paramFormPersonTable.birthdate;
                mtextBoxBD.Text = tempDOB.Split('/')[2] + "/" + tempDOB.Split('/')[1] + "/" + (Convert.ToInt16(tempDOB.Split('/')[0]) + 543).ToString();
            }
            catch
            { mtextBoxBD.ResetText(); }
           
            try
            {
                 dpregdate.Value = paramFormPersonTable.regDate;
            }
            catch
            {  }
            try
            {
                    dprepdate.Value = paramFormPersonTable.repDate;
            }
            catch
            { }

            try
            {
                textBoxID8_1.Text = paramFormPersonTable.id8.Substring(0, 4);
                mTextBoxID8.Text = paramFormPersonTable.id8.Substring(4, 4);
            }
            catch { }

            cbbType.SelectedValue = paramFormPersonTable.pertype;
            textBoxRunNum.Text = paramFormPersonTable.runcode;
            textBoxID10.Text = paramFormPersonTable.id;

            batt = paramFormPersonTable.batt;
            company = paramFormPersonTable.company;
            platoon = paramFormPersonTable.platoon;
            pseq = paramFormPersonTable.pseq;
            lbl_belong.Text = "ร้อย " + paramFormPersonTable.company + " พัน " + paramFormPersonTable.batt + " หมวด " + paramFormPersonTable.platoon + " ลำดับ " + paramFormPersonTable.pseq;


            if (paramFormPersonTable.towncode != "")
            {
                string tcode = paramFormPersonTable.towncode;
                try
                {
                    townnameManage.LoadProvinceToComboBox(cbbProvince, tcode);
                    cbbProvince.SelectedValue = tcode.Substring(0, 2) + "0000";
                    townnameManage.LoadCityToComboBox(cbbCity, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                    townnameManage.LoadTumbonToComboBox(cbbTumbon, tcode.Substring(0, 4) + "00", tcode);
                }
                catch { }
            }

            textBoxHomeNum.Text = paramFormPersonTable.address;
            textBoxMoo.Text = paramFormPersonTable.address_mu;
            textBoxSoy.Text = paramFormPersonTable.address_soil;
            textBoxRoad.Text = paramFormPersonTable.address_road;

            textBoxMark.Text = paramFormPersonTable.mark;
            textBoxHeight.Text = paramFormPersonTable.height;

            try
            {
                textBoxChessIn.Text = paramFormPersonTable.width.Split('/')[0];
                textBoxChessOut.Text = paramFormPersonTable.width.Split('/')[1];
            }
            catch
            { }

            try
            {
                if (paramFormPersonTable.is_request.Length > 0)
                {
                    checkBoxRequest.Checked = paramFormPersonTable.is_request.Substring(0, 1) == "1" ? true : false;
                }
            }
            catch
            {
                checkBoxRequest.Checked = false;
            }

            this.Name = "แก้ไขข้อมูลทหาร";
            mode = "edit";
            textBoxID13.Focus();

        }
        
        private void LoadID8Number(string armid)
        {
            //get id8
            string tempid8 = (dcore.GetMaxID8Number(armid) + 1).ToString();
            while (tempid8.Length < 4)
            {
                tempid8 = "0" + tempid8;
            }

            mTextBoxID8.Text = tempid8;
        }

        private void LoadValueFromNivyToControls(PersonDataSet.PersonNivyRow personRow)
        {
            textBoxID13.Text = personRow.ID13;
            textBoxName.Text = personRow.IsNAMENull() ? "" : personRow.NAME;
            textBoxSName.Text = personRow.IsSNAMENull() ? "" : personRow.SNAME;
            textBoxFname.Text = personRow.IsFATHERNull() ? "" : personRow.FATHER;
            textBoxFSname.Text = personRow.IsLFANAMENull() ? "" : personRow.LFANAME;
            textBoxMname.Text = personRow.IsMOTHERNull() ? "" : personRow.MOTHER;
            textBoxMSname.Text = personRow.IsLMANAMENull() ? "" : personRow.LMANAME;

            try
            {
                if (!personRow.IsBIRTHDATENull())
                {
                    if (personRow.BIRTHDATE.Length == 10)
                    {
                        int yearBD = Convert.ToInt16(personRow.BIRTHDATE.Substring(0, 4));
                        if (!Function.IsBuddhistYear(yearBD))
                        {
                            yearBD += 543;
                        }

                        string month = personRow.BIRTHDATE.Substring(5, 2);
                        string day = personRow.BIRTHDATE.Substring(8, 2);

                        mtextBoxBD.Text = day + "/" + month + "/" + yearBD.ToString();
                    }
                }
            }
            catch
            { mtextBoxBD.ResetText(); }

            if (!personRow.IsM_TTNull())
            {
                string tcode = DataDefinition.GetTowncodeByGOVID(personRow.M_TT);
                param.towncode = tcode;
                try
                {
                    cbbProvince.SelectedValue = tcode.Substring(0, 2) + "0000";
                    townnameManage.LoadCityToComboBox(cbbCity, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
                    townnameManage.LoadTumbonToComboBox(cbbTumbon, tcode.Substring(0, 4) + "00", tcode);
                }
                catch { }
            }

            if (!personRow.IsADDRESSNull())
            {
                string[] address;
                try
                {
                    address = personRow.ADDRESS.Split(' ');
                    textBoxHomeNum.Text = address[0];
                    textBoxMoo.Text = address[1].Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[1];
                }
                catch { }
            }

            //pictureBox1.ImageLocation = Function.SelectProvinceDirectory(param.armid,Constants.ImagePath.PersonCardPreValidate) +"\\"+ textBoxID13.Text + ".JPG";
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void setTextAddress() {

        }

        private void LoadValueFromPersonNavyToControls(PersonNavy personRow)
        {
            textBoxID13.Text = personRow.pid;
            textBoxName.Text = personRow.fname.Trim();
            textBoxSName.Text = personRow.lname.Trim();
            //textBoxFname.Text = personRow.faname.Trim();
            //textBoxFSname.Text = personRow.fa_sname == "" ? personRow.lname.Trim() : personRow.fa_sname.Trim();
            //textBoxMname.Text = personRow.maname.Trim();
            //textBoxMSname.Text = personRow.ma_sname == "" ? personRow.lname.Trim() : personRow.ma_sname.Trim();

            try
            {
                mtextBoxBD.Text = personRow.birthdate;
            }
            catch
            { //mtextBoxBD.ResetText();
            }

            //if (personRow.m_tt != "")
            //{
            //    string tcode = DataDefinition.GetTowncodeByGOVID(personRow.m_tt);
            //    param.towncode = tcode;
            //    try
            //    {
            //        cbbProvince.SelectedValue = tcode.Substring(0, 2) + "0000";
            //        townnameManage.LoadCityToComboBox(cbbCity, tcode.Substring(0, 2) + "0000", tcode.Substring(0, 4) + "00");
            //        townnameManage.LoadTumbonToComboBox(cbbTumbon, tcode.Substring(0, 4) + "00", tcode);
            //    }
            //    catch { }
            //}

            //if (personRow.m_home != "")
            //{
            //    personRow.m_home = personRow.m_home.Trim();
            //    string[] addressPrefix = { "ม.", "หมู่", "ซ.", "ซอย", "ถ.", "ถนน" };
            //    string[] address;
            //    try
            //    {
            //        address = personRow.m_home.Split(' ');
            //        textBoxHomeNum.ResetText();
            //        textBoxMoo.ResetText();
            //        textBoxSoy.ResetText();
            //        textBoxRoad.ResetText();

                    //string tempS = personRow.m_home.Trim();
                    //if (tempS.IndexOfAny("0123456789/".ToCharArray()) == 0)
                    //{
                    //    string addrPrefix = "";
                    //    while (GetAddressValue(tempS, out addrPrefix) == "")
                    //    {
                    //        if (tempS.IndexOf('/') == 0 || char.IsDigit(tempS, 0))
                    //        {
                    //            textBoxHomeNum.Text += tempS.Substring(0, 1);
                    //            tempS = tempS.Remove(0, 1);
                    //        }
                    //        else
                    //        {
                    //            break;
                    //        }
                    //    }
                    //}

                    //tempS = tempS.Trim();
                    //if (tempS.IndexOfAny("ม.".ToCharArray()) == 0 || tempS.IndexOfAny("หมู่".ToCharArray()) == 0)
                    //{
                    //    string addrPrefix = "";
                    //    tempS = GetAddressValue(tempS, out addrPrefix);
                    //    while (GetAddressValue(tempS, out addrPrefix) == "")
                    //    {
                    //        if (char.IsDigit(tempS, 0))
                    //        {
                    //            textBoxMoo.Text += tempS.Substring(0, 1);
                    //            tempS = tempS.Remove(0, 1);
                    //        }
                    //        else
                    //        {
                    //            break;
                    //        }
                    //    }
                    //}

                    //tempS = tempS.Trim();
                    //if (tempS.IndexOfAny("ซ.".ToCharArray()) == 0 || tempS.IndexOfAny("ซอย".ToCharArray()) == 0)
                    //{
                    //    string addrPrefix = "";
                    //    tempS = GetAddressValue(tempS, out addrPrefix);
                    //    while (GetAddressValue(tempS, out addrPrefix) == "")
                    //    {
                    //        textBoxSoy.Text += tempS.Substring(0, 1);
                    //        tempS = tempS.Remove(0, 1);
                    //    }
                    //}

                    //tempS = tempS.Trim();
                    //if (tempS.IndexOfAny("ถ.".ToCharArray()) == 0 || tempS.IndexOfAny("ถนน".ToCharArray()) == 0)
                    //{
                    //    string addrPrefix = "";
                    //    tempS = GetAddressValue(tempS, out addrPrefix);
                    //    while (GetAddressValue(tempS, out addrPrefix) == "")
                    //    {
                    //        textBoxRoad.Text += tempS.Substring(0, 1);
                    //        tempS = tempS.Remove(0, 1);
                    //    }
                //    //}
                //}
                //catch { }
            //}

            //textBoxMark.Text = personRow.scare.Trim();
            //textBoxHeight.Text = personRow.tall.Trim();
            //textBoxChessIn.Text = personRow.chess_in.Trim();
            //textBoxChessOut.Text = personRow.chess_out.Trim();

            try
            {
                if (personRow.recruit_code.Length > 4)
                {
                    checkBoxRequest.Checked = personRow.recruit_code.Substring(3, 1) == "0" ? true : false;
                }
            }
            catch
            {
                checkBoxRequest.Checked = false;
            }


            //pictureBox1.ImageLocation = Function.SelectProvinceDirectory(param.armid, Constants.ImagePath.PersonCardPreValidate) + "\\" + textBoxID13.Text + ".JPG";
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void AddValueAddress(string address,TextBox tb)
        {
            tb.ResetText();
            string addressPrefix = "";
            address = GetAddressValue(address, out addressPrefix);
            while (addressPrefix == "")
            {
                tb.Text += address.Substring(0, 1);
                address = address.Remove(0, 1);
            }
        }

        private string GetAddressValue(string address,out string prefix)
        {
            if (address.IndexOf("ม.") == 0)
            {
                prefix = "ม.";
                return address.Remove(0, "ม.".Length).TrimStart();
            }

            if (address.IndexOf("หมู่") == 0)
            {
                prefix = "ม.";
                return address.Remove(0, "หมู่".Length).TrimStart();
            }

            if (address.IndexOf("ซ.") == 0)
            {
                prefix = "ซ.";
                return address.Remove(0, "ซ.".Length).TrimStart();
            }

            if (address.IndexOf("ซอย") == 0)
            {
                prefix = "ซ.";
                return address.Remove(0, "ซอย".Length).TrimStart();
            }

            if (address.IndexOf("ถ.") == 0)
            {
                prefix = "ถ.";
                return address.Remove(0, "ถ.".Length).TrimStart();
            }

            if (address.IndexOf("ถนน") == 0)
            {
                prefix = "ถ.";
                return address.Remove(0, "ถนน".Length).TrimStart();
            }
            prefix = "";
            return "";
        }

        private string GetBirthDate(string textDate)
        {
            DateTime bd;
            string[] txtDateSplit;
            try
            {
                if (DateTime.TryParseExact(mtextBoxBD.Text, "dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"), System.Globalization.DateTimeStyles.None, out bd))
                {
                    txtDateSplit = textDate.Split('/');
                    if (Function.IsBuddhistYear(Convert.ToInt16(txtDateSplit[2])))
                    {
                        return (Convert.ToInt16(txtDateSplit[2]) - 543).ToString() + "/" + txtDateSplit[1] + "/" + txtDateSplit[0];
                    }
                    else
                    {
                        return txtDateSplit[2] + "/" + txtDateSplit[1] + "/" + txtDateSplit[0];
                    }
                }
            }
            catch
            { }
            return "";
        }
    
        #endregion

        #region Check Form values and Get values
        private string ValidateValue()
        {
            if (textBoxID13.Text.Trim() == "")
            {
                DialogResult dialogResult = MessageBox.Show("เลขบัตรประชาชนเป็นค่าว่าง", "Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    return "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    return "เลขบัตรประชาชน";
                }
                
            }

            if (textBoxName.Text.Trim() == "")
            {
                return "ชื่อ";
            }

            if (textBoxSName.Text.Trim() == "")
            {
                return "นามสกุล";
            }

            if (mTextBoxID8.Text.Trim().IndexOfAny("0123456789".ToCharArray()) < 0)
            {
                return "ID8";
            }

            if (DataControls.GetSelectedValueComboBoxToString(cbbType) == "1")
            {
                if (textBoxRunNum.Text.Trim().IndexOfAny("0123456789".ToCharArray()) < 0)
                {
                    return "Running number";
                }
            }
            return "";
        }

        private bool CheckDuplicateValue()
        {
            string key = "";
            string value = "";
            bool isDuplicate = false;
            isDuplicate = dcore.CheckPersonDuplicateKeys(param, out key, out value);
            //if (IsValidCheckPersonID(param.id13))
            //{
            //    MessageBox.Show("เลขบัตรประชาชนไม่ถูกต้อง");
            //    isDuplicate = true;
            //}
            if (key == "ID13")
            {
                MessageBox.Show("ข้อมูล [" + key + ":" + value + "] มีอยู่ในระบบแล้ว");
                textBoxID13.Focus();
                isDuplicate = true;
            }
            else if (key == "ID8")
            {
                MessageBox.Show("ข้อมูล [" + key + ":" + value + "] มีอยู่ในระบบแล้ว");
                mTextBoxID8.Focus();
                isDuplicate = true;
            }
            else if (key == "ID")
            {
                MessageBox.Show("ข้อมูล [" + key + ":" + value + "] มีอยู่ในระบบแล้ว");
                mTextBoxID8.Focus();
                isDuplicate = true;
            }
            else if (key == "RUNCODE")
            {
                MessageBox.Show("ข้อมูล [" + key + ":" + value + "] มีอยู่ในระบบแล้ว");
                textBoxRunNum.Focus();
                isDuplicate = true;
            }

            return isDuplicate;
        }

        private void GetParameters()
        {
            param.address = textBoxHomeNum.Text.Trim();
            param.address_mu = textBoxMoo.Text.Trim();
            param.address_road = textBoxRoad.Text.Trim();
            param.address_soil = textBoxSoy.Text.Trim();
            //param.armid = ;
            param.birthdate = GetBirthDate(mtextBoxBD.Text.Trim());
            if (mode != "new")
            {
                param.regDate = dpregdate.Value;
                param.repDate = dprepdate.Value;
            }
            param.educode0 = DataControls.GetSelectedValueComboBoxToString(cbbEdu);

            if (param.educode0.Length >= 4)
            {
                param.educode1 = param.educode0.Substring(0, 1);
                param.educode2 = param.educode0.Remove(0, 1);
            }

            param.father = textBoxFname.Text.Trim();
            param.fsname = textBoxFSname.Text.Trim();
            param.mother = textBoxMname.Text.Trim();
            param.msname = textBoxMSname.Text.Trim();
            param.height = textBoxHeight.Text.Trim();
            param.id = textBoxID10.Text;
            param.id13 = textBoxID13.Text.Trim();

            string tempid8 = mTextBoxID8.Text.Trim();
            while (tempid8.Length < 4)
            {
                tempid8 = "0" + tempid8;
            }
            param.id8 = textBoxID8_1.Text + tempid8;
            param.is_request = checkBoxRequest.Checked ? "100" : "000";
            param.mark = textBoxMark.Text.Trim();
            param.name = textBoxName.Text.Trim();
            param.sname = textBoxSName.Text.Trim();
            param.pertype = DataControls.GetSelectedValueComboBoxToString(cbbType);
            param.regcode = DataControls.GetSelectedValueComboBoxToString(cbbReligion);
            param.occcode = DataControls.GetSelectedValueComboBoxToString(cbbOcc);

            if (param.pertype == "1")
            {
                param.runcode = textBoxRunNum.Text.Trim();
            }
            else
            {
                param.runcode = null;
            }
            param.batt = batt;
            param.company = company;
            param.platoon = platoon;
            param.pseq = pseq;

            param.width = textBoxChessIn.Text + "/" + textBoxChessOut.Text;


            param.telephone = textBoxTelephone.Text.Trim();
            param.ftelephone = textBoxFTelephone.Text.Trim();
            param.mtelephone = textBoxMTelephone.Text.Trim();
            param.ptelephone = textBoxPTelephone.Text.Trim();
            param.percent = textPercent.Text.Trim();
            param.AccountNum = textBoxAccountNum.Text.Trim();

            if (DataControls.GetSelectedValueComboBoxToString(cbbTumbon) == "")
            {
                if (DataControls.GetSelectedValueComboBoxToString(cbbCity) == "")
                {
                    param.towncode = DataControls.GetSelectedValueComboBoxToString(cbbProvince);
                }
                else
                {
                    param.towncode = DataControls.GetSelectedValueComboBoxToString(cbbCity);
                }
            }
            else
            {
                param.towncode = DataControls.GetSelectedValueComboBoxToString(cbbTumbon);
            }
            if (cmbskill.Text.Trim() != "")
            {
                param.skill = DataControls.GetSelectedValueComboBoxToString(cmbskill);
            }
            else
            {
                param.skill = "B";
            }
            if (cmBoxkpt.Text.Trim() != "")
            {
                param.cmBoxkpt = DataControls.GetSelectedValueComboBoxToString(cmBoxkpt);
            }
            else
            {
                param.cmBoxkpt = null;
            }
            if (cbbBankID.Text.Trim() != "")
            {
                param.BankCode = DataControls.GetSelectedValueComboBoxToString(cbbBankID);
            }
            else
            {
                param.BankCode = null;
            }
            //if (cmbPatient_status.Text.Trim() != "")
            //{
            //    param.cmbPatient_status = DataControls.GetSelectedValueComboBoxToString(cmbPatient_status);
            //}
            //else
            //{
            //    param.cmbPatient_status = null;
            //}
            if (cmb_Addictive_Status.Text.Trim() != "")
            {
                param.cmbAddictive_status = DataControls.GetSelectedValueComboBoxToString(cmb_Addictive_Status);
            }
            else
            {
                param.cmbAddictive_status = null;
            }
            if (readfromIDCard == "1")
            {
                param.flagreadfrom_IDCard = "1";
            }

        }
        #endregion

        #region Event Control Action
        private void textBoxID13_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.btnSearchNivy.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void EventEnterKeyForNextControl(object sender, KeyEventArgs e)
        
        
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void AddEnterKeyDown()
        {         
            foreach (Control c in groupBox1.Controls)
            {            
                c.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            }
            foreach (Control c in groupBox2.Controls)
            {
                c.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            }
            foreach (Control c in groupBox4.Controls)
            {
                c.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            }
            foreach (Control c in groupBox5.Controls)
            {
                c.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            }
            foreach (Control c in groupBox3.Controls)
            {
                c.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            }
            foreach (Control c in groupBox8.Controls)
            {
                c.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            }
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pertype = DataControls.GetSelectedValueComboBoxToString(cbbType);
            if (pertype == "1" || pertype == "")
            {
                lbl_belong.Text = "ร้อย - พัน - หมวด - ลำดับ -";
                lbl_belong.BackColor = Color.FromName("Gainsboro");
                textBoxRunNum_TextChanged(sender, e);
            }
            else
            {
                company = "0";
                platoon = "0";
                pseq = "0";
                switch (pertype)
                {
                    case "2":
                        {
                            lbl_belong.Text = "ไม่มีความรู้";
                            batt = "5";
                            lbl_belong.BackColor = Color.FromArgb(Convert.ToInt32(ConfigurationManager.AppSettings["Color_batt_5"]));
                        }
                        break;
                    case "3":
                        {
                            lbl_belong.Text = "ลาศึกษาต่อ";
                            batt = "6";
                            lbl_belong.BackColor = Color.FromArgb(Convert.ToInt32(ConfigurationManager.AppSettings["Color_batt_6"]));
                        }
                        break;
                    case "4":
                        {
                            lbl_belong.Text = "หนีระหว่างนำส่ง";
                            batt = "7";
                            lbl_belong.BackColor = Color.FromArgb(Convert.ToInt32(ConfigurationManager.AppSettings["Color_batt_7"]));
                        }
                        break;
                }
            }
        }

        //input number only
        private void textBoxRunNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxRunNum_TextChanged(object sender, EventArgs e)
        {
            if (modecard != "")
            {
                btnSubmitAndNew.TabIndex = textBoxRunNum.TabIndex + 1;
            }
            string pertype = DataControls.GetSelectedValueComboBoxToString(cbbType);
            if (textBoxRunNum.Text != "" && pertype == "1")
            {
                Data.DataTemplate.NavyRunNumber num = Function.GenRunningNumber(Convert.ToInt32(textBoxRunNum.Text));

                lbl_belong.Text = "ร้อย " + num.company + " พัน " + num.batt + " หมวด " + num.platoon + " ลำดับ " + num.pseq;
                batt = num.batt;
                switch (batt)
                {
                    case "1": {
                            lbl_belong.BackColor = Color.FromArgb(Convert.ToInt32(ConfigurationManager.AppSettings["Color_batt_1"]));
                        } break;
                    case "2": {
                            lbl_belong.BackColor = Color.FromArgb(Convert.ToInt32(ConfigurationManager.AppSettings["Color_batt_2"]));
                        } break;
                    case "3": {
                            lbl_belong.BackColor = Color.FromArgb(Convert.ToInt32(ConfigurationManager.AppSettings["Color_batt_3"]));
                        } break;
                    case "4": {
                            lbl_belong.BackColor = Color.FromArgb(Convert.ToInt32(ConfigurationManager.AppSettings["Color_batt_4"]));
                        } break;
                   
                }
                company = num.company;
                platoon = num.platoon;
                pseq = num.pseq;
                param.runcode = Function.GetNavyRunningNumber(num);
            }
        }

        private void cbbArmtown_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbCity.DataSource = null;
            cbbTumbon.DataSource = null;
            object value = ((ComboBox)sender).SelectedValue;
            if (value != null)
            {
                townnameManage.SelectedProvince = value.ToString();
                townnameManage.LoadCityToComboBox(cbbCity, value.ToString());
                cbbCity_SelectedIndexChanged(cbbCity, e);
            }
        }

        private void cbbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTumbon.DataSource = null;
            object value = ((ComboBox)sender).SelectedValue;
            if (value != null)
            {
                townnameManage.SelectedCity = value.ToString();
                townnameManage.LoadTumbonToComboBox(cbbTumbon, value.ToString());
            }
        }

        private void mTextBoxID8_TextChanged(object sender, EventArgs e)
        {
            textBoxID10.Text = Function.GetNavyNumberID10(param.yearin, param.armid, mTextBoxID8.Text);
        }

        private void mTextBoxID8_Leave(object sender, EventArgs e)
        {
            mTextBoxID8_TextChanged(sender, e);
        }
        #endregion

        #region SelectAll Action

        private void SetTextboxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((TextBox)sender).SelectAll(); });
        }

        private void SetMaskedTextboxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((MaskedTextBox)sender).SelectAll(); });
        }

        private void SetComboBoxSelectAll(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { ((ComboBox)sender).SelectAll(); });
        }

        private void SetControlSelectAll()
        {
            foreach (Control c in groupBox1.Controls)
            
            
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.Enter += new System.EventHandler(this.SetComboBoxSelectAll);
                }

                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.Enter += new System.EventHandler(this.SetTextboxSelectAll);
                }

                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.Enter += new System.EventHandler(this.SetMaskedTextboxSelectAll);
                }
            }
        }

        private void ClearValueForNewPerson()
        {
            readfromIDCard = "";
            foreach (Control c in groupBox1.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.SelectedText = "";
                    cbb.SelectedIndex = -1;
                    cbb.Text = "";
                    //cbb.SelectedValue = null;
                }

                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.ResetText();
                }

                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.ResetText();
                }
            }
            foreach (Control c in groupBox2.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.SelectedText = "";
                    cbb.SelectedIndex = -1;
                    cbb.Text = "";
                    //cbb.SelectedValue = null;
                }

                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.ResetText();
                }

                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.ResetText();
                }
            }
            foreach (Control c in groupBox4.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.SelectedText = "";
                    cbb.SelectedIndex = -1;
                    cbb.Text = "";
                    //cbb.SelectedValue = null;
                }

                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.ResetText();
                }

                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.ResetText();
                }
            }
            foreach (Control c in groupBox5.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.SelectedText = "";
                    cbb.SelectedIndex = -1;
                    cbb.Text = "";
                    //cbb.SelectedValue = null;
                }

                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.ResetText();
                }

                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.ResetText();
                }
            }
            foreach (Control c in groupBox8.Controls)
            {
                ComboBox cbb = c as ComboBox;
                if (cbb != null)
                {
                    cbb.SelectedText = "";
                    cbb.SelectedIndex = -1;
                    cbb.Text = "";
                    //cbb.SelectedValue = null;
                }

                TextBox t = c as TextBox;
                if (t != null)
                {
                    t.ResetText();
                }

                MaskedTextBox mt = c as MaskedTextBox;
                if (mt != null)
                {
                    mt.ResetText();
                }
            }
        }
        #endregion

        #region Event button
        private void btnSearchNivy_Click(object sender, EventArgs e)
        {
            //search from nivy for import data to use
            SearchNivyForm2 f = new SearchNivyForm2(textBoxID13.Text);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            if (f.personSelected != null) //personSelected คือ ข้อมูลที่ได้จากที่เลือกมาก
            {
                LoadValueFromPersonNavyToControls(f.personSelected);
                readfromIDCard = "1";
                textBoxName.Focus();
            }
        }
        private void Request_Runcode()
        {
            param.runcodefrom = ConfigurationManager.AppSettings["runcode_from"];
            param.runcodeto = ConfigurationManager.AppSettings["runcode_to"];
            try
            {
                string runcode = dcore.RequestRuncode(param, textBoxBatt.Text, textBoxCompany.Text,textBoxPlatoon.Text,textBoxPseq.Text, DataControls.GetSelectedValueComboBoxToString(cbbType));
                textBoxRunNum.Invoke(new MethodInvoker(delegate { textBoxRunNum.Text = runcode; }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool IsValidCheckPersonID(string pid)
        {

            char[] numberChars = pid.ToCharArray();

            int total = 0;
            int mul = 13;
            int mod = 0, mod2 = 0;
            int nsub = 0;
            int numberChars12 = 0;

            for (int i = 0; i < numberChars.Length - 1; i++)
            {
                int num = 0;
                int.TryParse(numberChars[i].ToString(), out num);

                total = total + num * mul;
                mul = mul - 1;

                //Debug.Log(total + " - " + num + " - "+mul);
            }

            mod = total % 11;
            nsub = 11 - mod;
            mod2 = nsub % 10;

            //Debug.Log(mod);
            //Debug.Log(nsub);
            //Debug.Log(mod2);


            int.TryParse(numberChars[12].ToString(), out numberChars12);

            //Debug.Log(numberChars12);

            if (mod2 != numberChars12)
                return true;
            else
                return false;
        }
        private void btnSubmitAndNew_Click(object sender, EventArgs e)
        {
            //save and new form for record next person
            if (modecard != "")
            {
                if (textBoxRunNum.Text.Trim() == "")
                {
                    Request_Runcode();
                }
            }
            string val = ValidateValue();
            if (val != "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ [" + val + "] ก่อนบันทึก");
                
                return;
            }

            try
            {
                GetParameters();                

                if (mode == "new")
                {
                    if (CheckDuplicateValue())
                    {
                        return;
                    }

                    if (dcore.InsertPerson(param))
                    {
                        dcoreUpdateUsedPerson.UpdatePersonUsed(param.id13);
if (modecard != "")
                        {
                            print_dialog();
                        }
                        MessageBox.Show("บันทึกเรียบร้อย");
                        
                        ClearValueForNewPerson();
                        SetInitialPerson(param.yearin, param.armid, param.regDate, param.repDate, param.origincode);
                        SetControlSelectAll();
                        LoadControlsValue();
                        textBoxID13.Focus();
                    }
                    else
                    {
                        MessageBox.Show("บันทึกผิดพลาด");
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void print_dialog()
        {
           try
            {
                var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var path = Path.Combine(systemPath, "Slip.txt");
                string myText = File.ReadAllText(Path.Combine(systemPath, "Slip_Plant.txt"), Encoding.UTF8);
                if (File.Exists(path))
                {
                    File.Delete(path);

                }
                using (StreamWriter sw = new StreamWriter(path))
                {
                    string title = "";
                    switch (batt)
                    {
                        case "1": { title = ConfigurationManager.AppSettings["batt_1"]+" "+company; } break;
                        case "2": { title = ConfigurationManager.AppSettings["batt_2"] + " " + company; } break;
                        case "3": { title = ConfigurationManager.AppSettings["batt_3"] + " " + company; } break;
                        case "4": { title = ConfigurationManager.AppSettings["batt_4"] + " " + company; } break;
                        case "5": { title = ConfigurationManager.AppSettings["batt_5"]; } break;
                        case "6": { title = ConfigurationManager.AppSettings["batt_6"]; } break;
                        case "7": { title = ConfigurationManager.AppSettings["batt_7"]; } break;
                    }
                    myText = myText.Replace("@title",title);
                    myText = myText.Replace("@id13", String.Format("{0:0 0000 00000 0 00}", textBoxID13.Text));
                    myText = myText.Replace("@name", textBoxName.Text + " " + textBoxSName.Text);
                    string address = "";
                    string address_line2 = "";
                    if (textBoxHomeNum.Text != "")
                    {
                        address += textBoxHomeNum.Text;
                    }
                    if(textBoxMoo.Text != "")
                    {
                        address += " หมู่ "+textBoxMoo.Text;
                    }
                    if (textBoxSoy.Text != "")
                    {
                        address += " ซอย" + textBoxSoy.Text;
                    }
                    if (textBoxRoad.Text != "")
                    {
                        address += " ถนน" + textBoxRoad.Text;
                    }
                    if (cbbTumbon.Text != "")
                    {
                        address += " ตำบล" + cbbTumbon.Text;
                    }
                    if (cbbCity.Text != "")
                    {
                        address_line2 += "อำเภอ" + cbbCity.Text;
                    }
                    if (cbbProvince.Text != "")
                    {
                        address_line2 += " จังหวัด" + cbbProvince.Text;
                    }
                    myText = myText.Replace("@address1", address);
                    myText = myText.Replace("@address2", address_line2);
                    myText = myText.Replace("@batt", batt);
                    myText = myText.Replace("@company", company);
                    myText = myText.Replace("@platoon", platoon);
                    myText = myText.Replace("@pseq", Int32.Parse(pseq) < 10 ? "0" + pseq : pseq);
                    myText = myText.Replace("@yearin", year);
                    myText = myText.Replace("@runcode", textBoxRunNum.Text);
                    string tempid8 = mTextBoxID8.Text.Trim();
                    while (tempid8.Length < 4)
                    {
                        tempid8 = "0" + tempid8;
                    }
                    string id8 = textBoxID8_1.Text + tempid8;
                    myText = myText.Replace("@id8", id8);
                    sw.Write(myText);
                }
                DialogResult dialogResult = MessageBox.Show(myText, "Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    streamToPrint = new StreamReader(path, Encoding.UTF8, true);
                    {
                        try
                        {

                            PrintDocument pd = new PrintDocument();
                            pd.DefaultPageSettings.PaperSize = new PaperSize("custom", Int32.Parse(ConfigurationManager.AppSettings["PaperSizeW"]), Int32.Parse(ConfigurationManager.AppSettings["PaperSizeH"]));
                            pd.PrinterSettings.PrinterName = ConfigurationManager.AppSettings["Printer"];
                            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                            pd.Print();
                        }
                        finally
                        {
                            streamToPrint.Close();
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float yPos = 0;
            int count = 0;
            float leftMargin = 1; 
            float topMargin = 1;
            float[]line = new float[13];
            string text = null;
            float textHeight = 0;
            line[0] = 16;
            line[1] = 10;
            line[2] = 10;
            line[3] = 10;
            line[4] = 10;
            line[5] = 10;
            line[6] = 10;
            line[7] = 10;
            line[8] = 14;
            line[9] = 10;
            line[10] = 10;
            line[11] = 10;
            line[12] = 10;
            List<string> FontSize = ConfigurationManager.AppSettings["FontSize"].Split(',').ToList<string>();
            while ((text = streamToPrint.ReadLine()) != null)
            {
                printFont = new Font("Monaco", Int32.Parse(FontSize[count]));
                yPos = topMargin + textHeight;
                ev.Graphics.DrawString(text, printFont, Brushes.Black,leftMargin, yPos, new StringFormat());
                textHeight += printFont.GetHeight(ev.Graphics);
                count++;
            }
            if (text != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //save and close form
            string val = ValidateValue();
            if (val != "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ [" + val + "] ก่อนบันทึก");
                return;
            }
            try
            {
                GetParameters();
                if (mode == "new")
                {
                    if (CheckDuplicateValue())
                    {
                        return;
                    }
                    if (dcore.InsertPerson(param))
                    {
                        dcoreUpdateUsedPerson.UpdatePersonUsed(param.id13);
                        MessageBox.Show("บันทึกเรียบร้อย");
                        textBoxID13.Focus();
                    }
                    else
                    {
                        MessageBox.Show("บันทึกผิดพลาด");
                    }
                }
                else
                {
                    if (CheckDuplicateValue())
                    {
                        return;
                    }
                    if (dcore.UpdatePerson(param, navyid))
                    {
                        MessageBox.Show("บันทึกเรียบร้อย");
                        textBoxID13.Focus();
                    }
                    else
                    {
                        MessageBox.Show("บันทึกผิดพลาด");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearValueForNewPerson();
            SetInitialPerson(param.yearin, param.armid, param.regDate, param.repDate, param.origincode);
            LoadControlsValue();
        }

        public void SetbtnSubmitVisible(bool isVisible)
        {
            this.btnSubmit.Visible = isVisible;
        }

        public void SetbtnSubmitAndNewVisible(bool isVisible)
        {
            this.btnSubmitAndNew.Visible = isVisible;
        }

        #endregion

        private void label40_Click(object sender, EventArgs e)
        {

        }
        private void textPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textPercent.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReadcard_Click(object sender, EventArgs e)
        {
            RefreshDriver();
            Personal personal = idcard.readAll();
            if (personal != null)
            {
                CardInserted(personal);
                readfromIDCard = "1";
            }
            else {
                MessageBox.Show("ไม่สามารถดึงข้อมูลจากบัตรประชาชนได้");
            }
        }

        private void print_slip_Click(object sender, EventArgs e)
        {
            print_dialog();
        }

        private void LinkLabel_IDCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = @"\\192.168.0.1\d\TranscriptionForm\" + param.yearin.Replace("/", ".") + '/' + param.id13 + ".pdf";
            string filePathJPG = @"\\192.168.0.1\d\TranscriptionForm\" + param.yearin.Replace("/", ".") + '/' + param.id13 + ".jpg";
            string filePathNavyID = @"\\192.168.0.1\d\TranscriptionForm\" + param.yearin.Replace("/", ".") + '/' + param.navyid + ".pdf";
            string filePathJPGNavyID = @"\\192.168.0.1\d\TranscriptionForm\" + param.yearin.Replace("/", ".") + '/' + param.navyid + ".jpg";
            if (File.Exists(filePath)) //ถ้่า "เจอ" ชื่อไฟล์นั้น
            {
                OpenIDCardFile(filePath);
            }
            else if (File.Exists(filePathJPG))
            {
                OpenIDCardFile(filePathJPG);
            }
            else if (File.Exists(filePathNavyID))
            {
                OpenIDCardFile(filePathNavyID);
            }
            else if (File.Exists(filePathJPGNavyID))
            {
                OpenIDCardFile(filePathJPGNavyID);
            }
            else //เป็น ผลัดสมทบฝึก ให้หาจาก folder ของ oldyearin
            {
                if (param.oldyearin == "" || param.oldyearin == null)
                {
                    MessageBox.Show("ไม่พบไฟล์");
                }
                else
                {
                    filePath = @"\\192.168.0.1\d\TranscriptionForm\" + param.oldyearin.Replace("/", ".") + '/' + param.id13 + ".pdf";
                    filePathJPG = @"\\192.168.0.1\d\TranscriptionForm\" + param.oldyearin.Replace("/", ".") + '/' + param.id13 + ".jpg";
                    filePathNavyID = @"\\192.168.0.1\d\TranscriptionForm\" + param.oldyearin.Replace("/", ".") + '/' + param.navyid + ".pdf";
                    filePathJPGNavyID = @"\\192.168.0.1\d\TranscriptionForm\" + param.oldyearin.Replace("/", ".") + '/' + param.navyid + ".jpg";

                    if (File.Exists(filePath))
                    {
                        OpenIDCardFile(filePath);
                    }
                    else if (File.Exists(filePathJPG))
                    {
                        OpenIDCardFile(filePathJPG);
                    }
                    else if (File.Exists(filePathNavyID))
                    {
                        OpenIDCardFile(filePathNavyID);
                    }
                    else if (File.Exists(filePathJPGNavyID))
                    {
                        OpenIDCardFile(filePathJPGNavyID);
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบไฟล์");
                    }
                }

            }
        }


        /*private void Button_Connect_Click(object sender, EventArgs e)
        {
            UserName = System.Environment.MachineName.ToString();
            if (!String.IsNullOrEmpty(UserName))
            {
                Console("Connecting to server...");
                ConnectAsync();
            }
        }
        private async void ConnectAsync()
        {
            ServerURI = "http://" + Textbox_ip.Text + ":8080/signalr";
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyChatHub");
            HubProxy.On<string, string>("AddMessage", (name, message) =>
                this.Invoke((Action)(() => {
                    if (name == "HubServer")
                    {
                        textBoxRunNum.Text = message;
                    }
                    Console(name+":" + message);
                }))
            );
            try
            {
                await Connection.Start();
                checkHubserver = true;
            }
            catch (HttpRequestException)
            {
                checkHubserver = false;
                Console("Unable to connect to server: Start server before connecting clients.");
                //No connection: Don't enable Send button or show chat UI
                return;
            }
            Console("Connected to server at " + ServerURI);
        }
        private void Connection_Closed()
        {
            //Deactivate chat UI; show login UI. 
            //this.Invoke((Action)(() => ButtonSend.Enabled = false));
            this.Invoke((Action)(() => Console("You have been disconnected.")));
        }*/

        /*private void Console(string message)
        {
            DateTime date = DateTime.Now;
            LogConsole.Text += String.Format("{0}: {1}" ,"["+date.ToString("hh:MM:ss")+"]", message + Environment.NewLine);
            int max_lines = 5;
            if (LogConsole.Lines.Length > max_lines)
            {
                string[] newLines = new string[max_lines];
                Array.Copy(LogConsole.Lines, 1, newLines, 0, max_lines);
                LogConsole.Lines = newLines;
            }
            LogConsole.SelectionStart = LogConsole.Text.Length;
            LogConsole.ScrollToCaret();
        }*/
        private void setOptionAddNewperson() {
            groupBox3.Visible = false;
            panel3.TabIndex = 667;
            
        }

        private void btn_chechruncode_Click(object sender, EventArgs e)
        {
            Request_Runcode();
        }

        private void checkDatafromIDCard(ParamPerson param) {
            if (param.flagreadfrom_IDCard == "1") {
                textBoxID13.ReadOnly = true;
                mtextBoxBD.ReadOnly = true;
                lbl_IDCard.Text = "ข้อมูลจากบัตร";
                //cbbReligion.Enabled = false;
            }
            else
            {
                lbl_IDCard.Text = "ข้อมูลจากสด.";
            }

        }
        private void OpenIDCardFile(string filePath)
        {
            Process p = new Process();
            ProcessStartInfo s = new ProcessStartInfo(filePath);
            p.StartInfo = s;
            p.Start();
        }
    }
}
