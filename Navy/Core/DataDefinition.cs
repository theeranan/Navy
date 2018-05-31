using Navy.Data.DataTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navy.Core
{
    public class DataDefinition
    {
        private static DataTab dtab;
        private static DBConnection dbcon = new DBConnection();
        private static QueryString.DataDefinition query = new QueryString.DataDefinition();
        
        public DataDefinition()
        {
            NewConnection();
        }

        public static void NewConnection()
        {
            dbcon.NewConnection(Constants.currentConString);
            dtab = new DataTab();
        }

        public static void SetAllData()
        {

        }

        public static void ClearAllData()
        {
            dtab = new DataTab();
        }

        public static DataTable GetArmtownTab()
        {
            if (dtab._dtArmtown == null)
            {
                dtab._dtArmtown = dbcon.getDataTablePrototype(query.armtown());
            }
            return dtab._dtArmtown;
        }

        public static string GetArmtownName(string armid)
        {
            DataRow[] row;
            row = GetArmtownTab().Select("armid = '" + armid.ToString() + "'");
            if (row.Length > 0)
                return Convert.ToString(row[0]["armname"]);
            return "";
        }

        public static string GetArmtownAbbName(string armid)
        {
            DataRow[] row;
            row = GetArmtownTab().Select("armid = '" + armid.ToString() + "'");
            if (row.Length > 0)
                return Convert.ToString(row[0]["abbname"]);
            return "";
        }

        public static string GetArmtownLegion(string armid)
        {
            DataRow[] row;
            row = GetArmtownTab().Select("armid = '" + armid.ToString() + "'");
            if (row.Length > 0)
                return Convert.ToString(row[0]["legion"]);
            return "";
        }

        public static DataTable GetAskByTab()
        {
            if (dtab._dtAskBy == null)
            {
                dtab._dtAskBy = new DataTable();
                dtab._dtAskBy.Columns.Add("ask", typeof(string));

                // add number "00","01", ... ,"20"
                for (int i = 1; i <= 20; i++)
                {
                    dtab._dtAskBy.Rows.Add(i.ToString().Length < 2 ? "0" + i.ToString() : i.ToString());
                }
            }
            return dtab._dtAskBy;
        }

        // get max NUM where ASK and YEARIN from table [request]
        public static DataTable GetAskByNUMTab(string askbyCode, string yearin)
        {
            int maxNUM = 0;
            dtab._dtAskByNUM = new DataTable();
            dtab._dtAskByNUM.Columns.Add("NUM", typeof(string));

            if (!String.IsNullOrWhiteSpace(askbyCode) && !String.IsNullOrWhiteSpace(yearin))
            {
                QueryString.Search q = new QueryString.Search();
                maxNUM = dbcon.getNumberPrototype(q.GetMaxAskbyNUM(askbyCode, yearin), "maxNUM", 0);                
            }

            // add number plus 1
            for (int i = 1; i <= maxNUM + 1; i++)
            {
                dtab._dtAskByNUM.Rows.Add(i.ToString());
            }
            return dtab._dtAskByNUM;
        }
                
        public static DataTable GetOriginTab()
        {
            if (dtab._dtOrigin == null)
            {
                dtab._dtOrigin = dbcon.getDataTablePrototype(query.origintab());
            }
            return dtab._dtOrigin;
        }

        public static string GetOriginName(string origincode)
        {
            DataRow[] row;
            row = GetOriginTab().Select("origincode = '" + origincode.ToString() + "'");
            if (row.Length > 0)
                return Convert.ToString(row[0]["origin"]);
            return "";
        }

        public static DataTable GetOccTab()
        {
            if (dtab._dtOccTab == null)
            {
                dtab._dtOccTab = dbcon.getDataTablePrototype(query.occtab());
            }
            return dtab._dtOccTab;
        }

        public static string GetOccCode(string occname)
        {
            DataRow[] row;
            row = GetOriginTab().Select("occname = '" + occname.ToString() + "'");
            if (row.Length > 0)
                return Convert.ToString(row[0]["occcode"]);
            return "";
        }

        public static DataTable GetMemberCodeTab()
        {
            if (dtab._dtMemberCode == null)
            {
                dtab._dtMemberCode = dbcon.getDataTablePrototype(query.membercode());
            }
            return dtab._dtMemberCode;
        }

        public static DataTable GetStatusTab()
        {
            if (dtab._dtStatusTab == null)
            {
                dtab._dtStatusTab = dbcon.getDataTablePrototype(query.statustab());
            }
            return dtab._dtStatusTab;
        }

        public static string GetStatusSTitle(string statuscode)
        {
            DataRow[] row;
            row = GetStatusTab().Select("statuscode = '" + statuscode + "'");

            if (row.Length > 0)
                return Convert.ToString(row[0]["stitle"]);

            return "";
        }

        public static string GetStatusTitle(string statuscode)
        {
            DataRow[] row;
            row = GetStatusTab().Select("statuscode = '" + statuscode + "'");

            if (row.Length > 0)
                return Convert.ToString(row[0]["title"]);

            return "";
        }

        public static DataTable GetGroupTab()
        {
            if (dtab._dtGroupTab == null)
            {
                dtab._dtGroupTab = dbcon.getDataTablePrototype(query.grouptab());
            }
            return dtab._dtGroupTab;
        }

        public static string GetGroupName(int groupid)
        {
            DataRow[] row;
            row = GetGroupTab().Select("groupid = '" + groupid.ToString() + "'");

            if (row.Length > 0)
                return Convert.ToString(row[0]["groupname"]);

            return "";
        }
       
        //public static DataTable GetTypeTab()
        //{
        //    if (dtab._dtTypeTab == null)
        //    {
        //        dtab._dtTypeTab = dbcon.getDataTablePrototype(query.typetab());
        //    }
        //    return dtab._dtTypeTab;
        //}

        //public static string GetTypeName(string typeid)
        //{
        //    DataRow[] row;
        //    row = GetTypeTab().Select("typeid = '" + typeid + "'");

        //    if (row.Length > 0)
        //        return Convert.ToString(row[0]["type"]);

        //    return "";
        //}

        public static DataTable GetUnitTab()
        {
            if (dtab._dtUnitTab == null)
            {
                dtab._dtUnitTab = dbcon.getDataTablePrototype(query.unittab());
            }
            return dtab._dtUnitTab;
        }
        public static DataTable GetSkillTab()
        {
            if (dtab._dtSkillTab == null)
            {
                dtab._dtSkillTab = dbcon.getDataTablePrototype(query.skilltab());
            }
            return dtab._dtSkillTab;
        }
        public static DataTable GetPatient_Status()
        {
            if (dtab._dtPatient_status == null)
            {
                dtab._dtPatient_status = dbcon.getDataTablePrototype(query.Patient_status());
            }
            return dtab._dtPatient_status;
        }

        public static DataTable GetAddictive_Status()
        {
            if (dtab._dtAddictive_status == null)
            {
                dtab._dtAddictive_status = dbcon.getDataTablePrototype(query.Addictive_status());
            }
            return dtab._dtAddictive_status;
        }

        public static DataTable Getkptclass()
        {
            if (dtab._dtkptclass == null)
            {
                dtab._dtkptclass = dbcon.getDataTablePrototype(query.kptclass());
            }
            return dtab._dtkptclass;
        }
        public static DataTable GetBanktab()
        {
            if (dtab._dtbanktab == null)
            {
                dtab._dtbanktab = dbcon.getDataTablePrototype(query.banktab());
            }
            return dtab._dtbanktab;
        }
        public static DataTable GetUnitmoreTab()
        {
            if (dtab._dtUnitaddressmoveTab == null)
            {
                dtab._dtUnitaddressmoveTab = dbcon.getDataTablePrototype(query.unitmoretab());
            }
            return dtab._dtUnitaddressmoveTab;
        }
        public static DataTable GetSubUnitmoreTab(string unit_id)
        {

           
                dtab._dtSubUnitTab = dbcon.getDataTablePrototype(query.subunitmoretab(unit_id));
               
          
            return dtab._dtSubUnitTab;
        }
        public static DataTable Getstatusmore()
        {
            if (dtab._dtstatus_move == null)
            {
                dtab._dtstatus_move = dbcon.getDataTablePrototype(query.status_move());
            }
            return dtab._dtstatus_move;
        }
        public static string GetUnitName(string unit)
        {
            DataRow[] row;
            row = GetUnitTab().Select("refnum = '" + unit + "'");

            if (row.Length > 0)
                return Convert.ToString(row[0]["unitname"]);

            return "";
        }

        public static DataTable GetDocTab()
        {
            if (dtab._dtDocTab == null)
            {
                dtab._dtDocTab = dbcon.getDataTablePrototype(query.doctab());
            }
            return dtab._dtDocTab;
        }

        public static DataTable GetstructureTab()
        {
            if (dtab._dtStructure == null)
            {
                dtab._dtStructure = dbcon.getDataTablePrototype(query.structuretab());
            }
            return dtab._dtStructure;
        }

        public static DataTable GetReligionTab()
        {
            if (dtab._dtReligion == null)
            {
                dtab._dtReligion = dbcon.getDataTablePrototype(query.religiontab());
            }
            return dtab._dtReligion;
        }

        public static string GetReligionName(string regcode)
        {
            DataRow[] row;
            row = GetReligionTab().Select("regcode = '" + regcode + "'");

            if (row.Length > 0)
                return Convert.ToString(row[0]["religion"]);

            return "";
        }

        public static DataTable GetEducTab()
        {
            if (dtab._dtEducTab == null)
            {
                dtab._dtEducTab = dbcon.getDataTablePrototype(query.eductab());
            }
            return dtab._dtEducTab;
        }

        public static DataTable GetPerTypeTab()
        {
            if (dtab._dtPerTypeTab == null)
            {
                dtab._dtPerTypeTab = new DataTable();
                dtab._dtPerTypeTab.Columns.Add("id", typeof(string));
                dtab._dtPerTypeTab.Columns.Add("name", typeof(string));

                dtab._dtPerTypeTab.Rows.Add("1", "ปกติ");
                dtab._dtPerTypeTab.Rows.Add("2", "ไม่มีความรู้");
                dtab._dtPerTypeTab.Rows.Add("3", "ลาศึกษาต่อ");
                dtab._dtPerTypeTab.Rows.Add("4", "หนีระหว่างนำส่ง");
            }
            return dtab._dtPerTypeTab;
        }

        public static DataTable GetTownnameLV1()
        {
            if (dtab._dtTownnameLV1 == null)
            {
                dtab._dtTownnameLV1 = dbcon.getDataTablePrototype(query.province());
            }
            return dtab._dtTownnameLV1;
        }

        public static DataTable GetTownnameLV2(string towncodeLV1)
        {
            dtab._dtTownnameLV2 = dbcon.getDataTablePrototype(query.citiesInProvince(towncodeLV1));
            return dtab._dtTownnameLV2;
        }
        
        public static DataTable GetTownnameLV3(string towncodeLV2)
        {
            dtab._dtTownnameLV3 = dbcon.getDataTablePrototype(query.tumbonsInCity(towncodeLV2));
            return dtab._dtTownnameLV3;
        }
        public static DataRow GetPostcode(string towncodeLV2)
        {
            dtab._dtPostcode = dbcon.getDataTablePrototype(query.getpostcode(towncodeLV2));
            return dtab._dtPostcode.Rows[0];
        }

        //find province in towncode where 
        public static string GetTowncodeByArmtownID(string armid)
        {
            string towncode = dbcon.getValuePrototype(query.findProvinceByArmtown(GetArmtownName(armid)), "TOWNCODE");
            return towncode;
        }

        public static string GetTowncodeByGOVID(string govId)
        {
            string towncode = dbcon.getValuePrototype(query.townnameByGOVID(govId), "TOWNCODE");
            return towncode;
        }
       

    }
}
