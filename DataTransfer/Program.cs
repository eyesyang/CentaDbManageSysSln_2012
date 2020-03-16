using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using CentaDbManageSys.Model;
using CentaDbManageSys.BLL;


namespace CentaDbManageSys.DataTransfer
{
    class Program
    {
        static int _Interval = AppSettings.Interval;
        static System.Threading.Timer _Timer = null;

        static void Main(string[] args)
        {
            Console.Title = "CentaDbManageSys.DataTransfer (2012-03-06)";
            Console.WriteLine("时间: {0},程序开始执行..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            A2C();
            C2F();
            OrderStatusMonitor();
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
                Console.Write((new TimeSpan(0,0,_Interval)).ToString());                
                _Interval--;
            }
            else
            {
                _Interval = AppSettings.Interval;
                _Timer.Dispose();
                Console.WriteLine(string.Empty);
                A2C();
                C2F();
                OrderStatusMonitor();
                TimerStart();
            }
        }

        /// <summary>
        /// AgencyComDb to CollectDb
        /// </summary>
        static void A2C()
        {
            DateTime begin = DateTime.Now;
            EstateCmService service = new EstateCmService();
            Console.WriteLine("时间: {0}, 从Order中获取重点楼盘..", begin.ToString("yyyy-MM-dd hh:mm:ss"));
            List<OrderType> order = service.ListOrder(AppSettings.Banch,OrderStatus.REQUEST);
            Console.WriteLine("时间: {0}, 重点楼盘{1}个..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), order.Count);
            if (order != null && order.Count > 0)
            {
                order.ForEach(item =>
                {
                    Console.WriteLine("时间: {0}, 开始导入楼盘[{1}]..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), item.EstateId);
                    Estate_A2C_ing(item.EstateId);
                });
                DateTime end = DateTime.Now;
                Console.WriteLine("时间: {0}, 结束导入，总共用时: {1}", end.ToString("yyyy-MM-dd hh:mm:dd"), (end - begin).ToString());
            }   
        }
        static void Estate_A2C_ing(string estateId)
        {
            //
            DateTime begin= DateTime.Now;
            EstateCmService estateCmService = new EstateCmService();
            EstateCmType estateCmType = estateCmService.GetEstateTypeById(estateId);
            EstateCtType estateCtType = new EstateCtType(estateCmType);
            EstateCtService estateCtService = new EstateCtService();
            estateCtService.ImportEstate(estateCtType);
            BuildCmService buildCmService = new BuildCmService();
            List<BuildCmType> buildType= buildCmService.ListBuild(estateId).ToList();
            
            if (buildType!=null && buildType.Count>0)
            {
                buildType.ForEach(item =>
                {
                    Console.WriteLine("时间: {0}, 开始导入栋座[{1}]..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), item.BuildName);
                    Build_A2C(item); 
                });
            }
            DateTime end = DateTime.Now;
        }        
        static void Build_A2C(BuildCmType buildCmType)
        {
            //
            DateTime begin = DateTime.Now;
            EstateCtService estateCtService=new EstateCtService();
            BuildCtType buildCtType = new BuildCtType(buildCmType);            
            BuildCtService buildCtService = new BuildCtService();
            buildCtService.ImortBuild(buildCtType);
            BuildCmService buildCmService = new BuildCmService();
            UnitCmService unitCmService = new UnitCmService();
            List<UnitCmType> unitType = unitCmService.ListUnit(buildCmType.BuildId).ToList();
            if (unitType != null && unitType.Count > 0)
            {
                unitType.ForEach(item =>
                {
                    Console.WriteLine("时间: {0}, 导入单元[{1}]..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), item.CY_Axis+item.CX_Axis);
                    Unit_A2C(item);                   
                });
            }
            DateTime end = DateTime.Now;
        }
        static void Unit_A2C(UnitCmType unitCmType)
        {
            //
            DateTime begin = DateTime.Now;
            UnitCtType unitCtType = new UnitCtType(unitCmType);
            UnitCtService unitCtService = new UnitCtService();
            unitCtService.ImportUnit(unitCtType);
            DateTime end = DateTime.Now;
        }

        /// <summary>
        /// CollectDb to FrameworkDb
        /// </summary>
        static void C2F()
        {
            DateTime begin = DateTime.Now;
            EstateCtService service = new EstateCtService();
            Console.WriteLine("时间: {0}, 从CollectDb中获取已收集完成楼盘..", begin.ToString("yyyy-MM-dd hh:mm:ss"));
            List<EstateCtType> order = service.GetCompletedEstate(AppSettings.Banch);
            Console.WriteLine("时间: {0}, 重点楼盘{1}个..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), order.Count);
            if (order != null && order.Count > 0)
            {
                order.ForEach(item =>
                {
                    Console.WriteLine("时间: {0}, 开始导入楼盘[{1}]..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), item.EstateId);
                    Estate_C2F_Ing(item.EstateId);                                        
                });
                DateTime end = DateTime.Now;
                Console.WriteLine("时间: {0}, 结束导入，总共用时: {1}", end.ToString("yyyy-MM-dd hh:mm:dd"), (end - begin).ToString());
            }
        }
        static void Estate_C2F_Ing(string estateId)
        {
            //
            DateTime begin = DateTime.Now;
            EstateCtService estateCtService = new EstateCtService();
            EstateCtType estateCtType = estateCtService.GetEstateTypeById(estateId);
            EstateFwType estateFwType = new EstateFwType(estateCtType);
            EstateFwService estateFwService = new EstateFwService();
            estateFwService.ImportEstate(estateFwType);
            BuildCtService buildCtService = new BuildCtService();
            List<BuildCtType> buildType = buildCtService.ListBuild(estateId).ToList();

            if (buildType != null && buildType.Count > 0)
            {
                buildType.ForEach(item =>
                {
                    Console.WriteLine("时间: {0}, 开始导入栋座[{1}]..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), item.BuildName);
                    Build_C2F(item);                    
                });
            }
            DateTime end = DateTime.Now;
        }        
        static void Build_C2F(BuildCtType buildCtType)
        {
            //
            DateTime begin = DateTime.Now;           
            BuildFwType buildFwType = new BuildFwType(buildCtType);
            BuildFwService buildFwService = new BuildFwService();
            buildFwService.ImortBuild(buildFwType);
            UnitCtService unitCtService = new UnitCtService();
            List<UnitCtType> unitType = unitCtService.ListUnit(buildFwType.BuildId).ToList();
            if (unitType != null && unitType.Count > 0)
            {
                unitType.ForEach(item =>
                {
                    Console.WriteLine("时间: {0}, 导入单元[{1}]..", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), item.CY_Axis + item.CX_Axis);
                    Unit_C2F(item);
                });
            }
            DateTime end = DateTime.Now;
        }
        static void Unit_C2F(UnitCtType unitCtType)
        {
            //
            DateTime begin = DateTime.Now;
            UnitFwType unitFwType = new UnitFwType(unitCtType);
            UnitFwService unitFwService = new UnitFwService();
            unitFwService.ImportUnit(unitFwType);
            DateTime end = DateTime.Now;
        }

        static void OrderStatusMonitor()
        {            
            EstateCmService estateCmService = new EstateCmService();
            EstateCtService estateCtService = new EstateCtService();
            List<EstateCtType> ctTypeCollection= estateCtService.ListOrderStatus();
            if (ctTypeCollection != null && ctTypeCollection.Count > 0)
            {
                ctTypeCollection.ForEach(item =>
                {
                    switch(item.Flow)
                    {
                        case FlowStatus.COLLECTING:
                            {
                                Console.WriteLine("更新Order状态为[收集中--EstateId={0}]", item.AgencyCom_EstateId);
                                estateCmService.UpdateOrderStatus(item.AgencyCom_EstateId, OrderStatus.COLLECTING);
                                estateCtService.UpdateFlowStatus(item.EstateId, FlowStatus.COLLECTING_ORDERSTATUS);
                                break;
                            }
                        case FlowStatus.COLLECTED:
                            {
                                Console.WriteLine("更新Order状态[收集完成--EstateId={0}]", item.AgencyCom_EstateId);
                                estateCmService.UpdateOrderStatus(item.AgencyCom_EstateId, OrderStatus.COLLECTED);
                                estateCtService.UpdateFlowStatus(item.EstateId, FlowStatus.COLLECTED_ORDERSTATUS);
                                break;
                            }                        
                        default:
                            {
                                break;
                            }
                    }
                });
            }
            EstateFwService estateFwService = new EstateFwService();
             List<EstateFwType> fwTypeCollection =estateFwService.ListOrderStatus();
             if (fwTypeCollection != null && fwTypeCollection.Count > 0)
             {
                 fwTypeCollection.ForEach(item =>
                 {
                     switch (item.Flow)
                     {
                         case FlowStatus.COLLECTING:
                             {
                                 Console.WriteLine("更新Order状态[录入中--EstateId={0}]", item.AgencyCom_EstateId);
                                 estateCmService.UpdateOrderStatus(item.AgencyCom_EstateId, OrderStatus.FRAMEWORKING);
                                 estateFwService.UpdateFlowStatus(item.EstateId,FlowStatus.COLLECTING_ORDERSTATUS);
                                 break;
                             }
                         case FlowStatus.COLLECTED:
                             {
                                 Console.WriteLine("更新Order状态[录入完成--EstateId={0}]", item.AgencyCom_EstateId);
                                 estateCmService.UpdateOrderStatus(item.AgencyCom_EstateId, OrderStatus.FRAMEWORKED);
                                 estateFwService.UpdateFlowStatus(item.EstateId, FlowStatus.COLLECTED_ORDERSTATUS);
                                 break;
                             }
                         case FlowStatus.EXPORTED:
                             {
                                 Console.WriteLine("更新Order状态[比较完成--EstateId={0}]", item.AgencyCom_EstateId);
                                 estateCmService.UpdateOrderStatus(item.AgencyCom_EstateId, OrderStatus.COMPARED);
                                 estateFwService.UpdateFlowStatus(item.EstateId, FlowStatus.EXPORTED_ORDERSTATUS);
                                 break;
                             }
                         default:
                             {
                                 break;
                             }
                     }
                 });
             }
        }
    }
}
