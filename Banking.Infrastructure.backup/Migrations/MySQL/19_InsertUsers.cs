using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(19)]
    public class InsertUsers : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("19_InsertUsers.sql");
        }

        public override void Down()
        {
        }
    }
}
