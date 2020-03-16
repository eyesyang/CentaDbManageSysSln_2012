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
    public class EstateCmService
    {
        private string _ClassMsg = "Class: EstateService; NameSpace: CentaDbManageSys.BLL; Source File: EstateService.cs";

        private EstateCmDbService _DbService = null;

        public EstateCmService()
        {
            _DbService = new EstateCmDbService();
        }

        public EstateCm GetEstateById(string estateId)
        {
            string funMsg = "Function: GetEstateById(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                EstateCmType centaEstateType = GetEstateTypeById(estateId);
                if(centaEstateType==null)
                {
                    return null;
                }
                return new EstateCm(centaEstateType);
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public EstateCmType GetEstateTypeById(string estateId)
        {
            string funMsg = "Function: GetEstateById<T>(string estateId);" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetEstate(estateId);
                if(row==null)
                {
                    return null;
                }
                return new EstateCmType(row);               
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }       
        public IList<EstateCmType> GetEstateByType(string type, string code, int pageIndex, int pageSize, out int recordCount)
        {
            string funMsg = "Function: GetEstateByType(string type, string code, int pageIndex, int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;            
            try
            {
                DataTable table = _DbService.ListEstate(type, code, pageIndex, pageSize, out recordCount);
                if (table != null && table.Rows.Count > 0)
                {
                    List<EstateCmType> estateCollection = new List<EstateCmType>();
                    foreach(DataRow row in table.Rows)
                    {                        
                        estateCollection.Add(new EstateCmType(row));
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

        public bool SaveOrder(string[] estateId, string createBy)
        {
            string funMsg = "function: Save(string[] estateId, string createBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = 0;
            	if(estateId!=null && estateId.Length>0)
                {
                    foreach(var item in estateId)
                    {
                        effected += _DbService.InsertOrder(item, createBy);
                    }
                }
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public OrderType GetOrder(string estateId)
        {
            string funMsg = "function: GetOrder(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                if (!string.IsNullOrEmpty(estateId))
                {
                    DataRow row = _DbService.GetOrder(estateId);
                    if (row != null)
                    {
                        return new OrderType(row);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public List<OrderType> ListOrder(int banch,int orderStatus)
        {
            string funMsg = "function: ListOrder(int banch,int orderStatus)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListOrder(banch, orderStatus);
                List<OrderType> orderCollection = new List<OrderType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        orderCollection.Add(new OrderType(row));
                    }
                }
                return orderCollection;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }


        public bool UpdateOrderStatus(string estateId, int orderStatus)
        {
            string funMsg = "function: UpdateOrderStatus(string estateId,int orderStatus)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.UpdateOrderStatus(estateId, orderStatus);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ComparedEstateType GetComparedEstate(string estateId)
        {
            string funMsg = "function: GetComparedEstate(string estateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row= _DbService.GetComparedEstate(estateId);
                if(row!=null)
                {
                    ComparedEstateType estateType = new ComparedEstateType(row);
                    return estateType;
                }
                return null;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public bool InsertComparedEstate(EstateCmType b, EstateFwType c, int p)
        {
            string funMsg = "function: InsertComparedEstate(EstateCmType b, EstateFwType c, int p)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.InsertComparedEstate(b, c, p);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public ComparedEstateType GetComparedEstateByFw(string framework_EstateId)
        {
            string funMsg = "function: GetComparedEstateByFw(string framework_EstateId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetComparedEstateByFw(framework_EstateId);
                if (row==null)
                {
                    return null;
                }
                return new ComparedEstateType(row);
            }
            catch (Exception ex)
            {
            	throw ex;	
            }
        }
    }
}
