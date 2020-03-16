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
    public class BuildCtService
    {
        private string _ClassMsg = "Class: BuildService; NameSpace: CentaManageSys.BLL; Source File: BuildService.cs";

        private BuildCtDbService _DbService = null;

        private UserInfo _Member = null;

        public BuildCtService()
        {
            this._DbService = new BuildCtDbService();

            MemberService memberService = new MemberService();
            _Member = memberService.GetUserInfo();
        }


        public BuildCt GetBuild(string buildId)
        {
            string funMsg = "Function: GetBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                return new BuildCt(GetBuildType(buildId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BuildCtType GetBuildType(string buildId)
        {
            string funMsg = "Function GetBuildById(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetBuild(buildId);
                return new BuildCtType(row);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateBuild(string buildId, string buildName, string p)
        {
            throw new NotImplementedException();
        }

        public IList<BuildCtType> ListBuild(string estateId, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: ListBuild(string estateId, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            throw new NotImplementedException();
        }

        public bool RemoveBuild(string id)
        {
            throw new NotImplementedException();
        }

        public bool Complete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Import(string id, string p)
        {
            throw new NotImplementedException();
        }

        public bool AddBuild(string estateId, string buildName, string p)
        {
            throw new NotImplementedException();
        }

        public IList<BuildCtType> ListBuild(string estateId)
        {
            string funMsg = "function: ListBuild(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListBuild(estateId);
                List<BuildCtType> result = new List<BuildCtType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(new BuildCtType(row));
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ImortBuild(BuildCtType buildCtType)
        {
            string funMsg = "function: ImortBuild(BuildCtType buildCtType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                buildCtType.CreateBy = "System.Console";
                int effected = _DbService.ImportBuild(buildCtType);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }    
}
