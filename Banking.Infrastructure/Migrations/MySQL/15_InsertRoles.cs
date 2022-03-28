using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(15)]
    public class InsertRoles : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("15_InsertRoles.sql");
        }

        public override void Down()
        {
        }
    }
}
