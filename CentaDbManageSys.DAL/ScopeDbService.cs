using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;
using CentaLine.DataCommon;

namespace CentaDbManageSys.DAL
{
    public class ScopeDbService
    {

        private string _ClassMsg = "Class: ScopeDbService; NameSpace: CentaDbManageSys.DAL; Source File: ScopeDbService.cs";

        private string _ConnStr = string.Empty;

        public ScopeDbService()
        {
            this._ConnStr = AppSettings.CmDbConn;
        }


        public IList<DataTable> ListScope()
        {
            string funMsg = "Function: ListScope();" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListScope";
                return DbUtility.GetDataTableListByProc(procedureName, _ConnStr);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }      
    }
}
