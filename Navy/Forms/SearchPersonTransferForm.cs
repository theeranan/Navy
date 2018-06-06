using MySql.Data.MySqlClient;
using Navy.Core;
using Navy.Data;
using Navy.Data.DataTemplate;
using Navy.MyControls;
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
    public partial class SearchPersonTransferForm : Form
    {
        List<PersonSearch> listPerson;
        DataTable dtPerson;
        DataTable dtTransDetail;
        DataTable dtPunishmentDetail;
        DataTable dtDataOldYearin;
       // DataTable dtIndicment;

        DataCoreLibrary dcoreNav;
        DataCoreLibrary dcoreNavAll;
        ParamSearchPerson paramSearch;
        int count = 0;
        public SearchPersonTransferForm()
        {
            InitializeComponent();
            AddEnterKeyDown();

            rbAddNew.Checked = true;
            rbEditOrDelete.Checked = false;
            paramSearch = new ParamSearchPerson();
            dtPerson = new DataTable();
            dtTransDetail = new DataTable();
            dtPunishmentDetail = new DataTable();
            dtDataOldYearin = new DataTable();
            //dtIndicment = new DataTable();

            dcoreNav = new DataCoreLibrary();
            dcoreNav.ChangeDB("navdb");
            dcoreNavAll = new DataCoreLibrary();
            dcoreNavAll.ChangeDB("navdb_all");

            mtxtYearin.Text = dcoreNav.GetMaxYearin();
        }

        private void Search()
        {
            try
            {
                ParamSearchPerson param = new ParamSearchPerson();
                param.name = textBoxName.Text;
                param.sname = textBoxSname.Text;
                param.id8 = mTextBoxID8.Text;
                param.yearin = mtxtYearin.Text;

                if (rbAddNew.Checked)
                {
                    listPerson = dcoreNav.GetSearchPerson("", "", param);
                }
                else if (rbEditOrDelete.Checked)
                {
                    listPerson = dcoreNavAll.GetSearchPerson("", "", param);
                }

                gvResult.DataSource = listPerson;
                gvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                try
                {
                    gvResult.Columns["navyid"].Visible = false;
                }
                catch { }

                count = listPerson.Count;
                labelCountSearchRecord.Text = Convert.ToString(count) + " Record(s)";
                gvResult.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
            gvResult.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("ต้องการคัดลอกข้อมูลนี้ไปยังฐานข้อมูลทหารใหม่ ใช่หรือไม่", "คัดลอกข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int rowsAffect = 0;
                    string navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();
                    try
                    {
                        if (rbAddNew.Checked)
                        {
                            //no action
                            MessageBox.Show("ยังไม่มีฟังก์ชั่นการทำงานรองรับในส่วนนี้");
                        }
                        else if (rbEditOrDelete.Checked)
                        {
                            //get data from [person] [trans_detail], [punishment_detail], [dataoldyearin]
                            using (MySql.Data.MySqlClient.MySqlConnection con = dcoreNavAll.getConnection())
                            {
                                dcoreNavAll.openConnection();
                                dtPerson = new DataTable();
                                dtTransDetail = new DataTable();
                                dtPunishmentDetail = new DataTable();
                                dtDataOldYearin = new DataTable();
                                //dtIndicment = new DataTable();

                                dtPerson.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM person WHERE NAVYID = '" + navyid + "';", con)).ExecuteReader());
                                dtTransDetail.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM trans_detail WHERE NAVYID = '" + navyid + "';", con)).ExecuteReader());
                                dtPunishmentDetail.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM punishment_details WHERE NAVYID = '" + navyid + "';", con)).ExecuteReader());
                                dtDataOldYearin.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM dataoldyearin WHERE NAVYID = '" + navyid + "';", con)).ExecuteReader());
                                //dtIndicment.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM indictmenttab WHERE NavyID = '" + navyid + "';", con)).ExecuteReader());

                                dcoreNavAll.closeConnection();
                            }

                            //insert data to NavDB
                            using (MySql.Data.MySqlClient.MySqlConnection con = dcoreNav.getConnection())
                            {
                                dcoreNav.openConnection();

                                string sqlPerson = "";
                                foreach (DataRow dr in dtPerson.Rows)
                                {
                                    //sqlPerson += "INSERT INTO `person` (`STATUSCODE`, `educ`, `BATT`, `COMPANY`, `PLATOON`, `PSEQ`, `YEARIN`, `NAME`, `SNAME`, `ID8`, `PERCENT`, `UNIT1`, `UNIT2`, `POSTCODE`, `UNIT4`, `ITEM`, `UNIT3`, `ASK`, `NUMBER`, `UNIT0`, `REM`, `REM2`, `BIRTHDATE`, `ID13`, `EDUCODE0`, `EDUCODE1`, `EDUCODE2`, `ID`, `ISSCHOOL`, `NAVYID`, `ARMID`, `REGCODE`, `OCCCODE`, `RECIVEEDU1`, `RECIVEEDU2`, `SCHOOLCODE`, `SKILLCODE`, `TOWNCODE`, `SWIMCODE`, `SALCODE`, `ADDRESS`, `ADDRESS_MU`, `ADDRESS_SOIL`, `ADDRESS_ROAD`, `FATHER`, `FSNAME`, `MOTHER`, `MSNAME`, `HEIGHT`, `WIDTH`, `PERTYPE`, `RUNCODE`, `PERCENT1`, `PERSTAT`, `REPDATE`, `ARMSTUDY`, `REGDATE`, `RETIREDATE`, `MARK`, `BLOOD`, `REASON`, `IS_REQUEST`, `SORDER`, `NLABEL`, `NUMBOX`, `RECORDDATE`, `RECORDBY`, `IS_IMPORT`, `PIC`, `OLDYEARIN`, `FLAG`, `particular`, `origincode`, `FlagMove`, `AddressMove`, `Copy_of_MOVEDATE`, `MOVEDATE`, `serve`, `serve_doc`, `status_request`, `patient_status`, `kpt`, `shift_release`) " +
                                    //    "VALUES ('AA', NULL, '4', '6', '3', 30, '1/53', 'อำพล', 'จอมแพ่ง', 'พ.ท.0065', 60.010, '1', '10', '1', '0', 0, '1', NULL, NULL, NULL, NULL, NULL, '1989/02/21', 1930100106277, NULL, '3', '006', '2533600065', '', 55308545, '36', '1', 'B', NULL, NULL, '36010093100220', 'B', '360110', '0', NULL, '38/1', '5', '', '', 'อวบ', 'จอมแพ่ง', 'อัมพร', 'จอมแพ่ง', 171, '87/90', '1', 2160, NULL, NULL, '2010-5-2', '0', '2010-5-1', '0000-0-0', 'ข้อมือขวา', 'O', NULL, '100', NULL, 39, NULL, '2010-5-4 10:42:46', 'user', '0', NULL, NULL, 'F', NULL, '1', 'T', '0', '9999-1-1', '2010-7-5', '2.0', '0', NULL, NULL, NULL, '');";

                                    sqlPerson += "INSERT INTO `person` (`STATUSCODE`, `educ`, `BATT`, `COMPANY`, `PLATOON`, `PSEQ`, `YEARIN`, `NAME`, `SNAME`, `ID8`, `PERCENT`, `UNIT1`, `UNIT2`, `POSTCODE`, `UNIT4`, `ITEM`, `UNIT3`, `ASK`, `NUMBER`, `UNIT0`, `REM`, `REM2`, `BIRTHDATE`, `ID13`, `EDUCODE0`, `EDUCODE1`, `EDUCODE2`, `ID`, `ISSCHOOL`, `NAVYID`, `ARMID`, `REGCODE`, `OCCCODE`, `RECIVEEDU1`, `RECIVEEDU2`, `SCHOOLCODE`, `SKILLCODE`, `TOWNCODE`, `SWIMCODE`, `SALCODE`, `ADDRESS`, `ADDRESS_MU`, `ADDRESS_SOIL`, `ADDRESS_ROAD`, `FATHER`, `FSNAME`, `MOTHER`, `MSNAME`, `HEIGHT`, `WIDTH`, `PERTYPE`, `RUNCODE`, `PERCENT1`, `PERSTAT`, `REPDATE`, `ARMSTUDY`, `REGDATE`, `RETIREDATE`, `MARK`, `BLOOD`, `REASON`, `IS_REQUEST`, `SORDER`, `NLABEL`, `NUMBOX`, `RECORDDATE`, `RECORDBY`, `IS_IMPORT`, `PIC`, `OLDYEARIN`, `FLAG`, `particular`, `origincode`, `FlagMove`, `AddressMove`, `Copy_of_MOVEDATE`, `MOVEDATE`, `serve`, `serve_doc`, `status_request`, `patient_status`, `kpt`, `shift_release`) " +
                                         "VALUES (@STATUSCODE, @educ, @BATT, @COMPANY, @PLATOON, @PSEQ, @YEARIN, @NAME, @SNAME, @ID8, @PERCENT, @UNIT1, @UNIT2, @POSTCODE, @UNIT4, @ITEM, @UNIT3, @ASK, @NUMBER, @UNIT0, @REM, @REM2, @BIRTHDATE, @ID13, @EDUCODE0, @EDUCODE1, @EDUCODE2, @ID, @ISSCHOOL, @NAVYID, @ARMID, @REGCODE, @OCCCODE, @RECIVEEDU1, @RECIVEEDU2, @SCHOOLCODE, @SKILLCODE, @TOWNCODE, @SWIMCODE, @SALCODE, @ADDRESS, @ADDRESS_MU, @ADDRESS_SOIL, @ADDRESS_ROAD, @FATHER, @FSNAME, @MOTHER, @MSNAME, @HEIGHT, @WIDTH, @PERTYPE, @RUNCODE, @PERCENT1, @PERSTAT, @REPDATE, @ARMSTUDY, @REGDATE, @RETIREDATE, @MARK, @BLOOD, @REASON, @IS_REQUEST, @SORDER, @NLABEL, @NUMBOX, @RECORDDATE, @RECORDBY, @IS_IMPORT, @PIC, @OLDYEARIN, @FLAG, @particular, @origincode, @FlagMove, @AddressMove, @Copy_of_MOVEDATE, @MOVEDATE, @serve, @serve_doc, @status_request, @patient_status, @kpt, @shift_release);";


                                    MySqlCommand cmd = new MySqlCommand(sqlPerson, con);
                                    string[] columnNames = (from dc in dtPerson.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();
                                    foreach (string cname in columnNames)
                                    {
                                        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                    }

                                    rowsAffect += cmd.ExecuteNonQuery();
                                }



                                string sqlTransDetail = "";
                                foreach (DataRow dr in dtTransDetail.Rows)
                                {
                                    //sqlTransDetail += "INSERT INTO `trans_detail` (`TRANS_NO`, `ID`, `NavyID`, `TRANS_TYPE`, `CODE1`, `Yearin`, `Batt`, `Company`, `Membercode`, `Membercode5`, `Link`, `DOC_DATE`, `START_DATE`, `END_DATE`, `START_DATE_JUDGE`, `END_DATE_JUDGE`, `REMARK`, `REF_NO`, `REF_NO_2`, `PLACE`, `PLACE_JUDGE`, `ECODE1`, `ECODE2`, `OCCSP`, `REASONBK`, `CAUSE_JUDGE`, `INTIME`, `LEAVETIME`, `INYEAR`, `INMONTH`, `INDAY`, `NAMEPPOST`, `LEANAME`, `HOSPITAL`, `SCHOOL`, `PRISON`, `RE_PRISON`, `CEDIT1`, `CEDIT2`, `Flag`, `Num`, `UPDBY`, `UPDDATE`) " +
                                    //"VALUES (22049, '2574000556', 55713859, 'D', 'C', '3/57', '', '', 'A534JDF', '', '', '2015-11-23', '2015-11-6 00:00:00', '2015-11-20 00:00:00', NULL, NULL, NULL, '450/58', NULL, NULL, NULL, NULL, NULL, NULL, '1', NULL, '1', NULL, 0, 0, 14, '', '', NULL, NULL, NULL, NULL, 'ใบรายงานเหตุ', 'แผนกสวัสดิการ กบก.ศฝท.ยศ.ทร.', '0', NULL, 'ple', '2015-11-30 11:38:03');\n";

                                    sqlTransDetail = "INSERT INTO `trans_detail` (";

                                    // get column
                                    string[] columnNames = (from dc in dtTransDetail.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

                                    // generate column to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlTransDetail += "`" + cname + "`,";
                                    }
                                    sqlTransDetail = sqlTransDetail.Remove(sqlTransDetail.Length - 1, 1);
                                    sqlTransDetail += ") \n VALUES \n(";

                                    // generate values to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlTransDetail += "@" + cname + ",";
                                    }
                                    sqlTransDetail = sqlTransDetail.Remove(sqlTransDetail.Length - 1, 1);
                                    sqlTransDetail += ");\n";

                                    MySqlCommand cmd = new MySqlCommand(sqlTransDetail, con);
                                    foreach (string cname in columnNames)
                                    {
                                        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                    }

                                    rowsAffect += cmd.ExecuteNonQuery();
                                }

                                string sqlPunishmentDetail = "";
                                foreach (DataRow dr in dtPunishmentDetail.Rows)
                                {
                                    //sqlPunishmentDetail += "INSERT INTO `punishment_details` (`Punish_No`, `NavyID`, `Trans_Type`, `Code1`, `Batt`, `Company`, `Yearin`, `Membercode`, `Membercode5`, `Link`, `Fine`, `Other`, `Cedit1`, `Cedit2`, `Ref_No`, `Red_No`, `Black_No`, `Doc_Date`, `Trans_No`, `Trans_Note`, `Start_Date`, `End_Date`, `Law_Date`, `Out_Date`, `InYear`, `InMonth`, `InDay`, `InHour`, `Place`, `NamePPost1`, `ShortPpos`, `LeaName1`, `Level`, `NamePPost`, `LeaName`, `Flag`, `Num`, `UpdBy`, `UpdDate`, `ShortName`) " +
                                    //    "VALUES (17, '54703860', 'K', 'A', '', '', '1/47', 'A534JB', '', '', 0, '', 'คำสั่งลงทัณฑ์ทางวินัย', 'A534JBA', 'กห. 0534.8.2/231', '', '', '2005-09-13', 4263, 'ขาดราชการ ครั้งที่ 1 ในเวลาปกติ (กลับเอง)', '2005-09-12', '2005-09-14', '', '', 0, 0, 3, 2, '', 'ผบ. กนร.ศฝท.ยศ.ทร.', 'ผบ.กนร.', 'น.อ.ณัฏฐนันท์  วิเศษสมวงศ์', '4', '', '', '1', '4', 'chy', '2005-12-13 13:06:15', NULL);";

                                    sqlPunishmentDetail = "INSERT INTO `punishment_details` (";

                                    // get column
                                    string[] columnNames = (from dc in dtPunishmentDetail.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

                                    // generate column to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlPunishmentDetail += "`" + cname + "`,";
                                    }
                                    sqlPunishmentDetail = sqlPunishmentDetail.Remove(sqlPunishmentDetail.Length - 1, 1);
                                    sqlPunishmentDetail += ") \n VALUES \n(";

                                    // generate values to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlPunishmentDetail += "@" + cname + ",";
                                    }
                                    sqlPunishmentDetail = sqlPunishmentDetail.Remove(sqlPunishmentDetail.Length - 1, 1);
                                    sqlPunishmentDetail += ");\n";

                                    MySqlCommand cmd = new MySqlCommand(sqlPunishmentDetail, con);
                                    foreach (string cname in columnNames)
                                    {
                                        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                    }

                                    rowsAffect += cmd.ExecuteNonQuery();
                                }

                                string sqlDataOldYearin = "";
                                foreach (DataRow dr in dtDataOldYearin.Rows)
                                {
                                    //sqlDataOldYearin += "INSERT INTO `dataoldyearin` (`ID`, `navyid`, `ONCE`, `COMPANY`, `BATT`, `PLATOON`, `RUNCODE`, `PSEQ`, `YEARIN`, `p_company`, `p_batt`, `p_platoon`, `p_runcode`, `p_pseq`, `p_yearin`, `UPDBY`, `UPDDATE`) " +
                                    //    "VALUES ('2444800002', 54401659, '1', '2', '2', '2', NULL, '04', NULL, '2', '2', '2', NULL, '04', NULL, NULL, '0000-0-0 00:00:00');";

                                    sqlDataOldYearin = "INSERT IN TO `dataoldyearin` (";

                                    // get column
                                    string[] columnNames = (from dc in dtDataOldYearin.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

                                    // generate column to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlDataOldYearin += "`" + cname + "`,";
                                    }
                                    sqlDataOldYearin = sqlDataOldYearin.Remove(sqlDataOldYearin.Length - 1, 1);
                                    sqlDataOldYearin += ") \n VALUES \n(";

                                    // generate values to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlDataOldYearin += "@" + cname + ",";
                                    }
                                    sqlDataOldYearin = sqlDataOldYearin.Remove(sqlDataOldYearin.Length - 1, 1);
                                    sqlDataOldYearin += ");\n";

                                    MySqlCommand cmd = new MySqlCommand(sqlDataOldYearin, con);
                                    foreach (string cname in columnNames)
                                    {
                                        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                    }

                                    rowsAffect += cmd.ExecuteNonQuery();
                                }

                                //====== Move Indictment ======
                                //string sqlIndictmentDetail = "";
                                //foreach (DataRow dr in dtIndicment.Rows)
                                //{
                                //    //sqlPunishmentDetail += "INSERT INTO `punishment_details` (`Punish_No`, `NavyID`, `Trans_Type`, `Code1`, `Batt`, `Company`, `Yearin`, `Membercode`, `Membercode5`, `Link`, `Fine`, `Other`, `Cedit1`, `Cedit2`, `Ref_No`, `Red_No`, `Black_No`, `Doc_Date`, `Trans_No`, `Trans_Note`, `Start_Date`, `End_Date`, `Law_Date`, `Out_Date`, `InYear`, `InMonth`, `InDay`, `InHour`, `Place`, `NamePPost1`, `ShortPpos`, `LeaName1`, `Level`, `NamePPost`, `LeaName`, `Flag`, `Num`, `UpdBy`, `UpdDate`, `ShortName`) " +
                                //    //    "VALUES (17, '54703860', 'K', 'A', '', '', '1/47', 'A534JB', '', '', 0, '', 'คำสั่งลงทัณฑ์ทางวินัย', 'A534JBA', 'กห. 0534.8.2/231', '', '', '2005-09-13', 4263, 'ขาดราชการ ครั้งที่ 1 ในเวลาปกติ (กลับเอง)', '2005-09-12', '2005-09-14', '', '', 0, 0, 3, 2, '', 'ผบ. กนร.ศฝท.ยศ.ทร.', 'ผบ.กนร.', 'น.อ.ณัฏฐนันท์  วิเศษสมวงศ์', '4', '', '', '1', '4', 'chy', '2005-12-13 13:06:15', NULL);";

                                //    sqlIndictmentDetail = "INSERT INTO `indictmenttab` (";

                                //    // get column
                                //    string[] columnNames = (from dc in dtIndicment.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

                                //    // generate column to insert 
                                //    foreach (string cname in columnNames)
                                //    {
                                //        sqlIndictmentDetail += "`" + cname + "`,";
                                //    }
                                //    sqlIndictmentDetail = sqlIndictmentDetail.Remove(sqlIndictmentDetail.Length - 1, 1);
                                //    sqlIndictmentDetail += ") \n VALUES \n(";

                                //    // generate values to insert 
                                //    foreach (string cname in columnNames)
                                //    {
                                //        sqlIndictmentDetail += "@" + cname + ",";
                                //    }
                                //    sqlIndictmentDetail = sqlIndictmentDetail.Remove(sqlIndictmentDetail.Length - 1, 1);
                                //    sqlIndictmentDetail += ");\n";

                                //    MySqlCommand cmd = new MySqlCommand(sqlIndictmentDetail, con);
                                //    foreach (string cname in columnNames)
                                //    {
                                //        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                //    }

                                //    rowsAffect += cmd.ExecuteNonQuery();
                                //}

                                dcoreNav.closeConnection();
                            }

                            //// // ** temp comment ** // // 

                            ////delete data from NavBD_all
                            //string sqlDelete = "";
                            //sqlDelete += "DELETE FROM person WHERE NAVYID = '" + navyid + "';\n";
                            //sqlDelete += "DELETE FROM trans_detail WHERE NAVYID = '" + navyid + "';\n";
                            //sqlDelete += "DELETE FROM punishment_details WHERE NAVYID = '" + navyid + "';\n";
                            //sqlDelete += "DELETE FROM dataoldyearin WHERE NAVYID = '" + navyid + "';\n";

                            //string result1 = "";
                            //DBConnection.runCmdTransaction(sqlDelete, dcoreNavAll.getConnection(), out result1);
                            //if (result1 != "OK")
                            //{
                            //    MessageBox.Show("มีปัญหาในการลบข้อมูล กรุณาติดต่อ ผู้ดูแลระบบโดยด่วน!! " + result1);
                            //    return;
                            //}

                            MessageBox.Show("คัดลอกข้อมูลเรียบร้อย");
                            Search();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดพลาดในการทำรายการ .. " + ex.Message);
                        if (rowsAffect > 0)
                        {
                            //rollback
                            string sqlDelete = "";
                            sqlDelete += "DELETE FROM person WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM trans_detail WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM punishment_details WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM dataoldyearin WHERE NAVYID = '" + navyid + "';\n";
                           // sqlDelete += "DELETE FROM indictmenttab WHERE NavyID = '" + navyid + "';\n";
                            string result1 = "";
                            dcoreNav.closeConnection();
                            DBConnection.runCmdTransaction(sqlDelete, dcoreNav.getConnection(), out result1);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกข้อมูลก่อน");
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อน");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("ต้องการลบข้อมูล การร้องขอนี้ ใช่หรือไม่", "ลบข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();
                        string askby = gvResult.SelectedRows[0].Cells["askby"].Value.ToString();
                        string unit = gvResult.SelectedRows[0].Cells["unit"].Value.ToString();

                        if (dcoreNav.DeletePersonRequest(navyid,askby,unit))
                        {
                            gvResult.Rows.Remove(gvResult.SelectedRows[0]);
                            MessageBox.Show("ลบข้อมูลเรียบร้อย");
                            Search();
                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถลบข้อมูลได้");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดพลาดในการลบข้อมูล .. " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูล ก่อนทำการลบ");
            }
        }

        private void gvResult_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void gvResult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gvResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnSubmit_Click(sender, e);
                //e.Handled = true;

                if (gvResult.SelectedRows.Count > 0)
                {
                    string navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();

                    //change con string for get person detail
                    string OldConString = Constants.currentConString;
                    if (rbAddNew.Checked)
                    {
                        Constants.currentConString = dcoreNav.getConnection().ConnectionString;
                    }
                    else if (rbEditOrDelete.Checked)
                    {
                        Constants.currentConString = dcoreNavAll.getConnection().ConnectionString;
                    }

                    AddNewPersonForm f = new AddNewPersonForm(navyid);
                    f.SetbtnSubmitAndNewVisible(false);
                    f.SetbtnSubmitVisible(false);
                    f.ShowDialog();

                    //rollback con string
                    Constants.currentConString = OldConString;
                }
            }

            if (e.KeyCode == Keys.Delete)
            {

            }
        }

        private void gvResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                string navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();

                //change con string for get person detail
                string OldConString = Constants.currentConString;
                if(rbAddNew.Checked)
                {
                    Constants.currentConString = dcoreNav.getConnection().ConnectionString;
                }
                else if(rbEditOrDelete.Checked)
                {
                    Constants.currentConString = dcoreNavAll.getConnection().ConnectionString;
                }

                AddNewPersonForm f = new AddNewPersonForm(navyid);
                f.SetbtnSubmitAndNewVisible(false);
                f.SetbtnSubmitVisible(false);
                f.ShowDialog();

                //rollback con string
                Constants.currentConString = OldConString;
            }            
        }

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
        #endregion

        #region KeyPress Enter Event
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
            mtxtYearin.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            mTextBoxID8.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxName.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
            textBoxSname.KeyDown += new KeyEventHandler(EventEnterKeyForNextControl);
        }
        #endregion

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("ต้องการย้ายข้อมูลนี้ไปยังฐานข้อมูลทหารใหม่ ใช่หรือไม่", "ย้ายข้อมูล", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int rowsAffect = 0;
                    string navyid = gvResult.SelectedRows[0].Cells["navyid"].Value.ToString();
                    try
                    {
                        if (rbAddNew.Checked)
                        {
                            //no action
                            MessageBox.Show("ยังไม่มีฟังก์ชั่นการทำงานรองรับในส่วนนี้");
                        }
                        else if (rbEditOrDelete.Checked)
                        {
                            //get data from [person] [trans_detail], [punishment_detail], [dataoldyearin]
                            using (MySql.Data.MySqlClient.MySqlConnection con = dcoreNavAll.getConnection())
                            {
                                dcoreNavAll.openConnection();
                                dtPerson = new DataTable();
                                dtTransDetail = new DataTable();
                                dtPunishmentDetail = new DataTable();
                                dtDataOldYearin = new DataTable();
                               // dtIndicment = new DataTable();

                                dtPerson.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM person WHERE NAVYID = '" + navyid + "';", con)).ExecuteReader());
                                dtTransDetail.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM trans_detail WHERE NAVYID = '" + navyid + "';", con)).ExecuteReader());
                                dtPunishmentDetail.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM punishment_details WHERE NAVYID = '" + navyid + "';", con)).ExecuteReader());
                                dtDataOldYearin.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM dataoldyearin WHERE NAVYID = '" + navyid + "';", con)).ExecuteReader());
                               // dtIndicment.Load((new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM indictmenttab WHERE NavyID = '" + navyid + "';", con)).ExecuteReader());

                                dcoreNavAll.closeConnection();
                            }

                            //insert data to NavDB
                            using (MySql.Data.MySqlClient.MySqlConnection con = dcoreNav.getConnection())
                            {
                                dcoreNav.openConnection();

                                string sqlPerson = "";
                                foreach (DataRow dr in dtPerson.Rows)
                                {
                                    //sqlPerson += "INSERT INTO `person` (`STATUSCODE`, `educ`, `BATT`, `COMPANY`, `PLATOON`, `PSEQ`, `YEARIN`, `NAME`, `SNAME`, `ID8`, `PERCENT`, `UNIT1`, `UNIT2`, `POSTCODE`, `UNIT4`, `ITEM`, `UNIT3`, `ASK`, `NUMBER`, `UNIT0`, `REM`, `REM2`, `BIRTHDATE`, `ID13`, `EDUCODE0`, `EDUCODE1`, `EDUCODE2`, `ID`, `ISSCHOOL`, `NAVYID`, `ARMID`, `REGCODE`, `OCCCODE`, `RECIVEEDU1`, `RECIVEEDU2`, `SCHOOLCODE`, `SKILLCODE`, `TOWNCODE`, `SWIMCODE`, `SALCODE`, `ADDRESS`, `ADDRESS_MU`, `ADDRESS_SOIL`, `ADDRESS_ROAD`, `FATHER`, `FSNAME`, `MOTHER`, `MSNAME`, `HEIGHT`, `WIDTH`, `PERTYPE`, `RUNCODE`, `PERCENT1`, `PERSTAT`, `REPDATE`, `ARMSTUDY`, `REGDATE`, `RETIREDATE`, `MARK`, `BLOOD`, `REASON`, `IS_REQUEST`, `SORDER`, `NLABEL`, `NUMBOX`, `RECORDDATE`, `RECORDBY`, `IS_IMPORT`, `PIC`, `OLDYEARIN`, `FLAG`, `particular`, `origincode`, `FlagMove`, `AddressMove`, `Copy_of_MOVEDATE`, `MOVEDATE`, `serve`, `serve_doc`, `status_request`, `patient_status`, `kpt`, `shift_release`) " +
                                    //    "VALUES ('AA', NULL, '4', '6', '3', 30, '1/53', 'อำพล', 'จอมแพ่ง', 'พ.ท.0065', 60.010, '1', '10', '1', '0', 0, '1', NULL, NULL, NULL, NULL, NULL, '1989/02/21', 1930100106277, NULL, '3', '006', '2533600065', '', 55308545, '36', '1', 'B', NULL, NULL, '36010093100220', 'B', '360110', '0', NULL, '38/1', '5', '', '', 'อวบ', 'จอมแพ่ง', 'อัมพร', 'จอมแพ่ง', 171, '87/90', '1', 2160, NULL, NULL, '2010-5-2', '0', '2010-5-1', '0000-0-0', 'ข้อมือขวา', 'O', NULL, '100', NULL, 39, NULL, '2010-5-4 10:42:46', 'user', '0', NULL, NULL, 'F', NULL, '1', 'T', '0', '9999-1-1', '2010-7-5', '2.0', '0', NULL, NULL, NULL, '');";

                                    sqlPerson += "INSERT INTO `person` (`STATUSCODE`, `educ`, `BATT`, `COMPANY`, `PLATOON`, `PSEQ`, `YEARIN`, `NAME`, `SNAME`, `ID8`, `PERCENT`, `UNIT1`, `UNIT2`, `POSTCODE`, `UNIT4`, `ITEM`, `UNIT3`, `ASK`, `NUMBER`, `UNIT0`, `REM`, `REM2`, `BIRTHDATE`, `ID13`, `EDUCODE0`, `EDUCODE1`, `EDUCODE2`, `ID`, `ISSCHOOL`, `NAVYID`, `ARMID`, `REGCODE`, `OCCCODE`, `RECIVEEDU1`, `RECIVEEDU2`, `SCHOOLCODE`, `SKILLCODE`, `TOWNCODE`, `SWIMCODE`, `SALCODE`, `ADDRESS`, `ADDRESS_MU`, `ADDRESS_SOIL`, `ADDRESS_ROAD`, `FATHER`, `FSNAME`, `MOTHER`, `MSNAME`, `HEIGHT`, `WIDTH`, `PERTYPE`, `RUNCODE`, `PERCENT1`, `PERSTAT`, `REPDATE`, `ARMSTUDY`, `REGDATE`, `RETIREDATE`, `MARK`, `BLOOD`, `REASON`, `IS_REQUEST`, `SORDER`, `NLABEL`, `NUMBOX`, `RECORDDATE`, `RECORDBY`, `IS_IMPORT`, `PIC`, `OLDYEARIN`, `FLAG`, `particular`, `origincode`, `FlagMove`, `AddressMove`, `Copy_of_MOVEDATE`, `MOVEDATE`, `serve`, `serve_doc`, `status_request`, `patient_status`, `kpt`, `shift_release`) " +
                                         "VALUES (@STATUSCODE, @educ, @BATT, @COMPANY, @PLATOON, @PSEQ, @YEARIN, @NAME, @SNAME, @ID8, @PERCENT, @UNIT1, @UNIT2, @POSTCODE, @UNIT4, @ITEM, @UNIT3, @ASK, @NUMBER, @UNIT0, @REM, @REM2, @BIRTHDATE, @ID13, @EDUCODE0, @EDUCODE1, @EDUCODE2, @ID, @ISSCHOOL, @NAVYID, @ARMID, @REGCODE, @OCCCODE, @RECIVEEDU1, @RECIVEEDU2, @SCHOOLCODE, @SKILLCODE, @TOWNCODE, @SWIMCODE, @SALCODE, @ADDRESS, @ADDRESS_MU, @ADDRESS_SOIL, @ADDRESS_ROAD, @FATHER, @FSNAME, @MOTHER, @MSNAME, @HEIGHT, @WIDTH, @PERTYPE, @RUNCODE, @PERCENT1, @PERSTAT, @REPDATE, @ARMSTUDY, @REGDATE, @RETIREDATE, @MARK, @BLOOD, @REASON, @IS_REQUEST, @SORDER, @NLABEL, @NUMBOX, @RECORDDATE, @RECORDBY, @IS_IMPORT, @PIC, @OLDYEARIN, @FLAG, @particular, @origincode, @FlagMove, @AddressMove, @Copy_of_MOVEDATE, @MOVEDATE, @serve, @serve_doc, @status_request, @patient_status, @kpt, @shift_release);";


                                    MySqlCommand cmd = new MySqlCommand(sqlPerson, con);
                                    string[] columnNames = (from dc in dtPerson.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();
                                    foreach (string cname in columnNames)
                                    {
                                        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                    }

                                    rowsAffect += cmd.ExecuteNonQuery();
                                }



                                string sqlTransDetail = "";
                                foreach (DataRow dr in dtTransDetail.Rows)
                                {
                                    //sqlTransDetail += "INSERT INTO `trans_detail` (`TRANS_NO`, `ID`, `NavyID`, `TRANS_TYPE`, `CODE1`, `Yearin`, `Batt`, `Company`, `Membercode`, `Membercode5`, `Link`, `DOC_DATE`, `START_DATE`, `END_DATE`, `START_DATE_JUDGE`, `END_DATE_JUDGE`, `REMARK`, `REF_NO`, `REF_NO_2`, `PLACE`, `PLACE_JUDGE`, `ECODE1`, `ECODE2`, `OCCSP`, `REASONBK`, `CAUSE_JUDGE`, `INTIME`, `LEAVETIME`, `INYEAR`, `INMONTH`, `INDAY`, `NAMEPPOST`, `LEANAME`, `HOSPITAL`, `SCHOOL`, `PRISON`, `RE_PRISON`, `CEDIT1`, `CEDIT2`, `Flag`, `Num`, `UPDBY`, `UPDDATE`) " +
                                    //"VALUES (22049, '2574000556', 55713859, 'D', 'C', '3/57', '', '', 'A534JDF', '', '', '2015-11-23', '2015-11-6 00:00:00', '2015-11-20 00:00:00', NULL, NULL, NULL, '450/58', NULL, NULL, NULL, NULL, NULL, NULL, '1', NULL, '1', NULL, 0, 0, 14, '', '', NULL, NULL, NULL, NULL, 'ใบรายงานเหตุ', 'แผนกสวัสดิการ กบก.ศฝท.ยศ.ทร.', '0', NULL, 'ple', '2015-11-30 11:38:03');\n";

                                    sqlTransDetail = "INSERT INTO `trans_detail` (";

                                    // get column
                                    string[] columnNames = (from dc in dtTransDetail.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

                                    // generate column to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlTransDetail += "`" + cname + "`,";
                                    }
                                    sqlTransDetail = sqlTransDetail.Remove(sqlTransDetail.Length - 1, 1);
                                    sqlTransDetail += ") \n VALUES \n(";

                                    // generate values to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlTransDetail += "@" + cname + ",";
                                    }
                                    sqlTransDetail = sqlTransDetail.Remove(sqlTransDetail.Length - 1, 1);
                                    sqlTransDetail += ");\n";

                                    MySqlCommand cmd = new MySqlCommand(sqlTransDetail, con);
                                    foreach (string cname in columnNames)
                                    {
                                        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                    }

                                    rowsAffect += cmd.ExecuteNonQuery();
                                }

                                string sqlPunishmentDetail = "";
                                foreach (DataRow dr in dtPunishmentDetail.Rows)
                                {
                                    //sqlPunishmentDetail += "INSERT INTO `punishment_details` (`Punish_No`, `NavyID`, `Trans_Type`, `Code1`, `Batt`, `Company`, `Yearin`, `Membercode`, `Membercode5`, `Link`, `Fine`, `Other`, `Cedit1`, `Cedit2`, `Ref_No`, `Red_No`, `Black_No`, `Doc_Date`, `Trans_No`, `Trans_Note`, `Start_Date`, `End_Date`, `Law_Date`, `Out_Date`, `InYear`, `InMonth`, `InDay`, `InHour`, `Place`, `NamePPost1`, `ShortPpos`, `LeaName1`, `Level`, `NamePPost`, `LeaName`, `Flag`, `Num`, `UpdBy`, `UpdDate`, `ShortName`) " +
                                    //    "VALUES (17, '54703860', 'K', 'A', '', '', '1/47', 'A534JB', '', '', 0, '', 'คำสั่งลงทัณฑ์ทางวินัย', 'A534JBA', 'กห. 0534.8.2/231', '', '', '2005-09-13', 4263, 'ขาดราชการ ครั้งที่ 1 ในเวลาปกติ (กลับเอง)', '2005-09-12', '2005-09-14', '', '', 0, 0, 3, 2, '', 'ผบ. กนร.ศฝท.ยศ.ทร.', 'ผบ.กนร.', 'น.อ.ณัฏฐนันท์  วิเศษสมวงศ์', '4', '', '', '1', '4', 'chy', '2005-12-13 13:06:15', NULL);";

                                    sqlPunishmentDetail = "INSERT INTO `punishment_details` (";

                                    // get column
                                    string[] columnNames = (from dc in dtPunishmentDetail.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

                                    // generate column to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlPunishmentDetail += "`" + cname + "`,";
                                    }
                                    sqlPunishmentDetail = sqlPunishmentDetail.Remove(sqlPunishmentDetail.Length - 1, 1);
                                    sqlPunishmentDetail += ") \n VALUES \n(";

                                    // generate values to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlPunishmentDetail += "@" + cname + ",";
                                    }
                                    sqlPunishmentDetail = sqlPunishmentDetail.Remove(sqlPunishmentDetail.Length - 1, 1);
                                    sqlPunishmentDetail += ");\n";

                                    MySqlCommand cmd = new MySqlCommand(sqlPunishmentDetail, con);
                                    foreach (string cname in columnNames)
                                    {
                                        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                    }

                                    rowsAffect += cmd.ExecuteNonQuery();
                                }

                                string sqlDataOldYearin = "";
                                foreach (DataRow dr in dtDataOldYearin.Rows)
                                {
                                    //sqlDataOldYearin += "INSERT INTO `dataoldyearin` (`ID`, `navyid`, `ONCE`, `COMPANY`, `BATT`, `PLATOON`, `RUNCODE`, `PSEQ`, `YEARIN`, `p_company`, `p_batt`, `p_platoon`, `p_runcode`, `p_pseq`, `p_yearin`, `UPDBY`, `UPDDATE`) " +
                                    //    "VALUES ('2444800002', 54401659, '1', '2', '2', '2', NULL, '04', NULL, '2', '2', '2', NULL, '04', NULL, NULL, '0000-0-0 00:00:00');";

                                    sqlDataOldYearin = "INSERT IN TO `dataoldyearin` (";

                                    // get column
                                    string[] columnNames = (from dc in dtDataOldYearin.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

                                    // generate column to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlDataOldYearin += "`" + cname + "`,";
                                    }
                                    sqlDataOldYearin = sqlDataOldYearin.Remove(sqlDataOldYearin.Length - 1, 1);
                                    sqlDataOldYearin += ") \n VALUES \n(";

                                    // generate values to insert 
                                    foreach (string cname in columnNames)
                                    {
                                        sqlDataOldYearin += "@" + cname + ",";
                                    }
                                    sqlDataOldYearin = sqlDataOldYearin.Remove(sqlDataOldYearin.Length - 1, 1);
                                    sqlDataOldYearin += ");\n";

                                    MySqlCommand cmd = new MySqlCommand(sqlDataOldYearin, con);
                                    foreach (string cname in columnNames)
                                    {
                                        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                    }

                                    rowsAffect += cmd.ExecuteNonQuery();
                                }

                                //====== Move Indictment ======
                                //string sqlIndictmentDetail = "";
                                //foreach (DataRow dr in dtIndicment.Rows)
                                //{
                                //    //sqlPunishmentDetail += "INSERT INTO `punishment_details` (`Punish_No`, `NavyID`, `Trans_Type`, `Code1`, `Batt`, `Company`, `Yearin`, `Membercode`, `Membercode5`, `Link`, `Fine`, `Other`, `Cedit1`, `Cedit2`, `Ref_No`, `Red_No`, `Black_No`, `Doc_Date`, `Trans_No`, `Trans_Note`, `Start_Date`, `End_Date`, `Law_Date`, `Out_Date`, `InYear`, `InMonth`, `InDay`, `InHour`, `Place`, `NamePPost1`, `ShortPpos`, `LeaName1`, `Level`, `NamePPost`, `LeaName`, `Flag`, `Num`, `UpdBy`, `UpdDate`, `ShortName`) " +
                                //    //    "VALUES (17, '54703860', 'K', 'A', '', '', '1/47', 'A534JB', '', '', 0, '', 'คำสั่งลงทัณฑ์ทางวินัย', 'A534JBA', 'กห. 0534.8.2/231', '', '', '2005-09-13', 4263, 'ขาดราชการ ครั้งที่ 1 ในเวลาปกติ (กลับเอง)', '2005-09-12', '2005-09-14', '', '', 0, 0, 3, 2, '', 'ผบ. กนร.ศฝท.ยศ.ทร.', 'ผบ.กนร.', 'น.อ.ณัฏฐนันท์  วิเศษสมวงศ์', '4', '', '', '1', '4', 'chy', '2005-12-13 13:06:15', NULL);";

                                //    sqlIndictmentDetail = "INSERT INTO `indictmenttab` (";

                                //    // get column
                                //    string[] columnNames = (from dc in dtIndicment.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();

                                //    // generate column to insert 
                                //    foreach (string cname in columnNames)
                                //    {
                                //        sqlIndictmentDetail += "`" + cname + "`,";
                                //    }
                                //    sqlIndictmentDetail = sqlIndictmentDetail.Remove(sqlIndictmentDetail.Length - 1, 1);
                                //    sqlIndictmentDetail += ") \n VALUES \n(";

                                //    // generate values to insert 
                                //    foreach (string cname in columnNames)
                                //    {
                                //        sqlIndictmentDetail += "@" + cname + ",";
                                //    }
                                //    sqlIndictmentDetail = sqlIndictmentDetail.Remove(sqlIndictmentDetail.Length - 1, 1);
                                //    sqlIndictmentDetail += ");\n";

                                //    MySqlCommand cmd = new MySqlCommand(sqlIndictmentDetail, con);
                                //    foreach (string cname in columnNames)
                                //    {
                                //        cmd.Parameters.AddWithValue("@" + cname, dr[cname] == null ? null : dr[cname]);
                                //    }

                                //    rowsAffect += cmd.ExecuteNonQuery();
                                //}

                                dcoreNav.closeConnection();
                            }

                            //// // ** temp comment ** // // 

                            //delete data from NavBD_all
                            string sqlDelete = "";
                            sqlDelete += "DELETE FROM person WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM trans_detail WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM punishment_details WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM dataoldyearin WHERE NAVYID = '" + navyid + "';\n";
                            //sqlDelete += "DELETE FROM indictmenttab WHERE NavyID = '" + navyid + "';\n";

                            string result1 = "";
                            DBConnection.runCmdTransaction(sqlDelete, dcoreNavAll.getConnection(), out result1);
                            if (result1 != "OK")
                            {
                                MessageBox.Show("มีปัญหาในการลบข้อมูล กรุณาติดต่อ ผู้ดูแลระบบโดยด่วน!! " + result1);
                                return;
                            }

                            MessageBox.Show("ย้ายข้อมูลเรียบร้อย");
                            Search();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดพลาดในการทำรายการ .. " + ex.Message);
                        if (rowsAffect > 0)
                        {
                            //rollback
                            string sqlDelete = "";
                            sqlDelete += "DELETE FROM person WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM trans_detail WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM punishment_details WHERE NAVYID = '" + navyid + "';\n";
                            sqlDelete += "DELETE FROM dataoldyearin WHERE NAVYID = '" + navyid + "';\n";
                            //sqlDelete += "DELETE FROM indictmenttab WHERE NavyID = '" + navyid + "';\n";

                            string result1 = "";
                            dcoreNav.closeConnection();
                            DBConnection.runCmdTransaction(sqlDelete, dcoreNav.getConnection(), out result1);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกข้อมูลก่อน");
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อน");
            }
        }
    }
}
