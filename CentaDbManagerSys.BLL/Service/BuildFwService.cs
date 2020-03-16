using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentaLine.Common;
using CentaDbManageSys.DAL;
using CentaDbManageSys.Model;
using System.Data;


namespace CentaDbManageSys.BLL
{
    public class BuildFwService
    {
        private string _ClassMsg = "Class: BuildService; NameSpace: CentaManageSys.BLL; Source File: BuildService.cs";

        private BuildFwDbService _DbService = null;
        private UserInfo _Member = null;

        public BuildFwService()
        {
            this._DbService = new BuildFwDbService();

            MemberService memberService = new MemberService();
            this._Member = memberService.GetUserInfo();
        }
       
        public BuildFw GetBuild(string buildId)
        {
            string funMsg = "Function: GetBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                BuildFwType buildType = GetBuildType(buildId);
                if (buildType == null)
                {
                    return null;
                }
                return new BuildFw(buildType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BuildFwType GetBuildType(string buildId)
        {
            string funMsg = "Function: GetBuildById(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetBuild(buildId);
                if (row == null)
                {
                    return null;
                }
                return new BuildFwType(row);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateBuild(string buildId, string buildName, string address)
        {
            string funMsg = "Function: UpdateBuild(string buildId, string buildName, string address)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.UpdateBuild(buildId,buildName,address,this._Member.UserId);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public IList<BuildFwType> ListBuild(string estateId, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: ListBuild(string estateId, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            DataTable table = _DbService.ListBuild(estateId, pageIndex, pageSize, out recordCount);
            List<BuildFwType> result = new List<BuildFwType>();            
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    result.Add(new BuildFwType(row));
                }
                return result;
            }
            return result;     
        }

        public bool RemoveBuild(string buildId)
        {
            string funMsg = "function: RemoveBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.DeleteBuild(buildId,this._Member.UserId);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public bool Completed(string buildId)
        {
            string funMsg = "function: Completed(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.Completed(buildId, this._Member.UserId);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }


        public bool AddBuild(string estateId, string buildName, string address, int x_cnt, bool x_except, int y_cnt_b, int y_cnt_e, bool y_except)
        {
            string funMsg = "function: AddBuild(string estateId, string buildName, string address, int x_cnt, bool x_except, int y_cnt_b, int y_cnt_e, bool y_except)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = 0;
                effected = _DbService.InsertBuild(estateId, buildName, address, x_cnt, x_except, y_cnt_b, y_cnt_e, y_except, this._Member.UserId);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;	
            }
        }
        public IList<BuildFwType> ListBuildByCm(string agencyCom_EstateId)
        {
            string funMsg = "function: ListBuildByCm(string agencyCom_EstateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListBuildByCm(agencyCom_EstateId);
                List<BuildFwType> result = new List<BuildFwType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(new BuildFwType(row));
                    }
                    return result;
                }
                return result;   
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public IList<BuildFwType> ListBuild(string estateId)
        {
            string funMsg = "function: ListBuild(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int recordCount = 0;
                return ListBuild(estateId, 0, 0, out recordCount);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public bool ImortBuild(BuildFwType buildFwType)
        {
            string funMsg = "function: ImportBuild(BuildFwType buildFwType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                buildFwType.CreateBy = "System.Console";
                int effected = _DbService.ImportBuild(buildFwType);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
    
}
