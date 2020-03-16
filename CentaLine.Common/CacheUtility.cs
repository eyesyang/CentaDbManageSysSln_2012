using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CentaLine.Common
{
    /// <summary>
    /// cache操作类
    /// </summary>
    public class CacheUtility
    {       
        public static T Get<T>(string key)
        {
            try
            {
                object obj= HttpContext.Current.Cache[key];
                if (obj == null)
                {
                    return default(T);
                }
                return (T)obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Set(string key, object value)
        {
            try
            {
                HttpContext.Current.Cache.Insert(key, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Set(string key, object value, System.Web.Caching.CacheDependency dependencies)
        {
            try
            {
                HttpContext.Current.Cache.Insert(key, value, dependencies);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
