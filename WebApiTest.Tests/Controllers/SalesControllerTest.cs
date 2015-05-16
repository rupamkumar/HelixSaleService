using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiTest;
using WebApiTest.Controllers;
using WebApiTest.Models;


namespace WebApiTest.Tests.Controllers
{
  [TestClass]
    public  class SalesControllerTest
    {

      [TestMethod]
      public void GetSale()
      {
          // Arrange
          SalesController_ controller = new SalesController_();

          // Act
          IEnumerable<Sale> result = controller.GetSales();

          // Assert
          Assert.IsNotNull(result);
          Assert.AreEqual(0, result.Count());
          
      }

      [TestMethod()]
      public void PutSaleTest()
      {
          // Arrange
          SalesController_ controller = new SalesController_();
          Sale sale = new Sale();
          sale.location_name = "EXX";
          sale.sales_person_name = "test";
          sale.ProductId = 2;
          sale.ProductName = "Test2";
          sale.total_sale_amount = 56.23;
          sale.currency = "USD";
          
          // Act
          controller.PutSale(13, sale);

      }
    }
}
