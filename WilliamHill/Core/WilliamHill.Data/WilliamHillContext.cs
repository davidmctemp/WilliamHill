using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WilliamHill.Data.Models;
using WilliamHill.Data.Models.Mapping;

namespace WilliamHill.Data
{
    public partial class WilliamHillContext : DbContext
    {
        static WilliamHillContext()
        {
            Database.SetInitializer<WilliamHillContext>(null);
        }

        public WilliamHillContext()
            : base("Name=WilliamHillContext")
        {
        }

        public DbSet<Settled> Settled { get; set; }
        public DbSet<Unsettled> Unsettled { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SettledMap());
            modelBuilder.Configurations.Add(new UnsettledMap());
        }
    }
}
