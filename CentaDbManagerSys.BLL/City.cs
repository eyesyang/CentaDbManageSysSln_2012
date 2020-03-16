using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.BLL
{
    public class City : CityType
    {
        public City(string cityId)            
        {            
           
            this.CityId = cityId;
            this.CityName = ScopeService.Init().CityCollection.Find(m => m.CityId == this.CityId).CityName;
        }
       
        private IList<RegionType> GetRegion()
        {
            try
            {
                if (string.IsNullOrEmpty(this.CityName))
                {
                    throw new Exception();
                }
                return ScopeService.Init().RegionCollection.FindAll(m => m.CityId == this.CityId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ToTree()
        {
            IList<RegionType> region = GetRegion();
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            if (region != null && region.Count > 0)
            {
                int mIndex = 0;
                int mCount = region.Count;
                foreach (var m in region)
                {
                    mIndex++;
                    builder.AppendFormat("{{\"text\":\"{0}\",\"attributes\":{{\"type\":\"{2}\",\"code\":\"{1}\"}},\"state\":\"closed\",\"children\":[]}}", m.RegionName, m.RegionId, Architectures.REGION);
                    if (mIndex != mCount)
                    {
                        builder.Append(",");
                    }
                }
            }
            builder.Append("]");
            return builder.ToString();
        }

        public string ToNavBar(bool hasLink)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                if (hasLink)
                {
                    builder.AppendFormat("<a href='#'type='{1}' code='{2}'>{0}</a>", this.CityName, Architectures.CITY, this.CityId);
                    return builder.ToString();
                }
                return this.CityName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ToSearchMenu()
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("<div name='{0}' value='0'>所有楼盘</div>", Architectures.CITY);
                builder.AppendFormat("<div name='{2}' value='{0}'>{1}</div>", this.CityId, this.CityName, Architectures.CITY);
                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ToTitle()
        {
            return ToNavBar(false);
        }
    }
}
