using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CentaLine.Common;
using CentaLine.DataCommon;
using CentaDbRaw.Web.Models;

namespace CentaDbRaw.Web.Services
{
    public class BuildService
    {
        private string _classMsg =
            "Class: BuildDbService; NameSpace: CentaDbRaw.Web.Services; Source File: BuildService.cs";

        public List<CentaBuildType> GetList(int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: GetList(int pageIndex,int pageSize, out int recordCount)" + FileUtility.NewLine +
                            _classMsg;
            var dbService = new BuildDbService();
            DataTable table = dbService.GetDataTable(pageIndex, pageSize, out recordCount);
            if (table != null && table.Rows.Count > 0)
            {
                List<CentaBuildType> rs = (from DataRow row in table.Rows select new CentaBuildType(row)).ToList();
                return rs;
            }
            return new List<CentaBuildType>();
        }

        public int AddNew(CentaBuildType model)
        {
            string funMsg = "function: AddNew(CentaBuildType model)" + FileUtility.NewLine + _classMsg;
            var dbService = new BuildDbService();
            return dbService.AddNew(model);
        }

        public bool Update(CentaBuildType model)
        {
            string funMsg = "function: Update(CentaBuildType model)" + FileUtility.NewLine + _classMsg;
            var dbService = new BuildDbService();
            return dbService.Update(model);
        }

        public bool Delete(int buildId)
        {
            string funMsg = "function: Delete(int buildId)" + FileUtility.NewLine + _classMsg;
            var dbService = new BuildDbService();
            return dbService.Delete(buildId);
        }

        public List<CentaBuildType> Filter(CentaBuildType model, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: Filter(CentaBuildType model,int pageIndex,int pageSize, out int recordCount)" +
                            FileUtility.NewLine +
                            _classMsg;
            var dbService = new BuildDbService();
            DataTable table = dbService.GetDataTable(model, pageIndex, pageSize, out recordCount);
            if (table != null && table.Rows.Count > 0)
            {
                List<CentaBuildType> rs = (from DataRow row in table.Rows select new CentaBuildType(row)).ToList();
                return rs;
            }
            return new List<CentaBuildType>();
        }

        public class BuildDbService
        {
            private string _classMsg =
                "Class: BuildDbService; NameSpace: CentaDbRaw.Web.Services; Source File: BuildService.cs";

            #region  Method

            public DataRow GetDataRow(int buildId)
            {
                string funMsg = "function: GetDataRow(int buildId)" + FileUtility.NewLine + _classMsg;
                var strSql = new StringBuilder();
                strSql.Append(
                    "select CentaBuildId,centaest,cestcode,centabldg,cblgcode,lpt_x,lpt_y,usage,c_estate,e_estate,c_phase,e_phase,c_property,e_property,pc_addr1,pc_addr2,pe_addr,opdate,unit_cnt,x_cnt,y_cnt,scp_id,scp_c,scp_e,scp_mkt,nmark,o_estateid,o_bldgid,estateid,buildingid,address,moddate,pc_street1,pc_street2,pe_street1,pe_street2,pc_stno1,pc_stno2,ppt_rank,org_cenblg,org_cenest,need_clear,x_axis,x_axis2,y_axis,y_axis2,cblk_key ");
                strSql.Append(" FROM [centabldg] ");
                strSql.Append(" where CentaBuildId=@buildId ");
                SqlParameter[] parameters = {
                                                new SqlParameter("@buildId", SqlDbType.Int, 4)
                                            };
                parameters[0].Value = buildId;
                return DbUtility.GetDataRow(strSql.ToString(), AppSettings.DbConn, parameters);
            }

