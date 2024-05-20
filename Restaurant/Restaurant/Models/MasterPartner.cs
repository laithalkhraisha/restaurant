using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterPartner : BaseEntity
    {
        public int MasterPartnerId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string MasterPartnerName { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string MasterPartnerLogoImageUrl { get; set; }
        [Display(Name = "URL")]
        [Required]
        public string MasterPartnerWebsiteUrl { get; set; }
    }
}
