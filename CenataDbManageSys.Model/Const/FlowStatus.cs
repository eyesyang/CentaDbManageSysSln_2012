using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentaDbManageSys.Model
{
    public class FlowStatus
    {
        public const int COLLECTING = 0;
        public const int COLLECTING_ORDERSTATUS = 3;
        public const int COLLECTED = 1;
        public const int COLLECTED_ORDERSTATUS = 4;
        public const int EXPORTED = 2;
        public const int EXPORTED_ORDERSTATUS = 5;
    }
}