            public DataTable GetDataTable(CentaBuildType model, int pageIndex, int pageSize, out int recordCount)
            {
                string funMsg =
                    "function: GetDataTable(CentaBuildType model,int pageIndex, int pageSize, out int recordCount)" +
                    FileUtility.NewLine + _classMsg;
                var param = new StringBuilder();

                if (!string.IsNullOrEmpty(model.centaest))
                {
                    param.AppendFormat("centaest like '%{0}%'", model.centaest);
                }

                if (!string.IsNullOrEmpty(model.cestcode))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("cestcode like '%{0}%'", model.cestcode);
                }
                if (!string.IsNullOrEmpty(model.centabldg))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("centabldg like '%{0}%'", model.centabldg);
                }
                if (!string.IsNullOrEmpty(model.cblgcode))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("cblgcode like '%{0}%'", model.cblgcode);
                }
                if (model.lpt_x > 0)
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("lpt_x={0}", model.lpt_x);
                }
                if (model.lpt_y > 0)
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("lpt_y={0}", model.lpt_y);
                }
                if (!string.IsNullOrEmpty(model.usage))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("usage like '%{0}%'", model.usage);
                }
                if (!string.IsNullOrEmpty(model.c_estate))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("c_estate like '%{0}%'", model.c_estate);
                }
                if (!string.IsNullOrEmpty(model.e_estate))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("e_estate like '%{0}%'", model.e_estate);
                }
                if (!string.IsNullOrEmpty(model.c_phase))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("c_phase like '%{0}%'", model.c_phase);
                }
                if (!string.IsNullOrEmpty(model.e_phase))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("e_phase like '%{0}%'", model.e_phase);
                }
                if (!string.IsNullOrEmpty(model.c_property))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("c_property like '%{0}%'", model.c_property);
                }
                if (!string.IsNullOrEmpty(model.pc_addr1))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("pc_addr1 like '%{0}%'", model.pc_addr1);
                }
                if (!string.IsNullOrEmpty(model.pc_addr2))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("pc_addr2 like '%{0}%'", model.centaest);
                }
                if (!string.IsNullOrEmpty(model.pe_addr))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("pe_addr like '%{0}%'", model.pe_addr);
                }
                if (!string.IsNullOrEmpty(model.opdate))
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("opdate ='{0}'", model.opdate);
                }
                if (model.unit_cnt > 0)
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("unit_cnt={0}", model.unit_cnt);
                }
                if (model.x_cnt > 0)
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("x_cnt={0}", model.x_cnt);
                }
                if (model.y_cnt > 0)
                {
                    if (param.Length > 0)
                    {
                        param.Append(" and ");
                    }
                    param.AppendFormat("y_cnt={0}", model.y_cnt);
                }

                var strSql = new StringBuilder();
                strSql.Append("select count(1) from [centabldg]");
                if (param.Length > 0)
                {
                    strSql.AppendFormat(" where {0}", param.ToString());
                }

                recordCount = DbUtility.ExecuteScalar<int>(strSql.ToString(), AppSettings.DbConn);
                strSql.Clear();
                if (param.Length > 0)
                {
                    strSql.AppendFormat("select top {0} * from [centabldg]", pageSize);
                    if (pageIndex > 1)
                    {
                        strSql.AppendFormat(
                            " where CentaBuildId not in (select top {0} CentaBuildId from [centabldg] where {1}) and {1}",
                            (pageIndex - 1)*pageSize, param.ToString());

                    }
                    else
                    {
                        strSql.AppendFormat(" where {0}", param.ToString());
                    }
                }
                else
                {
                    strSql.AppendFormat("select top {0} * from [centabldg]", pageSize);
                    if (pageIndex > 1)
                    {
                        strSql.AppendFormat(" where CentaBuildId not in (select top {0} CentaBuildId from [centabldg])",
                                            (pageIndex - 1)*pageSize);

                    }
                }
                return DbUtility.GetDataTable(strSql.ToString(), AppSettings.DbConn);
            }

            public DataTable GetDataTable(int pageIndex, int pageSize, out int recordCount)
            {
                string funMsg = "function: GetDataTable(int pageIndex, int pageSize, out int recordCount)" +
                                FileUtility.NewLine + _classMsg;

                var strSql = new StringBuilder();
                strSql.Append("select count(1) from [centabldg]");
                recordCount = DbUtility.ExecuteScalar<int>(strSql.ToString(), AppSettings.DbConn);
                strSql.Clear();
                strSql.AppendFormat("select top {0} * from [centabldg]", pageSize);
                if (pageIndex > 1)
                {
                    strSql.AppendFormat(" where CentaBuildId not in (select top {0} CentaBuildId from [centabldg])",
                                        (pageIndex - 1)*pageSize);

                }
                return DbUtility.GetDataTable(strSql.ToString(), AppSettings.DbConn);
            }

            /// <summary>
            /// 增加一条数据
            /// </summary>
            public int AddNew(CentaBuildType model)
            {
                var strSql = new StringBuilder();
                strSql.Append("insert into [centabldg] (");
                strSql.Append(
                    "centaest,cestcode,centabldg,cblgcode,lpt_x,lpt_y,usage,c_estate,e_estate,c_phase,e_phase,c_property,e_property,pc_addr1,pc_addr2,pe_addr,opdate,unit_cnt,x_cnt,y_cnt,scp_id,scp_c,scp_e,scp_mkt,nmark,o_estateid,o_bldgid,estateid,buildingid,address,moddate,pc_street1,pc_street2,pe_street1,pe_street2,pc_stno1,pc_stno2,ppt_rank,org_cenblg,org_cenest,need_clear,x_axis,x_axis2,y_axis,y_axis2,cblk_key)");
                strSql.Append(" values (");
                strSql.Append(
                    "@centaest,@cestcode,@centabldg,@cblgcode,@lpt_x,@lpt_y,@usage,@c_estate,@e_estate,@c_phase,@e_phase,@c_property,@e_property,@pc_addr1,@pc_addr2,@pe_addr,@opdate,@unit_cnt,@x_cnt,@y_cnt,@scp_id,@scp_c,@scp_e,@scp_mkt,@nmark,@o_estateid,@o_bldgid,@estateid,@buildingid,@address,@moddate,@pc_street1,@pc_street2,@pe_street1,@pe_street2,@pc_stno1,@pc_stno2,@ppt_rank,@org_cenblg,@org_cenest,@need_clear,@x_axis,@x_axis2,@y_axis,@y_axis2,@cblk_key)");
                strSql.Append(";select max(CentaBuildId) as id from [centabldg]");
                SqlParameter[] parameters = {
                                                new SqlParameter("@centaest", SqlDbType.Char, 10),
                                                new SqlParameter("@cestcode", SqlDbType.Char, 10),
                                                new SqlParameter("@centabldg", SqlDbType.Char, 10),
                                                new SqlParameter("@cblgcode", SqlDbType.Char, 10),
                                                new SqlParameter("@lpt_x", SqlDbType.Decimal, 9),
                                                new SqlParameter("@lpt_y", SqlDbType.Decimal, 9),
                                                new SqlParameter("@usage", SqlDbType.Char, 2),
                                                new SqlParameter("@c_estate", SqlDbType.Char, 60),
                                                new SqlParameter("@e_estate", SqlDbType.Char, 60),
                                                new SqlParameter("@c_phase", SqlDbType.Char, 60),
                                                new SqlParameter("@e_phase", SqlDbType.Char, 60),
                                                new SqlParameter("@c_property", SqlDbType.Char, 50),
                                                new SqlParameter("@e_property", SqlDbType.Char, 60),
                                                new SqlParameter("@pc_addr1", SqlDbType.Char, 200),
                                                new SqlParameter("@pc_addr2", SqlDbType.Char, 100),
                                                new SqlParameter("@pe_addr", SqlDbType.Char, 100),
                                                new SqlParameter("@opdate", SqlDbType.DateTime),
                                                new SqlParameter("@unit_cnt", SqlDbType.Decimal, 9),
                                                new SqlParameter("@x_cnt", SqlDbType.Decimal, 9),
                                                new SqlParameter("@y_cnt", SqlDbType.Decimal, 9),
                                                new SqlParameter("@scp_id", SqlDbType.Char, 3),
                                                new SqlParameter("@scp_c", SqlDbType.Char, 30),
                                                new SqlParameter("@scp_e", SqlDbType.Char, 50),
                                                new SqlParameter("@scp_mkt", SqlDbType.Char, 1),
                                                new SqlParameter("@nmark", SqlDbType.Int, 4),
                                                new SqlParameter("@o_estateid", SqlDbType.Char, 50),
                                                new SqlParameter("@o_bldgid", SqlDbType.Char, 50),
                                                new SqlParameter("@estateid", SqlDbType.Char, 50),
                                                new SqlParameter("@buildingid", SqlDbType.Char, 50),
                                                new SqlParameter("@address", SqlDbType.Char, 50),
                                                new SqlParameter("@moddate", SqlDbType.DateTime),
                                                new SqlParameter("@pc_street1", SqlDbType.Char, 100),
                                                new SqlParameter("@pc_street2", SqlDbType.Char, 100),
                                                new SqlParameter("@pe_street1", SqlDbType.Char, 100),
                                                new SqlParameter("@pe_street2", SqlDbType.Char, 100),
                                                new SqlParameter("@pc_stno1", SqlDbType.Char, 20),
                                                new SqlParameter("@pc_stno2", SqlDbType.Char, 20),
                                                new SqlParameter("@ppt_rank", SqlDbType.Int, 4),
                                                new SqlParameter("@org_cenblg", SqlDbType.Char, 10),
                                                new SqlParameter("@org_cenest", SqlDbType.Char, 10),
                                                new SqlParameter("@need_clear", SqlDbType.Char, 1),
                                                new SqlParameter("@x_axis", SqlDbType.Char, 250),
                                                new SqlParameter("@x_axis2", SqlDbType.Char, 250),
                                                new SqlParameter("@y_axis", SqlDbType.Char, 250),
                                                new SqlParameter("@y_axis2", SqlDbType.Char, 250),
                                                new SqlParameter("@cblk_key", SqlDbType.Char, 250)
                                            };
                parameters[0].Value = ConvertUtility.Trim(model.centaest);
                parameters[1].Value = ConvertUtility.Trim(model.cestcode);
                parameters[2].Value = ConvertUtility.Trim(model.centabldg);
                parameters[3].Value = ConvertUtility.Trim(model.cblgcode);
                parameters[4].Value = ConvertUtility.ToDecimal(model.lpt_x);
                parameters[5].Value = ConvertUtility.ToDecimal(model.lpt_y);
                parameters[6].Value = ConvertUtility.Trim(model.usage);
                parameters[7].Value = ConvertUtility.Trim(model.c_estate);
                parameters[8].Value = ConvertUtility.Trim(model.e_estate);
                parameters[9].Value = ConvertUtility.Trim(model.c_phase);
                parameters[10].Value = ConvertUtility.Trim(model.e_phase);
                parameters[11].Value = ConvertUtility.Trim(model.c_property);
                parameters[12].Value = ConvertUtility.Trim(model.e_property);
                parameters[13].Value = ConvertUtility.Trim(model.pc_addr1);
                parameters[14].Value = ConvertUtility.Trim(model.pc_addr2);
                parameters[15].Value = ConvertUtility.Trim(model.pe_addr);
                parameters[16].Value = ConvertUtility.ToDateTime(model.opdate);
                parameters[17].Value = ConvertUtility.ToDecimal(model.unit_cnt);
                parameters[18].Value = ConvertUtility.ToDecimal(model.x_cnt);
                parameters[19].Value = ConvertUtility.ToDecimal(model.y_cnt);
                parameters[20].Value = ConvertUtility.Trim(model.scp_id);
                parameters[21].Value = ConvertUtility.Trim(model.scp_c);
                parameters[22].Value = ConvertUtility.Trim(model.scp_e);
                parameters[23].Value = ConvertUtility.Trim(model.scp_mkt);
                parameters[24].Value = ConvertUtility.ToInt(model.nmark);
                parameters[25].Value = ConvertUtility.Trim(model.o_estateid);
                parameters[26].Value = ConvertUtility.Trim(model.o_bldgid);
                parameters[27].Value = ConvertUtility.Trim(model.estateid);
                parameters[28].Value = ConvertUtility.Trim(model.buildingid);
                parameters[29].Value = ConvertUtility.Trim(model.address);
                parameters[30].Value = ConvertUtility.ToDateTime(model.moddate);
                parameters[31].Value = ConvertUtility.Trim(model.pc_street1);
                parameters[32].Value = ConvertUtility.Trim(model.pc_street2);
                parameters[33].Value = ConvertUtility.Trim(model.pe_street1);
                parameters[34].Value = ConvertUtility.Trim(model.pe_street2);
                parameters[35].Value = ConvertUtility.Trim(model.pc_stno1);
                parameters[36].Value = ConvertUtility.Trim(model.pc_stno2);
                parameters[37].Value = ConvertUtility.ToInt(model.ppt_rank);
                parameters[38].Value = ConvertUtility.Trim(model.org_cenblg);
                parameters[39].Value = ConvertUtility.Trim(model.org_cenest);
                parameters[40].Value = ConvertUtility.Trim(model.need_clear);
                parameters[41].Value = ConvertUtility.Trim(model.x_axis);
                parameters[42].Value = ConvertUtility.Trim(model.x_axis2);
                parameters[43].Value = ConvertUtility.Trim(model.y_axis);
                parameters[44].Value = ConvertUtility.Trim(model.y_axis2);
                parameters[45].Value = ConvertUtility.Trim(model.cblk_key);

                return DbUtility.ExecuteScalar<int>(strSql.ToString(), AppSettings.DbConn, parameters);
            }

            /// <summary>
            /// 更新一条数据
            /// </summary>
            public bool Update(CentaBuildType model)
            {
                var strSql = new StringBuilder();
                strSql.Append("update [centabldg] set ");
                strSql.Append("centaest=@centaest,");
                strSql.Append("cestcode=@cestcode,");
                strSql.Append("centabldg=@centabldg,");
                strSql.Append("cblgcode=@cblgcode,");
                strSql.Append("lpt_x=@lpt_x,");
                strSql.Append("lpt_y=@lpt_y,");
                strSql.Append("usage=@usage,");
                strSql.Append("c_estate=@c_estate,");
                strSql.Append("e_estate=@e_estate,");
                strSql.Append("c_phase=@c_phase,");
                strSql.Append("e_phase=@e_phase,");
                strSql.Append("c_property=@c_property,");
                strSql.Append("e_property=@e_property,");
                strSql.Append("pc_addr1=@pc_addr1,");
                strSql.Append("pc_addr2=@pc_addr2,");
                strSql.Append("pe_addr=@pe_addr,");
                strSql.Append("opdate=@opdate,");
                strSql.Append("unit_cnt=@unit_cnt,");
                strSql.Append("x_cnt=@x_cnt,");
                strSql.Append("y_cnt=@y_cnt,");
                strSql.Append("scp_id=@scp_id,");
                strSql.Append("scp_c=@scp_c,");
                strSql.Append("scp_e=@scp_e,");
                strSql.Append("scp_mkt=@scp_mkt,");
                strSql.Append("nmark=@nmark,");
                strSql.Append("o_estateid=@o_estateid,");
                strSql.Append("o_bldgid=@o_bldgid,");
                strSql.Append("estateid=@estateid,");
                strSql.Append("buildingid=@buildingid,");
                strSql.Append("address=@address,");
                strSql.Append("moddate=@moddate,");
                strSql.Append("pc_street1=@pc_street1,");
                strSql.Append("pc_street2=@pc_street2,");
                strSql.Append("pe_street1=@pe_street1,");
                strSql.Append("pe_street2=@pe_street2,");
                strSql.Append("pc_stno1=@pc_stno1,");
                strSql.Append("pc_stno2=@pc_stno2,");
                strSql.Append("ppt_rank=@ppt_rank,");
                strSql.Append("org_cenblg=@org_cenblg,");
                strSql.Append("org_cenest=@org_cenest,");
                strSql.Append("need_clear=@need_clear,");
                strSql.Append("x_axis=@x_axis,");
                strSql.Append("x_axis2=@x_axis2,");
                strSql.Append("y_axis=@y_axis,");
                strSql.Append("y_axis2=@y_axis2,");
                strSql.Append("cblk_key=@cblk_key");
                strSql.Append(" where CentaBuildId=@buildId ");
                SqlParameter[] parameters = {
                                                new SqlParameter("@centaest", SqlDbType.Char, 10),
                                                new SqlParameter("@cestcode", SqlDbType.Char, 10),
                                                new SqlParameter("@centabldg", SqlDbType.Char, 10),
                                                new SqlParameter("@cblgcode", SqlDbType.Char, 10),
                                                new SqlParameter("@lpt_x", SqlDbType.Decimal, 9),
                                                new SqlParameter("@lpt_y", SqlDbType.Decimal, 9),
                                                new SqlParameter("@usage", SqlDbType.Char, 2),
                                                new SqlParameter("@c_estate", SqlDbType.Char, 60),
                                                new SqlParameter("@e_estate", SqlDbType.Char, 60),
                                                new SqlParameter("@c_phase", SqlDbType.Char, 60),
                                                new SqlParameter("@e_phase", SqlDbType.Char, 60),
                                                new SqlParameter("@c_property", SqlDbType.Char, 50),
                                                new SqlParameter("@e_property", SqlDbType.Char, 60),
                                                new SqlParameter("@pc_addr1", SqlDbType.Char, 200),
                                                new SqlParameter("@pc_addr2", SqlDbType.Char, 100),
                                                new SqlParameter("@pe_addr", SqlDbType.Char, 100),
                                                new SqlParameter("@opdate", SqlDbType.DateTime),
                                                new SqlParameter("@unit_cnt", SqlDbType.Decimal, 9),
                                                new SqlParameter("@x_cnt", SqlDbType.Decimal, 9),
                                                new SqlParameter("@y_cnt", SqlDbType.Decimal, 9),
                                                new SqlParameter("@scp_id", SqlDbType.Char, 3),
                                                new SqlParameter("@scp_c", SqlDbType.Char, 30),
                                                new SqlParameter("@scp_e", SqlDbType.Char, 50),
                                                new SqlParameter("@scp_mkt", SqlDbType.Char, 1),
                                                new SqlParameter("@nmark", SqlDbType.Int, 4),
                                                new SqlParameter("@o_estateid", SqlDbType.Char, 50),
                                                new SqlParameter("@o_bldgid", SqlDbType.Char, 50),
                                                new SqlParameter("@estateid", SqlDbType.Char, 50),
                                                new SqlParameter("@buildingid", SqlDbType.Char, 50),
                                                new SqlParameter("@address", SqlDbType.Char, 50),
                                                new SqlParameter("@moddate", SqlDbType.DateTime),
                                                new SqlParameter("@pc_street1", SqlDbType.Char, 100),
                                                new SqlParameter("@pc_street2", SqlDbType.Char, 100),
                                                new SqlParameter("@pe_street1", SqlDbType.Char, 100),
                                                new SqlParameter("@pe_street2", SqlDbType.Char, 100),
                                                new SqlParameter("@pc_stno1", SqlDbType.Char, 20),
                                                new SqlParameter("@pc_stno2", SqlDbType.Char, 20),
                                                new SqlParameter("@ppt_rank", SqlDbType.Int, 4),
                                                new SqlParameter("@org_cenblg", SqlDbType.Char, 10),
                                                new SqlParameter("@org_cenest", SqlDbType.Char, 10),
                                                new SqlParameter("@need_clear", SqlDbType.Char, 1),
                                                new SqlParameter("@x_axis", SqlDbType.Char, 250),
                                                new SqlParameter("@x_axis2", SqlDbType.Char, 250),
                                                new SqlParameter("@y_axis", SqlDbType.Char, 250),
                                                new SqlParameter("@y_axis2", SqlDbType.Char, 250),
                                                new SqlParameter("@cblk_key", SqlDbType.Char, 250),
                                                new SqlParameter("@buildId", SqlDbType.Int, 4)
                                            };
                parameters[0].Value = ConvertUtility.Trim(model.centaest);
                parameters[1].Value = ConvertUtility.Trim(model.cestcode);
                parameters[2].Value = ConvertUtility.Trim(model.centabldg);
                parameters[3].Value = ConvertUtility.Trim(model.cblgcode);
                parameters[4].Value = ConvertUtility.ToDecimal(model.lpt_x);
                parameters[5].Value = ConvertUtility.ToDecimal(model.lpt_y);
                parameters[6].Value = ConvertUtility.Trim(model.usage);
                parameters[7].Value = ConvertUtility.Trim(model.c_estate);
                parameters[8].Value = ConvertUtility.Trim(model.e_estate);
                parameters[9].Value = ConvertUtility.Trim(model.c_phase);
                parameters[10].Value = ConvertUtility.Trim(model.e_phase);
                parameters[11].Value = ConvertUtility.Trim(model.c_property);
                parameters[12].Value = ConvertUtility.Trim(model.e_property);
                parameters[13].Value = ConvertUtility.Trim(model.pc_addr1);
                parameters[14].Value = ConvertUtility.Trim(model.pc_addr2);
                parameters[15].Value = ConvertUtility.Trim(model.pe_addr);
                parameters[16].Value = ConvertUtility.ToDateTime(model.opdate);
                parameters[17].Value = ConvertUtility.ToDecimal(model.unit_cnt);
                parameters[18].Value = ConvertUtility.ToDecimal(model.x_cnt);
                parameters[19].Value = ConvertUtility.ToDecimal(model.y_cnt);
                parameters[20].Value = ConvertUtility.Trim(model.scp_id);
                parameters[21].Value = ConvertUtility.Trim(model.scp_c);
                parameters[22].Value = ConvertUtility.Trim(model.scp_e);
                parameters[23].Value = ConvertUtility.Trim(model.scp_mkt);
                parameters[24].Value = ConvertUtility.ToInt(model.nmark);
                parameters[25].Value = ConvertUtility.Trim(model.o_estateid);
                parameters[26].Value = ConvertUtility.Trim(model.o_bldgid);
                parameters[27].Value = ConvertUtility.Trim(model.estateid);
                parameters[28].Value = ConvertUtility.Trim(model.buildingid);
                parameters[29].Value = ConvertUtility.Trim(model.address);
                parameters[30].Value = ConvertUtility.ToDateTime(model.moddate);
                parameters[31].Value = ConvertUtility.Trim(model.pc_street1);
                parameters[32].Value = ConvertUtility.Trim(model.pc_street2);
                parameters[33].Value = ConvertUtility.Trim(model.pe_street1);
                parameters[34].Value = ConvertUtility.Trim(model.pe_street2);
                parameters[35].Value = ConvertUtility.Trim(model.pc_stno1);
                parameters[36].Value = ConvertUtility.Trim(model.pc_stno2);
                parameters[37].Value = ConvertUtility.ToInt(model.ppt_rank);
                parameters[38].Value = ConvertUtility.Trim(model.org_cenblg);
                parameters[39].Value = ConvertUtility.Trim(model.org_cenest);
                parameters[40].Value = ConvertUtility.Trim(model.need_clear);
                parameters[41].Value = ConvertUtility.Trim(model.x_axis);
                parameters[42].Value = ConvertUtility.Trim(model.x_axis2);
                parameters[43].Value = ConvertUtility.Trim(model.y_axis);
                parameters[44].Value = ConvertUtility.Trim(model.y_axis2);
                parameters[45].Value = ConvertUtility.Trim(model.cblk_key);
                parameters[46].Value = model.CentaBuildId;

                var rows = DbUtility.ExecuteNonQuery(strSql.ToString(), AppSettings.DbConn, parameters);
                return rows > 0;
            }

            /// <summary>
            /// 删除一条数据
            /// </summary>
            public bool Delete(int buildId)
            {
                var strSql = new StringBuilder();
                strSql.Append("delete from [centabldg] ");
                strSql.Append(" where CentaBuildId=@buildId ");
                SqlParameter[] parameters = {
                                                new SqlParameter("@buildId", SqlDbType.Int, 4)
                                            };
                parameters[0].Value = buildId;

                int rows = DbUtility.ExecuteNonQuery(strSql.ToString(), AppSettings.DbConn, parameters);
                return rows > 0;
            }


            #endregion  Method

        }
    }
}
    