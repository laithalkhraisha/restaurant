using Microsoft.AspNetCore.Http;
using RESTAURANT.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterOfferViewModel : BaseEntity
    {
        public int MasterOfferId { get; set; }
        [Required] 
        [Display(Name = "Title")]
        public string MasterOfferTitle { get; set; }
        [Display(Name = "Breef")]
        public string MasterOfferBreef { get; set; }
        [Display(Name = "Desc")]
        public string MasterOfferDesc { get; set; }
        [Display(Name = "Image")]
        public string MasterOfferImageUrl { get; set; }

        public IFormFile OfferImage { get; set; }
    }
}
