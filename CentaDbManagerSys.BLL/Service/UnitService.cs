using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentaDbManageSys.DAL;
using CentaLine.Common;
using System.Collections;
using System.Data;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.BLL
{
    public class UnitService
    {
        private string _ClassMsg = "Class: UnitService; NameSpace: CentaDbManageSys.BLL; Source File: UnitService";
        private class UnitRowSort : IComparer
        {
            public int Compare(object a, object b)
            {
                string x = ConvertUtility.Trim(a);
                string y = ConvertUtility.Trim(b);
                if (!string.IsNullOrEmpty(x))
                {
                    x = x.Replace("楼", string.Empty);
                }
                if (!string.IsNullOrEmpty(y))
                {
                    y = y.Replace("楼", string.Empty);
                }
                int a_int = ConvertUtility.ToInt(x);
                int b_int = ConvertUtility.ToInt(y);
                return b_int - a_int;
            }
        }
        private class UnitColSort : IComparer
        {
            public int Compare(object a, object b)
            {
                string x = ConvertUtility.Trim(a);
                string y = ConvertUtility.Trim(b);
                string character = "abcdefghijklmnopqrstuvwxyz";

                if (!string.IsNullOrEmpty(x))
                {
                    x = x.Replace("室", string.Empty);
                }
                if (!string.IsNullOrEmpty(y))
                {
                    y = y.Replace("室", string.Empty);
                }
                int a_int = 0;
                int b_int = 0;
                if (character.IndexOf(x.ToLower()) > -1)
                {
                    a_int = ConvertUtility.ToASCIICode(x.ToLower());
                }
                else
                {
                    a_int = ConvertUtility.ToInt(x);
                }
                if (character.IndexOf(y.ToLower()) > -1)
                {
                    b_int = ConvertUtility.ToASCIICode(y.ToLower());
                }
                else
                {
                    b_int = ConvertUtility.ToInt(y);
                }
                return a_int - b_int;
            }
        }

        private UnitDbService _UnitDbService = null;

        public UnitService()
        {

        }

        public UnitService(string connStr)
        {
            this._UnitDbService = new UnitDbService(connStr);
        }

        public UnitService(string collectDbConn, string frameworkDbConn)
        {
            this._UnitDbService = new UnitDbService(collectDbConn, frameworkDbConn);
        }

        public UnitCmType GetUnit(string unitId)
        {
            return null;
        }
        public List<string> ListRoom(string buildId)
        {
            string funMsg = "function: ListRoom(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _UnitDbService.ListRoom(buildId);
                List<string> rs = new List<string>();
                if (table != null && table.Rows.Count > 0)
                {                    
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(ConvertUtility.Trim(row[0]));
                    }
                    UnitColSort sort = new UnitColSort();
                    rs.Sort(sort.Compare);                    
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> ListFloor(string buildId)
        {
            string funMsg = "function: ListFloor(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _UnitDbService.ListFloor(buildId);
                List<string> rs = new List<string>();
                if (table != null && table.Rows.Count > 0)
                {                   
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(ConvertUtility.Trim(row[0]));
                    }
                    UnitRowSort sort = new UnitRowSort();
                    rs.Sort(sort.Compare);                   
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<UnitCmType> ListCollectUnit(string buildId)
        {
            string funMsg = "Function: ListCollectUnit(int buildId, string connStr)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _UnitDbService.ListCollectUnit(buildId);
                List<UnitCmType> rs = new List<UnitCmType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(new UnitCmType(row));
                    }
                }
                return rs;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public IList<UnitCmType> ListUnitByBuildName(string buildName)
        {
            string funMsg = "function: ListUnitByBuildName(string buildName)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _UnitDbService.ListUnitByBuildName(buildName);
                List<UnitCmType> rs = new List<UnitCmType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(new UnitCmType(row));
                    }
                }
                return rs;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }


        public IList<UnitCmType> ListUnit(string buildId)
        {
            string funMsg = "function: ListUnit(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _UnitDbService.ListUnit(buildId);
                List<UnitCmType> rs = new List<UnitCmType>();
                if (table != null && table.Rows.Count > 0)
                {                   
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(new UnitCmType(row));
                    }                   
                }
                return rs;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool AddUnitByName(string buildName, string cx_axis, string cy_axis, string createBy)
        {
            string funMsg = "Function: AddUnitByName(string buildName, string cx_axis, string cy_axis, string createBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _UnitDbService.InsertUnitByName(buildName, cx_axis, cy_axis, createBy);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public bool AddUnit(string buildId, string cx_axis, string cy_axis, string createBy)
        {
            string funMsg = "Function:AddUnit(string buildId, string x_axis, string y_axis, string createBy)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _UnitDbService.InsertUnit(buildId, cx_axis, cy_axis, createBy);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public bool DeleteUnit(string unitId)
        {
            string funMsg = "Function: DeleteUnit(string unitId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _UnitDbService.DeleteUnit(unitId);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
