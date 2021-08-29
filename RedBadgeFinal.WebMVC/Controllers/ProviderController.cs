using Microsoft.AspNet.Identity;
using RedBadgeFinal.Models;
using RedBadgeFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.WebMVC.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProviderService(userId);
            var model = service.GetProviders();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProviderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProviderService();

            if (service.CreateProvider(model))
            {
                TempData["SaveResult"] = "Your provider was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Provider could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProviderService();
            var model = svc.GetProviderById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProviderService();
            var detail = service.GetProviderById(id);
            var model =
                new ProviderEdit
                {
                    ProvId = detail.ProvId,
                    ProvName = detail.ProvName,
                    LocationId = detail.LocationId,
                    ServiceId = detail.ServiceId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProviderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProvId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProviderService();

            if (service.UpdateProvider(model))
            {
                TempData["SaveResult"] = "Your provider was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your provider could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateProviderService();
            var model = svc.GetProviderById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProviderService();

            service.DeleteProvider(id);

            TempData["SaveResult"] = "Your provider was deleted";

            return RedirectToAction("index");
        }

        private ProviderService CreateProviderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProviderService(userId);
            return service;
        }
    }
}