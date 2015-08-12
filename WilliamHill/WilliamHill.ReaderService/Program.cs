using Quartz;
using System.Configuration;
using Topshelf;
using Topshelf.Quartz;
using Topshelf.Ninject;
using Topshelf.Quartz.Ninject;

namespace WilliamHill.ReaderService
{
    class Program
    {
        private static int Main(string[] args)
        {
            return (int)HostFactory.Run(svc =>
            {
                svc.UseNinject(new DependencyRegistration());
                svc.UseQuartzNinject();

                svc.ScheduleQuartzJobAsService(job =>
                {
                    job
                        .WithJob(() => JobBuilder.Create<CsvReaderJob>().Build())
                        .AddTrigger(
                            () =>
                                TriggerBuilder.Create()
                                    .WithCronSchedule(ConfigurationManager.AppSettings["CsvImporter"])
                                    .Build());
                });

                svc.RunAsLocalSystem();

                svc.SetDescription("WilliamHill.CsvImporter");
                svc.SetDisplayName("WilliamHill.CsvImporter");
                svc.SetServiceName("WilliamHill.CsvImporter");
            });
        }
    }
}
