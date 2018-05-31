using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Navy.Core
{
    public class DBConnection
    {
        public static readonly string defaultConString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        public static readonly string NavdbConString = ConfigurationManager.ConnectionStrings["NavdbConnectionString"].ConnectionString;
        public static MySqlConnectionStringBuilder conStringBuilder;
        protected MySqlConnection conn;

        public DBConnection()
        {
            NewConnection();
        }

        public DBConnection(string constr)
        {
            NewConnection(constr);
        }

        public void NewConnection()
        {
            NewConnection(Constants.currentConString);
        }

        public void NewConnection(string constr)
        {
            conStringBuilder = new MySqlConnectionStringBuilder(constr);
            conn = new MySqlConnection(constr);
        }

        public void ChangeDB(string database)
        {
            MySqlConnectionStringBuilder conB = new MySqlConnectionStringBuilder(this.conn.ConnectionString);
            conB.Database = database;
            conn = new MySqlConnection(conB.ConnectionString);
        }
                
        #region static function

        public static MySqlConnectionStringBuilder GetConnectionString()
        {
            if (conStringBuilder == null)
            {
                if (GetConStringFormFile() == "")
                {
                    //Set Default Connection String from App.config
                    conStringBuilder = new MySqlConnectionStringBuilder(defaultConString);
                    //conStringBuilder = new MySqlConnectionStringBuilder("navdb");
                }
            }
            return conStringBuilder;
        }

        public static void SetConnectionString(string host, string user, string password, string database)
        {
            conStringBuilder.Server = host;
            conStringBuilder.UserID = user;
            conStringBuilder.Password = password;
            conStringBuilder.Database = database;
            Constants.currentConString = conStringBuilder.ConnectionString;
            WriteConStringToFile(conStringBuilder);
        }

        public static DataTable GetAvailableDatabase(string host, string user, string pass)
        {
            DataTable dtDatabase = new DataTable("Database");
            dtDatabase.Columns.Add("SCHEMATA");
            MySqlConnectionStringBuilder conString = new MySqlConnectionStringBuilder();

            conString.Server = host;
            conString.UserID = user;
            conString.Password = pass;
            conString.Database = "";

            MySqlConnection conn = new MySqlConnection(conString.ConnectionString);

            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("Show Databases;", conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DataRow row = dtDatabase.NewRow();
                            row["SCHEMATA"] = dr.GetValue(0);
                            dtDatabase.Rows.Add(row);
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dtDatabase;
        }

        public static string GetConStringFormFile()
        {
            //DBConnection.GetAvailableDatabase(txtHost.Text, txtUser.Text, txtPassword.Text);
            string constr = "";
            try
            {

                //conStringBuilder = JsonConvert.DeserializeObject<MySqlConnectionStringBuilder>(File.ReadAllText(@"constr.json"));
                constr = "server=192.168.0.1;database=navdb;userid=root;characterset=utf8;convertzerodatetime=True;password=";//conStringBuilder.ConnectionString;
                Constants.currentConString = conStringBuilder.ConnectionString;
            }
            catch { constr = ""; }
            return constr;
        }

        public static bool WriteConStringToFile(MySqlConnectionStringBuilder conString)
        {
            try
            {
                File.WriteAllText(@"constr.json", JsonConvert.SerializeObject(conString));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("พบข้อผิดพลาดในการเขียนข้อมูลลงไฟล์ .. " + ex.Message);
                return false;
            }
        }

        /* @Function runCmdTransaction
         * @Purpose Execute sql command and rollback when error
         * @Input sqlCmd(string) : sql command which want to query
         * @Input connectionObject(SqlConnection) : object SqlConnection
         * @Input(out) msg(string) : msg status if no error then "OK" , return "ERROR:" + other message when error
         * @return (bool) TRUE if normally and "Error:" if error
         */
        public static bool runCmdTransaction(string sql, MySqlConnection connectionObject, out string msg)
        {
            bool success = true;
            msg = "OK";
            using (MySqlConnection conn = connectionObject)
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand(sql, conn, tran);
                try
                {
                    cmd.Parameters.Clear();
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    success = false;
                    msg = "ERROR:" + ex.Message;
                    tran.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
            return success;
        }

        /* @Function runCmdTransaction
         * @Purpose Execute sql command and rollback when error
         * @Input sqlCmd(string) : sql command which want to query
         * @Input connectionObject(SqlConnection) : object SqlConnection
         * @Input(out) msg(string) : msg status if no error then "OK" , return "ERROR:" + other message when error
         * @return (bool) TRUE if normally and "Error:" if error
         */
        public static bool runCmdTransaction(MySqlConnection connectionObject, MySqlCommand cmd, out string msg)
        {
            bool success = true;
            msg = "OK";
            using (MySqlConnection conn = connectionObject)
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.Transaction = tran;
                try
                {
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    success = false;
                    msg = "ERROR:" + ex.Message;
                    tran.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
            return success;
        }
        #endregion

        public bool openConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public MySqlConnection getConnection()
        {
            return conn;
        }

        #region PROTOTYPE
        public string getValuePrototype(string queryStr, string readerString)
        {
            string result = "";
            MySqlCommand comm = new MySqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader[readerString].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public T getValuePrototype<T>(string queryStr, string readerString)
        {
            T result = default(T);
            MySqlCommand comm = new MySqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = (T)(reader[readerString]);
                    }
                }
            }
            catch (Exception ex)
            {
                result = default(T);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int getNumberPrototype(string queryStr, string readerString, int returnValueWhenError)
        {
            int result = -1;
            MySqlCommand comm = new MySqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                result = Convert.ToInt32(comm.ExecuteScalar());
            }
            catch (Exception ex)
            {
                result = returnValueWhenError;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public List<string> getDataInRowPrototype(string queryStr)
        {
            List<string> result = new List<string>();
            MySqlCommand comm = new MySqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int colCount = reader.FieldCount;
                        for (int i = 0; i < colCount; i++)
                        {
                            result.Add(reader[i].ToString());
                        }
                    }
                }
                conn.Close();
            }
            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public Dictionary<string, string> getDataInRowPrototype(string queryStr, string[] readerColumnString)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            MySqlCommand comm = new MySqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (int i = 0; i < readerColumnString.Count(); i++)
                        {
                            result.Add(readerColumnString[i], reader[readerColumnString[i]].ToString());
                        }
                    }
                }
            }
            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public List<T> getListPrototype<T>(string queryStr, string readerString)
        {
            List<T> result = new List<T>();
            MySqlCommand comm = new MySqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add((T)(reader[readerString]));
                    }
                }
            }
            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public Dictionary<TKey, TValue> getDictionaryPrototype<TKey, TValue>(string queryStr, string readerKeyString, string readerValueString)
        {
            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
            MySqlCommand comm = new MySqlCommand(queryStr, conn);
            try
            {
                conn.Open();
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TKey key = (TKey)(reader[readerKeyString]);
                        TValue value = (TValue)(reader[readerValueString]);
                        result.Add(key, value);
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
            return result;
        }

        public Dictionary<string, int> getKeyNumberPrototype(string queryStr, string readerKeyString, string readerValueString)
        {
            return getDictionaryPrototype<string, int>(queryStr, readerKeyString, readerValueString);
        }

        public DataTable getDataTablePrototype(string queryStr)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
            //    cmd.CommandTimeout = 50000;
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
        public DataTable getDataTablePrototypeNON(string queryStr)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                    cmd.CommandTimeout = 5000;
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
        public DataTable getDataTablePrototypeNavdb(string queryStr)
        {
            DataTable dt = new DataTable();
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

        public bool getDataTablePrototype(string queryStr, ref DataTable dt)
        {
            //DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch
            {
                return false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public DataSet getDataSetPrototype(string queryStr)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlCommand cmd = new MySqlCommand(queryStr, conn);
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        public DataTable getSearchPrototype(string queryStr, string queryStrCount, out int countAllRecord)
        {
            DataTable dt = new DataTable();
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
        #endregion
    }
}
