using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using CentaLine.Common;

namespace CentaDbRaw.Web.Models
{

    [Serializable]
    public class CentaBuildType
    {
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int CentaBuildId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string centaest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cestcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string centabldg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cblgcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? lpt_x { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? lpt_y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string usage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string c_estate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string e_estate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string c_phase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string e_phase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string c_property { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string e_property { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pc_addr1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pc_addr2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pe_addr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string opdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? unit_cnt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? x_cnt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? y_cnt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string scp_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string scp_c { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string scp_e { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string scp_mkt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? nmark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string o_estateid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string o_bldgid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string estateid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string buildingid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? moddate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pc_street1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pc_street2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pe_street1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pe_street2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pc_stno1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pc_stno2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ppt_rank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string org_cenblg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string org_cenest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string need_clear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string x_axis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string x_axis2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string y_axis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string y_axis2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cblk_key { get; set; }

        #endregion Model

        #region Constructor
        public CentaBuildType()
        {
        }
        public CentaBuildType(DataRow row)
        {

            this.CentaBuildId = ConvertUtility.ToInt(row["CentaBuildId"]);

            this.centaest = ConvertUtility.Trim(row["centaest"]);

            this.cestcode =  ConvertUtility.Trim(row["cestcode"]);

            this.centabldg = ConvertUtility.Trim(row["centabldg"]);

            this.cblgcode = ConvertUtility.Trim(row["cblgcode"]);

            this.lpt_x = ConvertUtility.ToDecimal(row["lpt_x"]);

            this.lpt_y = ConvertUtility.ToDecimal(row["lpt_y"]);

            this.usage = ConvertUtility.Trim(row["usage"]);

            this.c_estate = ConvertUtility.Trim(row["c_estate"]);

            this.e_estate = ConvertUtility.Trim(row["e_estate"]);

            this.c_phase = ConvertUtility.Trim(row["c_phase"]);

            this.e_phase = ConvertUtility.Trim(row["e_phase"]);

            this.c_property = ConvertUtility.Trim(row["c_property"]);

            this.e_property = ConvertUtility.Trim(row["e_property"]);

            this.pc_addr1 = ConvertUtility.Trim(row["pc_addr1"]);

            this.pc_addr2 = ConvertUtility.Trim(row["pc_addr2"]);

            this.pe_addr =  ConvertUtility.Trim(row["pe_addr"]);

            this.opdate = ConvertUtility.Trim(row["opdate"]);

            this.unit_cnt = ConvertUtility.ToDecimal(row["unit_cnt"]);

            this.x_cnt = ConvertUtility.ToDecimal(row["x_cnt"]);

            this.y_cnt = ConvertUtility.ToDecimal(row["y_cnt"]);

            this.scp_id = ConvertUtility.Trim(row["scp_id"]);

            this.scp_c = ConvertUtility.Trim(row["scp_c"]);

            this.scp_e = ConvertUtility.Trim(row["scp_e"]);

            this.scp_mkt = ConvertUtility.Trim(row["scp_mkt"]);

            this.nmark = ConvertUtility.ToInt(row["nmark"]);

            this.o_estateid = ConvertUtility.Trim(row["o_estateid"]);

            this.o_bldgid = ConvertUtility.Trim(row["o_bldgid"]);

            this.estateid = ConvertUtility.Trim(row["estateid"]);

            this.buildingid = ConvertUtility.Trim(row["buildingid"]);

            this.address = ConvertUtility.Trim(row["address"]);

            this.moddate = ConvertUtility.ToDateTime(row["moddate"]);

            this.pc_street1 = ConvertUtility.Trim(row["pc_street1"]);

            this.pc_street2 = ConvertUtility.Trim(row["pc_street2"]);

            this.pe_street1 = ConvertUtility.Trim(row["pe_street1"]);

            this.pe_street2 = ConvertUtility.Trim(row["pe_street2"]);

            this.pc_stno1 = ConvertUtility.Trim(row["pc_stno1"]);

            this.pc_stno2 = ConvertUtility.Trim(row["pc_stno2"]);

            this.ppt_rank = ConvertUtility.ToInt(row["ppt_rank"]);

            this.org_cenblg = ConvertUtility.Trim(row["org_cenblg"]);

            this.org_cenest = ConvertUtility.Trim(row["org_cenest"]);

            this.need_clear = ConvertUtility.Trim(row["need_clear"]);

            this.x_axis = ConvertUtility.Trim(row["x_axis"]);

            this.x_axis2 = ConvertUtility.Trim(row["x_axis2"]);

            this.y_axis = ConvertUtility.Trim(row["y_axis"]);

            this.y_axis2 = ConvertUtility.Trim(row["y_axis2"]);

            this.cblk_key = ConvertUtility.Trim(row["cblk_key"]);

        }

        #endregion
    }
}