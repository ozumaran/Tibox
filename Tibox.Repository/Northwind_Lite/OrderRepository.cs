using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository.Northwind_Lite
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public Order OrderByOrderNumber(string orderNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", orderNumber);

                using (var multiple = connection.QueryMultiple("dbo.OrderSearchByOrderNumber", parameters, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var order = multiple.Read<Order>().Single();
                    return order;
                }
            }
        }

        public Order OrderWithOrderItems(string orderNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", orderNumber);

                using (var multiple = connection.QueryMultiple("dbo.OrderWithOrdersItems", parameters, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var order = multiple.Read<Order>().Single();
                    order.OrderItems = multiple.Read<OrderItem>();
                    return order;
                }
            }
        }
    }
}
