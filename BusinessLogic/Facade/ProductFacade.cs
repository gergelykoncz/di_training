using DataAccess.Entities;
using DataAccess.Repository;
using System.Collections.Generic;
using System;

namespace BusinessLogic.Facade
{
    public class ProductFacade : IProductFacade
    {
        private readonly IRepository<Product> _repository;

        public ProductFacade(IRepository<Product> repository)
        {
            this._repository = repository;
        }

        public void AddNewProduct(Product product)
        {
            this._repository.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            this._repository.Delete(product);
        }

        public void EditProduct(Product product)
        {
            this._repository.Update(product);
        }

        public IEnumerable<Product> FetchAllProducts()
        {
            return this._repository.GetAll();
        }

        public IEnumerable<Product> FetchProductsByCategory(string category)
        {
            return this._repository.GetByCriteria(x => x.Category == category);
        }

        public IEnumerable<Product> FetchProductsInStock()
        {
            return this._repository.GetByCriteria(x => x.StockLevel > 0);
        }

        public Product GetProductById(int id)
        {
            return this._repository.GetOne(x => x.ID == id);
        }
    }
}
