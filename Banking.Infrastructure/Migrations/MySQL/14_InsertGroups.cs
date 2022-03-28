using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(14)]
    public class InsertGroups : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("14_InsertGroups.sql");
        }

        public override void Down()
        {
        }
    }
}
