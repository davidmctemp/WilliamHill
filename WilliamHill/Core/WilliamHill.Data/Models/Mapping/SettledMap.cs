using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WilliamHill.Data.Models.Mapping
{
    public class SettledMap : EntityTypeConfiguration<Settled>
    {
        public SettledMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Settled");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Customer).HasColumnName("Customer");
            this.Property(t => t.Event).HasColumnName("Event");
            this.Property(t => t.Participant).HasColumnName("Participant");
            this.Property(t => t.Stake).HasColumnName("Stake");
            this.Property(t => t.Win).HasColumnName("Win");
        }
    }
}
