using Microsoft.AspNetCore.Http;
using RESTAURANT.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterSocialMediaViewModel : BaseEntity
    {
        public int MasterSocialMediaId { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string MasterSocialMediaImageUrl { get; set; }
        [Display(Name = "URL")]
        [Required]
        public string MasterSocialMediaUrl { get; set; }
        public IFormFile MediaImage { get; set; }

    }
}
