using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterServices : BaseEntity
    {
        public int MasterServicesId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string MasterServicesTitle { get; set; }
        [Display(Name = "Desc")]
        [Required]
        public string MasterServicesDesc { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string MasterServicesImage { get; set; }
    }
}
