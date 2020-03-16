using System;
using System.Data;
using System.Text;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.BLL
{
    public class EstateCm : EstateCmType
    {
        public Scope Scope
        {
            get;
            set;
        }
       
        public EstateCm(EstateCmType centaEstateType)
            : base(centaEstateType)
        {           
            this.Scope = new Scope(this.ScopeId);
        }     
       
        public string ToTree()
        {
            return string.Empty;
        }
        public string ToNavBar(bool hasLink)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.ScopeId))
                {
                    var builder = new StringBuilder();
                    builder.Append(this.Scope.ToNavBar(true));

                    if (hasLink)
                    {
                        builder.AppendFormat("><a href='#' type='{2}' code='{1}'>{0}</a>", this.EstateName, this.EstateId, Architectures.ESTATE);
                    }
                    else
                    {
                        builder.AppendFormat(">{0}", this.EstateName);
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
                if (!string.IsNullOrEmpty(this.ScopeId))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(this.Scope.ToTitle());
                    builder.AppendFormat(" {0}", this.EstateName);
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
                return this.Scope.ToSearchMenu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
