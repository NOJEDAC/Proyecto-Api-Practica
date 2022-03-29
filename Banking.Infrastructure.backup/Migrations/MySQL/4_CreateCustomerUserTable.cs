using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(4)]
    public class CreateCustomerUserTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("4_CreateCustomerUserTable.sql");
        }

        public override void Down()
        {
        }
    }
}
