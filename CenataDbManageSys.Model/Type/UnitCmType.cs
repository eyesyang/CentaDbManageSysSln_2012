using System.Data;
using System.Text;
using CentaLine.Common;
using System;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// AgencyCom Unit
    /// </summary>
    public class UnitCmType
    {
        /// <summary>
        /// 单元Id
        /// </summary>
        public string UnitId
        {
            get;
            set;
        }
        /// <summary>
        /// 栋座Id
        /// </summary>
        public string BuildId
        {
            get;
            set;
        }
        /// <summary>
        /// 单元
        /// </summary>
        public string CX_Axis
        {
            get;
            set;
        }
        /// <summary>
        /// 楼层
        /// </summary>
        public string CY_Axis
        {
            get;
            set;
        }
        /// <summary>
        /// 房间数
        /// </summary>
        public int CountF
        {
            get;
            set;
        }
        /// <summary>
        /// 厅数
        /// </summary>
        public int CountT
        {
            get;
            set;
        }
        /// <summary>
        /// 卫生间数
        /// </summary>
        public int CountW
        {
            get;
            set;
        }
        /// <summary>
        /// 阳台数
        /// </summary>
        public int CountY
        {
            get;
            set;
        }
        /// <summary>
        /// 面积
        /// </summary>
        public float Area
        {
            get;
            set;
        }
        /// <summary>
        /// 朝向
        /// </summary>
        public string DirectionTo
        {
            get;
            set;
        }        

        public UnitCmType(UnitCmType unitType)
        {
            this.UnitId = unitType.UnitId;
            this.BuildId = unitType.BuildId;
            this.CX_Axis = unitType.CX_Axis;
            this.CY_Axis = unitType.CY_Axis;
            this.CountF = unitType.CountF;
            this.CountT = unitType.CountT;
            this.CountW = unitType.CountW;
            this.CountY = unitType.CountY;
            this.DirectionTo = unitType.DirectionTo;
            this.Area = unitType.Area;
        }
        public UnitCmType()
        {

        }

        public UnitCmType(DataRow row)
        {
            this.UnitId = ConvertUtility.Trim(row["UnitId"]);
            this.BuildId = ConvertUtility.Trim(row["BuildId"]);
            this.CX_Axis = ConvertUtility.Trim(row["CX_Axis"]);
            this.CY_Axis = ConvertUtility.Trim(row["CY_Axis"]);
            this.CountF = ConvertUtility.ToInt(row["CountF"]);
            this.CountT = ConvertUtility.ToInt(row["CountT"]);
            this.CountW = ConvertUtility.ToInt(row["CountW"]);
            this.CountY = ConvertUtility.ToInt(row["CountY"]);
            this.DirectionTo = ConvertUtility.Trim(row["DirectionTo"]);
            this.Area = ConvertUtility.ToFloat(row["Area"]);
        }
        public string ToRoomStr()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}房{1}厅{2}卫 {3}m<sup>2</sup>", this.CountF, this.CountT, this.CountW, ConvertUtility.ToInt(this.Area));
            return builder.ToString();
        }
    }


   
}
