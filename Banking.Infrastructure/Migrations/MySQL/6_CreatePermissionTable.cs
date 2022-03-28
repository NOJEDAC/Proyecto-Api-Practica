using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(6)]
    public class CreatePermissionsTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("6_CreatePermissionTable.sql");
        }

        public override void Down()
        {
        }
    }
}
