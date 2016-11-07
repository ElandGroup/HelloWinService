using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HelloWinService.data.Service;

namespace HelloWinService.data.Jobs
{
    [DisallowConcurrentExecution]
    public class SimpleJob : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            SimpleService.TestCode();
        }

    }


}
