using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// Collect Estate
    /// </summary>
    public class EstateCtType
    {
        public string EstateId
        {
            get;
            set;
        }
        public string ScopeId
        {
            get;
            set;
        }
        public string EstateName
        {
            get;
            set;
        }
        public string Address
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

        public string AgencyCom_EstateId
        {
            get;
            set;
        }
        public string AgencyCom_ScopeId
        {
            get;
            set;
        }
        public string AgencyCom_EstateName
        {
            get;
            set;
        }
        public string AgencyCom_Address
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

        public EstateCtType()
        {

        }
        public EstateCtType(EstateCtType estateType)
        {
            this.EstateId = estateType.EstateId;
            this.ScopeId = estateType.ScopeId;
            this.EstateName = estateType.EstateName;
            this.Address = estateType.Address;
            this.Operate = estateType.Operate;
            this.Flow = estateType.Flow;
            this.AgencyCom_EstateId = estateType.AgencyCom_EstateId;
            this.AgencyCom_ScopeId = estateType.AgencyCom_ScopeId;
            this.AgencyCom_EstateName = estateType.AgencyCom_EstateName;
            this.AgencyCom_Address = estateType.AgencyCom_Address;
            this.CreateBy = estateType.CreateBy;
            this.CreateDate = estateType.CreateDate;
            this.ModifyBy = estateType.ModifyBy;
            this.ModifyDate = estateType.ModifyDate;
        }
        public EstateCtType(EstateCmType estateType)
        {
            this.EstateId = estateType.EstateId;
            this.ScopeId = estateType.ScopeId;
            this.EstateName = estateType.EstateName;
            this.Address = estateType.Address;
            this.Operate = OperateStatus.DEFAULT;
            this.Flow = FlowStatus.COLLECTING;
            this.AgencyCom_EstateId = estateType.EstateId;
            this.AgencyCom_ScopeId = estateType.ScopeId;
            this.AgencyCom_EstateName = estateType.EstateName;
            this.AgencyCom_Address = estateType.Address;            
        }

        public EstateCtType(DataRow row)
        {
            this.EstateId = ConvertUtility.Trim(row["EstateId"]);
            this.ScopeId = ConvertUtility.Trim(row["ScopeId"]);
            this.EstateName = ConvertUtility.Trim(row["EstateName"]);
            this.Address = ConvertUtility.Trim(row["Address"]);
            this.Operate = ConvertUtility.ToInt(row["OperateStatus"]);
            this.Flow = ConvertUtility.ToInt(row["FlowStatus"]);
            this.AgencyCom_EstateId = ConvertUtility.Trim(row["AgencyCom_EstateId"]);
            this.AgencyCom_ScopeId = ConvertUtility.Trim(row["AgencyCom_ScopeId"]);
            this.AgencyCom_EstateName = ConvertUtility.Trim(row["AgencyCom_EstateName"]);
            this.AgencyCom_Address = ConvertUtility.Trim(row["AgencyCom_Address"]);
            this.CreateBy = ConvertUtility.Trim(row["CreateBy"]);
            this.CreateDate = ConvertUtility.ToDateTime(row["CreateDate"]);
            this.ModifyBy = ConvertUtility.Trim(row["ModifyBy"]);
            this.ModifyDate = ConvertUtility.ToDateTime(row["ModifyDate"]);
        }
    }
}
