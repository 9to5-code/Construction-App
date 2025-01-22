

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProductService.IRepository;
using ProductService.Models;

namespace ProductService.Controller{
    
 [ApiController]
 [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new string[] { "Product1", "Product2" });

        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _productService.CreateProduct(product);
            return CreatedAtAction(nameof(Create), new { id = product.Id }, product);
        }
    }
}