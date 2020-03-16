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
    public class UnitCtDbService : UnitDbService
    {

        private string _ClassMsg = "Class: UnitCtDbService; NameSpace: CentaDbManageSys.DAL; Source File: UnitCtDbService.cs";

        public UnitCtDbService()
        {
            base.ConnStr = AppSettings.CtDbConn;
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

        public int InsertUnitByName(string buildName, string cx_axis, string cy_axis, string createBy)
        {
            throw new NotImplementedException();
        }

        public int InsertUnit(string buildId, string cx_axis, string cy_axis, string createBy)
        {
            throw new NotImplementedException();
        }

        public int DeleteUnit(string unitId)
        {
            throw new NotImplementedException();
        }

        public int ImportUnit(UnitCtType unitCtType)
        {
            string funMsg = "function: ImportUnit(UnitCtType unitCtType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spImportUnit";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {
                    new SqlParameter{ ParameterName="@cx_axis", SqlDbType= SqlDbType.NVarChar, Value= unitCtType.CX_Axis},
                    new SqlParameter{ ParameterName="@cy_axis", SqlDbType= SqlDbType.NVarChar, Value= unitCtType.CY_Axis},
                    new SqlParameter{ ParameterName="@countf", SqlDbType= SqlDbType.Int, Value= unitCtType.CountF},
                    new SqlParameter{ ParameterName="@countt", SqlDbType= SqlDbType.Int, Value= unitCtType.CountT},
                    new SqlParameter{ ParameterName="@countw", SqlDbType= SqlDbType.Int, Value= unitCtType.CountW},
                    new SqlParameter{ ParameterName="@county", SqlDbType= SqlDbType.Int, Value= unitCtType.CountY},
                    new SqlParameter{ ParameterName="@area", SqlDbType= SqlDbType.Float, Value= unitCtType.Area},
                    new SqlParameter{ ParameterName="@directionTo", SqlDbType= SqlDbType.NVarChar, Value= unitCtType.DirectionTo},
                    new SqlParameter{ ParameterName="@operateStatus", SqlDbType= SqlDbType.Int, Value= unitCtType.Operate},
                    new SqlParameter{ ParameterName="@agencyCom_UnitId", SqlDbType= SqlDbType.Char, Value= unitCtType.AgencyCom_UnitId},
                    new SqlParameter{ ParameterName="@agencyCom_BuildId", SqlDbType= SqlDbType.Char, Value= unitCtType.AgencyCom_BuildId},
                    new SqlParameter{ ParameterName="@agencyCom_CX_Axis", SqlDbType= SqlDbType.NVarChar, Value= unitCtType.AgencyCom_CX_Axis},
                    new SqlParameter{ ParameterName="@agencyCom_CY_Axis", SqlDbType= SqlDbType.NVarChar, Value= unitCtType.AgencyCom_CY_Axis},
                    new SqlParameter{ ParameterName="@agencyCom_CountF", SqlDbType= SqlDbType.Int, Value= unitCtType.AgencyCom_CountF},
                    new SqlParameter{ ParameterName="@agencyCom_CountT", SqlDbType= SqlDbType.Int, Value= unitCtType.AgencyCom_CountT},
                    new SqlParameter{ ParameterName="@agencyCom_CountW", SqlDbType= SqlDbType.Int, Value= unitCtType.AgencyCom_CountW},
                    new SqlParameter{ ParameterName="@agencyCom_CountY", SqlDbType= SqlDbType.Int, Value= unitCtType.AgencyCom_CountY},
                    new SqlParameter{ ParameterName="@agencyCom_Area", SqlDbType= SqlDbType.Float, Value= unitCtType.AgencyCom_Area},
                    new SqlParameter{ ParameterName="@agencyCom_DirectionTo", SqlDbType= SqlDbType.NVarChar, Value= unitCtType.AgencyCom_DirectionTo},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType= SqlDbType.NVarChar, Value= unitCtType.CreateBy}
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }   
}
