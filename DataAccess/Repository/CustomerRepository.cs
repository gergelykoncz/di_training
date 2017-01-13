using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        protected override IEnumerable<Customer> fillData()
        {
            return new List<Customer>();
        }
    }
}
