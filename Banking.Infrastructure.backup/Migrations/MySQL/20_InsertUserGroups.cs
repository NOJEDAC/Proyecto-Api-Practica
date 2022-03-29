using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(20)]
    public class InsertUserGroups : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20_InsertUserGroups.sql");
        }

        public override void Down()
        {
        }
    }
}
