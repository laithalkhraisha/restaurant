using Microsoft.AspNetCore.Http;
using RESTAURANT.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterServicesViewModel : BaseEntity
    {
        public int MasterServicesId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string MasterServicesTitle { get; set; }
        [Display(Name = "Desc")]
        public string MasterServicesDesc { get; set; }
        [Display(Name = "Image")]
        public string MasterServicesImage { get; set; }

        public IFormFile ServicesImage { get; set; }

    }
}
