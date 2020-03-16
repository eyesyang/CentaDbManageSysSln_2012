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
    public class CmBuildService
    {
        private string _ClassMsg = "Class: BuildService; NameSpace: CentaManageSys.BLL; Source File: BuildService.cs";

        private CmBuildDbService _BuildDbService = null;


        public CmBuildService()
        {
            this._BuildDbService = new CmBuildDbService();
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

        public BuildCmType GetBuildType(string buildId)
        {
            string funMsg = "Function GetBuildById(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _BuildDbService.GetBuild(buildId);
                return new BuildCmType(row);
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

        public IList<BuildCmType> ListBuild(string estateId, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: ListBuild(string estateId, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
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

        public IList<BuildCmType> ListBuild(string p)
        {
            throw new NotImplementedException();
        }
    }
    public class CtBuildService
    {
        private string _ClassMsg = "Class: BuildService; NameSpace: CentaManageSys.BLL; Source File: BuildService.cs";

        private CtBuildDbService _BuildDbService = null;


        public CtBuildService()
        {
            this._BuildDbService = new CtBuildDbService();
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

        public BuildCmType GetBuildType(string buildId)
        {
            string funMsg = "Function GetBuildById(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _BuildDbService.GetBuild(buildId);
                return new BuildCmType(row);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class FwBuildService
    {
         private string _ClassMsg = "Class: BuildService; NameSpace: CentaManageSys.BLL; Source File: BuildService.cs";

        private FkBuildDbService _BuildDbService = null;


        public FwBuildService()
        {
            this._BuildDbService = new FkBuildDbService();
        }


        public BuildFw GetBuild(string buildId)
        {
            string funMsg = "Function: GetBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                return new BuildFw(GetBuildType(buildId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BuildFwType GetBuildType(string buildId)
        {
            string funMsg = "Function GetBuildById(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _BuildDbService.GetBuild(buildId);
                return new BuildFwType(row);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
