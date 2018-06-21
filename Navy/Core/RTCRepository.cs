using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using Navy.Data.DataTemplate;

namespace Navy.Core
{
    public class RTCRepository : DBConnection
    {

        private string sql;
        private MySqlCommand cmd;

        #region Constructors
        public RTCRepository()
        {

        }
        #endregion

        #region Search and Get Details

        public List<MemberSearch> SearchMember(string yearin, string id8, string name, string sname, string membercode)
        {
            List<MemberSearch> rtcSearch;

            if (openConnection() == true)
            {
                sql = "SELECT m.id, m.yearin, m.id8, p.statuscode";
                sql += ", p.name, p.sname, st.TITLE, st.STITLE";
                sql += ", m.membercode, m.membercode5, m.link, m.start ";
                sql += ", m.estdate, m.end, m.refdoc, m.refdocdate, m.dischargetype";
                sql += "";
                sql += " FROM member m LEFT OUTER JOIN person p ON (m.ID = p.navyid) ";
                sql += " LEFT OUTER JOIN statustab st ON (p.STATUSCODE = st.STATUSCODE)";
                sql += "";
                sql += " WHERE m.yearin LIKE @yearin";
                sql += " AND m.id8 LIKE @id8";
                sql += " AND p.name LIKE @name";
                sql += " AND p.sname LIKE @sname";
                sql += " AND ( m.membercode LIKE @membercode OR m.membercode5 LIKE @membercode)";
                sql += "";
            
                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@yearin", yearin.Replace(" ", "%") + "%");
                cmd.Parameters.AddWithValue("@id8", id8.Replace(" ", "%") + "%");
                cmd.Parameters.AddWithValue("@name", name + "%");
                cmd.Parameters.AddWithValue("@sname", sname + "%");
                cmd.Parameters.AddWithValue("@membercode", membercode + "%");

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    rtcSearch = new List<MemberSearch>();

                    while (dr.Read())
                    {
                        rtcSearch.Add(new MemberSearch(dr));
                    }
                }

                closeConnection();

                return rtcSearch;
            }
            return null;
        }

