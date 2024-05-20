using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterCategoryMenu:BaseEntity
    {
      
        public int MasterCategoryMenuId { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string MasterCategoryMenuName { get; set; }

        
    }
}
