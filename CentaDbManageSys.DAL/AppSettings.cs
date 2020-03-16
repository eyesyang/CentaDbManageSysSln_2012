using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CentaLine.Common;

namespace CentaDbManageSys.DAL
{
    public class AppSettings
    {
        /// <summary>
        /// MemberDb ConnectionString
        /// </summary>
        public static string MemberDbConn
        {
            get
            {
                return ConvertUtility.Trim(ConfigurationManager.ConnectionStrings["MemberDbConn"].ConnectionString);
            }
        }
        /// <summary>
        /// AgencyComDb ConnectionString
        /// </summary>
        public static string CmDbConn
        {
            get
            {
                return ConvertUtility.Trim(ConfigurationManager.ConnectionStrings["AgencyComDbConn"].ConnectionString);
            }
        }
        /// <summary>
        /// CollectDb ConnectionString
        /// </summary>
        public static string CtDbConn
        {
            get
            {
                return ConvertUtility.Trim(ConfigurationManager.ConnectionStrings["CollectDbConn"].ConnectionString);
            }
        }
        /// <summary>
        /// FrameworkDb ConnectionString
        /// </summary>
        public static string FwDbConn
        {
            get
            {
                return ConvertUtility.Trim(ConfigurationManager.ConnectionStrings["FrameworkDbConn"].ConnectionString);
            }
        }
    }
}
