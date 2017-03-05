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
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IRepositorio<Order> Orders { get; }
        IRepositorio<OrderItem> OrderItems { get; }
        IRepositorio<Product> Products { get; }
        IRepositorio<Supplier> Suppliers { get; }
    }
}
