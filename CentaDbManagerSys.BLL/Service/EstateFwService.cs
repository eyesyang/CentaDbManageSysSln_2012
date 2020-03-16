using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CentaDbManageSys.DAL;
using CentaDbManageSys.Model;
using CentaLine.Common;

namespace CentaDbManageSys.BLL
{
    /// <summary>
    /// AgencyCom Estate Service
    /// </summary>
    public class EstateFwService
    {
        private string _ClassMsg = "Class: EstateService; NameSpace: CentaDbManageSys.BLL; Source File: EstateService.cs";

        private EstateFwDbService _DbService = null;

        private UserInfo _Member = null;

        public EstateFwService()
        {
            _DbService = new EstateFwDbService();

            MemberService memberService = new MemberService();
            this._Member = memberService.GetUserInfo();
        }
        
        public EstateFw GetEstateById(string estateId)
        {
            string funMsg = "Function: GetEstateById(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                EstateFwType centaEstateType = GetEstateTypeById(estateId);
                if (centaEstateType == null)
                {
                    return null;
                }
                return new EstateFw(centaEstateType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EstateFwType GetEstateTypeById(string estateId)
        {
            string funMsg = "Function: GetEstateById<T>(string estateId);" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetEstate(estateId);
                if (row == null)
                {
                    return null;
                }
                return new EstateFwType(row);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        public IList<EstateFwType> GetEstateByType(string type, string code, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "Function: GetEstateByType(string type, string code, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListEstate(type, code, pageIndex, pageSize, out recordCount);
                if (table != null && table.Rows.Count > 0)
                {
                    List<EstateFwType> estateCollection = new List<EstateFwType>();
                    foreach (DataRow row in table.Rows)
                    {
                        estateCollection.Add(new EstateFwType(row));
                    }
                    return estateCollection;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Completed(string estateId)
        {
            string funMsg = "Function: Completed(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.Completed(estateId, this._Member.UserId);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Edit(string estateId, string estateName, string address)
        {
            string funMsg = "Function: Edit(string estateId,string estateName, string address)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.UpdateEstate(estateId, estateName, address, this._Member.UserId);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ImportEstate(EstateFwType estateFwType)
        {
            string funMsg = "function: ImportEstate(EstateCtType estateType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                estateFwType.CreateBy = "System.Console";
                int effected = _DbService.ImportEstate(estateFwType);
                return effected > 0;                
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public List<EstateFwType> ListOrderStatus()
        {
            string funMsg = "function: ListOrderStatus()" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListOrderStatus();
                List<EstateFwType> result = new List<EstateFwType>();
                foreach (DataRow row in table.Rows)
                {
                    result.Add(new EstateFwType(row));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateFlowStatus(string estateId, int flowStatus)
        {
            string funMsg = "function: UpdateFlowStatus(string estateId, int flowStatus)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.UpdateFlowStatus(estateId, flowStatus);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstateFwType GetEstateByCm(string agencyCom_EstateId)
        {
            string funMsg = "function: GetEstateByCm(string agencyCom_EstateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetEstateByCm(agencyCom_EstateId);
                if (row!=null)
                {
                    return new EstateFwType(row);
                }
                return null;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
