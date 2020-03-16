using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentaDbManageSys.BLL;
using CentaLine.Common;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.Template.Framework
{
    public partial class estate_refresh : BaseTemplate
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EstateFwService estateService = new EstateFwService();
                int recordCount;
                string type = ConvertUtility.Trim(Request.QueryString["type"]);
                string code = ConvertUtility.Trim(Request.QueryString["code"]);
                int pageIndex = ConvertUtility.ToInt(Request.QueryString["pageIndex"]);               
                this.PageSize = AppSettings.PageSize;
                this.EstateCollection = estateService.GetEstateByType(type, code, pageIndex, this.PageSize, out recordCount);
                this.RecordCount = recordCount;
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