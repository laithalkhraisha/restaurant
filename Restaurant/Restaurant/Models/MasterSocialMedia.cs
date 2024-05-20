using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterSocialMedia : BaseEntity
    {
        public int MasterSocialMediaId { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string MasterSocialMediaImageUrl { get; set; }
        [Display(Name = "URL")]
        [Required]
        public string MasterSocialMediaUrl { get; set; }
    }
}
