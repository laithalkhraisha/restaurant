using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Helpers;
using Restaurant.Models.Repositories;
using RESTAURANT.Models;
using System;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenuController(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }
        // GET: MasterMenuController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                MasterMenu.Delete(DeleteId, new MasterMenu());
            }
            if (ActiveId != 0)
            {
                MasterMenu.Active(ActiveId, new MasterMenu());
            }
            return View(MasterMenu.View());
        }

        // GET: MasterMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenu collection)
        {
            try
            {
                collection.IsActive = true;
                collection.IsDelete=false;
                collection.CreateUser = CommonHelpers.UserID;
                collection.CreateDate = DateTime.UtcNow;

                MasterMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterMenu.Find(id);
            return View(data);
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenu collection)
        {
            try
            {
                collection.EditUser = CommonHelpers.UserID;
                collection.EditeDate = DateTime.UtcNow;

                MasterMenu.Update(id, collection);  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
