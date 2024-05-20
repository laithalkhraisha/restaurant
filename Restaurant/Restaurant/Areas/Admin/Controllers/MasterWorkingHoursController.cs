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
    public class MasterWorkingHoursController : Controller
    {
        public IRepository<MasterWorkingHours> MasterWork { get; }

        public MasterWorkingHoursController(IRepository<MasterWorkingHours> _MasterWork)
        {
            MasterWork = _MasterWork;
        }
        // GET: MasterWorkingHoursController
        public ActionResult Index(int DeleteId,int ActiveId)
        {
            if (DeleteId != 0)
            {
                MasterWork.Delete(DeleteId, new MasterWorkingHours());
            }
            if (ActiveId != 0)
            {
                MasterWork.Active(ActiveId, new MasterWorkingHours());
            }
            return View(MasterWork.View());
        }

        // GET: MasterWorkingHoursController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterWorkingHoursController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHoursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHours collection)
        {
            try
            {
                collection.IsActive = true;
                collection.IsDelete = false;
                collection.CreateUser = CommonHelpers.UserID;
                collection.CreateDate = DateTime.UtcNow;
                MasterWork.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHoursController/Edit/5
        public ActionResult Edit(int id)
        { 
            var data=MasterWork.Find(id);
            return View(data);
        }

        // POST: MasterWorkingHoursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHours collection)
        {
            try
            {
                
                collection.EditUser = CommonHelpers.UserID;
                collection.EditeDate = DateTime.UtcNow;
                MasterWork.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHoursController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterWorkingHoursController/Delete/5
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
