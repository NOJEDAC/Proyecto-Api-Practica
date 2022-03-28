using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(16)]
    public class InsertGroupRoles : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("16_InsertGroupRoles.sql");
        }

        public override void Down()
        {
        }
    }
}
