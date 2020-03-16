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
    /// AgencyCom Estate Database Service
    /// </summary>
    public class EstateCmDbService: EstateDbService
    {
        private string _ClassMsg = "";
        public EstateCmDbService()
        {
            base.ConnStr = AppSettings.CmDbConn;
        }
        public override DataRow GetEstate(string estateId)
        {            
            return base.GetEstate(estateId);
        }
        public override DataTable ListEstate(string type, string code, int pageIndex, int pageSize, out int recordCount)
        {            
            return base.ListEstate(type, code, pageIndex, pageSize, out recordCount);
        }

        public int InsertOrder(string estateId, string createBy)
        {
            string funMsg = "function: InsertOrder(string estateId, string createBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spInsertOrder";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.VarChar, Value=estateId},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType=SqlDbType.VarChar, Value=createBy}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataRow GetOrder(string estateId)
        {
            string funMsg = "function: GetOrder(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spGetOrder";
                return DbUtility.GetDataRowByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.VarChar, Value=estateId}                    
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListOrder(int banch,int orderStatus)
        {
            string funMsg = "function: ListOrder(int banch, int orderStatus)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spListOrder";
                return DbUtility.GetDataTableByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@banch", SqlDbType=SqlDbType.VarChar, Value=banch},
                    new SqlParameter{ ParameterName="@orderStatus", SqlDbType=SqlDbType.VarChar, Value=orderStatus},
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }        
       

        public int UpdateOrderStatus(string estateId, int statusId)
        {
            string funMsg = "function: UpdateOrderStatus(string estateId, int statusId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spUpdateOrderStatus";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ParameterName="@estateId", SqlDbType=SqlDbType.VarChar, Value=estateId},
                    new SqlParameter{ParameterName="@StatusId", SqlDbType=SqlDbType.Int, Value=statusId}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataRow GetComparedEstate(string estateId)
        {
            string funMsg = "function: GetComparedEstate(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spGetComparedEstate";
                return DbUtility.GetDataRowByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.VarChar, Value=estateId}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertComparedEstate(EstateCmType b, EstateFwType c, int p)
        {
            string funMsg = "function: InsertComparedEstate(EstateCmType b, EstateFwType c, int p)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spInsertComparedEstate";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.VarChar, Value=b.EstateId},
                    new SqlParameter{ ParameterName="@scopeId", SqlDbType=SqlDbType.Char, Value=b.ScopeId},
                    new SqlParameter{ ParameterName="@estateName", SqlDbType=SqlDbType.NVarChar, Value=b.EstateName},
                    new SqlParameter{ ParameterName="@address", SqlDbType=SqlDbType.NVarChar, Value=b.Address},
                    new SqlParameter{ ParameterName="@framework_EstateId", SqlDbType=SqlDbType.Char, Value=c.EstateId},
                    new SqlParameter{ ParameterName="@framework_ScopeId", SqlDbType=SqlDbType.Char, Value=c.ScopeId},
                    new SqlParameter{ ParameterName="@framework_EstateName", SqlDbType=SqlDbType.NVarChar, Value=c.EstateName},
                    new SqlParameter{ ParameterName="@framework_Address", SqlDbType=SqlDbType.NVarChar, Value=c.Address},
                    new SqlParameter{ ParameterName="@statusId", SqlDbType=SqlDbType.Int, Value=p},
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public DataRow GetComparedEstateByFw(string framework_EstateId)
        {
            string funMsg = "function: GetComparedEstateByFw(string framework_EstateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spGetComparedEstateByFw";
                return DbUtility.GetDataRowByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@framework_EstateId", SqlDbType=SqlDbType.Char,Value=framework_EstateId}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }    
}
