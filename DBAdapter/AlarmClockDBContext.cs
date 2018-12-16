/*
using System.Data.Entity;
using DBModels;
using DBAdapter.Migrations;

namespace DBAdapter
{
    class AlarmClockDBContext : DbContext
    {

        public AlarmClockDBContext() : base("NewAlarmClockDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlarmClockDBContext, Configuration>(true));
        }

        public DbSet<User1> Users { get; set; }
        public DbSet<AlarmClock> AlarmClocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User1.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new AlarmClock.AlarmClockEntityConfiguration());
        }
    }
}
*/