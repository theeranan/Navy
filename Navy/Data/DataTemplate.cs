using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using Navy.Core;

namespace Navy.Data.DataTemplate
{
    public struct LimitMySQL
    {
        public int limit1;
        public int limit2;
    }

    public struct NavyRunNumber
    {
        public string batt;
        public string company;
        public string platoon;
        public string pseq;
        public string towname;
    }

    public struct DataTab
    {
        public DataTable _dtArmtown;
        public DataTable _dtAskBy;
        public DataTable _dtAskByNUM;
        public DataTable _dtOrigin;
        public DataTable _dtOccTab;
        public DataTable _dtMemberCode;
        public DataTable _dtStatusTab;
        public DataTable _dtGroupTab;
        public DataTable _dtPerTypeTab;
        public DataTable _dtUnitTab;
        public DataTable _dtkptclass;
        public DataTable _dtUnitaddressmoveTab;
        public DataTable _dtstatus_move;
        public DataTable _dtDocTab;
        public DataTable _dtStructure;
        public DataTable _dtReligion;
        public DataTable _dtEducTab;
        public DataTable _dtTownnameLV2LV3;
        public DataTable _dtTownnameLV1;
        public DataTable _dtTownnameLV2;
        public DataTable _dtTownnameLV3;
        public DataTable _dtPostcode;
        public DataTable _dtSubUnitTab;
        public DataTable _dtPatient_status;
        public DataTable _dtAddictive_status;
        public DataTable _dtSkillTab;
        public DataTable _dtbanktab;
    }

    public struct ParamPersonRequest
    {
        public string navyid;
        public string unit;
        public string askby;
        public string num;
        public string remark;
        public string remark2;
        public string flag;
        public DateTime upddate;
        public string piority;
        public string username;
        public int updatecount;
    }

    public class ParamSearchPerson
    {
        public string yearin;
        public string id13;
        public string name;
        public string sname;
        public string id8;
        public string batt;
        public string company;
        public string runcode;

        public ParamSearchPerson()
        {
            yearin = "";
            id13 = "";
            name = "";
            sname = "";
            id8 = "";
            batt = "";
            company = "";
            runcode = "";
        }
    }

    public class InputSearchPersonNivy
    {
        public string id13 { get; set; }
        public string name { get; set; }
        public string sname { get; set; }
        public string yearBD { get; set; }

        public InputSearchPersonNivy()
        {
            this.id13 = "";
            this.name = "";
            this.sname = "";
            this.yearBD = "";
        }

        public InputSearchPersonNivy(string id13, string name, string sname, string yearBD)
        {
            this.id13 = id13;
            this.name = name;
            this.sname = sname;
            this.yearBD = yearBD;
        }

        public bool CheckSameValue(InputSearchPersonNivy objectToCheck)
        {
            if (this.id13 != objectToCheck.id13)
            { return false; }

            if (this.name != objectToCheck.name)
            { return false; }

            if (this.sname != objectToCheck.sname)
            { return false; }

            if (this.yearBD != objectToCheck.yearBD)
            { return false; }

            return true;
        }
    }

    public class PersonNavy
    {
        [DisplayName("เลขประจำตัวประชาชน")]
        public string pid { get; set; }
        [DisplayName("ชื่อ")]
        public string fname { get; set; }
        [DisplayName("นามสกุล")]
        public string lname { get; set; }
        [DisplayName("วันเกิด")]
        public string birthdate { get; set; }
        [Browsable(false)]
        public string dob_d { get; set; }
        [Browsable(false)]
        public string dob_m { get; set; }
        [Browsable(false)]
        public string dob_y { get; set; }
        [DisplayName("แผลเป็น")]
        public string scare { get; set; }
        [DisplayName("ที่อยู่")]
        public string m_home { get; set; }
        [DisplayName("รหัสที่อยู่")]
        public string m_tt { get; set; }
        [DisplayName("การศึกษา")]
        public string educate { get; set; }
        [DisplayName("อาชีพ")]
        public string employment { get; set; }
        [DisplayName("ศาสนา")]
        public string region { get; set; }
        [DisplayName("ชื่อบิดา")]
        public string faname { get; set; }
        [DisplayName("นามสกุลบิดา")]
        public string fa_sname { get; set; }
        [DisplayName("ชื่อมารดา")]
        public string maname { get; set; }
        [DisplayName("นามสกุลมารดา")]
        public string ma_sname { get; set; }
        [DisplayName("ส่วนสูง")]
        public string tall { get; set; }
        [DisplayName("น้ำหนัก")]
        public string weight { get; set; }
        [DisplayName("รอบอก(หายใจเข้า)")]
        public string chess_in { get; set; }
        [DisplayName("วันเกิด(หายใจออก)")]
        public string chess_out { get; set; }
        [DisplayName("หมู่เลือด")]
        public string blood { get; set; }
        public string sd43_year { get; set; }
        [DisplayName("รหัสประเภทเข้าประจำการ")]
        public string recruit_code { get; set; }
        public string recruit_mean { get; set; }
        public string recruit_note { get; set; }

