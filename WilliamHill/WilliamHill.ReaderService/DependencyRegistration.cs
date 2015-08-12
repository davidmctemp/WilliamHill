using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Repository;
using WilliamHill.ReaderService.Interfaces;

namespace WilliamHill.ReaderService
{
    public class DependencyRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileReader>().To<CsvFileReader>();
            Bind<ISettledRepository>().To<SettledRepository>();
            Bind<IUnSettledRepository>().To<UnSettledRepository>();
        }
    }
}
