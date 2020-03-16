using System;
using System.Web;

namespace CentaLine.Common
{
    /// <summary>
    /// cookie操作类
    /// </summary>
    public class CookieUtility
    {
        public static string Get(string key)
        {
            try
            {
                HttpCookie cookie= HttpContext.Current.Request.Cookies[key];
                if(cookie==null)
                {
                    return string.Empty;
                }
                return cookie.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Set(string key, string value)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(key);
                cookie.Value = value;  
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Set(string key, string value, DateTime expires)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(key);
                cookie.Value = value;
                cookie.Expires = expires;
                HttpContext.Current.Response.Cookies.Add(cookie);
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
                HttpCookie cookie = new HttpCookie(key);
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
