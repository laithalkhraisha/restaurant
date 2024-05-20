using RESTAURANT.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MasterPeople:BaseEntity
    {
        public int MasterPeopleId { get; set; }
        [Required]
        [Display(Name = "Desc")]
        public string MasterPeopledec { get; set;}
        [Required]
        [Display(Name = "Name")]
        public string MasterPeopleName { get; set;}
        [Required]
        [Display(Name = "Image")]
        public string MasterPeopleImageUrl { get; set; }
        [Display(Name = "job")]
        public string MasterPeoplejob { get; set; }

    }
}
