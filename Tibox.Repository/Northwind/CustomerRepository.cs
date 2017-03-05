using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using System.Data.SqlClient;
using Dapper;

namespace Tibox.Repository.Northwind
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public Customer SearchByNames(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstName);
                parameters.Add("@lastName", lastName);

                return connection
                    .QueryFirst<Customer>("dbo.CustomerSearchByNames", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