        public string address_home { get; set; }
        public string address_mu { get; set; }
        public string address_soy { get; set; }
        public string address_road { get; set; }
        public string telephone { get; set; }
        public string ftelephone { get; set; }
        public string mtelephone { get; set; }
        public string ptelephone { get; set; }

        public PersonNavy()
        {

        }

        public PersonNavy(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            pid = reader["PID"].ToString();
            fname = reader["FNAME"].ToString();
            lname = reader["LNAME"].ToString();
            dob_d = reader["DOB_D"].ToString();
            dob_m = reader["DOB_M"].ToString();
            dob_y = reader["DOB_Y"].ToString();
            scare = reader["SCARE"].ToString();
            m_home = reader["M_HOME"].ToString();
            m_tt = reader["M_TT"].ToString();
            educate = reader["EDUCATE"].ToString();
            employment = reader["EMPLOYMENT"].ToString();
            region = reader["REGION"].ToString();
            faname = reader["FANAME"].ToString();
            fa_sname = reader["FA_SNAME"].ToString();
            maname = reader["MANAME"].ToString();
            ma_sname = reader["MA_SNAME"].ToString();
            tall = reader["TALL"].ToString();
            weight = reader["WEIGHT"].ToString();
            chess_in = reader["CHESS_IN"].ToString();
            chess_out = reader["CHESS_OUT"].ToString();
            blood = reader["BLOOD"].ToString();
            sd43_year = reader["SD43_YEAR"].ToString();
            recruit_code = reader["RECRUIT_CODE"].ToString();
            recruit_mean = reader["RECRUIT_MEAN"].ToString();
            recruit_note = reader["RECRUIT_NOTE"].ToString();

            //birthdate = reader["BIRTHDATE"].ToString();
            //address_home = reader["ADDRESS_HOME"].ToString();
            //address_mu = reader["ADDRESS_MU"].ToString();
            //address_soy = reader["ADDRESS_SOY"].ToString();
            //address_road = reader["ADDRESS_ROAD"].ToString();

            birthdate = dob_d + "/" + dob_m + "/" + dob_y;
            address_home = reader["ADDRESS_HOME"].ToString();
            address_mu = reader["ADDRESS_MU"].ToString();
            address_soy = reader["ADDRESS_SOY"].ToString();
            address_road = reader["ADDRESS_ROAD"].ToString();
            //telephone = reader["Telephone"].ToString();
            //ftelephone = reader["FTelephone"].ToString();
            //mtelephone = reader["MTelephone"].ToString();
            //ptelephone = reader["PTelephone"].ToString();
        }
    }

