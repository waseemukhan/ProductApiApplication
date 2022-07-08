using ProductApiApplication.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApiApplication.Model
{
    public class SqlProductData : IProductData
    {
        private ProductContext _productContext;
        public SqlProductData(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public Product CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(Guid id)
        {
            var product = _productContext.Products.Find(id);

            return product;
        }

        public Product GetProductByName(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            return _productContext.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
