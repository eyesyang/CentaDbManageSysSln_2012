using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    public class ComparedUnitType
    {
        public int ComparedId { get; set; }
        public string UnitId { get; set; }
        public string BuildId { get; set; }
        public string CX_Axis { get; set; }
        public string CY_Axis { get; set; }
        public string CountF { get; set; }
        public string CountT { get; set; }
        public string CountW { get; set; }
        public string CountY { get; set; }
        public string Area { get; set; }
        public string DirectionTo { get; set; }
        public string Framework_UnitId { get; set; }
        public string Framework_BuildId { get; set; }
        public string Framework_CX_Axis { get; set; }
        public string Framework_CY_Axis { get; set; }
        public string Framework_CountF { get; set; }
        public string Framework_CountT { get; set; }
        public string Framework_CountW { get; set; }
        public string Framework_CountY { get; set; }
        public string Framework_Area { get; set; }
        public string Framework_DirectionTo { get; set; }
        public int StatusId { get; set; }
        public DateTime ComparedDate { get; set; }

        public ComparedUnitType()
        {

        }
        public ComparedUnitType(DataRow row)
        {
            this.ComparedId = ConvertUtility.ToInt(row["ComparedId"]);
            this.UnitId = ConvertUtility.Trim(row["UnitId"]);
            this.BuildId = ConvertUtility.Trim(row["BuildId"]);
            this.CX_Axis = ConvertUtility.Trim(row["CX_Axis"]);
            this.CY_Axis = ConvertUtility.Trim(row["CY_Axis"]);
            this.CountF = ConvertUtility.Trim(row["CountF"]);
            this.CountT = ConvertUtility.Trim(row["CountT"]);
            this.CountW = ConvertUtility.Trim(row["CountW"]);
            this.CountY = ConvertUtility.Trim(row["CountY"]);
            this.Area = ConvertUtility.Trim(row["Area"]);
            this.DirectionTo = ConvertUtility.Trim(row["DirectionTo"]);
            this.Framework_UnitId = ConvertUtility.Trim(row["Framework_UnitId"]);
            this.Framework_BuildId = ConvertUtility.Trim(row["Framework_BuildId"]);
            this.Framework_CX_Axis = ConvertUtility.Trim(row["Framework_CX_Axis"]);
            this.Framework_CY_Axis = ConvertUtility.Trim(row["Framework_CY_Axis"]);
            this.Framework_CountF = ConvertUtility.Trim(row["Framework_CountF"]);
            this.Framework_CountT = ConvertUtility.Trim(row["Framework_CountT"]);
            this.Framework_CountW = ConvertUtility.Trim(row["Framework_CountW"]);
            this.Framework_CountY = ConvertUtility.Trim(row["Framework_CountY"]);
            this.Framework_Area = ConvertUtility.Trim(row["Framework_Area"]);
            this.Framework_DirectionTo = ConvertUtility.Trim(row["Framework_DirectionTo"]);
            this.StatusId = ConvertUtility.ToInt(row["StatusId"]);
            this.ComparedDate = ConvertUtility.ToDateTime(row["ComparedDate"]);
        }
    }
}
