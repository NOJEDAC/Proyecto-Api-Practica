using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(1)]
    public class CreateCustomerTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("1_CreateCustomerTable.sql");
        }

        public override void Down()
        {
        }
    }
}
