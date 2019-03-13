using MVCandMongoDB.Models.ViewModels;
using MVCandMongoDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCandMongoDB.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService;
        public ProductController()
        {
            this.productService = new ProductService();
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = productService.GetAll();
            return View(products);
        }
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var success = productService.Create(viewModel);
            if (success)
                return RedirectToAction("Index");
            return Json(new { success = success });
        }
        public ActionResult Poruci(string id)
        {
            var order = new OrderViewModel
            {
                Product_ID = id
            };
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Poruci(OrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            viewModel.User_ID = "5bd6bb0317f85c0b706221e9";
            var success = productService.Poruci(viewModel);
            if (success)
                return RedirectToAction("Index");
            return Json(new { success = success });
        }
    }
}