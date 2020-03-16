using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.BLL
{
    public class Region : RegionType
    {
        public City City
        {
            get;
            set;
        }
        
        public Region(string regionId)
        {          
            this.RegionId = regionId;
            this.City = GetCity();      
        }     

        private City GetCity()
        {
            RegionType regionType = ScopeService.Init().RegionCollection.Find(m => m.RegionId == this.RegionId);            
            this.CityId = regionType.CityId;
            this.RegionName = regionType.RegionName;
            return new City(regionType.CityId);
        }
        private IList<ScopeType> GetScope()
        {
            if (string.IsNullOrEmpty(RegionId))
            {
                throw new Exception();
            }
            return ScopeService.Init().ScopeCollection.FindAll(m => m.RegionId == this.RegionId);
        }
       
        public string ToTree()
        {
            IList<ScopeType> scp = GetScope();
            StringBuilder builder = new StringBuilder();
            builder.Append("[");

            if (scp != null && scp.Count > 0)
            {
                int idx = 0;
                int count = scp.Count;
                foreach (var n in scp)
                {
                    idx++;
                    builder.AppendFormat("{{\"text\":\"{0}\",\"attributes\":{{\"type\":\"{2}\",\"code\":\"{1}\"}}}}", n.ScopeName, n.ScopeId, Architectures.SCOPE);
                    if (idx != count)
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
                if (!string.IsNullOrEmpty(this.CityId))
                {
                    StringBuilder builder = new StringBuilder();                    
                    builder.Append(this.City.ToNavBar(true));
                    if (hasLink)
                    {
                        builder.AppendFormat("><a href='#' type='{2}' code='{1}'>{0}</a>", this.RegionName, this.RegionId, Architectures.REGION);
                    }
                    else
                    {
                        builder.AppendFormat(">{0}", this.RegionName);
                    }
                    return builder.ToString();
                }
                return string.Empty;
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
                builder.Append(this.City.ToSearchMenu());
                builder.AppendFormat("<div name='{2}' value='{0}'>{1}</div>", this.RegionId, this.RegionName, Architectures.REGION);
                return builder.ToString();
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public string ToTitle()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.CityId))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(this.City.ToTitle());
                    builder.AppendFormat(" {0}", this.RegionName);
                    return builder.ToString();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
