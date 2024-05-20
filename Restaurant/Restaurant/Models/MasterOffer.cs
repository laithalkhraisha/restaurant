using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterOffer : BaseEntity
    {
        public int MasterOfferId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string MasterOfferTitle { get; set; }
        [Display(Name = "Breef")]
        [Required]
        public string MasterOfferBreef { get; set; }
        [Display(Name = "Desc")]
        [Required]
        public string MasterOfferDesc { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string MasterOfferImageUrl { get; set; }
    }
}
