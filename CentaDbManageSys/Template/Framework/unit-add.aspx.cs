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
    public partial class unit_add : BaseTemplate
    {
        public BuildFw Build
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
                    BuildFwService buildService = new BuildFwService();
                    this.Build = buildService.GetBuild(buildId);
                }
                else
                {
                    int x_axis_c = ConvertUtility.ToInt(Request.Form["x_axis"]);
                    string x_axis_t = ConvertUtility.Trim(Request.Form["x_axis_t"]);
                    bool x_axis_except = ConvertUtility.ToBoolean(Request.Form["x_axis_except"]);

                    int y_axis_b = ConvertUtility.ToInt(Request.Form["y_axis_b"]);
                    int y_axis_e = ConvertUtility.ToInt(Request.Form["y_axis_e"]);
                    bool y_axis_except = ConvertUtility.ToBoolean(Request.Form["y_axis_except"]);
                    
                    int countf = ConvertUtility.ToInt(Request.Form["countf"]);
                    int countt = ConvertUtility.ToInt(Request.Form["countt"]);
                    int countw = ConvertUtility.ToInt(Request.Form["countw"]);
                    int county = ConvertUtility.ToInt(Request.Form["county"]);
                    float area = ConvertUtility.ToFloat(Request.Form["area"]);
                    string directionTo = ConvertUtility.Trim(Request.Form["directionTo"]);

                    if (y_axis_b<=y_axis_e)
                    {
                        UnitFwService unitService = new UnitFwService();
                        string x_axis = string.Empty;
                        string y_axis = string.Empty;
                        for (int y = y_axis_b; y <= y_axis_e;y++ )
                        {
                            if (y_axis_except && y.ToString().IndexOf("4")>=0)
                            {
                                continue;
                            }
                            for (int x = 1; x <= x_axis_c; x++)
                            {
                                y_axis = y.ToString();
                                x_axis = x.ToString();
                                if(x_axis_t.Equals("a"))
                                {
                                    int ascii = x + 64;
                                    if(x>90)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                                        char[] chars = encoding.GetChars(new byte[] { (byte)ascii });
                                        x_axis = chars[0].ToString();
                                    }
                                }
                                else
                                {
                                    if(x_axis_except && x.ToString().IndexOf("4")>=0)
                                    {
                                        continue;
                                    }
                                }
                                unitService.AddUnit(buildId, x_axis, y_axis, countf, countt, countw, county, area, directionTo);
                            }
                        }

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
