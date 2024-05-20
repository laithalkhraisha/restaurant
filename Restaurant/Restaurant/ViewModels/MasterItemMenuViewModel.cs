using Microsoft.AspNetCore.Http;
using RESTAURANT.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterItemMenuViewModel : BaseEntity
    {
        public int MasterItemMenuId { get; set; }
        public int? MasterCategoryMenuId { get; set; }
       
        [Display(Name = "Title")]
        public string MasterItemMenuTitle { get; set; }
        [Display(Name = "Breef")]
        public string MasterItemMenuBreef { get; set; }
        [Display(Name = "Desc")]
        public string MasterItemMenuDesc { get; set; }
        [Display(Name = "Price")]
        public decimal? MasterItemMenuPrice { get; set; }
        [Display(Name = "Image")]
        public string MasterItemMenuImageUrl { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Date")]
        public DateTime? MasterItemMenuDate { get; set; }

        public virtual MasterCategoryMenu MasterCategoryMenu { get; set; }

        public IFormFile ItemImage { get; set; }
    }
}
