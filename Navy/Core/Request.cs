using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Navy.Core
{
    public class Request
    {
        public string navyid { get; set; }
        public string unit { get; set; }
        public string unitname { get; set; }
        public string askby { get; set; }
        public string remark { get; set; }
        public string remark2 { get; set; }

        public Request()
        {

        }

        public Request(MySqlDataReader reader)
        {
            navyid = Convert.ToString(reader["navyid"]);
            unit = Convert.ToString(reader["unit"]);
            askby = Convert.ToString(reader["askby"]);
            remark = Convert.ToString(reader["remark"]);
            remark2 = Convert.ToString(reader["remark2"]);
            unitname = Function.GetUnitName(unit);
        }
    }
}
