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
    public class UnitCmService
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

        private UnitCmDbService _DbService = null;

        public UnitCmService()
        {
            this._DbService = new UnitCmDbService();
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
                DataTable table = _DbService.ListRoom(buildId);
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
                DataTable table = _DbService.ListFloor(buildId);
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
        public IList<UnitCmType> ListUnit(string buildId)
        {
            string funMsg = "function: ListUnit(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListUnit(buildId);
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
                int effected = _DbService.InsertUnitByName(buildName, cx_axis, cy_axis, createBy);
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
                int effected = _DbService.DeleteUnit(unitId);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertComparedUnit(UnitCmType obj, UnitFwType m, int comparedStatus)
        {
            string funMsg = "function: InsertComparedUnit(UnitCmType obj, UnitFwType m, int comparedStatus)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                if(obj==null)
                {
                    obj = new UnitCmType();
                    obj.UnitId = string.Empty;
                    obj.BuildId = string.Empty;
                    obj.CX_Axis = string.Empty;
                    obj.CY_Axis = string.Empty;
                    obj.DirectionTo = string.Empty;
                }
                if(m==null)
                {
                    m = new UnitFwType();
                    m.UnitId = string.Empty;
                    m.BuildId = string.Empty;
                    m.CX_Axis = string.Empty;
                    m.CY_Axis = string.Empty;
                    m.DirectionTo = string.Empty;
                }
                int effected = _DbService.InsertComparedUnit(obj,m,comparedStatus);
                return effected > 0;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public List<string> ListComparedRoom(ComparedBuildType comparedBuild)
        {
            string funMsg = "function: ListComparedRoom(ComparedBuildType comparedBuild)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListComparedRoom(comparedBuild);
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
        public List<string> ListComparedFloor(ComparedBuildType comparedBuild)
        {
            string funMsg = "function: ListComparedFloor(ComparedBuildType buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListComparedFloor(comparedBuild);
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
        public IList<ComparedUnitType> ListComparedUnit(ComparedBuildType comparedBuild)
        {
            string funMsg = "function: ListComparedUnit(ComparedBuildType comparedBuild)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.ListComparedUnit(comparedBuild);
                List<ComparedUnitType> rs = new List<ComparedUnitType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(new ComparedUnitType(row));
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
    }
}
