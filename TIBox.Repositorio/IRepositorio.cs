﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace TIBox.Repositorio
{
    public interface IRepositorio<T> where T: class
    {
        int Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T GetEntityById(int id);
        //List<Customer> GetAllCustomer();
        IEnumerable<T> GetAll();
    }
}
