using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentaDbManageSys.Model;

namespace CentaDbManageSys.Service
{
    public class SearchService
    {
        private SearchService()
        {

        }

        private static SearchService Instance = null;
        public static SearchService Init()
        {
            if (Instance == null)
            {
                Instance = new SearchService();
            }
            return Instance;
        }

        private DateTime _LastSearchDb = DateTime.Now.AddDays(-1);
        private Dictionary<string, IList<CentaEstateType>> _ResultCache = new Dictionary<string, IList<CentaEstateType>>();
        private Dictionary<string, int> _CountCache = new Dictionary<string, int>();
        public int PageIndex
        {
            get;
            set;
        }
        public int PageSize
        {
            get;
            set;
        }
        public IList<CentaEstateType> Find(string[] keyword, out int recordCount)
        {
            try
            {
                DateTime currentDateTime = DateTime.Now;
                IList<CentaEstateType> value = null;

                if ((currentDateTime - _LastSearchDb) > new TimeSpan(12, 0, 0))
                {
                    value = FindFromDb(keyword, out recordCount);
                }
                else
                {
                    value = FindFromCache(keyword, out recordCount);
                }

                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private IList<CentaEstateType> FindFromDb(string[] keyword, out int recordCount)
        {
            try
            {
                this._LastSearchDb = DateTime.Now;
                ArchitectureService service = new ArchitectureService();
                IList<CentaEstateType> value = service.GetEstateByKeyword<CentaEstateType>(keyword, this.PageIndex, this.PageSize, out recordCount);
                SetCache(keyword, value);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private IList<CentaEstateType> FindFromCache(string[] keyword, out int recordCount)
        {
            try
            {
                IList<CentaEstateType> value = null;
                recordCount = 0;
                string key = string.Join(AppSettings.FirstSplit, keyword);
                if (this._ResultCache == null || this._ResultCache.Count == 0 || !this._ResultCache.TryGetValue(key, out value))
                {
                    value = FindFromDb(keyword, out recordCount);
                }
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SetCache(string[] keyword, IList<CentaEstateType> value)
        {
            try
            {
                string key = string.Join(AppSettings.FirstSplit, keyword);
                if (this._ResultCache.ContainsKey(key))
                {
                    this._ResultCache.Remove(key);
                }
                this._ResultCache.Add(key, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}