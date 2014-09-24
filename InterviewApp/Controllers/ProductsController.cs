using InterviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace InterviewApp.Controllers
{
  public class ProductsController : ApiController
  {

    List<Product> products = new List<Product>();

    public ProductsController()
    {
      products.Add(new Product { Id = 1, Name = "Red Bull", Category = "Drinks", Price = 1 });
      products.Add(new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M });
      products.Add(new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M });
    }

    public ProductsController(List<Product> products)
    {
      this.products = products;
    }

    public IEnumerable<Product> GetAllProducts()
    {
      return products;
    }

    public IHttpActionResult GetProduct(int id)
    {
      return null;
    }
  }
}