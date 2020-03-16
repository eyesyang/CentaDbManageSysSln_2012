using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CentaDbManageSys.Model
{
    public class Architectures
    {
        /// <summary>
        /// 城市
        /// </summary>
        public const string CITY = "23";
        /// <summary>
        /// 城区
        /// </summary>
        public const string REGION = "22";
        /// <summary>
        /// 片区
        /// </summary>
        public const string SCOPE = "21";
        /// <summary>
        /// 大型小区
        /// </summary>
        public const string BIGESTATE = "3";
        /// <summary>
        /// 小区、期数
        /// </summary>
        public const string ESTATE = "2";
        /// <summary>
        /// 栋座
        /// </summary>
        public const string BUILD = "1";
        /// <summary>
        /// 单元
        /// </summary>
        public const string UNIT = "0";
    }
    public enum Nmark
    {
        #region 表示需要添加的信息(楼盘、栋座)

        /// <summary>
        /// 新增楼盘 / 新增片區
        /// </summary>
        InsertEstate = 1,
        /// <summary>
        /// 新增栋座号
        /// </summary>
        InsertBuild = 2,
        /// <summary>
        /// 新增单元
        /// </summary>
        InsertUnit = 20,

        #endregion
        #region 表示需要修改的信息
        /// <summary>
        /// 修改楼盘的城区、片区，详细地址 / 修改片區
        /// </summary>
        Update3 = 3,
        /// <summary>
        /// 修改栋座的一層总戶数、总层数、竣工年份…..
        /// </summary>
        Update4 = 4,
        /// <summary>
        /// 修改单元的房号、室号 (X_AXIS, Y_AXIS)
        /// </summary>
        Update5 = 5,
        /// <summary>
        /// 修改栋座名称
        /// </summary>
        Update6 = 6,
        /// <summary>
        /// 修改楼盘名稱
        /// </summary>
        Update7 = 7,
        /// <summary>
        /// 手工驗查確認地理板塊 (4/1/2010增加)
        /// </summary>
        Update88 = 88,
        /// <summary>
        /// 修改单元內容 
        /// </summary>
        Update19 = 19,
        #endregion
        #region 表示需要删除的信息       
        /// <summary>
        /// 楼盘错误 / 非住宅 需要删除
        /// </summary>
        Delete11 = 11,
        /// <summary>
        /// 楼盘重复需要删除
        /// </summary>
        Delete12 = 12,
        /// <summary>
        /// 栋座号错误 / 非住宅 需要删除
        /// </summary>
        Delete13 = 13,
        /// <summary>
        /// 栋座号重复需要删除
        /// </summary>
        Delete14 = 14,
        /// <summary>
        /// 单元信息错误 / 非住宅 需要删除
        /// </summary>
        Delete15 = 15,
        /// <summary>
        /// 单元信息重复需要删除
        /// </summary>
        Delete16 = 16,
        /// <summary>
        /// SCP_ID(片区) 信息错误需要删除
        /// </summary>
        Delete17 = 17,
        /// <summary>
        /// SCP_ID(片区) 信息重复需要删除	
        /// </summary>
        Delete18 = 18
        #endregion
    }

    public enum EstateTypes
    {
        Bigest,
        Normal,
        Phase,
        Single
    }   
}
