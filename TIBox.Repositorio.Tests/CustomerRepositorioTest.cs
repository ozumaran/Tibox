using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Models;

namespace TIBox.DataAccess.Tests
{
    [TestClass]
    public class CustomerDataAccessTest
    {
        private readonly Repositorio.IRepositorio _repositorio;
        public CustomerDataAccessTest()
        {
            _repositorio = new Repositorio.Repositorio();
        }
        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _repositorio.GetAllCustomer();
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
            var result = _repositorio.InsertCustomer(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Delete_Customers()
        {
            var customer = _repositorio.GetCustomerById(99);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(_repositorio.DeleteCustomer(customer), true);
        }

        [TestMethod]
        public void Update_Customers()
        {
            var customer = _repositorio.GetCustomerById(93);
            Assert.AreEqual(customer != null, true);

            customer.Phone = "988-888-888";

            Assert.AreEqual(_repositorio.UpdateCustomer(customer), true);
        }


    }
}
