using System;
using System.Collections;
using System.Configuration;
using System.Data;
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


namespace CentaDbManageSys
{
    public partial class Main : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            
        }
        public string GetScript()
        {
            string script = string.Empty;
            MemberService memberService = new MemberService();
            UserInfo userInfo= memberService.GetUserInfo();
            switch(userInfo.Role)
            {
                case MemberRole.Collecter:
                    {
                        script = "<script src=\"Content/js/main-ct.js\" type=\"text/javascript\"></script>";
                        break;
                    }
                case MemberRole.Frameworker:
                    {
                        script = "<script src=\"Content/js/main-fw.js\" type=\"text/javascript\"></script>";
                        break;                            
                    }
                case MemberRole.Manager:
                    {
                        script = "<script src=\"Content/js/main-cm.js\" type=\"text/javascript\"></script>";
                        break; 
                    }
                default:
                    {
                        break;
                    }
            }
            return script;
        }
    }
}
