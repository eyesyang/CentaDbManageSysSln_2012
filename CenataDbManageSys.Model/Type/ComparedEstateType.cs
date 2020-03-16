using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    public class ComparedEstateType
    {
        public int ComparedId
        {
            get;
            set;
        }
        public string EstateId
        {
            get;
            set;
        }
        public string ScopeId
        {
            get;
            set;
        }
        public string EstateName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Framework_EstateId
        {
            get;
            set;
        }
        public string Framework_ScopeId
        {
            get;
            set;
        }
        public string Framework_EstateName
        {
            get;
            set;
        }
        public string Framework_Address
        {
            get;
            set;
        }
        public string StatusId
        {
            get;
            set;
        }
        public DateTime ComparedDate
        {
            get;
            set;
        }

        public ComparedEstateType()
        {

        }
        public ComparedEstateType(ComparedEstateType estateType)
        {
            this.ComparedId = estateType.ComparedId;
            this.EstateId = estateType.EstateId;
            this.ScopeId = estateType.ScopeId;
            this.EstateName = estateType.EstateName;
            this.Address = estateType.Address;
            this.Framework_EstateId = estateType.Framework_EstateId;
            this.Framework_ScopeId = estateType.Framework_ScopeId;
            this.Framework_EstateName = estateType.Framework_EstateName;
            this.Framework_Address = estateType.Framework_Address;
            this.StatusId = estateType.StatusId;
            this.ComparedDate = estateType.ComparedDate;
        }
        public ComparedEstateType(DataRow row)
        {
            this.ComparedId = ConvertUtility.ToInt(row["ComparedId"]);
            this.EstateId = ConvertUtility.Trim(row["EstateId"]);
            this.ScopeId = ConvertUtility.Trim(row["ScopeId"]);
            this.EstateName = ConvertUtility.Trim(row["EstateName"]);
            this.Address = ConvertUtility.Trim(row["Address"]);
            this.Framework_EstateId = ConvertUtility.Trim(row["Framework_EstateId"]);
            this.Framework_ScopeId = ConvertUtility.Trim(row["Framework_ScopeId"]);
            this.Framework_EstateName = ConvertUtility.Trim(row["Framework_EstateName"]);
            this.Framework_Address = ConvertUtility.Trim(row["Framework_Address"]);
            this.StatusId = ConvertUtility.Trim(row["StatusId"]);
            this.ComparedDate = ConvertUtility.ToDateTime(row["ComparedDate"]);
        }
    }
}
