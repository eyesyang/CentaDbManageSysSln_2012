using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CentaLine.Common;
using CentaLine.DataCommon;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.DAL
{
    /// <summary>
    /// Collect Estate Database Service
    /// </summary>
    public class EstateCtDbService : EstateDbService
    {
        private string _ClassMsg = "Class: EstateCtDbService; NameSpace: CentaDbManageSys.DAL; Source File: EstateCtDbService.cs";
        public EstateCtDbService()
        {
            base.ConnStr = AppSettings.CtDbConn;
        }


        public override DataRow GetEstate(string estateId)
        {
            return base.GetEstate(estateId);
        }
        public override DataTable ListEstate(string type, string code, int pageIndex, int pageSize, out int recordCount)
        {
            return base.ListEstate(type, code, pageIndex, pageSize, out recordCount);
        }

        public int ImportEstate(EstateCtType estateCtType)
        {
            string funMsg = "function: ImportEstate(EstateCtType estateCtType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spImportEstate";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@scopeId", SqlDbType=SqlDbType.Char, Value= estateCtType.ScopeId},
                    new SqlParameter{ ParameterName="@estateName", SqlDbType=SqlDbType.NVarChar, Value= estateCtType.EstateName},
                    new SqlParameter{ ParameterName="@address", SqlDbType=SqlDbType.NVarChar, Value= estateCtType.Address},
                    new SqlParameter{ ParameterName="@operateStatus", SqlDbType=SqlDbType.Int, Value= estateCtType.Operate},
                    new SqlParameter{ ParameterName="@FlowStatus", SqlDbType=SqlDbType.Int, Value= estateCtType.Flow},
                    new SqlParameter{ ParameterName="@agencyCom_EstateId", SqlDbType=SqlDbType.Char, Value= estateCtType.AgencyCom_EstateId},
                    new SqlParameter{ ParameterName="@agencyCom_ScopeId", SqlDbType=SqlDbType.Char, Value= estateCtType.AgencyCom_ScopeId},
                    new SqlParameter{ ParameterName="@agencyCom_EstateName", SqlDbType=SqlDbType.NVarChar, Value= estateCtType.AgencyCom_EstateName},
                    new SqlParameter{ ParameterName="@agencyCom_Address", SqlDbType=SqlDbType.NVarChar, Value= estateCtType.AgencyCom_Address},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType=SqlDbType.Char, Value= estateCtType.CreateBy}                    
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCompletedEstate(int banch)
        {
            string funMsg = "function: GetCompletedEstate(int banch)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spGetCompletedEstate";
                return DbUtility.GetDataTableByProc(procedure, this.ConnStr, new SqlParameter
                {
                    ParameterName = "@banch",
                    SqlDbType = SqlDbType.VarChar,
                    Value = banch
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateFlowStatus(string estateId, int flowStatus)
        {
            string funMsg = "function: UpdateFlowStatus(string estateId, int flowStatus)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spUpdateFlowStatus";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.Char, Value=estateId},
                    new SqlParameter{ ParameterName="@flowStatus", SqlDbType= SqlDbType.Int, Value=flowStatus}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListOrderStatus()
        {
            string funMsg = "function: ListOrderStatus()" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spListOrderStatus";
                return DbUtility.GetDataTableByProc(procedure, this.ConnStr);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
