using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Navy.Core
{
    public class TableMember
    {
        #region Fields

        public int memberid { get; set; }
        public string navyid { get; set; }
        public string id8 { get; set; }
        public string yearin { get; set; }
        public string name { get; set; }
        public string sname{ get; set; }
        public string membercode{ get; set; }
        public string membercode1{ get; set; } 
        public string membercode2{ get; set; }
        public string membercode3{ get; set; }
        public string membercode4{ get; set; }
        public string membercode5{ get; set; }
        public string link{ get; set; }
        public string groupid{ get; set; }
        public string typeid{ get; set; }
        public string start1{ get; set; }
        public DateTime start{ get; set; }
        public DateTime end{ get; set; }
        public string doccode{ get; set; }
        public int extend{ get; set; }
        public DateTime estdate{ get; set; }
        public DateTime sal2{ get; set; }
        public string updby{ get; set; }
        public DateTime upddate{ get; set; }

        public string refdoc { get; set; }
        public DateTime refdocdate { get; set; }
        public string tel1 { get; set; }
        public string tel2 { get; set; }
        public string dischargetype { get; set; }


        //regdate from person
        public DateTime regdate { get; set; }
        public string accountnum { get; set; }

        #endregion

        #region Constructors

        public TableMember()
        {

        }

        public TableMember(MySqlDataReader reader)
        {
            navyid = Convert.ToString(reader["id"]);
            id8 = Convert.ToString(reader["id8"]);
            yearin = Convert.ToString(reader["yearin"]);
            name = Convert.ToString(reader["name"]);
            sname = Convert.ToString(reader["sname"]);
            membercode = Convert.ToString(reader["membercode"]);
            membercode5 = Convert.ToString(reader["membercode5"]);
            link = Convert.ToString(reader["link"]);
            groupid = Convert.ToString(reader["groupid"]);
            typeid = Convert.ToString(reader["typeid"]);
            start = Function.GetDate(reader["start"]);
            end = Function.GetDate(reader["end"]);
            doccode = Convert.ToString(reader["doccode"]);
            extend = Convert.ToInt32(reader["extend"]);
            estdate = Convert.ToDateTime(reader["estdate"]);
            updby = Convert.ToString(reader["updby"]);
            upddate = Function.GetDate(reader["upddate"]);
            regdate = Function.GetDate(reader["regdate"]);
            refdoc = Convert.ToString(reader["refdoc"]);
            refdocdate = Function.GetDate(reader["refdocdate"]);
            tel1 = Convert.ToString(reader["tel1"]);
            tel2 = Convert.ToString(reader["tel2"]);
            dischargetype = Convert.ToString(reader["dischargetype"]);
            accountnum = Convert.ToString(reader["accountnum"]);
        }

        #endregion

    }
}
