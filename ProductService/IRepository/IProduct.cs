using System;
using ProductService.Models;

namespace ProductService.IRepository
{
    public interface IProduct
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(Product product);
    }
}
