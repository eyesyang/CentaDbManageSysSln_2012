using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CentaDbManageSys.Model;
using CentaLine.Common;
using CentaDbManageSys.BLL;

namespace CentaDbManageSys.Template.Collect
{
    public partial class unit_refresh : BaseTemplate
    {
        public UnitCtType[,] model
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

                    UnitCtService unitService = new UnitCtService();
                    List<string> rows = unitService.ListFloor(buildId);
                    List<string> cols = unitService.ListRoom(buildId);
                    IList<UnitCtType> unit_all = unitService.ListUnit(buildId);

                    this.Rows = rows;
                    this.Columns = cols;
                    this.model = new UnitCtType[rows.Count, cols.Count];

                    string floor = string.Empty;
                    string room = string.Empty;
                    for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < cols.Count; colIndex++)
                        {
                            floor = rows[rowIndex];
                            room = cols[colIndex];
                            UnitCtType unit_floor = unit_all.ToList().Find(m => m.CX_Axis.Equals(room) && m.CY_Axis.Equals(floor));
                            if (unit_floor != null)
                            {
                                this.model[rowIndex, colIndex] = unit_floor;
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