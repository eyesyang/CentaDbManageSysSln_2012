using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentaDbManageSys.BLL;
using CentaLine.Common;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.Template.Manage
{
    public partial class estate_refresh : BaseTemplate
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EstateCmService estateService = new EstateCmService();
                int recordCount;
                string type = ConvertUtility.Trim(Request.QueryString["type"]);
                string code = ConvertUtility.Trim(Request.QueryString["code"]);
                int pageIndex = ConvertUtility.ToInt(Request.QueryString["pageIndex"],1);               
                this.PageSize = AppSettings.PageSize;
                IList<EstateCmType> estateCollection = estateService.GetEstateByType(type, code, pageIndex, this.PageSize, out recordCount);
                this.RecordCount = recordCount;
                this.EstateCollection = new List<EstateCmType>();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }      
        public string StrFilter(string input, int length)
        {
            try
            {
                if (input.Length > length)
                {
                    input = input.Substring(0, length);
                }
                return input;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}