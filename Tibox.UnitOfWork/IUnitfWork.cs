using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Repository;
using Tibox.Models;
using Tibox.Repository.Northwind;

namespace Tibox.UnitOfWork
{
    public interface IUnitfWork
    {
        Customers = new CustomerRepository();
        Orders = new baseRepository<Order>();
            OrderItems = new baseRepository<OrderItem>();
            Products = new baseRepository<Products>();

    }
    ICustomerRepository Customers { get;  set; }
        IRepository<Order> Orders { get; private set; }
        IRepository<OrderItem> OrderItems { get; private set; }
        IRepository<Product> Products { get; private set; }
        IRepository<Supplier> Suppliers { get; private set; }
}
