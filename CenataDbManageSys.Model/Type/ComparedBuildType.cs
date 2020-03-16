using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentaLine.Common;
using System.Data;


namespace CentaDbManageSys.Model
{
    public class ComparedBuildType
    {
        public int ComparedId
        {
            get;
            set;
        }
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
        public string Framework_BuildId
        {
            get;
            set;
        }
        public string Framework_EstateId
        {
            get;
            set;
        }
        public string Framework_BuildName
        {
            get;
            set;
        }
        public string Framework_Address
        {
            get;
            set;
        }
        public int StatusId
        {
            get;
            set;
        }
        public DateTime ComparedDate
        {
            get;
            set;
        }

        public ComparedBuildType()
        {

        }

        public ComparedBuildType(ComparedBuildType buildType)
        {
            this.ComparedId = buildType.ComparedId;
            this.BuildId = buildType.BuildId;
            this.EstateId = buildType.EstateId;
            this.BuildName = buildType.BuildName;
            this.Address = buildType.Address;
            this.Framework_BuildId = buildType.Framework_BuildId;
            this.Framework_EstateId = buildType.Framework_EstateId;
            this.Framework_BuildName = buildType.Framework_BuildName;
            this.Framework_Address = buildType.Framework_Address;
            this.StatusId = buildType.StatusId;
            this.ComparedDate = buildType.ComparedDate;
        }

        public ComparedBuildType(DataRow row)
        {
            this.ComparedId = ConvertUtility.ToInt(row["ComparedId"]);
            this.BuildId = ConvertUtility.Trim(row["BuildId"]);
            this.EstateId = ConvertUtility.Trim(row["EstateId"]);
            this.BuildName = ConvertUtility.Trim(row["BuildName"]);
            this.Address = ConvertUtility.Trim(row["Address"]);
            this.Framework_BuildId = ConvertUtility.Trim(row["Framework_BuildId"]);
            this.Framework_EstateId = ConvertUtility.Trim(row["Framework_EstateId"]);
            this.Framework_BuildName = ConvertUtility.Trim(row["Framework_BuildName"]);
            this.Framework_Address = ConvertUtility.Trim(row["Framework_Address"]);
            this.StatusId = ConvertUtility.ToInt(row["StatusId"]);
            this.ComparedDate = ConvertUtility.ToDateTime(row["ComparedDate"]);
        }
    }
}
