using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    public class RegionType
    {
        public string RegionId
        {
            get;
            set;
        }

        public string RegionName
        {
            get;
            set;
        }
        public string CityId
        {
            get;
            set;
        }

        public RegionType()
        {

        }
        public RegionType(DataRow row)
        {
            this.RegionId = ConvertUtility.Trim(row["scp_mkt"]);
            this.RegionName = ConvertUtility.Trim(row["c_distname"]);
            this.CityId = ConvertUtility.Trim(row["cityid"]);
        }       
    }
}
