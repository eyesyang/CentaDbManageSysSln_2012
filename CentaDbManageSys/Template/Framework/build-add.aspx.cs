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

namespace CentaDbManageSys.Template.Framework
{
    public partial class build_add : BaseTemplate
    {
        public EstateFw Estate
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
                    EstateFwService estateService = new EstateFwService();
                    this.Estate = estateService.GetEstateById(estateId);
                }
                else
                {
                    //AddData                    
                    string buildName = ConvertUtility.Trim(Request.Form["buildName"]);
                    string address = ConvertUtility.Trim(Request.Form["address"]);
                    int x_cnt = ConvertUtility.ToInt(Request.Form["x_cnt"]);
                    bool x_except = ConvertUtility.ToBoolean(Request.Form["x_except"]);
                    int y_cnt_b = ConvertUtility.ToInt(Request.Form["y_cnt_b"]);
                    int y_cnt_e = ConvertUtility.ToInt(Request.Form["y_cnt_e"]);
                    bool y_except = ConvertUtility.ToBoolean(Request.Form["y_except"]);

                    BuildFwService buildService = new BuildFwService();
                    if (buildService.AddBuild(estateId, buildName,address,x_cnt,x_except,y_cnt_b,y_cnt_e,y_except))
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
