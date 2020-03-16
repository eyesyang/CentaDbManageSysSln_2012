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
using CentaDbManageSys.Model;
using CentaDbManageSys.BLL;
using CentaLine.Common;
using System.Collections.Generic;

namespace CentaDbManageSys.Template.Collect
{
    public partial class unit_add : BaseTemplate
    {
        public BuildCt model
        {
            get;
            set;
        }
        public bool IsSingle
        {
            get;
            set;
        }
        public string Row
        {
            get;
            set;
        }
        public string Col
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

                if(httpMethod.Equals("get", StringComparison.OrdinalIgnoreCase))
                {
                    BuildCtService buildService = new BuildCtService();
                    this.model = buildService.GetBuild(buildId);
                }
                else
                {
                    string x_axis = ConvertUtility.Trim(Request.Form["x_axis"]);
                    string y_axis = ConvertUtility.Trim(Request.Form["y_axis"]);                   
                   
                    UnitCtService unitService = new UnitCtService();                   
                    if (unitService.AddUnit(buildId, x_axis, y_axis, this.UserInfo.UserId))                    
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
