using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterSlider : BaseEntity
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
    }
}
