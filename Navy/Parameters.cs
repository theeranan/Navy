using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navy
{
    public class Parameters
    {
        public struct MemberSearch
        {
            public string yearin;
            public string id8;
            public string name;
            public string sname;
            public string membercode;
            public string statuscode;
            public string estdate;
        }

        public struct ChangeMemberCode
        {
            public string navyid;
            public string membercode;
            public string membercode5;
            public string link;
            public DateTime date_start;
        }

        public struct PersonRequest
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

        public struct PersonSearch
        {
            public string yearin;
            public string id8;
            public string name;
            public string sname;
            public string membercode;
            public string statuscode;
            public string estdate;
        }
    }
}
