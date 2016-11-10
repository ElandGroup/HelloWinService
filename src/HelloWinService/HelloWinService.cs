using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Common.Logging;
using HelloWinService.data;

namespace HelloWinService
{
    public partial class HelloWinService : ServiceBase
    {
        ILog log = LogManager.GetLogger("Logger");
        public HelloWinService()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
        }

        protected override void OnStart(string[] args)
        {
            log.Info("OrderCloud Service Starting...");
            JobHelper.JobLoader();
        }

        protected override void OnStop()
        {
            JobHelper.QuartzShutdown(false);
            log.Info("OrderCloud Service Stop...");
        }
    }
}
