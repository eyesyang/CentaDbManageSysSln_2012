using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// AgencyCom Estate
    /// </summary>
    public class EstateCmType
    {
        public string BigestId
        {
            get;
            set;
        }
        public string EstateId
        {
            get;
            set;
        }
        public string EstateName
        {
            get;
            set;
        }

        public string ScopeId
        {
            get;
            set;
        }
        public int Mark
        {
            get;
            set;
        }
        public string Phase
        {
            get;
            set;
        }
        public string EstateType
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public DateTime CreateDate
        {
            get;
            set;
        }
        public DateTime LastUpdate
        {
            get;
            set;
        }
        public bool Completed
        {
            get;
            set;
        }

        public bool IsOrder
        {
            get;
            set;
        }
        public int OrderStatus
        {
            get;
            set;
        }
        public DateTime CompareDate
        {
            get;
            set;
        }

        public EstateCmType()
        {

        }
        public EstateCmType(DataRow row)
        {
            this.BigestId = ConvertUtility.Trim(row["bigest"]);
            this.EstateId = ConvertUtility.Trim(row["estateid"]);
            this.EstateName = ConvertUtility.Trim(row["estatename"]);
            this.ScopeId = ConvertUtility.Trim(row["scp_id"]);
            this.Mark = ConvertUtility.ToInt(row["nmark"]);
            this.Phase = ConvertUtility.Trim(row["c_phase"]);
            this.EstateType = ConvertUtility.Trim(row["est_type"]);
            this.Address = ConvertUtility.Trim(row["address"]);
            this.CreateDate = ConvertUtility.ToDateTime(row["regdate"]);
            this.LastUpdate = ConvertUtility.ToDateTime(row["moddate"]);
        }
        public EstateCmType(EstateCmType estateType)
        {
            this.BigestId = estateType.BigestId;
            this.EstateId = estateType.EstateId;
            this.EstateName = estateType.EstateName;
            this.ScopeId = estateType.ScopeId;

            this.Mark = estateType.Mark;
            this.Phase = estateType.Phase;
            this.EstateType = estateType.EstateType;
            this.Address = estateType.Address;
            this.CreateDate = estateType.CreateDate;
            this.LastUpdate = estateType.LastUpdate;
        }
    }   
}
