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
    public partial class unit_modify :BaseTemplate
    {       
        public string EstateName
        {
            get;
            set;
        }
        public string BuildName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string UnitId
        {
            get;
            set;
        }
        public string UnitCollection
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string httpMehtod = Request.HttpMethod;
                UnitCtService unitService = new UnitCtService();
                if (httpMehtod.Equals("get", StringComparison.OrdinalIgnoreCase))
                {
                    this.UnitId = ConvertUtility.Trim(Request.QueryString["id"]);
                    string[] unitIdCollection = this.UnitId.Split(new string[] { AppSettings.FirstSplit }, StringSplitOptions.RemoveEmptyEntries);

                    if (unitIdCollection != null && unitIdCollection.Length > 0)
                    {
                        List<string> unit = new List<string>();
                        BuildCtService buildService = new BuildCtService();
                        foreach (var item in unitIdCollection)
                        {
                            var centaUnit = unitService.GetUnit("");
                            unit.Add(centaUnit.CY_Axis + centaUnit.CX_Axis);
                            if (string.IsNullOrEmpty(this.EstateName) && string.IsNullOrEmpty(this.BuildName))
                            {
                               
                                var build = buildService.GetBuild(centaUnit.BuildId);
                                this.BuildName = build.BuildName;
                                this.EstateName = build.Estate.EstateName;
                                this.Address = build.Estate.Address;
                            }
                        }
                        this.UnitCollection = string.Join(",", unit.ToArray());
                    }
                }
                else
                {
                    string unitId = ConvertUtility.Trim(Request.Form["unitId"]);
                    string[] unitIdCollection = unitId.Split(new string[] { AppSettings.FirstSplit }, StringSplitOptions.RemoveEmptyEntries);
                    decimal area = ConvertUtility.ToDecimal(Request.Form["area"]);
                    int countf = ConvertUtility.ToInt(Request.Form["countf"]);
                    int countt = ConvertUtility.ToInt(Request.Form["countt"]);
                    int countw = ConvertUtility.ToInt(Request.Form["countw"]);
                    string direction = ConvertUtility.Trim(Request.Form["direction"]);
                    //if (unitService.UpdateUnit(unitIdCollection, area, countf, countt, countw, direction))
                    //{
                    //    Response.Write("true");
                    //}
                    //else
                    //{
                    //    Response.Write("false");
                    //}
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
