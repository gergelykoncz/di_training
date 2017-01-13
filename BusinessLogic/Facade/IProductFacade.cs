using DataAccess.Entities;
using System.Collections.Generic;

namespace BusinessLogic.Facade
{
    public interface IProductFacade
    {
        IEnumerable<Product> FetchAllProducts();
        void AddNewProduct(Product product);
        Product GetProductById(int id);
        IEnumerable<Product> FetchProductsInStock();
        IEnumerable<Product> FetchProductsByCategory(string category);
    }
}
