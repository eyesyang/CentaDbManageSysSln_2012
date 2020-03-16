using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;
using CentaLine.DataCommon;
using System.Data.SqlClient;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.DAL
{
    public class UnitCmDbService:UnitDbService
    {
        private string _ClassMsg = "Class: UnitDbService; NameSpace: CentaDbManageSys.DAL; Source File: UnitDbService.cs";

        public UnitCmDbService()
        {
            base.ConnStr = AppSettings.CmDbConn;
        }       
       
        public override DataTable ListUnit(string buildId)
        {
            return base.ListUnit(buildId);
        }
        public override DataTable ListFloor(string buildId)
        {
            return base.ListFloor(buildId);
        }
        public override DataTable ListRoom(string buildId)
        {
            return base.ListRoom(buildId);
        }

        public DataTable ListComparedUnit(ComparedBuildType comparedBuild)
        {
            string funMsg = "Function: ListComparedUnit(string buildId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListComparedUnit";
                return DbUtility.GetDataTableByProc(procedureName, this.ConnStr, new SqlParameter[]{
                      new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.VarChar, Value=comparedBuild.BuildId},
                     new SqlParameter{ ParameterName="@framework_BuildId", SqlDbType=SqlDbType.VarChar, Value=comparedBuild.Framework_BuildId},                  
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListComparedFloor(ComparedBuildType comparedBuild)
        {
            string funMsg = "Function: ListComparedFloor(string buildId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListComparedFloor";
                return DbUtility.GetDataTableByProc(procedureName, this.ConnStr, new SqlParameter[]{
                     new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.VarChar, Value=comparedBuild.BuildId},
                     new SqlParameter{ ParameterName="@framework_BuildId", SqlDbType=SqlDbType.VarChar, Value=comparedBuild.Framework_BuildId},
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListComparedRoom(ComparedBuildType comparedBuild)
        {
            string funMsg = "Function: ListComparedRoom(string buildId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spListComparedRoom";
                return DbUtility.GetDataTableByProc(procedureName, this.ConnStr, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.VarChar, Value=comparedBuild.BuildId},
                     new SqlParameter{ ParameterName="@framework_BuildId", SqlDbType=SqlDbType.VarChar, Value=comparedBuild.Framework_BuildId},           
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteUnit(string unitId)
        {
            string funMsg = "Function: RemoveData(string unitId)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spDeleteUnit";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this.ConnStr, new SqlParameter[]{
                     new SqlParameter{ ParameterName="@unitId", SqlDbType=SqlDbType.Char, Value=unitId}                   
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertUnitByName(string buildName, string cx_axis, string cy_axis, string createBy)
        {
            string funMsg = "Function: InsertUnitByName(string buildId, string x_axis, string y_axis, int createBy)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spInsertUnitByName";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this.ConnStr, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@buildName", SqlDbType=SqlDbType.Char, Value=buildName},
                    new SqlParameter{ ParameterName="@cx_axis", SqlDbType= SqlDbType.VarChar, Value=cx_axis},
                    new SqlParameter{ ParameterName="@cy_axis", SqlDbType= SqlDbType.VarChar, Value=cy_axis},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType= SqlDbType.Char, Value=createBy},
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int UpdateUnit(string unitId, string cx_axis, string cy_axis, string modifyBy)
        {
            string funMsg = "Function: UpdateData(string unitId, string x_axis, string y_axis, string modifyBy)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spUpdateUnit";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this.ConnStr, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@unitId", SqlDbType=SqlDbType.Char, Value=unitId},
                    new SqlParameter{ ParameterName="@cx_axis", SqlDbType= SqlDbType.VarChar, Value=cx_axis},
                    new SqlParameter{ ParameterName="@cy_axis", SqlDbType= SqlDbType.VarChar, Value=cy_axis},
                    new SqlParameter{ ParameterName="@modifyBy", SqlDbType= SqlDbType.Char, Value=modifyBy},
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public int InsertComparedUnit(UnitCmType obj, UnitFwType m, int comparedStatus)
        {
            string funMsg = "function: InsertComparedUnit(UnitCmType obj, UnitFwType m, int comparedStatus)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spInsertComparedUnit";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@unitId", SqlDbType=SqlDbType.VarChar, Value=obj.UnitId},
                    new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.VarChar, Value=obj.BuildId},
                    new SqlParameter{ ParameterName="@cx_axis", SqlDbType=SqlDbType.NVarChar, Value=obj.CX_Axis},
                    new SqlParameter{ ParameterName="@cy_axis", SqlDbType=SqlDbType.NVarChar, Value=obj.CY_Axis},
                    new SqlParameter{ ParameterName="@countf", SqlDbType=SqlDbType.Int, Value=obj.CountF},
                    new SqlParameter{ ParameterName="@countt", SqlDbType=SqlDbType.Int, Value=obj.CountT},
                    new SqlParameter{ ParameterName="@countw", SqlDbType=SqlDbType.Int, Value=obj.CountW},
                    new SqlParameter{ ParameterName="@county", SqlDbType=SqlDbType.Int, Value=obj.CountY},
                    new SqlParameter{ ParameterName="@area", SqlDbType=SqlDbType.VarChar, Value=obj.Area},
                    new SqlParameter{ ParameterName="@directionTo", SqlDbType=SqlDbType.VarChar, Value=obj.DirectionTo},
                    new SqlParameter{ ParameterName="@framework_UnitId", SqlDbType=SqlDbType.Char, Value=m.UnitId},
                    new SqlParameter{ ParameterName="@framework_BuildId", SqlDbType=SqlDbType.Char, Value=m.BuildId},
                    new SqlParameter{ ParameterName="@framework_CX_Axis", SqlDbType=SqlDbType.NVarChar, Value=m.CX_Axis},
                    new SqlParameter{ ParameterName="@framework_CY_Axis", SqlDbType=SqlDbType.NVarChar, Value=m.CY_Axis},
                    new SqlParameter{ ParameterName="@framework_CountF", SqlDbType=SqlDbType.Int, Value=m.CountF},
                    new SqlParameter{ ParameterName="@framework_CountT", SqlDbType=SqlDbType.Int, Value=m.CountT},
                        new SqlParameter{ ParameterName="@framework_CountW", SqlDbType=SqlDbType.Int, Value=m.CountW},
                        new SqlParameter{ ParameterName="@framework_CountY", SqlDbType=SqlDbType.Int, Value=m.CountY},
                        new SqlParameter{ ParameterName="@framework_Area", SqlDbType=SqlDbType.Float, Value=m.Area},
                        new SqlParameter{ ParameterName="@framework_DirectionTo", SqlDbType=SqlDbType.NVarChar, Value=m.DirectionTo},
                        new SqlParameter{ ParameterName="@statusId", SqlDbType=SqlDbType.Int, Value=comparedStatus}
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }    
}
