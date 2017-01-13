using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class ProductRepository : RepositoryBase<Product>
    {
        protected override IEnumerable<Product> fillData()
        {
            return new List<Product>()
            {
                 new Product() {
                ID = 1,
                Name = "Kayak",
                Category = "Watersports",
                Description = "A boat like thing",
                Price = 100.00M,
                StockLevel = 100
            }
            };
        }

        public override void Update(Product entity)
        {
            Product original = this._inner.Single(x => x.ID == entity.ID);
            original.Category = entity.Category;
            original.Description = entity.Description;
            original.Name = entity.Name;
            original.Price = entity.Price;
            original.StockLevel = entity.StockLevel;
        }
    }
}
