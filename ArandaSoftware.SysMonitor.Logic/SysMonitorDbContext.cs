using Microsoft.EntityFrameworkCore;

namespace ArandaSoftware.SysMonitor.Logic
{
    public class SysMonitorDbContext : DbContext
    {
        public DbSet<MonitoringData> MonitoringData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=monitoring_db.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}