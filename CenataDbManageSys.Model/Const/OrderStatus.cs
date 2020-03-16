using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentaDbManageSys.Model
{
    public class OrderStatus
    {        
        public const int REQUEST = 0;       
        public const int COMPLETED = 1;
        public const int COLLECTING = 2;
        public const int COLLECTED = 3;      
        public const int FRAMEWORKING = 4;
        public const int FRAMEWORKED = 5;
        public const int COMPARED = 6;       
        public const int VALID = 7;
        public const int PROBLEM = 9;
    }
}
