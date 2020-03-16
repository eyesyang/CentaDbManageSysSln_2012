using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CentaDbManageSys.Model;
using CentaDbManageSys.Service.Db;
using CentaLine.Common;

namespace CentaDbManageSys.Service
{
    public class ArchitectureService
    {

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
        private static string _ClassMsg = "class: ArchitectureService; namespace: CentaDbManagerSys.Service; source file: ArchitectureService.cs";

        private ArchitectureDbService _DbService = new ArchitectureDbService();

        public static string GetEstateType(string estateType)
        {
            string funMsg = "function: GetEstateType(string estateType)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string rs = string.Empty;
                switch (estateType)
                {
                    case "bigest":
                        {
                            rs = "大型小区(分期)";
                            break;
                        }
                    case "normal":
                        {
                            rs = "小区";
                            break;
                        }
                    case "phase":
                        {
                            rs = "期数";
                            break;
                        }
                    case "single":
                        {
                            rs = "独栋";
                            break;
                        }
                    default:
                        {
                            break;
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

        public T GetEstateById<T>(string estateId) where T : CentaEstateType
        {
            string funMsg = "function: getEstateById<T>(string estateId);" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetEstateById(estateId);
                return ConvertUtility.Row2Model<T>(row);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public IList<T> GetEstateByScope<T>(string scopeId, int pageIndex, int pageSize, out int recordCount) where T : CentaEstateType
        {
            string funMsg = "function:GetEstateByScope(string scopeId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetEstateByScope(scopeId, pageIndex, pageSize, out recordCount);
                return ConvertUtility.Table2Model<T>(table);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        public T GetBuildById<T>(string buildId) where T : CentaBuildType
        {
            string funMsg = "function: GetBuildById<T>(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetBuildById(buildId);
                return ConvertUtility.Row2Model<T>(row);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        /// <summary>
        /// 通过城区或片区获取楼盘
        /// </summary>
        /// <typeparam name="T">CentaEstate 或者 CentaEstateType</typeparam>
        /// <param name="type">'city' 或者 'region' 或者 'scope'</param>
        /// <param name="code">'cityId' 或者 'regionId' 或者 'scopeId'</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<T> GetEstateByType<T>(string type, string code, int pageIndex, int pageSize, out int recordCount) where T : CentaEstateType
        {
            string funMsg = "function: GetEstateByType<T>(string type,string code, int pageIndex,int pageSize, out int recordCount)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetEstateByType(type, code, pageIndex, pageSize, out recordCount);
                return ConvertUtility.Table2Model<T>(table);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public IList<T> GetEstateByKeyword<T>(string[] key, int pageIndex, int pageSize, out int recordCount) where T : CentaEstateType
        {
            string funMsg = "function: GetEstateByKeyword<T>(string[] key, int pageIndex, int pageSize, out int recordCount);" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string keyword, type = string.Empty, code = string.Empty;
                keyword = key[0];
                if (key.Length > 1)
                {
                    type = key[1];
                    code = key[2];
                }
                DataTable table = _DbService.GetEstateByKeyword(keyword, type, code, pageIndex, pageSize, out recordCount);
                return ConvertUtility.Table2Model<T>(table);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public IList<T> GetBuildByEstate<T>(string estateId) where T : CentaBuildType
        {
            string funMsg = "function: GetBuildByEstate<T>(string estateId);" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetBuildByEstate(estateId);
                return ConvertUtility.Table2Model<T>(table);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        public IList<T> GetBuildByEstate<T>(string estateId, int pageIndex, int pageSize, out int recordCount) where T : CentaBuildType
        {
            string funMsg = "function: GetBuildByEstate<T>(string estateId, int pageIndex, int pageSize, out int recordCount)" + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetBuildByEstate(estateId, pageIndex, pageSize, out recordCount);
                return ConvertUtility.Table2Model<T>(table);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public T GetCentaUnitById<T>(string unitId) where T : CentaUnitType
        {
            string funMsg = "function: GetCentaUnitById<T>(string unitId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataRow row = _DbService.GetUnitById(unitId);
                return ConvertUtility.Row2Model<T>(row);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        public IList<string> GetUnitFloorByBuild(string buildId)
        {
            string funMsg = "function: GetUnitFloorByBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetUnitFloorByBuild(buildId);
                List<string> rs = ConvertUtility.Table2Model<string>(table).ToList();
                if (rs != null && rs.Count > 0)
                {
                    UnitRowSort sort = new UnitRowSort();
                    rs.Sort(sort.Compare);
                }
                return rs;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        public IList<string> GetUnitRoomByBuild(string buildId)
        {
            string funMsg = "function: GetUnitRoomByBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetUnitRoomByBuild(buildId);
                List<string> rs = ConvertUtility.Table2Model<string>(table).ToList();
                if (rs != null && rs.Count > 0)
                {
                    UnitColSort sort = new UnitColSort();
                    rs.Sort(sort.Compare);
                }
                return rs;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        public int GetColumnCountByBuild(string buildId)
        {
            string funMsg = "function: GetColumnCountByBuild(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                IList<DataTable> table = _DbService.GetUnitByBuild(buildId);
                DataTable room = table[0];
                return room.Rows.Count;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        public IList<T> GetUnitByBuild<T>(string buildId, out List<string> rows, out List<string> cols) where T : CentaUnitType
        {
            string funMsg = "function: GetUnitByBuild<T>(string buildId)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                IList<DataTable> table = _DbService.GetUnitByBuild(buildId);
                DataTable room = table[0];
                List<string> rs = new List<string>();
                if (room != null && room.Rows.Count > 0)
                {
                    foreach (DataRow row in room.Rows)
                    {
                        rs.Add(ConvertUtility.Trim(row[0]));
                    }
                    UnitColSort sort = new UnitColSort();
                    rs.Sort(sort.Compare);
                    cols = rs;
                }
                else
                {
                    cols = rs;
                }
                DataTable floor = table[1];
                if (floor != null && floor.Rows.Count > 0)
                {
                    rs = new List<string>();
                    foreach (DataRow row in floor.Rows)
                    {
                        rs.Add(ConvertUtility.Trim(row[0]));
                    }
                    UnitRowSort sort = new UnitRowSort();
                    rs.Sort(sort.Compare);
                    rows = rs;
                }
                else
                {
                    rows = rs;
                }
                DataTable all = table[2];
                return ConvertUtility.Table2Model<T>(all);
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
        public bool AddEstate(CentaEstateType estate)
        {
            string funMsg = "function: AddEstate(CentaEstateType estate)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.AddEstate(estate);
                if (effected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool UpdateEstate(CentaEstateType estate)
        {
            string funMsg = "function: UpdateEstate(CentaEstateType estate)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.UpdateEstate(estate);
                if (effected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool IsExistUnit(string buildId, string floor, string room)
        {
            string funMsg = "function: IsExistUnit(string buildId, string floor, string room)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetUnitByBuild(buildId, floor, room);
                if (table != null && table.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool IsExistEstateByScope(string scopeId, string estateId, string estateName)
        {
            string funMsg = "function: IsExistEstateByScope(string scopeId, string estateId, string estateName)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetEstateByScope(scopeId);
                List<CentaEstateType> estateCollection = ConvertUtility.Table2Model<CentaEstateType>(table).ToList();
                object rs = null;
                if (string.IsNullOrEmpty(estateId))
                {
                    rs = estateCollection.Find(m => m.EstateName == estateName);
                }
                else
                {                    
                    rs = estateCollection.Find(m => m.EstateId != estateId && m.EstateName == estateName);
                }
                if (rs != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool DeleteEstateById(string estateId, bool isDelete)
        {
            string funMsg = "function: DeleteEstateById(string estateId, bool isDelete)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int nmark = ConvertUtility.ToInt(Nmark.InsertEstate);
                if (isDelete)
                {
                    nmark = ConvertUtility.ToInt(Nmark.Delete11);
                }
                int effected = _DbService.UpdateEstateByNmark(estateId, nmark);
                if (effected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public IList<string> GetEstateNameByKeyword(string keyword, string type, string code)
        {
            string funMsg = "function: GetEstateNameByKeyword(string keyword,string type, string code);" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int recordCount;
                DataTable table = _DbService.GetEstateNameByKeyword(keyword, type, code, 1, 50, out recordCount);
                List<string> result = new List<string>();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var item = ConvertUtility.Trim(row[0]);
                        if (!result.Contains(item))
                        {
                            result.Add(item);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool IsExistBuildName(string estateId, string buildName)
        {
            string funMsg = "function: IsExistBuildName(string estateId, string buildName)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetBuildByName(estateId, buildName);
                if (table != null && table.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool AddUnit(string buildId, string floor, string room, decimal area, string countf, string countt, string countw, string direction)
        {
            string funMsg = "function: AddUnit(string buildId, string floor, string room, decimal area, string countf, string countt,string countw,string direction)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = 0;
                if (string.IsNullOrEmpty(buildId) || (string.IsNullOrEmpty(floor) && string.IsNullOrEmpty(room)))
                {
                    return false;
                }
                PreviewService.RefreshLog(buildId);
                if (string.IsNullOrEmpty(floor))
                {
                    IList<string> y_axis = GetUnitFloorByBuild(buildId);
                    foreach (var item in y_axis)
                    {
                        if (!IsExistUnit(buildId, item, room + "室"))
                        {
                            effected = _DbService.AddUnit(buildId, item.Replace("楼", ""), room, area, countf, countt, countw, direction);
                        }
                    }
                }
                else if (string.IsNullOrEmpty(room))
                {
                    IList<string> x_axis = GetUnitRoomByBuild(buildId);
                    foreach (var item in x_axis)
                    {

                        if (!IsExistUnit(buildId, floor + "楼", item))
                        {
                            effected = _DbService.AddUnit(buildId, floor, item.Replace("室", ""), area, countf, countt, countw, direction);
                        }
                    }
                }
                else
                {
                    effected = _DbService.AddUnit(buildId, floor, room, area, countf, countt, countw, direction);
                }
                return effected > 0;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool DeleteUnitById(string id, string isDelete)
        {
            string funMsg = "function: DeleteEstateById(string id, string isDelete)" + FileUtility.NewLine + _ClassMsg;
            try
            {

                string[] unitId = id.Split(new string[] { AppSettings.FirstSplit }, StringSplitOptions.RemoveEmptyEntries);
                string[] delete = isDelete.Split(new string[] { AppSettings.FirstSplit }, StringSplitOptions.RemoveEmptyEntries);
                for (int idx = 0; idx < unitId.Length; idx++)
                {
                    string item = unitId[idx];

                    int nmark = ConvertUtility.ToInt(Nmark.InsertUnit);
                    if (ConvertUtility.ToBoolean(delete[idx]))
                    {
                        nmark = ConvertUtility.ToInt(Nmark.Delete15);
                    }
                    _DbService.UpdateUnitByNmark(item, nmark);
                }
                return true;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool DeleteBuildById(string id, bool isDelete)
        {
            string funMsg = "function: DeleteBuildById(string id, bool isDelete)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int nmark = ConvertUtility.ToInt(Nmark.InsertBuild);
                if (isDelete)
                {
                    nmark = ConvertUtility.ToInt(Nmark.Delete13);
                }
                int effected = _DbService.UpdateBuildByNmark(id, nmark);
                return effected > 0;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool AddBuild(string estateId, string buildName, string buildType, string x_cnt, string y_cnt_begin, string y_cnt_end, bool x_except, bool y_except)
        {
            string funMsg = "function: AddBuild(string estateId, string buildName, string buildType, string x_cnt, string y_cnt_begin, string y_cnt_end, bool x_except,bool y_except)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.AddBuild(estateId, buildName, buildType, x_cnt, y_cnt_begin, y_cnt_end, x_except, y_except);
                return effected > 0;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool IsExistBuildByEstate(string estateId, string buildId, string buildName)
        {
            string funMsg = "function: IsExistBuildByEstate(string estateId, string buildId, string buildName)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                DataTable table = _DbService.GetBuildByEstate(estateId);
                List<CentaBuildType> build = ConvertUtility.Table2Model<CentaBuildType>(table).ToList();
                object rs = null;
                if (string.IsNullOrEmpty(buildId))
                {
                    rs = build.Find(m => m.BuildName == buildName);
                }
                else
                {
                    rs = build.Find(m => m.BuildId != buildId && m.BuildName == buildName);
                }

                if (rs != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool UpdateBuild(string buildId, string buildName)
        {
            string funMsg = "function: UpdateBuild(string buildId, string buildName)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = _DbService.UpdateBuild(buildId, buildName);
                return effected > 0;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool MoveUnit(string unitId, string row, string col)
        {
            string funMsg = "function: MoveUnit(string unitId, string row, string col)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string buildId = this.GetCentaUnitById<CentaUnitType>(unitId).BuildId;
                PreviewService.RefreshLog(buildId);
                int effected = _DbService.MoveUnit(unitId, row, col);
                return effected > 0;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool UpdateUnit(string[] unitIdCollection, decimal area, int countf, int countt, int countw, string direction)
        {
            string funMsg = "function: UpdateUnit(string[] unitIdCollection, decimal area, int countf, int countt, int countw, string direction)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                int effected = 0;
                if (unitIdCollection != null && unitIdCollection.Length > 0)
                {
                    foreach (var item in unitIdCollection)
                    {
                        effected = _DbService.UpdateUnit(item, area, countf, countt, countw, direction);
                    }
                }
                return effected > 0;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool MergeUnit(string unitCollection, int merge)
        {
            string funMsg = "function: Merge(string unitCollection, int merge)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string[] unitId = unitCollection.Split(new string[] { AppSettings.FirstSplit }, StringSplitOptions.RemoveEmptyEntries);
                string buildId = this.GetCentaUnitById<CentaUnitType>(unitId[merge]).BuildId;
                PreviewService.RefreshLog(buildId);
                int effected = _DbService.MergeUnit(unitId[merge]);
                return effected > 0;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }

        public bool AddBuild(string estateId, string buildName)
        {
            string funMsg = "function: AddBuild(string estateId, string buildName)" + FileUtility.NewLine + _ClassMsg;
            try
            {
                string[] name = buildName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in name)
                {
                    _DbService.AddBuild(estateId, item);
                }
                return true;
            }
            catch (Exception ex)
            {
                string exMsg = "Exception: " + ex.Message + FileUtility.NewLine + funMsg;
                throw new Exception(exMsg, ex.InnerException);
            }
        }
    }
}