using ProductApiApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductApiApplication.ProductData
{
    public class MockProductData : IProductData
    {
        private List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Product One"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Product Two"
            }
        };

        public Product CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            products.Add(product);

            return product;
        }
        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public Product GetProduct(Guid id)
        {
            return products.SingleOrDefault(x => x.Id == id);
        }

        public Product GetProductByName(Product product)
        {
            return products.SingleOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product UpdateProduct(Product product)
        {
            var existingProduct = GetProduct(product.Id);

            existingProduct.Name = product.Name;

            return existingProduct;
        }
    }
}
