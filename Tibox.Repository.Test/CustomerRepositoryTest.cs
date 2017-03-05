using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Repository;
using System.Linq;
using Tibox.Models;
namespace Tibox.DataAccess.Test
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class CustomerDataAccessTest
    {
        private readonly IRepository<Customer> _repository;

        public CustomerDataAccessTest()
        {
            _repository = new Repository.BaseRepository<Customer>();
        }
        
        [TestMethod]
        public void Get_All_Cusstomers()
        {
            var result = _repository.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Customer()
        {
            var customer = new Customer
            {
                FirstName = "Oscar",
                LastName = "Zumaran",
                City = "Talara",
                Country = "Peru",
                Phone = "282903"
            };
            var result = _repository.Insert(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var customer = new Customer
            {
                FirstName = "Oscar2",
                LastName = "Zumaran2",
                City = "Talara2",
                Country = "Peru2",
                Phone = "2829032",
                Id=10
            };

            Assert.AreEqual(_repository.Insert(customer), true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = _repository.GetEntityById(15);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(_repository.Delete (customer), true);
        }
    }
}
