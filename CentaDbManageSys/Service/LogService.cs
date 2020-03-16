using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace CentaDbManageSys.Service
{
    public class LogService
    {
        public void Error(object message)
        {
            ILog log = LogManager.GetLogger("logerror");
            log.Error(message);
        }
        public void Info(object message)
        {
            ILog log = LogManager.GetLogger("loginfo");
            log.Info(message);
        }
    }
}