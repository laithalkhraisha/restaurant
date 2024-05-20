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

    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> _SystemSetting,IHostingEnvironment _host)
        {
            SystemSetting = _SystemSetting;
            Host = _host;
        }
        // GET: SystemSettingController
        public ActionResult Index(int DeleteId,int ActiveId)
        {
            if (DeleteId != 0)
            {
                SystemSetting.Delete(DeleteId, new SystemSetting());
            }
            if (ActiveId != 0)
            {
                SystemSetting.Active(ActiveId, new SystemSetting());
            }
            return View(SystemSetting.View());
        }

        // GET: SystemSettingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingViewModel collection)
        {
            try
            {
                string NoteImage = "";
                string NameImage2 = "";
                string NameImage = "";
                if (collection.LogoImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.LogoImage.FileName);
                    NameImage = "logo" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.LogoImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }

               
                if (collection.LogoImage2 != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.LogoImage2.FileName);
                    NameImage2 = "logo2" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage2);
                    collection.LogoImage2.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
               
                if (collection.NoteImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.NoteImage.FileName);
                    NoteImage = "notel" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NoteImage);
                    collection.NoteImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }

                SystemSetting ss=new SystemSetting();
                ss.SystemSettingId = collection.SystemSettingId;
                ss.SystemSettingCopyright = collection.SystemSettingCopyright;
                ss.SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef;
                ss.SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl;
                ss.SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc;
                ss.SystemSettingMapLocation = collection.SystemSettingMapLocation;
                ss.SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle;
                ss.SystemSettingLogoImageUrl = NameImage;
                ss.SystemSettingLogoImageUrl2 = NameImage2;
                ss.SystemSettingWelcomeNoteImageUrl = NoteImage;
                ss.IsActive = true;
                ss.IsDelete = false;
                ss.CreateUser = CommonHelpers.UserID;
                ss.CreateDate = DateTime.UtcNow;

                SystemSetting.Add(ss);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);
            SystemSettingViewModel sv=new SystemSettingViewModel();
            sv.SystemSettingId=data.SystemSettingId;
            sv.SystemSettingCopyright=data.SystemSettingCopyright;
            sv.SystemSettingLogoImageUrl=data.SystemSettingLogoImageUrl;
            sv.SystemSettingWelcomeNoteDesc=data.SystemSettingWelcomeNoteDesc;
            sv.SystemSettingLogoImageUrl2=data.SystemSettingLogoImageUrl2;
            sv.SystemSettingMapLocation=data.SystemSettingMapLocation;
            sv.SystemSettingWelcomeNoteBreef=data.SystemSettingWelcomeNoteBreef;
            sv.SystemSettingWelcomeNoteImageUrl=data.SystemSettingWelcomeNoteImageUrl;
            sv.SystemSettingWelcomeNoteTitle=data.SystemSettingWelcomeNoteTitle;
            sv.SystemSettingWelcomeNoteUrl=data.SystemSettingWelcomeNoteUrl;
            return View(sv);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingViewModel collection)
        {
            try
            {
                string NoteImage = "";
                string NameImage2 = "";
                string NameImage = "";
                if (collection.LogoImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.LogoImage.FileName);
                    NameImage = "logo" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.LogoImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }


                if (collection.LogoImage2 != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.LogoImage2.FileName);
                    NameImage2 = "logo2" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage2);
                    collection.LogoImage2.CopyTo(new FileStream(FullPath, FileMode.Create));

                }

                if (collection.NoteImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.NoteImage.FileName);
                    NoteImage = "notel" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NoteImage);
                    collection.NoteImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }

                SystemSetting ss = new SystemSetting();
                ss.SystemSettingId = collection.SystemSettingId;
                ss.SystemSettingCopyright = collection.SystemSettingCopyright;
                ss.SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef;
                ss.SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl;
                ss.SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc;
                ss.SystemSettingMapLocation = collection.SystemSettingMapLocation;
                ss.SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle;
                ss.SystemSettingLogoImageUrl = (NameImage == "" ? collection.SystemSettingLogoImageUrl : NameImage);
                ss.SystemSettingLogoImageUrl2 = (NameImage2==""? collection.SystemSettingLogoImageUrl2:NameImage2);
                ss.SystemSettingWelcomeNoteImageUrl = (NoteImage==""? collection.SystemSettingWelcomeNoteImageUrl:NoteImage);
                
                ss.EditUser = CommonHelpers.UserID;
                ss.EditeDate = DateTime.UtcNow;

                SystemSetting.Update(id,ss);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemSettingController/Delete/5
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
