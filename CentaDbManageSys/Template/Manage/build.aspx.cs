﻿using System;
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
using System.Collections.Generic;
using CentaDbManageSys.Model;
using CentaDbManageSys.BLL;
using CentaLine.Common;
using System.Text;
using System.Web.Services;

namespace CentaDbManageSys.Template.Manage
{
    public partial class build : BaseTemplate
    {
        public string EstateId
        {
            get;
            set;
        }
        public IList<BuildCmType> BuildCollection
        {
            get;
            set;
        }
        public IList<ComparedBuildType> ComparedBuildCollection
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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int recordCount;
                string type = ConvertUtility.Trim(Request.QueryString["type"]);
                string estateId = ConvertUtility.Trim(Request.QueryString["code"]);

                this.EstateId = estateId;
                this.PageSize = AppSettings.PageSize;
                EstateCmService estateService = new EstateCmService();
                EstateCm estate = estateService.GetEstateById(this.EstateId);
                this.TitleBar = estate.ToNavBar(false);
                BuildCmService buildService = new BuildCmService();
                ComparedEstateType comparedEstate= estateService.GetComparedEstate(estateId);
                if (comparedEstate != null)
                {
                    this.ComparedBuildCollection = buildService.ListComparedBuild(comparedEstate, 1, this.PageSize, out recordCount);
                }
                else
                {                    
                    this.BuildCollection = buildService.ListBuild(this.EstateId, 1, this.PageSize, out recordCount);                    
                }
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
        private static string FilterStr(string input, int length)
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
