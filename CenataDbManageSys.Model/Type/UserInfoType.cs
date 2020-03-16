using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    public class UserInfoType
    {
        public string UserInfoId
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public int StatusInfoId
        {
            get;
            set;
        }
        public int RoleInfoId
        {
            get;
            set;
        }
        
        public DateTime CreateDate
        {
            get;
            set;
        }

        public UserInfoType()
        {

        }
        public UserInfoType(DataRow row)
        {
            this.UserInfoId = ConvertUtility.Trim(row["UserInfoId"]);
            this.UserName = ConvertUtility.Trim(row["UserName"]);
            this.RoleInfoId = ConvertUtility.ToInt(row["RoleInfoId"]);
            this.StatusInfoId = ConvertUtility.ToInt(row["StatusInfoId"]);
            this.CreateDate = ConvertUtility.ToDateTime(row["CreateDate"]);
        }
    }
}
