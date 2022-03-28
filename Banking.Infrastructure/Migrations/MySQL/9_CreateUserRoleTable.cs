using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(9)]
    public class CreateUserRoleTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("9_CreateUserRoleTable.sql");
        }

        public override void Down()
        {
        }
    }
}
