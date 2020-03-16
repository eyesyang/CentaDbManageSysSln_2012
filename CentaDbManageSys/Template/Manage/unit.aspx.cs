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
using System.Collections.Generic;
using CentaLine.Common;
using CentaDbManageSys.BLL;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace CentaDbManageSys.Template.Manage
{
    public partial class Unit : BaseTemplate
    {
        public string BuildId
        {
            get;
            set;
        }
        public UnitCmType[,] UnitArray
        {
            get;
            set;
        }

        public ComparedUnitType[,] ComparedUnitArray
        {
            get;
            set;
        }

        public IList<string> Rows
        {
            get;
            set;
        }
        public IList<string> Columns
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
                if (!IsPostBack)
                {
                    this.BuildId = ConvertUtility.Trim(Request.QueryString["id"]);
                    BuildCmService buildService = new BuildCmService();
                    UnitCmService unitService = new UnitCmService();
                    BuildCm build = buildService.GetBuild(this.BuildId);
                    if (build == null)
                    {
                        ComparedBuild comparedBuild = buildService.GetComparedBuild(this.BuildId);
                        this.TitleBar = comparedBuild.ToNavBar(false);
                        this.BuildId = string.IsNullOrEmpty(comparedBuild.BuildId) ? comparedBuild.Framework_BuildId : comparedBuild.BuildId;
                        this.Rows = unitService.ListComparedFloor(comparedBuild);
                        this.Columns = unitService.ListComparedRoom(comparedBuild);
                        IList<ComparedUnitType> unitCollection = unitService.ListComparedUnit(comparedBuild);

                        this.ComparedUnitArray = new ComparedUnitType[this.Rows.Count, this.Columns.Count];
                       
                        for (int rowIndex = 0; rowIndex < this.Rows.Count; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < this.Columns.Count; colIndex++)
                            {
                                string floor = this.Rows[rowIndex];
                                string room = this.Columns[colIndex];
                                ComparedUnitType comparedUnit = unitCollection.ToList().Find(m => (m.CX_Axis.Equals(room) && m.CY_Axis.Equals(floor)) || (m.Framework_CX_Axis.Equals(room) && m.Framework_CY_Axis.Equals(floor)));
                                if (comparedUnit != null)
                                {
                                    this.ComparedUnitArray[rowIndex, colIndex] = comparedUnit;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.TitleBar = build.ToNavBar(false);
                        this.Rows = unitService.ListFloor(this.BuildId);
                        this.Columns = unitService.ListRoom(this.BuildId);
                        IList<UnitCmType> unitCollection = unitService.ListUnit(this.BuildId);

                        this.UnitArray = new UnitCmType[this.Rows.Count, this.Columns.Count];
                       
                        for (int rowIndex = 0; rowIndex < this.Rows.Count; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < this.Columns.Count; colIndex++)
                            {
                                string floor = this.Rows[rowIndex];
                                string room = this.Columns[colIndex];
                                UnitCmType unitType = unitCollection.ToList().Find(m => m.CX_Axis.Equals(room) && m.CY_Axis.Equals(floor));
                                if (unitType != null)
                                {
                                    this.UnitArray[rowIndex, colIndex] = unitType;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }             
    }
}