        public List<MemberSearch> SearchMember(Parameters.MemberSearch searchParams)
        {
            List<MemberSearch> rtcSearch;

            if (openConnection() == true)
            {
                sql = "SELECT m.id, m.yearin, m.id8, p.statuscode";
                sql += ", p.name, p.sname, st.TITLE, st.STITLE";
                sql += ", m.membercode, m.membercode5, m.link, m.start ";
                sql += ", m.estdate, m.end, m.refdoc, m.refdocdate, m.dischargetype";
                sql += "";
                sql += " FROM member m LEFT OUTER JOIN person p ON (m.ID = p.navyid) ";
                sql += " LEFT OUTER JOIN statustab st ON (p.STATUSCODE = st.STATUSCODE)";
                sql += "";
                sql += " WHERE m.yearin LIKE @yearin";
                sql += " AND m.id8 LIKE @id8";
                sql += " AND p.name LIKE @name";
                sql += " AND p.sname LIKE @sname";
                sql += " AND ( m.membercode LIKE @membercode OR m.membercode5 LIKE @membercode)";
                sql += " AND p.statuscode LIKE @statuscode";
                sql += " AND DATE_FORMAT(m.estdate, '%d/%m/%Y') LIKE @estdate";

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@yearin", searchParams.yearin.Replace(" ", "%") + "%");
                cmd.Parameters.AddWithValue("@id8", searchParams.id8.Replace(" ", "%") + "%");
                cmd.Parameters.AddWithValue("@name", searchParams.name + "%");
                cmd.Parameters.AddWithValue("@sname", searchParams.sname + "%");
                cmd.Parameters.AddWithValue("@membercode", searchParams.membercode + "%");
                cmd.Parameters.AddWithValue("@statuscode", searchParams.statuscode + "%");
                cmd.Parameters.AddWithValue("@estdate", searchParams.estdate + "%");
                

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    rtcSearch = new List<MemberSearch>();

                    while (dr.Read())
                    {
                        rtcSearch.Add(new MemberSearch(dr));
                    }
                }

                closeConnection();

                return rtcSearch;
            }
            return null;
        } 

        public RTCDetails GetSelectedDetail(string navyid)
        {
            RTCDetails rtcDetails;

            if (openConnection() == true)
            {
                sql = @"  SELECT p.Telephone,p.FTelephone,p.MTelephone,p.PTelephone,p.navyid, p.name, p.sname, p.statuscode, st.stitle
                , m.membercode, mc.structureid, mc.namecode
                , mc.membercode_parentid as 'p_membercode', mcp.namecode as 'p_namecode'
                , m.membercode5, mc5.namecode as 'namecode5', m.link
                , m.groupid, m.typeid
                
              
                , p.yearin,ifnull( p.OLDYEARIN,p.yearin) as OLDYEARIN, p.id, p.id8, p.id13, p.birthdate, p.mark, p.blood
                , p.address, p.address_mu, p.address_soil, p.address_road
                , p.towncode, tn.townname as 'sub-district'
                , tn2.townname as 'district'
                , tn3.townname as 'Province', tn.zip
                , p.regcode, rl.religion
                , p.father, p.fsname, p.mother, p.msname, p.height,p.width
                , p.occcode, oc.occname 
                ,e1.EDUCNAME  as educ, p.regdate, p.repdate,p.MOVEDATE
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
,ad.addname as addictname
,ind.cause,bankingtab.EngShortName,p.AccountNum
                 FROM person p
                 LEFT OUTER JOIN bankingtab on bankingtab.bankcode = p.bankcode
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
LEFT OUTER JOIN positiontab pst ON (pst.POSTCODE = slt.POSTCODE)
left join eductab e1 on e1.ECODE1 =p.EDUCODE1 and e1.ECODE2 =p.EDUCODE2
left join eductab e2 on (e2.ECODE2 =e1.ECODE2 and e1.ECODE1 =e2.ECODE1 )
LEFT JOIN addictivetab ad on p.Addictive = ad.addcode
LEFT JOIN indictmenttab ind on ind.NavyID = p.NAVYID
                   ";
                sql += " WHERE p.navyid = @navyid";

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@navyid", navyid);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.Read())
                        rtcDetails = new RTCDetails(dr);
                    else
                        rtcDetails = new RTCDetails();                        
                }

                closeConnection();
                return rtcDetails;
            }

            return null;
        }

        public List<RTCTransaction> GetSelectedTransaction(string navyid)
        {
            List<RTCTransaction> rtcTransaction;

            if (openConnection() == true)
            {
                sql = "SELECT st.*, p.*, td.*";
                sql += "";
                sql += " FROM person p INNER JOIN trans_detail td ON (p.navyid = td.navyid)";
                sql += " LEFT OUTER JOIN statustab st ON (concat(td.TRANS_TYPE,td.CODE1) = st.STATUSCODE)";
                sql += "";
                sql += " WHERE p.navyid = @navyid";
                sql += "";
                sql += " ORDER BY td.start_date ASC, td.trans_no ASC";
                sql += "";

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@navyid", navyid);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    rtcTransaction = new List<RTCTransaction>();
                    while (dr.Read())
                    {
                        rtcTransaction.Add(new RTCTransaction(dr));
                    }
                }

                closeConnection();
                return rtcTransaction;
            }


            return null;
        }

        public List<RTCPunishment> GetSelectedPunishment(string navyid)
        {
            List<RTCPunishment> rtcPunishment;
            if (openConnection() == true)
            {
                sql = "SELECT * ";
                sql += "";
                sql += " FROM punishment_details";
                sql += "";
                sql += " WHERE navyid = @navyid";
                sql += " ORDER BY start_date ASC, punish_no ASC";


                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@navyid", navyid);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    rtcPunishment = new List<RTCPunishment>();
                    while (dr.Read())
                    {
                        rtcPunishment.Add(new RTCPunishment(dr));
                    }
                }
                closeConnection();
                return rtcPunishment;
            }

            return null;
        }

        public List<Person> SearchPerson(string yearin, string id8, string name, string sname)
        {
            List<Person> personList=new List<Person>();
            if (openConnection() == true)
            {
                sql = "SELECT p.navyid, p.yearin, p.id8, p.statuscode, p.batt, p.company, p.unit3, p.ask, p.oldyearin, p.regdate, p.movedate";
                sql += ", p.name, p.sname, st.TITLE, st.STITLE, ut.unitname";
                sql += "";
                sql += " FROM person p";
                sql += " LEFT OUTER JOIN statustab st ON (p.STATUSCODE = st.STATUSCODE)";
                sql += " LEFT OUTER JOIN unittab ut ON (p.unit3 = ut.refnum)";
                sql += "";
                sql += " WHERE p.yearin LIKE @yearin";
                sql += " AND p.id8 LIKE @id8";
                sql += " AND p.name LIKE @name";
                sql += " AND p.sname LIKE @sname";
                sql += "";

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@yearin", yearin.Replace(" ", "%") + "%");
                cmd.Parameters.AddWithValue("@id8", id8.Replace(" ", "%") + "%");
                cmd.Parameters.AddWithValue("@name", name + "%");
                cmd.Parameters.AddWithValue("@sname", sname + "%");

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    personList = new List<Person>();

                    while (dr.Read())
                    {
                        personList.Add(new Person(dr));
                    }
                }

                closeConnection();

                return personList;
            }
            return null;
        }

        public List<Person> SearchPerson(Parameters.PersonSearch searchParams)
        {
            return SearchPerson(searchParams.yearin, searchParams.id8, searchParams.name, searchParams.sname);            
        }

        #endregion

        #region Insert new data

        public List<Person> ListNewMember(string yearin, string id8, string unit3, string name, string sname)
        {
            List<Person> person;

            if (openConnection() == true)
            {
                sql = "SELECT p.navyid, p.statuscode, p.YEARIN, p.batt, p.company";
                sql += " , p.name, p.sname, p.ID8, p.unit3, ut.UNITNAME, p.ASK";
                sql += " , p.REGDATE, p.MOVEDATE, p.oldyearin";
                sql += " ";
                sql += " FROM person p LEFT OUTER JOIN unittab ut ON (p.UNIT3 = ut.REFNUM)";
                sql += " LEFT OUTER JOIN member m ON (cast(p.navyid as char) = m.id)";
                sql += " ";
                sql += " WHERE p.yearin LIKE @yearin";
                sql += " AND p.unit3 = @unit3";
                sql += " AND p.name LIKE @name";
                sql += " AND p.sname LIKE @sname";
                sql += " AND p.id8 LIKE @id8";
                sql += " ";
                sql += " AND m.id IS NULL";

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@yearin", yearin.Replace(" ", "%") + "%" );
                cmd.Parameters.AddWithValue("@id8", id8.Replace(" ", "%") + "%");
                cmd.Parameters.AddWithValue("@unit3", unit3);
                cmd.Parameters.AddWithValue("@name", name + "%");
                cmd.Parameters.AddWithValue("@sname", sname + "%");

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    person = new List<Person>();

                    while (dr.Read())
                    {
                        person.Add(new Person(dr));
                    }
                }

                closeConnection();

                return person;
            }
            return null;
        }

        public bool InsertNewMember(TableMember rtc)
        {
            if (openConnection() == true)
            {
                try
                {
                    sql = " INSERT INTO member ";
                    sql += " ( id, id8, yearin, name, sname";
                    sql += " , membercode, membercode5";
                    sql += " , link, groupid, typeid, start";
                    sql += " , doccode, extend, estdate, updby, upddate )";
                    sql += " ";
                    sql += " VALUES ( @navyid, @id8, @yearin, @name, @sname";
                    sql += " , @membercode, @membercode5";
                    sql += " , @link, @groupid, @typeid, @start";
                    sql += " , @doccode, @extend, @estdate, @updby, @upddate )";
                    sql += " ";
                    sql += " ";

                    cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@navyid", Function.GetTextOrNull(rtc.navyid));
                    cmd.Parameters.AddWithValue("@id8", Function.GetTextOrNull(rtc.id8));
                    cmd.Parameters.AddWithValue("@yearin", Function.GetTextOrNull(rtc.yearin));
                    cmd.Parameters.AddWithValue("@name", Function.GetTextOrNull(rtc.name));
                    cmd.Parameters.AddWithValue("@sname", Function.GetTextOrNull(rtc.sname));
                    cmd.Parameters.AddWithValue("@membercode", Function.GetTextOrNull(rtc.membercode));
                    cmd.Parameters.AddWithValue("@membercode5", Function.GetTextOrNull(rtc.membercode5));
                    cmd.Parameters.AddWithValue("@link", Function.GetTextOrNull(rtc.link));
                    cmd.Parameters.AddWithValue("@groupid", Function.GetTextOrNull(rtc.groupid));
                    cmd.Parameters.AddWithValue("@typeid", Function.GetTextOrNull(rtc.typeid));
                    cmd.Parameters.AddWithValue("@start", rtc.start);
                    cmd.Parameters.AddWithValue("@doccode", Function.GetTextOrNull(rtc.doccode));
                    cmd.Parameters.AddWithValue("@estdate", rtc.estdate);
                    cmd.Parameters.AddWithValue("@extend", rtc.extend);
                    cmd.Parameters.AddWithValue("@updby", Function.GetTextOrNull(rtc.updby));
                    cmd.Parameters.AddWithValue("@upddate", rtc.upddate);

                    cmd.ExecuteNonQuery();

                    closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                return true;
            }
            return true;
        }

        public Request GetRequestInfo(string navyid)
        {
            Request req = new Request(); 
            if (openConnection() == true)
            {
                sql = "SELECT * ";
                sql += "";
                sql += " FROM request";
                sql += "";
                sql += "";
                sql += " WHERE navyid = @navyid";
                sql += "";
                sql += "";

                using(MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@navyid", navyid);
                    
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            req = new Request(dr);
                        }
                    }
                }

                closeConnection();

            }
            return req;            
        }
        

        #endregion

        #region Update data

        public TableMember GetSelectedMember(string navyid)
        {
            TableMember tableMember = new TableMember();

            if (openConnection() == true)
            {
                sql = "SELECT m.*, p.regdate ";
                sql += " ";
                sql += " ";
                sql += " FROM member m LEFT OUTER JOIN person p ON ( m.id = p.navyid ) ";
                sql += " ";
                sql += " ";
                sql += " ";
                sql += "WHERE m.id = @navyid ";
             

                using(MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@navyid", navyid);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            tableMember = new TableMember(dr);
                        }
                    }
                }

                closeConnection();

                return tableMember;
            }
            return null;
        }

        public DataTable GetSelectedTransDetail(string navyid)
        {
            DataTable dtTransDetail = new DataTable();
            if (openConnection() == true)
            {
                sql = "SELECT td.NavyID, st.STATUSCODE, st.title, td.START_DATE, td.end_date, td.inyear, td.inmonth, td.inday";
                sql += "";
                sql += "";
                sql += " FROM trans_detail td ";
                sql += " INNER JOIN statustab st ON td.TRANS_TYPE = left(st.statuscode,1) AND td.CODE1 = right(st.statuscode,1)";
                sql += "";
                sql += " WHERE td.navyid = @navyid";
                sql += " ORDER BY td.TRANS_NO DESC";
                sql += "";
                sql += "";

                using(MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@navyid", navyid);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.HasRows)
                            dtTransDetail.Load(dr);
                    }
                }

                closeConnection();
            }
            return dtTransDetail;
        }

        public bool UpdateSelectedMember(TableMember member)
        {
            if (openConnection())
            {
                sql = "UPDATE member m";
                sql += " SET yearin = @yearin, id8 = @id8, name = @name, sname = @sname";
                sql += ", membercode = @membercode, membercode5 = @membercode5, link = @link";
                sql += ", groupid = @groupid, typeid = @typeid";
                sql += ", start = @start";
                sql += ", doccode = @doccode, extend = @extend, estdate = @estdate";
                sql += ", updby = @updby, upddate = @upddate";
                sql += ", tel1 = @tel1, tel2 = @tel2";
                sql += ", accountnum = @accnum";
                sql += "";
                sql += " WHERE m.id = @navyid ; ";
                
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@navyid", Function.GetTextOrNull(member.navyid));
                    cmd.Parameters.AddWithValue("@yearin", Function.GetTextOrNull(member.yearin));
                    cmd.Parameters.AddWithValue("@id8", Function.GetTextOrNull(member.id8));
                    cmd.Parameters.AddWithValue("@name", Function.GetTextOrNull(member.name));
                    cmd.Parameters.AddWithValue("@sname", Function.GetTextOrNull(member.sname));
                    cmd.Parameters.AddWithValue("@membercode", Function.GetTextOrNull(member.membercode));
                    cmd.Parameters.AddWithValue("@membercode5", Function.GetTextOrNull(member.membercode5));
                    cmd.Parameters.AddWithValue("@link", Function.GetTextOrNull(member.link));
                    cmd.Parameters.AddWithValue("@groupid", Function.GetTextOrNull(member.groupid));
                    cmd.Parameters.AddWithValue("@typeid", Function.GetTextOrNull(member.typeid));
                    cmd.Parameters.AddWithValue("@start", member.start);
                    cmd.Parameters.AddWithValue("@doccode", Function.GetTextOrNull(member.doccode));
                    cmd.Parameters.AddWithValue("@extend", member.extend);
                    cmd.Parameters.AddWithValue("@estdate", member.estdate);
                    cmd.Parameters.AddWithValue("@updby", Function.GetTextOrNull(member.updby));
                    cmd.Parameters.AddWithValue("@upddate", member.upddate);
                    cmd.Parameters.AddWithValue("@tel1", Function.GetTextOrNull(member.tel1));
                    cmd.Parameters.AddWithValue("@tel2", Function.GetTextOrNull(member.tel2));
                    cmd.Parameters.AddWithValue("@accnum", Function.GetTextOrNull(member.accountnum));

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }

                closeConnection();
            }
            return true;

            //if (openConnection())
            //{
            //    sql = "UPDATE member m";
            //    sql += " SET yearin = @yearin, id8 = @id8, name = @name, sname = @sname";
            //    sql += ", membercode = @membercode, membercode5 = @membercode5, link = @link";
            //    sql += ", groupid = @groupid, typeid = @typeid";
            //    sql += ", start = @start";
            //    sql += ", doccode = @doccode, extend = @extend, estdate = @estdate";
            //    sql += ", updby = @updby, upddate = @upddate, end = @end";
            //    sql += ", refdoc = @refdoc, refdocdate = @refdocdate";
            //    sql += ", tel1 = @tel1, tel2 = @tel2";
            //    sql += "";
            //    sql += " WHERE m.id = @navyid";

            //    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@navyid", Function.GetTextOrNull(member.navyid));
            //        cmd.Parameters.AddWithValue("@yearin", Function.GetTextOrNull(member.yearin));
            //        cmd.Parameters.AddWithValue("@id8", Function.GetTextOrNull(member.id8));
            //        cmd.Parameters.AddWithValue("@name", Function.GetTextOrNull(member.name));
            //        cmd.Parameters.AddWithValue("@sname", Function.GetTextOrNull(member.sname));
            //        cmd.Parameters.AddWithValue("@membercode", Function.GetTextOrNull(member.membercode));
            //        cmd.Parameters.AddWithValue("@membercode5", Function.GetTextOrNull(member.membercode5));
            //        cmd.Parameters.AddWithValue("@link", Function.GetTextOrNull(member.link));
            //        cmd.Parameters.AddWithValue("@groupid", Function.GetTextOrNull(member.groupid));
            //        cmd.Parameters.AddWithValue("@typeid", Function.GetTextOrNull(member.typeid));
            //        cmd.Parameters.AddWithValue("@start", member.start);
            //        cmd.Parameters.AddWithValue("@doccode", Function.GetTextOrNull(member.doccode));
            //        cmd.Parameters.AddWithValue("@extend", member.extend);
            //        cmd.Parameters.AddWithValue("@estdate", member.estdate);
            //        cmd.Parameters.AddWithValue("@updby", Function.GetTextOrNull(member.updby));
            //        cmd.Parameters.AddWithValue("@upddate", member.upddate);
            //        cmd.Parameters.AddWithValue("@tel1", Function.GetTextOrNull(member.tel1));
            //        cmd.Parameters.AddWithValue("@tel2", Function.GetTextOrNull(member.tel2));

            //        if (member.estdate == member.end)
            //        {
            //            cmd.Parameters.AddWithValue("@end", member.end);
            //            cmd.Parameters.AddWithValue("@refdoc", member.refdoc);
            //            cmd.Parameters.AddWithValue("@refdocdate", member.refdocdate);
            //        }
            //        else
            //        {
            //            cmd.Parameters.AddWithValue("@end", DBNull.Value);
            //            cmd.Parameters.AddWithValue("@refdoc", DBNull.Value);
            //            cmd.Parameters.AddWithValue("@refdocdate", DBNull.Value);
            //        }

            //        if (cmd.ExecuteNonQuery() > 0)
            //        {
            //            return true;
            //        }
            //    }

            //    closeConnection();
            //}


            //return true;
        }

        #endregion

        #region Discharge

        public bool UpdateMemberDischarge(TableMember member)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sql = "UPDATE member m";
                        sql += " SET estdate = @estdate, end = @end";
                        sql += ", dischargetype = @dischargetype";
                        sql += ", refdoc = @refdoc, refdocdate = @refdocdate";
                        sql += ", updby = @updby, upddate = @upddate";
                        sql += "";
                        sql += " WHERE m.id = @navyid";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            if (member.dischargetype == string.Empty)
                            {
                                cmd.Parameters.AddWithValue("@navyid", Function.GetTextOrNull(member.navyid));
                                cmd.Parameters.AddWithValue("@estdate", member.estdate);
                                cmd.Parameters.AddWithValue("@end", DBNull.Value);
                                cmd.Parameters.AddWithValue("@dischargetype", DBNull.Value);
                                cmd.Parameters.AddWithValue("@refdoc", DBNull.Value);
                                cmd.Parameters.AddWithValue("@refdocdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@updby", Function.GetTextOrNull(member.updby));
                                cmd.Parameters.AddWithValue("@upddate", member.upddate);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@navyid", Function.GetTextOrNull(member.navyid));
                                cmd.Parameters.AddWithValue("@estdate", member.estdate);
                                cmd.Parameters.AddWithValue("@end", member.end);
                                cmd.Parameters.AddWithValue("@dischargetype", member.dischargetype);
                                cmd.Parameters.AddWithValue("@refdoc", member.refdoc);
                                cmd.Parameters.AddWithValue("@refdocdate", member.refdocdate);
                                cmd.Parameters.AddWithValue("@updby", Function.GetTextOrNull(member.updby));
                                cmd.Parameters.AddWithValue("@upddate", member.upddate);
                            }

                            cmd.ExecuteNonQuery();
                        }

                        sql = "UPDATE person";
                        sql += " SET statuscode = @statuscode";
                        sql += " WHERE navyid = @navyid";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@statuscode", member.dischargetype);
                            cmd.Parameters.AddWithValue("@navyid", Function.GetTextOrNull(member.navyid));
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        closeConnection();
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                closeConnection();
                return true;
            }
            return false;
        }

        public bool CancelMemberDischarge(string navyid, string statuscode)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //Update Table Member
                        sql = "UPDATE member";
                        sql += " SET end = null, refdoc = null, refdocdate = null, dischargetype = null";
                        sql += "";
                        sql += " WHERE id = @navyid";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@navyid", navyid);

                            cmd.ExecuteNonQuery();
                        }


                        //Update Table Person
                        sql = "UPDATE person";
                        sql += " SET statuscode = @statuscode";
                        sql += " WHERE navyid = @navyid";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@statuscode", statuscode);
                            cmd.Parameters.AddWithValue("@navyid", navyid);

                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        closeConnection();
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }

                closeConnection();
                return true;
            }
            return false;
        }

        public List<RTCDischarge> UpdateDischargeFromTextFile(List<RTCDischarge> rtcDischarge)
        {
            List<RTCDischarge> result = new List<RTCDischarge>();

            if(openConnection())
            {
                sql = "Update member";
                sql += " SET end = @end ";
                sql += " WHERE id = @navyid";

                foreach (RTCDischarge row in rtcDischarge)
                {
                    using(MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@end", row.end);
                        cmd.Parameters.AddWithValue("@navyid", row.navyid);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            row.CheckSuccess(true);
                        }
                        else
                        {
                            row.CheckSuccess(false);
                        }
                    }
                    result.Add(row);
                }
                closeConnection();
            }
            return result;
        }

        public List<RTCDischarge> CompareData(DataTable dt)
        {
            List<RTCDischarge> result = new List<RTCDischarge>();

            if (openConnection())
            {
                sql = "SELECT name, sname, end";
                sql += " FROM member ";
                sql += " WHERE id = @navyid limit 1";

                foreach (DataRow file in dt.Rows)
                {
                    RTCDischarge newLine = new RTCDischarge();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@navyid", file["navyid"].ToString());

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            result.Add(new RTCDischarge(reader, file));
                        }
                    }
                }

                closeConnection();
            }
            return result;
        }

        #endregion
        
        #region MemberCodeHistory

        public List<MemberCodeHistory> ListMemberCodeHistory(string navyid)
        {
            List<MemberCodeHistory> listMemberCodeHistory = new List<MemberCodeHistory>();

            if (openConnection() == true)
            {
                sql = "SELECT * FROM membercodehistory";
                sql += " WHERE navyid = @navyid";
                sql += " ORDER BY id ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@navyid", navyid);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            listMemberCodeHistory.Add(new MemberCodeHistory(reader));
                        }
                    }
                }
                closeConnection();
            }

            return listMemberCodeHistory;

        }


        public bool ChangeMemberCode(Parameters.ChangeMemberCode param)
        {
            List<MemberCodeHistory> listHistory = new List<MemberCodeHistory>();
            TableMember member = new TableMember();

            listHistory = this.ListMemberCodeHistory(param.navyid);
            member = this.GetSelectedMember(param.navyid);

            if (openConnection() == true)
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //Insert Into membercodehistory
                        sql = "INSERT INTO membercodehistory";
                        sql += " ( navyid, membercode, membercode5, link, date_start, date_end, updated_by, updated_time )";
                        sql += " VALUES";
                        sql += " ( @navyid, @membercode, @membercode5, @link, @date_start, @date_end, 'admin', now()); ";
                        sql += "";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@navyid", Function.GetTextOrNull(member.navyid));
                            cmd.Parameters.AddWithValue("@membercode", Function.GetTextOrNull(member.membercode));
                            cmd.Parameters.AddWithValue("@membercode5", Function.GetTextOrNull(member.membercode5));
                            cmd.Parameters.AddWithValue("@link", Function.GetTextOrNull(member.link));

                            if (listHistory.Count > 0)
                            {
                                cmd.Parameters.AddWithValue("@date_start", listHistory[listHistory.Count-1].date_end.AddDays(1));
                                cmd.Parameters.AddWithValue("@date_end", param.date_start.AddDays(-1));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@date_start", member.start);
                                cmd.Parameters.AddWithValue("@date_end", param.date_start.AddDays(-1));
                            }
                            cmd.ExecuteNonQuery();
                        }

                        //Update MemberCode on table MEMBER
                        sql = "UPDATE member";
                        sql += " SET membercode = @membercode, membercode5 = @membercode5, link = @link";
                        sql += " WHERE id = @navyid;";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@navyid", Function.GetTextOrNull(param.navyid));
                            cmd.Parameters.AddWithValue("@membercode", Function.GetTextOrNull(param.membercode));
                            cmd.Parameters.AddWithValue("@membercode5", Function.GetTextOrNull(param.membercode5));
                            cmd.Parameters.AddWithValue("@link", Function.GetTextOrNull(param.link));

                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        closeConnection();
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                closeConnection();
            }
                
            return true;
        }

        public bool DeleteHistory(string id)
        {
            bool isSuccess = false ;

            if ( openConnection() == true)
            {
                sql = "DELETE FROM membercodehistory";
                sql += " WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    if (cmd.ExecuteNonQuery() > 0)
                        isSuccess = true;
                    else
                        isSuccess = false;
                }

                closeConnection();
            }
            return isSuccess;
        }

        #endregion

        #region Request Person
        public PersonRequest GetPersonRequestDetail(string navyid)
        {
            PersonRequest personReq = new PersonRequest();
            if (openConnection())
            {
                sql = "SELECT p.* \n";
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
                sql += "WHERE p.NAVYID = @navyid ";

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@navyid", navyid);

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
                    MessageBox.Show(ex.Message);
                }
                closeConnection();
            }
            return personReq;
        }

        public bool UpdatePersonRequest(PersonRequest personReq,Parameters.PersonRequest param)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //sql = "IF (SELECT 1 = 1 FROM request WHERE navyid = @navyid) THEN\n" +
                        //    "BEGIN\n" +
                        //    "	UPDATE request r\n" +
                        //    "	SET r.UNIT = @unit, r.ASKBY = @askby, r.NUM = @num, r.REMARK = @remark, r.REMARK2 = @remark2\n" +
                        //    "	,r.FLAG = @flag, r.UPDDATE = @upddate ,r.piority = @piority, r.UPDBY = @username, r.UPDTIME = @updtime, r.UPDATECOUNT = @updatecount\n" +
                        //    "	WHERE r.NAVYID = @navyid;\n" +
                        //    "	\n" +
                        //    "	UPDATE person p\n" +
                        //    "	SET p.UNIT0 = @unit, p.UNIT3 = @unit, p.ASK = @askby, p.NUMBER = @num, p.REM = @remark, p.REM2 = @remark2\n" +
                        //    "	WHERE p.NAVYID = @navyid;	\n" +
                        //    "END\n" +
                        //    "ELSE\n" +
                        //    "BEGIN\n" +
                        //    "	INSERT request (YEARIN,NAVYID,`NAME`,SNAME,UNIT,ASKBY,NUM,REMARK,REMARK2,FLAG,UPDDATE,piority,UPDBY,UPDTIME,UPDATECOUNT)\n" +
                        //    "	VALUES (@yearin,@navyid,@name_,@sname,@unit,@askby,@num,@remark,@remark2,@flag,@upddate,@piority,@username,@updtime,@updatecount);\n" +
                        //    "	UPDATE person p\n" +
                        //    "	SET p.UNIT0 = @unit, p.UNIT3 = @unit, p.ASK = @askby, p.NUMBER = @num, p.REM = @remark, p.REM2 = @remark2\n" +
                        //    "	WHERE p.NAVYID = @navyid;\n" +
                        //    "END\n" +
                        //    "END IF;";
                        
                        if (personReq.request.navyid == "")
                        {
                            // New Record
                            sql = ""+
                            "	INSERT request (YEARIN,NAVYID,ID8,`NAME`,SNAME,UNIT,ASKBY,NUM,REMARK,REMARK2,FLAG,UPDDATE,piority,UPDBY,UPDTIME,UPDATECOUNT)\n" +
                            "	VALUES ('" + personReq.person.yearin + "','" + param.navyid + "','" + (personReq.person.id8) + "','" + (personReq.person.name) + "','" + (personReq.person.sname) + "','" + (param.unit) + "','" + (param.askby) + "','" + (param.num) + "','" + (param.remark) + "','" + (param.remark2) + "','" + (param.flag) + "','" + param.upddate.Date.ToString("yyyy-MM-dd") + "','" + (param.piority) + "','" + (param.username) + "','" + param.upddate.ToString("HH:mm:ss") + "',0);\n" +
                            "	UPDATE person p\n" +
                            "	SET p.UNIT0 = '" + (param.unit) + "', p.UNIT3 = '" + (param.unit) + "', p.ASK = '" + (param.askby) + "', p.NUMBER = '" + (param.num) + "', p.REM = '" + (param.remark) + "', p.REM2 = '" + (param.remark2) + "'\n" +
                            "	WHERE p.NAVYID = '" + (param.navyid) + "';\n";
                        }
                        else
                        {
                            // Edit Record
                            sql = "	UPDATE request r\n" +
                            "	SET r.UNIT = '" + (param.unit) + "', r.ASKBY = '" + (param.askby) + "', r.NUM = '" + (param.num) + "', r.REMARK = '" + (param.remark) + "', r.REMARK2 = '" + (param.remark2) + "'\n" +
                            "	,r.FLAG = '" + (param.flag) + "', r.UPDDATE = '" + param.upddate.Date.ToString("yyyy-MM-dd") + "' ,r.piority = '" + (param.piority) + "', r.UPDBY = '" + (param.username) + "', r.UPDTIME = '" + param.upddate.ToString("HH:mm:ss") + "', r.UPDATECOUNT = '" + Convert.ToString(param.updatecount + 1) + "'\n" +
                            "	WHERE r.NAVYID = '" + (param.navyid) + "';\n" +
                            "	\n" +
                            "	UPDATE person p\n" +
                            "	SET p.UNIT0 = '" + (param.unit) + "', p.UNIT3 = '" + (param.unit) + "', p.ASK = '" + (param.askby) + "', p.NUMBER = '" + (param.num) + "', p.REM = '" + (param.remark) + "', p.REM2 = '" + (param.remark2) + "'\n" +
                            "	WHERE p.NAVYID = '" + (param.navyid) + "';\n";
                        }


                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            //cmd.Parameters.AddWithValue("@yearin", (personReq.person.yearin));
                            //cmd.Parameters.AddWithValue("@name_", (personReq.person.name));
                            //cmd.Parameters.AddWithValue("@sname", (personReq.person.sname));                            

                            //cmd.Parameters.AddWithValue("@navyid", (param.navyid));
                            //cmd.Parameters.AddWithValue("@unit", (param.unit));
                            //cmd.Parameters.AddWithValue("@askby", (param.askby));
                            //cmd.Parameters.AddWithValue("@num", (param.num));
                            //cmd.Parameters.AddWithValue("@remark", (param.remark));
                            //cmd.Parameters.AddWithValue("@remark2", (param.remark2));
                            //cmd.Parameters.AddWithValue("@flag", (param.flag));
                            //cmd.Parameters.AddWithValue("@upddate", param.upddate.Date);
                            //cmd.Parameters.AddWithValue("@piority", (param.piority));
                            //cmd.Parameters.AddWithValue("@username", (param.username));
                            //cmd.Parameters.AddWithValue("@updtime", param.upddate.Time);
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        closeConnection();
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                closeConnection();
            }
            return true;
        }

        public bool DeletePersonRequest(PersonRequest personReq)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sql = "DELETE FROM request WHERE navyid = '" + (personReq.person.navyid) + "'; \n";
                        sql += "UPDATE person p\n" +
                                "SET p.UNIT0 = NULL, p.UNIT3 = NULL, p.ASK = NULL, p.NUMBER = NULL, p.REM = NULL, p.REM2 = NULL \n" +
                                "WHERE p.NAVYID = '" + (personReq.person.navyid) + "'; \n";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        closeConnection();
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                closeConnection();
            }
            return true;
        }

        public bool UpdatePersonUnit3(string pNavyId, string unit3)
        {
            if (openConnection())
            {
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Edit Record
                        sql = "UPDATE person p SET p.UNIT3 = '" + (unit3) + "' WHERE p.NAVYID = '" + (pNavyId) + "';\n";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        closeConnection();
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                closeConnection();
            }
            return true;
        }
        #endregion
    }
}
