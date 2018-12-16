using DBModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAdapter.Database
{
    public class DirectoryBrowserContext : DbContext
    {
        public DirectoryBrowserContext() : base("DFBBase")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DirectoryBrowserContext, DBAdapter.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Entity<User>()
                .ToTable("UsersTable");

            modelBuilder.Entity<User>()
                .MapToStoredProcedures();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Query> Queries { get; set; }
    }
}
