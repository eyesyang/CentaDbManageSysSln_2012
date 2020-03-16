using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CentaLine.Common;
using CentaLine.DataCommon;
using System.Text;
using System.Collections.Generic;
using CentaDbManageSys.Model;
using System.Reflection;
using System.Data.SqlClient;


namespace CentaDbManageSys.Service.Db
{
    public class AreaDbService
    {

        private string _ClassMsg = "class: AreaDbService; namespace: CentaDbManageSys.Service.Db; source file: AreaDbService.cs";
        private string _CentaDbConn = AppSettings.CentaDbRawConn;
        /// <summary>
        /// 获取所有城市
        /// </summary>
        /// <returns></returns>
        public DataTable GetCities()
        {
            string funMsg = "function: GetCities();" + FileUtility.NewLine + _ClassMsg;
            string procedureName=string.Empty;
            try
            {
                procedureName = "spListCity";
                return DbUtility.GetDataTableByProc(procedureName, _CentaDbConn);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg,ex.InnerException);            	
            }
        }
        /// <summary>
        /// 获取所有城区
        /// </summary>
        /// <returns></returns>
        public DataTable GetRegions()
        {
            string funMsg = "function: GetRegions();" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListRegion";
                return DbUtility.GetDataTableByProc(procedureName, _CentaDbConn);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);   
            }
        }
        /// <summary>
        /// 获取所有片区
        /// </summary>
        /// <returns></returns>
        public DataTable GetScopes()
        {
            string funMsg = "function: GetScopes();" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListScope";
                return DbUtility.GetDataTableByProc(procedureName, _CentaDbConn);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);   
            }
        }       
    }
}
