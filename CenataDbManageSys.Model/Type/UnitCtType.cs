using System.Data;
using System.Text;
using CentaLine.Common;
using System;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// Collect Unit
    /// </summary>
    public class UnitCtType
    {        
        public string UnitId
        {
            get;
            set;
        }
        public string BuildId
        {
            get;
            set;
        }
        public string CX_Axis
        {
            get;
            set;
        }
        public string CY_Axis
        {
            get;
            set;
        }
        public int CountF
        {
            get;
            set;
        }
        public int CountT
        {
            get;
            set;
        }
        public int CountW
        {
            get;
            set;
        }
        public int CountY
        {
            get;
            set;
        }
        public float Area
        {
            get;
            set;
        }
        public string DirectionTo
        {
            get;
            set;
        }

        public int Operate
        {
            get;
            set;
        }
        public int Flow 
        { 
            get;
            set;
        }
        public string AgencyCom_UnitId
        {
            get;
            set;
        }
        public string AgencyCom_BuildId
        {
            get;
            set;
        }
        public string AgencyCom_CX_Axis
        {
            get;
            set;
        }
        public string AgencyCom_CY_Axis
        {
            get;
            set;
        }
        public int AgencyCom_CountF
        {
            get;
            set;
        }
        public int AgencyCom_CountT
        {
            get;
            set;
        }
        public int AgencyCom_CountW
        {
            get;
            set;
        }
        public int AgencyCom_CountY
        {
            get;
            set;
        }
        public float AgencyCom_Area
        {
            get;
            set;
        }
        public string AgencyCom_DirectionTo
        {
            get;
            set;
        }
        public string CreateBy
        {
            get;
            set;
        }
        public DateTime CreateDate
        {
            get;
            set;
        }
        public string ModifyBy
        {
            get;
            set;
        }
        public DateTime ModifyDate
        {
            get;
            set;
        }

        public UnitCtType()
        {

        }
        public UnitCtType(UnitCtType unitType)
        {
            this.UnitId = unitType.UnitId;
            this.BuildId = unitType.BuildId;
            this.CX_Axis = unitType.CX_Axis;
            this.CY_Axis = unitType.CY_Axis;
            this.CountF = unitType.CountF;
            this.CountT = unitType.CountT;
            this.CountW = unitType.CountW;
            this.CountY = unitType.CountY;
            this.Area = unitType.Area;
            this.DirectionTo = unitType.DirectionTo;
            this.Operate = unitType.Operate;
            this.Flow = unitType.Flow;

            this.AgencyCom_UnitId = unitType.AgencyCom_UnitId;
            this.AgencyCom_BuildId = unitType.AgencyCom_BuildId;
            this.AgencyCom_CX_Axis = unitType.AgencyCom_CX_Axis;
            this.AgencyCom_CY_Axis = unitType.AgencyCom_CY_Axis;
            this.AgencyCom_CountF = unitType.AgencyCom_CountF;
            this.AgencyCom_CountT = unitType.AgencyCom_CountT;
            this.AgencyCom_CountW = unitType.AgencyCom_CountW;
            this.AgencyCom_CountY = unitType.AgencyCom_CountY;
            this.AgencyCom_Area = unitType.AgencyCom_Area;
            this.AgencyCom_DirectionTo = unitType.AgencyCom_DirectionTo;
            this.CreateBy = unitType.CreateBy;
            this.CreateDate = unitType.CreateDate;
            this.ModifyBy = unitType.ModifyBy;
            this.ModifyDate = unitType.ModifyDate;
        }

        public UnitCtType(UnitCmType unitType)
        {           
            this.CX_Axis = unitType.CX_Axis;
            this.CY_Axis = unitType.CY_Axis;
            this.CountF = unitType.CountF;
            this.CountT = unitType.CountT;
            this.CountW = unitType.CountW;
            this.CountY = unitType.CountY;
            this.Area = unitType.Area;
            this.DirectionTo = unitType.DirectionTo;
            this.Operate = OperateStatus.DEFAULT;            

            this.AgencyCom_UnitId = unitType.UnitId;
            this.AgencyCom_BuildId = unitType.BuildId;
            this.AgencyCom_CX_Axis = unitType.CX_Axis;
            this.AgencyCom_CY_Axis = unitType.CY_Axis;
            this.AgencyCom_CountF = unitType.CountF;
            this.AgencyCom_CountT = unitType.CountT;
            this.AgencyCom_CountW = unitType.CountW;
            this.AgencyCom_CountY = unitType.CountY;
            this.AgencyCom_Area = unitType.Area;
            this.AgencyCom_DirectionTo = unitType.DirectionTo;            
        }
        public UnitCtType(DataRow row)
        {
            this.UnitId = ConvertUtility.Trim(row["UnitId"]);
            this.BuildId = ConvertUtility.Trim(row["BuildId"]);
            this.CX_Axis = ConvertUtility.Trim(row["CX_Axis"]);
            this.CY_Axis = ConvertUtility.Trim(row["CY_Axis"]);
            this.CountF = ConvertUtility.ToInt(row["CountF"]);
            this.CountT = ConvertUtility.ToInt(row["CountT"]);
            this.CountW = ConvertUtility.ToInt(row["CountW"]);
            this.CountY = ConvertUtility.ToInt(row["CountY"]);
            this.Area = ConvertUtility.ToFloat(row["Area"]);
            this.DirectionTo = ConvertUtility.Trim(row["DirectionTo"]);
            this.Operate = ConvertUtility.ToInt(row["OperateStatus"]);
            this.Flow = ConvertUtility.ToInt(row["FlowStatus"]);

            this.AgencyCom_UnitId = ConvertUtility.Trim(row["AgencyCom_UnitId"]);
            this.AgencyCom_BuildId = ConvertUtility.Trim(row["AgencyCom_BuildId"]);
            this.AgencyCom_CX_Axis = ConvertUtility.Trim(row["AgencyCom_CX_Axis"]);
            this.AgencyCom_CY_Axis = ConvertUtility.Trim(row["AgencyCom_CY_Axis"]);
            this.AgencyCom_CountF = ConvertUtility.ToInt(row["AgencyCom_CountF"]);
            this.AgencyCom_CountT = ConvertUtility.ToInt(row["AgencyCom_CountT"]);
            this.AgencyCom_CountW = ConvertUtility.ToInt(row["AgencyCom_CountW"]);
            this.AgencyCom_CountY = ConvertUtility.ToInt(row["AgencyCom_CountY"]);
            this.AgencyCom_Area = ConvertUtility.ToFloat(row["AgencyCom_Area"]);
            this.AgencyCom_DirectionTo = ConvertUtility.Trim(row["AgencyCom_DirectionTo"]);

            this.CreateBy = ConvertUtility.Trim(row["CreateBy"]);
            this.CreateDate = ConvertUtility.ToDateTime(row["CreateDate"]);
            this.ModifyBy = ConvertUtility.Trim(row["ModifyBy"]);
            this.ModifyDate = ConvertUtility.ToDateTime(row["ModifyDate"]);
        }
    }
}
