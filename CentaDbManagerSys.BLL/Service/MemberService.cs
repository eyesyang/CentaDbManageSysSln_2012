using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentaLine.Common;
using CentaDbManageSys.Model;
using CentaDbManageSys.DAL;
using System.Web;
using System.Data;
using System.IO;

namespace CentaDbManageSys.BLL
{
    public class MemberService
    {
        private readonly string _ClassMsg = "Class: MemberService; NameSpace: CentaDbManageSys.BLL; Source File: MemberService.cs";

        private MemberDbService _DbService = null;

        public MemberService()
        {
            _DbService = new MemberDbService();
        }       
        
        public UserInfo GetUserInfo()
        {
            string funMsg = "Function: IsLogin()" + FileUtility.NewLine + _ClassMsg;
            try
            {
                UserInfo userInfo = SessionUtility.Get<UserInfo>(SessionNames.USERINFO);
                return userInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void WriteVerifyCode(string content)
        {
            string funMsg = "Function: WriteVerifyCode(string content);" + FileUtility.NewLine + _ClassMsg;
            try
            {
                SessionUtility.Set(SessionNames.VERIFYCODE, content);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        private string ReadVerifyCode()
        {
            string funMsg = "Function: ReadVerifyCode();" + FileUtility.NewLine + _ClassMsg;
            try
            {
                return SessionUtility.Get<string>(SessionNames.VERIFYCODE);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public bool Login(string userName, string password, string verifyCode)
        {
            string funMsg = "Function: Login(string userName, string password, string verifyCode)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(verifyCode))
                {
                    return false;
                }
                if (!verifyCode.Equals(ReadVerifyCode(), StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                DataRow row = _DbService.GetDataRow(userName);
                if (row == null)
                {
                    return false;
                }
                UserInfo userInfo = new UserInfo(new UserInfoType(row));
                userInfo.ToCookie();
                userInfo.ToSession();              
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
        public void RedirectToLogin()
        {
            Uri uri = HttpContext.Current.Request.Url;
            string url = "http://" + uri.Host;
            url += uri.Port == 80 ? "" : ":" + uri.Port;
            url += "/login.aspx";
            HttpContext.Current.Response.Write("<script>window.location='" + url + "';</script>");
            HttpContext.Current.Response.End();               
        }
    }
}
