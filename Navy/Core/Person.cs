using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace Navy.Core
{
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

        #endregion

        #region Constructors

        public Person()
        {

        }

        public Person(MySqlDataReader reader)
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

            stitle = Function.GetStatusName(statuscode);
        }

        #endregion


    }
}
