using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;
using CentaLine.DataCommon;
using System.Data.SqlClient;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.DAL
{  
    public class BuildCtDbService : BuildDbService
    {
        private string _ClassMsg = "Class: BuildCtDbService; NameSpace: CentaDbManageSys.DAL; Source File: BuildCtDbService.cs";

        public BuildCtDbService()
        {
            if (string.IsNullOrEmpty(base.ConnStr))
            {
                base.ConnStr = AppSettings.CtDbConn;
            }
        }


        public int ImportBuild(BuildCtType buildCtType)
        {
            string funMsg = "function: ImportBuild(BuildCtType buildCtType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string procedure = "spImportBuild";
                return DbUtility.ExecuteNonQueryByProc(procedure, this.ConnStr, new SqlParameter[] {                    
                    new SqlParameter{ ParameterName="@buildName", SqlDbType=SqlDbType.NVarChar, Value=buildCtType.BuildName},
                    new SqlParameter{ ParameterName="@address", SqlDbType=SqlDbType.NVarChar, Value=buildCtType.Address},
                    new SqlParameter{ ParameterName="@operateStatus", SqlDbType=SqlDbType.Int, Value=buildCtType.Operate},
                    new SqlParameter{ ParameterName="@flowStatus", SqlDbType=SqlDbType.Int, Value=buildCtType.Flow},
                    new SqlParameter{ ParameterName="@agencyCom_BuildId", SqlDbType=SqlDbType.Char, Value=buildCtType.AgencyCom_BuildId},
                    new SqlParameter{ ParameterName="@agencyCom_EstateId", SqlDbType=SqlDbType.Char, Value=buildCtType.AgencyCom_EstateId},
                    new SqlParameter{ ParameterName="@agencyCom_BuildName", SqlDbType=SqlDbType.NVarChar, Value=buildCtType.AgencyCom_BuildName},
                    new SqlParameter{ ParameterName="@agencyCom_Address", SqlDbType=SqlDbType.NVarChar, Value=buildCtType.AgencyCom_Address},
                    new SqlParameter{ ParameterName="@createBy", SqlDbType=SqlDbType.Char, Value=buildCtType.CreateBy}                    
                });
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }    
}
