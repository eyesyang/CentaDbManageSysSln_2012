using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CentaLine.Common;
using CentaLine.DataCommon;

namespace CentaDbManageSys.DAL
{
    public abstract class EstateDbService
    {
        private string _ClassMsg = "Class: EstateDbService; NameSpace: CentaDbManageSys.DAL; Source File: EstateDbService.cs";

        protected string ConnStr
        {
            get;
            set;
        }     

        public virtual DataRow GetEstate(string estateId)
        {
            string funMsg = "Function: GetDataRow(string estateId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spGetEstate";
                return DbUtility.GetDataRowByProc(procedureName, this.ConnStr, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@estateId", SqlDbType= SqlDbType.NVarChar, Value=estateId}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual DataTable ListEstate(string type, string code, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: GetDataTable(string type,string code, int pageIndex,int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListEstate";
                return DbUtility.GetDataTableByProc(procedureName, this.ConnStr, out recordCount, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@type", SqlDbType= SqlDbType.NVarChar, Value=type},
                    new SqlParameter{ ParameterName="@code", SqlDbType= SqlDbType.NVarChar, Value =code},
                    new SqlParameter{ ParameterName="@pageIndex",SqlDbType=SqlDbType.Int, Value=pageIndex},
                    new SqlParameter{ ParameterName="@pageSize", SqlDbType=SqlDbType.Int, Value=pageSize},
                    new SqlParameter{ ParameterName="@recordCount", SqlDbType=SqlDbType.Int, Direction= ParameterDirection.Output}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }  
    }
}
