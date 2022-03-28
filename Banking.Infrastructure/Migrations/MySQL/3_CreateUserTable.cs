using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(3)]
    public class CreateUserTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("3_CreateUserTable.sql");
        }

        public override void Down()
        {
        }
    }
}