    public class ParamPerson
    {
        public string navyid { get; set; }
        public string yearin { get; set; }
        public string armid { get; set; }
        public DateTime regDate { get; set; }
        public string regDateStringAD()
        {
            return Core.Function.IsBuddhistYear(regDate.Year) ? new DateTime(regDate.Year + 543, regDate.Month, regDate.Day).ToString("yyyy-MM-dd") : regDate.Date.ToString("yyyy-MM-dd");
        }
        public DateTime repDate { get; set; }
        public string repDateStringAD()
        {
            return Core.Function.IsBuddhistYear(repDate.Year) ? new DateTime(repDate.Year + 543, repDate.Month, repDate.Day).ToString("yyyy-MM-dd") : repDate.Date.ToString("yyyy-MM-dd");
        }
        public string origincode { get; set; }
        public string id13 { get; set; }
        public string name { get; set; }
        public string sname { get; set; }
        public string birthdate { get; set; }
        public string address { get; set; }
        public string address_mu { get; set; }
        public string address_soil { get; set; }
        public string address_road { get; set; }
        public string towncode { get; set; }
        public string father { get; set; }
        public string fsname { get; set; }
        public string mother { get; set; }
        public string msname { get; set; }
        public string pertype { get; set; }
        public string runcode { get; set; }
        public string id8 { get; set; }
        public string id { get; set; }
        public string mark { get; set; }
        public string educode0 { get; set; }
        public string educode1 { get; set; }
        public string educode2 { get; set; }
        public string regcode { get; set; }
        public string occcode { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public string is_request { get; set; }
        public string batt { get; set; }
        public string company { get; set; }
        public string platoon { get; set; }
        public string pseq { get; set; }
        public string skill { get; set; }
        public string telephone { get; set; }
        public string ftelephone { get; set; }
        public string mtelephone { get; set; }
        public string ptelephone { get; set; }
        public string percent { get; set; }
        public string cmBoxkpt { get; set; }
        public string cmbPatient_status { get; set; }
        public string cmbAddictive_status { get; set; }
        public string flagreadfrom_IDCard { get; set; }
        public string runcodefrom { get; set; }
        public string runcodeto { get; set; }
        public string BankID { get; set; }
        public string AccountNum { get; set; }
        public ParamPerson()
        {

        }

        public ParamPerson(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            navyid = reader["navyid"].ToString();
            yearin = reader["yearin"].ToString();
            armid = reader["armid"].ToString();
            regDate = DateTime.Parse(reader["regDate"].ToString());
            repDate = DateTime.Parse(reader["repDate"].ToString());
            origincode = reader["origincode"].ToString();

            id13 = reader["id13"].ToString();
            name = reader["name"].ToString();
            sname = reader["sname"].ToString();
            birthdate = reader["birthdate"].ToString();
            address = reader["address"].ToString();
            address_mu = reader["address_mu"].ToString();
            address_soil = reader["address_soil"].ToString();
            address_road = reader["address_road"].ToString();
            towncode = reader["towncode"].ToString();
            father = reader["father"].ToString();
            fsname = reader["fsname"].ToString();
            mother = reader["mother"].ToString();
            msname = reader["msname"].ToString();
            pertype = reader["pertype"].ToString();
            runcode = reader["runcode"].ToString();
            id8 = reader["id8"].ToString();
            id = reader["id"].ToString();
            mark = reader["mark"].ToString();
            educode0 = reader["educode0"].ToString();
            educode1 = reader["educode1"].ToString();
            educode2 = reader["educode2"].ToString();
            regcode = reader["regcode"].ToString();
            occcode = reader["occcode"].ToString();
            height = reader["height"].ToString();
            width = reader["width"].ToString();
            is_request = reader["is_request"].ToString();
            batt = reader["batt"].ToString();
            company = reader["company"].ToString();
            platoon = reader["platoon"].ToString();
            pseq = reader["pseq"].ToString();
            skill = reader["SKILLCODE"].ToString();
            telephone = reader["Telephone"].ToString();
            ftelephone = reader["FTelephone"].ToString();
            mtelephone = reader["MTelephone"].ToString();
            ptelephone = reader["PTelephone"].ToString();
            percent = reader["percent"].ToString();
            cmBoxkpt = reader["kpt"].ToString();
            //cmbPatient_status = reader["patient_status"].ToString();
            cmbAddictive_status = reader["Addictive"].ToString();
            flagreadfrom_IDCard = reader["FlagReadfrom_IDCard"].ToString();
            BankID = reader["BankID"].ToString();
            AccountNum = reader["AccountNum"].ToString();
        }
    }

    public class PersonSearch
    {
        [DisplayName("ผลัด")]
        public string yearin { get; set; }
        [DisplayName("ผลัดสมทบฝึก")]
        public string oldyearin { get; set; }
        [DisplayName("เลขประจำตัวประชาชน")]
        public string id13 { get; set; }
        [DisplayName("ชื่อ")]
        public string name { get; set; }
        [DisplayName("นามสกุล")]
        public string sname { get; set; }
        [DisplayName("วันเกิด")]
        public string birthdate { get; set; }
        [DisplayName("ทะเบียน")]
        public string id8 { get; set; }
        [DisplayName("navyid")]
        public string navyid { get; set; }
        [DisplayName("ร้อย/พัน/(ลำดับที่)")] //[DisplayName("พัน/ร้อย/หมวด/ลำดับ")]
        public string battCompanyPlatoonPseq { get; set; }

