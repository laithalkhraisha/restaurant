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
    public class MasterServicesController : Controller
    {
        public IRepository<MasterServices> MasterServices { get; }
        public IHostingEnvironment Host { get; }

        public MasterServicesController(IRepository<MasterServices> _MasterServices,IHostingEnvironment _host)
        {
            MasterServices = _MasterServices;
            Host = _host;
        }
        // GET: MasterServicesController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                MasterServices.Delete(DeleteId, new MasterServices());
            }
            if (ActiveId != 0)
            {
                MasterServices.Active(ActiveId, new MasterServices());
            }
            return View(MasterServices.View());
        }

        // GET: MasterServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServicesViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.ServicesImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.ServicesImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.ServicesImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterServices ms=new MasterServices();
                ms.MasterServicesId = collection.MasterServicesId;
                ms.MasterServicesDesc = collection.MasterServicesDesc;
                ms.MasterServicesTitle = collection.MasterServicesTitle;
                ms.MasterServicesImage = NameImage;
                ms.IsActive = true;
                ms.IsDelete = false;
                ms.CreateUser = CommonHelpers.UserID;
                ms.CreateDate = DateTime.UtcNow;
                MasterServices.Add(ms);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServicesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterServices.Find(id);
            MasterServicesViewModel vm=new MasterServicesViewModel();
            vm.MasterServicesId=data.MasterServicesId;
            vm.MasterServicesTitle=data.MasterServicesTitle;
            vm.MasterServicesDesc=data.MasterServicesDesc;
            vm.MasterServicesImage=data.MasterServicesImage;

            return View(vm);
        }

        // POST: MasterServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServicesViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.ServicesImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.ServicesImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.ServicesImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterServices ms = new MasterServices();
                ms.MasterServicesId = collection.MasterServicesId;
                ms.MasterServicesDesc = collection.MasterServicesDesc;
                ms.MasterServicesTitle = collection.MasterServicesTitle;
                ms.MasterServicesImage = (NameImage == "" ? collection.MasterServicesImage : NameImage);
               
                ms.EditUser = CommonHelpers.UserID;
                ms.EditeDate = DateTime.UtcNow;
                MasterServices.Update(id,ms); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServicesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterServicesController/Delete/5
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
