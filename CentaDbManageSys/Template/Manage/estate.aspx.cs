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

namespace CentaDbManageSys.Template.Manage
{
    public partial class estate : BaseTemplate
    {        
        public IList<EstateCmType> EstateCollection
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
                EstateCmService estateService = new EstateCmService();

                int recordCount;

                string type = ConvertUtility.Trim(Request.QueryString["type"]);
                string code = ConvertUtility.Trim(Request.QueryString["code"]);

                this.Type = type;
                this.Code = code;
                this.TitleBar = GetTitleBar(this.Type, this.Code);
                this.PageSize = AppSettings.PageSize;
                IList<EstateCmType> estateCollection = estateService.GetEstateByType(this.Type, this.Code, 1, this.PageSize, out recordCount);
                this.RecordCount = recordCount;
                this.EstateCollection = new List<EstateCmType>();
                if (estateCollection != null && estateCollection.Count > 0)
                {
                    foreach (var item in estateCollection)
                    {
                        EstateCmType estateType = item;
                        OrderType orderType = estateService.GetOrder(item.EstateId);
                        if (orderType != null)
                        {
                            estateType.IsOrder = true;
                            estateType.OrderStatus = orderType.StatusId;
                            if (estateType.OrderStatus == OrderStatus.COMPARED)
                            {
                                estateType.CompareDate = estateService.GetComparedEstate(estateType.EstateId).ComparedDate;
                            }
                        }
                        this.EstateCollection.Add(estateType);
                    }
                }
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
        public static bool Save(string id)
        {
            try
            {
                string[] estateId = id.Split(new string[] { AppSettings.FirstSplit }, StringSplitOptions.RemoveEmptyEntries);
                EstateCmService estateService = new EstateCmService();
                MemberService memberService = new MemberService();
                string createBy = memberService.GetUserInfo().UserId;
                return estateService.SaveOrder(estateId,createBy);                
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
