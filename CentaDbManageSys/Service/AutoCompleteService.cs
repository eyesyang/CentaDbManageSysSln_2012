using System;
using System.Collections.Generic;
using System.Linq;

namespace CentaDbManageSys.Service
{
    public class AutoCompleteService
    {
        private static readonly object syncObject = new object();

        private static AutoCompleteService instance = null;

        private AutoCompleteService()
        {

        }
        private class SearchResult
        {
            public string SearchType
            {
                get;
                set;
            }
            public string SearchCode
            {
                get;
                set;
            }
            public string Keyword
            {
                get;
                set;
            }
            public IList<string> Result
            {
                get;
                set;
            }
        }
        public static AutoCompleteService Init()
        {
            if(instance==null)
            {
                lock(syncObject)
                {
                    if (instance==null)
                    {
                        instance = new AutoCompleteService();
                    }
                }
            }
            return instance;
        }

        private int _CacheLength = 1000;        

        private List<SearchResult> Cache
        {
            get;
            set;
        }
        private IList<string> QueryFromDb(string keyword)
        {
            ArchitectureService service = new ArchitectureService();
            IList<string> result= service.GetEstateNameByKeyword(keyword,this.SearchType,this.SearchCode);            
            if(result!=null && result.Count>0)
            {
                AddCache(keyword, result);
            }
            return result;
        }
        private void AddCache(string key, IList<string> result)
        {
            if (this.Cache == null)
            {
                this.Cache = new List<SearchResult>();
            }

            this.Cache.RemoveAll(m => m.Keyword == key && m.SearchType == this.SearchType && m.SearchCode==this.SearchCode);
            int count = this.Cache.Count;
            if (count >= this._CacheLength)
            {
                this.Cache.RemoveAt(0);
            }
            this.Cache.Add(new SearchResult { SearchType = this.SearchType, SearchCode=this.SearchCode, Keyword = key, Result = result });
        }

        public IList<string> Query(string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    key = key.ToUpper();
                }
                IList<string> result = null;
                if (this.Cache != null)
                {
                    var cache = this.Cache.FirstOrDefault(m => m.SearchType == this.SearchType && m.SearchCode==this.SearchCode && m.Keyword == key);
                    if (cache!=null && cache.Result!=null && cache.Result.Count>0)
                    {
                        return cache.Result;
                    }                   
                }
                result = QueryFromDb(key);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SearchType
        {
            get;
            set;
        }
        public string SearchCode
        {
            get;
            set;
        }
    }
}
