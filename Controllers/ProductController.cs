using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Title = "Laptop", Price = 1000 },
            new Product { Id = 2, Title = "Smartphone", Price = 700 },
            new Product { Id = 3, Title = "Tablet", Price = 400 }
        };

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_products);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { status = 404, message = "Product not found" });
            }
            return Ok(product);
        }

        [HttpPost("[action]")]
        public ActionResult AddProduct([FromBody] ProductVM product)
        {
            var newProduct = new Product()
            {
                Id = new Random().Next(),
                Title = product.Title,
                Price = product.Price,
            };
            _products.Add(newProduct);
            return Ok(new { status = 200, message = "Product added successfully", product });
        }

        [HttpPut("[action]")]
        public ActionResult UpdateProduct([FromBody] Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null)
            {
                return NotFound(new { status = 404, message = "Product not found" });
            }
            product.Title = updatedProduct.Title;
            product.Price = updatedProduct.Price;
            return Ok(new { status = 200, message = "Product updated successfully", product });
        }

        [HttpDelete("[action]/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { status = 404, message = "Product not found" });
            }
            _products.Remove(product);
            return Ok(new { status = 200, message = "Product deleted successfully" });
        }

        // Product class definition
        public class Product
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
        }

        public class ProductVM
        {
            public string Title { get; set; }
            public decimal Price { get; set; }
        }
    }
}
