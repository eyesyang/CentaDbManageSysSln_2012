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
    /// Framework Estate Database Service
    /// </summary>
    public class EstateFwDbService : EstateDbService
    {
        private string _ClassMsg = "Class: EstateFwDbService; NameSpace: CentaDbManageService.DAL; Source File: EstateFwDbService.cs";
        public EstateFwDbService()
        {
            base.ConnStr = AppSettings.FwDbConn;
        }
        public override DataRow GetEstate(string estateId)
        {           
            return base.GetEstate(estateId);
        }
        public override DataTable ListEstate(string type, string code, int pageIndex, int pageSize, out int recordCount)
        {           
            return base.ListEstate(type, code, pageIndex, pageSize, out recordCount);
        }

        public int Completed(string estateId, string modifyBy)
        {
            string funMsg = "Function: Completed(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spCompletedEstate";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType= SqlDbType.VarChar, Value=estateId},
                    new SqlParameter{ ParameterName="@modifyBy", SqlDbType= SqlDbType.Char, Value=modifyBy}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEstate(string estateId,string estateName, string address, string modifyBy)
        {
            string funMsg = "Function: UpdateEstateEdit(string estateId,string estateName, string address, string modifyBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spUpdateEstate";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType= SqlDbType.VarChar, Value=estateId},
                    new SqlParameter{ ParameterName="@estateName", SqlDbType= SqlDbType.VarChar, Value=estateName},
                    new SqlParameter{ ParameterName="@address", SqlDbType= SqlDbType.VarChar, Value=address},
                    new SqlParameter{ ParameterName="@modifyBy", SqlDbType= SqlDbType.Char, Value=modifyBy}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ImportEstate(EstateFwType estateFwType)
        {
            string funMsg = "function: ImportEstate(EstateFwType estateFwType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spImportEstate";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {                    
                    new SqlParameter{ ParameterName="@scopeId", SqlDbType= SqlDbType.Char, Value=estateFwType.ScopeId},
                    new SqlParameter{ ParameterName="@estateName", SqlDbType= SqlDbType.VarChar, Value=estateFwType.EstateName},
                    new SqlParameter{ ParameterName="@address", SqlDbType= SqlDbType.VarChar, Value=estateFwType.Address},
                    new SqlParameter{ ParameterName="@operateStatus", SqlDbType= SqlDbType.VarChar, Value=estateFwType.Operate},
                    new SqlParameter{ ParameterName="@flowStatus", SqlDbType= SqlDbType.VarChar, Value=estateFwType.Flow},

                    new SqlParameter{ ParameterName="@collect_EstateId", SqlDbType= SqlDbType.Char, Value=estateFwType.Collect_EstateId},
                    new SqlParameter{ ParameterName="@collect_ScopeId", SqlDbType= SqlDbType.Char, Value=estateFwType.Collect_ScopeId},
                    new SqlParameter{ ParameterName="@collect_EstateName", SqlDbType= SqlDbType.VarChar, Value=estateFwType.Collect_EstateName},
                    new SqlParameter{ ParameterName="@collect_Address", SqlDbType= SqlDbType.VarChar, Value=estateFwType.Collect_Address},

                    new SqlParameter{ ParameterName="@AgencyCom_EstateId", SqlDbType= SqlDbType.Char, Value=estateFwType.AgencyCom_EstateId},
                    new SqlParameter{ ParameterName="@AgencyCom_ScopeId", SqlDbType= SqlDbType.Char, Value=estateFwType.AgencyCom_ScopeId},
                    new SqlParameter{ ParameterName="@AgencyCom_EstateName", SqlDbType= SqlDbType.VarChar, Value=estateFwType.AgencyCom_EstateName},
                    new SqlParameter{ ParameterName="@AgencyCom_Address", SqlDbType= SqlDbType.VarChar, Value=estateFwType.AgencyCom_Address},

                    new SqlParameter{ ParameterName="@createBy", SqlDbType= SqlDbType.VarChar, Value=estateFwType.CreateBy}
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

        public DataRow GetEstateByCm(string agencyCom_EstateId)
        {
            string funMsg = "function: GetEstateByCm(string agencyCom_EstateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spGetEstateByCm";
                return DbUtility.GetDataRowByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ParameterName="@agencyCom_EstateId",SqlDbType=SqlDbType.VarChar,Value=agencyCom_EstateId}
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
