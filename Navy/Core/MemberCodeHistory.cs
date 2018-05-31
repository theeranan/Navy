using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.ComponentModel;


namespace Navy.Core
{
    public class MemberCodeHistory
    {
        #region Fields

        public string id { get; set; }

        [Browsable(false)]
        public string navyid { get; set; }

        [Browsable(false)]
        public string membercode { get; set; }

        [Browsable(false)]
        public string membercode5 { get; set; }

        [Browsable(false)]
        public string namecode { get; set; }

        [Browsable(false)]
        public string namecode5 { get; set; }

        [Browsable(false)]
        public string link { get; set; }
        
        [Browsable(false)]
        public string updated_by { get; set; }

        [Browsable(false)]
        public string updated_time { get; set; }

        [Browsable(false)]
        public string a1 { get; set; }

        [Browsable(false)]
        public string a2 { get; set; }

        [Browsable(false)]
        public DateTime date_start { get; set; }

        [Browsable(false)]
        public DateTime date_end { get; set; }

        [DisplayName("ตั้งแต่วันที่")]
        public string date_start_txt { get; set; }

        [DisplayName("ถึงวันที่")]
        public string date_end_txt { get; set; }

        [DisplayName("กอง")]
        public string a1_name { get; set; }

        [DisplayName("แผนก")]
        public string a2_name { get; set; }

        [DisplayName("หมายเหตุ")]
        public string remark { get; set; }
 
        #endregion

        #region Constructors

        public MemberCodeHistory()
        {

        }

        public MemberCodeHistory(MySqlDataReader reader)
        {
            id = Convert.ToString(reader["id"]);
            navyid = Convert.ToString(reader["navyid"]);
            membercode = Convert.ToString(reader["membercode"]);
            membercode5 = Convert.ToString(reader["membercode5"]);
            link = Convert.ToString(reader["link"]);
            date_start_txt = Function.GetStringOfDate(reader["date_start"]);
            date_end_txt = Function.GetStringOfDate(reader["date_end"]);

            date_start = Function.GetDate(reader["date_start"]);
            date_end = Function.GetDate(reader["date_end"]);

            namecode = Function.GetNameCode(membercode);
            namecode5 = Function.GetNameCode(membercode5);

            AssignDivision();

            remark = namecode5 + " " + link;
        }

        private void AssignDivision()
        {
            // Check Membercode structure
            string struc = Function.GetStructureID(membercode);

            if (struc == "A1")
            {
                a1 = membercode;
                a1_name = Function.GetNameCode(a1);
                a2 = " ";
                a2_name = " ";
            }

            else if (struc == "A2")
            {
                //Assign A2
                a2 = membercode;
                a2_name = Function.GetNameCode(a2);

                //Find A1
                a1 = Function.GetMemberCodeParent(membercode);
                a1_name = Function.GetNameCode(a1);

            }

        }

        #endregion

    }
}
