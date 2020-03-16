using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CentaLine.Common;

namespace CentaDbRaw.Web
{
    public class AppSettings
    {
        public static string DbConn
        {
            get { return ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString; }
        }

        public static int PageSize
        {
            get { return ConvertUtility.ToInt(ConfigurationManager.AppSettings["PageSize"]); }
        }
    }
}