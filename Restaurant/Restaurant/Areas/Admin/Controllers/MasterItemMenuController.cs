using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Helpers;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using RESTAURANT.Models;
using System;
using System.IO;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> Masteritem { get; }
        public IRepository<MasterCategoryMenu> Mastercategory { get; }
        public IHostingEnvironment Host { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> Masteritem, IRepository<MasterCategoryMenu> Mastercategory, IHostingEnvironment _Host)
        {
            this.Masteritem = Masteritem;
            this.Mastercategory = Mastercategory;
            Host = _Host;
        }
        // GET: MasterItemMenuController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                Masteritem.Delete(DeleteId, new MasterItemMenu());
            }
            if (ActiveId != 0)
            {
                Masteritem.Active(ActiveId, new MasterItemMenu());
            }
            return View(Masteritem.View());
        }

        // GET: MasterItemMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        { 
            ViewBag.categorymenu=Mastercategory.View();
            return View();
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuViewModel collection)
        {
            try
            {
               
                string NameImage = "";
                if (collection.ItemImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.ItemImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.ItemImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterItemMenu item=new MasterItemMenu();
                item.MasterItemMenuId = collection.MasterItemMenuId;
                item.MasterItemMenuBreef = collection.MasterItemMenuBreef;
                item.MasterItemMenuDate = collection.MasterItemMenuDate;
                item.MasterItemMenuDesc = collection.MasterItemMenuDesc;
                item.MasterItemMenuImageUrl = NameImage;
                item.MasterItemMenuTitle = collection.MasterItemMenuTitle;
                item.MasterItemMenuPrice = collection.MasterItemMenuPrice;
                item.MasterCategoryMenuId = collection.MasterCategoryMenuId;
                item.IsActive = true;
                item.IsDelete = false;
                item.CreateUser = CommonHelpers.UserID;
                item.CreateDate = DateTime.UtcNow;
                Masteritem.Add(item);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.categorymenu = Mastercategory.View();
            var data = Masteritem.Find(id);
            MasterItemMenuViewModel ms=new MasterItemMenuViewModel();
            ms.MasterItemMenuTitle=data.MasterItemMenuTitle;
            ms.MasterItemMenuDesc=data.MasterItemMenuDesc;
            ms.MasterItemMenuDate  =data.MasterItemMenuDate;
            ms.MasterItemMenuImageUrl=data.MasterItemMenuImageUrl;
            ms.MasterItemMenuPrice=data.MasterItemMenuPrice;
            ms.MasterItemMenuBreef=data.MasterItemMenuBreef;
            ms.MasterCategoryMenuId = data.MasterCategoryMenuId;
            ms.MasterItemMenuId=data.MasterItemMenuId;
            ms.MasterCategoryMenu = Mastercategory.Find(data.MasterItemMenuId);
            return View(ms);
        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuViewModel collection)
        {
            try
            {
                
                
                string NameImage = "";
                if (collection.ItemImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.ItemImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.ItemImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterItemMenu item = new MasterItemMenu();
                item.MasterItemMenuId = collection.MasterItemMenuId;
                item.MasterItemMenuBreef = collection.MasterItemMenuBreef;
                item.MasterItemMenuDate = collection.MasterItemMenuDate;
                item.MasterItemMenuDesc = collection.MasterItemMenuDesc;
                item.MasterItemMenuImageUrl = (NameImage == "" ? collection.MasterItemMenuImageUrl : NameImage);
                item.MasterItemMenuTitle = collection.MasterItemMenuTitle;
                item.MasterItemMenuPrice = collection.MasterItemMenuPrice;
                item.MasterCategoryMenuId = collection.MasterCategoryMenuId;
                item.EditUser = CommonHelpers.UserID;
                item.EditeDate = DateTime.UtcNow;
                Masteritem.Update(id, item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterItemMenuController/Delete/5
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
