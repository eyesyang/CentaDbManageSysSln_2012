using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CentaLine.Common;

namespace CentaDbManageSys.Compare
{
    public class AppSettings
    {
        public static int Banch
        {
            get
            {
                return ConvertUtility.ToInt(ConfigurationManager.AppSettings["Banch"]);
            }
        }
        public static int Interval
        {
            get
            {
                return ConvertUtility.ToInt(ConfigurationManager.AppSettings["Interval"]);
            }
        }
    }
}
