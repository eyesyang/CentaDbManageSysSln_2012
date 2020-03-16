using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;
using CentaLine.DataCommon;
using System.Data.SqlClient;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.DAL
{   
    public class BuildFwDbService : BuildDbService
    {
        private string _ClassMsg = "Class: BuildFwDbService; NameSpace: CentaDbManageSys.DAL; File Source: BuildFwDbService.cs";
        public BuildFwDbService()
        {
            if (string.IsNullOrEmpty(base.ConnStr))
            {
                base.ConnStr = AppSettings.FwDbConn;
            }
        }

        public int InsertBuild(string estateId, string buildName, string address, int x_cnt, bool x_except, int y_cnt_b, int y_cnt_e, bool y_except, string createBy)
        {
            string funMsg = "function: InsertBuild(string estateId, string buildName, string address,int x_cnt,bool x_except,int y_cnt,bool y_except, string createBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spInsertBuild";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.Char, Value= estateId},
                    new SqlParameter{ ParameterName="@buildName", SqlDbType=SqlDbType.NVarChar, Value=buildName},
                    new SqlParameter{ ParameterName="@address", SqlDbType=SqlDbType.NVarChar, Value=address},
                    new SqlParameter{ ParameterName="@x_cnt", SqlDbType=SqlDbType.Int, Value=x_cnt},
                    new SqlParameter{ ParameterName="@x_except", SqlDbType=SqlDbType.Bit, Value=x_except},
                    new SqlParameter{ ParameterName="@y_cnt_b", SqlDbType=SqlDbType.Int, Value=y_cnt_b},
                    new SqlParameter{ ParameterName="@y_cnt_e", SqlDbType=SqlDbType.Int, Value=y_cnt_e},
                    new SqlParameter{ ParameterName="@y_except", SqlDbType=SqlDbType.Bit, Value=y_except},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType=SqlDbType.Char, Value=createBy}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateBuild(string buildId, string buildName, string address, string modifyBy)
        {
            string funMsg = "Function: UpdateBuild(string buildId, string buildName, string address, string modifyBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spUpdateBuild";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@buildId", SqlDbType= SqlDbType.VarChar, Value=buildId},
                    new SqlParameter{ ParameterName="@buildName", SqlDbType= SqlDbType.VarChar, Value=buildName},
                    new SqlParameter{ ParameterName="@address", SqlDbType= SqlDbType.VarChar, Value=address},
                    new SqlParameter{ ParameterName="@modifyBy", SqlDbType= SqlDbType.Char, Value=modifyBy}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteBuild(string buildId, string modifyBy)
        {
            string funMsg = "function: DeleteBuild(string buildId, string modifyBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spDeleteBuild";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType= SqlDbType.VarChar, Value= buildId},
                    new SqlParameter{ ParameterName="@modifyBy", SqlDbType= SqlDbType.Char, Value= modifyBy}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Completed(string buildId, string modifyBy)
        {
            string funMsg = "function: Completed(string buildId, string modifyBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spCompletedBuild";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType= SqlDbType.VarChar, Value= buildId},
                    new SqlParameter{ ParameterName="@modifyBy", SqlDbType= SqlDbType.Char, Value= modifyBy}
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public int ImportBuild(BuildFwType buildFwType)
        {
            string funMsg = "function: ImportBuild(BuildFwType buildFwType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spImportBuild";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {                   
                    new SqlParameter{ ParameterName="@buildName", SqlDbType= SqlDbType.Char, Value=buildFwType.BuildName},
                    new SqlParameter{ ParameterName="@address", SqlDbType= SqlDbType.Char, Value=buildFwType.Address},
                    new SqlParameter{ ParameterName="@flowStatus", SqlDbType= SqlDbType.Int, Value=buildFwType.Flow},
                    new SqlParameter{ ParameterName="@operateStatus", SqlDbType= SqlDbType.Int, Value=buildFwType.Operate},
                    new SqlParameter{ ParameterName="@collect_BuildId", SqlDbType= SqlDbType.Char, Value=buildFwType.Collect_BuildId},
                    new SqlParameter{ ParameterName="@collect_EstateId", SqlDbType= SqlDbType.Char, Value=buildFwType.Collect_EstateId},
                    new SqlParameter{ ParameterName="@collect_BuildName", SqlDbType= SqlDbType.NVarChar, Value=buildFwType.Collect_BuildName},
                    new SqlParameter{ ParameterName="@collect_Address", SqlDbType= SqlDbType.NVarChar, Value=buildFwType.Collect_Address},
                    new SqlParameter{ ParameterName="@agencyCom_BuildId", SqlDbType= SqlDbType.Char, Value=buildFwType.AgencyCom_BuildId},
                     new SqlParameter{ ParameterName="@agencyCom_EstateId", SqlDbType= SqlDbType.Char, Value=buildFwType.AgencyCom_EstateId},
                    new SqlParameter{ ParameterName="@agencyCom_BuildName", SqlDbType= SqlDbType.NVarChar, Value=buildFwType.AgencyCom_BuildName},
                    new SqlParameter{ ParameterName="@agencyCom_Address", SqlDbType= SqlDbType.NVarChar, Value=buildFwType.AgencyCom_Address},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType= SqlDbType.Char, Value=buildFwType.CreateBy},
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public DataTable ListBuildByCm(string agencyCom_EstateId)
        {
            string funMsg = "function: ListBuildByCm(string agencyCom_EstateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spListBuildByCm";
                return DbUtility.GetDataTableByProc(procedure, this.ConnStr, new SqlParameter
                {
                    ParameterName="@agencyCom_EstateId",
                    SqlDbType= SqlDbType.VarChar,
                    Value=agencyCom_EstateId
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
