using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(11)]
    public class CreateUserGroupTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("11_CreateUserGroupTable.sql");
        }

        public override void Down()
        {
        }
    }
}
