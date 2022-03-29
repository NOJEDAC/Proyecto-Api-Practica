using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(22)]
    public class InsertCustomerUsers : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("22_InsertCustomerUsers.sql");
        }

        public override void Down()
        {
        }
    }
}
