using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(12)]
    public class InsertCustomers : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("12_InsertCustomers.sql");
        }

        public override void Down()
        {
        }
    }
}
