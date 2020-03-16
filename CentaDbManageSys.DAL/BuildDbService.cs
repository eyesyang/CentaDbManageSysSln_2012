using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;
using CentaLine.DataCommon;
using System.Data.SqlClient;

namespace CentaDbManageSys.DAL
{
    public abstract class BuildDbService
    {
        private string _ClassMsg = "";
        protected string ConnStr = string.Empty;

        public virtual DataRow GetBuild(string buildId)
        {
            string funMsg = "function: GetBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spGetBuild";
                return DbUtility.GetDataRowByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType= SqlDbType.VarChar, Value= buildId}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual DataTable ListBuild(string estateId)
        {
            string funMsg = "function: ListBuild(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int recordCount = 0;
                return ListBuild(estateId, 0, 0, out recordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual DataTable ListBuild(string estateId,int pageIndex,int pageSize, out int recordCount)
        {
            string funMsg = "function: ListBuild(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spListBuild";
                return DbUtility.GetDataTableByProc(procedure, this.ConnStr, out recordCount, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId",  SqlDbType=SqlDbType.VarChar, Value=estateId},
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
    }    
}
