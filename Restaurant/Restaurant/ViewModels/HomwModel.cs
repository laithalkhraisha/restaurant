using Restaurant.Models;
using RESTAURANT.Models;
using System.Collections;
using System.Collections.Generic;

namespace Restaurant.ViewModels
{
    public class HomwModel
    {

        public  IList<MasterMenu> ListMasterMenu{ get; set; }
        public SystemSetting SystemSetting { get; set; }
        public IList<MasterSlider> MasterSlider { get; set; }

        public IList<MasterWorkingHours> ListMasterWorkingHours { get; set; }

        public TransactionNewsletter TransactionNewsletter { get; set; }

        public IList<MasterSocialMedia> SocialMedia { get; set; }

        public IList<MasterContactUsInformation> ContactUsInformation { get; set; }

        public IList<MasterItemMenu> MasterItemMenu { get; set; }
        public TransactionBookTable TransactionBookTable { get; set; }

        public IList<MasterPartner> MasterPartner { get; set; }

        public IList<MasterOffer> MasterOffer { get; set; }
        public IList<MasterServices> MasterServices { get; set; }

        public TransactionContactUs TransactionContactUs { get; set; }
        public IList<MasterCategoryMenu> MasterCategoryMenu { get; set; }
        public IList<MasterPeople> MasterPeople { get; set; }





    }
}
