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
    public class EstateCtService
    {
        private string _ClassMsg = "Class: EstateService; NameSpace: CentaDbManageSys.BLL; Source File: EstateService.cs";

        private EstateCtDbService _DbService = null;

        private UserInfo _Member = null;

        public EstateCtService()
        {
            _DbService = new EstateCtDbService();

            MemberService memberService = new MemberService();
            _Member= memberService.GetUserInfo();
        }

        public EstateCt GetEstateById(string estateId)
        {
            string funMsg = "Function: GetEstateById(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                EstateCtType estateType = GetEstateTypeById(estateId);
                if(estateType==null)
                {
                    return null;
                }
                return new EstateCt(estateType);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public EstateCtType GetEstateTypeById(string estateId)
        {
            string funMsg = "Function: GetEstateById<T>(string estateId);" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetEstate(estateId);
                if(row==null)
                {
                    return null;
                }
                return new EstateCtType(row);               
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }       
        public IList<EstateCtType> GetEstateByType(string type, string code, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "Function: GetEstateByType(string type, string code, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;            
            try
            {
                DataTable table = _DbService.ListEstate(type, code, pageIndex, pageSize, out recordCount);
                if (table != null && table.Rows.Count > 0)
                {
                    List<EstateCtType> estateCollection = new List<EstateCtType>();
                    foreach(DataRow row in table.Rows)
                    {
                        estateCollection.Add(new EstateCtType(row));
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

        public bool ImportEstate(EstateCtType estateCtType)
        {
            string funMsg = "function: ImportEstate(EstateCtType estateCtType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                estateCtType.CreateBy = "System.Console";
                int effected = _DbService.ImportEstate(estateCtType);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public List<EstateCtType> GetCompletedEstate(int banch)
        {
            string funMsg = "function: GetCompletedEstate(int banch)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetCompletedEstate(banch);
                List<EstateCtType> result = new List<EstateCtType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(new EstateCtType(row));
                    }
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

        

        public List<EstateCtType> ListOrderStatus()
        {
            string funMsg = "function: ListOrderStatus()" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListOrderStatus();
                List<EstateCtType> result = new List<EstateCtType>();
                foreach (DataRow row in table.Rows)
                {
                    result.Add(new EstateCtType(row));
                }
                return result;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
    }
}
