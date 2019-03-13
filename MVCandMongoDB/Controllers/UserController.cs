using MVCandMongoDB.Models.ViewModels;
using MVCandMongoDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCandMongoDB.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;
        public UserController()
        {
            this.userService = new UserService();
        }
        // GET: User
        public ActionResult Index()
        {
            var viewModel = userService.GetAll();
            return View(viewModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel viewModel)
        {
            var success = userService.Create(viewModel);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            var viewModel = userService.GetById(id);
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var success = userService.Edit(viewModel);
            if (success)
                return RedirectToAction("Index");
            return View(viewModel);
        }
        public ActionResult Delete(string id)
        {
            var viewModel = userService.GetById(id);
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UserViewModel viewModel)
        {
            var success = userService.Delete(viewModel);
            if (success)
                return RedirectToAction("Index");
            return View(viewModel);
        }
    }
}