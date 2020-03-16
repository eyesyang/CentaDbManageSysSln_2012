using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CentaDbManageSys.Model;
using CentaDbManageSys.Service.Db;
using CentaLine.Common;

namespace CentaDbManageSys.Service
{
    public class AreaService
    {
        private AreaService()
        {
            LoadData();
        }
        private static AreaService _Instance = null;
        public static AreaService Init()
        {
            if (_Instance == null)
            {
                _Instance = new AreaService();
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

        private void LoadData()
        {
            try
            {
                AreaDbService areaDbService = new AreaDbService();
                DataTable table = areaDbService.GetCities();
                this.CityCollection = ConvertUtility.Table2Model<CityType>(table).ToList();
                table = areaDbService.GetRegions();
                this.RegionCollection = ConvertUtility.Table2Model<RegionType>(table).ToList();
                table = areaDbService.GetScopes();
                this.ScopeCollection = ConvertUtility.Table2Model<ScopeType>(table).ToList();               
            }
            catch (Exception ex)
            {
            	throw ex;
            }                        
        } 
    }
}
