using Microsoft.AspNetCore.Http;
using RESTAURANT.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterContactUsInformationViewModel: BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }
        [Required]
        [Display(Name = "desc")]
        public string MasterContactUsInformationIdesc { get; set; }
        [Display(Name = "Image")]
        public string MasterContactUsInformationImageUrl { get; set; }
        [Display(Name = "Redirect")]
        public string MasterContactUsInformationRedirect { get; set; }
        public string Icon { get; set; }

        public IFormFile ContactUsImage { get; set; }
    }
}

