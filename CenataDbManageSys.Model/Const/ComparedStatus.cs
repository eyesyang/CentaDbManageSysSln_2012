using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentaDbManageSys.Model
{
    public class ComparedStatus
    {
        public const int DEFAULT = 0;
        public const int DEFAULT_MISS = 7;
        public const int DEFAULT_CLEAR = 8;
        public const int ADDNEW = 1;
        public const int DELETE = 2;
        public const int UPDATE = 3;
        public const int MOVE = 4;
        public const int MERGE = 5;
        public const int RENAME = 6;
    }
}
