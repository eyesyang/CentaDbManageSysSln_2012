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
using System.Data.SqlClient;
using CentaDbManageSys.Model;
using System.Collections.Generic;

namespace CentaDbManageSys.Service.Db
{
    public class ArchitectureDbService
    {
        private string _ClassMsg = "class: ArchitectureDbService; namespace: CentaDbManagerSys.service.db";

        private string _CentaDbConn = AppSettings.CentaDbRawConn;

        /// <summary>
        /// 通过主键获取楼盘
        /// </summary>
        /// <param name="estateId">楼盘primarykey</param>
        /// <returns></returns>
        public DataRow GetEstateById(string estateId)
        {
            string funMsg = "function: GetEstateTypeById(string estateId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "sp_getoneest";//"spGetEstateByKey";
                return DbUtility.GetDataRowByProc(procedureName, _CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.Char, Value=estateId}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 通过片区获取(分页)楼盘
        /// </summary>
        /// <param name="scopeId">片区primarykey</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="recordCount">总页数</param>
        /// <returns></returns>
        public DataTable GetEstateByScope(string scopeId, int pageIndex,int pageSize,out int recordCount)
        {
            string funMsg = "function: GetEstateByScope(string scopeId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "sp_getallest";//"spListEstateByScope";
                return DbUtility.GetDataTableByProc(procedureName, _CentaDbConn, out recordCount, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@scopeId", SqlDbType=SqlDbType.Char, Value=scopeId},
                    new SqlParameter{ ParameterName="@pageIndex", SqlDbType=SqlDbType.Int, Value= pageIndex},
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
        /// <summary>
        /// 通过片区获取楼盘
        /// </summary>
        /// <param name="scopeId">片区primarykey</param>
        /// <returns></returns>
        public DataTable GetEstateByScope(string scopeId)
        {
            string funMsg = "function: GetEstateByScope(string scopeId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                int recordCount;
                return GetEstateByScope(scopeId, 0, 0, out recordCount);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 通过关键字搜索楼盘
        /// </summary>
        /// <param name="keyword">关键字(汉字，拼音)</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="recordCount">总页数</param>
        /// <returns></returns>
        public DataTable GetEstateByKeyword(string keyword, string type, string code, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: GetEstate(string keyword,int pageIndex,int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "spListEstateByKeyword";
                return DbUtility.GetDataTableByProc(procedureName, _CentaDbConn, out recordCount, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@keyword",SqlDbType=SqlDbType.NVarChar, Value=keyword},
                    new SqlParameter{ ParameterName="@type",SqlDbType=SqlDbType.NVarChar, Value=type},
                    new SqlParameter{ ParameterName="@code",SqlDbType=SqlDbType.NVarChar, Value=code},
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
        /// <summary>
        /// 通过主键获取栋座
        /// </summary>
        /// <param name="buildId">栋座primarykey</param>
        /// <returns></returns>
        public DataRow GetBuildById(string buildId)
        {
            string funMsg = "function: GetBuildById(string buildId);" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_getonebldg";//"spGetBuildByKey";
                return DbUtility.GetDataRowByProc(procedureName, _CentaDbConn, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@buildId", SqlDbType= SqlDbType.Char, Value=buildId}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }

        }       
        /// <summary>
        /// 通过楼盘Id获取栋座
        /// </summary>
        /// <param name="estateId">楼盘Id</param>
        /// <returns></returns>
        public DataTable GetBuildByEstate(string estateId)
        {
            string funMsg = "function: GetBuildByEstate(string estateId);" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                int recordCount;
                return GetBuildByEstate(estateId, 0, 0, out recordCount);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 通过楼盘Id获取栋座(分页)
        /// </summary>
        /// <param name="estateId">楼盘Id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="recordCount">记录数</param>
        /// <returns></returns>
        public DataTable GetBuildByEstate(string estateId, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: GetBuildByEstate(string estateId, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_getallbldg";//"spListBuildByEstate";
                return DbUtility.GetDataTableByProc(procedureName, _CentaDbConn, out recordCount, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@estateId",SqlDbType=SqlDbType.Char, Value=estateId},
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildId"></param>
        /// <returns></returns>
        public IList<DataTable> GetUnitByBuild(string buildId)
        {
            string funMsg = "function: GetUnitByBuild(string buildId);" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_getallunit_DB";//"spListUnitByBuild";
                return DbUtility.GetDataTableListByProc(procedureName, _CentaDbConn, new SqlParameter[]{
                     new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.NVarChar, Value=buildId},
                    new SqlParameter{ ParameterName="@floor", SqlDbType= SqlDbType.NVarChar, Value=string.Empty},
                    new SqlParameter{ ParameterName="@room", SqlDbType= SqlDbType.NVarChar, Value=string.Empty}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildId"></param>
        /// <param name="floor"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        public DataTable GetUnitByBuild(string buildId, string floor, string room)
        {
            string funMsg = "function: GetUnitByBuild(string buildId, string floor, string room)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_getallunit_DB";//"spListUnitByBuild";
                return DbUtility.GetDataTableByProc(procedureName, _CentaDbConn, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.NVarChar, Value=buildId},
                    new SqlParameter{ ParameterName="@floor", SqlDbType= SqlDbType.NVarChar, Value=floor},
                    new SqlParameter{ ParameterName="@room", SqlDbType= SqlDbType.NVarChar, Value=room}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public DataRow GetUnitById(string unitId)
        {
            string funMsg = "function: GetUnitById(string unitId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_getoneunit_DB";//"spGetUnitByKey";
                return DbUtility.GetDataRowByProc(procedureName, _CentaDbConn, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@unitId", SqlDbType=SqlDbType.Char, Value=unitId}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="code"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetEstateByType(string type, string code, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: GetEstateByType(string type,string code, int pageIndex,int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListEstateByType";
                return DbUtility.GetDataTableByProc(procedureName, _CentaDbConn, out recordCount, new SqlParameter[]{
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
            finally
            {
 
            }
        }   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estate"></param>
        /// <returns></returns>
        public int AddEstate(CentaEstateType estate)
        {
            string funMsg = "function:AddEstate(CentaEstateType estate)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_addest";//"spInsertEstate";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.NVarChar, Value= estate.EstateId},
                    new SqlParameter{ ParameterName="@scopeId", SqlDbType=SqlDbType.NVarChar, Value= estate.ScopeId},
                    new SqlParameter{ ParameterName="@estateName", SqlDbType=SqlDbType.NVarChar, Value=estate.EstateName},
                    new SqlParameter{ ParameterName="@estateType", SqlDbType=SqlDbType.NVarChar, Value=estate.EstateType},
                    new SqlParameter{ ParameterName="@address", SqlDbType= SqlDbType.NVarChar, Value=estate.Address},
                    new SqlParameter{ ParameterName="@phase", SqlDbType=SqlDbType.NVarChar, Value= estate.Phase}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estate"></param>
        /// <returns></returns>
        public int UpdateEstate(CentaEstateType estate)
        {
            string funMsg = "function: UpdateEstate(CentaEstateType estate)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_updest";//"spUpdateEstate";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@scopeId", SqlDbType=SqlDbType.NVarChar, Value=estate.ScopeId},
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.NVarChar, Value= estate.EstateId},
                    new SqlParameter{ ParameterName="@estateName", SqlDbType=SqlDbType.NVarChar, Value=estate.EstateName},
                    new SqlParameter{ ParameterName="@estateType", SqlDbType=SqlDbType.NVarChar, Value=estate.EstateType},
                    new SqlParameter{ ParameterName="@address", SqlDbType= SqlDbType.NVarChar, Value=estate.Address},
                    new SqlParameter{ ParameterName="@phase", SqlDbType=SqlDbType.NVarChar, Value= estate.Phase}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estateId"></param>
        /// <param name="nmark"></param>
        /// <returns></returns>
        public int UpdateEstateByNmark(string estateId,int nmark)
        {
            string funMsg = "function: UpdateEstateByNmark(string estateId,int nmark);" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_delest";// "spUpdateEstateByNmark";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.NVarChar , Value=estateId},
                    new SqlParameter{ ParameterName="@nmark", SqlDbType= SqlDbType.Int, Value=nmark}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estateId"></param>
        /// <param name="buildName"></param>
        /// <returns></returns>
        public DataTable GetBuildByName(string estateId, string buildName)
        {
            string funMsg = "function: GetBuild(string estateId, string buildName)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "spListBuildByName";
                return DbUtility.GetDataTableByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.NVarChar,Value=estateId},
                    new SqlParameter{ ParameterName="@buildName", SqlDbType= SqlDbType.NVarChar, Value=buildName}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildId"></param>
        /// <param name="floor"></param>
        /// <param name="room"></param>
        /// <param name="area"></param>
        /// <param name="countf"></param>
        /// <param name="countt"></param>
        /// <param name="countw"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public int AddUnit(string buildId, string floor, string room, decimal area, string countf, string countt, string countw, string direction)
        {
            string funMsg = "function: AddUnit(string buildId, string floor, string room, decimal area, string countf, string countt,string countw,string direction)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_addunit";//"spInsertUnit";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@centabldg", SqlDbType=SqlDbType.NVarChar,Value=buildId},
                    new SqlParameter{ ParameterName="@cx_axis", SqlDbType=SqlDbType.NVarChar,Value=room},
                    new SqlParameter{ ParameterName="@cy_axis", SqlDbType=SqlDbType.NVarChar,Value=floor},
                    new SqlParameter{ ParameterName="@area", SqlDbType=SqlDbType.Decimal,Value=area},
                    new SqlParameter{ ParameterName="@countf", SqlDbType=SqlDbType.NVarChar,Value=countf},
                    new SqlParameter{ ParameterName="@countt", SqlDbType=SqlDbType.NVarChar,Value=countt},
                    new SqlParameter{ ParameterName="@countw", SqlDbType=SqlDbType.NVarChar,Value=countw},
                    new SqlParameter{ ParameterName="@direction", SqlDbType=SqlDbType.NVarChar,Value=direction},
                    new SqlParameter{ ParameterName="@c_feature", SqlDbType=SqlDbType.NVarChar,Value=buildId},
                    new SqlParameter{ ParameterName="@c_feature2", SqlDbType=SqlDbType.NVarChar,Value=buildId},
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="nmark"></param>
        /// <returns></returns>
        public int UpdateUnitByNmark(string unitId, int nmark)
        {
            string funMsg = "function: UpdateEstateByNmark(string unitId,int nmark);" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_delunit";//"spUpdateUnitByNmark";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@unitId", SqlDbType=SqlDbType.NVarChar , Value=unitId},
                    new SqlParameter{ ParameterName="@nmark", SqlDbType= SqlDbType.Int, Value=nmark}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildId"></param>
        /// <param name="nmark"></param>
        /// <returns></returns>
        public int UpdateBuildByNmark(string buildId, int nmark)
        {
            string funMsg = "function: UpdateBuildByNmark(string buildId,int nmark);" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty; 
            try
            {
                procedureName = "sp_delbldg";//"spUpdateBuildByNmark";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.NVarChar , Value= buildId},
                    new SqlParameter{ ParameterName="@nmark", SqlDbType= SqlDbType.Int, Value=nmark}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estateId"></param>
        /// <param name="buildName"></param>
        /// <param name="buildType"></param>
        /// <param name="x_cnt"></param>
        /// <param name="y_cnt_begin"></param>
        /// <param name="y_cnt_end"></param>
        /// <param name="x_except"></param>
        /// <param name="y_except"></param>
        /// <returns></returns>
        public int AddBuild(string estateId, string buildName, string buildType, string x_cnt, string y_cnt_begin, string y_cnt_end, bool x_except,bool y_except)
        {
            string funMsg = "function: AddBuild(estateId,buildName,buildType,x_cnt,y_cnt_begin,y_cnt_end,x_except,y_except)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "sp_addbldg";//"spInsertBuild";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@estateId", SqlDbType=SqlDbType.NVarChar, Value=estateId},
                    new SqlParameter{ ParameterName="@buildName", SqlDbType=SqlDbType.NVarChar, Value=buildName},
                    new SqlParameter{ ParameterName="@buildType", SqlDbType=SqlDbType.NVarChar, Value=buildType},
                    new SqlParameter{ ParameterName="@x_cnt", SqlDbType=SqlDbType.NVarChar, Value=x_cnt},
                    new SqlParameter{ ParameterName="@y_cnt_begin", SqlDbType=SqlDbType.NVarChar, Value=y_cnt_begin},
                    new SqlParameter{ ParameterName="@y_cnt_end", SqlDbType=SqlDbType.NVarChar, Value=y_cnt_end},
                    new SqlParameter{ ParameterName="@x_except", SqlDbType=SqlDbType.Bit, Value=x_except},
                    new SqlParameter{ ParameterName="@y_except", SqlDbType=SqlDbType.Bit, Value=y_except}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildId"></param>
        /// <param name="buildName"></param>
        /// <returns></returns>
        public int UpdateBuild(string buildId, string buildName)
        {
            string funMsg = "function: UpdateBuild(string buildId, string buildName)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "sp_updbldg";//"spUpdateBuild";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.NVarChar, Value= buildId},
                    new SqlParameter{ ParameterName="@buildName", SqlDbType=SqlDbType.NVarChar, Value=buildName}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int MoveUnit(string unitId, string row, string col)
        {
            string funMsg = "function: MoveUnit(string unitId, string row, string col)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "sp_moveunit";//"spMoveUnit";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@unitId", SqlDbType= SqlDbType.NVarChar, Value= unitId},
                    new SqlParameter{ ParameterName="@row", SqlDbType=SqlDbType.NVarChar, Value=row},
                    new SqlParameter{ ParameterName="@col", SqlDbType= SqlDbType.NVarChar, Value=col}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildId"></param>
        /// <returns></returns>
        public DataTable GetUnitFloorByBuild(string buildId)
        {
            string funMsg = "function: GetUnitFloorByBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListUnitFloorByBuild";
                return DbUtility.GetDataTableByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType= SqlDbType.NVarChar, Value= buildId}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildId"></param>
        /// <returns></returns>
        public DataTable GetUnitRoomByBuild(string buildId)
        {
            string funMsg = "function: GetUnitRoomByBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListUnitRoomByBuild";
                return DbUtility.GetDataTableByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@buildId", SqlDbType= SqlDbType.NVarChar, Value= buildId}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="area"></param>
        /// <param name="countf"></param>
        /// <param name="countt"></param>
        /// <param name="countw"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public int UpdateUnit(string unitId, decimal area, int countf, int countt, int countw, string direction)
        {
            string funMsg = "function: UpdateUnit(string item, decimal area, int countf, int countt, int countw, string direction)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "sp_updunit";//"spUpdateUnit";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@unitId", SqlDbType=SqlDbType.NVarChar, Value=unitId},
                    new SqlParameter{ ParameterName="@area", SqlDbType=SqlDbType.Decimal, Value=area},
                    new SqlParameter{ ParameterName="@countf", SqlDbType=SqlDbType.Int, Value=countf},
                    new SqlParameter{ ParameterName="@countt", SqlDbType=SqlDbType.Int, Value=countt},
                    new SqlParameter{ ParameterName="@countw", SqlDbType=SqlDbType.Int, Value=countw},
                    new SqlParameter{ ParameterName="@direction", SqlDbType=SqlDbType.NVarChar, Value=direction},
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public int MergeUnit(string unitId)
        {
            string funMsg = "function: MergeUnit(string unitId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "sp_mergeunit";//"spMergeUnit";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@unitId", SqlDbType= SqlDbType.NVarChar, Value=unitId}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estateId"></param>
        /// <param name="buildName"></param>
        /// <returns></returns>
        public int AddBuild(string estateId, string buildName)
        {
            string funMsg = "function: AddBuild(string estateId, string buildName)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "sp_addbldg";//"spInsertBuild";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this._CentaDbConn, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@estateId", SqlDbType= SqlDbType.NVarChar, Value= estateId},
                    new SqlParameter{ ParameterName="@buildName", SqlDbType= SqlDbType.NVarChar, Value= buildName},
                    new SqlParameter{ ParameterName="@buildType", SqlDbType=SqlDbType.NVarChar, Value=string.Empty},
                    new SqlParameter{ ParameterName="@x_cnt", SqlDbType=SqlDbType.NVarChar, Value=string.Empty},
                    new SqlParameter{ ParameterName="@y_cnt_begin", SqlDbType=SqlDbType.NVarChar, Value=string.Empty},
                    new SqlParameter{ ParameterName="@y_cnt_end", SqlDbType=SqlDbType.NVarChar, Value=string.Empty},
                    new SqlParameter{ ParameterName="@x_except", SqlDbType=SqlDbType.Bit, Value=false},
                    new SqlParameter{ ParameterName="@y_except", SqlDbType=SqlDbType.Bit, Value=false}
                });
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + "ProcedureName: " + procedureName + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetEstateNameByKeyword(string keyword, string type, string code, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: GetEstateNameByKeyword(string keyword, string type, string code, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;            
            try
            {
                procedureName = "spListEstateNameByKeyword";
                return DbUtility.GetDataTableByProc(procedureName, this._CentaDbConn, out recordCount, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@keyword",SqlDbType=SqlDbType.NVarChar, Value=keyword},
                    new SqlParameter{ ParameterName="@type",SqlDbType=SqlDbType.NVarChar, Value=type},
                    new SqlParameter{ ParameterName="@code",SqlDbType=SqlDbType.NVarChar, Value=code},
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
