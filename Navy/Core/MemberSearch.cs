using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace Navy.Core
{
    public class MemberSearch
    {
        #region Fields

        [DisplayName("NavyId")]
        public string navyid { get; set; }

        [DisplayName("ทะเบียน")]
        public string id8 { get; set; }

        [DisplayName("ผลัด")]
        public string yearin { get; set; }

        [DisplayName("ชื่อ")]
        public string name { get; set; }

        [DisplayName("นามสกุล")]
        public string sname { get; set; }

        [Browsable(false)]
        public string membercode { get; set; }

        [Browsable(false)]
        public string membercode5 { get; set; }

        [Browsable(false)]
        public string link { get; set; }

        [Browsable(false)]
        public string statuscode { get; set; }

        [DisplayName("สถานะ")]
        public string title { get; set; }

        [Browsable(false)]
        public string stitle { get; set; }

        [DisplayName("หมายเหตุ")]
        public string remark { get; set; }

        [Browsable(false)]
        public DateTime estdate { get; set; }

        [Browsable(false)]
        public DateTime end { get; set; }

        [Browsable(false)]
        public string refdoc { get; set; }

        [Browsable(false)]
        public DateTime refdocdate { get; set; }

        [Browsable(false)]
        public string dischargetype { get; set; }



        #endregion

        #region Constructors

        public MemberSearch()
        {

        }

        public MemberSearch(MySqlDataReader reader)
        {
            navyid = Convert.ToString(reader["id"]);
            id8 = Convert.ToString(reader["id8"]);
            yearin = Convert.ToString(reader["yearin"]);
            name = Convert.ToString(reader["name"]);
            sname = Convert.ToString(reader["sname"]);
            membercode = Convert.ToString(reader["membercode"]);
            membercode5 = Convert.ToString(reader["membercode5"]);
            link = Convert.ToString(reader["link"]);

            remark = Function.GetNameCode(membercode5) + " " + link;

            statuscode = Convert.ToString(reader["statuscode"]);
            title = Convert.ToString(reader["title"]);
            stitle = Convert.ToString(reader["stitle"]);

            estdate = Function.GetDate(reader["estdate"]);
            end = Function.GetDate(reader["end"]);
            refdoc = Convert.ToString(reader["refdoc"]);
            refdocdate = Function.GetDate(reader["refdocdate"]);
            dischargetype = Convert.ToString(reader["dischargetype"]);

        }

        #endregion

    }
}
