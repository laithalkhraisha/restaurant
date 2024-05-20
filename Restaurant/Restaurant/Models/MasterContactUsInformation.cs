using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RESTAURANT.Models
{
    public partial class MasterContactUsInformation : BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }
        [Required]
        [Display(Name = "desc")]
        public string MasterContactUsInformationIdesc { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string MasterContactUsInformationImageUrl { get; set; }
        [Display(Name = "Redirect")]
        [Required]
        public string MasterContactUsInformationRedirect { get; set; }
        public string Icon { get; set; }
    }
}
