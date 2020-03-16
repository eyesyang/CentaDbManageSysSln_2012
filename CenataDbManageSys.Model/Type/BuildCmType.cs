using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    /// <summary>
    /// AgencyCom Build
    /// </summary>
    public class BuildCmType
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

        public BuildCmType(BuildCmType buildType)
        {
            this.BuildId = buildType.BuildId;
            this.EstateId = buildType.EstateId;            
            this.BuildName = buildType.BuildName;
            this.Address = buildType.Address;
          
        }
        public BuildCmType(DataRow row)
        {
            this.BuildId = ConvertUtility.Trim(row["BuildId"]);
            this.EstateId = ConvertUtility.Trim(row["EstateId"]);
            this.BuildName = ConvertUtility.Trim(row["BuildName"]);
            this.Address=ConvertUtility.Trim(row["Address"]);
        }
    }
}
