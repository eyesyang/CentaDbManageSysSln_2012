using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    public class CityType
    {
        public string CityId
        {
            get;
            set;
        }
        public string CityName
        {
            get;
            set;
        }

        public CityType()
        {

        }
        public CityType(DataRow row)
        {
            this.CityName = ConvertUtility.Trim(row["cityname"]);
            this.CityId = ConvertUtility.Trim(row["cityid"]);
        }      
    }
}
