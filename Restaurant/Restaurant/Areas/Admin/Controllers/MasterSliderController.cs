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
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSlider { get; }
        public IHostingEnvironment Host { get; }

        public MasterSliderController(IRepository<MasterSlider> _MasterSlider,IHostingEnvironment _Host)
        {
            MasterSlider = _MasterSlider;
            Host = _Host;
        }
        // GET: MasterSliderController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                MasterSlider.Delete(DeleteId, new MasterSlider());
            }
            if (ActiveId != 0)
            {
                MasterSlider.Active(ActiveId, new MasterSlider());
            }
            return View(MasterSlider.View());
        }

        // GET: MasterSliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.SliderUrl != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.SliderUrl.FileName);
                    NameImage = "slider" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.SliderUrl.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterSlider ms=new MasterSlider();
                ms.MasterSliderId = collection.MasterSliderId;
                ms.MasterSliderDesc = collection.MasterSliderDesc;
                ms.MasterSliderBreef = collection.MasterSliderBreef;
                ms.MasterSliderTitle = collection.MasterSliderTitle;
                ms.MasterSliderUrl = NameImage;
                ms.IsActive = true;
                ms.IsDelete = false;
                ms.CreateUser = CommonHelpers.UserID;
                ms.CreateDate = DateTime.UtcNow;

                MasterSlider.Add(ms);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=MasterSlider.Find(id);
            MasterSliderViewModel ms = new MasterSliderViewModel();
            ms.MasterSliderId=data.MasterSliderId;
            ms.MasterSliderBreef=data.MasterSliderBreef;
            ms.MasterSliderDesc=data.MasterSliderDesc;
            ms.MasterSliderTitle=data.MasterSliderTitle;
            ms.MasterSliderUrl=data.MasterSliderUrl;
            return View(ms);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.SliderUrl != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.SliderUrl.FileName);
                    NameImage = "slider" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.SliderUrl.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterSlider ms = new MasterSlider();
                ms.MasterSliderId = collection.MasterSliderId;
                ms.MasterSliderDesc = collection.MasterSliderDesc;
                ms.MasterSliderBreef = collection.MasterSliderBreef;
                ms.MasterSliderTitle = collection.MasterSliderTitle;
                ms.MasterSliderUrl = (NameImage == "" ? collection.MasterSliderUrl : NameImage);
              
                ms.EditUser = CommonHelpers.UserID;
                ms.EditeDate = DateTime.UtcNow;



                MasterSlider.Update(id, ms);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterSliderController/Delete/5
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
