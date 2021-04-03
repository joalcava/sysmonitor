using Microsoft.EntityFrameworkCore.Migrations;

namespace SysMonitor.Logic.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonitoringData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OsName = table.Column<string>(type: "TEXT", nullable: true),
                    HostName = table.Column<string>(type: "TEXT", nullable: true),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: true),
                    DiskCapacity = table.Column<double>(type: "REAL", nullable: false),
                    DiskUsage = table.Column<double>(type: "REAL", nullable: false),
                    RamCapacity = table.Column<double>(type: "REAL", nullable: false),
                    RamUsage = table.Column<double>(type: "REAL", nullable: false),
                    CpuName = table.Column<string>(type: "TEXT", nullable: true),
                    CpuUsage = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitoringData");
        }
    }
}
