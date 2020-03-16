using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CentaLine.Common;
using System.Collections.Generic;
using CentaDbManageSys.Model;

namespace CentaDbManageSys
{
    public class AppSettings
    { 
        public static int PageSize
        {
            get
            {
                return ConvertUtility.ToInt(ConfigurationManager.AppSettings["PageSize"]);
            }
        }
        public static string BaseUrl
        {
            get
            {
                string url = ConvertUtility.Trim(ConfigurationManager.AppSettings["BaseUrl"]);
                if (url.EndsWith("/"))
                {
                    return url;
                }
                return url + "/";
            }
        }
        public static string PreviewImgFolder
        {
            get
            {
                return ConvertUtility.Trim(ConfigurationManager.AppSettings["PreviewImgFolder"]);
            }
        }
        public static string PreviewLogFolder
        {
            get
            {
                return ConvertUtility.Trim(ConfigurationManager.AppSettings["PreviewLogFolder"]);
            }
        }
        public static int IntervalDay
        {
            get
            {
                return ConvertUtility.ToInt(ConfigurationManager.AppSettings["IntervalDay"]);
            }
        }
        public static string FirstSplit
        {
            get
            {
                return ConvertUtility.Trim(ConfigurationManager.AppSettings["FirstSplit"]);
            }
        }
        public static string SecondSplit
        {
            get
            {
                return ConvertUtility.Trim(ConfigurationManager.AppSettings["SecondSplit"]);
            }
        }
    }
}
