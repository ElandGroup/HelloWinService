using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HelloWinService.data.Service;
using Common.Logging;

namespace HelloWinService.data.Jobs
{
    [DisallowConcurrentExecution]
    public class SimpleJob : IJob
    {
        ILog log = LogManager.GetLogger("Logger"); 
        public void Execute(IJobExecutionContext context)
        {
            log.Info("SimpleJob");
        }

    }


}
