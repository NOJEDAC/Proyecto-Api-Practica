using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(5)]
    public class CreateRoleTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("5_CreateRoleTable.sql");
        }

        public override void Down()
        {
        }
    }
}
