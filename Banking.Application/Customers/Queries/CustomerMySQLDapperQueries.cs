using Banking.Application.Customers.Contracts;
using Banking.Application.Customers.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Banking.Application.Customers.Queries
{
    public class CustomerMySQLDapperQueries : ICustomerQueries
    {
        public List<CustomerDto> GetListPaginated(int page = 0, int pageSize = 5, string column = "firstName", string value = "")
        {
            string sql = @"
                    SELECT 
                        c.customer_id AS id,
                        c.first_name AS firstName,
                        c.last_name AS lastName,
                        c.identity_document AS identityDocument,
                        c.active
                    FROM 
                        customer c 
                    WHERE 
	                    first_name like concat('%',@Value,'%')
                    ORDER BY 
                        c.last_name ASC, c.first_name ASC
                    LIMIT @Page, @PageSize;";
            string connectionString = Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<CustomerDto> customers = connection
                        .Query<CustomerDto>(sql, new
                        {
                            Page = page,
                            PageSize = pageSize,
                            Column = column,
                            Value = value
                        })
                        .ToList();
                    return customers;
                } catch(Exception ex) {
                    ex.ToString();
                    return new List<CustomerDto>();
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