        public PersonSearch()
        {
            this.yearin = "";
            this.oldyearin = "";
            this.id13 = "";
            this.name = "";
            this.sname = "";
            this.birthdate = "";
            this.id8 = "";
            this.navyid = "";
            this.battCompanyPlatoonPseq = "";
        }

        public PersonSearch(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            this.yearin = reader["yearin"].ToString();
            this.oldyearin = reader["oldyearin"].ToString();
            this.id13 = reader["id13"].ToString();
            this.name = reader["name"].ToString();
            this.sname = reader["sname"].ToString();
            this.birthdate = reader["birthdate"].ToString();
            try
            {
                this.birthdate = this.birthdate.Split('/')[2] + "/" + this.birthdate.Split('/')[1] + "/" + (Convert.ToInt16(this.birthdate.Split('/')[0]) + 543).ToString();
            }
            catch
            {
                this.birthdate = reader["birthdate"].ToString();
            }
            this.id8 = reader["id8"].ToString();
            this.navyid = reader["navyid"].ToString();
            this.battCompanyPlatoonPseq = //reader["batt"].ToString() + "/" + reader["company"].ToString() + "/" + reader["platoon"].ToString() + "/" + reader["pseq"].ToString();
                                          reader["company"].ToString() + "/" + reader["batt"].ToString() + "(" + reader["platoon"].ToString() + string.Format("{0:0#}", reader["pseq"]) + ")";
        }
    }

    public class IndicmentDataSearch
    {
        [DisplayName("navyid")]
        public string navyid { get; set; }
        [DisplayName("ข้อหา")]
        public string indictment { get; set; }
        [DisplayName("วันที่ถูกจับกุม")]
        public string datecapture { get; set; }
        public IndicmentDataSearch()
        {
            this.navyid = "";
            this.indictment = "";
            this.datecapture = "";
        }

        public IndicmentDataSearch(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            this.navyid = reader["navyid"].ToString();
            this.indictment = reader["cause"].ToString();
            this.datecapture = convertTHDate(String.Format("{0:dd/MM/yyyy}", DateTime.Parse(reader["date_captured"].ToString())));
        }

        private string convertTHDate(string strDate)
        {
            int Thyear;
            string dateconverted = "";
            string[] datesplit = strDate.Split('/');
            if (Int32.Parse(datesplit[2]) < 2500)
            {
                Thyear = Int32.Parse(datesplit[2]) + 543;
            }
            dateconverted = datesplit[0] + "/" + converNumber2tMonth(datesplit[1]) + "/" + Int32.Parse(datesplit[2]).ToString();

            return dateconverted;
        }
        private string converNumber2tMonth(string month)
        {
            string THmonth = "";
            switch (month)
            {
                case "01":
                    THmonth = "ม.ค.";
                    break;
                case "02":
                    THmonth = "ก.พ.";
                    break;
                case "03":
                    THmonth = "มี.ค.";
                    break;
                case "04":
                    THmonth = "เม.ย.";
                    break;
                case "05":
                    THmonth = "พ.ค.";
                    break;
                case "06":
                    THmonth = "มิ.ย.";
                    break;
                case "07":
                    THmonth = "ก.ค.";
                    break;
                case "08":
                    THmonth = "ส.ค.";
                    break;
                case "09":
                    THmonth = "ก.ย.";
                    break;
                case "10":
                    THmonth = "ต.ค.";
                    break;
                case "11":
                    THmonth = "พ.ย.";
                    break;
                case "12":
                    THmonth = "ธ.ค.";
                    break;
            }
            return THmonth;
        }

    }

