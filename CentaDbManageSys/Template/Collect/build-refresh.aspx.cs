using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentaLine.Common;
using CentaDbManageSys.BLL;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.Template.Collect
{
    public partial class build_refresh : BaseTemplate
    {
        public IList<BuildCtType> BuildCollection
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
                int recordCount;
                string type = ConvertUtility.Trim(Request.QueryString["type"]);
                string estateId = ConvertUtility.Trim(Request.QueryString["code"]);
                int pageIndex = ConvertUtility.ToInt(Request.QueryString["pageIndex"]);
                this.PageSize = AppSettings.PageSize;
                BuildCtService buildService = new BuildCtService();
                this.BuildCollection = buildService.ListBuild(estateId, pageIndex, this.PageSize, out recordCount);
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