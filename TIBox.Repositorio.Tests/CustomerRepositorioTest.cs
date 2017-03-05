using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Models;
using TIBox.Repositorio.Northwind;

namespace TIBox.DataAccess.Tests
{
    [TestClass]
    public class CustomerDataAccessTest
    { 
        private readonly ICustomerRepository _repositorio; // Repositorio.IRepositorio<Customer> _repositorio;
        public CustomerDataAccessTest()
        {
            _repositorio = new CustomerRepository(); // Repositorio.BaseRepositorio<Customer>();
        }
        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _repositorio.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Customers()
        {
            var customer = new Customer
            {
                FirstName = "Raul",
                LastName = "Alva",
                City = "Trujillo",
                Country = "Peru",
                Phone = "999-999-999"
            };
            var result = _repositorio.Insert(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Delete_Customers()
        {
            var customer = _repositorio.GetEntityById(1092);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(_repositorio.Delete(customer), true);
        }

        [TestMethod]
        public void Update_Customers()
        {
            var customer = _repositorio.GetEntityById(93);
            Assert.AreEqual(customer != null, true);

            customer.Phone = "988-888-888";

            Assert.AreEqual(_repositorio.Update(customer), true);
        }

        [TestMethod]
        public void Customer_by_Names()
        {
            var customer = _repositorio.SearchByName("Maria", "Anders");
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Id, 1);
            Assert.AreEqual(customer.FirstName, "Maria");
            Assert.AreEqual(customer.LastName,"Anders");
        }

    }
}
