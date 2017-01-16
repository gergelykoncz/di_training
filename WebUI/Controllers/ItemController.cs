using BusinessLogic.Facade;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IProductFacade _productFacade;

        public ItemController(IProductFacade productFacade)
        {
            this._productFacade = productFacade;
        }

        // GET: api/Item
        public IEnumerable<Product> Get()
        {
            return this._productFacade.FetchAllProducts();
        }

        // GET: api/Item/5
        public Product Get(int id)
        {
            return this._productFacade.GetProductById(id);
        }

        // POST: api/Item
        public void Post([FromBody]Product value)
        {
            this._productFacade.AddNewProduct(value);
        }

        // PUT: api/Item/5
        public void Put(int id, [FromBody]Product value)
        {
            this._productFacade.EditProduct(value);
        }

        // DELETE: api/Item/5
        public void Delete(int id)
        {
            var product = this._productFacade.GetProductById(id);
            this._productFacade.DeleteProduct(product);
        }
    }
}
