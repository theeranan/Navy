using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Navy.Data.DataTemplate;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace Navy.Core
{
    public static class Function
    {
        public static RTCRepository rtcRespository;
        private static DataTable _dtStatusTab;
        private static DataTable _dtStructure;
        private static DataTable _dtMemberCode;
        private static DataTable _dtUnitTab;
        private static DataTable _dtAskby;
        private static DataTable _dtAskbyNUM;
        public static RTCRepository GetRTCRespository()
        {
            if (rtcRespository == null)
                rtcRespository = new RTCRepository();

            return rtcRespository;
        }
        #region Conversion
        public static int? GetInt(object obj)
        {
            try
            {
                if (obj == DBNull.Value || obj == null)
                    return null;
                else
                    return int.Parse(obj.ToString());
            }
            catch //(Exception ex)
            {
                return 0;
            }
        }

        public static DateTime GetDate(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                    return Constants.minDate;
                else
                    return Convert.ToDateTime(obj);
            }
            catch //(Exception ex)
            {
                return Constants.minDate;
            }
        }

        /* Determine year is Buddhist Era 
         * [***note***] 
         * year start BE = 2558, AD(CE) = 2015
         * this algorithm is range follow:
         * BE range = [2500,...]
         * AD range = [...,2500]
         */
        public static bool IsBuddhistYear(int year)
        {
            return (year + 500) >= 3000 ? true : false;
        }

        //Convert date to string in format 'd MMM yyyy'
        public static string GetStringOfDate(object obj)
        {
            try
            {
                if (obj != DBNull.Value)
                {
                    DateTime date = Convert.ToDateTime(obj);

                    return date.ToString("d MMM yyyy");
                }
                return string.Empty;
            }
            catch //(FormatException ex)
            {
                return string.Empty;
            }
        }

        //Convert date from TH-format(dd/MM/yyyy) to US-format(yyyy-MM-dd)
        public static string GetDateStrFromDatePickerTH(DateTime dt)
        {
            try
            {
                if (IsBuddhistYear(dt.Year))
                {
                    dt = new DateTime(dt.Year - 543, dt.Month, dt.Day);
                }
                return dt.Date.ToString("yyyy-MM-dd");
            }
            catch //(Exception ex)
            {
                return string.Empty;
            }
        }

        //
        //public static string GetDateFormTextBoxValue(string txt)
        //{
        //    try
        //    {
        //        DateTime bd;
        //        if (!DateTime.TryParseExact(txt, "dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"), System.Globalization.DateTimeStyles.None, out bd))
        //        {
        //            return "วันเกิด";
        //        }

        //        string[] txtDate = txt.Split('/');
                

        //        if (IsBuddhistYear(Convert.ToInt16(txtDate[2])))
        //        {
        //            dt = new DateTime(dt.Year - 543, dt.Month, dt.Day);
        //        }
        //        return dt.Date.ToString("yyyy-MM-dd");
        //    }
        //    catch //(Exception ex)
        //    {
        //        return string.Empty;
        //    }
        //}

        //Convert empty string to null
        public static string GetTextOrNull(string str)
        {
            if (String.IsNullOrEmpty(str))
                return null;

            return str;
        }

        //Replace empty string to specific string
        public static string GetTextOrNull(string str, string replaceStr)
        {
            if (String.IsNullOrEmpty(str))
                return replaceStr;

            return str;
        }

        //Calculate item and page number then convert to SQL limit cause
        public static LimitMySQL GetLimitFromPage(int itemPerPage, int page)
        {
            LimitMySQL limit = new LimitMySQL();
            limit.limit1 = page == 1 ? 0 : (itemPerPage * (page - 1));
            limit.limit2 = itemPerPage;
            return limit;
        }

        //Calculate total pages
        public static int CalTotalPage(int allItem, int itemPerPage)
        {
            if (allItem <= itemPerPage)
            {
                return 1;
            }
            else
            {
                return (allItem + itemPerPage - 1) / itemPerPage;
            }
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static T ConvertToUserDefineTable<T>(DataTable dataTable) where T : new()
        {
            //Define what attributes to be read from the class
            const System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;

            //Read Attribute Names and Types
            var objFieldNames = typeof(T).GetProperties(flags).Cast<System.Reflection.PropertyInfo>().
                Select(item => new
                {
                    Name = item.Name,
                    Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
                }).ToList();

            //Read Datatable column names and types
            var dtlFieldNames = dataTable.Columns.Cast<DataColumn>().
                Select(item => new
                {
                    Name = item.ColumnName,
                    Type = item.DataType
                }).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var classObj = new T();

                foreach (var dtField in dtlFieldNames)
                {
                    System.Reflection.PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);

                    var field = objFieldNames.Find(x => x.Name == dtField.Name + "Column");

                    if (field != null)
                    {

                    }
                }
            }

            return new T();
            
            //PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            //DataTable table = new DataTable();
            //foreach (PropertyDescriptor prop in properties)
            //    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            //foreach (T item in data)
            //{
            //    DataRow row = table.NewRow();
            //    foreach (PropertyDescriptor prop in properties)
            //        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            //    table.Rows.Add(row);
            //}
            //return table;
        }
        #endregion

        #region Date Of Yearin

        private static DateTime firstDate;
        private static DateTime lastDate;

        public static void SetFirstDate(string yearin)
        {
            firstDate = ConvertYearinToFirstDate(yearin);
        }

        public static void SetLastDate(string yearin)
        {
            lastDate = ConvertYearinToLastDate(yearin);
        }

        public static DateTime GetFirstDate()
        {
            return firstDate;
        }

        public static DateTime GetLastDate()
        {
            return lastDate;
        }

        public static DateTime GetFirstDateOfYearin(string yearin)
        {
            string shift = yearin.Substring(0, 1);
            string year = yearin.Substring(2, 2);

            int month = 1;
            switch (shift)
            {
                case "1": month = 5; break;
                case "2": month = 8; break;
                case "3": month = 11; break;
                case "4": month = 2; year = (Int16.Parse(year) + 1).ToString(); break;
            }

            int y = Convert.ToInt16("25" + year);
            DateTime date = new DateTime((y - 543), month, 1);
            if (IsBuddhistYear(DateTime.Now.Year))
            {
                date = new DateTime(y, month, 1);
            }

            return date.Date;
        }

        public static DateTime GetLastDateOfYearin(string yearin)
        {
            string shift = yearin.Substring(0, 1);
            string year = yearin.Substring(2, 2);

            int month = 1;
            switch (shift)
            {
                case "1": month = 7; break;
                case "2": month = 10; break;
                case "3": month = 1; year = (Int16.Parse(year) + 1).ToString(); break;
                case "4": month = 4; year = (Int16.Parse(year) + 1).ToString(); break;
            }

            int y = Convert.ToInt16("25" + year);
            DateTime date = new DateTime(y - 543, month, DateTime.DaysInMonth(y - 543, month));
            if (IsBuddhistYear(DateTime.Now.Year))
            {
                date = new DateTime(y, month, DateTime.DaysInMonth(y, month));
            }
            return date.Date;
        }

        public static DateTime ConvertYearinToFirstDate(string yearin)
        {
            string shift = yearin.Substring(0, 1);
            string year = yearin.Substring(2, 2);

            int month = 1;
            switch (shift)
            {
                case "1": month = 5; year = "25" + year; break;
                case "2": month = 8; year = "25" + year; break;
                case "3": month = 11; year = "25" + year; break;
                case "4": month = 2; year = "25" + (Int16.Parse(year) + 1).ToString(); break;
            }

            DateTime date = new DateTime(Int16.Parse(year), month, 1);
            if (!IsBuddhistYear(Convert.ToInt16(year)))
            {
                date = new DateTime(Int16.Parse(year) - 543, month, 1);
            }

            return date.Date;
        }

        public static DateTime ConvertYearinToLastDate(string yearin)
        {
            string shift = yearin.Substring(0, 1);
            string year = yearin.Substring(2, 2);

            int month = 1;
            switch (shift)
            {
                case "1": month = 7; year = "25" + year; break;
                case "2": month = 10; year = "25" + year; break;
                case "3": month = 1; year = "25" + (Int16.Parse(year) + 1).ToString(); break;
                case "4": month = 4; year = "25" + (Int16.Parse(year) + 1).ToString(); break;
            }

            DateTime date = new DateTime(Int16.Parse(year), month, DateTime.DaysInMonth(Int16.Parse(year), month));
            if (!IsBuddhistYear(Convert.ToInt16(year)))
            {
                date = new DateTime(Int16.Parse(year) - 543, month, DateTime.DaysInMonth(Int16.Parse(year) - 543, month));
            }
            return date.Date;
        }
        #endregion

        public static string GetRegYear(string yearin)
        {
            string shift = yearin.Substring(0, 1);
            string year = yearin.Substring(2, 2);

            if (shift == "4")
            {
                return year = (Int16.Parse(year) + 1).ToString();
            }
            return year;
        }

        public static string GetNavyNumberID10(string yearin, string armtownID, string id8_numberOnly)
        {
            string id10 = "2";
            string shift = yearin.Substring(0, 1);
            string year = yearin.Substring(2, 2);

            switch (shift)
            {
                case "1": id10 += year; break;
                case "2": id10 += year; break;
                case "3": id10 += year; break;
                case "4": id10 += (Int16.Parse(year) + 1).ToString(); break;
            }

            //get Armtown
            id10 += armtownID;

            //get id8
            string tempid8 = id8_numberOnly;
            while (tempid8.Length < 5)
            {
                tempid8 = "0" + tempid8;
            }
            id10 += tempid8;

            if (id10.Length != 10)
            {
                id10 = "XXXXXXXXXX";
            }

            return id10;
        }

        public static NavyRunNumber GenRunningNumber(int number)
        {
            NavyRunNumber result = new NavyRunNumber();
            int batt = 0;
            int com = 0;
            int pltn = 0;
            int seq = 0;

            try
            {
                batt = (int)(Math.Floor(((float)(number % 24) / 6.0) + 0.90));
                batt = batt == 0 ? 4 : batt;

                com = ((number % 24) % 6);
                com = com == 0 ? 6 : com;

                pltn = number % (4 * 6 * 3);
                pltn = pltn == 0 ? (4 * 6 * 3) : pltn;
                pltn = ((pltn - 1) / (4 * 6)) + 1;

                seq = ((number - 1) / (4 * 6 * 3)) + 1;
            }
            catch (DivideByZeroException)
            {
                batt = 0;
                com = 0;
                pltn = 0;
                seq = 0;
            }
            catch (OverflowException)
            {
                batt = -1;
                com = -1;
                pltn = -1;
                seq = -1;
            }

            result.batt = batt.ToString();
            result.company = com.ToString();
            result.platoon = pltn.ToString();
            result.pseq = seq.ToString();

            return result;
        }

        public static string GetNavyRunningNumber(NavyRunNumber result)
        {
            return result.batt + result.company + result.platoon + result.pseq;
        }

        public static void SetNavyRunningNumber(string number, Label lbBatt, Label lbCom, Label lbPlt, Label lbPseq)
        {
            NavyRunNumber num = Function.GenRunningNumber(Convert.ToInt16(number));
            lbBatt.Text = num.batt;
            lbCom.Text = num.company;
            lbPlt.Text = num.platoon;
            lbPseq.Text = num.pseq;
        }

        public static bool ValidateYearinFormat(string yearin)
        {
            if (yearin.Length == 4)
            {
                //check whitespace
                string[] textYearin = yearin.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in textYearin)
                {
                    if (String.IsNullOrWhiteSpace(s))
                        return false;
                }

                //check first digit
                if (Constants.shiftYearin.Contains(Convert.ToInt16(yearin.Substring(0, 1))))
                {
                    return true;
                }
            }
            return false;
        }
        #region Membercode Management
        public static DataTable GetMemberCode()
        {
            if (_dtMemberCode == null)
            {
                _dtMemberCode = new DataTable();
                DBConnection dbconn = new DBConnection();

                if (dbconn.openConnection() == true)
                {
                    using (MySqlConnection conn = dbconn.getConnection())
                    {
                        string sql = string.Empty;
                        sql = "SELECT mc.*, st.structure FROM membercode mc ";
                        sql += " INNER JOIN structure st ON mc.structureid = st.structureid";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            using (MySqlDataReader dr = cmd.ExecuteReader())
                            {
                                _dtMemberCode.Load(dr);
                            }
                        }
                    }

                }

            }
            return _dtMemberCode;
        }

        public static string GetMemberCodeParent(string membercode)
        {
            DataRow[] row;
            row = GetMemberCode().Select("membercode = '" + membercode + "'");

            if (row.Length > 0)
            {
                return Convert.ToString(row[0]["membercode_parentid"]);
            }
            else
            {
                return "";
            }
        }

        public static string GetNameCode(string membercode)
        {
            DataRow[] row;
            row = GetMemberCode().Select("membercode = '" + membercode + "'");
            if (row.Length > 0)
            {
                return Convert.ToString(row[0]["namecode"]);
            }
            else
            {
                return "";
            }
        }

        public static string GetStructureID(string membercode)
        {
            DataRow[] row;
            row = GetMemberCode().Select("membercode = '" + membercode + "'");

            if (row.Length > 0)
            {
                string structureid = Convert.ToString(row[0]["structureid"]);

                return structureid == "A7" ? "A6" : structureid;
            }
            else
            {
                return "";
            }
        }

        public static string GetStructureName(string membercode)
        {
            DataRow[] row;
            row = GetMemberCode().Select("membercode = '" + membercode + "'");

            if (row.Length > 0)
            {
                return Convert.ToString(row[0]["structure"]);
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region StatusTab Managememt

        public static DataTable GetStatusTab()
        {
            if (_dtStatusTab == null)
            {
                _dtStatusTab = new DataTable();
                DBConnection dbconn = new DBConnection();

                if (dbconn.openConnection() == true)
                {
                    using (MySqlConnection conn = dbconn.getConnection())
                    {
                        string sql = string.Empty;
                        sql = "SELECT * FROM statustab";


                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            using (MySqlDataReader dr = cmd.ExecuteReader())
                            {
                                _dtStatusTab.Load(dr);
                            }
                        }
                    }

                }

            }
            return _dtStatusTab;
        }

        public static string GetStatusName(string statuscode)
        {
            DataRow[] row;
            row = GetStatusTab().Select("statuscode = '" + statuscode + "'");

            if (row.Length > 0)
                return Convert.ToString(row[0]["stitle"]);

            return "";
        }

        public static string GetTitle(string statuscode)
        {
            DataRow[] row;
            row = GetStatusTab().Select("statuscode = '" + statuscode + "'");

            if (row.Length > 0)
                return Convert.ToString(row[0]["title"]);

            return "";
        }

        #endregion

        #region ReportViewDate
        private static DateTime dateViewReport = DateTime.Today.Date;

        public static void SetDateViewReport(DateTime date)
        {
            dateViewReport = date;
        }

        public static DateTime GetDateViewReport()
        {
            return dateViewReport.Date;
        }

        #endregion

        #region Input Language

        public static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                    return lang;
            }
            return null;
        }
        public static void SetKeyboardLayout(InputLanguage layout)
        {
            if (layout != InputLanguage.CurrentInputLanguage)
                InputLanguage.CurrentInputLanguage = layout;
        }

        #endregion

        #region Get first date of month

        public static DateTime GetFirstDateOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        #endregion

        #region Path Image

        public static string GetImagePath(Constants.ImagePath typePath)
        {
            switch (typePath)
            {
                case Constants.ImagePath.PersonCard: return System.IO.Path.GetFullPath(System.Configuration.ConfigurationManager.AppSettings["PhotoPath"] + "\\personcard");
                case Constants.ImagePath.PersonCardPreValidate: return System.IO.Path.GetFullPath(System.Configuration.ConfigurationManager.AppSettings["PhotoPath"] + "\\personcard\\preprocess");
                case Constants.ImagePath.PersonCardPostValidate: return System.IO.Path.GetFullPath(System.Configuration.ConfigurationManager.AppSettings["PhotoPath"] + "\\personcard\\processed");
                default: return "";
            }
        }

        public static string SelectProvinceDirectory(string armtownid,Constants.ImagePath pathType)
        {
            string selectDirProvince = "";
            string[] subdirectoryEntries = System.IO.Directory.GetDirectories(Function.GetImagePath(pathType));

            foreach (string subdirectory in subdirectoryEntries)
            {
                string[] dirname = subdirectory.Split('_');
                if (dirname.Count() > 0)
                {
                    if (dirname[1] == armtownid)
                    {
                        selectDirProvince = System.IO.Path.GetFullPath(subdirectory);
                        break;
                    }
                }
            }

            return selectDirProvince;
        }
        #endregion

        public static void InitCBMemberCodeA1(ComboBox comboBox, string value)
        {
            try
            {
                comboBox.DataSource = GetMemberCode().Select("membercode Like 'A534J%' and structureid = 'A1'", "membercode ASC").CopyToDataTable();
                comboBox.DisplayMember = "NameCode";
                comboBox.ValueMember = "MemberCode";
                comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                if (value == string.Empty)
                    comboBox.SelectedIndex = -1;
                else
                    comboBox.SelectedValue = value;
            }
            catch (Exception)
            {
                comboBox.DataSource = null;
            }
        }
        public static void InitCBMemberCodeA2(ComboBox comboBox, string parent, string value)
        {
            try
            {
                comboBox.DataSource = GetMemberCode().Select("structureid = 'A2' and membercode_parentID = '" + parent + "'").CopyToDataTable();
                comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.DisplayMember = "namecode";
                comboBox.ValueMember = "membercode";
                if (value == string.Empty)
                    comboBox.SelectedIndex = -1;
                else
                    comboBox.SelectedValue = value;
            }
            catch (Exception)
            {
                comboBox.DataSource = null;
            }

        }
        public static void InitCBMemberCode5(ComboBox comboBox, string structureid, string value)
        {
            try
            {
                string expression, sort;

                sort = "membercode ASC";
                if (structureid == "A6")
                {
                    expression = "structureid IN ('A6', 'A7')";
                }
                else
                {
                    expression = "structureid = '" + structureid + "'";
                }

                comboBox.DataSource = GetMemberCode().Select(expression, sort).CopyToDataTable();
                comboBox.DisplayMember = "shortname";
                comboBox.ValueMember = "membercode";
                comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                if (value == string.Empty)
                    comboBox.SelectedIndex = 0;
                else
                    comboBox.SelectedValue = value;
            }
            catch (Exception)
            {
                comboBox.DataSource = null;
            }

        }
        public static void InitCBStatusCode(ComboBox comboBox)
        {
            try
            {
                comboBox.DataSource = GetStatusTab();
                comboBox.DisplayMember = "title";
                comboBox.ValueMember = "statuscode";
                comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.SelectedIndex = -1;
            }
            catch (Exception)
            {
                comboBox.DataSource = null;
            }
        }
        public static DataTable GetStructureTab()
        {
            if (_dtStructure == null)
            {
                _dtStructure = new DataTable();
                DBConnection dbconn = new DBConnection();

                if (dbconn.openConnection() == true)
                {
                    using (MySqlConnection conn = dbconn.getConnection())
                    {
                        string sql = string.Empty;
                        sql = "SELECT *";
                        sql += " FROM structure ";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            using (MySqlDataReader dr = cmd.ExecuteReader())
                            {
                                _dtStructure.Load(dr);
                            }
                        }
                    }
                }
            }

            return _dtStructure;
        }
         public static void InitCBStructure(ComboBox comboBox, string value)
        {
            try
            {
                comboBox.DataSource = GetStructureTab().Select("structureid IN ('A5', 'A6', 'B', 'C')").CopyToDataTable();
                comboBox.DisplayMember = "structure";
                comboBox.ValueMember = "structureid";
                comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                if (value != string.Empty)
                    comboBox.SelectedValue = value;
                else
                    comboBox.SelectedIndex = -1;
            }
            catch (Exception)
            {
                comboBox.DataSource = null;
            }
        }
         public static string GetUnitName(string unit)
         {
             DataRow[] row;
             row = GetUnitTab().Select("refnum = '" + unit + "'");

             if (row.Length > 0)
                 return Convert.ToString(row[0]["unitname"]);

             return "";
         }
         public static DataTable GetUnitTab()
         {
             if (_dtUnitTab == null)
             {
                 _dtUnitTab = new DataTable();
                 DBConnection dbconn = new DBConnection();

                 if (dbconn.openConnection() == true)
                 {
                     using (MySqlConnection conn = dbconn.getConnection())
                     {
                         string sql = string.Empty;
                         sql = "SELECT * FROM unittab WHERE movestat = 1";


                         using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                         {
                             using (MySqlDataReader dr = cmd.ExecuteReader())
                             {
                                 _dtUnitTab.Load(dr);
                             }
                         }
                     }

                 }

             }
             return _dtUnitTab;
         }
         public static void InitCBUnit(ComboBox comboBox, string value)
         {
             try
             {
                 comboBox.DataSource = GetUnitTab();
                 comboBox.DisplayMember = "UNITNAME";
                 comboBox.ValueMember = "REFNUM";
                 comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                 comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                 if (value == string.Empty)
                     comboBox.SelectedIndex = -1;
                 else
                     comboBox.SelectedValue = value;
             }
             catch (Exception)
             {
                 comboBox.DataSource = null;
             }
         }
         public static void  InitCBAskBy(ComboBox comboBox, string value)
         {
             try
             {
                 comboBox.DataSource = GetAskByTab();
                 comboBox.DisplayMember = "ask";
                 comboBox.ValueMember = "ask";
                 comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                 comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                 comboBox.SelectedIndex = -1;
                 if (value == string.Empty)
                     comboBox.SelectedIndex = -1;
                 else
                     comboBox.SelectedValue = value;
             }
             catch (Exception)
             {
                 comboBox.DataSource = null;
             }
         }
         public static void InitCBRequestAskNUM(ComboBox comboBox, string askbycode, string yearin)
         {
             try
             {
                 comboBox.DataSource = GetAskByNUMTab(askbycode, yearin);
                 comboBox.DisplayMember = "NUM";
                 comboBox.ValueMember = "NUM";
                 comboBox.AutoCompleteMode = AutoCompleteMode.Append;
                 comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                 comboBox.SelectedIndex = comboBox.Items.Count - 1;
             }
             catch (Exception)
             {
                 comboBox.DataSource = null;
             }
         }
         public static DataTable GetAskByNUMTab(string askbyCode, string yearin)
         {
             int maxNUM = 0;
             _dtAskbyNUM = new DataTable();
             _dtAskbyNUM.Columns.Add("NUM", typeof(string));

             if (!String.IsNullOrWhiteSpace(askbyCode) && !String.IsNullOrWhiteSpace(yearin))
             {
                 DBConnection dbconn = new DBConnection();
                 if (dbconn.openConnection() == true)
                 {
                     using (MySqlConnection conn = dbconn.getConnection())
                     {
                         string sql = string.Empty;
                         sql = "SELECT IFNULL(MAX(r.NUM),0) as maxNUM FROM request r WHERE LEFT(r.ASKBY,2)='" + askbyCode + "' AND r.YEARIN = '" + yearin + "'";

                         using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                         {
                             using (MySqlDataReader dr = cmd.ExecuteReader())
                             {
                                 if (dr.Read())
                                 {
                                     maxNUM = Convert.ToInt16(dr["maxNUM"]);
                                     // msgBox(maxNUM);
                                 }
                             }
                         }
                     }
                 }
             }

             // add number plus 1
             for (int i = 1; i <= maxNUM + 1; i++)
             {
                 _dtAskbyNUM.Rows.Add(i.ToString());
             }
             return _dtAskbyNUM;
         }
         public static DataTable GetAskByTab()
         {
             if (_dtAskby == null)
             {
                 _dtAskby = new DataTable();
                 _dtAskby.Columns.Add("ask", typeof(string));

                 // add number "00","01", ... ,"20"
                 for (int i = 0; i <= 20; i++)
                 {
                     _dtAskby.Rows.Add(i.ToString().Length < 2 ? "0" + i.ToString() : i.ToString());
                 }
                 _dtAskby.Rows.Add(".");
                 _dtAskby.Rows.Add("0");
                 _dtAskby.Rows.Add(":");
             }
            
             return _dtAskby;
         }
    }
}
