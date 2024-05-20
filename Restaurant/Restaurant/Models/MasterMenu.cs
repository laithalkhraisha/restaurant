using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterMenu : BaseEntity
    {
        public int MasterMenuId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string MasterMenuName { get; set; }
        [Required]
        public string MasterMenuUrl { get; set; }
    }
}
