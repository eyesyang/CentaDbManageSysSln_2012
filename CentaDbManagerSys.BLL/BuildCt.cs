using System;
using System.Data;
using System.Text;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.BLL
{
    public class BuildCt : BuildCtType
    {
        public EstateCt Estate
        {
            get;
            set;
        }
        
        public BuildCt(BuildCtType buildType)
            : base(buildType)
        {
            EstateCtService service = new EstateCtService();
            this.Estate = service.GetEstateById(this.EstateId);
        }
        public string ToNavBar(bool hasLink)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.EstateId))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(this.Estate.ToNavBar(true));
                    if (hasLink)
                    {
                        builder.AppendFormat("><a href='#' type='{2}' code='{1}'>{0}</a>", this.BuildName, this.BuildId, Architectures.BUILD);
                    }
                    else
                    {
                        builder.AppendFormat(">{0}", this.BuildName);
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
        public string ToTitle()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.EstateId))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(this.Estate.ToTitle());
                    builder.AppendFormat(" {0}", this.BuildName);
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
