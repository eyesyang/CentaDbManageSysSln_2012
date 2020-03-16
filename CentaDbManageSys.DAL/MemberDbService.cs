using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentaLine.DataCommon;
using System.Data;
using CentaLine.Common;
using System.Data.SqlClient;

namespace CentaDbManageSys.DAL
{
    public class MemberDbService
    {
        private string _ClassMsg = "Class: MemberDbService; NameSpace: CentaManageSys.DAL; Source File: MemberDbService.cs";

        private string _ConnStr = string.Empty;

        public MemberDbService()
        {
            this._ConnStr = AppSettings.MemberDbConn;
        }

        public DataRow GetDataRow(string userName)
        {
            string funMsg = "Function: GetDataRow(string userName)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = "spGetMemberByUserName";
            try
            {
                return DbUtility.GetDataRowByProc(procedureName, _ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@userName", SqlDbType=SqlDbType.NVarChar, Value= userName}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDataTable()
        {
            string funMsg = "Function: GetDataTable()" + FileUtility.NewLine + _ClassMsg;
            string procedureName = "spListUserInfo";
            try
            {
                return DbUtility.GetDataTableByProc(procedureName, _ConnStr);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
