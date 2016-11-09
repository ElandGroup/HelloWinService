using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using HelloWinService.data.Jobs;
using HelloWinService.data.Helper;

namespace HelloWinService.data
{
    public class JobHelper
    {
        static ISchedulerFactory factory;
        static IScheduler scheduler;
        public static void JobLoader()
        {
            //init
            factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler();
            //set rule
            SimpleJobQuartz();

            //start quartz
            scheduler.Start();
        }

        private static void SimpleJobQuartz()
        {
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                              .WithIdentity("SimpleJob", "group1")
                              .Build();
            SimpleQuartz("SimpleJob", job);
        }
        private static void SimpleCronJobQuartz()
        {
            IJobDetail job = JobBuilder.Create<SimpleCronJob>()
                              .WithIdentity("SimpleCronJob", "group1")
                              .Build();
            CronQuartz("SimpleCronJob", job);
        }

        /// <summary>
        /// SimpleQuartz
        /// </summary>
        /// <param name="packageDownloaderJobInAppSettings">appSettings in appSettings config</param>
        private static void SimpleQuartz(string appSettingsKey, IJobDetail job)
        {
            int seconds = TimeSpanHelper.GetSecond(ConfigurationManager.AppSettings[appSettingsKey]);
            // Trigger the job to run on the next round minute

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1" + job.Key, "group1")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(seconds).RepeatForever())
                .StartNow()
                .Build();

            // Tell quartz to schedule the job using our trigger
            scheduler.ScheduleJob(job, trigger);

        }
        /// <summary>
        /// CronQuartz
        /// </summary>
        /// <param name="packageDownloaderJobInAppSettings">appSettings in appSettings config</param>
        private static void CronQuartz(string appSettingsKey, IJobDetail job)
        {
            string cronExpress = ConfigurationManager.AppSettings[appSettingsKey];
            // Trigger the job to run on the next round minute
            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1" + appSettingsKey, "group1")
            .WithCronSchedule(cronExpress)
            .StartNow()
            .Build();

            // Tell quartz to schedule the job using our trigger
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
