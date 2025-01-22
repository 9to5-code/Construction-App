using System;
using ProductService.IRepository;
using ProductService.Models;

namespace ProductService.Repository
{
    public class ProductRepository:IProduct
    {
        private static List<Product> products = new List<Product>();

        public IEnumerable<Product> GetAllProducts()
        { 
            return products;
        }

        public void CreateProduct(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
        }
    }
}
