using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using TIBox.Repositorio;
using TIBox.Repositorio.Northwind;

namespace TIBox.UnitOfWork
{
    public class TIBoxUnitOfWork : IUnitOfWork, IDisposable
    {
        public ICustomerRepository Customer { get; private set; }
        public IRepositorio<Order> Orders { get; private set; }
        public IRepositorio<OrderItem> OrderItems { get; private set; }
        public IRepositorio<Product> Products { get; private set; }
        public IRepositorio<Supplier> Suppliers { get; private set; }

        public TIBoxUnitOfWork()
        {
            this.Customer = new CustomerRepository();
            this.Orders = new BaseRepositorio<Order>();
            this.OrderItems = new BaseRepositorio<OrderItem>();
            this.Products = new BaseRepositorio<Product>();
            this.Suppliers = new BaseRepositorio<Supplier>();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
