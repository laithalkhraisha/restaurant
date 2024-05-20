using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using RESTAURANT.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> TransactionContactUs { get; }

        public TransactionContactUsController(IRepository<TransactionContactUs> _TransactionContactUs)
        {
            TransactionContactUs = _TransactionContactUs;
        }
        // GET: TransactionContactUsController
        public ActionResult Index(int DeleteId, int ActiveId)
        {
            if (DeleteId != 0)
            {
                TransactionContactUs.Delete(DeleteId, new TransactionContactUs());
            }
            if (ActiveId != 0)
            {
                TransactionContactUs.Active(ActiveId, new TransactionContactUs());
            }
            return View(TransactionContactUs.View());
        }

        // GET: TransactionContactUsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionContactUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionContactUs collection)
        {
            try
            {
                TransactionContactUs.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUsController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=TransactionContactUs.Find(id);
            return View(data);
        }

        // POST: TransactionContactUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionContactUs collection)
        {
            try
            {
                TransactionContactUs.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionContactUsController/Delete/5
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
