using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace TIBox.Repositorio.Northwind
{
    public interface ICustomerRepository: IRepositorio<Customer>
    {
        Customer SearchByName(string firstName, string lastName);
    }
}
