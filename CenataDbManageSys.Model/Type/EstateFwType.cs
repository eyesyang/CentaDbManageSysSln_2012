using System;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// Framework Estate
    /// </summary>
    public class EstateFwType
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
        public int Flow
        {
            get;
            set;
        }
        public int Operate
        {
            get;
            set;
        }
        public string Collect_EstateId
        {
            get;
            set;
        }
        public string Collect_ScopeId
        {
            get;
            set;
        }
        public string Collect_EstateName
        {
            get;
            set;
        }
        public string Collect_Address
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


        public EstateFwType()
        {

        }
        public EstateFwType(EstateFwType estateType)
        {
            this.EstateId = estateType.EstateId;
            this.ScopeId = estateType.ScopeId;
            this.EstateName = estateType.EstateName;
            this.Address = estateType.Address;
            this.Flow = estateType.Flow;
            this.Operate = estateType.Operate;

            this.Collect_EstateId = estateType.Collect_EstateId;
            this.Collect_ScopeId = estateType.Collect_ScopeId;
            this.Collect_EstateName = estateType.Collect_EstateName;
            this.Collect_Address = estateType.Collect_Address;

            this.AgencyCom_EstateId = estateType.AgencyCom_EstateId;
            this.AgencyCom_ScopeId = estateType.AgencyCom_ScopeId;
            this.AgencyCom_EstateName = estateType.AgencyCom_EstateName;
            this.AgencyCom_Address = estateType.AgencyCom_Address;

            this.CreateBy = estateType.CreateBy;
            this.CreateDate = estateType.CreateDate;
            this.ModifyBy = estateType.ModifyBy;
            this.ModifyDate = estateType.ModifyDate;
        }

        public EstateFwType(EstateCtType estateType)
        {
            this.EstateId = estateType.EstateId;
            this.ScopeId = estateType.ScopeId;
            this.EstateName = estateType.EstateName;
            this.Address = estateType.Address;
            this.Flow = FlowStatus.COLLECTING;
            this.Operate = estateType.Operate;

            this.Collect_EstateId = estateType.EstateId;
            this.Collect_ScopeId = estateType.ScopeId;
            this.Collect_EstateName = estateType.EstateName;
            this.Collect_Address = estateType.Address;

            this.AgencyCom_EstateId = estateType.AgencyCom_EstateId;
            this.AgencyCom_ScopeId = estateType.AgencyCom_ScopeId;
            this.AgencyCom_EstateName = estateType.AgencyCom_EstateName;
            this.AgencyCom_Address = estateType.AgencyCom_Address;
        }
        public EstateFwType(DataRow row)
        {
            this.EstateId = ConvertUtility.Trim(row["EstateId"]);
            this.ScopeId = ConvertUtility.Trim(row["ScopeId"]);
            this.EstateName = ConvertUtility.Trim(row["EstateName"]);
            this.Address = ConvertUtility.Trim(row["Address"]);
            this.Flow=ConvertUtility.ToInt(row["FlowStatus"]);

            this.Operate = ConvertUtility.ToInt(row["OperateStatus"]);

            this.Collect_EstateId = ConvertUtility.Trim(row["Collect_EstateId"]);
            this.Collect_ScopeId = ConvertUtility.Trim(row["Collect_ScopeId"]);
            this.Collect_EstateName = ConvertUtility.Trim(row["Collect_EstateName"]);
            this.Collect_Address = ConvertUtility.Trim(row["Collect_Address"]);

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
