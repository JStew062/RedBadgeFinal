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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            var model = service.GetClients();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "The Client was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The CLient could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateClientService();
            var detail = service.GetClientById(id);
            var model =
                new ClientEdit
                {
                    ClientId = detail.ClientId,
                    ClientName = detail.ClientName,
                    LocationId = detail.LocationId,
                    CaseMgr = detail.CaseMgr
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "The Client was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Client could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClientService();

            service.DeleteClient(id);

            TempData["SaveResult"] = "The Client was deleted";

            return RedirectToAction("index");
        }

        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
    }
}