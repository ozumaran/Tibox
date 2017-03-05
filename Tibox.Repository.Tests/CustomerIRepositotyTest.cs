using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Repository;
using Tibox.Models;
using Tibox.Repository.Northwind;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerIRepositotyTest
    {
        private readonly ICustomerRepository _repository;
        public CustomerIRepositotyTest()
        {
            _repository = new CustomerRepository();
        }

        [TestMethod]
        public void Customer_By_Names()
        {
            var result = _repository.SearchByNames("Maria", "Anders");
            Assert.AreEqual(result != null, true);

            //Assert.AreEqual(result.Id, true);
            //Assert.AreEqual(result.FirstName, "Maria");
            //Assert.AreEqual(result.LastName, "Anders");
        }
    }
}
