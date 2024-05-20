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
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTable { get; }

        public TransactionBookTableController( IRepository<TransactionBookTable> _TransactionBookTable)
        {
            TransactionBookTable = _TransactionBookTable;
        }
        // GET: TransactionBookTableController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                TransactionBookTable.Delete(DeleteId, new TransactionBookTable());
            }
            if (ActiveId != 0)
            {
                TransactionBookTable.Active(ActiveId, new TransactionBookTable());
            }
            return View(TransactionBookTable.View());
        }

        // GET: TransactionBookTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionBookTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionBookTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionBookTable collection)
        {
            try
            {
                collection.IsActive = true;
                collection.IsDelete = false;
                collection.CreateUser = CommonHelpers.UserID;
                collection.CreateDate = DateTime.UtcNow;
                TransactionBookTable.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=TransactionBookTable.Find(id);
            return View(data);
        }

        // POST: TransactionBookTableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionBookTable collection)
        {
            try
            {
               
                collection.EditUser = CommonHelpers.UserID;
                collection.EditeDate = DateTime.UtcNow;
                TransactionBookTable.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionBookTableController/Delete/5
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
