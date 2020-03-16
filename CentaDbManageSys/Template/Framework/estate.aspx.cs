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
using System.Collections.Generic;
using CentaDbManageSys.Model;
using System.Web.Services;
using System.Text;

namespace CentaDbManageSys.Template.Framework
{
    public partial class estate : BaseTemplate
    {        
        public IList<EstateFwType> EstateCollection
        {
            get;
            set;
        }       
        public int PageSize
        {
            get;
            set;
        }
        public int RecordCount
        {
            get;
            set;
        }

        public string TitleBar
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string Code
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int recordCount;

                string type = ConvertUtility.Trim(Request.QueryString["type"]);
                string code = ConvertUtility.Trim(Request.QueryString["code"]);

                this.Type = type;
                this.Code = code;
                this.TitleBar = GetTitleBar(this.Type, this.Code);
                this.PageSize = AppSettings.PageSize;
                EstateFwService estateService = new EstateFwService();
                IList<EstateFwType> estateCollection = estateService.GetEstateByType(this.Type, this.Code, 1, this.PageSize, out recordCount);
                this.RecordCount = recordCount;
                this.EstateCollection = new List<EstateFwType>();
                this.EstateCollection = estateCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetTitleBar(string type, string code)
        {            
            string titleBar = string.Empty;
            string searchMenu = string.Empty;
            switch(type)
            {
                case Architectures.CITY:
                    {
                        City city = new City(code);
                        titleBar= city.ToNavBar(false);                      
                        break;
                    }
                case Architectures.REGION:
                    {
                        Region region = new Region(code);
                        titleBar =region.ToNavBar(false);                      
                        break;
                    }
                case Architectures.SCOPE:
                    {
                        Scope scope = new Scope(code);
                        titleBar= scope.ToNavBar(false);                       
                        break;
                    }
                case Architectures.BIGESTATE:
                    {
                        EstateCmService estateService = new EstateCmService();
                        EstateCm estate= estateService.GetEstateById(code);
                        titleBar = estate.ToNavBar(false);                      
                        break;
                    }
                default:
                    break;
            }           
            return titleBar;            
        }

        public string StrFilter(string input, int length)
        {
            try
            {
                if (input.Length > length)
                {
                    input= input.Substring(0, length);
                }
                return input;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }           
        [WebMethod]
        public static bool Complete(string id)
        {
            try
            {
                EstateFwService estateService = new EstateFwService();
                bool effected= estateService.Completed(id);
                return effected;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
