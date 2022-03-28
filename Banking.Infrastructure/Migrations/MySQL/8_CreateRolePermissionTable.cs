using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(8)]
    public class CreateRolePermissionTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("8_CreateRolePermissionTable.sql");
        }

        public override void Down()
        {
        }
    }
}
