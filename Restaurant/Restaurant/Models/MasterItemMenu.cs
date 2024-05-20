using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterItemMenu : BaseEntity
    {
        public int MasterItemMenuId { get; set; }
        public int? MasterCategoryMenuId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string MasterItemMenuTitle { get; set; }
        [Display(Name = "Breef")]
        [Required]
        public string MasterItemMenuBreef { get; set; }
        [Display(Name = "Desc")]
        [Required]
        public string MasterItemMenuDesc { get; set; }
        [Display(Name = "Price")]
        [Required]
        public decimal? MasterItemMenuPrice { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string MasterItemMenuImageUrl { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Date")]
        
        public DateTime? MasterItemMenuDate { get; set; }

        public virtual MasterCategoryMenu MasterCategoryMenu { get; set; }
    }
}
