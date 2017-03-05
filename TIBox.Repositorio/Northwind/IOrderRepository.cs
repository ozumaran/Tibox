using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace TIBox.Repositorio.Northwind
{
    public interface IOrderRepository: IRepositorio<Order>
    {
        Order SearchByOrderNumber(int OrderNumber);
        Order OrderWithOrderItems(int OrderNumber);
    }
}
