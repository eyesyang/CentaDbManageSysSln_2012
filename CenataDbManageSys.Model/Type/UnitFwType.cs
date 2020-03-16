using System.Data;
using System.Text;
using CentaLine.Common;
using System;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// Framework Unit
    /// </summary>
    public class UnitFwType
    {
        private UnitCtType unitCtType;

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

        public string Collect_UnitId
        {
            get;
            set;
        }
        public string Collect_BuildId
        {
            get;
            set;
        }
        public string Collect_CX_Axis
        {
            get;
            set;
        }
        public string Collect_CY_Axis
        {
            get;
            set;
        }
        public int Collect_CountF
        {
            get;
            set;
        }
        public int Collect_CountT
        {
            get;
            set;
        }
        public int Collect_CountW
        {
            get;
            set;
        }
        public int Collect_CountY
        {
            get;
            set;
        }
        public float Collect_Area
        {
            get;
            set;
        }
        public string Collect_DirectionTo
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

        public UnitFwType()
        {

        }
        public UnitFwType(UnitFwType unitType)
        {
            this.UnitId = unitType.UnitId;
            this.BuildId = unitType.BuildId;
            this.CountF = unitType.CountF;
            this.CountT = unitType.CountT;
            this.CountW = unitType.CountW;
            this.CountY = unitType.CountY;
            this.CX_Axis = unitType.CX_Axis;
            this.CY_Axis = unitType.CY_Axis;
            this.Area = unitType.Area;
            this.DirectionTo = unitType.DirectionTo;
            this.Operate = unitType.Operate;
            this.Flow = unitType.Flow;

            this.Collect_UnitId = unitType.Collect_UnitId;
            this.Collect_BuildId = unitType.Collect_BuildId;
            this.Collect_CountF = unitType.Collect_CountF;
            this.Collect_CountT = unitType.Collect_CountT;
            this.Collect_CountW = unitType.Collect_CountW;
            this.Collect_CountY = unitType.Collect_CountY;
            this.Collect_CX_Axis = unitType.Collect_CX_Axis;
            this.Collect_CY_Axis = unitType.Collect_CY_Axis;
            this.Collect_Area = unitType.Collect_Area;
            this.Collect_DirectionTo = unitType.Collect_DirectionTo;

            this.AgencyCom_UnitId = unitType.AgencyCom_UnitId;
            this.AgencyCom_BuildId = unitType.AgencyCom_BuildId;
            this.AgencyCom_CountF = unitType.AgencyCom_CountF;
            this.AgencyCom_CountT = unitType.AgencyCom_CountT;
            this.AgencyCom_CountW = unitType.AgencyCom_CountW;
            this.AgencyCom_CountY = unitType.AgencyCom_CountY;
            this.AgencyCom_CX_Axis = unitType.AgencyCom_CX_Axis;
            this.AgencyCom_CY_Axis = unitType.AgencyCom_CY_Axis;
            this.AgencyCom_Area = unitType.AgencyCom_Area;
            this.AgencyCom_DirectionTo = unitType.AgencyCom_DirectionTo;

            this.CreateBy = unitType.CreateBy;
            this.CreateDate = unitType.CreateDate;
            this.ModifyBy = unitType.ModifyBy;
            this.ModifyDate = unitType.ModifyDate;
        }
        public UnitFwType(DataRow row)
        {
            this.UnitId = ConvertUtility.Trim(row["UnitId"]);
            this.BuildId=ConvertUtility.Trim(row["BuildId"]);
            this.CountF = ConvertUtility.ToInt(row["CountF"]);
            this.CountT = ConvertUtility.ToInt(row["CountT"]);
            this.CountW = ConvertUtility.ToInt(row["CountW"]);
            this.CountY = ConvertUtility.ToInt(row["CountY"]);
            this.CX_Axis = ConvertUtility.Trim(row["CX_Axis"]);
            this.CY_Axis = ConvertUtility.Trim(row["CY_Axis"]);
            this.Area = ConvertUtility.ToFloat(row["Area"]);
            this.DirectionTo = ConvertUtility.Trim(row["DirectionTo"]);
            this.Operate = ConvertUtility.ToInt(row["OperateStatus"]);
            this.Flow = ConvertUtility.ToInt(row["FlowStatus"]);

            this.Collect_UnitId = ConvertUtility.Trim(row["Collect_UnitId"]);
            this.Collect_BuildId = ConvertUtility.Trim(row["Collect_BuildId"]);
            this.Collect_CountF = ConvertUtility.ToInt(row["Collect_CountF"]);
            this.Collect_CountT = ConvertUtility.ToInt(row["Collect_CountT"]);
            this.Collect_CountW = ConvertUtility.ToInt(row["Collect_CountW"]);
            this.Collect_CountY = ConvertUtility.ToInt(row["Collect_CountY"]);
            this.Collect_CX_Axis = ConvertUtility.Trim(row["Collect_CX_Axis"]);
            this.Collect_CY_Axis = ConvertUtility.Trim(row["Collect_CY_Axis"]);
            this.Collect_Area = ConvertUtility.ToFloat(row["Collect_Area"]);
            this.Collect_DirectionTo = ConvertUtility.Trim(row["Collect_DirectionTo"]);

            this.AgencyCom_UnitId = ConvertUtility.Trim(row["AgencyCom_UnitId"]);
            this.AgencyCom_BuildId = ConvertUtility.Trim(row["AgencyCom_BuildId"]);
            this.AgencyCom_CountF = ConvertUtility.ToInt(row["AgencyCom_CountF"]);
            this.AgencyCom_CountT = ConvertUtility.ToInt(row["AgencyCom_CountT"]);
            this.AgencyCom_CountW = ConvertUtility.ToInt(row["AgencyCom_CountW"]);
            this.AgencyCom_CountY = ConvertUtility.ToInt(row["AgencyCom_CountY"]);
            this.AgencyCom_CX_Axis = ConvertUtility.Trim(row["AgencyCom_CX_Axis"]);
            this.AgencyCom_CY_Axis = ConvertUtility.Trim(row["AgencyCom_CY_Axis"]);
            this.AgencyCom_Area = ConvertUtility.ToFloat(row["AgencyCom_Area"]);
            this.AgencyCom_DirectionTo = ConvertUtility.Trim(row["AgencyCom_DirectionTo"]);

            this.CreateBy = ConvertUtility.Trim(row["CreateBy"]);
            this.CreateDate = ConvertUtility.ToDateTime(row["CreateDate"]);
            this.ModifyBy = ConvertUtility.Trim(row["ModifyBy"]);
            this.ModifyDate = ConvertUtility.ToDateTime(row["ModifyDate"]);

        }

        public UnitFwType(UnitCtType unitType)
        {
            this.UnitId = unitType.UnitId;
            this.BuildId = unitType.BuildId;
            this.CountF = unitType.CountF;
            this.CountT = unitType.CountT;
            this.CountW = unitType.CountW;
            this.CountY = unitType.CountY;
            this.CX_Axis = unitType.CX_Axis;
            this.CY_Axis = unitType.CY_Axis;
            this.Area = unitType.Area;
            this.DirectionTo = unitType.DirectionTo;
            this.Operate = unitType.Operate;
            this.Flow = unitType.Flow;

            this.Collect_UnitId = unitType.UnitId;
            this.Collect_BuildId = unitType.BuildId;
            this.Collect_CountF = unitType.CountF;
            this.Collect_CountT = unitType.CountT;
            this.Collect_CountW = unitType.CountW;
            this.Collect_CountY = unitType.CountY;
            this.Collect_CX_Axis = unitType.CX_Axis;
            this.Collect_CY_Axis = unitType.CY_Axis;
            this.Collect_Area = unitType.Area;
            this.Collect_DirectionTo = unitType.DirectionTo;

            this.AgencyCom_UnitId = unitType.AgencyCom_UnitId;
            this.AgencyCom_BuildId = unitType.AgencyCom_BuildId;
            this.AgencyCom_CountF = unitType.AgencyCom_CountF;
            this.AgencyCom_CountT = unitType.AgencyCom_CountT;
            this.AgencyCom_CountW = unitType.AgencyCom_CountW;
            this.AgencyCom_CountY = unitType.AgencyCom_CountY;
            this.AgencyCom_CX_Axis = unitType.AgencyCom_CX_Axis;
            this.AgencyCom_CY_Axis = unitType.AgencyCom_CY_Axis;
            this.AgencyCom_Area = unitType.AgencyCom_Area;
            this.AgencyCom_DirectionTo = unitType.AgencyCom_DirectionTo;
        }
    }
}
