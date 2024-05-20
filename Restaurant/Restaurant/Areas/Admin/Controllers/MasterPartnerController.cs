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
{ [Area("Admin")]
   
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> _MasterPartner,IHostingEnvironment _host)
        {
            MasterPartner = _MasterPartner;
            Host = _host;
        }
        // GET: MasterPartnerController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                MasterPartner.Delete(DeleteId, new MasterPartner());
            }
            if (ActiveId != 0)
            {
                MasterPartner.Active(ActiveId, new MasterPartner());
            }
            return View(MasterPartner.View());
        }

        // GET: MasterPartnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.LogoImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.LogoImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.LogoImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterPartner mp = new MasterPartner();
                mp.MasterPartnerName = collection.MasterPartnerName;
                mp.MasterPartnerId = collection.MasterPartnerId;
                mp.MasterPartnerLogoImageUrl = NameImage;
                mp.MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl;
                mp.IsActive = true;
                mp.IsDelete = false;
                mp.CreateUser = CommonHelpers.UserID;
                mp.CreateDate = DateTime.UtcNow;

                MasterPartner.Add(mp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartner.Find(id);
            MasterPartnerViewModel vm=new MasterPartnerViewModel();
            vm.MasterPartnerName=data.MasterPartnerName;
            vm.MasterPartnerLogoImageUrl=data.MasterPartnerLogoImageUrl;
            vm.MasterPartnerWebsiteUrl=data.MasterPartnerWebsiteUrl;
            vm.MasterPartnerId=data.MasterPartnerId;
            return View(vm);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.LogoImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.LogoImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.LogoImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterPartner mp = new MasterPartner();
                mp.MasterPartnerName = collection.MasterPartnerName;
                mp.MasterPartnerId = collection.MasterPartnerId;
                mp.MasterPartnerLogoImageUrl = (NameImage == "" ? collection.MasterPartnerLogoImageUrl : NameImage);
                mp.MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl;
                mp.EditUser = CommonHelpers.UserID;
                mp.EditeDate = DateTime.UtcNow;

                MasterPartner.Update(id, mp);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterPartnerController/Delete/5
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
