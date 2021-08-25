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
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            var model = service.GetLocations();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLocationService();

            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Your location was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Location could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLocationService();
            var detail = service.GetLocationById(id);
            var model =
                new LocationEdit
                {
                    LocationId = detail.LocationId,
                    City = detail.City,
                    County = detail.County,
                    ZipCode = detail.ZipCode
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LocationId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLocationService();

            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "Your location was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your location could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLocationService();

            service.DeleteLocation(id);

            TempData["SaveResult"] = "Your location was deleted";

            return RedirectToAction("index");
        }

        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;
        }
    }
}