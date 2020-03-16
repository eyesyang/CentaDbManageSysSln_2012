using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentaDbManageSys.Model;
using CentaLine.Common;
using CentaDbManageSys.BLL;

namespace CentaDbManageSys.Template.Framework
{
    public partial class estate_edit : System.Web.UI.Page
    {
        public EstateFw Estate
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string estateId = ConvertUtility.Trim(Request.QueryString["id"]);
            string httpMethod = Request.HttpMethod;
            EstateFwService estateService = new EstateFwService();
            if (httpMethod.Equals("get", StringComparison.OrdinalIgnoreCase))
            {                
                this.Estate = estateService.GetEstateById(estateId);
            }
            else
            {
                string estateName = ConvertUtility.Trim(Request.Form["estateName"]);
                string address = ConvertUtility.Trim(Request.Form["address"]);
                if(estateService.Edit(estateId,estateName,address))
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
    }
}