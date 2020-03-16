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
    public class UnitFwService : UnitFwDbService
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
        
        private UserInfo _Member = null;

        public UnitFwService()
        {
            MemberService memberService = new MemberService();
            this._Member = memberService.GetUserInfo();
        }

        public UnitFw GetUnit(string unitId)
        {
            UnitFwType unitType = GetUnitType(unitId);
            return new UnitFw(unitType);
        }

        public UnitFwType GetUnitType(string unitId)
        {
            string funMsg = "function: GetUnitType(string unitId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = base.GetUnit(unitId);
                if (row == null)
                {
                    return null;
                }
                return new UnitFwType(row);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> ListRoom(string buildId)
        {
            string funMsg = "function: ListRoom(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = base.ListRoom(buildId);
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
                DataTable table = base.ListFloor(buildId);
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

        public IList<UnitCmType> ListUnitByBuildName(string buildName)
        {
            string funMsg = "function: ListUnitByBuildName(string buildName)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = base.ListUnitByBuildName(buildName);
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


        public IList<UnitFwType> ListUnit(string buildId)
        {
            string funMsg = "function: ListUnit(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = base.ListUnit(buildId);
                List<UnitFwType> rs = new List<UnitFwType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(new UnitFwType(row));
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

        public IList<UnitFwType> ListUnitByCm(string buildId)
        {
            string funMsg = "function: ListUnitByCm(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = base.ListUnitByCm(buildId);
                List<UnitFwType> rs = new List<UnitFwType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(new UnitFwType(row));
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
            string funMsg =
                "Function: AddUnitByName(string buildName, string cx_axis, string cy_axis, string createBy)" +
                FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = base.InsertUnitByName(buildName, cx_axis, cy_axis, createBy);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddUnit(string buildId, string x_axis, string y_axis)
        {
            string funMsg = "Function: AddUnit(string buildId, string x_axis, string y_axis)" + FileUtility.NewLine +
                            _ClassMsg;
            try
            {
                return AddUnit(buildId, x_axis, y_axis, 0, 0, 0, 0, 0, string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddUnit(string buildId, string x_axis, string y_axis, int countf, int countt, int countw, int county,
                            float area, string directionTo)
        {
            string funMsg =
                "Function:AddUnit(string buildId, string x_axis, string y_axis, int countf,int countt,int countw,int county,float area,string directionTo)" +
                FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = 0;
                if (string.IsNullOrEmpty(x_axis) && string.IsNullOrEmpty(y_axis))
                {
                    return false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(x_axis) && !string.IsNullOrEmpty(y_axis))
                    {
                        effected = base.InsertUnit(buildId, x_axis, y_axis, countf, countt, countw, county, area,
                                                         directionTo, this._Member.UserId);
                    }
                    else if (string.IsNullOrEmpty(y_axis))
                    {
                        List<string> floor = ListFloor(buildId);
                        if (floor != null)
                        {
                            floor.ForEach(item =>
                                              {
                                                  y_axis = item.Replace("楼", string.Empty);
                                                  effected += base.InsertUnit(buildId, x_axis, y_axis, countf,
                                                                                    countt, countw, county, area,
                                                                                    directionTo, this._Member.UserId);
                                              });
                        }
                    }
                    else
                    {
                        List<string> room = ListRoom(buildId);
                        if (room != null)
                        {
                            string[] array = y_axis.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var m in array)
                            {
                                y_axis = m;
                                room.ForEach(item =>
                                                 {
                                                     x_axis = item.Replace("室", string.Empty);
                                                     effected += base.InsertUnit(buildId, x_axis, y_axis, countf,
                                                                                       countt, countw, county, area,
                                                                                       directionTo, this._Member.UserId);
                                                 });
                            }
                        }
                    }
                }
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
                int effected = base.DeleteUnit(unitId, this._Member.UserId);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ImportUnit(UnitFwType unitFwType)
        {
            string funMsg = "function: ImportUnit(UnitFwType unitFwType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                unitFwType.CreateBy = "System.Console";
                int effected = base.ImportUnit(unitFwType);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUnit(string unitId, int countf, int countt, int countw, int county, string direction,
                               float area)
        {
            string funMsg =
                "function: UpdateUnit(string unitId, int countf, int countt, int countw, int county, string direction, float area)" +
                FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = base.UpdateUnit(unitId, countf, countt, countw, county, direction, area);
                return effected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<UnitFwType> ListUnitByCm(string agencyCom_BuildId, string framework_BuildId)
        {
            string funMsg = "function: ListUnitByCm(string agencyCom_BuildId, string framework_BuildId)" +
                            FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = base.ListUnitByCm(agencyCom_BuildId, framework_BuildId);
                List<UnitFwType> rs = new List<UnitFwType>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        rs.Add(new UnitFwType(row));
                    }
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
