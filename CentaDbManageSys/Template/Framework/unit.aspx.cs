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

namespace CentaDbManageSys.Template.Framework
{
    public partial class Unit : BaseTemplate
    {
        public string BuildId
        {
            get;
            set;
        }
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
                    BuildFwService buildService = new BuildFwService();
                    BuildFw build = buildService.GetBuild(this.BuildId);
                    this.TitleBar = build.ToNavBar(false);

                    UnitFwService unitService = new UnitFwService();
                    List<string> rows = unitService.ListFloor(this.BuildId);
                    List<string> cols = unitService.ListRoom(this.BuildId);
                    IList<UnitFwType> unit_all = unitService.ListUnit(this.BuildId);

                    this.Rows = rows;
                    this.Columns = cols;
                    this.model = new UnitFwType[rows.Count, cols.Count];

                    string floor = string.Empty;
                    string room = string.Empty;
                    for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < cols.Count; colIndex++)
                        {
                            floor = rows[rowIndex];
                            room = cols[colIndex];
                            UnitFwType unit_floor = unit_all.ToList().Find(m => m.CX_Axis.Equals(room) && m.CY_Axis.Equals(floor));
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

        [WebMethod(true)]
        public static bool Remove(string id)
        {
            try
            {               
                UnitFwService service = new UnitFwService();
                string[] unit = id.Split(new string[] { Seperator.FirstChar }, StringSplitOptions.RemoveEmptyEntries);
                int effected = 0;
                foreach (var item in unit)
                {
                    if (service.DeleteUnit(item))
                    {
                        effected++;
                    }
                }
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod(true)]
        public static bool Fill(string id, string cx_axis, string cy_axis)
        {
            try
            {
                MemberService memberService = new MemberService();               
                string createBy = memberService.GetUserInfo().UserId;
                UnitFwService service = new UnitFwService();
                if (service.AddUnit(id,cx_axis,cy_axis))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod(true)]
        public static bool Standard(string id)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        [WebMethod(true)]
        public static bool Undo(string id)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
