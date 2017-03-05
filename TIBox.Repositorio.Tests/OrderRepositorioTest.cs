using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using TIBox.UnitOfWork;

namespace TIBox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositorioTest
    {
        private readonly IUnitOfWork _unitOfWork;  //Repositorio.IRepositorio<Order> _repositorio;
        public OrderRepositorioTest()
        {
            _unitOfWork = new TIBoxUnitOfWork(); //Repositorio.BaseRepositorio<Order>();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _unitOfWork.Orders.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        [TestMethod]
        public void Order_by_OrderNamber()
        {
            var order = _unitOfWork.Orders.SearchByOrderNumber(542378);
            Assert.AreEqual(order != null, true);

            Assert.AreEqual(order.Id, 1);
            Assert.AreEqual(order.CustomerId, 85);            
        }

        [TestMethod]
        public void Order_With_Items()
        {
            var order = _unitOfWork.Orders.OrderWithOrderItems(542378);
            Assert.AreEqual(order != null, true);

            Assert.AreEqual(order.Items.Any(), true);
        }
    }
}
