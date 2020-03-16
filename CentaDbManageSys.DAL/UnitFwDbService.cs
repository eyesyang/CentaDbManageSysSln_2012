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
    public class UnitFwDbService : UnitDbService
    {

        private string _ClassMsg = "Class: UnitFwDbService; NameSpace: CentaDbManageSys.DAL; Source File: UnitFwDbService.cs";
        public UnitFwDbService()
        {
            base.ConnStr = AppSettings.FwDbConn;
        }
        public override DataTable ListRoom(string buildId)
        {
            return base.ListRoom(buildId);
        }

        public override DataTable ListFloor(string buildId)
        {
            return base.ListFloor(buildId);
        }

        public DataTable ListUnitByBuildName(string buildName)
        {
            throw new NotImplementedException();
        }

        public override DataTable ListUnit(string buildId)
        {
            return base.ListUnit(buildId);
        }
        public DataTable ListUnitByCm(string agencyCom_BuildId)
        {
            string funMsg = "function: ListUnitByCm(string agencyCom_BuildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spListUnitByCm";
                return DbUtility.GetDataTableByProc(procedure, this.ConnStr, new SqlParameter
                {
                    ParameterName = "@agencyCom_BuildId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = agencyCom_BuildId
                }, new SqlParameter
                {
                    ParameterName = "@framework_BuildId",
                    SqlDbType = SqlDbType.Char,
                    Value = string.Empty
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertUnitByName(string buildName, string cx_axis, string cy_axis, string createBy)
        {
            throw new NotImplementedException();
        }

        public int InsertUnit(string buildId, string x_axis, string y_axis, int countf, int countt, int countw, int county, float area, string directionTo, string createBy)
        {
            string funMsg = "Function: InsertUnit(string buildId, string x_axis, string y_axis, int countf,int countt,int countw,int county,float area,string directionTo, string createBy)" + FileUtility.NewLine + _ClassMsg;
            string procedureName = string.Empty;
            try
            {
                procedureName = "spInsertUnit";
                return DbUtility.ExecuteNonQueryByProc(procedureName, this.ConnStr, new SqlParameter[]{
                    new SqlParameter{ ParameterName="@buildId", SqlDbType=SqlDbType.Char, Value=buildId}, 
                     new SqlParameter{ ParameterName="@cx_axis", SqlDbType= SqlDbType.NVarChar, Value=x_axis},
                      new SqlParameter{ ParameterName="@cy_axis", SqlDbType= SqlDbType.NVarChar, Value=y_axis},
                       new SqlParameter{ ParameterName="@countf", SqlDbType= SqlDbType.Int, Value=countf},
                        new SqlParameter{ ParameterName="@countt", SqlDbType= SqlDbType.Int, Value=countt},
                        new SqlParameter{ ParameterName="@countw", SqlDbType= SqlDbType.Int, Value=countw},
                        new SqlParameter{ ParameterName="@county", SqlDbType= SqlDbType.Int, Value=county},
                        new SqlParameter{ ParameterName="@area", SqlDbType= SqlDbType.Float, Value=area},
                        new SqlParameter{ ParameterName="@directionTo", SqlDbType= SqlDbType.NVarChar, Value=directionTo},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType= SqlDbType.Char, Value=createBy},
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteUnit(string unitId, string modifyBy)
        {
            string funMsg = "Function: DeleteUnit(string unitId, string modifyBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spDeleteUnit";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr,
                    new SqlParameter
                {
                    ParameterName = "@unitId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = unitId
                },
                new SqlParameter
                {
                    ParameterName = "@modifyBy",
                    SqlDbType = SqlDbType.Char,
                    Value = modifyBy
                }
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataRow GetUnit(string unitId)
        {
            string funMsg = "Function: GetUnit(string unitId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spGetUnit";
                return DbUtility.GetDataRowByProc(procedure, this.ConnStr, new SqlParameter
                {
                    ParameterName = "@unitId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = unitId
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ImportUnit(UnitFwType unitFwType)
        {
            string funMsg = "function: ImportUnit(UnitFwType unitFwType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spImportUnit";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {                   
                     new SqlParameter{ ParameterName="@cx_axis", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.CX_Axis},
                      new SqlParameter{ ParameterName="@cy_axis", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.CY_Axis},
                       new SqlParameter{ ParameterName="@countf", SqlDbType= SqlDbType.Int, Value=unitFwType.CountF},
                        new SqlParameter{ ParameterName="@countt", SqlDbType= SqlDbType.Int, Value=unitFwType.CountT},
                        new SqlParameter{ ParameterName="@countw", SqlDbType= SqlDbType.Int, Value=unitFwType.CountW},
                        new SqlParameter{ ParameterName="@county", SqlDbType= SqlDbType.Int, Value=unitFwType.CountY},
                        new SqlParameter{ ParameterName="@area", SqlDbType= SqlDbType.Float, Value=unitFwType.Area},
                        new SqlParameter{ ParameterName="@directionTo", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.DirectionTo},
                        new SqlParameter{ ParameterName="@operateStatus", SqlDbType= SqlDbType.Int, Value=unitFwType.Operate},
                        new SqlParameter{ ParameterName="@collect_UnitId", SqlDbType=SqlDbType.Char, Value=unitFwType.Collect_UnitId},  
                        new SqlParameter{ ParameterName="@collect_BuildId", SqlDbType=SqlDbType.Char, Value=unitFwType.Collect_BuildId}, 
                    new SqlParameter{ ParameterName="@collect_CX_Axis", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.Collect_CX_Axis},
                      new SqlParameter{ ParameterName="@collect_CY_Axis", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.Collect_CY_Axis},
                       new SqlParameter{ ParameterName="@collect_CountF", SqlDbType= SqlDbType.Int, Value=unitFwType.Collect_CountF},
                        new SqlParameter{ ParameterName="@collect_CountT", SqlDbType= SqlDbType.Int, Value=unitFwType.Collect_CountT},
                        new SqlParameter{ ParameterName="@collect_CountW", SqlDbType= SqlDbType.Int, Value=unitFwType.Collect_CountW},
                        new SqlParameter{ ParameterName="@collect_CountY", SqlDbType= SqlDbType.Int, Value=unitFwType.Collect_CountY},
                        new SqlParameter{ ParameterName="@collect_Area", SqlDbType= SqlDbType.Float, Value=unitFwType.Collect_Area},
                        new SqlParameter{ ParameterName="@collect_DirectionTo", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.Collect_DirectionTo},
                         new SqlParameter{ ParameterName="@agencyCom_UnitId", SqlDbType=SqlDbType.Char, Value=unitFwType.AgencyCom_UnitId}, 
                         new SqlParameter{ ParameterName="@agencyCom_BuildId", SqlDbType=SqlDbType.Char, Value=unitFwType.AgencyCom_BuildId}, 
                    new SqlParameter{ ParameterName="@agencyCom_CX_Axis", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.AgencyCom_CX_Axis},
                      new SqlParameter{ ParameterName="@agencyCom_CY_Axis", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.AgencyCom_CY_Axis},
                       new SqlParameter{ ParameterName="@agencyCom_CountF", SqlDbType= SqlDbType.Int, Value=unitFwType.AgencyCom_CountF},
                        new SqlParameter{ ParameterName="@agencyCom_CountT", SqlDbType= SqlDbType.Int, Value=unitFwType.AgencyCom_CountT},
                        new SqlParameter{ ParameterName="@agencyCom_CountW", SqlDbType= SqlDbType.Int, Value=unitFwType.AgencyCom_CountW},
                        new SqlParameter{ ParameterName="@agencyCom_CountY", SqlDbType= SqlDbType.Int, Value=unitFwType.AgencyCom_CountY},
                        new SqlParameter{ ParameterName="@agencyCom_Area", SqlDbType= SqlDbType.Float, Value=unitFwType.AgencyCom_Area},
                        new SqlParameter{ ParameterName="@agencyCom_DirectionTo", SqlDbType= SqlDbType.NVarChar, Value=unitFwType.AgencyCom_DirectionTo},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType= SqlDbType.Char, Value=unitFwType.CreateBy},
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int UpdateUnit(string unitId, int countf, int countt, int countw, int county, string direction, float area)
        {
            string funMsg = "function: UpdateUnit(string unitId, int countf, int countt, int countw, int county, string direction, float area)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spUpdateUnit";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@unitId", SqlDbType= SqlDbType.Char, Value= unitId},
                    new SqlParameter{ ParameterName="@countf", SqlDbType= SqlDbType.Int, Value= countf},
                    new SqlParameter{ ParameterName="@countt", SqlDbType= SqlDbType.Int, Value= countt},
                    new SqlParameter{ ParameterName="@countw", SqlDbType= SqlDbType.Int, Value= countw},
                    new SqlParameter{ ParameterName="@county", SqlDbType= SqlDbType.Int, Value= county},
                    new SqlParameter{ ParameterName="@directionTo", SqlDbType= SqlDbType.Char, Value= direction},
                    new SqlParameter{ ParameterName="@area", SqlDbType= SqlDbType.Float, Value= area}
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public DataTable ListUnitByCm(string agencyCom_BuildId, string framework_BuildId)
        {
            string funMsg = "function: ListUnitByCm(string agencyCom_BuildId, string framework_BuildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spListUnitByCm";
                return DbUtility.GetDataTableByProc(procedure, this.ConnStr, new SqlParameter
                {
                    ParameterName = "@agencyCom_BuildId",
                    SqlDbType = SqlDbType.VarChar,
                    Value = agencyCom_BuildId
                }, new SqlParameter
                {
                    ParameterName = "@framework_BuildId",
                    SqlDbType = SqlDbType.Char,
                    Value = framework_BuildId
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
