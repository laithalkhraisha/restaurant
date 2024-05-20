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
    [Authorize]
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public IHostingEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer> _MasterOffer,IHostingEnvironment _host)
        {
            MasterOffer = _MasterOffer;
            Host = _host;
        }
        // GET: MasterOfferController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                MasterOffer.Delete(DeleteId, new MasterOffer());
            }
            if (ActiveId != 0)
            {
                MasterOffer.Active(ActiveId, new MasterOffer());
            }
            return View(MasterOffer.View());
        }

        // GET: MasterOfferController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferViewModel collection)
        {
            try
            {

                string NameImage = "";
                if (collection.OfferImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.OfferImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.OfferImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterOffer off=new MasterOffer();
                off.MasterOfferId = collection.MasterOfferId;
                off.MasterOfferBreef = collection.MasterOfferBreef;
                off.MasterOfferDesc = collection.MasterOfferDesc;
                off.MasterOfferTitle = collection.MasterOfferTitle;
                off.MasterOfferImageUrl = NameImage;
                off.IsActive = true;
                off.IsDelete = false;
                off.CreateUser = CommonHelpers.UserID;
                off.CreateDate = DateTime.UtcNow;
                MasterOffer.Add(off);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterOffer.Find(id);
            MasterOfferViewModel vm=new MasterOfferViewModel();
            vm.MasterOfferId=data.MasterOfferId;
            vm.MasterOfferTitle=data.MasterOfferTitle;
            vm.MasterOfferImageUrl=data.MasterOfferImageUrl;
            vm.MasterOfferDesc=data.MasterOfferDesc;
            vm.MasterOfferBreef=data.MasterOfferBreef;
            return View(vm);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.OfferImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.OfferImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.OfferImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterOffer off = new MasterOffer();
                off.MasterOfferId = collection.MasterOfferId;
                off.MasterOfferBreef = collection.MasterOfferBreef;
                off.MasterOfferDesc = collection.MasterOfferDesc;
                off.MasterOfferTitle = collection.MasterOfferTitle;
                off.MasterOfferImageUrl = (NameImage == "" ? collection.MasterOfferImageUrl : NameImage);
                off.EditUser = CommonHelpers.UserID;
                off.EditeDate = DateTime.UtcNow;
                MasterOffer.Update(id, off);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterOfferController/Delete/5
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
