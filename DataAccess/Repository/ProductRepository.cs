using System.Collections.Generic;
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
    }
}
