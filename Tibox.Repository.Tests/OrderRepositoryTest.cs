﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repository;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private readonly IRepository<Order> _repository;
        public OrderRepositoryTest()
        {
            _repository = new BaseRepository<Order>();
        }
        [TestMethod]
        public void Get_All_orders()
        {
            var orderList = _repository.GetAll();
            Assert.AreEqual(orderList.Count() > 0, true);
        }


    }
}
