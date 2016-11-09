# HelloWinService

### Windows Service
	1.DEBUG this Service

```sh

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

```

	2.modify serviceName

```sh

  <appSettings>
    <add key="ServiceName" value="HelloWinService DEV" />
  </appSettings>
```

### Quartz

	add a Quartz

```sh

	1.JobHelper.JobLoader();
	2.
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
	3.
	    private static void SimpleJobQuartz()
        {
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                              .WithIdentity("SimpleJob", "group1")
                              .Build();
            SimpleQuartz("SimpleJob", job);
        }
	4.
		[DisallowConcurrentExecution]
		public class SimpleJob : IJob
		{
			ILog log = LogManager.GetLogger("Logger"); 
			public void Execute(IJobExecutionContext context)
			{
				log.Info("SimpleJob");
			}

		}
	5.
	  <appSettings>
		<add key="SimpleJob" value="5s" />
	  </appSettings>
```

### log4net

```sh
ILog log = LogManager.GetLogger("Logger");
log.Info("SimpleCronJob");

```
### Test result

```sh

path:C:\Users\Administrator\Desktop\HelloWinService\src\HelloWinService\bin\Debug\Logs

log:
2016-11-07 15:26:24,200 [DefaultQuartzScheduler_Worker-1] - SimpleJob
2016-11-07 15:26:24,218 [DefaultQuartzScheduler_Worker-2] - SimpleJob
2016-11-07 15:26:24,218 [DefaultQuartzScheduler_Worker-3] - SimpleJob
2016-11-07 15:26:28,208 [DefaultQuartzScheduler_Worker-4] - SimpleJob
2016-11-07 15:26:33,199 [DefaultQuartzScheduler_Worker-5] - SimpleJob
2016-11-07 15:26:38,199 [DefaultQuartzScheduler_Worker-6] - SimpleJob

```

### modify projectName

```sh

	ReplaceName tools in IE: http://10.202.101.10/ReplaceName/

```

Thank you
