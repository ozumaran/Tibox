using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace TIBox.Repositorio
{
    public interface IRepositorio
    {
        int InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        Customer GetCustomerById(int id);
        //List<Customer> GetAllCustomer();
        IEnumerable<Customer> GetAllCustomer();
    }
}
