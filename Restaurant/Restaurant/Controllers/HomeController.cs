using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using RESTAURANT.Models;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterWorkingHours> MasterWorkingHours { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IRepository<MasterContactUsInformation> ContactUsInformation { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<MasterServices> MasterServices { get; }
        public IRepository<TransactionContactUs> TransactionContactUs { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IRepository<MasterPeople> MasterPeople { get; }

        public HomeController(IRepository<MasterMenu> _MasterMenu, IRepository<SystemSetting> _SystemSetting, IRepository<MasterWorkingHours> _MasterWorkingHours, IRepository<TransactionNewsletter> _TransactionNewsletter, IRepository<MasterSocialMedia> _MasterSocialMedia, IRepository<MasterContactUsInformation> _ContactUsInformation, IRepository<MasterSlider> _MasterSlider, IRepository<MasterItemMenu> _MasterItemMenu, IRepository<TransactionBookTable> _TransactionBookTable, IRepository<MasterPartner> _MasterPartner, IRepository<MasterOffer> _MasterOffer, IRepository<MasterServices> _MasterServices, IRepository<TransactionContactUs> _TransactionContactUs, IRepository<MasterCategoryMenu> _MasterCategoryMenu, IRepository<MasterPeople> _MasterPeople)
        {
            MasterMenu = _MasterMenu;
            SystemSetting = _SystemSetting;
            MasterWorkingHours = _MasterWorkingHours;
            TransactionNewsletter = _TransactionNewsletter;
            MasterSocialMedia = _MasterSocialMedia;
            ContactUsInformation = _ContactUsInformation;
            MasterSlider = _MasterSlider;
            MasterItemMenu = _MasterItemMenu;
            TransactionBookTable = _TransactionBookTable;
            MasterPartner = _MasterPartner;
            MasterOffer = _MasterOffer;
            MasterServices = _MasterServices;
            TransactionContactUs = _TransactionContactUs;
            MasterCategoryMenu = _MasterCategoryMenu;
            MasterPeople = _MasterPeople;
        }


        public IActionResult Index()
        {
            var ss=SystemSetting.Find(17);
            


            var Model = new HomwModel
            {
                ListMasterMenu = MasterMenu.ViewFrontClient(),
                ListMasterWorkingHours = MasterWorkingHours.ViewFrontClient(),
                SocialMedia = MasterSocialMedia.ViewFrontClient(),
                ContactUsInformation = ContactUsInformation.ViewFrontClient(),
                MasterSlider = MasterSlider.ViewFrontClient(),
                MasterItemMenu= MasterItemMenu.ViewFrontClient(),
                MasterPartner= MasterPartner.ViewFrontClient(),
                MasterOffer= MasterOffer.ViewFrontClient(),
                MasterPeople= MasterPeople.ViewFrontClient(),
                SystemSetting = ss
                
                
            };

            return View(Model);
        }


        public IActionResult About()
        {
            var ss = SystemSetting.Find(17);
            var Model = new HomwModel
            {
                ListMasterMenu = MasterMenu.ViewFrontClient(),
                
                ListMasterWorkingHours = MasterWorkingHours.ViewFrontClient(),
                SocialMedia = MasterSocialMedia.View(),
                ContactUsInformation = ContactUsInformation.ViewFrontClient(),
                MasterServices = MasterServices.ViewFrontClient(),
                 SystemSetting = ss
            };

            return View(Model);
        }
        public IActionResult ContactUs()
        {
            var ss = SystemSetting.Find(17);
            var Model = new HomwModel
            {
                ListMasterMenu = MasterMenu.ViewFrontClient(),

                ListMasterWorkingHours = MasterWorkingHours.ViewFrontClient(),
                SocialMedia = MasterSocialMedia.ViewFrontClient(),
                ContactUsInformation = ContactUsInformation.ViewFrontClient(),
                MasterServices = MasterServices.ViewFrontClient(),
                SystemSetting = ss
            };

            return View(Model);
        }
        public IActionResult Menu()
        {
            var ss = SystemSetting.Find(17);
            var Model = new HomwModel
            {
                ListMasterMenu = MasterMenu.ViewFrontClient(),

                ListMasterWorkingHours = MasterWorkingHours.ViewFrontClient(),
                SocialMedia = MasterSocialMedia.View(),
                ContactUsInformation = ContactUsInformation.ViewFrontClient(),
                MasterPartner=MasterPartner.ViewFrontClient(),
                MasterCategoryMenu = MasterCategoryMenu.ViewFrontClient(),
                MasterItemMenu = MasterItemMenu.ViewFrontClient(),
                SystemSetting = ss
            };
            
            return View(Model);
        }
        public IActionResult productDetails()
        {
            var ss = SystemSetting.Find(17);
            var Model = new HomwModel
            {
                ListMasterMenu = MasterMenu.ViewFrontClient(),

                ListMasterWorkingHours = MasterWorkingHours.ViewFrontClient(),
                SocialMedia = MasterSocialMedia.View(),
                ContactUsInformation = ContactUsInformation.ViewFrontClient(),
                MasterCategoryMenu = MasterCategoryMenu.ViewFrontClient(),
                MasterItemMenu = MasterItemMenu.ViewFrontClient(),
                SystemSetting = ss
            };
         
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aboutcreate(HomwModel collection)
        {
            try
            {
                TransactionNewsletter newsletter=new TransactionNewsletter();
                newsletter.TransactionNewsletterEmail = collection.TransactionNewsletter.TransactionNewsletterEmail;
              

                TransactionNewsletter.Add(newsletter);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booktabel(HomwModel collection)
        {
            try
            {
                TransactionBookTable bt = new TransactionBookTable();
                bt.TransactionBookTableMobileNumber = collection.TransactionBookTable.TransactionBookTableMobileNumber;
                bt.TransactionBookTableId = collection.TransactionBookTable.TransactionBookTableId;
                bt.TransactionBookTableDate = collection.TransactionBookTable.TransactionBookTableDate;
                bt.TransactionBookTableEmail = collection.TransactionBookTable.TransactionBookTableEmail;
                bt.TransactionBookTableFullName = collection.TransactionBookTable.TransactionBookTableFullName;
                TransactionBookTable.Add(bt);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMsg(HomwModel collection)
        {
            try
            {
                TransactionContactUs tc = new TransactionContactUs();
                tc.TransactionContactUsId=collection.TransactionContactUs.TransactionContactUsId;
                tc.TransactionContactUsFullName=collection.TransactionContactUs.TransactionContactUsFullName;
                tc.TransactionContactUsEmail = collection.TransactionContactUs.TransactionContactUsEmail;
                tc.TransactionContactUsSubject = collection.TransactionContactUs.TransactionContactUsSubject;
                tc.TransactionContactUsMessage = collection.TransactionContactUs.TransactionContactUsMessage;

                TransactionContactUs.Add(tc);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
