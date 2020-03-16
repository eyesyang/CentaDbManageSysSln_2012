using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentaDbManageSys.Model;
using CentaLine.Common;
using CentaDbManageSys.BLL;

namespace CentaDbManageSys.Template.Framework
{
    public partial class unit_refresh : BaseTemplate
    {       
        public UnitFwType[,] model
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string buildId = ConvertUtility.Trim(Request.QueryString["id"]);                    

                    var unitService = new UnitFwService();
                    var rows = unitService.ListFloor(buildId);
                    var cols = unitService.ListRoom(buildId);
                    var unitAll = unitService.ListUnit(buildId);

                    this.Rows = rows;
                    this.Columns = cols;
                    this.model = new UnitFwType[rows.Count, cols.Count];

                    for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < cols.Count; colIndex++)
                        {
                            string floor = rows[rowIndex];
                            string room = cols[colIndex];
                            var unitFloor = unitAll.ToList().Find(m => m.CX_Axis.Equals(room) && m.CY_Axis.Equals(floor));
                            if (unitFloor != null)
                            {
                                this.model[rowIndex, colIndex] = unitFloor;
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