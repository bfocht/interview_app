using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewApp.Controllers;
using System.Collections.Generic;
using InterviewApp.Models;
using System.Web.Http.Results;
using System.Linq;

namespace InterviewApp.Tests
{
  [TestClass]
  public class ProductsControllerTest
  {
    [TestMethod]
    public void it_should_get_all_products()
    {
      var testProducts = GetTestProducts();
      var controller = new ProductsController(testProducts);
      var result = controller.GetAllProducts() as List<Product>;
      Assert.AreEqual(testProducts.Count, result.Count);
    }

    [TestMethod]
    public void it_should_return_correct_product()
    {
      var testProducts = GetTestProducts();
      var controller = new ProductsController(testProducts);
      var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
      Assert.IsNotNull(result);
      Assert.AreEqual(testProducts[3].Name, result.Content.Name);
    }

    [TestMethod]
    public void it_should_not_find_a_product()
    {
      var controller = new ProductsController(GetTestProducts());
      var result = controller.GetProduct(999);
      Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

    private List<Product> GetTestProducts()
    {
      var testProducts = new List<Product>();
      testProducts.Add(new Product { Id = 1, Name = "Demo1", Price = 1 });
      testProducts.Add(new Product { Id = 2, Name = "Demo2", Price = 3.75M });
      testProducts.Add(new Product { Id = 3, Name = "Demo3", Price = 16.99M });
      testProducts.Add(new Product { Id = 4, Name = "Demo4", Price = 11.00M });

      return testProducts;
    }


  }
}
