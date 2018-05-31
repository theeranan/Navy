using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Navy.Core
{
    public class RTCTransaction
    {
        public string navyid;
        public string trans_no;
        public string id;
        public string trans_type;
        public string stitle;
        public string code1;
        public string yearin;
        public string refno;
        public string doc_date;
        public string start_date;
        public string end_date;

        public int inyear;
        public int inmonth;
        public int inday;

        public string flag;
        public string num;

        public RTCTransaction()
        {

        }

        public RTCTransaction(MySqlDataReader reader)
        {
            navyid = Convert.ToString(reader["navyid"]);
            trans_no = Convert.ToString(reader["trans_no"]);
            id = Convert.ToString(reader["id"]);
            trans_type = Convert.ToString(reader["trans_type"]);
            stitle = Convert.ToString(reader["stitle"]);
            code1 = Convert.ToString(reader["code1"]);
            yearin = Convert.ToString(reader["yearin"]);
            refno = Convert.ToString(reader["ref_no"]);
            doc_date = Function.GetStringOfDate(reader["doc_date"]);
            start_date = Function.GetStringOfDate(reader["start_date"]);
            end_date = Function.GetStringOfDate(reader["end_date"]);

            inyear = (int) Function.GetInt(reader["inyear"]);
            inmonth = (int) Function.GetInt(reader["inmonth"]);
            inday = (int) Function.GetInt(reader["inday"]);

            flag = Convert.ToString(reader["flag"]);
            num = Convert.ToString(reader["num"]);
        }
    
    }


}
