using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentaDbManageSys.Model;
using CentaDbManageSys.BLL;


namespace CentaDbManageSys.Compare
{
    class Program
    {
        static int _Interval = AppSettings.Interval;
        static System.Threading.Timer _Timer = null;

        static void Main(string[] args)
        {
            Console.Title = "CentaDbManageSys.Compare [2012-03-06]";
            CompareOrder();
            TimerStart();
            Console.ReadLine();
        }
        static void TimerStart()
        {
            Console.WriteLine("时间: {0},倒计时开始..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            _Timer = new System.Threading.Timer(Timer_Elapsed, null, 0, 1000);
        }
        static void Timer_Elapsed(object sender)
        {
            if (_Interval >= 0)
            {
                Console.CursorLeft = 0;
                Console.Write((new TimeSpan(0, 0, _Interval)).ToString());
                _Interval--;
            }
            else
            {
                _Interval = AppSettings.Interval;
                _Timer.Dispose();
                Console.WriteLine(string.Empty);
                CompareOrder();
                TimerStart();
            }
        }
        static void CompareOrder()
        {
            Console.WriteLine("时间: [{0}],比较程序开始..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            EstateCmService service = new EstateCmService();
            try
            {
                var order = service.ListOrder(AppSettings.Banch, OrderStatus.FRAMEWORKED);
                if (order != null && order.Count > 0)
                {
                    order.ForEach(m =>
                    {
                        CompareEstate(m.EstateId);
                        service.UpdateOrderStatus(m.EstateId, OrderStatus.COMPARED);
                    });
                }
                else
                {
                    Console.WriteLine("时间: [{0}],没有需要比较的楼盘..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static void CompareEstate(string agencyCom_EstateId)
        {
            Console.WriteLine("时间 : [{0}], 比较楼盘 [{1}]", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), agencyCom_EstateId);
            EstateCmService estateCmService = new EstateCmService();
            EstateCmType agencyComEstate= estateCmService.GetEstateById(agencyCom_EstateId);
            EstateFwService estateFwService = new EstateFwService();
            EstateFwType frameworkEstate= estateFwService.GetEstateByCm(agencyCom_EstateId);
            estateCmService.InsertComparedEstate(agencyComEstate, frameworkEstate, ComparedStatus.DEFAULT);
            CompareBuild(agencyCom_EstateId);
        }
        static void CompareBuild(string agencyCom_EstateId)
        {            
            BuildCmService buildCmService = new BuildCmService();
            List<BuildCmType> agencyComBuildList = buildCmService.ListBuild(agencyCom_EstateId).ToList();
            BuildFwService buildFwService = new BuildFwService();
            List<BuildFwType> frameworkBuildList = buildFwService.ListBuildByCm(agencyCom_EstateId).ToList();
            if (frameworkBuildList != null && frameworkBuildList.Count > 0)
            {
                frameworkBuildList.ForEach(agencyComBuild =>
                {
                    if (agencyComBuildList != null && agencyComBuildList.Count > 0)
                    {
                        var obj = agencyComBuildList.Find(item => item.BuildName == agencyComBuild.BuildName);
                        if (obj != null)
                        {
                            agencyComBuildList.RemoveAll(item => item.BuildName == agencyComBuild.BuildName);
                            
                            Console.WriteLine("时间 : [{0}], 比较栋座 [{1}]", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), obj.BuildName);
                            buildCmService.InsertComparedBuild(obj.BuildId, obj.EstateId, obj.BuildName, obj.Address, agencyComBuild.BuildId, agencyComBuild.EstateId, agencyComBuild.BuildName, agencyComBuild.Address, CompareUnit(obj.BuildId, agencyComBuild.BuildId));
                        }
                        else
                        {
                            buildCmService.InsertComparedBuild(string.Empty, string.Empty, string.Empty, string.Empty, agencyComBuild.BuildId, agencyComBuild.EstateId, agencyComBuild.BuildName, agencyComBuild.Address, ComparedStatus.ADDNEW);
                            Console.WriteLine("时间 : [{0}], 比较栋座 [{1}]", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), agencyComBuild.BuildName);
                            CompareUnit(string.Empty, agencyComBuild.BuildId);
                        }
                    }
                    else
                    {
                        buildCmService.InsertComparedBuild(string.Empty, string.Empty, string.Empty, string.Empty, agencyComBuild.BuildId, agencyComBuild.EstateId, agencyComBuild.BuildName, agencyComBuild.Address, ComparedStatus.ADDNEW);
                        Console.WriteLine("时间 : [{0}], 比较栋座 [{1}]", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), agencyComBuild.BuildName);
                        CompareUnit(string.Empty, agencyComBuild.BuildId);
                    }
                });
            }
            //delete
            if (agencyComBuildList != null && agencyComBuildList.Count > 0)
            {
                agencyComBuildList.ForEach(agencyComBuild =>
                {
                    buildCmService.InsertComparedBuild(agencyComBuild.BuildId, agencyComBuild.EstateId, agencyComBuild.BuildName, agencyComBuild.Address, string.Empty, string.Empty, string.Empty, string.Empty, ComparedStatus.DELETE);
                    CompareUnit(agencyComBuild.BuildId, string.Empty);
                });
            }
        }
        static int CompareUnit(string agencyCom_BuildId,string framework_BuildId)
        {
            int buildStatus = ComparedStatus.DEFAULT;
            UnitCmService unitCmService = new UnitCmService();
            List<UnitCmType> agencyComUnitList= null;
             UnitFwService unitFwService = new UnitFwService();
             List<UnitFwType> frameworkUnitList = null;
            if(!string.IsNullOrEmpty(agencyCom_BuildId) && !string.IsNullOrEmpty(framework_BuildId))
            {
                frameworkUnitList = unitFwService.ListUnitByCm(agencyCom_BuildId, framework_BuildId).ToList();
                agencyComUnitList = unitCmService.ListUnit(agencyCom_BuildId).ToList();  
            }
            else if (!string.IsNullOrEmpty(agencyCom_BuildId))
            {
                agencyComUnitList = unitCmService.ListUnit(agencyCom_BuildId).ToList();
            }
            else if (!string.IsNullOrEmpty(framework_BuildId))
            {
                frameworkUnitList = unitFwService.ListUnitByCm(agencyCom_BuildId, framework_BuildId).ToList();
            }
            if (frameworkUnitList != null && frameworkUnitList.Count > 0)
            {
                frameworkUnitList.ForEach(frameworkUnit =>
                {
                    if (agencyComUnitList != null && agencyComUnitList.Count > 0)
                    {
                        var agencyComUnit = agencyComUnitList.Find(item => item.CX_Axis == frameworkUnit.CX_Axis && item.CY_Axis == frameworkUnit.CY_Axis);
                        if (agencyComUnit != null)
                        {
                            agencyComUnitList.RemoveAll(item => item.CX_Axis == frameworkUnit.CX_Axis && item.CY_Axis == frameworkUnit.CY_Axis);
                            unitCmService.InsertComparedUnit(agencyComUnit, frameworkUnit, ComparedStatus.DEFAULT);
                        }
                        else
                        {
                            unitCmService.InsertComparedUnit(null, frameworkUnit, ComparedStatus.ADDNEW);
                            buildStatus = ComparedStatus.DEFAULT_MISS;
                        }
                    }
                    else
                    {
                        unitCmService.InsertComparedUnit(null, frameworkUnit, ComparedStatus.ADDNEW);
                        buildStatus = ComparedStatus.DEFAULT_MISS;
                    }
                });
            }
            //delete
            if (agencyComUnitList != null && agencyComUnitList.Count > 0)
            {
                agencyComUnitList.ForEach(agencyComUnit =>
                {
                    unitCmService.InsertComparedUnit(agencyComUnit, null, ComparedStatus.DELETE);
                    buildStatus = ComparedStatus.DEFAULT_CLEAR;
                });
            }
            return buildStatus;
        }

    }
}
