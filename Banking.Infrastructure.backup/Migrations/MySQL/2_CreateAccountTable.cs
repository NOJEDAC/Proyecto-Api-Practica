using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(2)]
    public class CreateAccountTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_CreateAccountTable.sql");
        }

        public override void Down()
        {
        }
    }
}