    public class PersonSD18
    {
        [DisplayName("runcode")]
        public string runcode { get; set; }
        [DisplayName("เลขประจำตัวประชาชน")]
        public string id13 { get; set; }
        [DisplayName("ชื่อ")]
        public string name { get; set; }
        [DisplayName("นามสกุล")]
        public string sname { get; set; }
        [DisplayName("ทะเบียน")]
        public string id8 { get; set; }
        [DisplayName("วันเกิด")]
        public string birthdate { get; set; }
        [DisplayName("แผลเป็น")]
        public string mark { get; set; }
        [DisplayName("ที่อยู่")]
        public string address { get; set; }
        [DisplayName("ตำบล")]
        public string tumbon { get; set; }
        [DisplayName("อำเภอ")]
        public string amphor { get; set; }
        [DisplayName("จังหวัด")]
        public string province { get; set; }
        [DisplayName("การศึกษา")]
        public string educ { get; set; }
        [DisplayName("อาชีพ")]
        public string occ { get; set; }
        [DisplayName("ศาสนา")]
        public string religion { get; set; }
        [DisplayName("ชื่อบิดา")]
        public string father { get; set; }
        [DisplayName("สกุลบิดา")]
        public string fsname { get; set; }
        [DisplayName("ชื่อมารดา")]
        public string mother { get; set; }
        [DisplayName("สกุลมารดา")]
        public string msname { get; set; }
        [DisplayName("สูง")]
        public string height { get; set; }
        [DisplayName("รอบอก")]
        public string width { get; set; }
        [DisplayName("หมายเหตุ")]
        public string request { get; set; }

        public PersonSD18(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            runcode = reader["runcode"].ToString();

            try
            {
                runcode += "\n" + reader["batt"].ToString() + "." + reader["company"].ToString() + "." + reader["platoon"].ToString() + "." + reader["pseq"].ToString();
            }
            catch
            {
                runcode += "";
            }

            id13 = reader["id13"].ToString() + "\n" + reader["name"].ToString() + "\n" + reader["sname"].ToString();
            name = reader["name"].ToString();
            sname = reader["sname"].ToString();
            id8 = reader["id8"].ToString();

            try
            {
                DateTime d = DateTime.ParseExact(reader["birthdate"].ToString(), "yyyy/MM/dd", new System.Globalization.CultureInfo("en-US"));
                int year = d.Year;
                if (!Core.Function.IsBuddhistYear(year))
                {
                    birthdate = d.ToString("d MMM", new System.Globalization.CultureInfo("th-TH")) + " " + (year + 543).ToString();
                }
                else
                {
                    birthdate = d.ToString("d MMM yyyy", new System.Globalization.CultureInfo("th-TH"));
                }
            }
            catch
            {
                birthdate = reader["birthdate"].ToString();
            }
            birthdate += "\n" + reader["mark"].ToString();
            mark = reader["mark"].ToString();
            address = (reader["address"].ToString() + (reader["address_mu"].ToString() == "" ? "" : " ม." + reader["address_mu"].ToString()) + (reader["address_soil"].ToString() == "" ? "" : " ซ." + reader["address_soil"].ToString()) + (reader["address_road"].ToString() == "" ? "" : " ถ." + reader["address_road"].ToString())).Trim();

            tumbon = reader["tumbon"].ToString() + "\n" + reader["amphor"].ToString() + "\n" + reader["province"].ToString();
            amphor = reader["amphor"].ToString();
            province = reader["province"].ToString();

            educ = reader["educname"].ToString();
            occ = reader["occname"].ToString();
            religion = reader["religion"].ToString();
            father = reader["father"].ToString() + "\n" + reader["fsname"].ToString();
            fsname = reader["fsname"].ToString();
            mother = reader["mother"].ToString() + "\n" + reader["msname"].ToString(); ;
            msname = reader["msname"].ToString();
            height = reader["height"].ToString();
            width = reader["width"].ToString();
            request = reader["is_request"].ToString();
            request = request == "100" ? "ร้องขอ" : "";
        }
    }

    public class Person
    {
        #region Fields
        //[Browsable(false)]
        public string navyid { get; set; }

        [Browsable(false)]
        public string statuscode { get; set; }

        [Browsable(false)]
        public string unit3 { get; set; }

        [Browsable(false)]
        public string ask { get; set; }

        [Browsable(false)]
        public DateTime regdate { get; set; }

        [Browsable(false)]
        public DateTime movedate { get; set; }

        [DisplayName("ผลัด")]
        public string yearin { get; set; }

        [DisplayName("สมทบฝึก")]
        public string oldyearin { get; set; }

        [DisplayName("ทะเบียน")]
        public string id8 { get; set; }

        [DisplayName("กองพัน")]
        public string batt { get; set; }

        [DisplayName("กองร้อย")]
        public string company { get; set; }

        [DisplayName("ชื่อ")]
        public string name { get; set; }

