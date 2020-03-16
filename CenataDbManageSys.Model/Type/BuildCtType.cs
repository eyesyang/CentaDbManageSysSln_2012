using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// Collect Build
    /// </summary>
    public class BuildCtType
    {
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

        public BuildCtType()
        {

        }
        public BuildCtType(BuildCtType buildType)
        {
            this.BuildId = buildType.BuildId;
            this.EstateId = buildType.EstateId;
            this.BuildName = buildType.BuildName;
            this.Address = buildType.Address;
            this.Operate = buildType.Operate;
            this.Flow = buildType.Flow;
            this.AgencyCom_BuildId = buildType.AgencyCom_BuildId;
            this.AgencyCom_EstateId = buildType.AgencyCom_EstateId;
            this.AgencyCom_BuildName = buildType.AgencyCom_BuildName;
            this.AgencyCom_Address = buildType.AgencyCom_Address;
            this.CreateBy = buildType.CreateBy;
            this.CreateDate = buildType.CreateDate;
            this.ModifyBy = buildType.ModifyBy;
            this.ModifyDate = buildType.ModifyDate;
        }

        public BuildCtType(BuildCmType buildType)
        {                      
            this.BuildName = buildType.BuildName;
            this.Address = buildType.Address;
            this.Operate = OperateStatus.DEFAULT;
            this.Flow = FlowStatus.COLLECTING;
            this.AgencyCom_BuildId = buildType.BuildId;
            this.AgencyCom_EstateId = buildType.EstateId;
            this.AgencyCom_BuildName = buildType.BuildName;
            this.AgencyCom_Address = buildType.Address;                    
        }

        public BuildCtType(DataRow row)
        {
            this.BuildId = ConvertUtility.Trim(row["BuildId"]);
            this.EstateId = ConvertUtility.Trim(row["EstateId"]);
            this.BuildName = ConvertUtility.Trim(row["BuildName"]);
            this.Address = ConvertUtility.Trim(row["Address"]);
            this.Operate = ConvertUtility.ToInt(row["BuildName"]);
            this.Flow = ConvertUtility.ToInt(row["Address"]);
            this.AgencyCom_BuildId = ConvertUtility.Trim(row["AgencyCom_BuildId"]);
            this.AgencyCom_EstateId = ConvertUtility.Trim(row["AgencyCom_EstateId"]);
            this.AgencyCom_BuildName = ConvertUtility.Trim(row["AgencyCom_BuildName"]);
            this.AgencyCom_Address = ConvertUtility.Trim(row["AgencyCom_Address"]);
            this.CreateBy = ConvertUtility.Trim(row["CreateBy"]);
            this.CreateDate = ConvertUtility.ToDateTime(row["CreateDate"]);
            this.ModifyBy = ConvertUtility.Trim(row["ModifyBy"]);
            this.ModifyDate = ConvertUtility.ToDateTime(row["ModifyDate"]);
        }
    }
}
