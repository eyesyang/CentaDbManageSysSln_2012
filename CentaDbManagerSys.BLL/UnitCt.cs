using System;
using System.Data;
using System.Text;
using CentaDbManageSys.Model;


namespace CentaDbManageSys.BLL
{
    public class UnitCt :UnitCtType
    {
        public BuildCt Build
        {
            get;
            set;
        }

        public UnitCt(UnitCtType unitType)
            : base(unitType)
        {
            BuildCtService buildService = new BuildCtService();
            this.Build = buildService.GetBuild(this.BuildId);
        }
        public string ToNavBar()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.BuildId))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(this.Build.ToNavBar(true));
                    builder.AppendFormat(">{1}{2}", this.CY_Axis, this.CX_Axis);
                    return builder.ToString();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public string ToTitle()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.BuildId))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(this.Build.ToNavBar(true));
                    builder.AppendFormat(" {1}{2}", this.CY_Axis, this.CX_Axis);
                    return builder.ToString();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }      
        }
    }
}
