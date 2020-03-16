using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using CentaDbManageSys.Model;
using CentaLine.Common;
using CentaDbManageSys.BLL;
using System.Collections.Generic;
using System.Text;

namespace CentaDbManageSys.Ajax
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Tree : IRequiresSessionState,IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string type = ConvertUtility.Trim(context.Request.QueryString["type"]);
                string code = ConvertUtility.Trim(context.Request.QueryString["code"]);
                string json = GetJSON(type, code);
                context.Response.Write(json); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetJSON(string type,string code)
        {
            try
            {
                if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(code))
                {
                    List<CityType> cityCollection = ScopeService.Init().CityCollection;
                    StringBuilder builder = new StringBuilder();
                    int mIndex = 0;
                    int mCount = cityCollection.Count;
                    builder.Append("[");
                    foreach (var cityType in cityCollection)
                    {
                        mIndex++;
                        City city= new City(cityType.CityId);
                        builder.AppendFormat("{{\"text\":\"{0}\",\"attributes\":{{\"type\":\"{2}\",\"code\":\"{1}\"}},\"state\":\"closed\"}}", city.CityName, city.CityId, Architectures.CITY);
                        if (mIndex != mCount)
                        {
                            builder.Append(",");
                        }
                    }
                    builder.Append("]");
                    return builder.ToString();
                }               
                if (type == Architectures.CITY)
                {                    
                    City city = new City(code);
                    return city.ToTree();   
                }
                else if (type == Architectures.REGION)
                {
                    Region region = new Region(code);                    
                    return region.ToTree();  
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
