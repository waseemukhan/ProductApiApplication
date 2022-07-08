using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProductApiApplication.Model;
using ProductApiApplication.ProductData;
using System;
using System.Collections.Generic;

namespace ProductApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductData _productData;
        private readonly IMemoryCache _memoryCache;
        private readonly string productKey = "productKey";
        public ProductController(IProductData productData, IMemoryCache memoryCache)
        {
            _productData = productData;
            _memoryCache = memoryCache;
        }

        // GET api/<ProductController>
        [HttpGet]
        public List<Product> GetProducts()
        {
            if (!_memoryCache.TryGetValue(productKey, out List<Product> products))
            {
                products = _productData.GetProducts(); // Get the data from database
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _memoryCache.Set(productKey, products, cacheEntryOptions);
            }
            return products;
        }

        // GET api/<ProductController>
        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _productData.GetProduct(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound($"Product with Id: {id} was not found");
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var existingProduct = _productData.GetProductByName(product);

            if (existingProduct == null)
            {
                _productData.CreateProduct(product);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + product.Id,
                    product);
            }

            return Conflict("Product already exist!");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productData.GetProduct(id);

            if (product != null)
            {
                _productData.DeleteProduct(product);

                return Ok();
            }

            return NotFound($"Product with Id: {id} was not found");
        }


        // DELETE api/<ProductController>/5
        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(Guid id, Product product)
        {
            var existingProduct = _productData.GetProduct(id);

            if (existingProduct != null)
            {
                product.Id = existingProduct.Id;
                _productData.UpdateProduct(product);
            }

            return Ok(product);
        }
    }
}
