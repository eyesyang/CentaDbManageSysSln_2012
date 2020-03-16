using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentaDbManageSys.Model;


namespace CentaDbManageSys.BLL
{
    public class ComparedBuild : ComparedBuildType
    {
        public ComparedEstate Estate
        {
            get;
            set;
        }
        public ComparedBuild(ComparedBuildType buildType)
            : base(buildType)
        {
            var service = new EstateCmService();
            this.Estate = !string.IsNullOrEmpty(buildType.EstateId) ? new ComparedEstate(service.GetComparedEstate(this.EstateId)) : new ComparedEstate(service.GetComparedEstateByFw(this.Framework_EstateId));
        }

        public string ToNavBar(bool hasLink)
        {
            try
            {               
                    var builder = new StringBuilder();
                    builder.Append(this.Estate.ToNavBar(true));
                    if (string.IsNullOrEmpty(this.BuildId))
                    {
                        if (hasLink)
                        {
                            builder.AppendFormat("><a href='#' type='{2}' code='{1}'>{0}</a>", this.Framework_BuildName, this.Framework_BuildId, Architectures.BUILD);
                        }
                        else
                        {
                            builder.AppendFormat(">{0}", this.Framework_BuildName);
                        }
                    }
                    else
                    {
                        if (hasLink)
                        {
                            builder.AppendFormat("><a href='#' type='{2}' code='{1}'>{0}</a>", this.BuildName, this.BuildId, Architectures.BUILD);
                        }
                        else
                        {
                            builder.AppendFormat(">{0}", this.BuildName);
                        }
                    }
                    return builder.ToString();  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
