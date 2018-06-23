using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navy.Core
{
    public class QueryString
    {
        public class DataDefinition
        {
            public string banktab()
            {
                return "SELECT * FROM bankingtab ORDER BY BankCode";
            }
            public string armtown()
            {
                return "SELECT * FROM armtown ORDER BY ARMNAME ASC;";
            }

            public string origintab()
            {
                return "SELECT * FROM origintab;";
            }

            public string occtab()
            {
                return "SELECT * FROM occtab ORDER BY OCCCODE ASC;";
            }

            public string membercode()
            {
                return "SELECT * FROM membercode;";
            }

            public string statustab()
            {
                return "SELECT * FROM statustab;";
            }

            public string grouptab()
            {
                return "SELECT * FROM grouptab;";
            }

            public string typetab()
            {
                return "SELECT * FROM type;";
            }

            public string unittab()
            {
                return "SELECT * FROM unittab WHERE movestat = 1;";
            }
            public string skilltab()
            {
                return "SELECT * FROM skilltab WHERE (1=1) ";
            }
            public string Patient_status()
            {
                return "SELECT * FROM statustab WHERE STATUSCODE = 'BV' or STATUSCODE = 'BW' or STATUSCODE = 'BX'  ";
            }

            public string Addictive_status()
            {
                return "SELECT * FROM addictivetab ";
            }

            public string kptclass()
            {
                return "SELECT * FROM kptclass WHERE (1=1) ";
            }
            public string unitmoretab()
            {
                return "SELECT * FROM address_unit where level='0' ";
            }
            public string subunitmoretab(string unit_id)
            {
                string sql = "SELECT * FROM address_unit where level='1' ";

                if (!string.IsNullOrEmpty(unit_id))
                {

                    sql += " and unit_id='" + unit_id + "' ";
                }
                return sql;

            }
            public string status_move()
            {
                return "SELECT * FROM status_move  ;";
            }

            public string doctab()
            {
                return "SELECT * FROM doctab;";
            }

            public string structuretab()
            {
                return "SELECT * FROM structure;";
            }

            public string religiontab()
            {
                return "SELECT * FROM religion;";
            }

            public string eductab()
            {
                return "SELECT *,CONCAT(ECODE1,ECODE2) as ECODE0 FROM eductab WHERE (ECODE1 <= 3) OR (ECODE2 = 001) OR (ECODE1 = 9) ORDER BY ECODE1 ASC,ECODE2 ASC;";
            }

            public string townname(string towncode)
            {
                return "SELECT * FROM townname WHERE TOWNCODE = '" + towncode + "';";
            }

            public string townnameByGOVID(string GOVID)
            {
                return "SELECT * FROM townname WHERE GOVID = '" + GOVID + "';";
            }

            public string province()
            {
                return "SELECT * FROM townname WHERE CLEVEL = '1' ORDER BY TOWNNAME ASC;";
            }

            //get Province from Tumbon or City
            public string provinceFromChildNode(string towncodeLV23)
            {
                return "SELECT * FROM townname WHERE (SUBSTR(TOWNCODE,1,2) = SUBSTR('" + towncodeLV23 + "',1,2)) AND CLEVEL = '1' ORDER BY TOWNNAME ASC;";
            }

            //get all Cities in Province
            public string citiesInProvince(string towncodeLV1)
            {
                return "SELECT * FROM townname WHERE (SUBSTR(TOWNCODE,1,2) = SUBSTR('" + towncodeLV1 + "',1,2)) AND CLEVEL = '2' ORDER BY TOWNNAME ASC;";
            }
            //get all Cities in Province
            public string getpostcode(string towncodeLV1)
            {
                return "SELECT * FROM townname WHERE (SUBSTR(TOWNCODE,1,4) = SUBSTR('" + towncodeLV1 + "',1,4)) AND CLEVEL = '2' ORDER BY TOWNNAME ASC; ";
            }
            //get City from Tumbon
            public string cityFromChildNode(string towncodeLV3)
            {
                return "SELECT * FROM townname WHERE (SUBSTR(TOWNCODE,1,4) = SUBSTR('" + towncodeLV3 + "',1,4)) AND CLEVEL = '2' ORDER BY TOWNNAME ASC;";
            }

            //get all Tumbons in City
            public string tumbonsInCity(string towncodeLV2)
            {
                return "SELECT * FROM townname WHERE (SUBSTR(TOWNCODE,1,4) = SUBSTR('" + towncodeLV2 + "',1,4)) AND CLEVEL = '3' ORDER BY TOWNNAME ASC;";
            }

            public string findProvinceByArmtown(string armname)
            {
                return "SELECT * FROM townname t WHERE t.TOWNNAME LIKE '%" + armname + "%' AND CLEVEL = '1' ORDER BY TOWNNAME ASC;";
            }

            public string provinceLower(string towncodeLV1)
            {
                return "SELECT * FROM townname WHERE (SUBSTR(TOWNCODE,1,4)  = SUBSTR('" + towncodeLV1 + "',1,2) ORDER BY TOWNNAME ASC;";
            }
        }

        public class Search
        {
            public string checkruncode()
            {
                return "SELECT Runcode FROM person WHERE Runcode is not null ORDER BY RUNCODE ASC";
            }
            public string checkruncode(int i)
            {
                return "SELECT Runcode FROM person WHERE Runcode=" + i;
            }
            public static string whereEqualsClause(string sqlWhere, string column, string input)
            {
                if (!String.IsNullOrWhiteSpace(input))
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " " + column + " = '" + input.Trim() + "'\n";
                }
                return sqlWhere;
            }

            public static string whereLikeClause(string sqlWhere, string column, string input)
            {
                if (!String.IsNullOrWhiteSpace(input))
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " " + column + " LIKE '%" + input.Trim() + "%'\n";
                }
                return sqlWhere;
            }

            public static string whereYearin(string sqlWhere, string columnYearin, string inputYearin)
            {
                if (!String.IsNullOrWhiteSpace(inputYearin) && inputYearin != " /")
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " " + columnYearin + " = '" + inputYearin + "'\n";
                }
                return sqlWhere;
            }

            public static string whereYearinAndOldYearinNull(string sqlWhere, string columnYearin, string columnOldYearin, string inputYearin)
            {
                if (!String.IsNullOrWhiteSpace(inputYearin) && inputYearin != " /")
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " " + columnYearin + " = '" + inputYearin + "' AND " + columnOldYearin + " IS NULL \n";
                }
                return sqlWhere;
            }

            public static string whereLikeNameSName(string sqlWhere, string columnName, string columnSName, string inputName, string inputSName)
            {
                if (!String.IsNullOrWhiteSpace(inputName))
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " " + columnName + " LIKE '" + inputName.Trim() + "%'\n";
                }

                if (!String.IsNullOrWhiteSpace(inputSName))
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " " + columnSName + " LIKE '" + inputSName.Trim() + "%'\n";
                }
                return sqlWhere;
            }

            public static string whereLikeID8(string sqlWhere, string columnID8, string inputID8)
            {
                if (!String.IsNullOrWhiteSpace(inputID8) && inputID8 != " . ." && inputID8.Length >= 4)
                {
                    string id8_first = inputID8.Substring(0, 4);
                    string id8_last = inputID8.Remove(0, 4);

                    if (id8_last != "")
                    {
                        id8_last = (Convert.ToInt16(id8_last)).ToString();
                    }

                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " " + columnID8 + " LIKE '" + id8_first + "%" + id8_last + "'\n";
                }
                return sqlWhere;
            }

            public Search() { }

            public string CountRecord(string sql)
            {
                return "SELECT COUNT(*) as countRecord FROM (" + sql + ") result";
            }

            public string searchPersonNivy(string id13, string name, string sname, string yearBD, int limit1, int limit2, bool isLimit)
            {
                string sql = "";
                string sqlSelect = "SELECT * FROM nivy1 \n";
                string sqlWhere = "";
                string sqlLimit = "";

                sqlWhere = whereLikeClause(sqlWhere, "ID13", id13);
                sqlWhere = whereLikeNameSName(sqlWhere, "`NAME`", "SNAME", name, sname);

                if (!String.IsNullOrWhiteSpace(yearBD))
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " SUBSTR(BIRTHDATE,1,4) = '" + yearBD + "'\n";
                }

                if (isLimit)
                {
                    if (limit1 >= 0)
                    {
                        sqlLimit += "LIMIT " + limit1.ToString() + (limit2 >= 1 ? "," + limit2.ToString() : "");
                    }
                }

                sql = sqlSelect + sqlWhere + sqlLimit;
                return sql;
            }

            public string searchPersonNivyCountRecord(string id13, string name, string sname, string yearBD)
            {
                return CountRecord(searchPersonNivy(id13, name, sname, yearBD, 0, 0, false));
            }

            public string searchPersonNivy2(string id13, string name, string sname, string yearBD, bool getUsedPerson, int limit1, int limit2, bool isLimit)
            {
                string sql = "";
                string sqlSelect = "SELECT *,STR_TO_DATE(CONCAT(DOB_Y,'/',DOB_M,'/',DOB_D),'%Y/%m/%d') BIRTHDATE2 FROM navy \n";
                string sqlWhere = "";
                string sqlLimit = "";

                sqlWhere = whereLikeClause(sqlWhere, "PID", id13);
                sqlWhere = whereLikeNameSName(sqlWhere, "FNAME", "LNAME", name, sname);

                if (!String.IsNullOrWhiteSpace(yearBD))
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " SUBSTR(BIRTHDATE,1,4) = '" + yearBD + "'\n";
                }

                if (!getUsedPerson)
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " USED != '1'";
                }

                if (isLimit)
                {
                    if (limit1 >= 0)
                    {
                        sqlLimit += "LIMIT " + limit1.ToString() + (limit2 >= 1 ? "," + limit2.ToString() : "");
                    }
                }

                sql = sqlSelect + sqlWhere + sqlLimit;
                return sql;
            }

            public string searchPersonNivy2CountRecord(string id13, string name, string sname, string yearBD, bool getUsedPerson)
            {
                return CountRecord(searchPersonNivy2(id13, name, sname, yearBD, getUsedPerson, 0, 0, false));
            }

            public string searchPerson(string navyid, string id13, string name, string sname, string yearBD, string armid, string yearin, string id8, string runcode, int limit1, int limit2, bool isLimit, string batt, string company)
            {
                string sql = "";
                string sqlSelect = "SELECT * FROM person \n";
                string sqlWhere = "";
                string sqlLimit = "";

                sqlWhere = whereEqualsClause(sqlWhere, "NAVYID", navyid);
                sqlWhere = whereLikeClause(sqlWhere, "ID13", id13);
                sqlWhere = whereLikeClause(sqlWhere, "ARMID", armid);
                sqlWhere = whereLikeNameSName(sqlWhere, "`NAME`", "SNAME", name, sname);
                sqlWhere = whereLikeID8(sqlWhere, "ID8", id8);
                sqlWhere = whereYearin(sqlWhere, "YEARIN", yearin);
                sqlWhere = whereEqualsClause(sqlWhere, "RUNCODE", runcode);
                sqlWhere = whereEqualsClause(sqlWhere, "BATT", batt);
                sqlWhere = whereEqualsClause(sqlWhere, "COMPANY", company);

                if (!String.IsNullOrWhiteSpace(yearBD))
                {
                    sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " SUBSTR(BIRTHDATE,1,4) = '" + yearBD + "'\n";
                }

                if (isLimit)
                {
                    if (limit1 >= 0)
                    {
                        sqlLimit += "LIMIT " + limit1.ToString() + (limit2 >= 1 ? "," + limit2.ToString() : "");
                    }
                }

                sql = sqlSelect + sqlWhere + sqlLimit;
               // Console.WriteLine("SQL  = " + sql.ToString());
                return sql;
            }

            public string searchTelephone(string batt, string company,string name,string sname,string id8)
            {
                string sql = "";
                string sqlSelect = "select `NAME`,SNAME,Telephone,FTelephone,MTelephone,PTelephone from person \n";
                string sqlWhere = "";

                sqlWhere = whereEqualsClause(sqlWhere, "BATT", batt);
                sqlWhere = whereEqualsClause(sqlWhere, "COMPANY", company);
                sqlWhere = whereLikeNameSName(sqlWhere, "`NAME`", "SNAME", name, sname);
                sqlWhere = whereLikeID8(sqlWhere, "ID8", id8);

                sql = sqlSelect + sqlWhere;
                return sql;
            }

            public string searchPerson_OnlyIndictment(string id13, string name, string sname, string yearin, string id8)
            {
                string sql = "";
                string sqlSelect = "SELECT * FROM indictmenttab ind LEFT JOIN person p on ind.NavyID = p.NAVYID \n";
                string sqlWhere = "";

                sqlWhere = whereLikeClause(sqlWhere, "ID13", id13);
                sqlWhere = whereLikeNameSName(sqlWhere, "`NAME`", "SNAME", name, sname);
                sqlWhere = whereLikeID8(sqlWhere, "ID8", id8);
                sqlWhere = whereYearin(sqlWhere, "YEARIN", yearin);

                string sqlGroup = "GROUP BY ind.NavyID";
                sql = sqlSelect + sqlWhere + sqlGroup;
                return sql;
            }

            public string SearchData_Indictment(string navyid)
            {
                string sql = "";
                string sqlSelect = "SELECT * FROM indictmenttab ind RIGHT JOIN person p on ind.NavyID = p.NAVYID \n";
                string sqlWhere = "";

                sqlWhere = whereLikeID8(sqlWhere, "ind.NavyID", navyid);

                sql = sqlSelect + sqlWhere;
                return sql;
            }


            public string searchPerson(string BATT, string COMPANY, string PLATOON, string PSEQ)
            {
                string sql = "";
                sql += "SELECT * FROM person p where (1=1) and p.YEARIN='3/59' ";

                if (!string.IsNullOrEmpty(BATT))
                {
                    sql += " and p.BATT = '" + BATT + "' ";
                }
                if (!string.IsNullOrEmpty(COMPANY))
                {
                    sql += " and p.COMPANY = '" + COMPANY + "' ";
                }
                if (!string.IsNullOrEmpty(PLATOON))
                {
                    sql += " and p.PLATOON = '" + PLATOON + "' ";
                }
                if (!string.IsNullOrEmpty(PSEQ))
                {
                    sql += " and p.PSEQ = '" + PSEQ + "' ";
                }

                sql += " order by p.id8 ";

                return sql;
            }

            public string searchPersonCountRecord(string navyid, string id13, string name, string sname, string yearBD, string armid, string yearin, string id8, string runcode, string batt, string company)
            {
                return CountRecord(searchPerson(navyid, id13, name, sname, yearBD, armid, yearin, id8, runcode, 0, 0, false, batt, company));
            }

            public string searchTelephoneCountRecord(string batt, string company, string name, string sname, string id8)
            {
                return CountRecord(searchTelephone(batt, company,name,sname,id8));
            }

            //new
            public string tumbonsInCity(string towncodeLV2)
            {
                return "SELECT * FROM townname WHERE TOWNCODE = '" + towncodeLV2 + "' AND CLEVEL = '3' ORDER BY TOWNNAME ASC;";
            }
            public string searchPersonbyunit(string UNIT3)
            {
                string sql = "";
                string sqlSelect = "select per.UNIT3,per.NAVYID,per.NLABEL  from person per \n";
                string sqlWhere = "";
                sqlWhere = whereEqualsClause(sqlWhere, "per.UNIT3", UNIT3);
                sql = sqlSelect + sqlWhere;
                return sql;
            }

            public string searchPersonCountRecordbyunit(string UNIT3)
            {
                return CountRecord(searchPersonbyunit(UNIT3));
            }

            public string searchNlabelInUnit(string UNIT3)
            {
                string sql = "";
                string sqlSelect = @"select DISTINCT per.NLABEL  from person per  ";
                string sqlWhere = " where per.NLABEL is not null  ";
                sqlWhere = whereEqualsClause(sqlWhere, "per.UNIT3", UNIT3);
                sql = sqlSelect + sqlWhere;
                return sql;
            }
            public string searchNlabelInUnitCountRecord(string UNIT3)
            {
                return CountRecord(searchNlabelInUnit(UNIT3));
            }
            public string searchNlabelNotInUnit(string UNIT3)
            {
                string sql = "";
                string sqlSelect = @"select DISTINCT per.NLABEL  from person per  ";
                string sqlWhere = " where per.NLABEL is not null  ";
                sqlWhere += " and  per.UNIT3<> '" + UNIT3 + "'  ";
                sql = sqlSelect + sqlWhere;
                return sql;
            }

            public string searchNlabelNotInUnitCountRecord(string UNIT3)
            {
                return CountRecord(searchNlabelNotInUnit(UNIT3));
            }

            public string GetReportHistory()
            {

                string sqlWhere = @" select * from person
                                        where (1=1) and YEARIN='1/59'  ";


                return sqlWhere;
            }
            public string GetViewdata(string navyid)
            {

                string sqlWhere = @" 
              SELECT p.navyid, p.name, p.sname, p.statuscode, st.stitle
                , m.membercode, mc.structureid, mc.namecode
                , mc.membercode_parentid as 'p_membercode', mcp.namecode as 'p_namecode'
                , m.membercode5, mc5.namecode as 'namecode5', m.link
                , m.groupid, m.typeid
                
                ,CAST(CONCAT('\\','\\192.168.0.1\\NavyImages\\',SUBSTR(p.YEARIN,1,1),'.',SUBSTR(p.YEARIN,3,2),'\\',p.NAVYID,'.jpg') AS CHAR)  as image
                , p.yearin,p.OLDYEARIN, p.id, p.id8, p.id13, p.msname as birthdate, p.mark, p.blood
                , p.address, p.address_mu, p.address_soil, p.address_road
                , p.towncode, tn.townname as 'subdistrict'
                , tn2.townname as 'district'
                , tn3.townname as 'Province', tn.zip
                , p.regcode, rl.religion
                , p.father, p.fsname, p.mother, p.msname, p.height,p.width
                , p.occcode, oc.occname 
                , e1.EDUCNAME  as educ,p.msname as regdate ,p.msname as repdate,p.msname as MOVEDATE
                , p.unit3, ut.unitname,ut1.UNITNAME as Unitname1,ut2.Unitname as Unitname2
                , p.skillcode, sk.skill
,p.BATT								
,p.COMPANY
								,p.PLATOON
								,p.PSEQ
								,p.RUNCODE
								,gr.GROUPNAME
,type.TYPE
,p.IS_REQUEST
,pst.POSTNAME
,p.PERCENT
                 FROM person p
									LEFT OUTER JOIN member m ON (m.id = p.navyid)
                 LEFT OUTER JOIN membercode mc ON (m.membercode = mc.membercode)
                 LEFT OUTER JOIN membercode mcp ON (mc.membercode_parentid = mcp.membercode)
                 LEFT OUTER JOIN membercode mc5 ON (m.membercode5 = mc5.membercode)
              
                
                 LEFT OUTER JOIN statustab st ON (p.statuscode = st.statuscode)
                 LEFT OUTER JOIN townname tn ON (p.towncode = tn.towncode) 
                 LEFT OUTER JOIN townname tn2 ON (concat(substring(p.towncode,1,4),'00') = tn2.towncode)
                 LEFT OUTER JOIN townname tn3 ON (concat(substring(p.towncode,1,2),'0000') = tn3.towncode)
                 LEFT OUTER JOIN religion rl ON (p.regcode = rl.regcode)
                 LEFT OUTER JOIN occtab oc ON (p.occcode = oc.occcode)
                 LEFT OUTER JOIN unittab ut ON (p.unit3 = ut.refnum)
 LEFT OUTER JOIN unittab ut1 ON (p.unit1 = ut1.refnum)
 LEFT OUTER JOIN unittab ut2 ON (p.unit2 = ut2.refnum)
                 LEFT OUTER JOIN skilltab sk ON (p.skillcode = sk.skillcode)
								 LEFT OUTER JOIN grouptab gr on (gr.GROUPID = m.GroupID)
									LEFT OUTER JOIN type  on (type.TYPEID = m.TypeID)
LEFT OUTER JOIN selectexam slt ON (slt.navyid = p.navyid)
LEFT OUTER JOIN positiontab pst ON (pst.POSTCODE = p.POSTCODE)
              left join eductab e1 on e1.ECODE1 =p.EDUCODE1 and e1.ECODE2 =p.EDUCODE2
left join eductab e2 on (e2.ECODE2 =e1.ECODE2 and e1.ECODE1 =e2.ECODE1 )
                    where (1=1)
                ";


                if (string.IsNullOrEmpty(navyid))
                {
                    sqlWhere += " and (1=2) ";
                }
                else
                {

                    sqlWhere += " and p.navyid = '" + navyid + "' ";

                }


                return sqlWhere;
            }
            public string searchPerson(string id13, string name, string sname)
            {

                string sqlWhere = @"SELECT p.id13,p.navyid,p.name,p.sname,p.ADDRESS,p.ADDRESS_MU,p.ADDRESS_SOIL,p.ADDRESS_ROAD,p.TOWNCODE,p.yearin,p.oldyearin,u.UNITNAME as unit3 FROM person p 

 LEFT JOIN unittab u on u.REFNUM = p.UNIT3
where (1=1) 
                ";


                if (string.IsNullOrEmpty(id13) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(sname))
                {
                    sqlWhere += " and (1=2) ";
                }
                else
                {
                    if (!string.IsNullOrEmpty(id13))
                    {
                        sqlWhere += " and p.id13 like '" + id13 + "%' ";
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        sqlWhere += " and p.name like '" + name + "%' ";
                    }
                    if (!string.IsNullOrEmpty(sname))
                    {
                        sqlWhere += " and p.sname like '" + sname + "%' ";
                    }
                }


                return sqlWhere;
            }
            public string searchPeople(string id13, string name, string sname, string rank, string book_number, string status)
            {

                string sqlWhere = @" SELECT ps.`NAME`,ps.SNAME,ps.yearin,ps.oldyearin,u.UNITNAME as unit3,p.* FROM people p
                                        LEFT JOIN person ps on ps.navyid = p.navyid 
LEFT JOIN unittab u on u.REFNUM = ps.UNIT3
                                        where (1=1)  ";


                //if (string.IsNullOrEmpty(id13) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(sname) && string.IsNullOrEmpty(book_number) && string.IsNullOrEmpty(rank))
                //{
                //    sqlWhere += " and (1=2) ";
                //}
                //else
                //{
                if (!string.IsNullOrEmpty(id13))
                {
                    sqlWhere += " and p.id13 = '" + id13 + "' ";
                }
                if (!string.IsNullOrEmpty(name))
                {
                    sqlWhere += " and ps.name like '" + name + "%' ";
                }
                if (!string.IsNullOrEmpty(sname))
                {
                    sqlWhere += " and ps.sname like '" + sname + "%' ";
                }
                if (!string.IsNullOrEmpty(book_number))
                {
                    sqlWhere += " and p.book_number = '" + book_number + "' ";
                }
                if (!string.IsNullOrEmpty(rank))
                {
                    sqlWhere += " and p.rank = '" + rank + "' ";
                }
                if (!string.IsNullOrEmpty(status))
                {
                    sqlWhere += " and p.status = '" + status + "' ";
                }
                // }


                return sqlWhere;
            }

            //เพิ่ม Funtion Select Count ของการศึกษา
            public string GetReportEducation(string yearin)
            {
                string sqlWhere = @"SELECT (
	                                CASE 
                                        when batt = 5 THEN '7'
                                        WHEN ECODE1 > 4 and ECODE1 < 9 and BATT < 5 then '1'
                                        WHEN ECODE1 = 9 or ECODE1 = 4 or(ECODE1 = 3 and ECODE2 > 003) and BATT < 5 then '2'
                                        WHEN ECODE1 = 3 and ECODE2 < 004 and BATT < 5 then '3'
                                        WHEN ECODE1 = 2 and ECODE2 > 003 and BATT < 5 then '4'
                                        WHEN ECODE1 = 2 and ECODE2 < 004 and BATT < 5 then '5'
                                        WHEN ECODE1 = 1 and ECODE2 = 001 and BATT < 5 then '6'
                                        ELSE '8' END) as EduType
                                        ,count(ID8) as Educount
                                        FROM person p LEFT JOIN eductab e1 ON e1.ECODE1 = p.EDUCODE1 and e1.ECODE2 = p.EDUCODE2
                                        WHERE BATT < 6 and (OLDYEARIN is null or OLDYEARIN = '') and YEARIN = '" + yearin +
                                        @"' GROUP BY EduType
                                        ORDER BY EduType"
                                        ;
                // Console.WriteLine(sqlWhere);
                return sqlWhere;
            }

            //เพิ่ม Function Select count อาชีพ
            public string GetReporOccupation(string yearin)
            {
                string sqlWhere = @"SELECT (
	                                    CASE
	                                    WHEN p.OCCCODE = 'A'  then '1'
	                                    WHEN p.OCCCODE = 'B'  then '2'
	                                    WHEN p.OCCCODE = 'C'  then '3'
	                                    WHEN p.OCCCODE = 'D'  then '4'
	                                    WHEN p.OCCCODE = 'E'  then '5'
	                                    WHEN p.OCCCODE = 'F'  then '6'
                                        WHEN p.OCCCODE = 'G'  then '7'
                                        WHEN p.OCCCODE = 'H'  then '8'
	                                    ELSE '9' END) as OccType
	                                    ,count(ID8) as OccCount
	                                    FROM person p LEFT JOIN occtab o1 ON o1.OCCCODE = p.OCCCODE
	                                    WHERE BATT < 6 and (OLDYEARIN is null or OLDYEARIN = '') and YEARIN = '" + yearin +
                                        @"' GROUP BY OccType
	                                    ORDER BY OccType"
                                        ;
                return sqlWhere;
            }

            //เพิ่ม Function Select ข้อมูลเลขบัตรประขำตัวประชาชนที่ยังไม่มีในระบบ
            public string GetReportLostInformation_ID13(string yearin)
            {
                string sql = @"SELECT BATT,COMPANY,CONCAT(PLATOON,IF(LENGTH(PSEQ) = 1,'0',''),PSEQ) as 'Number',ID8,`NAME`,SNAME,ID13
                                    from person
                                    where (ID13 is null or ID13 = '' or (LENGTH(ID13)<13)) 
                                           and batt < 6 and yearin = '" + yearin + @"'
                                    ORDER BY BATT,COMPANY,PLATOON,PSEQ"
                                    ;
                // Console.WriteLine("SQL Check ID13 is " + sql);
                return sql;
            }

            //เพิ่ม Function Select ข้อมูลพลหทารที่ไม่มีวุมฒิการศึกษา หรือ ปวช"ขึ้นไป"แต่ไม่มีสาขา
            public string GetReportLostInformation_Educate(string yearin)
            {
                string sql = @"SELECT  p.BATT
                                      ,p.COMPANY
                                      ,CONCAT(p.PLATOON,IF(LENGTH(p.PSEQ) = 1,'0',''),p.PSEQ) as 'Number'
                                      ,p.ID8
                                      ,p.`NAME`
                                      ,p.SNAME
                                      ,educ.EDUCNAME as educate
                            from person p LEFT JOIN eductab educ on p.EDUCODE1 = educ.ECODE1 and p.EDUCODE2= educ.ECODE2
                            where (p.EDUCODE1 is null or p.EDUCODE1 = '' or ((p.EDUCODE1 BETWEEN 4 and 8) and p.EDUCODE2 = '001')) 
                                   and batt < 6 and yearin = '" + yearin + @"'
                            ORDER BY p.BATT,p.COMPANY,p.PLATOON,p.PSEQ"
                                ;
                //Console.WriteLine("SQL Check Educate is " + sql);
                return sql;
            }

            //เพิ่ม Function Select ข้อมูลเลขบัญชีธนาคาร หรือ ที่ยังไม่มีสังกัดธนาคารในระบบ
            public string GetReportLostInformation_AccountNum(string yearin)
            {
                string sql = @"SELECT p.BATT
                                     ,p.COMPANY
                                     ,CONCAT(p.PLATOON,IF(LENGTH(p.PSEQ) = 1,'0',''),p.PSEQ) as 'Number'
                                     ,p.ID8
                                     ,p.`NAME`
                                     ,p.SNAME
                                     ,p.AccountNum
                                     ,bank.EngShortName
                                from person p LEFT JOIN bankingtab bank on p.BankCode = bank.BankCode
                                where (p.AccountNum is null or p.AccountNum = '' or p.BankCode is null or p.BankCode = '') 
                                       and batt < 6 and yearin = '" + yearin + @"'
                                ORDER BY p.BATT,p.COMPANY,p.PLATOON,p.PSEQ"
                                ;
                //Console.WriteLine("SQL Check Account is " + sql);
                return sql;
            }

            public string searchPeople(string navyid)
            {

                string sqlWhere = @" SELECT ps.`NAME`,ps.SNAME,ps.yearin,ps.oldyearin,u.UNITNAME as unit3,p.* FROM people p
                                        LEFT JOIN person ps on ps.navyid = p.navyid 
LEFT JOIN unittab u on u.REFNUM = ps.UNIT3
                                        where (1=1)  ";


                //if (string.IsNullOrEmpty(id13) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(sname) && string.IsNullOrEmpty(book_number) && string.IsNullOrEmpty(rank))
                //{
                //    sqlWhere += " and (1=2) ";
                //}
                //else
                //{
                if (!string.IsNullOrEmpty(navyid))
                {
                    sqlWhere += " and p.navyid = '" + navyid + "' ";
                }

                // }


                return sqlWhere;
            }

            public string GetListPeople()
            {

                string sqlWhere = @" select * from people
                                        where (1=1) and (1=2)  ";


                return sqlWhere;
            }
            public string GetListPremoreAdress(string name, string sname, string report_number, string book_number, string rank, string id13, string YEARIN, bool move_in, string unit3)
            {

                string sqlWhere = @" select per.`NAME`
                                            ,SNAME
,per.navyid
                                            ,YEARIN,ID8
                                            ,u.UNITNAME

                                            ,if(p.navyid is not null,sm.status_name,'ยังไม่ย้ายเข้า') as StatusName
 ,p.report_number 
,per.id13
,p.book_number
,p.rank
                                          	
                                        from person per
                                            LEFT JOIN  people p on per.navyid = p.navyid
                                            LEFT JOIN unittab u on u.REFNUM = per.UNIT3
                                            LEFT JOIN status_move sm on sm.status_id = p.`status`
                                        WHERE (1=1)  ";
                if (!string.IsNullOrEmpty(name))
                {
                    sqlWhere += " and per.name like '" + name + "%' ";
                }
                if (!string.IsNullOrEmpty(sname))
                {
                    sqlWhere += " and per.sname like '" + sname + "%' ";
                }
                if (!string.IsNullOrEmpty(report_number))
                {
                    sqlWhere += " and p.report_number = '" + report_number + "' ";
                }
                if (!string.IsNullOrEmpty(book_number))
                {
                    sqlWhere += " and p.book_number = '" + book_number + "' ";
                }
                if (!string.IsNullOrEmpty(rank))
                {
                    sqlWhere += " and p.rank = '" + rank + "' ";
                }
                if (!string.IsNullOrEmpty(id13))
                {
                    sqlWhere += " and per.id13 = '" + id13 + "' ";
                }
                if (!string.IsNullOrEmpty(unit3))
                {
                    sqlWhere += " and per.unit3 = '" + unit3 + "' ";
                }
                if (!YEARIN.Equals(" /"))
                {
                    sqlWhere += " and per.YEARIN = '" + YEARIN + "' ";
                }
                if (move_in)
                {
                    sqlWhere += " and p.navyid is not null ";
                }
                sqlWhere += @" Order BY p.book_number*1 ,p.rank*1 ";
                return sqlWhere;
            }
            public string GetMaxReport_Number()
            {

                string sqlWhere = @" select (MAX(p.report_number)+1) as report_number  from people p  ";

                return sqlWhere;
            }

            public string GetMaxSubUnit(string Unit)
            {

                string sqlWhere = @" select MAX(subunit_id) as subunit_id from address_unit 
                                        WHERE unit_id='" + Unit + "'   ";

                return sqlWhere;
            }

            public string GetReportListPeople(string report_number)
            {




                string sqlWhere = @" select 
 CONCAT(per.`NAME`,if(p.people_name is not null and p.people_name <> '', CONCAT('(',p.people_name,')') , ' ')) as NAME
,CONCAT(per.SNAME,if(p.people_lname is not null and p.people_lname <> '', CONCAT('(',p.people_lname,')') , ' ')) as SNAME
,CONCAT(SUBSTR(p.ID13,1,1),'-',SUBSTR(p.ID13,2,4),'-',SUBSTR(p.ID13,6,5),'-',SUBSTR(p.ID13,11,2),'-',SUBSTR(p.ID13,13,1)) as ID13
,per.YEARIN,p.book_number,p.rank,per.ID8,au.unit_name
,CONCAT('เลขที่ ',if(p.address_out is not null and p.address_out <> '', p.address_out , '-')
,' หมู่ที่ ',if(p.address_mu_out is not null and p.address_mu_out <> '', p.address_mu_out , '-')
,' ถนน', if(p.address_road_out is not null and p.address_road_out <> '', p.address_road_out , '-')
,'  ซอย ', if(p.address_soid_out is not null and p.address_soid_out <> '', p.address_soid_out , '-')
) as full_address
,CONCAT(
'ตำบล',IFNULL(t3.TOWNNAME,'-')
,'  อำเภอ',IFNULL(t2.TOWNNAME,'-')
,'  จังหวัด',IFNULL(t1.TOWNNAME,'-')) as TOWNNAME
                                        from people p 
                                        left join person per on p.navyid=per.NAVYID
                                            left join address_unit au on au.unit_id=per.UNIT3
                                            LEFT JOIN townname t1 on CONCAT(SUBSTR(p.towncode_out,1,2),'0000') = t1.TOWNCODE
                                            LEFT JOIN townname t2 on CONCAT(SUBSTR(p.towncode_out,1,4),'00') = t2.TOWNCODE
                                    LEFT JOIN townname t3 on p.towncode_out = t3.TOWNCODE
                                    WHERE (1=1)
                                     ";
                if (string.IsNullOrEmpty(report_number))
                {
                    sqlWhere += " and (1=2) ";
                }
                else
                {
                    if (!string.IsNullOrEmpty(report_number))
                    {
                        sqlWhere += " and p.report_number = '" + report_number + "' ";

                    }

                }
                sqlWhere += " order by p.book_number*1,p.rank*1 ";
                return sqlWhere;
            }

            public string GetReportListPeople(string unit_id, string yearin)
            {




                string sqlWhere = @" select 
 CONCAT(per.`NAME`,if(p.people_name is not null and p.people_name <> '', CONCAT('(',p.people_name,')') , ' ')) as NAME
,CONCAT(per.SNAME,if(p.people_lname is not null and p.people_lname <> '', CONCAT('(',p.people_lname,')') , ' ')) as SNAME
,CONCAT(SUBSTR(p.ID13,1,1),'-',SUBSTR(p.ID13,2,4),'-',SUBSTR(p.ID13,6,5),'-',SUBSTR(p.ID13,11,2),'-',SUBSTR(p.ID13,13,1)) as ID13
,per.YEARIN,p.book_number,p.rank,per.ID8,au.unit_name
,CONCAT('เลขที่ ',if(p.address_in is not null and p.address_in <> '', p.address_in , '-')
,' หมู่ที่ ',if(p.address_mu_in is not null and p.address_mu_in <> '', p.address_mu_in , '-')
,' ถนน', if(p.address_road_in is not null and p.address_road_in <> '', p.address_road_in , '-')
,'  ซอย ', if(p.address_soid_in is not null and p.address_soid_in <> '', p.address_soid_in , '-')
) as full_address
,CONCAT(
'ตำบล',IFNULL(t3.TOWNNAME,'-')
,'  อำเภอ',IFNULL(t2.TOWNNAME,'-')
,'  จังหวัด',IFNULL(t1.TOWNNAME,'-')) as TOWNNAME
                                        from people p 
                                        left join person per on p.navyid=per.NAVYID
                                            left join address_unit au on au.unit_id=per.UNIT3
                                            LEFT JOIN townname t1 on CONCAT(SUBSTR(per.TOWNCODE,1,2),'0000') = t1.TOWNCODE
                                            LEFT JOIN townname t2 on CONCAT(SUBSTR(per.TOWNCODE,1,4),'00') = t2.TOWNCODE
                                    LEFT JOIN townname t3 on per.TOWNCODE = t3.TOWNCODE
                                    WHERE (1=1)
                                     ";
                if (string.IsNullOrEmpty(unit_id))
                {
                    sqlWhere += " and (1=2) ";
                }
                else
                {
                    if (!string.IsNullOrEmpty(unit_id))
                    {
                        sqlWhere += " and per.UNIT3 = '" + unit_id + "' ";

                    }
                    if (!string.IsNullOrEmpty(yearin) && yearin != "/")
                    {
                        sqlWhere += " and per.YEARIN = '" + yearin + "' ";

                    }
                    sqlWhere += " ORDER BY per.ID8 ";
                }

                return sqlWhere;
            }

            public string GetReportListAddressmore(string unit_id, string yearin)
            {
                string sqlWhere = @"
                                    SELECT  ut.unitname,`NAME`, `SNAME`,IFNULL(p.OLDYEARIN,p.YEARIN) as `YEARIN`,p.navyid ,`ID8` ,e.EDUCNAME as EDUCNAME ,IF(st.Unit4=p.UNIT3,pt.POSTNAME,' ') as POSTNAME 
                                            ,if(Addictive=0,'',CONCAT('กลุ่ม ',Addictive) ) as ADDICTIVE,p.Note
                                    FROM `person` p
                                    LEFT JOIN eductab e on e.ECODE1 = p.EDUCODE1 and e.ECODE2=p.EDUCODE2
                                    LEFT JOIN selectexam st on st.NAVYID = p.NAVYID
                                    LEFT JOIN positiontab pt on pt.POSTCODE = p.POSTCODE
                                    LEFT JOIN unittab ut on ut.refnum	 = p.unit3
                                    LEFT JOIN addictivetab addict on addict.addcode = p.addictive
                                    WHERE (1=1) 
";
                if (!string.IsNullOrEmpty(unit_id))
                {
                    sqlWhere += " and p.UNIT3 = '" + unit_id + "' ";
                   // Console.WriteLine("UNIT IS : " + unit_id);
                }
                if (!string.IsNullOrEmpty(yearin) && yearin != "/")
                {
                    sqlWhere += " and p.YEARIN = '" + yearin + "' ";

                }
                sqlWhere += "  ORDER BY p.ID8  ";


                return sqlWhere;
            }
            public string GetReportExportToExcel(string unit_id, string yearin)
            {
                string sqlWhere = @"
                                   select p.unit3 as unitcode ,if(p.unit3<>0,un.unitname,' ') as unitname ,
       if(p.unit3=se.unit4,po.postname,' ') as position ,st.title,
       if(p.oldyearin is null,p.yearin,p.oldyearin) as yearin ,p.id8, p.name,p.sname,p.id,p.id13,p.blood, 
       p.birthdate,substring(p.birthdate,9,2) as birth_day ,abs(substring(p.birthdate,6,2)) as birth_month ,(abs(substring(p.birthdate,1,4))+543) as birth_year ,
       p.mark as blamed ,p.address,p.address_mu as mu ,p.address_soil as soi ,p.address_road as street ,       
       t1.townname as district1 ,t2.townname as district2 ,t3.townname as province ,t1.zip,       
       reg.religion,p.height,       
       p.father,p.fsname,p.mother,msname,
       e.educname as education ,       

       if(p.skillcode<>'B',sk.skill,' ') as skill  ,  
       if(p.occcode<>'H',occ.occname,' ') as occupation ,       
       if(LEFT(p.is_request,1)='1','ร้องขอ',' ') as remark ,
       p.regdate as register ,dayofmonth(p.regdate) as register_day ,month(p.regdate) as register_month , abs(year(p.regdate))+543 as register_year    ,       
       k.kptclass,addict.addname as ADDICTIVE,p.Note 
from person p
     left outer join townname t1 on (p.towncode=t1.towncode)     
     left outer join townname t2 on (concat(substring(p.towncode,1,4),'00')=t2.towncode)     
     left outer join townname t3 on (concat(substring(p.towncode,1,2),'0000')=t3.towncode)         
     left outer join religion reg on (p.regcode=reg.regcode)     
     left outer join eductab e on (concat(p.educode1,p.educode2)=concat(e.ecode1,e.ecode2))     
     left outer join skilltab sk on (p.skillcode=sk.skillcode)     
     left outer join occtab occ on (p.occcode=occ.occcode)   
     left outer join unittab un on (p.unit3=un.refnum)       
     left OUTER join selectexam se on (p.navyid=se.navyid)     
     left outer join positiontab po on (se.postcode=po.postcode)     
     left outer join statustab st on (p.statuscode=st.statuscode)     
	 left outer join kptclass k on (left(p.kpt,2)=k.kptcode)
     left join addictivetab addict on addict.addcode = p.addictive
where (1=1) 

 
";
                if (!string.IsNullOrEmpty(unit_id))
                {
                    sqlWhere += " and p.UNIT3 = '" + unit_id + "' ";

                }
                if (!string.IsNullOrEmpty(yearin) && yearin != "/")
                {
                    sqlWhere += " and p.YEARIN = '" + yearin + "' ";

                }
                sqlWhere += "  order by p.unit3,p.id8  ";


                return sqlWhere;
            }
            public string GetReportSumP()
            {
                string sqlWhere = @"
                                    
                                
select  per.UNIT3,u.UNITNAME,COUNT(per1.UNIT3) as peopleIN,COUNT(per2.UNIT3)  as peopleOUT
from people p 
LEFT JOIN  person per on (per.NAVYID = p.navyid)
LEFT JOIN unittab u on u.REFNUM = per.UNIT3
LEFT JOIN  person per1 on (per1.NAVYID = p.navyid and p.`status`=1)
LEFT JOIN  person per2 on (per2.NAVYID = p.navyid and p.`status`in(2,3))
WHERE p.navyid is not null

GROUP BY UNIT3




";


                return sqlWhere;
            }
            public string searchaddress_unit(string unit)
            {

                string sqlWhere = " SELECT * from address_unit u where (1=1) ";


                if (string.IsNullOrEmpty(unit))
                {
                    sqlWhere += " and (1=2) ";
                }
                else
                {

                    sqlWhere += " and u.unit_id = '" + unit + "' ";


                }


                return sqlWhere;
            }
            public string searchaddress_subunit(string subunit_id)
            {

                string sqlWhere = " SELECT * from address_unit u where (1=1) ";


                if (string.IsNullOrEmpty(subunit_id))
                {
                    sqlWhere += " and (1=2) ";
                }
                else
                {

                    sqlWhere += " and u.subunit_id = '" + subunit_id + "' ";


                }


                return sqlWhere;
            }

            public enum RequestPersonFilter
            {
                All, RTC, Other
            }

            public string searchRequest(string navyid, string name, string sname, string id8, string yearin, RequestPersonFilter type)
            {
                string sql = "";
                string sqlSelect = "SELECT r.navyid, r.YEARIN, p.oldyearin,r.`NAME`,r.SNAME,r.ID8,CONCAT(p.company,'/',p.batt) as com_batt \n" +
                                    ",r.unit ,r.askby ,r.remark ,r.remark2 ,utRequest.unitname ,r.num ,r.updatecount \n" +
                                    "FROM request r LEFT OUTER JOIN unittab utRequest ON (r.UNIT = utRequest.REFNUM) \n" +
                                    "LEFT OUTER JOIN person p ON (r.NAVYID = p.NAVYID) \n";
                string sqlWhere = "";
                string sqlLimit = "";

                sqlWhere = whereEqualsClause(sqlWhere, "r.NAVYID", navyid);
                sqlWhere = whereLikeNameSName(sqlWhere, "r.`NAME`", "r.SNAME", name, sname);
                sqlWhere = whereLikeID8(sqlWhere, "r.ID8", id8);
                sqlWhere = whereYearin(sqlWhere, "r.YEARIN", yearin);

                if (type != RequestPersonFilter.All)
                {
                    if (type == RequestPersonFilter.RTC)
                    {
                        sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " r.UNIT = '26' \n";
                    }
                    else
                    {
                        sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " r.UNIT != '26' \n";
                    }
                }

                sqlWhere += " ORDER BY r.UNIT,SUBSTR(r.ASKBY,1,2),r.NUM, r.`NAME`, r.SNAME \n";

                sql = sqlSelect + sqlWhere + sqlLimit;
                return sql;
            }

            public string searchPersonRequest(string navyid, string name, string sname, string id8, string yearin, bool getNullRequest)
            {
                string sql = "";
                string sqlSelect = "SELECT p.navyid,p.yearin,p.oldyearin,p.`NAME`,p.SNAME,p.ID8,CONCAT(p.company,'/',p.batt) as com_batt \n";
                sqlSelect += ",CASE WHEN r.navyid IS NOT NULL THEN 'มีการร้องขอ' ELSE '' END as 'hasrequest' \n";
                sqlSelect += "FROM person p " + (getNullRequest ? "LEFT OUTER " : "") + "JOIN request r ON (p.NAVYID=r.navyid) \n";

                string sqlWhere = "";
                string sqlLimit = "";

                sqlWhere = whereEqualsClause(sqlWhere, "p.NAVYID", navyid);
                sqlWhere = whereLikeNameSName(sqlWhere, "p.`NAME`", "p.SNAME", name, sname);
                sqlWhere = whereLikeID8(sqlWhere, "p.ID8", id8);
                sqlWhere = whereYearin(sqlWhere, "p.YEARIN", yearin);

                sql = sqlSelect + sqlWhere + sqlLimit;
                return sql;
            }

            public string CheckRequestDuplicateNUM(string askby, string num)
            {
                string sql = "SELECT COUNT(*) as countNUM FROM request WHERE (SUBSTR(ASKBY,1,2) = '" + askby.Substring(0, 2) + "' AND NUM = " + num + ") ;";
                return sql;
            }

            public string GetRequestNUMHigher(string askby, string num)
            {
                string sql = "SELECT NAVYID,ASKBY,UNIT,piority,NUM,updatecount FROM request WHERE SUBSTR(ASKBY,1,2) = '" + askby.Substring(0, 2) + "' AND NUM >= " + num + " ORDER BY NUM ;";
                return sql;
            }

            public string GetMaxYearin()
            {
                return "SELECT SUBSTR(DATE_FORMAT(MAX(STR_TO_DATE(p.YEARIN,'%m/%y')),'%m/%y'),2,4) max_yearin FROM person p;";
            }

            public string GetMaxID8(string armid)
            {
                return "SELECT COALESCE(MAX(SUBSTR(ID,6,10)),0) as maxID8 FROM person p WHERE ARMID = '" + armid + "';";
            }

            public string GetMaxAskbyNUM(string askbyCode, string yearin)
            {
                return "SELECT IFNULL(MAX(r.NUM),0) as maxNUM FROM request r WHERE LEFT(r.ASKBY,2)='" + askbyCode + "' AND r.YEARIN = '" + yearin + "'";
            }

            public string reportPrintNewPerson(string armid)
            {
                string sql = "";
                sql += " SELECT p.*,o.OCCNAME,r.RELIGION,e.EDUCNAME,t1.TOWNNAME province,t2.TOWNNAME amphor,t3.TOWNNAME tumbon \n" +
                        "FROM person p \n" +
                        "LEFT JOIN occtab o ON p.OCCCODE=o.OCCCODE\n" +
                        "LEFT JOIN religion r ON p.REGCODE=r.REGCODE\n" +
                        "LEFT JOIN eductab e ON p.EDUCODE1=e.ECODE1 AND p.EDUCODE2=e.ECODE2\n" +
                        "LEFT JOIN townname t3 ON p.TOWNCODE=t3.TOWNCODE AND t3.CLEVEL = '3'\n" +
                        "LEFT JOIN townname t2 ON (CONCAT(SUBSTR(p.TOWNCODE,1,4),'00'))=t2.TOWNCODE AND t2.CLEVEL = '2'\n" +
                        "LEFT JOIN townname t1 ON (CONCAT(SUBSTR(p.TOWNCODE,1,2),'0000'))=t1.TOWNCODE AND t1.CLEVEL = '1'\n" +
                        "WHERE (p.oldyearin IS NULL or p.oldyearin = '') ";

                if (!String.IsNullOrWhiteSpace(armid))
                {
                    sql += " AND p.armid ='" + armid + "'";
                }

                sql += " ORDER BY p.id8 ";

                return sql;
            }

            public enum SummaryPersonType
            {
                All, Escape, Register, Study, Prepare, Training
            }

            public string sumPersonByArmtown(SummaryPersonType pType, string yearinForm, string yearinTo)
            {
                string sql = "";
                string sqlWhere = "";
                sql += "SELECT a.LEGION,a.ARMNAME,count(p.ID13) as allperson FROM person p JOIN armtown a ON p.ARMID=a.ARMID\n";

                switch (pType)
                {
                    case SummaryPersonType.Escape:
                        sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " p.BATT=7\n"; break;
                    case SummaryPersonType.Register:
                        sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " p.BATT<7\n"; break;
                    case SummaryPersonType.Study:
                        sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " p.BATT=6\n"; break;
                    case SummaryPersonType.Prepare:
                        sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " p.BATT=5\n"; break;
                    case SummaryPersonType.Training:
                        sqlWhere += (sqlWhere == "" ? "WHERE" : "AND") + " p.BATT<5\n"; break;
                    default:
                        sqlWhere += ""; break;
                }

                sql += sqlWhere;


                sql += "GROUP BY a.ARMNAME\n" +
                      "ORDER BY a.LEGION,a.ABBNAME;";
                return sql;
            }

            public string sumPersonByArmtown(string legion)
            {
                string sql = "";
                sql += "SELECT a.LEGION,a.ARMNAME,a.ABBNAME\n" +
                        ",count(p.ID13) as 'count_person'\n" +
                        ",SUM(CASE WHEN p.oldyearin IS NULL THEN 1 ELSE 0 END ) as 'count_all'\n" +
                        ",SUM(CASE WHEN p.BATT=7 AND p.oldyearin IS NULL THEN 1 ELSE 0 END ) 'count_escape'\n" +
                        ",SUM(CASE WHEN p.BATT<7 AND p.oldyearin IS NULL THEN 1 ELSE 0 END ) 'count_register'\n" +
                        ",SUM(CASE WHEN p.BATT=6 AND p.oldyearin IS NULL THEN 1 ELSE 0 END ) 'count_study'\n" +
                        ",SUM(CASE WHEN p.BATT=5 AND p.oldyearin IS NULL THEN 1 ELSE 0 END ) 'count_prepare'\n" +
                        ",SUM(CASE WHEN p.BATT<5 AND p.oldyearin IS NULL THEN 1 ELSE 0 END ) 'count_training'\n" +
                        ",SUM(CASE WHEN p.BATT<5 AND p.oldyearin IS NOT NULL THEN 1 ELSE 0 END ) 'count_oldperson'\n" +
                        "FROM person p JOIN armtown a ON p.ARMID=a.ARMID\n";

                if (!String.IsNullOrWhiteSpace(legion))
                {
                    sql += "WHERE a.LEGION='" + legion + "'\n";
                }

                sql += "GROUP BY a.ARMNAME\n" +
                "ORDER BY a.LEGION,a.ABBNAME;";
                return sql;
            }

            public string countUNIT3(string yearin)
            {
                string sql = "";
                sql += "SELECT u.UNITNAME,COUNT(p.UNIT3) as count_person_per_unit \n" +
                        "FROM person p JOIN unittab u ON p.UNIT3=u.REFNUM\n";

                if (!String.IsNullOrWhiteSpace(yearin))
                {
                    sql += "WHERE p.YEARIN='" + yearin + "'\n";
                }
                sql += "GROUP BY u.UNITNAME";

                return sql;
            }

            public string reportDevideUnitListPerson(string yearin)
            {
                string sql = "";
                string sqlSelect = "SELECT p.navyid, p.YEARIN, p.oldyearin,p.`NAME`,p.SNAME,p.ID8,p.ID13,CONCAT(p.company,'/',p.batt) as com_batt,p.NLABEL,p.UNIT3 \n" +
                                    "FROM person p \n";
                string sqlWhere = "";
                string sqlLimit = "";

                sqlWhere = whereYearin(sqlWhere, "p.YEARIN", yearin);
                sqlWhere += " ORDER BY p.BATT, p.COMPANY, p.PLATOON, p.PSEQ LIMIT 50 \n";

                sql = sqlSelect + sqlWhere + sqlLimit;
                return sql;
            }

            public string reportHistoryBook(string yearin, string batt, string company, string platoon)
            {
                string sql = "";
                string sqlSelect = "SELECT p.ID, p.ARMID, p.PSEQ,p.YEARIN, p.ID8, p.NAME, p.SNAME, p.BIRTHDATE, p.SCHOOLCODE,p.PLATOON\n" +
                    ",p.REGDATE, p.MARK, p.ADDRESS, p.IS_REQUEST, t.TOWNNAME\n" +
                    ",t.ZIP, p.EDUCODE1, o.OCCNAME, p.HEIGHT, t.TOWNCODE\n" +
                    ",p.FATHER, p.FSNAME, p.MOTHER, p.MSNAME, r.RELIGION, e.EDUCNAME\n" +
                    ",p.SKILLCODE, p.ADDRESS_MU, p.ADDRESS_SOIL , p.ADDRESS_ROAD , s.UNITNAME , p.MOVEDATE\n" +
                    ",CAST(if(pseq<10,concat(platoon,'0', cast(pseq as char)),concat(platoon,pseq)) AS CHAR) im\n" +
                    ",cast(p.navyid as char) NAVYID\n" +
                    "FROM person p\n" +
                    "LEFT OUTER JOIN eductab e ON ((p.EDUCODE1 = e.ECODE1)\n" +
                    "AND (p.EDUCODE2 = e.ECODE2))\n" +
                    "LEFT OUTER JOIN occtab o ON (p.OCCCODE = o.OCCCODE) \n" +
                    "LEFT OUTER JOIN religion r ON (p.REGCODE = r.REGCODE) \n" +
                    "LEFT OUTER JOIN townname t ON (p.TOWNCODE = t.TOWNCODE) \n" +
                    "LEFT OUTER JOIN unittab s ON (p.UNIT3 = s.REFNUM) \n";

                string sqlWhere = "";
                sqlWhere = whereYearinAndOldYearinNull(sqlWhere, "p.YEARIN", "p.OLDYEARIN", yearin);
                sqlWhere = String.IsNullOrWhiteSpace(batt) ? sqlWhere : whereEqualsClause(sqlWhere, "p.BATT", batt);
                sqlWhere = String.IsNullOrWhiteSpace(company) ? sqlWhere : whereEqualsClause(sqlWhere, "p.COMPANY", company);
                sqlWhere = String.IsNullOrWhiteSpace(platoon) ? sqlWhere : whereEqualsClause(sqlWhere, "p.PLATOON", platoon);
                sqlWhere += "ORDER BY p.BATT, p.COMPANY ,p.PLATOON ,im";

                string sqlLimit = "";
                sql = sqlSelect + sqlWhere + sqlLimit;
                return sql;
            }
        }

        public class UpdateRecord
        {
            public string InsertPersonNivy()
            {
                string sql = "";
                sql += "INSERT INTO nivy1 ( \n" +
                    "`ID13`, `NAME`, `SNAME`, `BIRTHDATE`, `FATHER`, `MOTHER`, `MID`, `MID_DATE`, `SCARE` \n" +
                    ", `ADDRESS`, `M_TT`, `EMPLOYMENT`, `TALL`, `WEIGHT`, `CHESS_IN`, `CHESS_OUT`, `RECRUIT_CODE`, `RECRUIT_DATE`, `RECRUIT_NOTE` \n" +
                    ", `YEARIN`, `LFANAME`, `LMANAME` \n" +
                    ") \n";
                sql += "VALUES (\n" +
                        "@ID13, @NAME_, @SNAME, @BIRTHDATE, @FATHER, @MOTHER, @MID, @MID_DATE, @SCARE \n" +
                        ", @ADDRESS, @M_TT, @EMPLOYMENT, @TALL, @WEIGHT, @CHESS_IN, @CHESS_OUT, @RECRUIT_CODE, @RECRUIT_DATE, @RECRUIT_NOTE \n" +
                        ", @YEARIN, @LFANAME, @LMANAME \n" +
                        ")";
                return sql;
            }

            public string InsertNivyToTempPerson()
            {
                string sql = "";
                sql += "INSERT INTO person_nivy (" +
                    "YEARIN,ID13,`NAME`,SNAME,BIRTHDATE,ADDRESS,ADDRESS_MU,TOWNCODE,ARMID \n" +
                    ",FATHER,FSNAME,MOTHER,MSNAME,MARK,HEIGHT \n" +
                    ",RECORDDATE \n" +
                    ") \n";
                sql += "VALUES \n" +
                       "(@YEARIN,@ID13,@NAME_,@SNAME,@BIRTHDATE,@ADDRESS,@ADDRESS_MU,@TOWNCODE,@ARMID \n" +
                       ",@FATHER,@FSNAME,@MOTHER,@MSNAME,@MARK,@HEIGHT \n" +
                       ",CONCAT(CURDATE(),' ',CURTIME()))";
                return sql;
            }

            public string InsertNewPerson()
            {
                string sql = "";
                sql += "INSERT INTO person (" +
                    "YEARIN,origincode,REGDATE,REPDATE,ID13,`NAME`,SNAME,BIRTHDATE,ADDRESS,ADDRESS_MU,ADDRESS_SOIL,ADDRESS_ROAD,TOWNCODE,ARMID \n" +
                    ",FATHER,FSNAME,MOTHER,MSNAME,PERTYPE,RUNCODE,ID8,ID,MARK,EDUCODE0,EDUCODE1,EDUCODE2,REGCODE,OCCCODE,HEIGHT,WIDTH,IS_REQUEST,BATT,COMPANY,PLATOON,PSEQ \n" +
                    ",RECORDDATE,RECORDBY,SKILLCODE,Telephone,FTelephone,MTelephone,PTelephone,Addictive,FlagReadfrom_IDCard,BankCode,AccountNum \n" +
                    ") \n";
                sql += "VALUES \n" +
                       "(@YEARIN,@origincode,@REGDATE,@REPDATE,@ID13,@NAME_,@SNAME,@BIRTHDATE,@ADDRESS,@ADDRESS_MU,@ADDRESS_SOIL,@ADDRESS_ROAD,@TOWNCODE,@ARMID \n" +
                       ",@FATHER,@FSNAME,@MOTHER,@MSNAME,@PERTYPE,@RUNCODE,@ID8,@ID,@MARK,@EDUCODE0,@EDUCODE1,@EDUCODE2,@REGCODE,@OCCCODE,@HEIGHT,@WIDTH,@IS_REQUEST, @BATT, @COMPANY, @PLATOON, @PSEQ \n" +
                       ",CONCAT(CURDATE(),' ',CURTIME()),@RECORDBY,@SKILLCODE,@Telephone,@FTelephone,@MTelephone,@PTelephone,@addictive_status,@flagreadfrom_IDCard,@BankCode,@AccountNum )";
                return sql;
            }

            public string InsertNewPeople()
            {
                string sql = "";
                sql += @"INSERT INTO people ( 
                                                id13
                                                ,navyid
,people_name
,people_lname
                                                ,address_in
                                                ,address_mu_in
                                                ,address_soid_in
                                                ,address_road_in
       
                                                ,towncode_in
                                                ,address_out
                                                ,address_mu_out
                                                ,address_soid_out
                                                ,address_road_out
                                                ,towncode_out            
                                                ,type_out
                                                ,rank
                                                ,book_number
                                                ,status
                                                ,dead_date
                                                ,in_date
                                                ,out_date
                                                ,pseq
                                                
                                        ) VALUES (
                                                @id13
                                                ,@navyid
,@people_name
,@people_lname
                                                ,@address_in
                                                ,@address_mu_in
                                                ,@address_soid_in
                                                ,@address_road_in
                                                ,@towncode_in
                                                ,@address_out
                                                ,@address_mu_out
                                                ,@address_soid_out
                                                ,@address_road_out
                                                ,@towncode_out                
                                                ,@type_out
                                                ,@rank
,@book_number
                                                ,@status
                                                ,@dead_date
                                                ,@in_date
                                                ,@out_date
,@pseq
                                               
                                        )";
                return sql;
            }
            public string InsertNewSubUnit()
            {
                string sql = "";
                sql += @"INSERT INTO address_unit ( 
                                                unit_id
                                                ,subunit_id
,unit_name
,TOWNCODE
                                                ,ADDRESS
                                                ,ADDRESS_MU
                                                ,ADDRESS_SOIL
                                                ,ADDRESS_ROAD
       
                                                ,level
                                               
                                                
                                        ) VALUES (
                                                @unit_id
                                                ,@subunit_id
,@unit_name
,@TOWNCODE
                                                ,@ADDRESS
                                                ,@ADDRESS_MU
                                                ,@ADDRESS_SOIL
                                                ,@ADDRESS_ROAD
       
                                                ,@level
                                               
                                               
                                        )";
                return sql;
            }
            public string UpdatePeople()
            {

                string strSql = @"  Update people set
                                                             id13=@id13
                                                             ,address_in=@address_in
                                                             ,address_mu_in=@address_mu_in
                                                             ,address_soid_in=@address_soid_in
                                                             ,address_road_in=@address_road_in
                                                             ,towncode_in=@towncode_in
                                                             ,address_out=@address_out
                                                             ,address_mu_out=@address_mu_out
                                                             ,address_soid_out=@address_soid_out
                                                             ,address_road_out=@address_road_out
                                                             ,towncode_out=@towncode_out
                                                             ,type_out=@type_out
                                                             ,rank=@rank
                                                             ,book_number=@book_number
                                                             ,status=@status
                                                             ,dead_date=@dead_date
                                                             ,in_date=@in_date
                                                             ,out_date=@out_date
 ,people_name=@people_name
 ,people_lname=@people_lname
,report_number=@report_number
,report_date=@report_date
,pseq=@pseq

                                                           
                                                             where navyid=@navyid ";
                return strSql;

            }
            public string UpdatePerson(string navyid)
            {
                string sql = "";
                sql += "UPDATE person SET \n" +
                    "YEARIN = @YEARIN,origincode = @origincode,REGDATE = @REGDATE,REPDATE=@REPDATE,ID13=@ID13,`NAME`=@NAME_,SNAME=@SNAME \n" +
                    ",BIRTHDATE=@BIRTHDATE,ADDRESS=@ADDRESS,ADDRESS_MU=@ADDRESS_MU,ADDRESS_SOIL=@ADDRESS_SOIL,ADDRESS_ROAD=@ADDRESS_ROAD,TOWNCODE=@TOWNCODE,ARMID=@ARMID \n" +
                    ",FATHER=@FATHER,FSNAME=@FSNAME,MOTHER=@MOTHER,MSNAME=@MSNAME,PERTYPE=@PERTYPE,RUNCODE=@RUNCODE,ID8=@ID8,ID=@ID \n" +
                    ",MARK=@MARK,EDUCODE0=@EDUCODE0,EDUCODE1=@EDUCODE1,EDUCODE2=@EDUCODE2,REGCODE=@REGCODE,OCCCODE=@OCCCODE,HEIGHT=@HEIGHT,WIDTH=@WIDTH,IS_REQUEST=@IS_REQUEST \n" +
                    ",BATT=@BATT,COMPANY=@COMPANY,PLATOON=@PLATOON,PSEQ=@PSEQ \n" +
                    ",RECORDDATE=CONCAT(CURDATE(),' ',CURTIME()),RECORDBY=@RECORDBY" +
                    ",kpt=@kpt,PERCENT=@percent,SKILLCODE=@SKILLCODE,Telephone=@Telephone" +
                    ",FTelephone=@FTelephone,MTelephone=@MTelephone,PTelephone=@PTelephone,Addictive=@addictive_status,FlagReadfrom_IDCard = @flagreadfrom_IDCard,BankCode = @BankCode,AccountNum = @AccountNum \n" +
                    " \n";
                sql += "WHERE NAVYID = '" + navyid + "'";
                return sql;
            }

            public string CheckPersonDuplicateKeys(string navyid)
            {
                string sql = "SELECT NAVYID,ID13,ID8,ID,RUNCODE,YEARIN FROM person WHERE ((YEARIN=@YEARIN AND (ID8=@ID8 OR RUNCODE=@RUNCODE)) OR ID=@ID OR ID13=@ID13) ";
                if (!String.IsNullOrWhiteSpace(navyid))
                {
                    sql += " AND NAVYID<>@NAVYID ";
                }
                return sql;
            }

            public string CheckPersonDuplicateKeys()
            {
                return CheckPersonDuplicateKeys("");
            }

            public string InsertRequest()
            {
                string sql = "";
                sql = "INSERT request (YEARIN,NAVYID,ID8,`NAME`,SNAME,UNIT,ASKBY,NUM,REMARK,REMARK2,FLAG,UPDDATE,piority,UPDBY,UPDTIME,UPDATECOUNT)\n" +
                    "VALUES (@yearin,@navyid,@id8,@name_,@sname,@unit,@askby,@num,@remark,@remark2,@flag,CURDATE(),@piority,@username,CURTIME(),0);\n";
                return sql;
            }

            public string UpdateRequest(int updatecount)
            {
                string sql = "";
                sql = "UPDATE request r\n" +
                    "SET r.UNIT = @unit, r.ASKBY = @askby, r.NUM = @num, r.REMARK = @remark, r.REMARK2 = @remark2 \n" +
                    ",r.FLAG = @flag, r.UPDDATE = CURDATE() ,r.piority = @piority, r.UPDBY = @username, r.UPDTIME = CURTIME(), r.UPDATECOUNT = @updatecount \n" +
                    "WHERE r.NAVYID = @navyid ;\n";
                return sql;
            }

            public string UpdatePersonRequestUNIT3()
            {
                string sql = "UPDATE person p\n" +
                    "SET p.UNIT0 = @unit, p.UNIT3 = @unit, p.ASK = @ask, p.NUMBER = @num, p.REM = @remark, p.REM2 = @remark2 \n" +
                    "WHERE p.NAVYID = @navyid ;\n";
                return sql;
            }

            public string CheckRequestDuplicateKeys(string navyid, string askby, string unit, string piority)
            {
                string sql = "SELECT NAVYID,ASKBY,UNIT,piority FROM request WHERE NAVYID = '" + navyid + "' AND ASKBY = '" + askby + "' AND UNIT = '" + unit + "' AND piority = '" + piority + "' ;";
                return sql;
            }

            public string UpdateNLabel()
            {
                string sql = "UPDATE person p\n" +
                            "JOIN (\n" +
                            "SELECT NAVYID FROM person WHERE UNIT3 = @unit AND YEARIN = @yearin ORDER BY `NAME` LIMIT @limit1,@limit2 \n" +
                            ") p2 USING (NAVYID)\n" +
                            "SET NLABEL = @nlabel;";
                return sql;
            }

            public string UpdateNLabel(string yearin, string unit, int nlabel, int limit1, int limit2)
            {
                string sql = "UPDATE person p\n" +
                            "JOIN (\n" +
                            "SELECT NAVYID FROM person WHERE UNIT3 = " + unit + " AND YEARIN = '" + yearin + "' ORDER BY `NAME` LIMIT " + limit1.ToString() + "," + limit2.ToString() + " \n" +
                            ") p2 USING (NAVYID)\n" +
                            "SET NLABEL = " + nlabel.ToString() + ";\n";
                return sql;
            }



        }
    }
}
