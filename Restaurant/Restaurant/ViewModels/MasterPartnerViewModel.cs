using Microsoft.AspNetCore.Http;
using RESTAURANT.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterPartnerViewModel : BaseEntity
    {
        public int MasterPartnerId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string MasterPartnerName { get; set; }
        [Display(Name = "Image")]
        public string MasterPartnerLogoImageUrl { get; set; }
        [Display(Name = "URL")]
        public string MasterPartnerWebsiteUrl { get; set; }

        public IFormFile LogoImage { get; set; }
    }
}
