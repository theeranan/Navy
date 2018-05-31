using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Navy.Core
{
    public class RTCPunishment
    {
        public string punish_no { get; set; }
        public string navyid { get; set; }
        public string stitle { get; set; }
        public string title { get; set; }
        public string trans_type { get; set; }
        public string code1 { get; set; }
        public string refno { get; set; }
        public string red_no { get; set; }
        public string black_no { get; set; }
        public string doc_date { get; set; }
        public string trans_no { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        public string inyear { get; set; }
        public string inmonth { get; set; }
        public string inday { get; set; }
        public string inhour { get; set; }
        public string place { get; set; }

        public string flag { get; set; }
        public string num { get; set; }

        public RTCPunishment()
        {

        }

        public RTCPunishment(MySqlDataReader reader)
        {
            punish_no = Convert.ToString(reader["punish_no"]);
            navyid = Convert.ToString(reader["navyid"]);
            trans_type = Convert.ToString(reader["trans_type"]);
            code1 = Convert.ToString(reader["code1"]);

            stitle = Function.GetStatusName(trans_type + code1);
            title = Function.GetTitle(trans_type + code1);

            refno = Convert.ToString(reader["ref_no"]);
            red_no = Convert.ToString(reader["red_no"]);
            black_no = Convert.ToString(reader["black_no"]);
            doc_date = Function.GetStringOfDate(reader["doc_date"]);
            trans_no = Convert.ToString(reader["trans_no"]);
            start_date = Function.GetStringOfDate(reader["start_date"]);
            end_date = Function.GetStringOfDate(reader["end_date"]);

            inyear = Convert.ToString(reader["inyear"]);
            inmonth = Convert.ToString(reader["inmonth"]);
            inday = Convert.ToString(reader["inday"]);
            inhour = Convert.ToString(reader["inhour"]);

            flag = Convert.ToString(reader["flag"]);
            num = Convert.ToString(reader["num"]);


        }
    }
}
