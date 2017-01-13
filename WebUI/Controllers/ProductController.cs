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

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var product = this._productFacade.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                this._productFacade.EditProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            var product = this._productFacade.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = this._productFacade.GetProductById(id);
            this._productFacade.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}