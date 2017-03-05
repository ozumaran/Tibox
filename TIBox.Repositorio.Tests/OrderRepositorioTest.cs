using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace TIBox.DataAccess.Tests
{
    public class OrderRepositorioTest
    {
        private readonly Repositorio.IRepositorio<Order> _repositorio;
        public OrderRepositorioTest()
        {
            _repositorio = new Repositorio.BaseRepositorio<Order>();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _repositorio.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }
    }
}
