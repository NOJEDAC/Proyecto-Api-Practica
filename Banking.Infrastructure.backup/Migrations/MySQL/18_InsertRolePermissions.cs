using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(18)]
    public class InsertRolePermissions : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("18_InsertRolePermissions.sql");
        }

        public override void Down()
        {
        }
    }
}
