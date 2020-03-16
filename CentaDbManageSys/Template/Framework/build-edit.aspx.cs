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
using CentaLine.Common;
using CentaDbManageSys.BLL;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.Template.Framework
{
    public partial class build_edit : BaseTemplate
    {
        public BuildFw Build
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string httpMethod = Request.HttpMethod;
                string buildId = ConvertUtility.Trim(Request.QueryString["id"]);
                BuildFwService buildService = new BuildFwService();
                if (httpMethod.Equals("get", StringComparison.OrdinalIgnoreCase))
                {
                    this.Build = buildService.GetBuild(buildId);
                }
                else
                {
                    //UpdateData
                    string buildName = ConvertUtility.Trim(Request.Form["buildName"]);
                    string address = ConvertUtility.Trim(Request.Form["address"]);
                    if (buildService.UpdateBuild(buildId, buildName,address))
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
