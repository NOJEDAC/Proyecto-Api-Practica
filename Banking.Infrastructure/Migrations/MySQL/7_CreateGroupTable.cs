using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(7)]
    public class CreateGroupTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("7_CreateGroupTable.sql");
        }

        public override void Down()
        {
        }
    }
}
