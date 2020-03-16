using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CentaLine.Common
{
    /// <summary>
    /// session操作类
    /// </summary>
    public class SessionUtility
    {
        public static T Get<T>(string key)
        {
            try
            {
                if (HttpContext.Current==null || HttpContext.Current.Session == null)
                {
                    return default(T);
                }
                object obj = HttpContext.Current.Session[key];
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
                HttpContext.Current.Session[key] = value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Remove(string key)
        {
            try
            {
                HttpContext.Current.Session.Remove(key);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public static void RemoveAll()
        {
            try
            {
                HttpContext.Current.Session.RemoveAll();
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
