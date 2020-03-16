using System;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// Framework Build
    /// </summary>
    public class BuildFwType
    {
        private BuildCtType buildCtType;

         public string BuildId
        {
            get;
            set;
        }
        public string EstateId
        {
            get;
            set;
        }
        public string BuildName
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
        public string Collect_BuildId
        {
            get;
            set;
        }
        public string Collect_EstateId
        {
            get;
            set;
        }
        public string Collect_BuildName
        {
            get;
            set;
        }
        public string Collect_Address
        {
            get;
            set;
        }
        public string AgencyCom_BuildId
        {
            get;
            set;
        }
        public string AgencyCom_EstateId
        {
            get;
            set;
        }
        public string AgencyCom_BuildName
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

        public BuildFwType()
        {

        }

        public BuildFwType(BuildFwType buildType)
        {
            this.BuildId = buildType.BuildId;
            this.EstateId = buildType.EstateId;
            this.BuildName = buildType.BuildName;
            this.Address = buildType.Address;
            this.Flow = buildType.Flow;
            this.Operate = buildType.Operate;

            this.Collect_BuildId = buildType.Collect_BuildId;
            this.Collect_EstateId = buildType.Collect_EstateId;
            this.Collect_BuildName = buildType.Collect_BuildName;
            this.Collect_Address = buildType.Collect_Address;

            this.AgencyCom_BuildId = buildType.AgencyCom_BuildId;
            this.AgencyCom_EstateId = buildType.AgencyCom_EstateId;
            this.AgencyCom_BuildName = buildType.AgencyCom_BuildName;
            this.AgencyCom_Address = buildType.AgencyCom_Address;

            this.CreateBy = buildType.CreateBy;
            this.CreateDate = buildType.CreateDate;
            this.ModifyBy = buildType.ModifyBy;
            this.ModifyDate = buildType.ModifyDate;
        }
        public BuildFwType(DataRow row)
        {
            this.BuildId = ConvertUtility.Trim(row["BuildId"]);
            this.EstateId = ConvertUtility.Trim(row["EstateId"]);
            this.BuildName = ConvertUtility.Trim(row["BuildName"]);
            this.Address = ConvertUtility.Trim(row["Address"]);
            this.Flow = ConvertUtility.ToInt(row["FlowStatus"]);
            this.Operate = ConvertUtility.ToInt(row["OperateStatus"]);

            this.Collect_BuildId = ConvertUtility.Trim(row["Collect_BuildId"]);
            this.Collect_EstateId = ConvertUtility.Trim(row["Collect_EstateId"]);
            this.Collect_BuildName = ConvertUtility.Trim(row["Collect_BuildName"]);
            this.Collect_Address = ConvertUtility.Trim(row["Collect_Address"]);

            this.AgencyCom_BuildId = ConvertUtility.Trim(row["AgencyCom_BuildId"]);
            this.AgencyCom_EstateId = ConvertUtility.Trim(row["AgencyCom_EstateId"]);
            this.AgencyCom_BuildName = ConvertUtility.Trim(row["AgencyCom_BuildName"]);
            this.AgencyCom_Address = ConvertUtility.Trim(row["AgencyCom_Address"]);

            this.CreateBy = ConvertUtility.Trim(row["CreateBy"]);
            this.CreateDate = ConvertUtility.ToDateTime(row["CreateDate"]);
            this.ModifyBy = ConvertUtility.Trim(row["ModifyBy"]);
            this.ModifyDate = ConvertUtility.ToDateTime(row["ModifyDate"]);
        }

        public BuildFwType(BuildCtType buildType)
        {
            this.BuildId = buildType.BuildId;
            this.EstateId = buildType.EstateId;
            this.BuildName = buildType.BuildName;
            this.Address = buildType.Address;
            this.Flow = buildType.Flow;
            this.Operate = buildType.Operate;

            this.Flow = FlowStatus.COLLECTING;
            this.Operate = buildType.Operate;

            this.Collect_BuildId = buildType.BuildId;
            this.Collect_EstateId = buildType.EstateId;
            this.Collect_BuildName = buildType.BuildName;
            this.Collect_Address = buildType.Address;

            this.AgencyCom_BuildId = buildType.AgencyCom_BuildId;
            this.AgencyCom_EstateId = buildType.AgencyCom_EstateId;
            this.AgencyCom_BuildName = buildType.AgencyCom_BuildName;
            this.AgencyCom_Address = buildType.AgencyCom_Address;
        }
    }
}
