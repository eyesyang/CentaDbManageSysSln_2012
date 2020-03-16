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
    public abstract class UnitDbService
    {
        private string _ClassMsg = "Class: UnitDbService; NameSpace: CentaDbManageSys.DAL; Source File: UnitDbService.cs";

        protected string ConnStr = string.Empty;

        public virtual DataTable ListUnit(string buildId)
        {
            string funMsg = "Function: ListUnit(string buildId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "spListUnit";
                return DbUtility.GetDataTableByProc(procedureName, this.ConnStr, new SqlParameter[]{
                     new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.Char, Value=buildId}                    
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual DataTable ListFloor(string buildId)
        {
            string funMsg = "Function: ListFloor(string buildId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListFloor";
                return DbUtility.GetDataTableByProc(procedureName, this.ConnStr, new SqlParameter[]{
                     new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.Char, Value=buildId}                    
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual DataTable ListRoom(string buildId)
        {
            string funMsg = "Function: ListRoom(string buildId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListRoom";
                return DbUtility.GetDataTableByProc(procedureName, this.ConnStr, new SqlParameter[]{
                     new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.Char, Value=buildId}                    
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
