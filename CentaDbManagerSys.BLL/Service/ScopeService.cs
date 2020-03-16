using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaDbManageSys.DAL;
using CentaDbManageSys.Model;
using CentaLine.Common;

namespace CentaDbManageSys.BLL
{
    public class ScopeService
    {
        private ScopeService( )
        {           
            LoadData();
        }
        
        private static ScopeService _Instance = null;
        public static ScopeService Init()
        {

            if (_Instance == null)
            {
                _Instance = new ScopeService();
            }           
            return _Instance;
        }       

        public List<CityType> CityCollection
        {
            get;
            set;
        }
        public List<RegionType> RegionCollection
        {
            get;
            set;
        }
        public List<ScopeType> ScopeCollection
        {
            get;
            set;
        }
        public CityType GetCityById(string cityId)
        {
            if (this.CityCollection==null)
            {
                LoadData();
            }
            return this.CityCollection.Find(m => m.CityId == cityId);
        }
        public RegionType GetRegionById(string regionId)
        {
            if (this.RegionCollection == null)
            {
                LoadData();
            }
            return this.RegionCollection.Find(m => m.RegionId == regionId);
        }
        public ScopeType GetScopeById(string scopeId)
        {
            if (this.ScopeCollection == null)
            {
                LoadData();
            }
            return this.ScopeCollection.Find(m => m.ScopeId == scopeId);
        }

        private void LoadData()
        {
            try
            {
                ScopeDbService scopeDbService = new ScopeDbService();
                IList<DataTable> table = scopeDbService.ListScope();
                this.CityCollection = ConvertUtility.Table2Model<CityType>(table[0]).ToList();
                this.RegionCollection = ConvertUtility.Table2Model<RegionType>(table[1]).ToList();
                this.ScopeCollection = ConvertUtility.Table2Model<ScopeType>(table[2]).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
