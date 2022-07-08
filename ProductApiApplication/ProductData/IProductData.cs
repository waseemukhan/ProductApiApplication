using ProductApiApplication.Model;
using System;
using System.Collections.Generic;

namespace ProductApiApplication.ProductData
{
    public interface IProductData
    {
        /// <summary>
        /// This method is used for create new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Product CreateProduct(Product product);

        /// <summary>
        /// This method is used for delete product
        /// </summary>
        /// <param name="product"></param>
        void DeleteProduct(Product product);

        /// <summary>
        /// This method is used for update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Product UpdateProduct(Product product);
        List<Product> GetProducts();
        Product GetProduct(Guid id);
        Product GetProductByName(Product product);
    }
}
