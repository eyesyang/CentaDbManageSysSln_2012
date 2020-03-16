using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using CentaLine.Common;
using CentaDbManageSys.Model;
using System.Collections.Generic;
using CentaDbManageSys.BLL;
using System.Text;


namespace CentaDbManageSys.Ajax
{
    ///// <summary>
    ///// Summary description for $codebehindclassname$
    ///// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Area : IHttpHandler
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
                context.Response.Write(GetArea(context));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

        private string GetArea(HttpContext context)
        {
            try
            {
                string type = ConvertUtility.Trim(context.Request.QueryString["type"]);
                string code = ConvertUtility.Trim(context.Request.QueryString["code"]);
                string json = string.Empty;
                if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(code))
                {
                    return json;
                }
                ScopeService service = ScopeService.Init();
                //{p:[{id:'',name:''}],c:[{id:'',name:''}],d:[{id:'',name:''}]}               
                if (type == Architectures.CITY)
                {
                    IList<RegionType> region = service.RegionCollection.FindAll(m => m.CityId.Equals(code));
                    IList<ScopeType> scope = service.ScopeCollection.FindAll(m => m.RegionId.Equals(region[0].RegionId)); ;
                    json = ToJson(null, region, scope);
                }
                else if (type == Architectures.REGION)
                {
                    json = ToJson(null, null, service.ScopeCollection.FindAll(m => m.RegionId.Equals(code)));
                }
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string ToJson(IList<CityType> city, IList<RegionType> region, IList<ScopeType> scope)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("{{'city':{0},'region':{1},'scope':{2}}}", City2Json(city), Region2Json(region), Scope2Json(scope));
                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string Scope2Json(IList<ScopeType> scope)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("[");
                if (scope != null)
                {
                    int count = scope.Count;
                    if (count > 0)
                    {
                        string formatter = "{{'code':'{0}',name:'{1}'}}";
                        int idx = 0;
                        foreach (var item in scope)
                        {
                            idx++;
                            builder.AppendFormat(formatter, item.ScopeId, item.ScopeName);
                            if (idx != count)
                            {
                                builder.Append(",");
                            }
                        }
                    }
                }
                builder.Append("]");
                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string Region2Json(IList<RegionType> region)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("[");
                if (region != null)
                {
                    int count = region.Count;
                    if (count > 0)
                    {
                        string formatter = "{{'code':'{0}',name:'{1}'}}";
                        int idx = 0;
                        foreach (var item in region)
                        {
                            idx++;
                            builder.AppendFormat(formatter, item.RegionId, item.RegionName);
                            if (idx != count)
                            {
                                builder.Append(",");
                            }
                        }
                    }
                }
                builder.Append("]");
                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string City2Json(IList<CityType> city)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("[");
                if (city != null)
                {
                    int count = city.Count;
                    if (count > 0)
                    {
                        string formatter = "{{'code':'{0}',name:'{1}'}}";
                        int idx = 0;
                        foreach (var item in city)
                        {
                            idx++;
                            builder.AppendFormat(formatter, item.CityId, item.CityName);
                            if (idx != count)
                            {
                                builder.Append(",");
                            }
                        }
                    }
                }
                builder.Append("]");
                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
