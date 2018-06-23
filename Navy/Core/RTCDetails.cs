using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Navy.Core
{
    public class RTCDetails
    {
        #region Fields
        public string navyid { get; set; }
        public string name { get; set; }
        public string sname { get; set; }
        public string statuscode { get; set; }
        public string stitle { get; set; }
        public string membercode { get; set; }
        public string structureid { get; set; }
        public string namecode { get; set; }
        public string p_membercode { get; set; }
        public string p_namecode { get; set; }

        public string a1 { get; set; } 
        public string a2 { get; set; }

        public string membercode5 { get; set; }
        public string namecode5 { get; set; }
        public string link { get; set; }
        public string groupid { get; set; }
        public string groupname { get; set; }
        public string typeid { get; set; }
        public string type { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string doccode { get; set; }
        public int extend { get; set; }
        public string estdate { get; set; }

        public string oldyearin { get; set; }
        public string yearin { get; set; }
        public string id { get; set; }
        public string id8 { get; set; }
        public string id13 { get; set; }
        public string birthdate { get; set; }
        public string mark { get; set; }
        public string blood { get; set; }
        public string sign { get; set; }

        public string address_all { get; set; }
        public string address { get; set; }
        public string address_mu { get; set; }
        public string address_soil { get; set; }
        public string address_road { get; set; }
        public string towncode { get; set; }
        public string sub_district { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public string zip { get; set; }

        public string regcode { get; set; }
        public string religion { get; set; }
        public string father { get; set; }
        public string fsname { get; set; }
        public string mother { get; set; }
        public string msname { get; set; }
        public string height { get; set; }
        public string occcode { get; set; }
        public string occname { get; set; }
        public string educ { get; set; }
        public string regdate { get; set; }
        public string repdate { get; set; }
        public string unit3 { get; set; }
        public string unitname { get; set; }
        public string skillcode { get; set; }
        public string skill { get; set; }
        public string IS_REQUEST { get; set; }
        public string RUNCODE { get; set; }
        public string SALCODE { get; set; }
        public string BATT { get; set; }
        public string COMPANY { get; set; }
        public string PLATOON { get; set; }
        public string PSEQ { get; set; }
        public string PERCENT { get; set; }
        public string Unitname1 { get; set; }
        public string Unitname2 { get; set; }
        public string MOVEDATE { get; set; }
        public string POSTNAME { get; set; }
        public string width { get; set; }
        public string telephone { get; set; }
        public string ftelephone { get; set; }
        public string mtelephone { get; set; }
        public string ptelephone { get; set; }
        public string addictname { get; set; }
        public string Indiction { get; set; }
        public string BankName { get; set; }
        public string AccountNum { get; set; }

        #endregion

        #region Constructors

        public RTCDetails()
        {

        }

        public RTCDetails(MySqlDataReader reader)
        {

            navyid = reader["navyid"].ToString();
            name = reader["name"].ToString();
            sname = reader["sname"].ToString();
            statuscode = reader["statuscode"].ToString();
            stitle = reader["stitle"].ToString();

            membercode = reader["membercode"].ToString();
            namecode = reader["namecode"].ToString();
            structureid = reader["structureid"].ToString();
            p_membercode = reader["p_membercode"].ToString();
            p_namecode = reader["p_namecode"].ToString();
            setMemberCode();

            membercode5 = reader["membercode5"].ToString();
            namecode5 = reader["namecode5"].ToString();
            link = reader["link"].ToString();
            groupid = reader["groupid"].ToString();
            groupname = reader["groupname"].ToString();
            typeid = reader["typeid"].ToString();
            type = reader["type"].ToString();
            IS_REQUEST = reader["IS_REQUEST"].ToString();

            RUNCODE = reader["RUNCODE"].ToString();
        //    SALCODE = reader["SALCODE"].ToString();
            BATT = reader["BATT"].ToString();
            COMPANY = reader["COMPANY"].ToString();
            PLATOON = reader["PLATOON"].ToString();
            PSEQ = reader["PSEQ"].ToString();
            PERCENT = reader["PERCENT"].ToString();

            Unitname1 = reader["Unitname1"].ToString();
            Unitname2 = reader["Unitname2"].ToString();
            POSTNAME = reader["POSTNAME"].ToString();
            MOVEDATE = Function.GetStringOfDate(reader["MOVEDATE"]);

         //   start = Function.GetStringOfDate(reader["start"]);
          //  end = Function.GetStringOfDate(reader["end"]);
          //  doccode = reader["doccode"].ToString();

           

        //    estdate = Function.GetStringOfDate(reader["estdate"]);

            oldyearin = reader["OLDYEARIN"].ToString();
            yearin = reader["yearin"].ToString();
            SetSign();
            id = reader["id"].ToString();
            id8 = reader["id8"].ToString();
            id13 = reader["id13"].ToString();
            birthdate = Function.GetStringOfDate(reader["birthdate"]);
            mark = reader["mark"].ToString();
            blood = reader["blood"].ToString();
            address = reader["address"].ToString();
            address_mu = reader["address_mu"].ToString();
            address_soil = reader["address_soil"].ToString();
            address_road = reader["address_road"].ToString();
            towncode = reader["towncode"].ToString();
            sub_district = reader["sub-district"].ToString();
            district = reader["district"].ToString();
            province = reader["province"].ToString();
            zip = reader["zip"].ToString();

            setaddress();

            regcode = reader["regcode"].ToString();
            religion = reader["religion"].ToString();
            father = reader["father"].ToString();
            fsname = reader["fsname"].ToString();
            mother = reader["mother"].ToString();
            msname = reader["msname"].ToString();
            height = reader["height"].ToString();
            occcode = reader["occcode"].ToString();
            occname = reader["occname"].ToString();
            educ = reader["educ"].ToString();
            regdate = Function.GetStringOfDate(reader["regdate"]);
            repdate = Function.GetStringOfDate(reader["repdate"]);
            unit3 = reader["unit3"].ToString();
            unitname = reader["unitname"].ToString();
            skillcode = reader["skillcode"].ToString();
            skill = reader["skill"].ToString();
            telephone = reader["Telephone"].ToString();
            ftelephone = reader["FTelephone"].ToString();
            mtelephone = reader["MTelephone"].ToString();
            ptelephone = reader["PTelephone"].ToString();
            addictname = reader["addictname"].ToString();
            Indiction = reader["cause"].ToString();
            BankName = reader["EngShortName"].ToString();
            AccountNum = reader["AccountNum"].ToString();
        }
        
        #endregion

        #region Methods

        public void setMemberCode()
        {
            if (structureid == "A2")
            {
                a2 = namecode;
                a1 = p_namecode;
            }
            else if (structureid == "A1")
            {
                a1 = namecode;
                a2 = "-";
            }
        }


        public void SetSign()
        {
            string shift = yearin.Substring(0, 1);
            int year = Convert.ToInt16(yearin.Substring(2, 2));

            if (shift == "4")
            {
                year = year + 1;
            }

            sign = "ท.ร.25" + year.ToString();
        }

        public void setaddress()
        {
            address_all = "";

            if (address != "")
                address_all += "บ้านเลขที่ " + address;

            if (address_mu != "")
                address_all += " หมู่ " + address_mu;

            if (address_soil != "")
                address_all += " ซอย " + address_soil;

            if (address_road != "")
                address_all += " ถนน " + address_road;

            if (sub_district != "")
                address_all += " ตำบล " + sub_district;

            if (district != "")
                address_all += " อำเภอ " + district;

            if (province != "")
                address_all += " จังหวัด " + province;

            if (zip != "")
                address_all += " " + zip;
        }

        #endregion
    }
}
