using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    public class ScopeType
    {
        public string ScopeId
        {
            get;
            set;
        }
        public string ScopeName
        {
            get;
            set;
        }
        public string RegionId
        {
            get;
            set;
        }
        public ScopeType()
        {
        
        }
        public ScopeType(DataRow row)
        {
            this.ScopeId = ConvertUtility.Trim(row["scp_id"]);
            this.ScopeName = ConvertUtility.Trim(row["scp_c"]);
            this.RegionId = ConvertUtility.Trim(row["scp_mkt"]);
        }       
    }
}
