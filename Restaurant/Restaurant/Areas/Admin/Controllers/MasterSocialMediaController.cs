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
    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IHostingEnvironment Host { get; }

        public MasterSocialMediaController(IRepository<MasterSocialMedia> _MasterSocialMedia,IHostingEnvironment _host)
        {
            MasterSocialMedia = _MasterSocialMedia;
            Host = _host;
        }
        // GET: MasterSocialMediaController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                MasterSocialMedia.Delete(DeleteId, new MasterSocialMedia());
            }
            if (ActiveId != 0)
            {
                MasterSocialMedia.Active(ActiveId, new MasterSocialMedia());
            }
            return View(MasterSocialMedia.View());
        }

        // GET: MasterSocialMediaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterSocialMediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediaViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.MediaImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.MediaImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.MediaImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterSocialMedia sm=new MasterSocialMedia();
                sm.MasterSocialMediaUrl = collection.MasterSocialMediaUrl;
                sm.MasterSocialMediaId = collection.MasterSocialMediaId;
                sm.MasterSocialMediaImageUrl = NameImage;
                sm.IsActive = true;
                sm.IsDelete = false;
                sm.CreateUser = CommonHelpers.UserID;
                sm.CreateDate = DateTime.UtcNow;
                MasterSocialMedia.Add(sm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedia.Find(id);
            MasterSocialMediaViewModel vm=new MasterSocialMediaViewModel();
            vm.MasterSocialMediaId=data.MasterSocialMediaId;
            vm.MasterSocialMediaImageUrl=data.MasterSocialMediaImageUrl;
            vm.MasterSocialMediaUrl=data.MasterSocialMediaUrl;
            
            return View(vm);
        }

        // POST: MasterSocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediaViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.MediaImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.MediaImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.MediaImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterSocialMedia sm = new MasterSocialMedia();
                sm.MasterSocialMediaUrl = collection.MasterSocialMediaUrl;
                sm.MasterSocialMediaId = collection.MasterSocialMediaId;
                sm.MasterSocialMediaImageUrl = (NameImage == "" ? collection.MasterSocialMediaImageUrl : NameImage);
                MasterSocialMedia.Update(id,sm);
               
                sm.EditUser = CommonHelpers.UserID;
                sm.EditeDate = DateTime.UtcNow;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterSocialMediaController/Delete/5
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
