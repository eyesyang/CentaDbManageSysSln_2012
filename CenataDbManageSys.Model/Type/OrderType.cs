using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CentaLine.Common;

namespace CentaDbManageSys.Model
{
    public class OrderType
    {
        public int OrderId
        {
            get;
            set;
        }
        public string EstateId
        {
            get;
            set;
        }
        public int StatusId
        {
            get;
            set;
        }
        public string CreateBy
        {
            get;
            set;
        }
        public DateTime CreateDate
        {
            get;
            set;
        }
        public string CompletedBy
        {
            get;
            set;
        }
        public DateTime CompletedDate
        {
            get;
            set;
        }

        public OrderType()
        {

        }
        public OrderType(DataRow row)
        {
            this.OrderId = ConvertUtility.ToInt(row["OrderId"]);
            this.EstateId = ConvertUtility.Trim(row["EstateId"]);
            this.StatusId = ConvertUtility.ToInt(row["StatusId"]);
            this.CreateBy = ConvertUtility.Trim(row["CreateBy"]);
            this.CreateDate = ConvertUtility.ToDateTime(row["CreateDate"]);
            this.CompletedBy = ConvertUtility.Trim(row["CompletedBy"]);
            this.CompletedDate = ConvertUtility.ToDateTime(row["CompletedDate"]);
        }
    }
}
