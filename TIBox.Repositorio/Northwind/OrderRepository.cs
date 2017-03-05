using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace TIBox.Repositorio.Northwind
{
    public class OrderRepository : BaseRepositorio<Order>, IOrderRepository
    {
        public Order OrderWithOrderItems(int OrderNumber)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", OrderNumber);
                using (var multiple =
                        connection.QueryMultiple("[dbo].[OrderWithOrdersItems]",
                        parameters,
                        commandType: System.Data.CommandType.StoredProcedure))
                {
                    var order = multiple.Read<Order>().Single();
                    order.Items = multiple.Read<OrderItem>();
                    return order;
                }

            }
        }

        public Order SearchByOrderNumber(int OrderNumber)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", OrderNumber);

                return connection
                    .QueryFirst<Order>("[dbo].[OrderSearchByOrderNumber]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
