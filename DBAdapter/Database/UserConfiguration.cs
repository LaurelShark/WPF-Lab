using DBModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBAdapter.Database
{
    class UserConfiguration : EntityTypeConfiguration<LabUser>
    {
        public UserConfiguration()
        {
            this.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
