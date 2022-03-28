using Banking.Application.Accounts.Contracts;
using Banking.Application.Accounts.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Application.Accounts.Queries
{
    public class AccountMySQLDapperQueries : IAccountQueries
    {
        public List<AccountDto> GetListPaginated(long customerId, int page = 0, int pageSize = 5)
        {
            string sql = @"
                    SELECT 
                        a.account_id AS id,
                        a.number,
                        a.balance,
                        a.locked,
                        CONCAT(c.first_name,' ', c.last_name) AS customerName
                    FROM 
                        account a
                        JOIN (SELECT a2.account_id FROM account a2 ORDER BY a2.number ASC LIMIT @Page, @PageSize)
                            AS a3 ON a.account_id = a3.account_id
                        JOIN customer c ON a.customer_id = c.customer_id
                    WHERE
                        c.customer_id = @CustomerId
                    ORDER BY 
                        a.number ASC;";
            string connectionString = Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<AccountDto> accounts = connection
                    .Query<AccountDto>(sql, new
                    {
                        Page = page,
                        PageSize = pageSize,
                        CustomerId = customerId
                    })
                    .ToList();
                    return accounts;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return new List<AccountDto>();
                }
                finally
                {
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
