using MySql.Data.MySqlClient;
using Navy.Data;
using Navy.Data.DataTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navy.Core
{
    public class DataCoreLibrary : DBConnection
    {
        public QueryString.Search search;
        public QueryString.UpdateRecord queryUpdate;

        public DataCoreLibrary()
            : base()
        {
            search = new QueryString.Search();
            queryUpdate = new QueryString.UpdateRecord();
        }

        public DataCoreLibrary(string constr)
            : base(constr)
        {
            search = new QueryString.Search();
            queryUpdate = new QueryString.UpdateRecord();
        }

        public string GetMaxYearin()
        {
            if (Constants.maxYearin == null)
                Constants.maxYearin = base.getValuePrototype(search.GetMaxYearin(), "max_yearin");
            return Constants.maxYearin;
        }

        public int GetMaxID8Number(string armid)
        {
            return base.getNumberPrototype(search.GetMaxID8(armid), "maxID8", -1);
        }
        public string RequestRuncode(ParamPerson param, string batt, string company, string platoon, string pseq, string pertype)
        {
            int count_runcode = Int32.Parse(param.runcodefrom);
            int count_runcodeto = Int32.Parse(param.runcodeto);
            string runcode;
            bool check_batt_company = false;
            bool checkruncode = false;
            int i, bit1 = 0, bit2 = 0, bit4 = 0, bit8 = 0;
            int b1 = 0, b2 = 0, b4 = 0, b8 = 0;
            if (batt != "" || company != "" || platoon != "" || pseq != "")
            {
                if (pseq != "")
                {
                    bit1 = 1;
                }
                if (platoon != "")
                {
                    bit2 = 1;
                }
                if (company != "")
                {
                    bit4 = 1;
                }
                if (batt != "")
                {
                    bit8 = 1;
                }
                string queryStr = search.checkruncode();
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(queryStr, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        for (i = count_runcode; i <= count_runcodeto; i++)
                        {
                            checkruncode = false;
                            if (pertype == "1")
                            {
                                NavyRunNumber num = Function.GenRunningNumber(i);
                                if (batt == num.batt)
                                {
                                    b8 = 1;
                                }
                                else
                                {
                                    b8 = 0;
                                }
                                if (company == num.company)
                                {
                                    b4 = 1;
                                }
                                else
                                {
                                    b4 = 0;
                                }
                                if (platoon == num.platoon)
                                {
                                    b2 = 1;
                                }
                                else
                                {
                                    b2 = 0;
                                }
                                if (pseq == num.pseq)
                                {
                                    b1 = 1;
                                }
                                else
                                {
                                    b1 = 0;
                                }

                                param.runcode = Function.GetNavyRunningNumber(num);
                            }
                            if (bit8 == b8 && bit4 == b4 && bit2 == b2 && bit1 == b1)
                            {
                                while (reader.Read())
                                {
                                    if (reader["Runcode"].ToString() == i.ToString())
                                    {
                                        checkruncode = true;
                                        break;
                                    }
                                }
                                if (checkruncode == false)
                                {
                                    break;
                                }
                                check_batt_company = false;
                            }

                        }
                        count_runcode = i;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }

            }
            else
            {
                string queryStr = search.checkruncode();
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(queryStr, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            if (Int32.Parse(reader["Runcode"].ToString()) <= count_runcode)
                            {
                                count_runcode = Int32.Parse(reader["Runcode"].ToString());

                            }
                            else if (Int32.Parse(reader["Runcode"].ToString()) > count_runcode)
                            {
                                break;
                            }
                            count_runcode++;
                        }

                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            runcode = count_runcode.ToString();
            return runcode;
        }
        public bool CheckPersonDuplicateKeys(ParamPerson param, out string keyDuplicate, out string valueDuplicate)
        {
            string resultId13 = "";
            string resultId8 = "";
            string resultId = "";
            string resultRuncode = "";
            string resultNavyID = "";

            if (openConnection())
            {
                try
                {
                    string sql = queryUpdate.CheckPersonDuplicateKeys(param.navyid);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID13", (param.id13));
                    cmd.Parameters.AddWithValue("@ID8", (param.id8));
                    cmd.Parameters.AddWithValue("@ID", (param.id));
                    cmd.Parameters.AddWithValue("@RUNCODE", (param.runcode));
                    cmd.Parameters.AddWithValue("@YEARIN", (param.yearin));

                    if (param.navyid != "")
                    {
                        cmd.Parameters.AddWithValue("@NAVYID", (param.navyid));
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resultId13 = reader["ID13"].ToString();
                            resultId8 = reader["ID8"].ToString();
                            resultId = reader["ID"].ToString();
                            resultRuncode = reader["RUNCODE"].ToString();
                            resultNavyID = reader["NAVYID"].ToString();
                        }
                    }

                    if (param.id13 == resultId13)
                    {
                        keyDuplicate = "ID13";
                        valueDuplicate = param.id13;
                        return true;
                    }
                    else if (param.id8 == resultId8)
                    {
                        keyDuplicate = "ID8";
                        valueDuplicate = param.id8;
                        return true;
                    }
                    else if (param.id == resultId)
                    {
                        keyDuplicate = "ID";
                        valueDuplicate = param.id;
                        return true;
                    }
                    else if (param.runcode == resultRuncode)
                    {
                        keyDuplicate = "RUNCODE";
                        valueDuplicate = param.runcode;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.InnerException.Message;
                    throw ex.InnerException;
                }
                finally
                {
                    closeConnection();
                }
            }

            keyDuplicate = "";
            valueDuplicate = "";
            return false;
        }

        #region Search
        //get paging data ,not count all record
        public DataTable GetSearchPersonNivy(InputSearchPersonNivy param, int itemsPerPage, int pageNo)
        {
            return GetSearchPersonNivy(param.id13, param.name, param.sname, param.yearBD, itemsPerPage, pageNo);
        }

        //get paging data ,not count all record
        public DataTable GetSearchPersonNivy(string id13, string name, string sname, string yearBD, int itemsPerPage, int pageNo)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            DataTable dt = new DataTable();
            dt = base.getDataTablePrototype(search.searchPersonNivy(id13, name, sname, yearBD, limit.limit1, limit.limit2, true));
            return dt;
        }

        //get paging data ,count all record
        public DataTable GetSearchPersonNivy(InputSearchPersonNivy param, int itemsPerPage, int pageNo, out int count)
        {
            return GetSearchPersonNivy(param.id13, param.name, param.sname, param.yearBD, itemsPerPage, pageNo, out count);
        }

        //get paging data ,count all record
        public DataTable GetSearchPersonNivy(string id13, string name, string sname, string yearBD, int itemsPerPage, int pageNo, out int count)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            DataTable dt = new DataTable();
            dt = base.getSearchPrototype(search.searchPersonNivy(id13, name, sname, yearBD, limit.limit1, limit.limit2, true), search.searchPersonNivyCountRecord(id13, name, sname, yearBD), out count);
            return dt;
        }

        public PersonDataSet.PersonNivyDataTable GetSearchPersonNivyTemplate(InputSearchPersonNivy param, int itemsPerPage, int pageNo, out int countAllRecord)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            string queryStr = search.searchPersonNivy(param.id13, param.name, param.sname, param.yearBD, limit.limit1, limit.limit2, true);
            string queryStrCount = search.searchPersonNivyCountRecord(param.id13, param.name, param.sname, param.yearBD);

            PersonDataSet.PersonNivyDataTable dt = new PersonDataSet.PersonNivyDataTable();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                MySqlCommand cmd2 = new MySqlCommand(queryStrCount, conn);
                dt.Load(cmd.ExecuteReader());
                countAllRecord = Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public List<PersonNavy> GetSearchPersonNavy(InputSearchPersonNivy param, bool getUsedPerson, int itemsPerPage, int pageNo, out int countAllRecord)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            string queryStr = search.searchPersonNivy2(param.id13, param.name, param.sname, param.yearBD, getUsedPerson, limit.limit1, limit.limit2, true);
            string queryStrCount = search.searchPersonNivy2CountRecord(param.id13, param.name, param.sname, param.yearBD, getUsedPerson);

            List<PersonNavy> p = new List<PersonNavy>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                MySqlCommand cmd2 = new MySqlCommand(queryStrCount, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        p.Add(new PersonNavy(reader));
                    }
                }
                countAllRecord = Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return p;
        }

        public List<PersonSearch> GetSearchPerson(string navyid, string armid, InputSearchPersonNivy param, int itemsPerPage, int pageNo, out int countAllRecord)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            string queryStr = search.searchPerson(navyid, param.id13, param.name, param.sname, param.yearBD, armid, "", "", "", limit.limit1, limit.limit2, true, "", "");
            string queryStrCount = search.searchPersonCountRecord(navyid, param.id13, param.name, param.sname, param.yearBD, armid, "", "", "", "", "");

            List<PersonSearch> p = new List<PersonSearch>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                MySqlCommand cmd2 = new MySqlCommand(queryStrCount, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        p.Add(new PersonSearch(reader));
                    }
                }
                countAllRecord = Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return p;
        }

        public List<PersonSearch> GetSearchPerson(string navyid, string armid, ParamSearchPerson param, int itemsPerPage, int pageNo, out int countAllRecord)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            string queryStr = search.searchPerson(navyid, param.id13, param.name, param.sname, "", armid, param.yearin, param.id8, param.runcode, limit.limit1, limit.limit2, true, param.batt, param.company);
            string queryStrCount = search.searchPersonCountRecord(navyid, param.id13, param.name, param.sname, "", armid, param.yearin, param.id8, param.runcode, param.batt, param.company);

            List<PersonSearch> p = new List<PersonSearch>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                MySqlCommand cmd2 = new MySqlCommand(queryStrCount, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        p.Add(new PersonSearch(reader));
                    }
                }
                countAllRecord = Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return p;
        }

        public List<PersonSearch> GetSearchPersonOnlyIndictment(string navyid, string armid, ParamSearchPerson param, int itemsPerPage, int pageNo, out int countAllRecord)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            string queryStr = search.searchPerson_OnlyIndictment(param.id13, param.name, param.sname, param.yearin, param.id8);
            string queryStrCount = search.searchPersonCountRecord(navyid, param.id13, param.name, param.sname, "", armid, param.yearin, param.id8, param.runcode, param.batt, param.company);

            List<PersonSearch> p = new List<PersonSearch>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                MySqlCommand cmd2 = new MySqlCommand(queryStrCount, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        p.Add(new PersonSearch(reader));
                    }
                }
                countAllRecord = Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return p;
        }

        public List<IndicmentDataSearch> GetIndictmentData(string navyid)
        {
            //LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            string queryStr = search.SearchData_Indictment(navyid);
            // string queryStrCount = search.searchPersonCountRecord(navyid, param.id13, param.name, param.sname, "", armid, param.yearin, param.id8, param.runcode);

            List<IndicmentDataSearch> p = new List<IndicmentDataSearch>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                //MySqlCommand cmd2 = new MySqlCommand(queryStrCount, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        p.Add(new IndicmentDataSearch(reader));
                    }
                }
                //countAllRecord = Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return p;
        }

        //temp search
        public List<PersonSearch> GetSearchPerson(string navyid, string armid, ParamSearchPerson param)
        {
            string queryStr = search.searchPerson(navyid, param.id13, param.name, param.sname, "", armid, param.yearin, param.id8, param.runcode, 0, 0, false, param.batt, param.company);
            List<PersonSearch> p = new List<PersonSearch>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        p.Add(new PersonSearch(reader));
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return p;
        }

        public DataTable GetSearchPersonTable(string navyid, string armid, InputSearchPersonNivy param, int itemsPerPage, int pageNo, out int countAllRecord)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            DataTable dt = new DataTable();
            string queryStr = search.searchPerson(navyid, param.id13, param.name, param.sname, param.yearBD, armid, "", "", "", limit.limit1, limit.limit2, true, "", "");
            string queryStrCount = search.searchPersonCountRecord(navyid, param.id13, param.name, param.sname, param.yearBD, armid, "", "", "", "", "");
            dt = base.getSearchPrototype(queryStr, queryStrCount, out countAllRecord);
            return dt;
        }

        public DataTable GetSearchPersonTable(string navyid, ParamSearchPerson param, int itemsPerPage, int pageNo, out int countAllRecord)
        {
            LimitMySQL limit = Function.GetLimitFromPage(itemsPerPage, pageNo);
            DataTable dt = new DataTable();
            string queryStr = search.searchPerson(navyid, param.id13, param.name, param.sname, "", "", param.yearin, param.id8, param.runcode, limit.limit1, limit.limit2, true, param.batt, param.company);
            string queryStrCount = search.searchPersonCountRecord(navyid, param.id13, param.name, param.sname, "", "", param.yearin, param.id8, param.runcode, param.batt, param.company);
            dt = base.getSearchPrototype(queryStr, queryStrCount, out countAllRecord);
            return dt;
        }

        public DataTable GetSearchPersonTable(string navyid, ParamSearchPerson param, out int countAllRecord)
        {
            DataTable dt = new DataTable();
            string queryStr = search.searchPerson(navyid, param.id13, param.name, param.sname, "", "", param.yearin, param.id8, param.runcode, 0, 0, false, param.batt, param.company);
            string queryStrCount = search.searchPersonCountRecord(navyid, param.id13, param.name, param.sname, "", "", param.yearin, param.id8, param.runcode, param.batt, param.company);
            dt = base.getSearchPrototype(queryStr, queryStrCount, out countAllRecord);
            return dt;
        }
        //new
        public DataTable GetTotalselectunit(string UNIT3, out int countAllRecord)
        {
            DataTable dt = new DataTable();
            string queryStr = search.searchPersonbyunit(UNIT3);
            string queryStrCount = search.searchPersonCountRecordbyunit(UNIT3);
            dt = base.getSearchPrototype(queryStr, queryStrCount, out countAllRecord);
            return dt;
        }
        public DataTable GetNlabelInUnit(string UNIT3, out int countAllRecord)
        {
            DataTable dt = new DataTable();
            string queryStr = search.searchNlabelInUnit(UNIT3);
            string queryStrCount = search.searchNlabelInUnitCountRecord(UNIT3);
            dt = base.getSearchPrototype(queryStr, queryStrCount, out countAllRecord);
            return dt;
        }
        public DataTable GetNlabelNotInUnit(string UNIT3, out int countAllRecord)
        {
            DataTable dt = new DataTable();
            string queryStr = search.searchNlabelNotInUnit(UNIT3);
            string queryStrCount = search.searchNlabelNotInUnitCountRecord(UNIT3);
            dt = base.getSearchPrototype(queryStr, queryStrCount, out countAllRecord);
            return dt;
        }


        public ParamPerson GetPersonParam(string navyid)
        {
            LimitMySQL limit = Function.GetLimitFromPage(50, 1);
            string queryStr = search.searchPerson(navyid, "", "", "", "", "", "", "", "", limit.limit1, limit.limit2, true, "", "");
            string queryStrCount = search.searchPersonCountRecord(navyid, "", "", "", "", "", "", "", "", "", "");

            ParamPerson p = new ParamPerson();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                MySqlCommand cmd2 = new MySqlCommand(queryStrCount, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new ParamPerson(reader);
                    }
                }
                //countAllRecord = Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return p;
        }

        #endregion

        #region Person Transaction Record
        public bool InsertPerson(ParamPerson param)
        {
            if (openConnection())
            {
                //using (MySqlTransaction trans = conn.BeginTransaction())
                //{
                try
                {
                    string sql = queryUpdate.InsertNewPerson();
                    //string sql = param.GetQueryInsertPerson();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@YEARIN", (param.yearin));
                        cmd.Parameters.AddWithValue("@origincode", (param.origincode));
                        cmd.Parameters.AddWithValue("@REGDATE", (param.regDate.Date));
                        cmd.Parameters.AddWithValue("@REPDATE", (param.repDate.Date));
                        cmd.Parameters.AddWithValue("@ID13", (param.id13));
                        cmd.Parameters.AddWithValue("@NAME_", (param.name));
                        cmd.Parameters.AddWithValue("@SNAME", (param.sname));

                        cmd.Parameters.AddWithValue("@BIRTHDATE", (param.birthdate));
                        cmd.Parameters.AddWithValue("@ADDRESS", (param.address));
                        cmd.Parameters.AddWithValue("@ADDRESS_MU", (param.address_mu));
                        cmd.Parameters.AddWithValue("@ADDRESS_SOIL", (param.address_soil));
                        cmd.Parameters.AddWithValue("@ADDRESS_ROAD", (param.address_road));
                        cmd.Parameters.AddWithValue("@TOWNCODE", (param.towncode));
                        cmd.Parameters.AddWithValue("@ARMID", (param.armid));
                        cmd.Parameters.AddWithValue("@FATHER", (param.father));
                        cmd.Parameters.AddWithValue("@FSNAME", (param.fsname));
                        cmd.Parameters.AddWithValue("@MOTHER", (param.mother));
                        cmd.Parameters.AddWithValue("@MSNAME", (param.msname));
                        cmd.Parameters.AddWithValue("@PERTYPE", (param.pertype));
                        cmd.Parameters.AddWithValue("@RUNCODE", (param.runcode));
                        cmd.Parameters.AddWithValue("@ID8", (param.id8));
                        cmd.Parameters.AddWithValue("@ID", (param.id));
                        cmd.Parameters.AddWithValue("@MARK", (param.mark));
                        cmd.Parameters.AddWithValue("@EDUCODE0", (param.educode0));
                        cmd.Parameters.AddWithValue("@EDUCODE1", (param.educode1));
                        cmd.Parameters.AddWithValue("@EDUCODE2", (param.educode2));
                        cmd.Parameters.AddWithValue("@REGCODE", (param.regcode));
                        cmd.Parameters.AddWithValue("@OCCCODE", (param.occcode));
                        cmd.Parameters.AddWithValue("@HEIGHT", (param.height));
                        cmd.Parameters.AddWithValue("@WIDTH", (param.width));
                        cmd.Parameters.AddWithValue("@IS_REQUEST", (param.is_request));
                        cmd.Parameters.AddWithValue("@RECORDBY", (Environment.MachineName));

                        cmd.Parameters.AddWithValue("@BATT", (param.batt));
                        cmd.Parameters.AddWithValue("@COMPANY", (param.company));
                        cmd.Parameters.AddWithValue("@PLATOON", (param.platoon));
                        cmd.Parameters.AddWithValue("@PSEQ", (param.pseq));
                        cmd.Parameters.AddWithValue("@SKILLCODE", (param.skill));
                        cmd.Parameters.AddWithValue("@Telephone", (param.telephone));
                        cmd.Parameters.AddWithValue("@FTelephone", (param.ftelephone));
                        cmd.Parameters.AddWithValue("@MTelephone", (param.mtelephone));
                        cmd.Parameters.AddWithValue("@PTelephone", (param.ptelephone));
                        cmd.Parameters.AddWithValue("@kpt", (param.cmBoxkpt));
                        //cmd.Parameters.AddWithValue("@patient_status", (param.cmbPatient_status));
                        cmd.Parameters.AddWithValue("@addictive_status", (param.cmbAddictive_status));
                        cmd.Parameters.AddWithValue("@flagreadfrom_IDCard", (param.flagreadfrom_IDCard));
                        cmd.Parameters.AddWithValue("@BankID", (param.BankID));
                        cmd.Parameters.AddWithValue("@AccountNum", (param.AccountNum));
                        cmd.ExecuteNonQuery();
                    }
                    //trans.Commit();
                }
                catch (Exception ex)
                {
                    //string e = ex.InnerException.Message;
                    //trans.Rollback();                        
                    throw;
                }
                finally
                {
                    closeConnection();
                }
                //}
                //closeConnection();
            }
            return true;
        }
        public bool InsertPeople(DataRow param)
        {
            if (openConnection())
            {
                //using (MySqlTransaction trans = conn.BeginTransaction())
                //{
                try
                {
                    string sql = queryUpdate.InsertNewPeople();
                    //string sql = param.GetQueryInsertPerson();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id13", (param["id13"]));
                        cmd.Parameters.AddWithValue("@navyid", (param["navyid"]));
                        cmd.Parameters.AddWithValue("@people_name", (param["people_name"]));
                        cmd.Parameters.AddWithValue("@people_lname", (param["people_lname"]));
                        cmd.Parameters.AddWithValue("@address_in", (param["address_in"]));
                        cmd.Parameters.AddWithValue("@address_mu_in", (param["address_mu_in"]));
                        cmd.Parameters.AddWithValue("@address_soid_in", (param["address_soid_in"]));
                        cmd.Parameters.AddWithValue("@address_road_in", (param["address_road_in"]));
                        cmd.Parameters.AddWithValue("@towncode_in", (param["towncode_in"]));


                        cmd.Parameters.AddWithValue("@address_out", (param["address_out"]));
                        cmd.Parameters.AddWithValue("@address_mu_out", (param["address_mu_out"]));
                        cmd.Parameters.AddWithValue("@address_soid_out", (param["address_soid_out"]));
                        cmd.Parameters.AddWithValue("@address_road_out", (param["address_road_out"]));
                        cmd.Parameters.AddWithValue("@towncode_out", (param["towncode_out"]));


                        cmd.Parameters.AddWithValue("@book_number", (param["book_number"]));
                        cmd.Parameters.AddWithValue("@type_out", (param["type_out"]));
                        cmd.Parameters.AddWithValue("@rank", (param["rank"]));
                        cmd.Parameters.AddWithValue("@status", (param["status"]));
                        cmd.Parameters.AddWithValue("@dead_date", (param["dead_date"]));
                        cmd.Parameters.AddWithValue("@out_date", (param["out_date"]));
                        cmd.Parameters.AddWithValue("@in_date", (param["in_date"]));
                        cmd.Parameters.AddWithValue("@pseq", (param["pseq"]));


                        cmd.ExecuteNonQuery();
                    }
                    //trans.Commit();
                }
                catch (Exception ex)
                {
                    //string e = ex.InnerException.Message;
                    //trans.Rollback();                        
                    throw;
                }
                finally
                {
                    closeConnection();
                }
                //}
                //closeConnection();
            }
            return true;
        }
        public bool UpdatePeople(ParamPeople param)
        {
            if (openConnection())
            {
                //using (MySqlTransaction trans = conn.BeginTransaction())
                //{
                try
                {
                    string sql = queryUpdate.UpdatePeople();
                    //string sql = param.GetQueryInsertPerson();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id13", (param.id13));
                        cmd.Parameters.AddWithValue("@navyid", (param.navyid));

                        cmd.Parameters.AddWithValue("@address_in", (param.address_in));
                        cmd.Parameters.AddWithValue("@address_mu_in", (param.address_mu_in));
                        cmd.Parameters.AddWithValue("@address_soid_in", (param.address_soid_in));
                        cmd.Parameters.AddWithValue("@address_road_in", (param.address_road_in));
                        cmd.Parameters.AddWithValue("@towncode_in", (param.towncode_in));


                        cmd.Parameters.AddWithValue("@address_out", (param.address_out));
                        cmd.Parameters.AddWithValue("@address_mu_out", (param.address_mu_out));
                        cmd.Parameters.AddWithValue("@address_soid_out", (param.address_soid_out));
                        cmd.Parameters.AddWithValue("@address_road_out", (param.address_road_out));
                        cmd.Parameters.AddWithValue("@towncode_out", (param.towncode_out));


                        cmd.Parameters.AddWithValue("@book_number", (param.book_number));
                        cmd.Parameters.AddWithValue("@type_out", (param.type_out));
                        cmd.Parameters.AddWithValue("@rank", (param.rank));
                        cmd.Parameters.AddWithValue("@status", (param.status));
                        cmd.Parameters.AddWithValue("@dead_date", (param.dead_date));
                        cmd.Parameters.AddWithValue("@out_date", (param.out_date));
                        cmd.Parameters.AddWithValue("@in_date", (param.in_date));
                        cmd.Parameters.AddWithValue("@pseq", (param.pseq));

                        cmd.ExecuteNonQuery();
                    }
                    //trans.Commit();
                }
                catch (Exception ex)
                {
                    //string e = ex.InnerException.Message;
                    //trans.Rollback();                        
                    throw;
                }
                finally
                {
                    closeConnection();
                }
                //}
                //closeConnection();
            }
            return true;
        }
        public bool UpdatePeople(DataRow param)
        {
            if (openConnection())
            {
                //using (MySqlTransaction trans = conn.BeginTransaction())
                //{
                try
                {
                    string sql = queryUpdate.UpdatePeople();
                    //string sql = param.GetQueryInsertPerson();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id13", (param["id13"]));
                        cmd.Parameters.AddWithValue("@navyid", (param["navyid"]));
                        cmd.Parameters.AddWithValue("@people_name", (param["people_name"]));
                        cmd.Parameters.AddWithValue("@people_lname", (param["people_lname"]));

                        cmd.Parameters.AddWithValue("@address_in", (param["address_in"]));
                        cmd.Parameters.AddWithValue("@address_mu_in", (param["address_mu_in"]));
                        cmd.Parameters.AddWithValue("@address_soid_in", (param["address_soid_in"]));
                        cmd.Parameters.AddWithValue("@address_road_in", (param["address_road_in"]));
                        cmd.Parameters.AddWithValue("@towncode_in", (param["towncode_in"]));


                        cmd.Parameters.AddWithValue("@address_out", (param["address_out"]));
                        cmd.Parameters.AddWithValue("@address_mu_out", (param["address_mu_out"]));
                        cmd.Parameters.AddWithValue("@address_soid_out", (param["address_soid_out"]));
                        cmd.Parameters.AddWithValue("@address_road_out", (param["address_road_out"]));
                        cmd.Parameters.AddWithValue("@towncode_out", (param["towncode_out"]));


                        cmd.Parameters.AddWithValue("@book_number", (param["book_number"]));
                        cmd.Parameters.AddWithValue("@type_out", (param["type_out"]));
                        cmd.Parameters.AddWithValue("@rank", (param["rank"]));
                        cmd.Parameters.AddWithValue("@status", (param["status"]));
                        cmd.Parameters.AddWithValue("@dead_date", (param["dead_date"]));
                        cmd.Parameters.AddWithValue("@out_date", (param["out_date"]));
                        cmd.Parameters.AddWithValue("@in_date", (param["in_date"]));

                        cmd.Parameters.AddWithValue("@report_number", (param["report_number"]));
                        cmd.Parameters.AddWithValue("@report_date", (param["report_date"]));
                        cmd.Parameters.AddWithValue("@pseq", (param["pseq"]));

                        cmd.ExecuteNonQuery();
                    }
                    //trans.Commit();
                }
                catch (Exception ex)
                {
                    //string e = ex.InnerException.Message;
                    //trans.Rollback();                        
                    throw;
                }
                finally
                {
                    closeConnection();
                }
                //}
                //closeConnection();
            }
            return true;
        }
        public bool UpdatePerson(ParamPerson param, string navyid)
        {
            if (openConnection())
            {
                //using (MySqlTransaction trans = conn.BeginTransaction())
                //{
                try
                {
                    string sql = queryUpdate.UpdatePerson(navyid);
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@YEARIN", (param.yearin));
                        cmd.Parameters.AddWithValue("@origincode", (param.origincode));
                        cmd.Parameters.AddWithValue("@REGDATE", (param.regDate.Date));
                        cmd.Parameters.AddWithValue("@REPDATE", (param.repDate.Date));
                        cmd.Parameters.AddWithValue("@ID13", (param.id13));
                        cmd.Parameters.AddWithValue("@NAME_", (param.name));
                        cmd.Parameters.AddWithValue("@SNAME", (param.sname));

                        cmd.Parameters.AddWithValue("@BIRTHDATE", (param.birthdate));
                        cmd.Parameters.AddWithValue("@ADDRESS", (param.address));
                        cmd.Parameters.AddWithValue("@ADDRESS_MU", (param.address_mu));
                        cmd.Parameters.AddWithValue("@ADDRESS_SOIL", (param.address_soil));
                        cmd.Parameters.AddWithValue("@ADDRESS_ROAD", (param.address_road));
                        cmd.Parameters.AddWithValue("@TOWNCODE", (param.towncode));
                        cmd.Parameters.AddWithValue("@ARMID", (param.armid));
                        cmd.Parameters.AddWithValue("@FATHER", (param.father));
                        cmd.Parameters.AddWithValue("@FSNAME", (param.fsname));
                        cmd.Parameters.AddWithValue("@MOTHER", (param.mother));
                        cmd.Parameters.AddWithValue("@MSNAME", (param.msname));
                        cmd.Parameters.AddWithValue("@PERTYPE", (param.pertype));
                        cmd.Parameters.AddWithValue("@RUNCODE", (param.runcode));
                        cmd.Parameters.AddWithValue("@ID8", (param.id8));
                        cmd.Parameters.AddWithValue("@ID", (param.id));
                        cmd.Parameters.AddWithValue("@MARK", (param.mark));
                        cmd.Parameters.AddWithValue("@EDUCODE0", (param.educode0));
                        cmd.Parameters.AddWithValue("@EDUCODE1", (param.educode1));
                        cmd.Parameters.AddWithValue("@EDUCODE2", (param.educode2));
                        cmd.Parameters.AddWithValue("@REGCODE", (param.regcode));
                        cmd.Parameters.AddWithValue("@OCCCODE", (param.occcode));
                        cmd.Parameters.AddWithValue("@HEIGHT", (param.height));
                        cmd.Parameters.AddWithValue("@WIDTH", (param.width));
                        cmd.Parameters.AddWithValue("@IS_REQUEST", (param.is_request));
                        cmd.Parameters.AddWithValue("@RECORDBY", (Environment.MachineName));

                        cmd.Parameters.AddWithValue("@BATT", (param.batt));
                        cmd.Parameters.AddWithValue("@COMPANY", (param.company));
                        cmd.Parameters.AddWithValue("@PLATOON", (param.platoon));
                        cmd.Parameters.AddWithValue("@PSEQ", (param.pseq));
                        cmd.Parameters.AddWithValue("@SKILLCODE", (param.skill));

                        cmd.Parameters.AddWithValue("@telephone", (param.telephone));
                        cmd.Parameters.AddWithValue("@ftelephone", (param.ftelephone));
                        cmd.Parameters.AddWithValue("@mtelephone", (param.mtelephone));
                        cmd.Parameters.AddWithValue("@ptelephone", (param.ptelephone));
                        cmd.Parameters.AddWithValue("@percent", (param.percent));
                        cmd.Parameters.AddWithValue("@kpt", (param.cmBoxkpt));
                        //cmd.Parameters.AddWithValue("@patient_status", (param.cmbPatient_status));
                        cmd.Parameters.AddWithValue("@addictive_status", (param.cmbAddictive_status));
                        cmd.Parameters.AddWithValue("@flagreadfrom_IDCard", (param.flagreadfrom_IDCard));
                        cmd.Parameters.AddWithValue("@BankID", (param.BankID));
                        cmd.Parameters.AddWithValue("@AccountNum", (param.AccountNum));
                        cmd.ExecuteNonQuery();
                    }
                    //trans.Commit();
                }
                catch (Exception ex)
                {
                    //string e = ex.InnerException.Message;
                    //trans.Rollback();
                    throw;
                }
                finally
                {
                    closeConnection();
                }
                //}
                //closeConnection();
            }
            return true;
        }
        public bool InsertSubunit(DataRow param)
        {
            if (openConnection())
            {
                //using (MySqlTransaction trans = conn.BeginTransaction())
                //{
                try
                {
                    string sql = queryUpdate.InsertNewSubUnit();
                    //string sql = param.GetQueryInsertPerson();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@unit_id", (param["unit_id"]));
                        cmd.Parameters.AddWithValue("@subunit_id", (param["subunit_id"]));
                        cmd.Parameters.AddWithValue("@unit_name", (param["unit_name"]));
                        cmd.Parameters.AddWithValue("@TOWNCODE", (param["TOWNCODE"]));
                        cmd.Parameters.AddWithValue("@ADDRESS", (param["ADDRESS"]));
                        cmd.Parameters.AddWithValue("@ADDRESS_MU", (param["ADDRESS_MU"]));
                        cmd.Parameters.AddWithValue("@ADDRESS_SOIL", (param["ADDRESS_SOIL"]));
                        cmd.Parameters.AddWithValue("@ADDRESS_ROAD", (param["ADDRESS_ROAD"]));
                        cmd.Parameters.AddWithValue("@level", (param["level"]));




                        cmd.ExecuteNonQuery();
                    }
                    //trans.Commit();
                }
                catch (Exception ex)
                {
                    //string e = ex.InnerException.Message;
                    //trans.Rollback();                        
                    throw;
                }
                finally
                {
                    closeConnection();
                }
                //}
                //closeConnection();
            }
            return true;
        }
        public bool InsertPersonNivy(PersonDataSet.PersonNivyRow param)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = queryUpdate.InsertPersonNivy();
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID13", (param.ID13));
                            cmd.Parameters.AddWithValue("@NAME_", (param.NAME));
                            cmd.Parameters.AddWithValue("@SNAME", (param.SNAME));
                            cmd.Parameters.AddWithValue("@BIRTHDATE", (param.BIRTHDATE));
                            cmd.Parameters.AddWithValue("@FATHER", (param.IsFATHERNull() ? null : param.FATHER));
                            cmd.Parameters.AddWithValue("@LFANAME", (param.IsLFANAMENull() ? null : param.LFANAME));
                            cmd.Parameters.AddWithValue("@MOTHER", (param.IsMOTHERNull() ? null : param.MOTHER));
                            cmd.Parameters.AddWithValue("@LMANAME", (param.IsLMANAMENull() ? null : param.LMANAME));

                            cmd.Parameters.AddWithValue("@MID", (param.IsMIDNull() ? null : param.MID));
                            cmd.Parameters.AddWithValue("@MID_DATE", (param.IsMID_DATENull() ? null : param.MID_DATE));
                            cmd.Parameters.AddWithValue("@SCARE", (param.IsSCARENull() ? null : param.SCARE));
                            cmd.Parameters.AddWithValue("@ADDRESS", (param.IsADDRESSNull() ? null : param.ADDRESS));
                            cmd.Parameters.AddWithValue("@M_TT", (param.IsM_TTNull() ? null : param.M_TT));
                            cmd.Parameters.AddWithValue("@EMPLOYMENT", (param.IsEMPLOYMENTNull() ? null : param.EMPLOYMENT));
                            cmd.Parameters.AddWithValue("@TALL", (param.IsTALLNull() ? null : param.TALL));
                            cmd.Parameters.AddWithValue("@WEIGHT", (param.IsWEIGHTNull() ? null : param.WEIGHT));
                            cmd.Parameters.AddWithValue("@CHESS_IN", (param.IsCHESS_INNull() ? null : param.CHESS_IN));
                            cmd.Parameters.AddWithValue("@CHESS_OUT", (param.IsCHESS_OUTNull() ? null : param.CHESS_OUT));
                            cmd.Parameters.AddWithValue("@RECRUIT_CODE", (param.IsRECRUIT_CODENull() ? null : param.RECRUIT_CODE));
                            cmd.Parameters.AddWithValue("@RECRUIT_DATE", (param.IsRECRUIT_DATENull() ? null : param.RECRUIT_DATE));
                            cmd.Parameters.AddWithValue("@RECRUIT_NOTE", (param.IsRECRUIT_NOTENull() ? null : param.RECRUIT_NOTE));
                            cmd.Parameters.AddWithValue("@YEARIN", (param.IsYEARINNull() ? null : param.YEARIN));

                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }

        public bool UpdatePersonUsed(string id13)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE navy SET USED = '1' WHERE PID = '" + id13 + "' ";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }

        public bool UpdatePersonUnUsed(string id13)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE navy SET USED = '0' WHERE PID = '" + id13 + "' ";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }
        // new
        public bool Updatereport_number(string NAVYID, string report_number)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE people SET report_number = '" + report_number + "' WHERE NAVYID = '" + NAVYID + "' ";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }
        public bool Clearreport_number(string NAVYID)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE people SET report_number = null,address_out= null,address_mu_out= null,address_soid_out= null,address_road_out= null,towncode_out= null WHERE NAVYID = '" + NAVYID + "' ";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }
        public bool UpdateNLabelPerson(string NAVYID, string NLABEL)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE person SET NLABEL = '" + NLABEL + "' WHERE NAVYID = '" + NAVYID + "' ";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }
        public bool ClearNLabelPerson(string UNIT3)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE person SET NLABEL = null WHERE UNIT3 = '" + UNIT3 + "' ";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }
        public bool ClearAllNLabelPerson()
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE person SET NLABEL = null ";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }
        public bool DeletePerson(string navyid)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "DELETE FROM Person WHERE NAVYID = '" + navyid + "' ";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }
        #endregion

        #region Person Transfer DB

        #endregion

        #region Report
        public PersonDataSet.SummaryPersonDataTable ReportSummaryNewPersonByArmtown(List<string> yearin)
        {
            return new PersonDataSet.SummaryPersonDataTable();
        }

        public PersonDataSet.SummaryPersonDataTable ReportSummaryNewPersonByArmtown()
        {
            PersonDataSet.SummaryPersonDataTable dt = new PersonDataSet.SummaryPersonDataTable();
            string queryStr = search.sumPersonByArmtown("");
            try
            {
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public PersonDataSet.PersonLabelUnitDataTable ReportLabelUnitListPerson(string yearin)
        {
            PersonDataSet.PersonLabelUnitDataTable dt = new PersonDataSet.PersonLabelUnitDataTable();
            string queryStr = search.reportDevideUnitListPerson(yearin);
            try
            {
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public Profileview.DataTable1DataTable GetViewProfile(string navyid)
        {
            Profileview.DataTable1DataTable dt = new Profileview.DataTable1DataTable();
            string queryStr = search.GetViewdata(navyid);
            try
            {
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        #endregion

        #region PersonRequest
        public PersonRequestDataSet.PersonDataTable GetSearchPersonForRequest(ParamSearchPerson param)
        {
            string queryStr = search.searchPersonRequest("", param.name, param.sname, param.id8, param.yearin, true);
            PersonRequestDataSet.PersonDataTable dt = new PersonRequestDataSet.PersonDataTable();
            dt.noColumn.DataType = typeof(int);
            dt.noColumn.AutoIncrement = true;
            dt.noColumn.AutoIncrementSeed = 1;
            dt.noColumn.AutoIncrementStep = 1;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                dt.Load(cmd.ExecuteReader());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public PersonRequestDataSet.PersonRequestDataTable GetSearchRequest(ParamSearchPerson param, QueryString.Search.RequestPersonFilter type)
        {
            string queryStr = search.searchRequest("", param.name, param.sname, param.id8, param.yearin, type);
            PersonRequestDataSet.PersonRequestDataTable dt = new PersonRequestDataSet.PersonRequestDataTable();
            dt.noColumn.DataType = typeof(int);
            dt.noColumn.AutoIncrement = true;
            dt.noColumn.AutoIncrementSeed = 1;
            dt.noColumn.AutoIncrementStep = 1;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                dt.Load(cmd.ExecuteReader());

            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public PersonRequest GetPersonRequestDetail(string navyid, string askby, string unit)
        {
            PersonRequest personReq = new PersonRequest();
            if (openConnection())
            {
                string sql = "SELECT p.* \n";
                sql += ",r.navyid as request_navyid,r.unit as request_unit,r.askby as request_askby,r.remark as request_remark,r.remark2 as request_remark2,utRequest.unitname as request_unitname,r.num as request_num,r.updby as request_updby,r.updatecount as request_updatecount \n";
                sql += ",sx.item as sxitem,ut4.unitname as unit4name \n";
                sql += ",stt.stitle,ut.unitname,ut1.unitname as unit1name,ut2.unitname as unit2name,pt.postname,et.educname,st.skill \n";
                sql += "FROM person p LEFT OUTER JOIN request r ON (p.NAVYID=r.navyid) \n";
                sql += "LEFT OUTER JOIN statustab stt ON (p.STATUSCODE = stt.STATUSCODE) \n";
                sql += "LEFT OUTER JOIN unittab ut ON (p.UNIT3 = ut.REFNUM) \n";
                sql += "LEFT OUTER JOIN selectexam sx ON (p.NAVYID = sx.NAVYID) \n";
                sql += "LEFT OUTER JOIN positiontab pt ON (sx.Postcode = pt.POSTCODE) \n";
                sql += "LEFT OUTER JOIN unittab ut4 ON (sx.Unit4 = ut4.REFNUM) \n";
                sql += "LEFT OUTER JOIN eductab et ON (p.EDUCODE1 = et.ECODE1 AND p.EDUCODE2 = et.ECODE2) \n";
                sql += "LEFT OUTER JOIN skilltab st ON (p.SKILLCODE = st.SKILLCODE) \n";
                sql += "LEFT OUTER JOIN unittab ut1 ON (p.UNIT1 = ut1.REFNUM) \n";
                sql += "LEFT OUTER JOIN unittab ut2 ON (p.UNIT2 = ut2.REFNUM) \n";
                sql += "LEFT OUTER JOIN unittab utRequest ON (r.UNIT = utRequest.REFNUM) \n";
                sql += "WHERE p.NAVYID = '" + navyid + "' \n";

                if (!String.IsNullOrWhiteSpace(askby))
                {
                    sql += "AND r.askby = '" + askby + "' \n";
                }
                if (!String.IsNullOrWhiteSpace(unit))
                {
                    sql += "AND r.unit = '" + unit + "' \n";
                }

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personReq = new PersonRequest(reader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    personReq = new PersonRequest();
                    closeConnection();
                    //throw;
                }
                closeConnection();
            }
            return personReq;
        }

        public PersonRequest GetPersonRequestDetail(string navyid)
        {
            return GetPersonRequestDetail(navyid, "", "");
        }

        public bool UpdateRequest(PersonRequest personReq, ParamPersonRequest param)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql;
                        if (personReq.request.navyid == "")
                        {
                            sql = queryUpdate.InsertRequest();
                        }
                        else
                        {
                            sql = queryUpdate.UpdateRequest(param.updatecount);
                        }

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@yearin", (personReq.person.yearin));
                            cmd.Parameters.AddWithValue("@name_", (personReq.person.name));
                            cmd.Parameters.AddWithValue("@sname", (personReq.person.sname));
                            cmd.Parameters.AddWithValue("@id8", (personReq.person.id8));

                            cmd.Parameters.AddWithValue("@navyid", (param.navyid));
                            cmd.Parameters.AddWithValue("@unit", (param.unit));
                            cmd.Parameters.AddWithValue("@askby", (param.askby));
                            cmd.Parameters.AddWithValue("@num", (param.num));
                            cmd.Parameters.AddWithValue("@remark", (param.remark));
                            cmd.Parameters.AddWithValue("@remark2", (param.remark2));
                            cmd.Parameters.AddWithValue("@flag", (param.flag));
                            //cmd.Parameters.AddWithValue("@upddate", param.upddate.Date);
                            cmd.Parameters.AddWithValue("@piority", (param.piority));
                            cmd.Parameters.AddWithValue("@username", (param.username));
                            cmd.Parameters.AddWithValue("@updatecount", param.updatecount);
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        closeConnection();
                        throw;
                    }
                }
                closeConnection();
            }
            return true;
        }

        //public bool UpdateRequestNUM(ParamPersonRequest param)
        //{
        //    if (openConnection())
        //    {
        //        using (MySqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                string sql= "";
        //                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@yearin", (personReq.person.yearin));
        //                    cmd.Parameters.AddWithValue("@name_", (personReq.person.name));
        //                    cmd.Parameters.AddWithValue("@sname", (personReq.person.sname));
        //                    cmd.Parameters.AddWithValue("@id8", (personReq.person.id8));

        //                    cmd.Parameters.AddWithValue("@navyid", (param.navyid));
        //                    cmd.Parameters.AddWithValue("@unit", (param.unit));
        //                    cmd.Parameters.AddWithValue("@askby", (param.askby));
        //                    cmd.Parameters.AddWithValue("@num", (param.num));
        //                    cmd.Parameters.AddWithValue("@remark", (param.remark));
        //                    cmd.Parameters.AddWithValue("@remark2", (param.remark2));
        //                    cmd.Parameters.AddWithValue("@flag", (param.flag));
        //                    //cmd.Parameters.AddWithValue("@upddate", param.upddate.Date);
        //                    cmd.Parameters.AddWithValue("@piority", (param.piority));
        //                    cmd.Parameters.AddWithValue("@username", (param.username));
        //                    cmd.Parameters.AddWithValue("@updatecount", param.updatecount);
        //                    cmd.ExecuteNonQuery();
        //                }
        //                trans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                closeConnection();
        //                throw;
        //            }
        //        }
        //        closeConnection();
        //    }
        //    return true;
        //}

        public bool DeletePersonRequest(string navyid, string askby, string unit)
        {
            string msg = "";
            string sql;
            sql = "DELETE FROM request WHERE navyid = '" + navyid + "' AND ASKBY = '" + askby + "' AND UNIT = '" + unit + "' ; \n";
            //sql += "UPDATE person p\n" +
            //        "SET p.UNIT0 = NULL, p.UNIT3 = NULL, p.ASK = NULL, p.NUMBER = NULL, p.REM = NULL, p.REM2 = NULL \n" +
            //        "WHERE p.NAVYID = '" + (personReq.person.navyid) + "'; \n";

            bool success = DBConnection.runCmdTransaction(sql, base.conn, out msg);
            return success;
        }

        public bool UpdatePersonUnit3(string pNavyId, string unit3)
        {
            string msg = "";
            string sql;
            sql = "UPDATE person p SET p.UNIT3 = '" + (unit3) + "' WHERE p.NAVYID = '" + (pNavyId) + "';\n";

            bool success = DBConnection.runCmdTransaction(sql, base.conn, out msg);
            return success;
        }

        public bool CheckRequestMultiple(string navyid)
        {
            return true;
        }

        public bool CheckRequestDuplicateNUM(ParamPersonRequest param)
        {
            int countNUM = 0;
            string sql = search.CheckRequestDuplicateNUM(param.askby, param.num);
            countNUM = base.getNumberPrototype(sql, "countNUM", -1);
            return countNUM > 1 ? true : false;
        }

        public PersonRequestDataSet.PersonRequestDataTable GetRequestNUMHigher(string askby, string num)
        {
            PersonRequestDataSet.PersonRequestDataTable dt = new PersonRequestDataSet.PersonRequestDataTable();
            string queryStr = search.GetRequestNUMHigher(askby, num);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                dt.Load(cmd.ExecuteReader());
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool ReOrderNUMRequest(PersonRequestDataSet.PersonRequestDataTable listParam, ParamPersonRequest param)
        {
            int rowsAffect = 0;
            bool success = true;
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //listParam.OrderBy()
                        foreach (PersonRequestDataSet.PersonRequestRow r in listParam)
                        {
                            if (r.navyid == param.navyid)
                            {
                                continue;
                            }

                            string sql = "UPDATE request r SET r.NUM = @num, r.UPDDATE = CURDATE(), r.UPDTIME = CURTIME(), r.UPDBY = @username, r.UPDATECOUNT = @updatecount \n" +
                                " WHERE r.NAVYID = @navyid AND r.ASKBY = @askby AND r.UNIT = @unit ;\n";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@num", Convert.ToInt16(r.num) + 1);
                            cmd.Parameters.AddWithValue("@navyid", r.navyid);
                            cmd.Parameters.AddWithValue("@askby", r.askby);
                            cmd.Parameters.AddWithValue("@unit", r.unit);
                            cmd.Parameters.AddWithValue("@username", Environment.MachineName);
                            cmd.Parameters.AddWithValue("@updatecount", Convert.ToInt16(r.updatecount) + 1);

                            rowsAffect += cmd.ExecuteNonQuery();
                        }
                        success = true;
                        trans.Commit();
                        //if (rowsAffect != listParam.Count)
                        //{
                        //    success = false;
                        //    trans.Rollback();
                        //}
                        //else
                        //{
                        //    success = true;
                        //    trans.Commit();
                        //}
                    }
                    catch
                    {
                        success = false;
                        trans.Rollback();
                        closeConnection();
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return success;
        }
        #endregion

        #region DevideUnit
        public bool UpdateNLabel(string yearin, string unit, int nlabel, LimitMySQL limit)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = queryUpdate.UpdateNLabel();
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@unit", (unit));
                            cmd.Parameters.AddWithValue("@yearin", (yearin));
                            cmd.Parameters.AddWithValue("@limit1", (limit.limit1));
                            cmd.Parameters.AddWithValue("@limit2", (limit.limit2));
                            cmd.Parameters.AddWithValue("@nlabel", (nlabel));

                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        string e = ex.InnerException.Message;
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        closeConnection();
                    }
                }
                closeConnection();
            }
            return true;
        }
        #endregion

        public DataTable GetSearchPerson(string id13, string name, string sname, string status, string mode_search)
        {
            DataTable dt = new DataTable();
            try
            {
                switch (mode_search)
                {
                    case "new":
                        dt = base.getDataTablePrototype(search.searchPerson(id13, name, sname));
                        break;
                    case "edit":
                        dt = base.getDataTablePrototype(search.searchPeople(id13, name, sname, "", "", status));
                        break;
                    case "out":
                        dt = base.getDataTablePrototype(search.searchPeople(id13, name, sname, "", "", status));
                        break;
                }

            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;
        }

        public DataTable GetReportHistrory()
        {
            DataTable dt = new DataTable();
            try
            {

                dt = base.getDataTablePrototype(search.GetReportHistory());



            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;
        }
        public DataRow GetSearchPerson(string id13)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.searchPerson(id13, "", ""));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {

                    return null;
                }
            }
            else
            {
                return null;

            }
        }

        public DataTable GetSearchPerson(string BATT, string COMPANY, string PLATOON, string PSEQ)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.searchPerson(BATT, COMPANY, PLATOON, PSEQ));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt != null)
            {

                return dt;



            }
            else
            {
                return null;

            }
        }

        public DataTable GetViewdata(string navyid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetViewdata(navyid));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            return dt;
        }
        public DataRow GetSearchPeople(string navyid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.searchPeople(navyid));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {

                    return null;
                }
            }
            else
            {
                return null;

            }
        }

        public DataRow GetSearchPeople(string id13, string rank, string book_number)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.searchPeople(id13, "", "", rank, book_number, ""));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {

                    return null;
                }
            }
            else
            {
                return null;

            }
        }
        public DataTable GetListPeople(string id13, string rank, string book_number)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetListPeople());
            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;

        }
        public DataTable GetReportListPeople(string report_number)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototypeNON(search.GetReportListPeople(report_number));
            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;

        }
        public DataTable GetReportListAddressmore(string report_number)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetReportListPeople(report_number));
            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;

        }

        public DataTable GetReportListAddressmore(string yearin, string unit)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetReportListAddressmore(unit, yearin));
            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;

        }

        public DataTable GetReportExportToExcel(string yearin, string unit)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetReportExportToExcel(unit, yearin));
            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;

        }
        public DataTable GetReportSumpeople()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetReportSumP());
            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;

        }

        public DataTable GetSearchListPreAddressmore(string name, string lname, string report_number, string book_number, string rank, string id13, string yearin, bool move_in, string unit_id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetListPremoreAdress(name, lname, report_number, book_number, rank, id13, yearin, move_in, unit_id));
            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;

        }
        public DataTable GetListAddress(string unit_id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.searchaddress_unit(unit_id));
            }
            catch (Exception ex)
            {

                dt = null;
            }

            return dt;


        }
        public DataRow GetAddress(string unit_id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.searchaddress_unit(unit_id));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;

            }
        }
        public DataRow GetSubAddress(string subunit_id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.searchaddress_subunit(subunit_id));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;

            }
        }

        public string GetReport_number()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetMaxReport_Number());
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["report_number"].ToString();
            }
            else
            {
                return null;

            }
        }

        public string GetMaxSubUnit(string unit_id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetMaxSubUnit(unit_id));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["subunit_id"].ToString();
            }
            else
            {
                return null;

            }
        }
        public DataRow Getpostcode(string district)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.tumbonsInCity(district));
            }
            catch (Exception ex)
            {

                dt = null;
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;

            }
        }

        //เพิ่ม Funtion Select Count ของการศึกษา
        public DataTable GetReportEducation(string yearin)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetReportEducation(yearin));
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataTable GetReportOccupation(string yearin)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.getDataTablePrototype(search.GetReporOccupation(yearin));
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
    }
}
