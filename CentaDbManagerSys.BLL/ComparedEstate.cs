using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.BLL
{
    public class ComparedEstate : ComparedEstateType
    {
         public Scope Scope
        {
            get;
            set;
        }

         public ComparedEstate(ComparedEstateType estateType)
            : base(estateType)
        {           
            this.Scope = new Scope(this.ScopeId);
        }
         public string ToNavBar(bool hasLink)
         {
             try
             {
                 if (!string.IsNullOrEmpty(this.ScopeId))
                 {
                     var builder = new StringBuilder();
                     builder.Append(this.Scope.ToNavBar(true));
                     if (string.IsNullOrEmpty(this.EstateId))
                     {
                         if (hasLink)
                         {
                             builder.AppendFormat("><a href='#' type='{2}' code='{1}'>{0}</a>", this.Framework_EstateName, this.Framework_EstateId, Architectures.ESTATE);
                         }
                         else
                         {
                             builder.AppendFormat(">{0}", this.Framework_EstateName);
                         }
                     }
                     else
                     {
                         if (hasLink)
                         {
                             builder.AppendFormat("><a href='#' type='{2}' code='{1}'>{0}</a>", this.EstateName, this.EstateId, Architectures.ESTATE);
                         }
                         else
                         {
                             builder.AppendFormat(">{0}", this.EstateName);
                         }
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
    }
}
