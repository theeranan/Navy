using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Navy.Core
{
    public class RTCDischarge
    {
        #region Fields
        public string navyid { get; set; }
        public string f_name { get; set; }
        public string f_sname { get; set; }
        public string name { get; set; }
        public string sname { get; set; }
        public DateTime end { get; set; }
        public bool isCorrect { get; set; }
        public bool isSuccess { get; set; }
        #endregion

        #region Constructors

        public RTCDischarge()
        {

        }

        public RTCDischarge(MySqlDataReader reader, DataRow file)
        {
            navyid = Convert.ToString(file["navyid"]);
            f_name = Convert.ToString(file["name"]);
            f_sname = Convert.ToString(file["sname"]);
            end = Convert.ToDateTime(file["end"]);

            if (reader.Read())
            {
                name = Convert.ToString(reader["name"]);
                sname = Convert.ToString(reader["sname"]);
            }
            else
            {
                name = string.Empty;
                sname = string.Empty;
            }

            CheckData();
        }

        #endregion  

        #region Methods

        public void CheckData()
        {
            if (name == f_name && sname == f_sname)
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
                isSuccess = false;
            }
        }

        public void CheckSuccess(bool success)
        {
            isSuccess = success;
        }

        #endregion
    }
}
