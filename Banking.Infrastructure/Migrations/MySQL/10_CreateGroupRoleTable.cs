using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(10)]
    public class CreateGroupRoleTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("10_CreateGroupRoleTable.sql");
        }

        public override void Down()
        {
        }
    }
}
