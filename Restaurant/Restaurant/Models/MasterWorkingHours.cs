using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterWorkingHours : BaseEntity
    {
        public int MasterWorkingHoursId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string MasterWorkingHoursIdName { get; set; }
        public string MasterWorkingHoursIdTimeFormTo { get; set; }
    }
}