        [DisplayName("นามสกุล")]
        public string sname { get; set; }

        [DisplayName("สังกัดหน่วย")]
        public string unitname { get; set; }

        [DisplayName("สถานะ")]
        public string stitle { get; set; }
        public string postname { get; set; }
        public string unit4 { get; set; }
        public string item { get; set; }
        public string percent { get; set; }
        public string educname { get; set; }
        public string skill { get; set; }
        public string platoon { get; set; }
        public string pseq { get; set; }
        public string unit1 { get; set; }
        public string unit2 { get; set; }
        #endregion

        #region Constructors

        public Person()
        {

        }

        public Person(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            navyid = Convert.ToString(reader["navyid"]);
            statuscode = Convert.ToString(reader["statuscode"]);
            yearin = Convert.ToString(reader["yearin"]);
            batt = Convert.ToString(reader["batt"]);
            company = Convert.ToString(reader["company"]);
            name = Convert.ToString(reader["name"]);
            sname = Convert.ToString(reader["sname"]);
            id8 = Convert.ToString(reader["id8"]);
            unit3 = Convert.ToString(reader["unit3"]);
            unitname = Convert.ToString(reader["unitname"]);
            ask = Convert.ToString(reader["ask"]);
            oldyearin = Convert.ToString(reader["oldyearin"]);
            regdate = reader.GetDateTime("regdate");
            movedate = reader.GetDateTime("movedate");
            //stitle = Core.DataDefinition.GetStatusSTitle(statuscode);
            stitle = Convert.ToString(reader["stitle"]);
            postname = Convert.ToString(reader["postname"]);
            unit4 = Convert.ToString(reader["unit4name"]);
            item = Convert.ToString(reader["sxitem"]);
            percent = Convert.ToString(reader["percent"]);
            educname = Convert.ToString(reader["educname"]);
            skill = Convert.ToString(reader["skill"]);
            platoon = Convert.ToString(reader["platoon"]);
            pseq = Convert.ToString(reader["pseq"]);
            unit1 = Convert.ToString(reader["unit1name"]);
            unit2 = Convert.ToString(reader["unit2name"]);
        }

        #endregion


    }

    public class Request
    {
        [DisplayName("ผลัด")]
        public string yearin { get; set; }
        [DisplayName("ชื่อ")]
        public string name { get; set; }
        [DisplayName("สกุล")]
        public string sname { get; set; }
        [DisplayName("ทะเบียน")]
        public string id8 { get; set; }
        [DisplayName("ร/พ")]
        public string com_batt { get; set; }

        public string navyid { get; set; }
        public string unit { get; set; }
        [DisplayName("หน่วยที่ขอ")]
        public string unitname { get; set; }
        [DisplayName("ผู้ขอ")]
        public string askby { get; set; }
        [DisplayName("หมายเหตุ")]
        public string remark { get; set; }
        [DisplayName("ขอต่อ")]
        public string remark2 { get; set; }
        public string num { get; set; }
        public string updby { get; set; }
        public int updatecount { get; set; }

        public Request()
        {
            navyid = "";
        }

        public Request(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            navyid = Convert.ToString(reader["request_navyid"]);
            unit = Convert.ToString(reader["request_unit"]);
            askby = Convert.ToString(reader["request_askby"]);
            remark = Convert.ToString(reader["request_remark"]);
            remark2 = Convert.ToString(reader["request_remark2"]);
            unitname = Convert.ToString(reader["request_unitname"]);
            num = Convert.ToString(reader["request_num"]);
            updby = Convert.ToString(reader["request_updby"]);
            updatecount = Convert.ToInt16(Core.Function.GetTextOrNull(Convert.ToString(reader["request_updatecount"]), "-1"));
        }
    }

    public class PersonRequest
    {
        public Person person;
        public Request request;

        public PersonRequest()
        {
            person = new Person();
            request = new Request();
        }

        public PersonRequest(Person p, Request r)
        {
            person = p;
            request = r;
        }

        public PersonRequest(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            this.person = new Person(reader);
            this.request = new Request(reader);
        }
    }

