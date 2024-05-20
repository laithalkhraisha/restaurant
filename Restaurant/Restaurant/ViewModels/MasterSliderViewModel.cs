using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterSliderViewModel
    {
        public int MasterSliderId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string MasterSliderTitle { get; set; }
        [Display(Name = "Breef")]
        [Required]
        public string MasterSliderBreef { get; set; }
        [Display(Name = "Desc")]
        [Required]
        public string MasterSliderDesc { get; set; }
        [Display(Name = "URL")]
        [Required]
        public string MasterSliderUrl { get; set; }

        public IFormFile SliderUrl { get; set; }
    }
}
