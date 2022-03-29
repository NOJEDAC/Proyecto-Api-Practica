using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(13)]
    public class InsertAccounts : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("13_InsertAccounts.sql");
        }

        public override void Down()
        {
        }
    }
}
