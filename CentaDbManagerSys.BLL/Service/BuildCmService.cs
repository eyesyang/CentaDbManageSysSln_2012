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
    public class BuildCmService
    {
        private string _ClassMsg = "Class: BuildService; NameSpace: CentaManageSys.BLL; Source File: BuildService.cs";

        private BuildCmDbService _DbService = null;


        public BuildCmService()
        {
            this._DbService = new BuildCmDbService();
        }


        public BuildCm GetBuild(string buildId)
        {
            string funMsg = "Function: GetBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                BuildCmType buildType= GetBuildType(buildId);
                if(buildType==null)
                {
                    return null;
                }
                return new BuildCm(buildType);
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
                DataRow row = _DbService.GetBuild(buildId);
                if(row==null)
                {
                    return null;
                }
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
            try
            {
                DataTable table= _DbService.ListBuild(estateId, pageIndex, pageSize, out recordCount);
                List<BuildCmType> result = new List<BuildCmType>();
                if(table!=null && table.Rows.Count>0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(new BuildCmType(row));
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

        public IList<BuildCmType> ListBuild(string estateId)
        {
            string funMsg = "function: ListBuild(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int recordCount;
                return ListBuild(estateId, 0, 0, out recordCount);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public bool InsertComparedBuild(string buildId,string estateId,string buildName,string address,string framework_BuildId,string framework_EstateId,string framework_BuildName,string framework_Address,int statusId)
        {
            string funMsg = "function: InsertComparedBuild(string buildId,string estateId,string buildName,string address,string framework_BuildId,string framework_EstateId,string framework_BuildName,string framework_Address,int statusId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.InsertComparedBuild(buildId, estateId, buildName, address, framework_BuildId, framework_EstateId, framework_BuildName, framework_Address, statusId);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public IList<ComparedBuildType> ListComparedBuild(ComparedEstateType comparedEstate, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "function: ListComparedBuild(ComparedEstateType comparedEstate, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListComparedBuild(comparedEstate, pageIndex, pageSize, out recordCount);
                List<ComparedBuildType> result = new List<ComparedBuildType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(new ComparedBuildType(row));
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public ComparedBuild GetComparedBuild(string buildId)
        {
            string funMsg = "function: GetComparedBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                ComparedBuildType buildType = GetComparedBuildType(buildId);
                if (buildType==null)
                {
                    return null;
                }
                return new ComparedBuild(buildType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ComparedBuildType GetComparedBuildType(string buildId)
        {
            string funMsg = "function: GetComparedBuildType(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetComparedBuild(buildId);
                if(row==null)
                {
                    return null;
                }
                return new ComparedBuildType(row);
            }
            catch (Exception ex)
            {
            	throw ex;	
            }
        }
    }   
}
