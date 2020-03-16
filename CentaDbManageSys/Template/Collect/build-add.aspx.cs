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
using System.Web.Services;
using CentaDbManageSys.Model;
using CentaDbManageSys.BLL;
using CentaLine.Common;
using System.Collections.Generic;
using System.Text;

namespace CentaDbManageSys.Template.Collect
{
    public partial class build_add : BaseTemplate
    {
        public EstateCm Estate
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string httpMethod = Request.HttpMethod;
                string estateId = ConvertUtility.Trim(Request.QueryString["id"]);

                if (httpMethod.Equals("get", StringComparison.OrdinalIgnoreCase))
                {
                    EstateCmService estateService = new EstateCmService();
                    this.Estate = estateService.GetEstateById(estateId);
                }
                else
                {
                    //AddData                    
                    string buildName = ConvertUtility.Trim(Request.Form["buildName"]);

                    BuildCtService buildService = new BuildCtService();

                    if (buildService.AddBuild(estateId, buildName,this.UserInfo.UserId))
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
