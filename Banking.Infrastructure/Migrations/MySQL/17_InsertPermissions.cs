using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(17)]
    public class InsertPermissions : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("17_InsertPermissions.sql");
        }

        public override void Down()
        {
        }
    }
}
