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
    public class MasterCategoryMenuController : Controller
    {
        
        public IRepository<MasterCategoryMenu> CatrgoryMenu { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> CatrgoryMenu)
        {
            this.CatrgoryMenu = CatrgoryMenu;
        }
        // GET: MasterCategoryMenuController
        public ActionResult Index(int DeleteId,int ActiveId)
        
        
        
        {
            if (ActiveId != 0)
            {
                CatrgoryMenu.Active(ActiveId, new MasterCategoryMenu());
            }

            if (DeleteId != 0)
            {
                CatrgoryMenu.Delete(DeleteId, new MasterCategoryMenu());
            }

            return View(CatrgoryMenu.View());
        }

        // GET: MasterCategoryMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {
                collection.IsActive = true;
                collection.IsDelete = false;
                collection.CreateUser = CommonHelpers.UserID;
                collection.CreateDate = DateTime.UtcNow;

                CatrgoryMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=CatrgoryMenu.Find(id);
            return View(data);
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {
                collection.EditUser=CommonHelpers.UserID;
                collection.EditeDate=DateTime.UtcNow;
                CatrgoryMenu.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int DeleteId)
        {
            var data = CatrgoryMenu.Find(DeleteId);
            return View(data);
        }

        // POST: MasterCategoryMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int DeleteId, MasterCategoryMenu collection)
        {
            try
            {
                CatrgoryMenu.Delete(DeleteId, collection);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Active(int Updateid)
        {
            
            return View();
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Active(int Updateid, MasterCategoryMenu collection)
        {
            try
            {
                CatrgoryMenu.Active(Updateid, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
