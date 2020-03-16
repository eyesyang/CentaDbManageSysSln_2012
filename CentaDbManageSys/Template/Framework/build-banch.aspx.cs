using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentaDbManageSys.BLL;
using CentaLine.Common;
using System.Text.RegularExpressions;

namespace CentaDbManageSys.Template.Framework
{
    public partial class build_banch: BaseTemplate
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
                    string buildName1 = ConvertUtility.Trim(Request.Form["buildName_B"]);
                    string buildName2 = ConvertUtility.Trim(Request.Form["buildName_E"]);
                    
                    string buildName = ConvertUtility.Trim(Request.Form["buildName"]);
                    string address = ConvertUtility.Trim(Request.Form["address"]);
                    int x_cnt = ConvertUtility.ToInt(Request.Form["x_cnt"]);
                    bool x_except = ConvertUtility.ToBoolean(Request.Form["x_except"]);
                    int y_cnt_b = ConvertUtility.ToInt(Request.Form["y_cnt_b"]);
                    int y_cnt_e = ConvertUtility.ToInt(Request.Form["y_cnt_e"]);
                    bool y_except = ConvertUtility.ToBoolean(Request.Form["y_except"]);

                    BuildFwService buildService = new BuildFwService();
                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    byte[] b1= encoding.GetBytes(buildName1.ToUpper());
                    byte[] b2 = encoding.GetBytes(buildName2.ToUpper());
                     int c=b2[0]-b1[0];
                     if (c >= 0 && b2[0] < 90 && b1[0] > 64)
                     {
                         for (int idx = b1[0]; idx <= b2[0];idx++ )
                         {
                             char[] name= encoding.GetChars(new byte[] { (byte)idx });
                             buildService.AddBuild(estateId, name[0].ToString() + buildName, address, x_cnt, x_except, y_cnt_b, y_cnt_e, y_except);
                         }
                         Response.Write("true");
                     }
                     else
                     {
                         int buildName_B = ConvertUtility.ToInt(buildName1);
                         int buildName_E = ConvertUtility.ToInt(buildName2);
                         if (buildName_E >= buildName_B)
                         {                             
                             while (buildName_B <= buildName_E)
                             {
                                 buildService.AddBuild(estateId, buildName_B + buildName, address, x_cnt, x_except, y_cnt_b, y_cnt_e, y_except);

                                 buildName_B++;
                                 if (buildName_B > buildName_E)
                                 {
                                     break;
                                 }
                             }
                             Response.Write("true");
                         }
                         else
                         {
                             Response.Write("false");
                         }
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