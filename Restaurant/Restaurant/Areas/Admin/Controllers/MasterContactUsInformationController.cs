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

    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUs { get; }
        public IHostingEnvironment Host { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> MasterContactUs, IHostingEnvironment _Host)
        {
            this.MasterContactUs = MasterContactUs;
            Host = _Host;
        }
        // GET: MasterContactUsInformationController
        public ActionResult Index(int DeleteId,int ActiveId)
        {
            if (DeleteId!=0)
            {
                MasterContactUs.Delete(DeleteId, new MasterContactUsInformation());
            }
            if (ActiveId!=0)
            {
                MasterContactUs.Active(ActiveId, new MasterContactUsInformation());
            }
            return View(MasterContactUs.View());
        }

        // GET: MasterContactUsInformationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformationViewModel  collection)
        {
            try
            {
               
                string NameImage = "";
                if (collection.ContactUsImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.ContactUsImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.ContactUsImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterContactUsInformation us = new MasterContactUsInformation();
                us.MasterContactUsInformationId = collection.MasterContactUsInformationId;
                us.MasterContactUsInformationIdesc=collection.MasterContactUsInformationIdesc;
                us.MasterContactUsInformationImageUrl = NameImage;
                us.MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect;
                us.Icon = collection.Icon;
                us.IsActive=true;
                us.IsDelete = false;
                us.CreateUser= CommonHelpers.UserID;
                us.CreateDate= DateTime.UtcNow;

                MasterContactUs.Add(us);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {

            var data = MasterContactUs.Find(id);
            MasterContactUsInformationViewModel us = new MasterContactUsInformationViewModel();
            us.MasterContactUsInformationId=data.MasterContactUsInformationId;
            us.MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc;
            us.MasterContactUsInformationImageUrl=data.MasterContactUsInformationImageUrl;
            us.MasterContactUsInformationRedirect=data.MasterContactUsInformationRedirect;
            us.Icon = data.Icon;

            return View(us);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformationViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.ContactUsImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.ContactUsImage.FileName);
                    NameImage = "XYZ" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.ContactUsImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterContactUsInformation us = new MasterContactUsInformation();
                us.MasterContactUsInformationId = collection.MasterContactUsInformationId;
                us.MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc;
                us.MasterContactUsInformationImageUrl = (NameImage == "" ? collection.MasterContactUsInformationImageUrl : NameImage);
                us.MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect;
                us.Icon = collection.Icon;
                us.EditUser = CommonHelpers.UserID;
                us.EditeDate = DateTime.UtcNow;
                MasterContactUs.Update(id,us);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Delete/5
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
