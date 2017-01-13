using BusinessLogic.Facade;
using DataAccess.Entities;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade)
        {
            this._productFacade = productFacade;
        }

        public ActionResult Index()
        {
            var productList = _productFacade.FetchAllProducts();
            return View(productList);
        }

        [HttpGet]
        public ViewResult Add()
        {
            var newProduct = new Product();
            return View(newProduct);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                this._productFacade.AddNewProduct(product);
                TempData["Message"] = "Successfully added the new product";
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}