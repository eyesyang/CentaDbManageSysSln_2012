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

namespace CentaDbManageSys.Template.Framework
{
    public partial class unit_edit :BaseTemplate
    {
        public UnitFw Unit
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string httpMehtod = Request.HttpMethod;
                UnitFwService unitService = new UnitFwService();
                string unitId = ConvertUtility.Trim(Request.QueryString["id"]);
                if (httpMehtod.Equals("get", StringComparison.OrdinalIgnoreCase))
                {                   
                    this.Unit = unitService.GetUnit(unitId);
                }
                else
                {                          
                    float area = ConvertUtility.ToFloat(Request.Form["area"]);
                    int countf = ConvertUtility.ToInt(Request.Form["countf"]);
                    int countt = ConvertUtility.ToInt(Request.Form["countt"]);
                    int countw = ConvertUtility.ToInt(Request.Form["countw"]);
                    int county = ConvertUtility.ToInt(Request.Form["county"]);
                    string direction = ConvertUtility.Trim(Request.Form["directionTo"]);
                    if (unitService.UpdateUnit(unitId,countf,countt,countw,county,direction,area))
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
