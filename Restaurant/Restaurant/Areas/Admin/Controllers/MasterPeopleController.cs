using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Helpers;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System;
using System.IO;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterPeopleController : Controller
    {
        public IRepository<MasterPeople> MasterPeople { get; }
        public IHostingEnvironment Host { get; }

        public MasterPeopleController(IRepository<MasterPeople> _MasterPeople, IHostingEnvironment _host)
        {
            MasterPeople = _MasterPeople;
            Host = _host;
        }
        // GET: MasterPeopleController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                MasterPeople.Delete(DeleteId, new MasterPeople());
            }
            if (ActiveId != 0)
            {
                MasterPeople.Active(ActiveId, new MasterPeople());
            }
            return View(MasterPeople.View());
        }

        // GET: MasterPeopleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterPeopleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPeopleViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.peopleImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.peopleImage.FileName);
                    NameImage = "people" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.peopleImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterPeople mp=new MasterPeople();
                mp.MasterPeopleId = collection.MasterPeopleId;
                mp.MasterPeopleName= collection.MasterPeopleName;
                mp.MasterPeopledec= collection.MasterPeopledec;
                mp.MasterPeoplejob= collection.MasterPeoplejob;
                mp.MasterPeopleImageUrl = NameImage;
                mp.IsActive = true;
                mp.IsDelete = false;
                mp.CreateUser = CommonHelpers.UserID;
                mp.CreateDate = DateTime.UtcNow;
                MasterPeople.Add(mp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPeople.Find(id);
            MasterPeopleViewModel model = new MasterPeopleViewModel();
            model.MasterPeopleId= data.MasterPeopleId;
            model.MasterPeopleName = data.MasterPeopleName;
            model.MasterPeopledec = data.MasterPeopledec;
            model.MasterPeopleImageUrl= data.MasterPeopleImageUrl;
            model.MasterPeoplejob = data.MasterPeoplejob;
            return View(model);
        }

        // POST: MasterPeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPeopleViewModel collection)
        {
            try
            {
                string NameImage = "";
                if (collection.peopleImage != null)
                {
                    string PathImage = Path.Combine(Host.WebRootPath, "Images");
                    FileInfo info = new FileInfo(collection.peopleImage.FileName);
                    NameImage = "people" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + info.Extension;
                    string FullPath = Path.Combine(PathImage, NameImage);
                    collection.peopleImage.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                MasterPeople mp = new MasterPeople();
                mp.MasterPeopleId = collection.MasterPeopleId;
                mp.MasterPeopleName = collection.MasterPeopleName;
                mp.MasterPeopledec = collection.MasterPeopledec;
                mp.MasterPeoplejob = collection.MasterPeoplejob;
                mp.MasterPeopleImageUrl = (NameImage == "" ? collection.MasterPeopleImageUrl : NameImage);
               
                mp.EditUser = CommonHelpers.UserID;
                mp.EditeDate = DateTime.UtcNow;
                MasterPeople.Update(id,mp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPeopleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterPeopleController/Delete/5
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
