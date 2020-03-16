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
    public class BuildCmDbService : BuildDbService
    {
        private string _ClassMsg = "Class: BuildCmDbService; NameSpace: CentaDbManageSys.DAL; Source File: BuildCmDbService.cs";

        public BuildCmDbService()
        {
            if (string.IsNullOrEmpty(base.ConnStr))
            {
                base.ConnStr = AppSettings.CmDbConn;
            }
        }

        public override DataRow GetBuild(string buildId)
        {          
            return base.GetBuild(buildId);
        }
        public override DataTable ListBuild(string estateId)
        {           
            return base.ListBuild(estateId);
        }        

        public override DataTable ListBuild(string estateId, int pageIndex, int pageSize, out int recordCount)
        {
            return base.ListBuild(estateId, pageIndex, pageSize, out recordCount);
        }

        public int InsertComparedBuild(string buildId, string estateId, string buildName, string address, string framework_BuildId, string framework_EstateId, string framework_BuildName, string framework_Address, int statusId)
        {
            string funMsg = "function: InsertComparedBuild(string buildId, string estateId, string buildName, string address, string framework_BuildId, string framework_EstateId, string framework_BuildName, string framework_Address, int statusId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spInsertComparedBuild";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType= SqlDbType.VarChar, Value= buildId},
                    new SqlParameter{ ParameterName="@estateId", SqlDbType= SqlDbType.VarChar, Value= estateId},
                    new SqlParameter{ ParameterName="@buildName", SqlDbType= SqlDbType.NVarChar, Value= buildName},
                    new SqlParameter{ ParameterName="@address", SqlDbType= SqlDbType.NVarChar, Value= address},
                    new SqlParameter{ ParameterName="@framework_BuildId", SqlDbType= SqlDbType.Char, Value= framework_BuildId},
                    new SqlParameter{ ParameterName="@framework_EstateId", SqlDbType= SqlDbType.Char, Value= framework_EstateId},
                    new SqlParameter{ ParameterName="@framework_BuildName", SqlDbType= SqlDbType.NVarChar, Value= framework_BuildName},
                    new SqlParameter{ ParameterName="@framework_Address", SqlDbType= SqlDbType.NVarChar, Value= framework_Address},
                    new SqlParameter{ ParameterName="@statusId", SqlDbType= SqlDbType.Int, Value= statusId}                    
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public DataTable ListComparedBuild(ComparedEstateType comparedEstate, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: ListComparedBuild(ComparedEstateType comparedEstate, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spListComapredBuild";
                return DbUtility.GetDataTableByProc(procedure, this.ConnStr, out recordCount, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId",  SqlDbType=SqlDbType.VarChar, Value=comparedEstate.EstateId},
                    new SqlParameter{ ParameterName="@framework_EstateId",  SqlDbType=SqlDbType.VarChar, Value=comparedEstate.Framework_EstateId},
                    new SqlParameter{ ParameterName="@pageIndex",  SqlDbType=SqlDbType.Int, Value=pageIndex},
                    new SqlParameter{ ParameterName="@pageSize",  SqlDbType=SqlDbType.Int, Value=pageSize},
                    new SqlParameter{ ParameterName="@recordCount", SqlDbType=SqlDbType.Int, Direction= ParameterDirection.Output}
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public DataRow GetComparedBuild(string buildId)
        {
            string funMsg = "function: GetComparedBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spGetComparedBuild";
                return DbUtility.GetDataRowByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.VarChar,Value= buildId}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }    
}