    public class NLabelPerson
    {
        [DisplayName("หน่วย")]
        public string unitname { get; set; }
        [DisplayName("จำนวนคน")]
        public string countPerson { get; set; }
        [DisplayName("หมายเลข")]
        public string all_nlabel { get; set; }
        [DisplayName("จำนวนหมายเลข")]
        public string countNLabel { get; set; }
        [DisplayName("จำนวนคนต่อหมายเลข")]
        public string countPersonPerNLabel { get; set; }
        [DisplayName("จำนวนคนต่อหมายเลขทั้งหมด")]
        public string countPersonPerNLabels { get; set; }

        public NLabelPerson()
        {

        }

        public NLabelPerson(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            unitname = reader["unitname"].ToString();
            countPerson = reader["count_person"].ToString();

        }
    }

    public class ParamPeople
    {
        public string id13 { get; set; }
        public string navyid { get; set; }



        public DateTime in_date { get; set; }
        public DateTime dead_date { get; set; }
        public DateTime out_date { get; set; }

        public string address_in { get; set; }
        public string address_mu_in { get; set; }
        public string address_soid_in { get; set; }
        public string address_road_in { get; set; }
        public string towncode_in { get; set; }

        public string address_out { get; set; }
        public string address_mu_out { get; set; }
        public string address_soid_out { get; set; }
        public string address_road_out { get; set; }
        public string towncode_out { get; set; }

        public string type_out { get; set; }
        public string book_number { get; set; }
        public string rank { get; set; }
        public string status { get; set; }
        public string pseq { get; set; }

        public ParamPeople()
        {

        }

        public ParamPeople(string id13)
        {
            using (MySqlConnection mcon = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            using (MySqlCommand cmd = mcon.CreateCommand())
            {
                mcon.Open();
                string sql = "SELECT * FROM person p where(1=1) ";

                if (!string.IsNullOrEmpty(id13))
                {

                    sql += " p.id13 ='" + id13 + "' ";
                }
                cmd.CommandText = sql;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        navyid = reader["navyid"].ToString();
                        id13 = reader["id13"].ToString();

                        in_date = DateTime.Parse(reader["regDate"].ToString());

                        address_in = reader["address_in"].ToString();
                        address_mu_in = reader["address_mu_in"].ToString();
                        address_soid_in = reader["address_soid_in"].ToString();
                        address_road_in = reader["address_road_in"].ToString();
                        towncode_in = reader["towncode_in"].ToString();

                        address_in = reader["address_out"].ToString();
                        address_mu_in = reader["address_mu_out"].ToString();
                        address_soid_in = reader["address_soid_out"].ToString();
                        address_road_in = reader["address_road_out"].ToString();
                        towncode_out = reader["towncode_out"].ToString();
                        type_out = reader["type_out"].ToString();
                        book_number = reader["book_number"].ToString();
                        rank = reader["rank"].ToString();
                        status = reader["status"].ToString();
                        pseq = reader["pseq"].ToString();
                    }
                }
            }
        }
    }

    //public class TelephoneSearch
    //{

    //    [DisplayName("ชื่อ")]
    //    public string name { get; set; }
    //    [DisplayName("นามสกุล")]
    //    public string sname { get; set; }
    //    [DisplayName("เบอร์โทรศัพท์")]
    //    public string TelNumber { get; set; }
    //    [DisplayName("เบอร์โทรศัพท์บิดา")]
    //    public string FTelNumber { get; set; }
    //    [DisplayName("เบอร์โทรศัพท์มารดา")]
    //    public string MTelNumber { get; set; }
    //    [DisplayName("เบอร์โทรศัพท์ผู้ปกครอง")] //[DisplayName("พัน/ร้อย/หมวด/ลำดับ")]
    //    public string PTelephone { get; set; }

    //    public TelephoneSearch()
    //    {
    //        this.name = "";
    //        this.sname = "";
    //        this.TelNumber = "";
    //        this.FTelNumber = "";
    //        this.MTelNumber = "";
    //        this.PTelephone = "";
    //    }

    //    public TelephoneSearch(MySql.Data.MySqlClient.MySqlDataReader reader)
    //    {
    //        this.name = reader["NAME"].ToString();
    //        this.sname = reader["SNAME"].ToString();
    //        this.TelNumber = reader["Telephone"].ToString();
    //        this.FTelNumber = reader["FTelephone"].ToString();
    //        this.MTelNumber = reader["MTelephone"].ToString();
    //        this.PTelephone = reader["PTelephone"].ToString();
    //    }
    //}

}
