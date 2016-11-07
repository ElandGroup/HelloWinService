using System;
using System.IO;
using System.ServiceProcess;
using HelloWinService.data;
using HelloWinService.data.Service;

namespace HelloWinService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {

#if DEBUG
            JobHelper.JobLoader();
            Console.Read();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new HelloWinService() 
            };
            ServiceBase.Run(ServicesToRun);
#endif

        }

    }
}
