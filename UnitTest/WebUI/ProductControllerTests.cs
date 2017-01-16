using BusinessLogic.Facade;
using DataAccess.Entities;
using DataAccess.Repository;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Controllers;
using Xunit;

namespace UnitTest.WebUI
{
    public class ProductControllerTests
    {
        [Fact]
        public void IndexShouldSetModel()
        {
            IProductFacade fakeFacade = A.Fake<IProductFacade>();
            var fakeProductList = new List<Product>();
            fakeProductList.Add(new Product() { ID = 1, Name = "Bob" });
            A.CallTo(() => fakeFacade.FetchAllProducts()).Returns(fakeProductList);
            var productController = new ProductController(fakeFacade);

            var result = productController.Index() as ViewResult;

            Assert.Equal(fakeProductList, result.Model);
        }

        [Fact]
        public void DetailsShouldReturnProduct()
        {
            IProductFacade fakeFacade = A.Fake<IProductFacade>();
            var fakeProduct = new Product();
            fakeProduct.Name = "The fake product";
            A.CallTo(() => fakeFacade.GetProductById(A<int>.Ignored)).Returns(fakeProduct);
            var productController = new ProductController(fakeFacade);

            var model = productController.Edit(1).Model as Product;

            Assert.Equal("The fake product", model.Name);
        }

        [Fact]
        public void EditShouldShowViewOnValidationError()
        {
            var fakeFacade = A.Fake<IProductFacade>();
            var productController = new ProductController(fakeFacade);
            productController.ModelState.AddModelError("An error", new Exception());
            var product = new Product();

            var result = productController.Edit(product) as ViewResult;

            Assert.Equal(product, result.Model);
        }

        [Fact]
        public void EditShouldRedirectWhenSuccess()
        {
            var fakeFacade = A.Fake<IProductFacade>();
            var productController = new ProductController(fakeFacade);
            var product = new Product()
            {
                ID = 1,
                Name = "Kayak"
            };

            var result = productController.Edit(product) as RedirectToRouteResult;

            A.CallTo(() => fakeFacade.EditProduct(product)).MustHaveHappened();
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Heyy()
        {

        }
    }
}
