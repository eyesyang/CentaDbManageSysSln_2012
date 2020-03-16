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
using CentaDbManageSys.BLL;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.Template
{
    public class BaseTemplate : Page
    { 
        public UserInfo UserInfo
        {
            get;
            set;
        }

        protected override void OnInit(EventArgs e)
        {
            MemberService memberService=new MemberService();
            UserInfo userInfo = memberService.GetUserInfo();
            if (userInfo != null)
            {
                this.UserInfo = userInfo;
                base.OnInit(e);
            }
            else
            {
                memberService.RedirectToLogin();
            }
        }
        protected override void OnError(EventArgs e)
        {
            Exception ex= Server.GetLastError();
            //LogService log = new LogService();
            //log.Error(ex);
            Server.ClearError();
            Response.End();            
        }
    }
}
