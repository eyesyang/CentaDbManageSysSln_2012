using System;
using System.Data;
using System.Text;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.BLL
{
    public class Scope:ScopeType
    {
        public Region Region
        {
            get;
            set;
        }      
        
        public Scope(string scopeId) 
        {         
            this.ScopeId = scopeId;
            this.Region = GetRegion();           
        }     

        private Region GetRegion()
        {
            ScopeType scopeType = ScopeService.Init().ScopeCollection.Find(m => m.ScopeId == this.ScopeId);
            this.RegionId = scopeType.RegionId;           
            this.ScopeName = scopeType.ScopeName;
            return new Region(scopeType.RegionId);
        }

        public string ToTree()
        {
            return string.Empty;
        }
        public string ToNavBar(bool hasLink)
        {
            try
            {
            	if(!string.IsNullOrEmpty(this.RegionId))
                {                    
                    StringBuilder builder = new StringBuilder();
                    builder.Append(this.Region.ToNavBar(true));
                    if (hasLink)
                    {
                        builder.AppendFormat("><a href='#' type='{2}' code='{1}'>{0}</a>", this.ScopeName, this.ScopeId, Architectures.SCOPE);
                    }
                    else
                    {
                        builder.AppendFormat(">{0}", this.ScopeName);
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
                builder.Append(this.Region.ToSearchMenu());
                builder.AppendFormat("<div name='{2}' value='{0}'>{1}</div>", this.ScopeId, this.ScopeName, Architectures.SCOPE);
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
                if (!string.IsNullOrEmpty(this.RegionId))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(this.Region.ToTitle());
                    builder.AppendFormat(" {0}", this.ScopeName);
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
