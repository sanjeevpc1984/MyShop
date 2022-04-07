using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.WebUI;
using MyShop.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MyShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexPageDoesReturnProduct()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();

            productContext.Insert(new Product());

            HomeController controller = new HomeController(productContext, productCategoryContext);
            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;
            Assert.AreEqual(1, viewModel.Products.Count());
        }
        [TestMethod]
        public void DetailPageWithProduct()
        {

            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();

            productContext.Insert(new Product() { Id="1", Name= "Bumble Bee" });

            HomeController controller = new HomeController(productContext, productCategoryContext);
            var result = controller.Details("1") as ViewResult;
            var model = (Product)result.ViewData.Model;
            Assert.AreEqual("1", model.Id);
            Assert.AreEqual("Bumble Bee", model.Name);
        }
    }
}
