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
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userId);
            var model = service.GetServices();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateServiceService();

            if (service.CreateService(model))
            {
                TempData["SaveResult"] = "Your service was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Service could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateServiceService();
            var model = svc.GetServiceById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateServiceService();
            var detail = service.GetServiceById(id);
            var model =
                new ServiceEdit
                {
                    ServiceId = detail.ServiceId,
                    ServiceName = detail.ServiceName
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ServiceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateServiceService();

            if (service.UpdateService(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        /*        public ActionResult Delete(int id)
                {
                    var svc = CreateServiceService();
                    var model = svc.GetServiceById(id);

                    return View(model);
                }

                [HttpPost]
                [ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public ActionResult DeletePost(int id)
                {
                    var service = CreateServiceService();

                    service.DeleteService(id);

                    TempData["SaveResult"] = "Your service was deleted";

                    return RedirectToAction("index");
                }*/

        private ServiceService CreateServiceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userId);
            return service;
        }
    }
}