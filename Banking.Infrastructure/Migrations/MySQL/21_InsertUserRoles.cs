using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(21)]
    public class InsertUserRoles : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("21_InsertUserRoles.sql");
        }

        public override void Down()
        {
        }
    }
}
