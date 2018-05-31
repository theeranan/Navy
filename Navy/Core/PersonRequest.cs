using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navy.Core
{
    public class PersonRequest
    {
        public class Person : Core.Person
        {
            public virtual string stitle { get; set; }
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

            public Person()
            {
                navyid = "";
            }

            public Person(MySql.Data.MySqlClient.MySqlDataReader reader)
                : base(reader)
            {
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
        }

        public class Request : Core.Request
        {
            public string num { get; set; }
            public string updby { get; set; }
            public int updatecount { get; set; }

            public Request()
            {
                navyid = "";
            }

            public Request(MySql.Data.MySqlClient.MySqlDataReader reader)
                : base()
            {
                navyid = Convert.ToString(reader["request_navyid"]);
                unit = Convert.ToString(reader["request_unit"]);
                askby = Convert.ToString(reader["request_askby"]);
                remark = Convert.ToString(reader["request_remark"]);
                remark2 = Convert.ToString(reader["request_remark2"]);
                unitname = Convert.ToString(reader["request_unitname"]);
                num = Convert.ToString(reader["request_num"]);
                updby = Convert.ToString(reader["request_updby"]);
                updatecount = Convert.ToInt16(Function.GetTextOrNull(Convert.ToString(reader["request_updatecount"]), "-1"));

            }
        }

        public Person person;
        public Request request;

        public PersonRequest()
        {
            person = new Person();
            request = new Request();
        }

        public PersonRequest(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            this.person = new PersonRequest.Person(reader);
            this.request = new Request(reader);
        }
    }
}
